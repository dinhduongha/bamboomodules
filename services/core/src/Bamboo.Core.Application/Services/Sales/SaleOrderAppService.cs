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
    [Module("Sale", Category = "Sales", Depends = new[] { "sales_team", "account_payment", "utm" })]
    public partial class SaleOrderAppService : GenericAppService<SaleOrder>, ISaleOrderAppService
    {
        private readonly IAccountDocumentImportMixinAppService _accountDocumentImportMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        private readonly IUtmMixinAppService _utmMixinAppService;
        public SaleOrderAppService(IRepository<SaleOrder, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAccountDocumentImportMixinAppService accountDocumentImportMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IPosLoadMixinAppService posLoadMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _accountDocumentImportMixinAppService = accountDocumentImportMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        protected async Task<SaleOrder> ActionCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // res = super()._action_cancel()
            // self.order_line._cancel_repair_order()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // inv = self.invoice_ids.filtered(lambda inv: inv.state == 'draft')
            // inv.button_cancel()
            // return self.write({'state': 'cancel'})
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // previously_confirmed = self.filtered(lambda s: s.state == 'sale')
            // res = super()._action_cancel()
            // 
            // order_history_lines = self.env['loyalty.history'].search([
            //     ('order_model', '=', self._name),
            //     ('order_id', 'in', previously_confirmed.ids),
            // ])
            // if order_history_lines:
            //     order_history_lines.sudo().unlink()
            // 
            // # Add/remove the points to our coupons
            // for coupon, changes in previously_confirmed.filtered(
            //     lambda s: s.state != 'sale'
            // )._get_point_changes().items():
            //     coupon.points -= changes
            // # Remove any rewards
            // self.order_line.filtered(lambda l: l.is_reward_line).unlink()
            // self.coupon_point_ids.coupon_id.sudo().filtered(
            //     lambda c: not c.program_id.is_nominative and c.order_id in self and not c.use_count)\
            //     .unlink()
            // self.coupon_point_ids.unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // result = super()._action_cancel()
            // # When a sale person cancel a SO, he might not have the rights to write
            // # on PO. But we need the system to create an activity on the PO (so 'write'
            // # access), hence the `sudo`.
            // self.sudo()._activity_cancel_on_purchase()
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // documents = None
            // for sale_order in self:
            //     if sale_order.state == 'sale' and sale_order.order_line:
            //         sale_order_lines_quantities = {order_line: (order_line.product_uom_qty, 0) for order_line in sale_order.order_line}
            //         documents = self.env['stock.picking'].with_context(include_draft_documents=True)._log_activity_get_documents(sale_order_lines_quantities, 'move_ids', 'UP')
            // self.picking_ids.filtered(lambda p: p.state != 'done').action_cancel()
            // if documents:
            //     filtered_documents = {}
            //     for (parent, responsible), rendering_context in documents.items():
            //         if parent._name == 'stock.picking':
            //             if parent.state == 'cancel':
            //                 continue
            //         filtered_documents[(parent, responsible)] = rendering_context
            //     self._log_decrease_ordered_quantity(filtered_documents, cancel=True)
            // return super()._action_cancel()
            */
            return default;
        }

        protected async Task<SaleOrder> ActionConfirmInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // for order in self:
            //     order_location = order.pickup_location_data
            // 
            //     if not order_location:
            //         continue
            // 
            //     # Retrieve all the data : name, street, city, state, zip, country.
            //     name = order_location.get('name') or order.partner_shipping_id.name
            //     street = order_location['street']
            //     city = order_location['city']
            //     zip_code = order_location['zip_code']
            //     country_code = order_location['country_code']
            //     country = order.env['res.country'].search([('code', '=', country_code)]).id
            //     state = order.env['res.country.state'].search([
            //         ('code', '=', order_location['state']),
            //         ('country_id', '=', country),
            //     ]).id if (order_location.get('state') and country) else None
            //     parent_id = order.partner_shipping_id.id
            //     email = order.partner_shipping_id.email
            //     phone = order.partner_shipping_id.phone
            // 
            //     # Check if the current partner has a partner of type 'delivery' with the same address.
            //     existing_partner = order.env['res.partner'].search([
            //         ('street', '=', street),
            //         ('city', '=', city),
            //         ('state_id', '=', state),
            //         ('country_id', '=', country),
            //         ('parent_id', '=', parent_id),
            //         ('type', '=', 'delivery'),
            //     ], limit=1)
            // 
            //     shipping_partner = existing_partner or order.env['res.partner'].create({
            //         'parent_id': parent_id,
            //         'type': 'delivery',
            //         'name': name,
            //         'street': street,
            //         'city': city,
            //         'state_id': state,
            //         'zip': zip_code,
            //         'country_id': country,
            //         'email': email,
            //         'phone': phone,
            //         'is_pickup_location': True,
            //     })
            //     order.with_context(update_delivery_shipping_partner=True).write({'partner_shipping_id': shipping_partner})
            // return super()._action_confirm()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // res = super()._action_confirm()
            // self.order_line._create_repair_order()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // """ Implementation of additional mechanism of Sales Order confirmation.
            //     This method should be extended when the confirmation should generated
            //     other documents. In this method, the SO are in 'sale' state (not yet 'done').
            // """
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // """ On SO confirmation, some lines should generate a task or a project. """
            // if self.env.context.get('disable_project_task_generation'):
            //     return super()._action_confirm()
            // 
            // if len(self.company_id) == 1:
            //     # All orders are in the same company
            //     self.order_line.sudo().with_company(self.company_id)._timesheet_service_generation()
            // else:
            //     # Orders from different companies are confirmed together
            //     for order in self:
            //         order.order_line.sudo().with_company(order.company_id)._timesheet_service_generation()
            // 
            // # If the order has exactly one project and that project comes from a template, set the company of the template
            // # on the project.
            // for order in self.sudo(): # Salesman may not have access to projects
            //     if len(order.project_ids) == 1:
            //         project = order.project_ids[0]
            //         for sol in order.order_line:
            //             if project == sol.project_id and (project_template := sol.product_template_id.project_template_id):
            //                 project.sudo().company_id = project_template.sudo().company_id
            //                 break
            // return super()._action_confirm()
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // result = super(SaleOrder, self)._action_confirm()
            // for order in self:
            //     order.order_line.sudo()._purchase_service_generation()
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // self.order_line._action_launch_stock_rule()
            // return super(SaleOrder, self)._action_confirm()
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // """ If the product of an order line is a 'course', we add the client of the sale_order
            // as a member of the channel(s) on which this product is configured (see slide.channel.product_id). """
            // result = super(SaleOrder, self)._action_confirm()
            // 
            // so_lines = self.env['sale.order.line'].search(
            //     [('order_id', 'in', self.ids)]
            // )
            // products = so_lines.mapped('product_id')
            // related_channels = self.env['slide.channel'].search(
            //     [('product_id', 'in', products.ids), ('enroll', '=', 'payment')],
            // )
            // channel_products = related_channels.mapped('product_id')
            // 
            // channels_per_so = {sale_order: self.env['slide.channel'] for sale_order in self}
            // for so_line in so_lines:
            //     if so_line.product_id in channel_products:
            //         for related_channel in related_channels:
            //             if related_channel.product_id == so_line.product_id:
            //                 channels_per_so[so_line.order_id] = channels_per_so[so_line.order_id] | related_channel
            // 
            // for sale_order, channels in channels_per_so.items():
            //     channels.sudo()._action_add_members(sale_order.partner_id)
            // 
            // return result
            */
            return default;
        }

        protected async Task<SaleOrder> ActivityCancelOnPurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def _activity_cancel_on_purchase(self):
            // """ If some SO are cancelled, we need to put an activity on their generated purchase. If sale lines of
            //     different sale orders impact different purchase, we only want one activity to be attached.
            // """
            // purchase_to_notify_map = {}  # map PO -> recordset of SOL as {purchase.order: set(sale.orde.liner)}
            // 
            // purchase_order_lines = self.env['purchase.order.line'].search([
            //     ('sale_line_id', 'in', self.mapped('order_line').ids),
            //     ('state', '!=', 'cancel'),
            //     ('product_id.service_to_purchase', '=', True),
            // ])
            // for purchase_line in purchase_order_lines:
            //     purchase_to_notify_map.setdefault(purchase_line.order_id, self.env['sale.order.line'])
            //     purchase_to_notify_map[purchase_line.order_id] |= purchase_line.sale_line_id
            // 
            // for purchase_order, sale_order_lines in purchase_to_notify_map.items():
            //     purchase_order._activity_schedule_with_view('mail.mail_activity_data_warning',
            //         user_id=purchase_order.user_id.id or self.env.uid,
            //         views_or_xmlid='sale_purchase.exception_purchase_on_sale_cancellation',
            //         render_context={
            //             'sale_orders': sale_order_lines.mapped('order_id'),
            //             'sale_order_lines': sale_order_lines,
            //     })
            */
            return default;
        }

        protected async Task<SaleOrder> AddBaseLinesForEarlyPaymentDiscountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _add_base_lines_for_early_payment_discount(self):
            // """
            // When applying a payment term with an early payment discount, and when said payment term computes the tax on the
            // 'mixed' setting, the tax computation is always based on the discounted amount untaxed.
            // Creates the necessary line for this behavior to be displayed.
            // :returns: array containing the necessary lines or empty array if the payment term isn't epd mixed
            // """
            // self.ensure_one()
            // epd_lines = []
            // if (
            //     self.payment_term_id.early_discount
            //     and self.payment_term_id.early_pay_discount_computation == 'mixed'
            //     and self.payment_term_id.discount_percentage
            // ):
            //     percentage = self.payment_term_id.discount_percentage
            //     currency = self.currency_id or self.company_id.currency_id
            //     for line in self._get_priced_lines():
            //         line_amount_after_discount = (line.price_subtotal / 100) * percentage
            //         epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             record=self,
            //             price_unit=-line_amount_after_discount,
            //             quantity=1.0,
            //             currency_id=currency,
            //             sign=1,
            //             special_type='early_payment',
            //             tax_ids=line.tax_ids.flatten_taxes_hierarchy().filtered(lambda tax: tax.amount_type != 'fixed'),
            //         ))
            //         epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             record=self,
            //             price_unit=line_amount_after_discount,
            //             quantity=1.0,
            //             currency_id=currency,
            //             sign=1,
            //             special_type='early_payment',
            //         ))
            // return epd_lines
            */
            return default;
        }

        protected async Task<SaleOrder> AddLoyaltyHistoryLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _add_loyalty_history_lines(self):
            // self.ensure_one()
            // points_per_coupon = defaultdict(partial(defaultdict, int))
            // for coupon_point in self.coupon_point_ids:
            //     points_per_coupon[coupon_point.coupon_id]['issued'] = coupon_point.points
            // for line in self.order_line:
            //     if not line.coupon_id:
            //         continue
            //     points_per_coupon[line.coupon_id]['cost'] += line.points_cost
            // 
            // create_values = []
            // base_values = {
            //     'order_id': self.id,
            //     'order_model': self._name,
            //     'description': _("Order %s", self.display_name),
            // }
            // for coupon, point_dict in points_per_coupon.items():
            //     cost = point_dict.get('cost', 0.0)
            //     issued = point_dict.get('issued', 0.0)
            //     create_values.append({
            //         **base_values,
            //         'card_id': coupon.id,
            //         'used': cost,
            //         'issued': issued,
            //     })
            // 
            // self.env['loyalty.history'].create(create_values)
            */
            return default;
        }

        protected async Task<SaleOrder> AddPartnershipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: sale_order.py) ---
            // def _add_partnership(self):
            // for so in self:
            //     if not so.assigned_grade_id:
            //         continue
            //     so.partner_id.commercial_partner_id.grade_id = so.assigned_grade_id
            */
            return default;
        }

        protected async Task<SaleOrder> AddPointsForCouponInternalAsync(object coupon_points)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _add_points_for_coupon(self, coupon_points):
            // """
            // Updates (or creates) an entry in coupon_point_ids for the given coupons.
            // """
            // self.ensure_one()
            // if self.state == 'sale':
            //     for coupon, points in coupon_points.items():
            //         coupon.sudo().points += points
            // for pe in self.coupon_point_ids.sudo():
            //     if pe.coupon_id in coupon_points:
            //         pe.points = coupon_points.pop(pe.coupon_id)
            // if coupon_points:
            //     self.sudo().with_context(tracking_disable=True).write({
            //         'coupon_point_ids': [(0, 0, {
            //             'coupon_id': coupon.id,
            //             'points': points,
            //         }) for coupon, points in coupon_points.items()]
            //     })
            */
            return default;
        }

        protected async Task<SaleOrder> AddReferenceInternalAsync(object reference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _add_reference(self, reference):
            // """ link the given references to the list of references. """
            // self.ensure_one()
            // self.stock_reference_ids = [Command.link(stock_reference.id) for stock_reference in reference]
            */
            return default;
        }

        protected async Task<SaleOrder> AllProductAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _all_product_available(self):
            // self.ensure_one()
            // if not (lines := self.order_line):
            //     return True
            // return not any(product._is_sold_out() for product in lines.product_id)
            */
            return default;
        }

        protected async Task<SaleOrder> AllowNominativeProgramsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _allow_nominative_programs(self):
            // """
            // Whether or not this order may use nominative programs.
            // """
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _allow_nominative_programs(self):
            // if not request or not hasattr(request, 'website'):
            //     return super()._allow_nominative_programs()
            // return not request.website.is_public_user() and super()._allow_nominative_programs()
            */
            return default;
        }

        protected async Task<SaleOrder> ApplyGridInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py) ---
            // def _apply_grid(self):
            // """Apply the given list of changed matrix cells to the current SO."""
            // if self.grid and self.grid_update:
            //     grid = json.loads(self.grid)
            //     product_template = self.env['product.template'].browse(grid['product_template_id'])
            //     dirty_cells = grid['changes']
            //     Attrib = self.env['product.template.attribute.value']
            //     default_so_line_vals = {}
            //     new_lines = []
            //     for cell in dirty_cells:
            //         combination = Attrib.browse(cell['ptav_ids'])
            //         no_variant_attribute_values = combination - combination._without_no_variant_attributes()
            // 
            //         # create or find product variant from combination
            //         product = product_template._create_product_variant(combination)
            //         order_lines = self.order_line.filtered(
            //             lambda line: line.product_id.id == product.id
            //             and line.product_no_variant_attribute_value_ids.ids == no_variant_attribute_values.ids
            //             and not line.combo_item_id
            //         )
            // 
            //         # if product variant already exist in order lines
            //         old_qty = sum(order_lines.mapped('product_uom_qty'))
            //         qty = cell['qty']
            //         diff = qty - old_qty
            // 
            //         if not diff:
            //             continue
            // 
            //         # TODO keep qty check? cannot be 0 because we only get cell changes ...
            //         if order_lines:
            //             if qty == 0:
            //                 if self.state in ['draft', 'sent']:
            //                     # Remove lines if qty was set to 0 in matrix
            //                     # only if SO state = draft/sent
            //                     self.order_line -= order_lines
            //                 else:
            //                     order_lines.update({'product_uom_qty': 0.0})
            //             else:
            //                 """
            //                 When there are multiple lines for same product and its quantity was changed in the matrix,
            //                 An error is raised.
            // 
            //                 A 'good' strategy would be to:
            //                     * Sets the quantity of the first found line to the cell value
            //                     * Remove the other lines.
            // 
            //                 But this would remove all business logic linked to the other lines...
            //                 Therefore, it only raises an Error for now.
            //                 """
            //                 if len(order_lines) > 1:
            //                     raise ValidationError(_("You cannot change the quantity of a product present in multiple sale lines."))
            //                 else:
            //                     order_lines[0].product_uom_qty = qty
            //                     # If we want to support multiple lines edition:
            //                     # removal of other lines.
            //                     # For now, an error is raised instead
            //                     # if len(order_lines) > 1:
            //                     #     # Remove 1+ lines
            //                     #     self.order_line -= order_lines[1:]
            //         else:
            //             if not default_so_line_vals:
            //                 OrderLine = self.env['sale.order.line']
            //                 default_so_line_vals = OrderLine.default_get(OrderLine._fields.keys())
            //             last_sequence = self.order_line[-1:].sequence
            //             if last_sequence:
            //                 default_so_line_vals['sequence'] = last_sequence
            //             new_lines.append((0, 0, dict(
            //                 default_so_line_vals,
            //                 product_id=product.id,
            //                 product_uom_qty=qty,
            //                 product_no_variant_attribute_value_ids=no_variant_attribute_values.ids)
            //             ))
            //     if new_lines:
            //         # Add new SO lines
            //         self.update(dict(order_line=new_lines))
            */
            return default;
        }

        protected async Task<SaleOrder> ApplyProgramRewardInternalAsync(object reward, object coupon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _apply_program_reward(self, reward, coupon, **kwargs):
            // """
            // Applies the reward to the order provided the given coupon has enough points.
            // This method does not check for program rules.
            // 
            // This method also assumes the points added by the program triggers have already been computed.
            // The temporary points are used if the program is applicable to the current order.
            // 
            // Returns a dict containing the error message or empty if everything went correctly.
            // NOTE: A call to `_update_programs_and_rewards` is expected to reorder the discounts.
            // """
            // self.ensure_one()
            // # Use the old lines before creating new ones. These should already be in a 'reset' state.
            // old_reward_lines = kwargs.get('old_lines', self.env['sale.order.line'])
            // if reward.is_global_discount:
            //     global_discount_reward_lines = self._get_applied_global_discount_lines()
            //     global_discount_reward = global_discount_reward_lines.reward_id
            //     if (
            //         global_discount_reward
            //         and global_discount_reward != reward
            //         and self._best_global_discount_already_applied(global_discount_reward, reward)
            //     ):
            //         return {'error': _("A better global discount is already applied.")}
            //     elif global_discount_reward and global_discount_reward != reward:
            //         # Invalidate the old global discount as it may impact the new discount to apply
            //         global_discount_reward_lines._reset_loyalty(True)
            //         old_reward_lines |= global_discount_reward_lines
            // if not reward.program_id.is_nominative and reward.program_id.applies_on == 'future' and coupon in self.coupon_point_ids.coupon_id:
            //     return {'error': _("The coupon can only be claimed on future orders.")}
            // elif self._get_real_points_for_coupon(coupon) < reward.required_points:
            //     return {'error': _("The coupon does not have enough points for the selected reward.")}
            // reward_vals = self._get_reward_line_values(reward, coupon, **kwargs)
            // self._write_vals_from_reward_vals(reward_vals, old_reward_lines)
            // return {}
            */
            return default;
        }

        protected async Task<SaleOrder> AutoApplyRewardsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _auto_apply_rewards(self):
            // """
            // Tries to auto apply claimable rewards.
            // 
            // It must answer to the following rules:
            //  - Must not be from a nominative program
            //  - The reward must be the only reward of the program
            //  - The reward may not be a multi product reward
            // 
            // Returns True if any reward was claimed else False
            // """
            // self.ensure_one()
            // 
            // claimed_reward_count = 0
            // claimable_rewards = self._get_claimable_rewards()
            // for coupon, rewards in claimable_rewards.items():
            //     if (
            //         len(coupon.program_id.reward_ids) != 1
            //         or coupon.program_id.is_nominative
            //         or (rewards.reward_type == 'product' and rewards.multi_product)
            //         or rewards in self.disabled_auto_rewards
            //         or rewards in self.order_line.reward_id
            //     ):
            //         continue
            // 
            //     try:
            //         res = self._apply_program_reward(rewards, coupon)
            //         if 'error' not in res:
            //             claimed_reward_count += 1
            //     except UserError:
            //         pass
            // 
            // return bool(claimed_reward_count)
            */
            return default;
        }

        protected async Task<SaleOrder> BestGlobalDiscountAlreadyAppliedInternalAsync(object current_reward, object new_reward, object discountable)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _best_global_discount_already_applied(self, current_reward, new_reward, discountable=None):
            // """Determine whether current_reward is better than new_reward.
            // 
            // This function compares the discount amount of two rewards to determine whether the current
            // one is better than another one.
            // 
            // Notes
            // -----
            // 
            //     If the discount amounts of both the current and the new rewards exceed the order total,
            //     the reward with the smaller discount amount is considered the best.
            //     This is to ensure that the most advantageous discount is applied for the customer,
            //     who will keep the most important voucher, having saved the same amount in the end.
            // 
            // :param loyalty.reward current_reward: The reward currently applied on the sale order.
            // :param loyalty.reward new_reward: The reward to compare with.
            // :param float discountable: The total discountable amount of the sale order.
            //     If not provided, it will be calculated on the fly.
            // :return: True if current_reward is considered better than new_reward.
            // :rtype: bool
            // """
            // self.ensure_one()
            // current_reward.ensure_one()
            // new_reward.ensure_one()
            // 
            // if current_reward == new_reward:
            //     return True
            // 
            // if discountable is None:  # Only recompute if discountable is not given, not if its zero
            //     discountable = self._discountable_amount(current_reward)
            // 
            // discount_current_reward = self._get_discount_amount(current_reward, discountable)
            // discount_new_reward = self._get_discount_amount(new_reward, discountable)
            // 
            // discount_current_bigger_than_discountable = self.currency_id.compare_amounts(
            //     amount1=discount_current_reward,
            //     amount2=discountable,
            // ) >= 0
            // discount_new_bigger_than_discountable = self.currency_id.compare_amounts(
            //     amount1=discount_new_reward,
            //     amount2=discountable,
            // ) >= 0
            // compare_current_and_new_reward = self.currency_id.compare_amounts(
            //     amount1=discount_current_reward,
            //     amount2=discount_new_reward,
            // )
            // 
            // if discount_current_bigger_than_discountable and discount_new_bigger_than_discountable:
            //     # If both discounts are greater than the discountable amount, the lower discount
            //     # is better as it reduces the discount amount 'spent' by the customer.
            //     return compare_current_and_new_reward <= 0
            // 
            // # Return True only if the discount of the new reward is greater than the current reward
            // # discount.
            // return compare_current_and_new_reward >= 0
            */
            return default;
        }

        protected async Task<SaleOrder> CanBeEditedOnPortalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _can_be_edited_on_portal(self):
            // self.ensure_one()
            // return self.state in ('draft', 'sent')
            */
            return default;
        }

        public async Task<SaleOrder> CancelAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_cancel(self):
            // """ Cancel sales order and related draft invoices. """
            // if any(order.locked for order in self):
            //     raise UserError(_("You cannot cancel a locked order. Please unlock it first."))
            // return self._action_cancel()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> CartAccessoriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_accessories(self):
            // """ Suggest accessories based on 'Accessory Products' of products in cart """
            // product_ids = set(self.website_order_line.product_id.ids)
            // all_accessory_products = self.env['product.product']
            // for line in self.website_order_line.filtered('product_id'):
            //     accessory_products = line.product_id.product_tmpl_id._get_website_accessory_product()
            //     if accessory_products:
            //         # Do not read ptavs if there is no accessory products to filter
            //         combination = line.product_id.product_template_attribute_value_ids + line.product_no_variant_attribute_value_ids
            //         all_accessory_products |= accessory_products.filtered(lambda product:
            //             product.id not in product_ids
            //             and product._website_show_quick_add()
            //             and product.filtered_domain(self.env['product.product']._check_company_domain(line.company_id))
            //             and product._is_variant_possible(parent_combination=combination)
            //             and (
            //                 not self.website_id.prevent_zero_price_sale
            //                 or product._get_contextual_price()
            //             )
            //         )
            // 
            // return random.sample(all_accessory_products, len(all_accessory_products))
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> CartAddInternalAsync(Guid product_id, float quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_add(self, product_id: int, quantity: float = 1.0, *, uom_id: int | None = None, **kwargs) -> dict:
            // """Add quantity of the given product to the current sales order.
            // 
            // :param product_id: product id, as a `product.product` id.
            // :param quantity: the quantity to add to the cart.
            // :param kwargs: Additional parameters given to deeper method calls.
            // :return: values used by the cart service to give feedback to the customer.
            // """
            // self.ensure_one()
            // self = self.with_company(self.company_id)
            // 
            // if not uom_id:
            //     uom_id = self.env['product.product'].browse(product_id).uom_id.id  # type: ignore
            // if existing_sol := self._cart_find_product_line(product_id, uom_id=uom_id, **kwargs)[:1]:
            //     # If a matching line is found, update the existing line instead.
            //     return self._cart_update_line_quantity(
            //         line_id=existing_sol.id,  # type: ignore
            //         quantity=existing_sol.product_uom_qty + quantity,
            //         **kwargs,
            //     )
            // 
            // quantity, warning = self._verify_updated_quantity(
            //     self.env['sale.order.line'],
            //     product_id,
            //     quantity,
            //     uom_id=uom_id,
            //     **kwargs,
            // )
            // 
            // order_line = self._create_new_cart_line(product_id, quantity, uom_id, **kwargs)
            // 
            // # NOTE: the provided product_id should not be given after `_create_new_cart_line` call as it
            // # could be different from the line's product_id (see variant generation logic in
            // # `_prepare_order_line_values`).
            // 
            // if warning:
            //     (order_line or self).shop_warning = warning
            // 
            // if not self.env.context.get('skip_cart_verification'):
            //     self._verify_cart_after_update()
            // 
            // return {
            //     'added_qty': quantity,
            //     'line_id': order_line.id,
            //     'quantity': quantity,
            //     'warning': warning,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> CartFindProductLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py) ---
            // def _cart_find_product_line(self, *args, event_booth_pending_ids=None, **kwargs):
            // """Check if there is another sale order line which already contains the requested event_booth_pending_ids
            // to overwrite it with the newly requested booths to avoid having multiple so_line related to the same booths"""
            // lines = super()._cart_find_product_line(
            //     *args, event_booth_pending_ids=event_booth_pending_ids, **kwargs,
            // )
            // 
            // if not event_booth_pending_ids:
            //     return lines
            // 
            // return lines.filtered(
            //     lambda line: any(booth.id in event_booth_pending_ids for booth in line.event_booth_pending_ids)
            // )
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py) ---
            // def _cart_find_product_line(self, *args, event_slot_id=False, event_ticket_id=False, **kwargs):
            // lines = super()._cart_find_product_line(
            //     *args, event_slot_id=event_slot_id, event_ticket_id=event_ticket_id, **kwargs,
            // )
            // if not event_slot_id and not event_ticket_id:
            //     return lines
            // 
            // return lines.filtered(lambda line: line.event_slot_id.id == event_slot_id and line.event_ticket_id.id == event_ticket_id)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_find_product_line(
            //     self, product_id, uom_id, linked_line_id=False, no_variant_attribute_value_ids=None, **kwargs
            // ):
            //     """Find the cart line matching the given parameters.
            // 
            //     Custom attributes won't be matched (but no_variant & dynamic ones will be)
            // 
            //     :param int product_id: the product being added/removed, as a `product.product` id
            //     :param int linked_line_id: optional, the parent line (for optional products), as a
            //         `sale.order.line` id
            //     :param list optional_product_ids: optional, the optional products of the line, as a list
            //         of `product.product` ids
            //     :param list no_variant_attribute_value_ids: list of `product.template.attribute.value` ids
            //         whose attribute is configured as `no_variant`
            //     :param dict kwargs: unused parameters, maybe used in overrides or other cart update methods
            //     :return: matching order lines in the cart, if any
            //     :rtype: `sale.order.line` recordset
            //     """
            //     self.ensure_one()
            // 
            //     if not self.order_line:
            //         return self.env['sale.order.line']
            // 
            //     product = self.env['product.product'].browse(product_id)
            //     if product.type == 'combo':
            //         return self.env['sale.order.line']
            // 
            //     domain = [
            //         ('product_id', '=', product_id),
            //         ('product_uom_id', '=', uom_id),
            //         ('product_custom_attribute_value_ids', '=', False),
            //         ('linked_line_id', '=', linked_line_id),
            //         ('combo_item_id', '=', False),
            //     ]
            // 
            //     filtered_sol = self.order_line.filtered_domain(domain)
            //     if not filtered_sol:
            //         return self.env['sale.order.line']
            // 
            //     has_configurable_no_variant_attributes = any(
            //         len(line.value_ids) > 1 or line.attribute_id.display_type == 'multi'
            //         for line in product.attribute_line_ids
            //         if line.attribute_id.create_variant == 'no_variant'
            //     )
            //     if has_configurable_no_variant_attributes:
            //         filtered_sol = filtered_sol.filtered(
            //             lambda sol:
            //                 sol.product_no_variant_attribute_value_ids.ids == no_variant_attribute_value_ids
            //         )
            // 
            //     return filtered_sol
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _cart_find_product_line(self, *args, **kwargs):
            // # Filter out reward lines, they shouldn't be modified by standard _cart_add logic.
            // # This kind of lines is handled by _update_programs_and_rewards and _auto_apply_rewards.
            // return super()._cart_find_product_line(*args, **kwargs).filtered(
            //     lambda sol: not sol.is_reward_line
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> CartRecoveryEmailSendInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_recovery_email_send(self):
            // """Send the cart recovery email on the current recordset,
            // making sure that the portal token exists to avoid broken links, and marking the email as sent.
            // Similar method to action_recovery_email_send, made to be called in automation rules.
            // Contrary to the former, it will use the website-specific template for each order."""
            // sent_orders = self.env['sale.order']
            // for order in self:
            //     template = order._get_cart_recovery_template()
            //     if template:
            //         order._portal_ensure_token()
            //         template.send_mail(order.id)
            //         sent_orders |= order
            // sent_orders.write({'cart_recovery_email_sent': True})
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> CartUpdateLineQuantityInternalAsync(Guid line_id, float quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_update_line_quantity(self, line_id: int, quantity: float, **kwargs) -> dict:
            // """Update the quantity of a given line of the cart.
            // 
            // :param line_id: line id, as a `sale.order.line` id.
            // :param quantity: the updated quantity of the line.
            // :param kwargs: Additional parameters given to deeper method calls.
            // :return: values used by the cart service to give feedback to the customer.
            // """
            // if self:
            //     self.ensure_one()
            // 
            // self = self.with_company(self.company_id)  # noqa: PLW0642
            // 
            // if not (order_line := self.order_line.filtered(lambda sol: sol.id == line_id)):
            //     # If the line isn't found because of wrong parameters, or because the user updated
            //     # the cart in other tabs, a warning will be returned.
            //     # Note that if the cart is empty, the zero cart_quantity will trigger a page reload
            //     # and this warning won't be shown.
            //     return {
            //         'warning': _(
            //             "We weren't able to update your cart. Please refresh your page before trying"
            //             " again."
            //         )
            //     }
            // 
            // if quantity > 0:
            //     quantity, warning = self._verify_updated_quantity(
            //         order_line,
            //         order_line.product_id.id,
            //         quantity,
            //         uom_id=order_line.product_uom_id.id,
            //         **kwargs,
            //     )
            // else:
            //     # If the line will be removed anyway, there is no need to verify
            //     # the requested quantity update.
            //     warning = ''
            // 
            // added_qty = quantity - order_line.product_uom_qty  # new_qty - old_qty
            // order_line = self._cart_update_order_line(order_line, quantity, **kwargs)
            // if not self.env.context.get('skip_cart_verification'):
            //     self._verify_cart_after_update()
            // 
            // if warning:
            //     (order_line or self).shop_warning = warning
            // 
            // return {
            //     'added_qty': added_qty,
            //     'line_id': order_line.id,
            //     'quantity': quantity,
            //     'warning': warning,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> CartUpdateOrderLineInternalAsync(object order_line, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py) ---
            // def _cart_update_order_line(self, order_line, quantity, **kwargs):
            // old_qty = order_line.product_uom_qty
            // 
            // updated_line = super()._cart_update_order_line(order_line, quantity, **kwargs)
            // 
            // # Remove event registrations on quantity decrease.
            // if (
            //     updated_line
            //     and updated_line.event_ticket_id
            //     and (diff := old_qty - updated_line.product_uom_qty) > 0
            // ):
            //     attendees = self.env['event.registration'].search(
            //         domain=[
            //             ('state', '!=', 'cancel'),
            //             ('sale_order_id', '=', self.id),
            //             ('event_slot_id', '=', order_line.event_slot_id.id),
            //             ('event_ticket_id', '=', order_line.event_ticket_id.id),
            //         ],
            //         offset=updated_line.product_uom_qty,
            //         limit=diff,
            //         order='create_date asc',
            //     )
            //     attendees.action_cancel()
            // 
            // return updated_line
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _cart_update_order_line(self, order_line, quantity, **kwargs):
            // self.ensure_one()
            // order_line.ensure_one()
            // 
            // if quantity <= 0:
            //     # Remove zero or negative lines
            //     order_line.unlink()
            //     return self.env['sale.order.line']
            // 
            // # Update existing line
            // update_values = self._prepare_order_line_update_values(order_line, quantity, **kwargs)
            // if update_values:
            //     combo_item_lines = order_line.linked_line_ids.filtered('combo_item_id')
            //     if (
            //         order_line.product_type == 'combo'
            //         and combo_item_lines
            //         and 'product_uom_qty' in update_values
            //     ):
            //         # A combo product and its items should have the same quantity (by design). If the
            //         # requested quantity isn't available for one or more combo items, we should lower
            //         # the quantity of the combo product and its items to the maximum available quantity
            //         # of the combo item with the least available quantity.
            //         combo_quantity = quantity
            //         for item_line in combo_item_lines:
            //             if quantity != item_line.product_uom_qty:
            //                 combo_item_quantity, _warning = self._verify_updated_quantity(
            //                     item_line,
            //                     item_line.product_id.id,
            //                     quantity,
            //                     uom_id=item_line.product_uom_id.id,
            //                     **kwargs
            //                 )
            //                 combo_quantity = min(combo_quantity, combo_item_quantity)
            //         for item_line in combo_item_lines:
            //             if combo_quantity != item_line.product_uom_qty:
            //                 self.with_context(skip_cart_verification=True)._cart_update_line_quantity(
            //                     line_id=item_line.id, quantity=combo_quantity
            //                 )
            //         update_values['product_uom_qty'] = combo_quantity
            // 
            //     order_line.write(update_values)
            // 
            //     order_line._check_validity()
            // 
            // return order_line
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _cart_update_order_line(self, order_line, quantity, **kwargs):
            // if (
            //     quantity <= 0
            //     and order_line.coupon_id
            //     and order_line.reward_id
            //     and order_line.reward_id.reward_type == 'discount'
            // ):
            //     # When a reward line is deleted we remove it from the auto claimable rewards
            //     order_line = order_line.with_context(website_sale_loyalty_delete=True)
            // 
            // return super()._cart_update_order_line(order_line, quantity, **kwargs)
            */
            return default;
        }

        protected async Task<SaleOrder> CheapestLineInternalAsync(object reward)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _cheapest_line(self, reward):
            // self.ensure_one()
            // cheapest_line = False
            // cheapest_line_price_unit = False
            // domain = reward._get_discount_product_domain()
            // for line in (self.order_line - self._get_no_effect_on_threshold_lines()):
            //     line_price_unit = self._get_order_line_price(line, 'price_unit')
            //     if (
            //         line.reward_id
            //         or line.combo_item_id
            //         or not line.product_uom_qty
            //         or not line_price_unit
            //         or not line.product_id.filtered_domain(domain)
            //     ):
            //         continue
            //     if not cheapest_line or cheapest_line_price_unit > line_price_unit:
            //         cheapest_line = line._get_lines_with_price()
            //         cheapest_line_price_unit = line_price_unit
            // return cheapest_line
            */
            return default;
        }

        protected async Task<SaleOrder> CheckCartIsReadyToBePaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _check_cart_is_ready_to_be_paid(self):
            // """ Whether the cart is valid and the user can proceed to the payment
            // 
            // :rtype: bool
            // """
            // if not self._is_cart_ready():
            //     raise ValidationError(_(
            //         "Your cart is not ready to be paid, please verify previous steps."
            //     ))
            // 
            // if not self.only_services and not self.carrier_id:
            //     raise ValidationError(_("No shipping method is selected."))
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _check_cart_is_ready_to_be_paid(self):
            // """ Override of `website_sale` to check if all products are in stock in the selected
            // warehouse. """
            // if (
            //     self._has_deliverable_products()
            //     and self.carrier_id.delivery_type == 'in_store'
            //     and not self._is_in_stock(self.warehouse_id.id)
            // ):
            //     raise ValidationError(self.env._(
            //         "Some products are not available in the selected store."
            //     ))
            // return super()._check_cart_is_ready_to_be_paid()
            --- ODOO METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: sale_order.py) ---
            // def _check_cart_is_ready_to_be_paid(self):
            // if (
            //     self.partner_shipping_id.is_mondialrelay and self.delivery_set
            //     and self.carrier_id and not self.carrier_id.is_mondialrelay
            // ):
            //     raise ValidationError(_(
            //         "Point Relais® can only be used with the delivery method Mondial Relay."
            //     ))
            // elif not self.partner_shipping_id.is_mondialrelay and self.carrier_id.is_mondialrelay:
            //     raise ValidationError(_(
            //         "Delivery method Mondial Relay can only ship to Point Relais®."
            //     ))
            // return super()._check_cart_is_ready_to_be_paid()
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _check_cart_is_ready_to_be_paid(self):
            // values = [
            //     line.shop_warning
            //     for line in self.order_line
            //     if not line._check_availability()
            // ]
            // if values:
            //     raise ValidationError(' '.join(values))
            // return super()._check_cart_is_ready_to_be_paid()
            */
            return default;
        }

        protected async Task<bool> CheckComboQuantitiesInternalAsync(object line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _check_combo_quantities(self, line) -> bool:
            // """Ensure all combo item lines have the same quantity.
            // 
            // :returns: whether the combo quantities had to be updated
            // """
            // # Ensure all combo lines have the same quantity
            // if not (combo_lines := line.linked_line_ids):
            //     return False
            // available_combo_quantity = min(line.product_uom_qty for line in combo_lines)
            // if available_combo_quantity < line.product_uom_qty:
            //     line._set_shop_warning_stock(
            //         line.product_uom_qty,
            //         available_combo_quantity,
            //     )
            //     (line + combo_lines).product_uom_qty = available_combo_quantity
            //     return True
            // 
            // return False
            */
            return default;
        }

        protected async Task<SaleOrder> CheckOrderLineCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _check_order_line_company_id(self):
            // for order in self:
            //     invalid_companies = order.order_line.product_id.company_id.filtered(
            //         lambda c: order.company_id not in c._accessible_branches()
            //     )
            //     if invalid_companies:
            //         bad_products = order.order_line.product_id.filtered(
            //             lambda p: p.company_id and p.company_id in invalid_companies
            //         )
            //         raise ValidationError(_(
            //             "Your quotation contains products from company %(product_company)s whereas your quotation belongs to company %(quote_company)s. \n Please change the company of your quotation or remove the products from other companies (%(bad_products)s).",
            //             product_company=', '.join(invalid_companies.sudo().mapped('display_name')),
            //             quote_company=order.company_id.display_name,
            //             bad_products=', '.join(bad_products.mapped('display_name')),
            //         ))
            */
            return default;
        }

        protected async Task<SaleOrder> CheckPrepaymentPercentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _check_prepayment_percent(self):
            // for order in self:
            //     if order.require_payment and not (0 < order.prepayment_percent <= 1.0):
            //         raise ValidationError(_("Prepayment percentage must be a valid percentage."))
            */
            return default;
        }

        protected async Task<SaleOrder> CheckWarehouseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _check_warehouse(self):
            // """ Ensure that the warehouse is set in case of storable products """
            // orders_without_wh = self.filtered(lambda order: order.state not in ('draft', 'cancel') and not order.warehouse_id)
            // company_ids_with_wh = {
            //     company_id.id for [company_id] in self.env['stock.warehouse']._read_group(
            //         domain=[('company_id', 'in', orders_without_wh.company_id.ids)],
            //         groupby=['company_id'],
            //     )
            // }
            // other_company = set()
            // for order_line in orders_without_wh.order_line:
            //     if order_line.product_id.type != 'consu':
            //         continue
            //     if order_line.route_ids.company_id and order_line.route_ids.company_id != order_line.company_id:
            //         other_company.add(order_line.route_ids.company_id.id)
            //         continue
            //     if order_line.order_id.company_id.id in company_ids_with_wh:
            //         raise UserError(_('You must set a warehouse on your sale order to proceed.'))
            //     self.env['stock.warehouse'].with_company(order_line.order_id.company_id)._warehouse_redirect_warning()
            // other_company_warehouses = self.env['stock.warehouse'].search([('company_id', 'in', list(other_company))])
            // if any(c not in other_company_warehouses.company_id.ids for c in other_company):
            //     raise UserError(_("You must have a warehouse for line using a delivery in different company."))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAbandonedCartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_abandoned_cart(self):
            // for order in self:
            //     # a quotation can be considered as an abandonned cart if it is linked to a website,
            //     # is in the 'draft' state and has an expiration date
            //     if order.website_id and order.state == 'draft' and order.date_order:
            //         public_partner_id = order.website_id.user_id.partner_id
            //         # by default the expiration date is 1 hour if not specified on the website configuration
            //         abandoned_delay = order.website_id.cart_abandoned_delay or 1.0
            //         abandoned_datetime = datetime.utcnow() - relativedelta(hours=abandoned_delay)
            //         order.is_abandoned_cart = bool(order.date_order <= abandoned_datetime and order.partner_id != public_partner_id and order.order_line)
            //     else:
            //         order.is_abandoned_cart = False
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAccessUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for order in self:
            //     order.access_url = f'/my/orders/{order.id}'
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountDeliveryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_amount_delivery(self):
            // self.amount_delivery = 0.0
            // for order in self.filtered('website_id'):
            //     delivery_lines = order.order_line.filtered('is_delivery')
            //     if order.website_id.show_line_subtotals_tax_selection == 'tax_excluded':
            //         order.amount_delivery = sum(delivery_lines.mapped('price_subtotal'))
            //     else:
            //         order.amount_delivery = sum(delivery_lines.mapped('price_total'))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _compute_amount_invoiced(self):
            // super()._compute_amount_invoiced()
            // for order in self:
            //     if order.invoice_status == 'invoiced':
            //         continue
            //     # We need to account for the downpayment paid in POS with and without invoice
            //     order_amount = sum(order.sudo().pos_order_line_ids.filtered(lambda pol: pol.order_id.state in ['paid', 'done', 'invoiced'] and pol.sale_order_line_id.is_downpayment).mapped('price_subtotal_incl'))
            //     order.amount_invoiced += order_amount
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_invoiced(self):
            // for order in self:
            //     order.amount_invoiced = sum(order.order_line.mapped('amount_invoiced'))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountPaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_paid(self):
            // """ Sum of the amount paid through all transactions for this SO. """
            // for order in self:
            //     order.amount_paid = sum(
            //         tx.amount for tx in order.transaction_ids if tx.state in ('authorized', 'done')
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _compute_amount_to_invoice(self):
            // super()._compute_amount_to_invoice()
            // for order in self:
            //     # We need to account for all amount paid in POS with and without invoice
            //     order_amount = sum(order.sudo().pos_order_line_ids.mapped('price_subtotal_incl'))
            //     order.amount_to_invoice -= order_amount
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_to_invoice(self):
            // for order in self:
            //     order.amount_to_invoice = sum(order.order_line.mapped('amount_to_invoice'))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountTotalWithoutDeliveryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _compute_amount_total_without_delivery(self):
            // self.ensure_one()
            // delivery_cost = sum([l.price_total for l in self.order_line if l.is_delivery])
            // return self.amount_total - delivery_cost
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _compute_amount_total_without_delivery(self):
            // res = super()._compute_amount_total_without_delivery()
            // return res - sum(
            //     self.order_line.filtered(
            //         lambda l: l.coupon_id and l.coupon_id.program_type in ['ewallet', 'gift_card']
            //     ).mapped('price_unit')
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountUndiscountedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_undiscounted(self):
            // for order in self:
            //     total = 0.0
            //     for line in order.order_line:
            //         total += (line.price_subtotal * 100)/(100-line.discount) if line.discount != 100 else (line.price_unit * line.product_uom_qty)
            //     order.amount_undiscounted = total
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountUnpaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _compute_amount_unpaid(self):
            // for sale_order in self:
            //     invoices = sale_order.order_line.invoice_lines.move_id.filtered(lambda invoice: invoice.state in ('draft', 'posted'))
            //     total_invoices_paid = sum(invoices.mapped('amount_total'))
            //     pos_orders = sale_order.order_line.pos_order_line_ids.order_id
            //     total_pos_orders_paid = sum(pos_orders.mapped('amount_total'))
            //     sale_order.amount_unpaid = max(sale_order.amount_total - total_invoices_paid - total_pos_orders_paid - sale_order.amount_paid, 0.0)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amounts(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order._get_priced_lines()
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     base_lines += order._add_base_lines_for_early_payment_discount()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            //     order.amount_untaxed = tax_totals['base_amount_currency']
            //     order.amount_tax = tax_totals['tax_amount_currency']
            //     order.amount_total = tax_totals['total_amount_currency']
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAttendeeCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py) ---
            // def _compute_attendee_count(self):
            // sale_orders_data = self.env['event.registration']._read_group(
            //     [('sale_order_id', 'in', self.ids),
            //      ('state', '!=', 'cancel')],
            //     ['sale_order_id'], ['__count'],
            // )
            // attendee_count_data = {
            //     sale_order.id: count for sale_order, count in sale_orders_data
            // }
            // for sale_order in self:
            //     sale_order.attendee_count = attendee_count_data.get(sale_order.id, 0)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAuthorizedTransactionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_authorized_transaction_ids(self):
            // for trans in self:
            //     trans.authorized_transaction_ids = trans.transaction_ids.filtered(lambda t: t.state == 'authorized')
            //     trans.has_authorized_transaction_ids = bool(trans.authorized_transaction_ids)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAvailableQuotationDocumentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py) ---
            // def _compute_available_quotation_document_ids(self):
            // for order in self:
            //     order.available_quotation_document_ids = self.env['quotation.document'].search(
            //         self.env['quotation.document']._check_company_domain(order.company_id),
            //         order='sequence',
            //     ).filtered(lambda doc:
            //         # templates are available only to salesman
            //         not (templates := doc.sudo().quotation_template_ids)
            //         or order.sale_order_template_id in templates
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCartInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_cart_info(self):
            // for order in self:
            //     order.cart_quantity = int(sum(order.mapped('website_order_line.product_uom_qty')))
            //     order.only_services = all(sol.product_id.type == 'service' for sol in order.website_order_line)
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _compute_cart_info(self):
            // super(SaleOrder, self)._compute_cart_info()
            // for order in self:
            //     reward_lines = order.website_order_line.filtered(lambda line: line.is_reward_line)
            //     order.cart_quantity -= int(sum(reward_lines.mapped('product_uom_qty')))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCompletedTaskPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_completed_task_percentage(self):
            // for so in self:
            //     so.completed_task_percentage = so.tasks_count and so.closed_task_count / so.tasks_count
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_id(self):
            // for order in self:
            //     order.currency_id = order.pricelist_id.currency_id or order.company_id.currency_id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(
            //         from_currency=order.company_id.currency_id,
            //         to_currency=order.currency_id,
            //         company=order.company_id,
            //         date=(order.date_order or fields.Datetime.now()).date(),
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDeliveryStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _compute_delivery_state(self):
            // for order in self:
            //     order.delivery_set = any(line.is_delivery for line in order.order_line)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDeliveryStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_delivery_status(self):
            // for order in self:
            //     if not order.picking_ids or all(p.state == 'cancel' for p in order.picking_ids):
            //         order.delivery_status = False
            //     elif all(p.state in ['done', 'cancel'] for p in order.picking_ids):
            //         order.delivery_status = 'full'
            //     elif any(p.state == 'done' for p in order.picking_ids) and any(
            //             l.qty_delivered for l in order.order_line):
            //         order.delivery_status = 'partial'
            //     elif any(p.state == 'done' for p in order.picking_ids):
            //         order.delivery_status = 'started'
            //     else:
            //         order.delivery_status = 'pending'
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('sale_show_partner_name'):
            //     return super()._compute_display_name()
            // for order in self:
            //     name = order.name
            //     if order.partner_id.name:
            //         name = f'{name} - {order.partner_id.name}'
            //     order.display_name = name
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDuplicatedOrderIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_duplicated_order_ids(self):
            // draft_orders = self.filtered(lambda o: o.state == 'draft')
            // order_to_duplicate_orders = draft_orders._fetch_duplicate_orders()
            // for order in draft_orders:
            //     order.duplicated_order_ids = [Command.set(order_to_duplicate_orders.get(order.id, []))]
            // (self - draft_orders).duplicated_order_ids = False
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_effective_date(self):
            // for order in self:
            //     pickings = order.picking_ids.filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'customer')
            //     dates_list = [date for date in pickings.mapped('date_done') if date]
            //     order.effective_date = min(dates_list, default=False)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeEventBoothCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py) ---
            // def _compute_event_booth_count(self):
            // slot_data = self.env['event.booth']._read_group(
            //     [('sale_order_id', 'in', self.ids)],
            //     ['sale_order_id'], ['__count'],
            // )
            // slot_mapped = {sale_order.id: count for sale_order, count in slot_data}
            // for so in self:
            //     so.event_booth_count = slot_mapped.get(so.id, 0)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeExpectedDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_expected_date(self):
            // """ For service and combo (non-goods) products, we avoid computing the expected date. This method is extended in sale_stock to
            //     take the picking_policy of SO into account.
            // """
            // self.mapped("order_line")  # Prefetch indication
            // for order in self:
            //     if order.state == 'cancel':
            //         order.expected_date = False
            //         continue
            //     dates_list = order.order_line.filtered(
            //         lambda line: line.product_id.type == 'consu' and not line.display_type and not line._is_delivery()
            //     ).mapped(lambda line: line and line._expected_date())
            //     if dates_list:
            //         order.expected_date = order._select_expected_date(dates_list)
            //     else:
            //         order.expected_date = False
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_expected_date(self):
            // super(SaleOrder, self)._compute_expected_date()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeExpenseCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: sale_order.py) ---
            // def _compute_expense_count(self):
            // for sale_order in self:
            //     sale_order.expense_count = len(sale_order.order_line.expense_ids)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_field_value(self, field):
            // if field.name != 'invoice_status' or self.env.context.get('mail_activity_automation_skip'):
            //     return super()._compute_field_value(field)
            // 
            // filtered_self = self.filtered(
            //     lambda so: so.ids
            //         and (so.user_id or so.partner_id.user_id)
            //         and so._origin.invoice_status != 'upselling')
            // super()._compute_field_value(field)
            // 
            // upselling_orders = filtered_self.filtered(lambda so: so.invoice_status == 'upselling')
            // upselling_orders._create_upsell_activity()
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _compute_field_value(self, field):
            // if field.name != 'invoice_status' or self.env.context.get('mail_activity_automation_skip'):
            //     return super()._compute_field_value(field)
            // 
            // # Get SOs which their state is not equal to upselling and if at least a SOL has warning prepaid service upsell set to True and the warning has not already been displayed
            // upsellable_orders = self.filtered(lambda so:
            //     so.state == 'sale'
            //     and so.invoice_status != 'upselling'
            //     and so.id
            //     and (so.user_id or so.partner_id.user_id)  # salesperson needed to assign upsell activity
            // )
            // super(SaleOrder, upsellable_orders.with_context(mail_activity_automation_skip=True))._compute_field_value(field)
            // for order in upsellable_orders:
            //     upsellable_lines = order._get_prepaid_service_lines_to_upsell()
            //     if upsellable_lines:
            //         order._create_upsell_activity()
            //         # We want to display only one time the warning for each SOL
            //         upsellable_lines.write({'has_displayed_warning_upsell': True})
            // super(SaleOrder, self - upsellable_orders)._compute_field_value(field)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_fiscal_position_id(self):
            // """
            // Trigger the change of fiscal position when the shipping address is modified.
            // """
            // cache = {}
            // for order in self:
            //     if not order.partner_id:
            //         order.fiscal_position_id = False
            //         continue
            //     fpos_id_before = order.fiscal_position_id.id
            //     key = (order.company_id.id, order.partner_id.id, order.partner_shipping_id.id)
            //     if key not in cache:
            //         cache[key] = self.env['account.fiscal.position'].with_company(
            //             order.company_id
            //         )._get_fiscal_position(order.partner_id, order.partner_shipping_id).id
            //     if fpos_id_before != cache[key] and order.order_line:
            //         order.show_update_fpos = True
            //     order.fiscal_position_id = cache[key]
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _compute_fiscal_position_id(self):
            // """Override of `sale` to set the fiscal position matching the selected pickup location
            // for pickup in-store orders."""
            // in_store_orders = self.filtered(
            //     lambda so: so.carrier_id.delivery_type == 'in_store' and so.pickup_location_data
            // )
            // AccountFiscalPosition = self.env['account.fiscal.position'].sudo()
            // for order in in_store_orders:
            //     order.fiscal_position_id = AccountFiscalPosition._get_fiscal_position(
            //         order.partner_id, delivery=order.warehouse_id.partner_id
            //     )
            // super(SaleOrder, self - in_store_orders)._compute_fiscal_position_id()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeGiftCardCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _compute_gift_card_count(self):
            // gift_card_data = dict(
            //     self.env['loyalty.card']._read_group(
            //         domain=[
            //             ('order_id', 'in', self.ids),
            //             ('program_type', '=', 'gift_card'),
            //         ],
            //         groupby=['order_id'],
            //         aggregates=['__count'],
            //     )
            // )
            // for order in self:
            //     order.gift_card_count = gift_card_data.get(order, 0)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeHasActivePricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_has_active_pricelist(self):
            // for order in self:
            //     order.has_active_pricelist = bool(self.env['product.pricelist'].search(
            //         [('company_id', 'in', (False, order.company_id.id)), ('active', '=', True)],
            //         limit=1,
            //     ))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeHasArchivedProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_has_archived_products(self):
            // for order in self:
            //     order.has_archived_products = any(
            //         not product.active for product in order.order_line.product_id
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeInvoiceStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_invoice_status(self):
            // """
            // Compute the invoice status of a SO. Possible statuses:
            // - no: if the SO is not in status 'sale' or 'done', we consider that there is nothing to
            //   invoice. This is also the default value if the conditions of no other status is met.
            // - to invoice: if any SO line is 'to invoice', the whole SO is 'to invoice'
            // - invoiced: if all SO lines are invoiced, the SO is invoiced.
            // - upselling: if all SO lines are invoiced or upselling, the status is upselling.
            // """
            // confirmed_orders = self.filtered(lambda so: so.state == 'sale')
            // (self - confirmed_orders).invoice_status = 'no'
            // if not confirmed_orders:
            //     return
            // lines_domain = [('is_downpayment', '=', False), ('display_type', '=', False)]
            // line_invoice_status_all = [
            //     (order.id, invoice_status)
            //     for order, invoice_status in self.env['sale.order.line']._read_group(
            //         lines_domain + [('order_id', 'in', confirmed_orders.ids)],
            //         ['order_id', 'invoice_status']
            //     )
            // ]
            // for order in confirmed_orders:
            //     line_invoice_status = [d[1] for d in line_invoice_status_all if d[0] == order.id]
            //     if order.state != 'sale':
            //         order.invoice_status = 'no'
            //     elif any(invoice_status == 'to invoice' for invoice_status in line_invoice_status):
            //         if any(invoice_status == 'no' for invoice_status in line_invoice_status):
            //             # If only discount/delivery/promotion lines can be invoiced, the SO should not
            //             # be invoiceable.
            //             invoiceable_domain = lines_domain + [('invoice_status', '=', 'to invoice')]
            //             invoiceable_lines = order.order_line.filtered_domain(invoiceable_domain)
            //             special_lines = invoiceable_lines.filtered(
            //                 lambda sol: not sol._can_be_invoiced_alone()
            //             )
            //             if invoiceable_lines == special_lines:
            //                 order.invoice_status = 'no'
            //             else:
            //                 order.invoice_status = 'to invoice'
            //         else:
            //             order.invoice_status = 'to invoice'
            //     elif line_invoice_status and all(invoice_status == 'invoiced' for invoice_status in line_invoice_status):
            //         order.invoice_status = 'invoiced'
            //     elif line_invoice_status and all(invoice_status in ('invoiced', 'upselling') for invoice_status in line_invoice_status):
            //         order.invoice_status = 'upselling'
            //     else:
            //         order.invoice_status = 'no'
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsExpiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_is_expired(self):
            // today = fields.Date.today()
            // for order in self:
            //     order.is_expired = (
            //         order.state in ('draft', 'sent')
            //         and order.validity_date
            //         and order.validity_date < today
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsPdfQuoteBuilderAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py) ---
            // def _compute_is_pdf_quote_builder_available(self):
            // for order in self:
            //     order.is_pdf_quote_builder_available = bool(
            //         order.available_quotation_document_ids
            //         or order.order_line.available_product_document_ids
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsProductMilestoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_is_product_milestone(self):
            // for order in self:
            //     order.is_product_milestone = order.order_line.product_id.filtered(lambda p: p.service_policy == 'delivered_milestones')
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsServiceProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _compute_is_service_products(self):
            // for so in self:
            //     so.is_all_service = all(line.product_id.type == 'service' for line in so.order_line.filtered(lambda x: not x.display_type))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_journal_id(self):
            // self.journal_id = False
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_journal_id(self):
            // super()._compute_journal_id()
            // for order in self.filtered('sale_order_template_id'):
            //     order.journal_id = order.sale_order_template_id.journal_id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_json_popover(self):
            // for order in self:
            //     late_stock_picking = order.picking_ids.filtered(lambda p: p.delay_alert_date)
            //     order.json_popover = json.dumps({
            //         'popoverTemplate': 'sale_stock.DelayAlertWidget',
            //         'late_elements': [{
            //                 'id': late_move.id,
            //                 'name': late_move.display_name,
            //                 'model': 'stock.picking',
            //             } for late_move in late_stock_picking
            //         ]
            //     })
            //     order.show_json_popover = bool(late_stock_picking)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeLateAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_late_availability(self):
            // for order in self:
            //     order.late_availability = any(
            //         picking.products_availability_state == 'late' for picking in order.picking_ids
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeLoyaltyDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _compute_loyalty_data(self):
            // self.loyalty_data = {}
            // 
            // confirmed_so = self.filtered(lambda order: order.state == 'sale' and bool(order.id))
            // if not confirmed_so:
            //     return
            // 
            // loyalty_history_data = self.env['loyalty.history'].sudo()._read_group(
            //     domain=[
            //         ('order_id', 'in', confirmed_so.ids),
            //         ('order_model', '=', self._name),
            //     ],
            //     groupby=['order_id'],
            //     aggregates=['issued:sum', 'used:sum'],
            // )
            // loyalty_history_data_per_order = {
            //     order_id: {
            //         'total_issued': issued,
            //         'total_cost': cost,
            //     }
            //     for order_id, issued, cost in loyalty_history_data
            // }
            // for order in confirmed_so:
            //     if order.id not in loyalty_history_data_per_order:
            //         continue
            //     coupons = order.coupon_point_ids.coupon_id
            //     coupon_point_name = (len(coupons) == 1 and coupons.point_name) or _("Points")
            //     order.loyalty_data = {
            //         'point_name': coupon_point_name,
            //         'issued': loyalty_history_data_per_order[order.id]['total_issued'],
            //         'cost': loyalty_history_data_per_order[order.id]['total_cost'],
            //     }
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMarginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_margin, FILE: sale_order.py) ---
            // def _compute_margin(self):
            // if not all(self._ids):
            //     for order in self:
            //         order.margin = sum(order.order_line.mapped('margin'))
            //         order.margin_percent = order.amount_untaxed and order.margin/order.amount_untaxed
            // else:
            //     # On batch records recomputation (e.g. at install), compute the margins
            //     # with a single read_group query for better performance.
            //     # This isn't done in an onchange environment because (part of) the data
            //     # may not be stored in database (new records or unsaved modifications).
            //     grouped_order_lines_data = self.env['sale.order.line']._read_group(
            //         [
            //             ('order_id', 'in', self.ids),
            //         ], ['order_id'], ['margin:sum'])
            //     mapped_data = {order.id: margin for order, margin in grouped_order_lines_data}
            //     for order in self:
            //         order.margin = mapped_data.get(order.id, 0.0)
            //         order.margin_percent = order.amount_untaxed and order.margin/order.amount_untaxed
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMilestoneCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_milestone_count(self):
            // read_group = self.env['project.milestone']._read_group(
            //     [('sale_line_id', 'in', self.order_line.ids)],
            //     ['sale_line_id'],
            //     ['__count'],
            // )
            // line_data = {sale_line.id: count for sale_line, count in read_group}
            // for order in self:
            //     order.milestone_count = sum(line_data.get(line.id, 0) for line in order.order_line)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMrpProductionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order.py) ---
            // def _compute_mrp_production_ids(self):
            // for sale in self:
            //     # We want only manufacturing orders of first level
            //     mos = sale.stock_reference_ids.production_ids
            //     sale.mrp_production_ids = mos.filtered(lambda mo: not mo.production_group_id.parent_ids and mo.state != 'cancel')
            //     sale.mrp_production_count = len(sale.mrp_production_ids)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeNoteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_note(self):
            // use_invoice_terms = self.env['ir.config_parameter'].sudo().get_param('account.use_invoice_terms')
            // if not use_invoice_terms:
            //     return
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     if order.terms_type == 'html' and self.env.company.invoice_terms_html:
            //         baseurl = html_keep_url(order._get_note_url() + '/terms')
            //         context = {'lang': order.partner_id.lang or self.env.user.lang}
            //         order.note = _('Terms & Conditions: %s', baseurl)
            //         del context
            //     elif not is_html_empty(self.env.company.invoice_terms):
            //         if order.partner_id.lang:
            //             order = order.with_context(lang=order.partner_id.lang)
            //         order.note = order.env.company.invoice_terms
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_note(self):
            // super()._compute_note()
            // for order in self.filtered('sale_order_template_id'):
            //     template = order.sale_order_template_id.with_context(lang=order.partner_id.lang)
            //     order.note = template.note if not is_html_empty(template.note) else order.note
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerCreditWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_credit_warning(self):
            // for order in self:
            //     order.with_company(order.company_id)
            //     order.partner_credit_warning = ''
            //     show_warning = order.state in ('draft', 'sent') and \
            //                    order.company_id.account_use_credit_limit
            //     if show_warning:
            //         order.partner_credit_warning = self.env['account.move']._build_credit_warning_message(
            //             order.sudo(),  # ensure access to `credit` & `credit_limit` fields
            //             current_amount=(order.amount_total / order.currency_rate),
            //         )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerInvoiceIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_invoice_id(self):
            // for order in self:
            //     order.partner_invoice_id = order.partner_id.address_get(['invoice'])['invoice'] if order.partner_id else False
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerShippingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _compute_partner_shipping_id(self):
            // """ Override to reset the delivery address when a pickup location was selected. """
            // super()._compute_partner_shipping_id()
            // for order in self:
            //     if order.partner_shipping_id.is_pickup_location:
            //         order.partner_shipping_id = order.partner_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_shipping_id(self):
            // for order in self:
            //     order.partner_shipping_id = order.partner_id.address_get(['delivery'])['delivery'] if order.partner_id else False
            --- ODOO METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: sale_order.py) ---
            // def _compute_partner_shipping_id(self):
            // super()._compute_partner_shipping_id()
            // ecommerce_orders = self.filtered('website_id')
            // for order in ecommerce_orders:
            //     if order.partner_shipping_id.is_mondialrelay and not order.carrier_id.is_mondialrelay:
            //         order.partner_shipping_id = order.partner_id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnershipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: sale_order.py) ---
            // def _compute_partnership(self):
            // for so in self:
            //     partnership_lines = so.order_line.filtered(lambda l: l.service_tracking == 'partnership')
            //     so.assigned_grade_id = partnership_lines.mapped('product_id.grade_id')[:1]
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePaymentTermIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_payment_term_id(self):
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     order.payment_term_id = order.partner_id.property_payment_term_id
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_payment_term_id(self):
            // super()._compute_payment_term_id()
            // website_orders = self.filtered(
            //     lambda so: so.website_id and not so.payment_term_id
            // )
            // if not website_orders:
            //     return
            // 
            // # Try to find a payment term even if there wasn't any set on the partner
            // default_pt = self.env.ref(
            //     'account.account_payment_term_immediate', raise_if_not_found=False)
            // for order in website_orders:
            //     if default_pt and (
            //         order.company_id == default_pt.company_id
            //         or not default_pt.company_id
            //     ):
            //         order.payment_term_id = default_pt
            //     else:
            //         order.payment_term_id = order.env['account.payment.term'].search([
            //             ('company_id', '=', order.company_id.id),
            //         ], limit=1)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePickingIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_picking_ids(self):
            // for order in self:
            //     order.delivery_count = len(order.picking_ids)
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py) ---
            // def _compute_picking_ids(self):
            // super()._compute_picking_ids()
            // for order in self:
            //     dropship_count = len(order.picking_ids.filtered(lambda p: p.is_dropship))
            //     order.delivery_count -= dropship_count
            //     order.dropship_picking_count = dropship_count
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePreferredPaymentMethodLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_preferred_payment_method_line_id(self):
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     order.preferred_payment_method_line_id = order.partner_id.property_inbound_payment_method_line_id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePrepaymentPercentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_prepayment_percent(self):
            // for order in self:
            //     order.prepayment_percent = order.company_id.prepayment_percent
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_prepayment_percent(self):
            // super()._compute_prepayment_percent()
            // for order in self.filtered('sale_order_template_id'):
            //     if order.require_payment:
            //         order.prepayment_percent = order.sale_order_template_id.prepayment_percent
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePricelistIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_pricelist_id(self):
            // for order in self:
            //     if order.state != 'draft':
            //         continue
            //     if not order.partner_id:
            //         order.pricelist_id = False
            //         continue
            //     order = order.with_company(order.company_id)
            //     order.pricelist_id = order.partner_id.property_product_pricelist
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_pricelist_id(self):
            // # Override to compute pricelists for carts using the partner's GeoIP,
            // # providing a fallback in case they don't have an address set.
            // if not (country_code := self.env['website']._get_geoip_country_code()):
            //     return super()._compute_pricelist_id()
            // if website_orders := self.filtered('website_id'):
            //     website_orders = website_orders.with_context(country_code=country_code)
            //     super(SaleOrder, website_orders)._compute_pricelist_id()
            // return super(SaleOrder, self - website_orders)._compute_pricelist_id()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeProjectIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_project_ids(self):
            // projects = self.env['project.project'].search(['|', ('sale_order_id', 'in', self.ids), ('reinvoiced_sale_order_id', 'in', self.ids)])
            // projects_per_so = defaultdict(lambda: self.env['project.project'])
            // for project in projects:
            //     projects_per_so[project.sale_order_id.id or project.reinvoiced_sale_order_id.id] |= project
            // for order in self:
            //     projects = order.order_line.mapped('product_id.project_id')
            //     projects |= order.project_id
            //     projects |= order.order_line.mapped('project_id')
            //     projects |= projects_per_so[order.id or order._origin.id]
            //     projects = projects._filtered_access('read')
            //     order.project_ids = projects
            //     order.project_count = len(projects.filtered('active'))
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def _compute_purchase_order_count(self):
            // for order in self:
            //     order.purchase_order_count = len(order._get_purchase_orders())
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: sale_order.py) ---
            // def _compute_purchase_order_count(self):
            // super()._compute_purchase_order_count()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRepairCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: sale_order.py) ---
            // def _compute_repair_count(self):
            // for order in self:
            //     order.repair_count = len(order.repair_order_ids)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRequirePaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_payment(self):
            // for order in self:
            //     order.require_payment = order.company_id.portal_confirmation_pay
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_require_payment(self):
            // super()._compute_require_payment()
            // for order in self.filtered('sale_order_template_id'):
            //     order.require_payment = order.sale_order_template_id.require_payment
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRequireSignatureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // for order in self:
            //     order.require_signature = order.company_id.portal_confirmation_sign
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // super()._compute_require_signature()
            // for order in self.filtered('sale_order_template_id'):
            //     order.require_signature = order.sale_order_template_id.require_signature
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // website_orders = self.filtered('website_id')
            // website_orders.require_signature = False
            // super(SaleOrder, self - website_orders)._compute_require_signature()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRewardTotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _compute_reward_total(self):
            // for order in self:
            //     reward_amount = 0
            //     for line in order.order_line:
            //         if not line.reward_id:
            //             continue
            //         if line.reward_id.reward_type != 'product':
            //             reward_amount += line.price_subtotal
            //         else:
            //             # Free product are 'regular' product lines with a price_unit of 0
            //             reward_amount -= line.product_id.lst_price * line.product_uom_qty
            //     order.reward_amount = reward_amount
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeSaleOrderTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_sale_order_template_id(self):
            // for order in self:
            //     company_template = order.company_id.sale_order_template_id
            //     if company_template and order.sale_order_template_id != company_template:
            //         if 'website_id' in self._fields and order.website_id:
            //             # don't apply quotation template for order created via eCommerce
            //             continue
            //         order.sale_order_template_id = order.company_id.sale_order_template_id.id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeSaleWarningTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_sale_warning_text(self):
            // if not self.env.user.has_group('sale.group_warning_sale'):
            //     self.sale_warning_text = ''
            //     return
            // for order in self:
            //     warnings = OrderedSet()
            //     if partner_msg := order.partner_id.sale_warn_msg:
            //         warnings.add((order.partner_id.name or order.partner_id.display_name) + ' - ' + partner_msg)
            //     for line in order.order_line:
            //         if product_msg := line.sale_line_warn_msg:
            //             warnings.add(line.product_id.display_name + ' - ' + product_msg)
            //     order.sale_warning_text = '\n'.join(warnings)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShippingWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _compute_shipping_weight(self):
            // for order in self:
            //     order.shipping_weight = order._get_estimated_weight()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShowHoursRecordedButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _compute_show_hours_recorded_button(self):
            // show_button_ids = self._get_order_with_valid_service_product()
            // for order in self:
            //     order.show_hours_recorded_button = order.timesheet_count or order.project_count and order.id in show_button_ids
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShowProjectAndTaskButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_show_project_and_task_button(self):
            // is_project_manager = self.env.user.has_group('project.group_project_manager')
            // show_button_ids = self.env['sale.order.line']._read_group([
            //     ('order_id', 'in', self.ids),
            //     ('order_id.state', 'not in', ['draft', 'sent']),
            // ], aggregates=['order_id:array_agg'])[0][0]
            // for order in self:
            //     state = order.state not in ['draft', 'sent']
            //     order.show_project_button = state and order.project_count
            //     order.show_create_project_button = (
            //         is_project_manager
            //         and order.id in show_button_ids
            //         and not order.project_count
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTasksIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_tasks_ids(self):
            // tasks_per_so = self.env['project.task']._read_group(
            //     domain=self._tasks_ids_domain(),
            //     groupby=['sale_order_id', 'state'],
            //     aggregates=['id:recordset', '__count']
            // )
            // so_with_tasks = self.env['sale.order']
            // for order, state, tasks_ids, tasks_count in tasks_per_so:
            //     if order:
            //         order.tasks_ids += tasks_ids
            //         order.tasks_count += tasks_count
            //         order.closed_task_count += state in CLOSED_STATES and tasks_count
            //         so_with_tasks += order
            //     else:
            //         # tasks that have no sale_order_id need to be associated with the SO from their sale_line_id
            //         for task in tasks_ids:
            //             task_so = task.sale_line_id.order_id
            //             task_so.tasks_ids = [Command.link(task.id)]
            //             task_so.tasks_count += 1
            //             task_so.closed_task_count += state in CLOSED_STATES
            //             so_with_tasks += task_so
            // remaining_orders = self - so_with_tasks
            // if remaining_orders:
            //     remaining_orders.tasks_ids = [Command.clear()]
            //     remaining_orders.tasks_count = 0
            //     remaining_orders.closed_task_count = 0
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_tax_country_id(self):
            // for record in self:
            //     if record.fiscal_position_id.foreign_vat:
            //         record.tax_country_id = record.fiscal_position_id.country_id
            //     else:
            //         record.tax_country_id = record.company_id.account_fiscal_country_id
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_tax_totals(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order._get_priced_lines()
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     base_lines += order._add_base_lines_for_early_payment_discount()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     order.tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_team_id(self):
            // cached_teams = {}
            // for order in self:
            //     default_team_id = order._default_team_id()
            //     user_id = order.user_id.id
            //     company_id = order.company_id.id
            //     key = (default_team_id, user_id, company_id)
            //     if key not in cached_teams:
            //         cached_teams[key] = self.env['crm.team'].with_context(
            //             default_team_id=default_team_id,
            //         )._get_default_team_id(
            //             user_id=user_id,
            //             domain=self.env['crm.team']._check_company_domain(company_id),
            //         )
            //     order.team_id = cached_teams[key]
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTimesheetCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _compute_timesheet_count(self):
            // timesheets_per_so = {
            //     order.id: count
            //     for order, count in self.env['account.analytic.line']._read_group(
            //         [('order_id', 'in', self.ids), ('project_id', '!=', False)],
            //         ['order_id'],
            //         ['__count'],
            //     )
            // }
            // 
            // for order in self:
            //     order.timesheet_count = timesheets_per_so.get(order.id, 0)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTimesheetTotalDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _compute_timesheet_total_duration(self):
            // group_data = self.env['account.analytic.line']._read_group([
            //     ('order_id', 'in', self.ids), ('project_id', '!=', False)
            // ], ['order_id'], ['unit_amount:sum'])
            // timesheet_unit_amount_dict = defaultdict(float)
            // timesheet_unit_amount_dict.update({order.id: unit_amount for order, unit_amount in group_data})
            // for sale_order in self:
            //     total_time = sale_order.company_id.project_time_mode_id._compute_quantity(
            //         timesheet_unit_amount_dict[sale_order.id],
            //         sale_order.timesheet_encode_uom_id,
            //         rounding_method='HALF-UP',
            //     )
            //     sale_order.timesheet_total_duration = round(total_time)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTypeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_type_name(self):
            // for record in self:
            //     if record.state in ('draft', 'sent', 'cancel'):
            //         record.type_name = _("Quotation")
            //     else:
            //         record.type_name = _("Sales Order")
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_user_id(self):
            // for order in self:
            //     if order.partner_id and not (order._origin.id and order.user_id):
            //         # Recompute the salesman on partner change
            //         #   * if partner is set (is required anyway, so it will be set sooner or later)
            //         #   * if the order is not saved or has no salesman already
            //         order.user_id = (
            //             order.partner_id.user_id
            //             or order.partner_id.commercial_partner_id.user_id
            //             or (self.env.user.has_group('sales_team.group_sale_salesman') and self.env.user)
            //         )
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_user_id(self):
            // """Do not assign self.env.user as salesman for e-commerce orders.
            // 
            // Leave salesman empty if no salesman is specified on partner or website.
            // """
            // website_orders = self.filtered('website_id')
            // super(SaleOrder, self - website_orders)._compute_user_id()
            // for order in website_orders:
            //     if order.state == 'draft' and not order.env.context.get('force_user_recomputation'):
            //         # Do not assign any salesman to draft carts to avoid useless notifications/pings/...
            //         # It'll be assigned on confirmation (see action_confirm)
            //         continue
            //     if not order.user_id:
            //         order.user_id = (
            //             order.website_id.salesperson_id
            //             or order.partner_id.user_id.id
            //             or order.partner_id.parent_id.user_id.id
            //         )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeValidityDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_validity_date(self):
            // today = fields.Date.context_today(self)
            // for order in self:
            //     days = order.company_id.quotation_validity_days
            //     if days > 0:
            //         order.validity_date = today + timedelta(days)
            //     else:
            //         order.validity_date = False
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _compute_validity_date(self):
            // super()._compute_validity_date()
            // for order in self.filtered('sale_order_template_id'):
            //     validity_days = order.sale_order_template_id.number_of_days
            //     if validity_days > 0:
            //         order.validity_date = fields.Date.context_today(order) + timedelta(validity_days)
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeVisibleProjectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _compute_visible_project(self):
            // """ Users should be able to select a project_id on the SO if at least one SO line has a product with its service tracking
            // configured as 'task_in_project' """
            // for order in self:
            //     order.visible_project = any(
            //         service_tracking == 'task_in_project' for service_tracking in order.order_line.mapped('product_id.service_tracking')
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _compute_warehouse_id(self):
            // for order in self:
            //     default_warehouse_id = self.env['ir.default'].with_company(
            //         order.company_id.id)._get_model_defaults('sale.order').get('warehouse_id')
            //     if order.state in ['draft', 'sent'] or not order.ids:
            //         # Should expect empty
            //         if default_warehouse_id is not None:
            //             order.warehouse_id = default_warehouse_id
            //         else:
            //             order.warehouse_id = order.user_id.with_company(order.company_id.id)._get_default_warehouse_id()
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _compute_warehouse_id(self):
            // """ Override of `website_sale_stock` to avoid recomputations for in_store orders
            // when the warehouse was set by the pickup_location_data"""
            // in_store_orders_with_pickup_data = self.filtered(
            //     lambda so: (
            //         so.carrier_id.delivery_type == 'in_store' and so.pickup_location_data
            //     )
            // )
            // super(SaleOrder, self - in_store_orders_with_pickup_data)._compute_warehouse_id()
            // for order in in_store_orders_with_pickup_data:
            //     order.warehouse_id = order.pickup_location_data['id']
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _compute_warehouse_id(self):
            // website_orders = self.filtered('website_id')
            // super(SaleOrder, self - website_orders)._compute_warehouse_id()
            // for order in website_orders:
            //     if order.website_id.warehouse_id:
            //         order.warehouse_id = order.website_id.warehouse_id
            //     else:
            //         super(SaleOrder, order)._compute_warehouse_id()
            //     if not order.warehouse_id:
            //         order.warehouse_id = self.env.user._get_default_warehouse_id()
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeWebsiteOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _compute_website_order_line(self):
            // # group saler.order.line to prefetch all in one query
            // order_lines = self.env['sale.order.line'].search_fetch([('order_id', 'in', self.ids)])
            // for order in self:
            //     order.website_order_line = order_lines.filtered(
            //         lambda sol: sol.order_id == order and sol._show_in_cart(),
            //     )
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _compute_website_order_line(self):
            // """ This method will merge multiple discount lines generated by a same program
            //     into a single one (temporary line with `new()`).
            //     This case will only occur when the program is a discount applied on multiple
            //     products with different taxes.
            //     In this case, each taxes will have their own discount line. This is required
            //     to have correct amount of taxes according to the discount.
            //     But we want these lines to be `visually` merged into a single one in the
            //     e-commerce since the end user should only see one discount line.
            //     This is only possible since we don't show taxes in cart.
            //     eg:
            //         line 1: 10% discount on product with tax `A` - $15
            //         line 2: 10% discount on product with tax `B` - $11.5
            //         line 3: 10% discount on product with tax `C` - $10
            //     would be `hidden` and `replaced` by
            //         line 1: 10% discount - $36.5
            // 
            //     Note: The line will be created without tax(es) and the amount will be computed
            //           depending if B2B or B2C is enabled.
            // """
            // super()._compute_website_order_line()
            // for order in self:
            //     grouped_order_lines = defaultdict(lambda: self.env['sale.order.line'])
            //     for line in order.order_line:
            //         if line.reward_id and line.coupon_id:
            //             grouped_order_lines[(line.reward_id, line.coupon_id, line.reward_identifier_code)] |= line
            //     new_lines = self.env['sale.order.line']
            //     for lines in grouped_order_lines.values():
            //         if lines.reward_id.reward_type != 'discount':
            //             continue
            //         new_lines += self.env['sale.order.line'].new({
            //             'product_id': lines[0].product_id.id,
            //             'tax_ids': False,
            //             'price_unit': sum(lines.mapped('price_unit')),
            //             'price_subtotal': sum(lines.mapped('price_subtotal')),
            //             'price_total': sum(lines.mapped('price_total')),
            //             'discount': 0.0,
            //             'name': lines[0].name_short if lines.reward_id.reward_type != 'product' else lines[0].name,
            //             'product_uom_qty': 1,
            //             'product_uom_id': lines[0].product_uom_id.id,
            //             'order_id': order.id,
            //             'is_reward_line': True,
            //             'coupon_id': lines.coupon_id,
            //             'reward_id': lines.reward_id,
            //         })
            //     if new_lines:
            //         order.website_order_line += new_lines
            */
            return default;
        }

        public async Task<SaleOrder> ConfirmAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: sale_order.py) ---
            // def action_confirm(self):
            // unmatch = self.filtered(lambda so: so.carrier_id.is_mondialrelay != so.partner_shipping_id.is_mondialrelay)
            // if unmatch:
            //     error = _('Mondial Relay mismatching between delivery method and shipping address.')
            //     if len(self) > 1:
            //         error += ' (%s)' % ','.join(unmatch.mapped('name'))
            //     raise UserError(error)
            // return super().action_confirm()
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py) ---
            // def action_confirm(self):
            // res = super(SaleOrder, self).action_confirm()
            // for so in self:
            //     if not any(line.service_tracking == 'event_booth' for line in so.order_line):
            //         continue
            //     so_lines_missing_booth = so.order_line.filtered(lambda line: line.service_tracking == 'event_booth' and not line.event_booth_pending_ids)
            //     if so_lines_missing_booth:
            //         so_lines_descriptions = "".join(f"\n- {so_line_description.name}" for so_line_description in so_lines_missing_booth)
            //         raise ValidationError(_("Please make sure all your event-booth related lines are configured before confirming this order:%s", so_lines_descriptions))
            //     so.order_line._update_event_booths()
            // return res
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py) ---
            // def action_confirm(self):
            // res = super(SaleOrder, self).action_confirm()
            // 
            // for so in self:
            //     if not any(line.service_tracking == 'event' for line in so.order_line):
            //         continue
            //     so_lines_missing_events = so.order_line.filtered(lambda line: line.service_tracking == 'event' and not line.event_id)
            //     if so_lines_missing_events:
            //         so_lines_descriptions = "".join(f"\n- {so_line_description.name}" for so_line_description in so_lines_missing_events)
            //         raise ValidationError(_("Please make sure all your event related lines are configured before confirming this order:%s", so_lines_descriptions))
            //     # Initialize registrations
            //     so.order_line._init_registrations()
            //     if len(self) == 1:
            //         return self.env['ir.actions.act_window'].with_context(
            //             default_sale_order_id=so.id
            //         )._for_xml_id('event_sale.action_sale_order_event_registration')
            // return res
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: sale_order.py) ---
            // def action_confirm(self):
            // res = super().action_confirm()
            // self._add_partnership()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_confirm(self):
            // """ Confirm the given quotation(s) and set their confirmation date.
            // 
            // If the corresponding setting is enabled, also locks the Sale Order.
            // 
            // :return: True
            // :rtype: bool
            // :raise: UserError if trying to confirm cancelled SO's
            // """
            // for order in self:
            //     error_msg = order._confirmation_error_message()
            //     if error_msg:
            //         raise UserError(error_msg)
            // 
            // self.order_line._validate_analytic_distribution()
            // 
            // self.write(self._prepare_confirmation_values())
            // 
            // # Context key 'default_name' is sometimes propagated up to here.
            // # We don't need it and it creates issues in the creation of linked records.
            // context = self.env.context.copy()
            // context.pop('default_name', None)
            // context.pop('default_user_id', None)
            // 
            // self.with_context(context)._action_confirm()
            // self.filtered(lambda so: so._should_be_locked()).action_lock()
            // 
            // if self.env.context.get('send_email'):
            //     self._send_order_confirmation_mail()
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: sale_order.py) ---
            // def action_confirm(self):
            // res = super(SaleOrder, self.with_context({k: v for k, v in self.env.context.items() if k != 'default_tag_ids'})).action_confirm()
            // for order in self:
            //     order.opportunity_id._update_revenues_from_so(order)
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def action_confirm(self):
            // """ Override of `sale` to send the order to Gelato on confirmation. """
            // res = super().action_confirm()
            // for order in self.filtered(
            //     lambda o: any(o.order_line.product_id.mapped('gelato_product_uid'))
            // ):
            //     if message := order._ensure_partner_address_is_complete():
            //         raise ValidationError(message)
            //     order._create_order_on_gelato()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def action_confirm(self):
            // """
            // Override to validate and update coupon rewards.
            // 
            // If called with one SO, checks if there exists rewards that are available but not claimed,
            // and if so returns a notification action.
            // 
            // :raises ValidationError: A coupon gave a negative amount of points.
            // :return: True or a notification action
            // :rtype: bool | dict
            // """
            // for order in self:
            //     all_coupons = order.applied_coupon_ids | order.coupon_point_ids.coupon_id | order.order_line.coupon_id
            //     if any(order._get_real_points_for_coupon(coupon) < 0 for coupon in all_coupons):
            //         raise ValidationError(_("One or more rewards on the sale order is invalid. Please check them."))
            //     order._update_programs_and_rewards()
            //     order._add_loyalty_history_lines()
            // has_claimable_rewards = len(self) == 1 and bool(self._get_claimable_rewards())
            // 
            // # Remove any coupon from 'current' program that don't claim any reward.
            // # This is to avoid ghost coupons that are lost forever.
            // # Claiming a reward for that program will require either an automated check or a manual input again.
            // reward_coupons = self.order_line.coupon_id
            // self.coupon_point_ids.filtered(
            //     lambda pe: pe.coupon_id.program_id.applies_on == 'current' and pe.coupon_id not in reward_coupons
            // ).coupon_id.sudo().unlink()
            // # Add/remove the points to our coupons
            // for coupon, change in self.filtered(lambda s: s.state != 'sale')._get_point_changes().items():
            //     coupon.points += change
            // res = super().action_confirm()
            // # Prioritize any action from super()
            // if isinstance(res, bool) and has_claimable_rewards:
            //     res = {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'info',
            //             'title': _("Rewards Available"),
            //             'message': _("There are available rewards not added to this order."),
            //             'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // self._send_reward_coupon_mail()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def action_confirm(self):
            // res = super().action_confirm()
            // 
            // if self.env.context.get('send_email'):
            //     # Mail already sent in super method
            //     return res
            // 
            // # When an order is confirmed from backend (send_email=False), if the quotation template has
            // # a specified mail template, send it as it's probably meant to share additional information.
            // for order in self:
            //     if order.sale_order_template_id.mail_template_id:
            //         order._send_order_notification_mail(order.sale_order_template_id.mail_template_id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def action_confirm(self):
            // if len(self) == 1 and self.env.context.get('create_for_project_id') and self.state == 'sale':
            //     # do nothing since the SO has been automatically confirmed during its creation
            //     return True
            // return super().action_confirm()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def action_confirm(self):
            // carts = self.filtered('website_id')
            // if self.env.su:
            //     carts = carts.with_user(SUPERUSER_ID)
            // # Assign the salesman to carts on confirmation, as SUPERUSER to send the
            // # 'You have been assigned to SOOOO' with OdooBot (and not public/logged in user).
            // carts.with_context(force_user_recomputation=True)._compute_user_id()
            // return super().action_confirm()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> ConfirmOrderOnGelatoInternalAsync(Guid gelato_order_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _confirm_order_on_gelato(self, gelato_order_id):
            // """Send the order confirmation request to Gelato.
            // 
            // This is performed in a separate transaction to allow running as post-commit hook.
            // 
            // :return: None
            // """
            // self.ensure_one()
            // 
            // _logger.info(
            //     "Confirmation of Gelato order %s for sales order %s", gelato_order_id, self.display_name
            // )
            // data = None
            // try:
            //     api_key = self.company_id.sudo().gelato_api_key  # In sudo mode to read on the company.
            //     payload = {'orderType': 'order'}  # Confirm the order (draft -> order).
            //     data = utils.make_request(
            //         api_key,
            //         'order',
            //         'v4',
            //         f'orders/{gelato_order_id}',
            //         payload=payload,
            //         method='PATCH',
            //     )
            // except UserError:
            //     self.message_post(
            //         body=self.env._("Unable to confirm the order %s on Gelato.", gelato_order_id),
            //         author_id=self.env.ref('base.partner_root').id,
            //     )
            // finally:
            //     _logger.info(
            //         "Received confirmation request response for Gelato order %s:\n%s",
            //         gelato_order_id, pprint.pformat(data),
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> ConfirmationErrorMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _confirmation_error_message(self):
            // """ Return whether order can be confirmed or not if not then returm error message. """
            // self.ensure_one()
            // if self.state not in {'draft', 'sent'}:
            //     return _("Some orders are not in a state requiring confirmation.")
            // if any(
            //     not line.display_type
            //     and not line.is_downpayment
            //     and not line.product_id
            //     for line in self.order_line
            // ):
            //     return _("Some order lines are missing a product, you need to correct them before going further.")
            // 
            // return False
            */
            return default;
        }

        protected async Task<SaleOrder> ConstraintUniqueAssignedGradeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: sale_order.py) ---
            // def _constraint_unique_assigned_grade(self):
            // for so in self:
            //     if len(set(so.order_line.mapped('product_id.grade_id'))) > 1:
            //         raise ValidationError(so.env._(
            //             "You cannot confirm Sale Order %(sale_order_name)s because there are products"
            //             " assigning different grades.", sale_order_name=so.name,
            //         ))
            */
            return default;
        }

        public override async Task<SaleOrder> CopyAsync(CopyRequestDto<SaleOrder> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def copy(self, default=None):
            // new_orders = super().copy(default)
            // reward_lines = new_orders.order_line.filtered('is_reward_line')
            // if reward_lines:
            //     reward_lines.unlink()
            // return new_orders
            */
            return await base.CopyAsync(input);
        }

        public async Task<SaleOrder> CopyDataAsync(SaleOrderCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // default_has_no_order_line = 'order_line' not in default
            // default.setdefault('order_line', [])
            // vals_list = super().copy_data(default=default)
            // if default_has_no_order_line:
            //     for order, vals in zip(self, vals_list):
            //         vals['order_line'] = [
            //             Command.create(line_vals)
            //             for line_vals in order._get_copiable_order_lines().copy_data()
            //         ]
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> CountPosOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _count_pos_order(self):
            // for order in self:
            //     linked_orders = order.pos_order_line_ids.mapped('order_id')
            //     order.pos_order_count = len(linked_orders)
            */
            return default;
        }

        protected async Task<SaleOrder> CreateAccountInvoicesInternalAsync(object invoice_vals_list, object final)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_account_invoices(self, invoice_vals_list, final):
            // """Small method to allow overriding the behavior right after an invoice is created."""
            // # Manage the creation of invoices in sudo because a salesperson must be able to generate an invoice from a
            // # sale order without "billing" access rights. However, he should not be able to create an invoice from scratch.
            // return self.env['account.move'].sudo().with_context(default_move_type='out_invoice').create(invoice_vals_list)
            */
            return default;
        }

        protected async Task<SaleOrder> CreateActivitySetDetailsInternalAsync(object body)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py) ---
            // def _create_activity_set_details(self, body):
            // """ Create activity on sale order to set details.
            // 
            // :return: None.
            // """
            // activity_message = _("Some information could not be imported:")
            // activity_message += body
            // self.activity_schedule(
            //     'mail.mail_activity_data_todo',
            //     user_id=self.env.user.id,
            //     note=activity_message,
            // )
            */
            return default;
        }

        public override async Task<SaleOrder> CreateAsync(CreateRequestDto<SaleOrder> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('name', _("New")) == _("New"):
            //         seq_date = fields.Datetime.context_timestamp(
            //             self, fields.Datetime.to_datetime(vals['date_order'])
            //         ) if 'date_order' in vals else None
            //         vals['name'] = self.env['ir.sequence'].with_company(vals.get('company_id')).next_by_code(
            //             'sale.order', sequence_date=seq_date) or _("New")
            // 
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def create(self, vals_list):
            // created_records = super().create(vals_list)
            // project = self.env['project.project'].browse(self.env.context.get('create_for_project_id'))
            // task = self.env['project.task'].browse(self.env.context.get('create_for_task_id'))
            // if project or task:
            //     service_sol = next((sol for sol in created_records.order_line if sol.is_service), self.env['sale.order.line'])
            //     if project and not project.sale_line_id:
            //         project.sale_line_id = service_sol
            //         if not project.reinvoiced_sale_order_id:
            //             project.reinvoiced_sale_order_id = service_sol.order_id or created_records[0] if created_records else False
            //     if task and not task.sale_line_id:
            //         created_records.with_context(disable_project_task_generation=True).action_confirm()
            //         task.sale_line_id = service_sol
            // return created_records
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def create(self, vals_list):
            // created_records = super().create(vals_list)
            // if self.env.context.get('create_for_employee_mapping'):
            //     if not next((sol for sol in created_records.order_line if sol.is_service), False):
            //         raise UserError(_('The Sales Order must contain at least one service product.'))
            //     created_records.with_context(disable_project_task_generation=True).action_confirm()
            // return created_records
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website_id'):
            //         website = self.env['website'].browse(vals['website_id'])
            //         if 'company_id' in vals:
            //             company = self.env['res.company'].browse(vals['company_id'])
            //             if website.company_id.id != company.id:
            //                 raise ValueError(_(
            //                     "The company of the website you are trying to sell from (%(website_company)s)"
            //                     " is different than the one you want to use (%(company)s)",
            //                     website_company=website.company_id.name,
            //                     company=company.name,
            //                 ))
            //         else:
            //             vals['company_id'] = website.company_id.id
            // return super().create(vals_list)
            */
            return await base.CreateAsync(input);
        }

        protected async Task<SaleOrder> CreateDeliveryLineInternalAsync(object carrier, object price_unit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _create_delivery_line(self, carrier, price_unit):
            // values = self._prepare_delivery_line_vals(carrier, price_unit)
            // return self.env['sale.order.line'].sudo().create(values)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py) ---
            // def _create_delivery_line(self, carrier, price_unit):
            // sol = super()._create_delivery_line(carrier, price_unit)
            // context = {}
            // if self.partner_id:
            //     # set delivery detail in the customer language
            //     context['lang'] = self.partner_id.lang
            // if carrier.invoice_policy == 'real':
            //     sol.update({
            //         'price_unit': 0,
            //         'name': _(
            //             "%(name)s (Estimated Cost: %(cost)s)",
            //             name=sol["name"],
            //             cost=self.currency_id.format(price_unit),
            //         ),
            //     })
            // del context
            // return sol
            */
            return default;
        }

        public async Task<SaleOrder> CreateDocumentFromAttachmentAsync(SaleOrderCreateDocumentFromAttachmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the sale orders from given attachment_ids and redirect newly create order view.
            // 
            // :param list attachment_ids: List of attachments process.
            // :return: An action redirecting to related sale order view.
            // :rtype: dict
            // """
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // orders = self.with_context(default_partner_id=self.env.user.partner_id.id)._create_records_from_attachments(attachments)
            // 
            // return orders._get_records_action(name=_("Generated Orders"))
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> CreateDownPaymentLinesFromBaseLinesInternalAsync(object down_payment_base_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_down_payment_lines_from_base_lines(self, down_payment_base_lines):
            // """ Add the base lines passed as parameter as sale order lines into the current sale order.
            // 
            // :param down_payment_base_lines: A list of base lines
            //                                 (see '_prepare_base_line_for_taxes_computation').
            // :return The newly created SO lines.
            // """
            // self.ensure_one()
            // sequence = max(self.order_line.mapped('sequence') or [10]) + 1
            // return self.env['sale.order.line'] \
            //     .with_context(sale_no_log_for_new_lines=True) \
            //     .create([
            //         {
            //             **self._prepare_down_payment_line_values_from_base_line(base_line),
            //             'sequence': sequence + index,
            //         }
            //         for index, base_line in enumerate(down_payment_base_lines)
            //     ])
            */
            return default;
        }

        protected async Task<SaleOrder> CreateDownPaymentSectionLineIfNeededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_down_payment_section_line_if_needed(self):
            // """ Add the down section line if not already there on the current SO.
            // 
            // :return The newly created SO line or None if the section was already there.
            // """
            // self.ensure_one()
            // # If a down payment is already there, then the section is not needed and
            // # has already been created.
            // if any(line.display_type and line.is_downpayment for line in self.order_line):
            //     return
            // 
            // sequence = max(self.order_line.mapped('sequence') or [10]) + 1
            // return self.env['sale.order.line'] \
            //     .with_context(sale_no_log_for_new_lines=True) \
            //     .create({
            //         **self._prepare_down_payment_line_section_values(),
            //         'sequence': sequence,
            //     })
            */
            return default;
        }

        protected async Task<SaleOrder> CreateInvoicesInternalAsync(object grouped, object final, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_invoices(self, grouped=False, final=False, date=None):
            // """ Create invoice(s) for the given Sales Order(s).
            // 
            // :param bool grouped: if True, invoices are grouped by SO id.
            //     If False, invoices are grouped by keys returned by :meth:`_get_invoice_grouping_keys`
            // :param bool final: if True, refunds will be generated if necessary
            // :param date: unused parameter
            // :returns: created invoices
            // :rtype: `account.move` recordset
            // :raises: UserError if one of the orders has no invoiceable lines.
            // """
            // if not self.env['account.move'].has_access('create'):
            //     try:
            //         self.check_access('write')
            //     except AccessError:
            //         return self.env['account.move']
            // 
            // # 1) Create invoices.
            // invoice_vals_list = []
            // invoice_item_sequence = 0 # Incremental sequencing to keep the lines order on the invoice.
            // for order in self:
            //     if order.partner_invoice_id.lang:
            //         order = order.with_context(lang=order.partner_invoice_id.lang)
            //     order = order.with_company(order.company_id)
            // 
            //     invoice_vals = order._prepare_invoice()
            //     invoiceable_lines = order._get_invoiceable_lines(final)
            // 
            //     if all(line.display_type for line in invoiceable_lines):
            //         continue
            // 
            //     invoice_line_vals = []
            //     down_payment_section_added = False
            //     for line in invoiceable_lines:
            //         if not down_payment_section_added and line.is_downpayment:
            //             # Create a dedicated section for the down payments
            //             # (put at the end of the invoiceable_lines)
            //             invoice_line_vals.append(
            //                 Command.create(
            //                     order._prepare_down_payment_section_line(sequence=invoice_item_sequence)
            //                 ),
            //             )
            //             down_payment_section_added = True
            //             invoice_item_sequence += 1
            // 
            //         optional_values = {'sequence': invoice_item_sequence}
            // 
            //         # When creating the final invoice, we want to express the lines representing
            //         # the full order but negate the already created down payment lines.
            //         # At this point, on the sale order, the down payment lines have a non-empty
            //         # 'extra_tax_data' containing a price unit greater than zero and a quantity of 0.0.
            //         if line.is_downpayment:
            //             optional_values['quantity'] = -1.0
            //             optional_values['extra_tax_data'] = self.env['account.tax']\
            //                 ._reverse_quantity_base_line_extra_tax_data(line.extra_tax_data)
            // 
            //         for vals in line._prepare_invoice_lines_vals_list(**optional_values):
            //             invoice_line_vals.append(Command.create(vals))
            // 
            //         invoice_item_sequence += 1
            // 
            //     invoice_vals['invoice_line_ids'] += invoice_line_vals
            //     invoice_vals_list.append(invoice_vals)
            // 
            // if not invoice_vals_list and self.env.context.get('raise_if_nothing_to_invoice', True):
            //     raise UserError(self._nothing_to_invoice_error_message())
            // 
            // # 2) Manage 'grouped' parameter: group by (partner_id, partner_shipping_id, currency_id).
            // if not grouped:
            //     new_invoice_vals_list = []
            //     invoice_grouping_keys = self._get_invoice_grouping_keys()
            //     invoice_vals_list = sorted(
            //         invoice_vals_list,
            //         key=lambda x: [
            //             x.get(grouping_key) for grouping_key in invoice_grouping_keys
            //         ]
            //     )
            //     for _grouping_keys, invoices in groupby(invoice_vals_list, key=lambda x: [x.get(grouping_key) for grouping_key in invoice_grouping_keys]):
            //         origins = set()
            //         payment_refs = set()
            //         refs = set()
            //         ref_invoice_vals = None
            //         for invoice_vals in invoices:
            //             if not ref_invoice_vals:
            //                 ref_invoice_vals = invoice_vals
            //             else:
            //                 ref_invoice_vals['invoice_line_ids'] += invoice_vals['invoice_line_ids']
            //             origins.add(invoice_vals['invoice_origin'])
            //             payment_refs.add(invoice_vals['payment_reference'])
            //             refs.add(invoice_vals['ref'])
            //         ref_invoice_vals.update({
            //             'ref': ', '.join(refs)[:2000],
            //             'invoice_origin': ', '.join(origins),
            //             'payment_reference': len(payment_refs) == 1 and payment_refs.pop() or False,
            //         })
            //         new_invoice_vals_list.append(ref_invoice_vals)
            //     invoice_vals_list = new_invoice_vals_list
            // 
            // # 3) Create invoices.
            // 
            // # As part of the invoice creation, we make sure the sequence of multiple SO do not interfere
            // # in a single invoice. Example:
            // # SO 1:
            // # - Section A (sequence: 10)
            // # - Product A (sequence: 11)
            // # SO 2:
            // # - Section B (sequence: 10)
            // # - Product B (sequence: 11)
            // #
            // # If SO 1 & 2 are grouped in the same invoice, the result will be:
            // # - Section A (sequence: 10)
            // # - Section B (sequence: 10)
            // # - Product A (sequence: 11)
            // # - Product B (sequence: 11)
            // #
            // # Resequencing should be safe, however we resequence only if there are less invoices than
            // # orders, meaning a grouping might have been done. This could also mean that only a part
            // # of the selected SO are invoiceable, but resequencing in this case shouldn't be an issue.
            // if len(invoice_vals_list) < len(self):
            //     SaleOrderLine = self.env['sale.order.line']
            //     for invoice in invoice_vals_list:
            //         sequence = 1
            //         for line in invoice['invoice_line_ids']:
            //             line[2]['sequence'] = SaleOrderLine._get_invoice_line_sequence(new=sequence, old=line[2]['sequence'])
            //             sequence += 1
            // 
            // moves = self._create_account_invoices(invoice_vals_list, final)
            // 
            // # 4) Some moves might actually be refunds: convert them if the total amount is negative
            // # We do this after the moves have been created since we need taxes, etc. to know if the total
            // # is actually negative or not
            // if final and (moves_to_switch := moves.sudo().filtered(lambda m: m.amount_total < 0)):
            //     with self.env.protecting([moves._fields['team_id']], moves_to_switch):
            //         moves_to_switch.action_switch_move_type()
            //         self.invoice_ids._set_reversed_entry(moves_to_switch)
            // 
            // for move in moves:
            //     move.message_post_with_source(
            //         'mail.message_origin_link',
            //         render_values={'self': move, 'origin': move.line_ids.sale_line_ids.order_id},
            //         subtype_xmlid='mail.mt_note',
            //     )
            // return moves
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _create_invoices(self, grouped=False, final=False, date=None):
            // """Link timesheets to the created invoices. Date interval is injected in the
            // context in sale_make_invoice_advance_inv wizard.
            // """
            // moves = super()._create_invoices(grouped=grouped, final=final, date=date)
            // moves._link_timesheets_to_invoice(self.env.context.get("timesheet_start_date"), self.env.context.get("timesheet_end_date"))
            // self._reset_has_displayed_warning_upsell_order_lines()
            // return moves
            */
            return default;
        }

        protected async Task<SaleOrder> CreateNewCartLineInternalAsync(Guid product_id, object quantity, Guid uom_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _create_new_cart_line(self, product_id, quantity, uom_id, **kwargs):
            // if quantity <= 0.0:
            //     return self.env['sale.order.line']
            // 
            // line = self.env['sale.order.line'].create(
            //     self._prepare_order_line_values(product_id, quantity, uom_id, **kwargs)
            // )
            // 
            // # The validity of a combo product line can only be checked after creating all of its combo
            // # item lines.
            // if line.product_type != 'combo':
            //     line._check_validity()
            // return line
            */
            return default;
        }

        protected async Task<SaleOrder> CreateOrderOnGelatoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _create_order_on_gelato(self):
            // """ Send the order creation request to Gelato and log the request result on the chatter.
            // 
            // :return: None
            // """
            // delivery_line = self.order_line.filtered(
            //     lambda l: l.is_delivery and l.product_id.default_code in ('normal', 'express')
            // )
            // payload = {
            //     'orderType': 'draft',  # The order is confirmed/deleted later, see @post_commit hooks.
            //     'orderReferenceId': self.id,
            //     'customerReferenceId': f'Odoo Partner #{self.partner_id.id}',
            //     'currency': self.currency_id.name,
            //     'items': self._gelato_prepare_items_payload(),
            //     'shipmentMethodUid': delivery_line.product_id.default_code or 'cheapest',
            //     'shippingAddress': self.partner_shipping_id._gelato_prepare_address_payload(),
            // }
            // try:
            //     api_key = self.company_id.sudo().gelato_api_key  # In sudo mode to read on the company.
            //     data = utils.make_request(api_key, 'order', 'v4', 'orders', payload=payload)
            // 
            //     # Add hooks to confirm/delete the order on Gelato only after the transaction is
            //     # committed/rolled back. This prevents creating duplicate confirmed orders on Gelato.
            //     self.env.cr.postcommit.add(partial(self._confirm_order_on_gelato, data['id']))
            //     self.env.cr.postrollback.add(partial(self._delete_order_on_gelato, data['id']))
            // except UserError as e:
            //     raise UserError(_(
            //         "The order with reference %(order_reference)s was not sent to Gelato.\n"
            //         "Reason: %(error_message)s",
            //         order_reference=self.display_name,
            //         error_message=str(e),
            //     ))
            // 
            // _logger.info("Notification received from Gelato with data:\n%s", pprint.pformat(data))
            // self.message_post(
            //     body=_("The order has been successfully passed on Gelato."),
            //     author_id=self.env.ref('base.partner_root').id,
            // )
            */
            return default;
        }

        public async Task<SaleOrder> CreateProjectAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def action_create_project(self):
            // self.ensure_one()
            // if not self.show_create_project_button:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'message': self.env._("The project couldn't be created as the Sales Order must be confirmed or is already linked to a project."),
            //         }
            //     }
            // 
            // sorted_line = self.order_line.sorted('sequence')
            // default_sale_line = next((
            //     sol for sol in sorted_line
            //     if sol.product_id.type == 'service' and not sol.is_downpayment
            // ), self.env['sale.order.line'])
            // view_id = self.env.ref('sale_project.sale_project_view_form_simplified_template', raise_if_not_found=False)
            // return {
            //     **self.env['project.template.create.wizard'].action_open_template_view(),
            //     'name': self.env._('Create a Project'),
            //     'views': [(view_id.id, 'form')],
            //     'context': {
            //         'default_sale_order_id': self.id,
            //         'default_reinvoiced_sale_order_id': self.id,
            //         'default_sale_line_id': default_sale_line.id,
            //         'default_partner_id': self.partner_id.id,
            //         'default_user_ids': [self.env.uid],
            //         'default_allow_billable': 1,
            //         'hide_allow_billable': True,
            //         'default_company_id': self.company_id.id,
            //         'generate_milestone': default_sale_line.product_id.service_policy == 'delivered_milestones',
            //         'default_name': self.name,
            //         'default_allow_milestones': 'delivered_milestones' in self.order_line.product_id.mapped('service_policy'),
            //     },
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> CreateUpsellActivityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_upsell_activity(self):
            // if not self:
            //     return
            // 
            // self.activity_unlink(['mail.mail_activity_data_todo'])
            // for order in self:
            //     order_ref = order._get_html_link()
            //     customer_ref = order.partner_id._get_html_link()
            //     order.activity_schedule(
            //         'mail.mail_activity_data_todo',
            //         user_id=order.user_id.id or order.partner_id.user_id.id,
            //         note=_("Upsell %(order)s for customer %(customer)s", order=order_ref, customer=customer_ref))
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> CronSendPendingEmailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _cron_send_pending_emails(self):
            // """ Find and send pending order status emails asynchronously.
            // 
            // :return: None
            // """
            // pending_email_orders = self.search([('pending_email_template_id', '!=', False)])
            // self.env['ir.cron']._commit_progress(remaining=len(pending_email_orders))
            // for order in pending_email_orders:
            //     order = order[0]  # Avoid pre-fetching after each cache invalidation due to committing.
            //     order._send_order_notification_mail(
            //         order.pending_email_template_id, allow_deferred_sending=False
            //     )  # Resume the email sending.
            //     order.pending_email_template_id = None
            //     remaining_time = self.env['ir.cron']._commit_progress(processed=1)
            //     if not remaining_time:
            //         break
            */
            return default;
        }

        [ApiModel]
        public override async Task<SaleOrder> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def default_get(self, fields):
            // res = super().default_get(fields)
            // if 'origin' in fields and (task_id := self.env.context.get('create_for_task_id')):
            //     task = self.env['project.task'].browse(task_id)
            //     res['origin'] = self.env._('[Project] %(task_name)s', task_name=task.name)
            // return res
            */
            return await base.DefaultGetAsync(input);
        }

        protected async Task<SaleOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['sale.order.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        protected async Task<SaleOrder> DefaultQuotationDocumentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py) ---
            // def _default_quotation_document_ids(self):
            // return self.env['quotation.document'].search([
            //     *self.env['quotation.document']._check_company_domain(self.env.company),
            //     ('quotation_template_ids', '=', False),
            //     ('add_by_default', '=', True),
            // ])
            */
            return default;
        }

        protected async Task<SaleOrder> DefaultTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _default_team_id(self):
            // return self.env.context.get('default_team_id', False) or self.team_id.id
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _default_team_id(self):
            // return super()._default_team_id() or self.website_id.salesteam_id.id
            */
            return default;
        }

        protected async Task<SaleOrder> DeleteOrderOnGelatoInternalAsync(Guid gelato_order_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _delete_order_on_gelato(self, gelato_order_id):
            // """Send the order deletion request to Gelato.
            // 
            // This is performed in a separate transaction to allow running as post-commit hook.
            // 
            // :return: None
            // """
            // self.ensure_one()
            // 
            // _logger.info(
            //     "Deletion of Gelato order %s for sales order %s", gelato_order_id, self.display_name
            // )
            // data = None
            // try:
            //     api_key = self.company_id.sudo().gelato_api_key  # In sudo mode to read on the company.
            //     data = utils.make_request(
            //         api_key, 'order', 'v4', f'orders/{gelato_order_id}', method='DELETE'
            //     )
            // except UserError:
            //     self.message_post(
            //         body=self.env._("Unable to delete the order %s on Gelato.", gelato_order_id),
            //         author_id=self.env.ref('base.partner_root').id,
            //     )
            // finally:
            //     _logger.info(
            //         "Received deletion request response for Gelato order %s:\n%s",
            //         gelato_order_id, pprint.pformat(data),
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> DiscardTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _discard_tracking(self):
            // self.ensure_one()
            // return (
            //     self.state == 'draft'
            //     and request and request.env.context.get('catalog_skip_tracking')
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableAmountInternalAsync(object rewards_to_ignore)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _discountable_amount(self, rewards_to_ignore):
            // """Compute the `discountable` amount for the current order, ignoring the provided rewards.
            // 
            // :param rewards_to_ignore: the rewards to ignore from the total amount (if they were already
            //     applied on the order)
            // :type rewards_to_ignore: `loyalty.reward` recordset
            // 
            // :return: The discountable amount
            // :rtype: float
            // """
            // self.ensure_one()
            // 
            // discountable = 0
            // 
            // for line in self.order_line - self._get_no_effect_on_threshold_lines():
            //     if rewards_to_ignore and line.reward_id in rewards_to_ignore:
            //         # Ignore the existing reward line if it was already applied
            //         continue
            //     if not line.product_uom_qty or not line.price_unit:
            //         # Ignore lines whose amount will be 0 (bc of empty qty or 0 price)
            //         continue
            //     tax_data = line.tax_ids.compute_all(
            //         line.price_unit,
            //         quantity=line.product_uom_qty,
            //         product=line.product_id,
            //         partner=line.order_partner_id,
            //     )
            //     # To compute the discountable amount we get the subtotal and add
            //     # non-fixed tax totals. This way fixed taxes will not be discounted
            //     taxes = line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')
            //     discountable += tax_data['total_excluded'] + sum(
            //         tax['amount'] for tax in tax_data['taxes'] if tax['id'] in taxes.ids
            //     )
            // return discountable
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableCheapestInternalAsync(object reward)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _discountable_cheapest(self, reward):
            // """
            // Returns the discountable and discountable_per_tax for a discount that applies to the cheapest line
            // """
            // self.ensure_one()
            // assert reward.discount_applicability == 'cheapest'
            // 
            // cheapest_line = self._cheapest_line(reward)
            // if not cheapest_line:
            //     return False, False
            // 
            // discountable = 0
            // discountable_per_tax = defaultdict(int)
            // for line in cheapest_line:
            //     discountable += line.price_total / line.product_uom_qty
            //     taxes = line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')
            //     discountable_per_tax[taxes] += line.price_unit * (1 - (line.discount or 0) / 100)
            // 
            // return discountable, discountable_per_tax
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableOrderInternalAsync(object reward)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _discountable_order(self, reward):
            // """Compute the `discountable` amount (and amounts per tax group) for the current order.
            // 
            // :param reward: if provided, the reward whose discountable amounts must be computed.
            //     It must be applicable at the order level.
            // :type reward: `loyalty.reward` record, can be empty to compute the amounts regardless of the
            //     program configuration
            // 
            // :return: A tuple with the first element being the total discountable amount of the order,
            //     and the second a dictionary mapping each non-fixed taxes group to its corresponding
            //     total untaxed amount of the eligible order lines.
            // :rtype: tuple(float, dict(account.tax: float))
            // """
            // self.ensure_one()
            // reward.ensure_one()
            // assert reward.discount_applicability == 'order'
            // 
            // lines = self.order_line.filtered(lambda line: not line.display_type)
            // if not reward.program_id.is_payment_program:
            //     # Gift cards and eWallets are applied on the total order amount
            //     # Other types of programs are not expected to apply on delivery lines
            //     lines -= self._get_no_effect_on_threshold_lines()
            // 
            // discountable = 0
            // discountable_per_tax = defaultdict(float)
            // 
            // AccountTax = self.env['account.tax']
            // base_lines = []
            // for line in lines:
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     taxes = base_line['tax_ids'].flatten_taxes_hierarchy()
            //     if not reward.program_id.is_payment_program:
            //         # To compute the discountable amount we get the subtotal and add
            //         # non-fixed tax totals. This way fixed taxes will not be discounted
            //         # This does not apply to Gift Cards and e-Wallet, where the total
            //         # order amount may be paid with the card balance
            //         taxes = taxes.filtered(lambda t: t.amount_type != 'fixed')
            //     base_line['discount_taxes'] = taxes
            //     base_lines.append(base_line)
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // 
            // def grouping_function(base_line, tax_data):
            //     if not tax_data:
            //         return None
            //     return {
            //         'taxes': base_line['discount_taxes'],
            //         'skip': (
            //             tax_data['tax'] not in base_line['discount_taxes']
            //             or base_line['record'] not in lines
            //         ),
            //     }
            // 
            // base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, grouping_function)
            // values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            // for grouping_key, values in values_per_grouping_key.items():
            //     if grouping_key and grouping_key['skip']:
            //         continue
            // 
            //     taxes = grouping_key['taxes'] if grouping_key else self.env['account.tax']
            //     discountable += values['raw_base_amount_currency'] + values['raw_tax_amount_currency']
            //     discountable_per_tax[taxes] += (
            //         values['raw_base_amount_currency']
            //         + sum(
            //             tax_data['raw_tax_amount_currency']
            //             for base_line, taxes_data in values['base_line_x_taxes_data']
            //             for tax_data in taxes_data
            //             if tax_data['tax'].price_include
            //         )
            //     )
            // return discountable, discountable_per_tax
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableSpecificInternalAsync(object reward)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _discountable_specific(self, reward):
            // """
            // Special function to compute the discountable for 'specific' types of discount.
            // The goal of this function is to make sure that applying a 5$ discount on an order with a
            //  5$ product and a 5% discount does not make the order go below 0.
            // 
            // Returns the discountable and discountable_per_tax for a discount that only applies to specific products.
            // """
            // self.ensure_one()
            // assert reward.discount_applicability == 'specific'
            // 
            // lines_to_discount = self._get_specific_discountable_lines(reward).filtered(
            //     lambda line: bool(line.product_uom_qty and line.price_total)
            // )
            // discount_lines = defaultdict(lambda: self.env['sale.order.line'])
            // order_lines = self.order_line - self._get_no_effect_on_threshold_lines()
            // remaining_amount_per_line = defaultdict(int)
            // for line in order_lines:
            //     if not line.product_uom_qty or not line.price_total:
            //         continue
            //     remaining_amount_per_line[line] = line.price_total
            //     if line.reward_id.reward_type == 'discount':
            //         discount_lines[line.reward_identifier_code] |= line
            // 
            // order_lines -= self.order_line.filtered('reward_id')
            // cheapest_line = False
            // for lines in discount_lines.values():
            //     line_reward = lines.reward_id
            //     discounted_lines = order_lines
            //     if line_reward.discount_applicability == 'cheapest':
            //         # get the discounted cheapest line applicable for given reward domain
            //         cheapest_line = cheapest_line or self._cheapest_line(line_reward)
            //         discounted_lines = cheapest_line
            //     elif line_reward.discount_applicability == 'specific':
            //         discounted_lines = self._get_specific_discountable_lines(line_reward)
            //     if not discounted_lines:
            //         continue
            //     common_lines = discounted_lines & lines_to_discount
            //     if line_reward.discount_mode == 'percent':
            //         for line in discounted_lines:
            //             if line_reward.discount_applicability == 'cheapest':
            //                 remaining_amount_per_line[line] *= (1 - line_reward.discount / 100 / line.product_uom_qty)
            //             else:
            //                 remaining_amount_per_line[line] *= (1 - line_reward.discount / 100)
            //     else:
            //         non_common_lines = discounted_lines - lines_to_discount
            //         # Fixed prices are per tax
            //         discounted_amounts = defaultdict(int, {
            //             sol.tax_ids.filtered(lambda t: t.amount_type != 'fixed'): abs(sol.price_total)
            //             for sol in lines
            //         })
            //         for line in itertools.chain(non_common_lines, common_lines):
            //             # For gift card and eWallet programs we have no tax but we can consume the amount completely
            //             if lines.reward_id.program_id.is_payment_program:
            //                 discounted_amount = discounted_amounts[lines.tax_ids.filtered(lambda t: t.amount_type != 'fixed')]
            //             else:
            //                 discounted_amount = discounted_amounts[line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')]
            //             if discounted_amount == 0:
            //                 continue
            //             remaining = remaining_amount_per_line[line]
            //             consumed = min(remaining, discounted_amount)
            //             if lines.reward_id.program_id.is_payment_program:
            //                 discounted_amounts[lines.tax_ids.filtered(lambda t: t.amount_type != 'fixed')] -= consumed
            //             else:
            //                 discounted_amounts[line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')] -= consumed
            //             remaining_amount_per_line[line] -= consumed
            // 
            // discountable = 0
            // discountable_per_tax = defaultdict(int)
            // for line in lines_to_discount:
            //     discountable += remaining_amount_per_line[line]
            //     line_discountable = line.price_unit * line.product_uom_qty * (1 - (line.discount or 0.0) / 100.0)
            //     # line_discountable is the same as in a 'order' discount
            //     #  but first multiplied by a factor for the taxes to apply
            //     #  and then multiplied by another factor coming from the discountable
            //     taxes = line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')
            //     discountable_per_tax[taxes] += line_discountable *\
            //         (remaining_amount_per_line[line] / line.price_total)
            // return discountable, discountable_per_tax
            */
            return default;
        }

        public async Task<SaleOrder> DraftAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_draft(self):
            // orders = self.filtered(lambda s: s.state in ['cancel', 'sent'])
            // return orders.write({
            //     'state': 'draft',
            //     'signature': False,
            //     'signed_by': False,
            //     'signed_on': False,
            // })
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> EnsurePartnerAddressIsCompleteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _ensure_partner_address_is_complete(self):
            // """Ensure that all order's partner address fields required by Gelato are set.
            // 
            // :return: An error message if the address is incomplete, None otherwise.
            // :rtype: str | None
            // """
            // required_address_fields = ['city', 'country_id', 'email', 'name', 'street']
            // if self.partner_id.country_id.code not in const.COUNTRIES_WITHOUT_ZIPCODE:
            //     required_address_fields.append('zip')
            // missing_fields = [
            //     self.partner_id._fields[field_name]
            //     for field_name in required_address_fields if not self.partner_id[field_name]
            // ]
            // if missing_fields:
            //     translated_field_names = [f._description_string(self.env) for f in missing_fields]
            //     return _(
            //         "The following required address fields are missing: %s",
            //         ", ".join(translated_field_names),
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> FetchDuplicateOrdersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _fetch_duplicate_orders(self):
            // """ Fetch duplicated orders.
            // 
            // :return: Dictionary mapping order to its related duplicated orders.
            // :rtype: dict
            // """
            // orders = self.filtered(lambda order: order.id and order.client_order_ref)
            // if not orders:
            //     return {}
            // 
            // self.env['sale.order'].flush_model(['company_id', 'partner_id', 'client_order_ref', 'origin', 'state'])
            // 
            // result = self.env.execute_query(SQL("""
            //     SELECT
            //         sale_order.id AS order_id,
            //         array_agg(duplicate_order.id) AS duplicate_ids
            //       FROM sale_order
            //       JOIN sale_order AS duplicate_order
            //         ON sale_order.company_id = duplicate_order.company_id
            //          AND sale_order.id != duplicate_order.id
            //          AND duplicate_order.state != 'cancel'
            //          AND sale_order.partner_id = duplicate_order.partner_id
            //          AND (
            //             sale_order.origin = duplicate_order.name
            //             OR sale_order.client_order_ref = duplicate_order.client_order_ref
            //         )
            //      WHERE sale_order.id IN %(orders)s
            //      GROUP BY sale_order.id
            //     """,
            //     orders=tuple(orders.ids),
            // ))
            // return {
            //     order_id: set(duplicate_ids)
            //     for order_id, duplicate_ids in result
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> FilterCanSendAbandonedCartMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py) ---
            // def _filter_can_send_abandoned_cart_mail(self):
            // # Prevent carts with expired/sold out tickets from being subject of reminder emails
            // return super()._filter_can_send_abandoned_cart_mail().filtered(
            //     lambda so: all(ticket.sale_available for ticket in so.order_line.event_ticket_id),
            // )
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _filter_can_send_abandoned_cart_mail(self):
            // self.website_id.ensure_one()
            // abandoned_datetime = datetime.utcnow() - relativedelta(hours=self.website_id.cart_abandoned_delay)
            // 
            // sales_after_abandoned_date = self.env['sale.order'].search([
            //     ('state', '=', 'sale'),
            //     ('partner_id', 'in', self.partner_id.ids),
            //     ('create_date', '>=', abandoned_datetime),
            //     ('website_id', '=', self.website_id.id),
            // ])
            // latest_create_date_per_partner = {}
            // for sale in self:
            //     if sale.partner_id not in latest_create_date_per_partner:
            //         latest_create_date_per_partner[sale.partner_id] = sale.create_date
            //     else:
            //         latest_create_date_per_partner[sale.partner_id] = max(latest_create_date_per_partner[sale.partner_id], sale.create_date)
            // has_later_sale_order = {}
            // for sale in sales_after_abandoned_date:
            //     if has_later_sale_order.get(sale.partner_id, False):
            //         continue
            //     has_later_sale_order[sale.partner_id] = latest_create_date_per_partner[sale.partner_id] <= sale.date_order
            // 
            // # Customer needs to be signed in otherwise the mail address is not known.
            // # We therefore consider only sales with a known mail address.
            // 
            // # If a payment processing error occurred when the customer tried to complete their checkout,
            // # then the email won't be sent.
            // 
            // # If all the products in the checkout are free, and the customer does not visit the shipping page to add a
            // # shipping fee or the shipping fee is also free, then the email won't be sent.
            // 
            // # If a potential customer creates one or more abandoned sale order and then completes a sale order before
            // # the recovery email gets sent, then the email won't be sent.
            // 
            // return self.filtered(
            //     lambda abandoned_sale_order:
            //     abandoned_sale_order.partner_id.email
            //     and not any(transaction.sudo().state == 'error' for transaction in abandoned_sale_order.transaction_ids)
            //     and any(not float_is_zero(line.price_unit, precision_rounding=line.currency_id.rounding) for line in abandoned_sale_order.order_line)
            //     and not has_later_sale_order.get(abandoned_sale_order.partner_id, False)
            // )
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _filter_can_send_abandoned_cart_mail(self):
            // """Filter sale orders on their product availability."""
            // return super()._filter_can_send_abandoned_cart_mail().filtered(
            //     lambda so: so._all_product_available()
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> FilterProductDocumentsInternalAsync(object documents)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _filter_product_documents(self, documents):
            // return documents.filtered(
            //     lambda document:
            //         document.attached_on_sale == 'quotation'
            //         or (self.state == 'sale' and document.attached_on_sale == 'sale_order')
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> FindMailTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _find_mail_template(self):
            // """ Get the appropriate mail template for the current sales order based on its state.
            // 
            // If the SO is confirmed, we return the mail template for the sale confirmation.
            // Otherwise, we return the quotation email template.
            // 
            // :return: The correct mail template based on the current status
            // :rtype: record of `mail.template` or `None` if not found
            // """
            // self.ensure_one()
            // if self.env.context.get('proforma'):
            //     return self.env.ref('sale.email_template_proforma', raise_if_not_found=False)
            // elif self.state != 'sale':
            //     return self.env.ref('sale.email_template_edi_sale', raise_if_not_found=False)
            // else:
            //     return self._get_confirmation_template()
            */
            return default;
        }

        protected async Task<SaleOrder> ForceLinesToInvoicePolicyOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _force_lines_to_invoice_policy_order(self):
            // """Force the qty_to_invoice to be computed as if the invoice_policy
            // was set to "Ordered quantities", independently of the product configuration.
            // 
            // This is needed for the automatic invoice logic, as we want to automatically
            // invoice the full SO when it's paid.
            // """
            // for line in self.order_line:
            //     if line.state == 'sale':
            //         # No need to set 0 as it is already the standard logic in the compute method.
            //         line.qty_to_invoice = line.product_uom_qty - line.qty_invoiced
            */
            return default;
        }

        protected async Task<SaleOrder> FormatCurrencyAmountInternalAsync(object amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py) ---
            // def _format_currency_amount(self, amount):
            // pre = post = u''
            // if self.currency_id.position == 'before':
            //     pre = u'{symbol}\N{NO-BREAK SPACE}'.format(symbol=self.currency_id.symbol or '')
            // else:
            //     post = u'\N{NO-BREAK SPACE}{symbol}'.format(symbol=self.currency_id.symbol or '')
            // return u' {pre}{0}{post}'.format(amount, pre=pre, post=post)
            */
            return default;
        }

        protected async Task<SaleOrder> GcAbandonedCouponsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _gc_abandoned_coupons(self, *args, **kwargs):
            // """Remove coupons from abandonned ecommerce order."""
            // ICP = self.env['ir.config_parameter']
            // validity = ICP.get_param('website_sale_coupon.abandonned_coupon_validity', 4)
            // validity = fields.Datetime.to_string(fields.Datetime.now() - timedelta(days=int(validity)))
            // so_to_reset = self.env['sale.order'].search([
            //     ('state', '=', 'draft'),
            //     ('write_date', '<', validity),
            //     ('website_id', '!=', False),
            //     ('applied_coupon_ids', '!=', False),
            // ])
            // so_to_reset.applied_coupon_ids = False
            // for so in so_to_reset:
            //     so._update_programs_and_rewards()
            */
            return default;
        }

        protected async Task<SaleOrder> GelatoPrepareItemsPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _gelato_prepare_items_payload(self):
            // """ Create the payload for the 'items' key of an 'orders' request.
            // 
            // :return: The items payload.
            // :rtype: dict
            // """
            // items_payload = []
            // for gelato_line in self.order_line.filtered(lambda l: l.product_id.gelato_product_uid):
            //     item_data = {
            //         'itemReferenceId': gelato_line.product_id.id,
            //         'productUid': gelato_line.product_id.gelato_product_uid,
            //         'files': [
            //             image._gelato_prepare_file_payload()
            //             for image in gelato_line.product_id.product_tmpl_id.gelato_image_ids
            //         ],
            //         'quantity': int(gelato_line.product_uom_qty),
            //     }
            //     items_payload.append(item_data)
            // return items_payload
            */
            return default;
        }

        protected async Task<SaleOrder> GenerateDownpaymentInvoicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _generate_downpayment_invoices(self):
            // """ Generate invoices as down payments for sale order.
            // 
            // :return: The generated down payment invoices.
            // :rtype: recordset of `account.move`
            // """
            // generated_invoices = self.env['account.move']
            // 
            // for order in self:
            //     downpayment_wizard = order.env['sale.advance.payment.inv'].create({
            //         'sale_order_ids': order,
            //         'advance_payment_method': 'fixed',
            //         'fixed_amount': order.amount_paid,
            //     })
            //     generated_invoices |= downpayment_wizard._create_invoices(order)
            // 
            // return generated_invoices
            */
            return default;
        }

        protected async Task<SaleOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            //     'show_sections': bool(self.id),
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> GetActionViewPickingInternalAsync(object pickings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _get_action_view_picking(self, pickings):
            // '''
            // This function returns an action that display existing delivery orders
            // of given sales order ids. It can either be a in a list or in a form
            // view, if there is only one delivery order to show.
            // '''
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_picking_tree_all")
            // 
            // if len(pickings) > 1:
            //     action['domain'] = [('id', 'in', pickings.ids)]
            // elif pickings:
            //     form_view = [(self.env.ref('stock.view_picking_form').id, 'form')]
            //     if 'views' in action:
            //         action['views'] = form_view + [(state,view) for state,view in action['views'] if view != 'form']
            //     else:
            //         action['views'] = form_view
            //     action['res_id'] = pickings.id
            // # Prepare the context.
            // picking_id = pickings.filtered(lambda l: l.picking_type_id.code == 'outgoing')
            // if picking_id:
            //     picking_id = picking_id[0]
            // else:
            //     picking_id = pickings[0]
            // action['context'] = dict(
            //     default_partner_id=self.partner_id.id,
            //     default_picking_type_id=picking_id.picking_type_id.id,
            // )
            // return action
            */
            return default;
        }

        protected async Task<SaleOrder> GetAmountTotalExcludingDeliveryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_amount_total_excluding_delivery(self):
            // return sum(self._get_non_delivery_lines().mapped('price_total'))
            */
            return default;
        }

        protected async Task<SaleOrder> GetApplicableProgramPointsInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_applicable_program_points(self, domain=None):
            // """
            // Returns a dict with the points per program for each (automatic) program that is applicable
            // """
            // self.ensure_one()
            // if not domain:
            //     domain = [('trigger', '=', 'auto')]
            // # Make sure domain always complies with the order's domain rules
            // domain = Domain.AND([self._get_program_domain(), domain])
            // # No other way than to test all programs to the order
            // programs = self.env['loyalty.program'].search(domain)
            // all_status = self._program_check_compute_points(programs)
            // program_points = {p: status['points'][0] for p, status in all_status.items() if 'points' in status}
            // return program_points
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedGlobalDiscountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_applied_global_discount(self):
            // """
            // Returns the currently applied global discount reward or False
            // """
            // return self._get_applied_global_discount_lines().reward_id
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedGlobalDiscountLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_applied_global_discount_lines(self):
            // """
            // Returns the first line of the currently applied global discount or False
            // """
            // self.ensure_one()
            // return self.order_line.filtered(lambda l: l.reward_id.is_global_discount)
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedProgramsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_applied_programs(self):
            // """
            // Returns all applied programs on current order.
            // 
            // Applied programs is the combination of both new points for your order and the programs linked to rewards.
            // """
            // self.ensure_one()
            // return self._get_points_programs() | self._get_reward_programs()
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartAndFreeQtyInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _get_cart_and_free_qty(self, product):
            // """Get cart quantity and free quantity for given product.
            // 
            // Note: self.ensure_one()
            // 
            // :param product: `product.product` record.
            // :returns: cart quantity and available quantity in the product uom
            // :rtype: tuple
            // """
            // self.ensure_one()
            // product.ensure_one()
            // 
            // return self._get_cart_qty(product.id), self._get_free_qty(product)
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartQtyInternalAsync(Guid product_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _get_cart_qty(self, product_id):
            // """Return the quantity of the given product in the current cart, if any.
            // 
            // :param int product_id: `product.product` id
            // :return: product quantity in the product uom
            // :rtype: float
            // """
            // if not self:
            //     return 0.0
            // order_lines = self._get_common_product_lines(product_id)
            // return sum(
            //     order_lines.mapped(
            //         lambda sol: sol.product_uom_id._compute_quantity(
            //             sol.product_uom_qty, sol.product_id.uom_id,
            //         )
            //     )
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartRecoveryTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_cart_recovery_template(self):
            // """ Return the cart recovery template record for a set of orders.
            // 
            // If they all belong to the same website, we return the website-specific template;
            // otherwise we return the default template.
            // If the default is not found, the empty ['mail.template'] is returned.
            // """
            // websites = self.mapped('website_id')
            // template = websites.cart_recovery_mail_template_id if len(websites) == 1 else False
            // template = template or self.env.ref('website_sale.mail_template_sale_cart_recovery', raise_if_not_found=False)
            // return template or self.env['mail.template']
            */
            return default;
        }

        protected async Task<SaleOrder> GetClaimableAndShowableRewardsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_claimable_and_showable_rewards(self):
            // self.ensure_one()
            // res = self._get_claimable_rewards()
            // loyality_cards = self.env['loyalty.card'].search([
            //     ('partner_id', '=', self.partner_id.id),
            //     ('program_id', 'any', self._get_program_domain()),
            //     '|',
            //         ('program_id.trigger', '=', 'with_code'),
            //         '&', ('program_id.trigger', '=', 'auto'), ('program_id.applies_on', '=', 'future'),
            // ])
            // total_is_zero = self.currency_id.is_zero(self.amount_total)
            // global_discount_reward = self._get_applied_global_discount()
            // for coupon in loyality_cards:
            //     points = self._get_real_points_for_coupon(coupon)
            //     for reward in coupon.program_id.reward_ids - self.order_line.reward_id:
            //         if (
            //             reward.is_global_discount
            //             and global_discount_reward
            //             and self._best_global_discount_already_applied(global_discount_reward, reward)
            //         ):
            //             continue
            //         if reward.reward_type == 'discount' and total_is_zero:
            //             continue
            //         if coupon.expiration_date and coupon.expiration_date < fields.Date.today():
            //             continue
            //         if points >= reward.required_points:
            //             if coupon in res:
            //                 res[coupon] |= reward
            //             else:
            //                 res[coupon] = reward
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> GetClaimableRewardsInternalAsync(object forced_coupons)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_claimable_rewards(self, forced_coupons=None):
            // """
            // Fetch all rewards that are currently claimable from all concerned coupons,
            //  meaning coupons from applied programs and applied rewards or the coupons given as parameter.
            // 
            // Returns a dict containing the all the claimable rewards grouped by coupon.
            // Coupons that can not claim any reward are not contained in the result.
            // """
            // self.ensure_one()
            // result = defaultdict(lambda: self.env['loyalty.reward'])
            // 
            // all_coupons = forced_coupons or (self.coupon_point_ids.coupon_id | self.order_line.coupon_id | self.applied_coupon_ids)
            // if not all_coupons:
            //     return result
            // 
            // has_payment_reward = any(line.reward_id.program_id.is_payment_program for line in self.order_line)
            // global_discount_reward = self._get_applied_global_discount()
            // active_products_domain = self.env['loyalty.reward']._get_active_products_domain()
            // 
            // # Only evaluate discountable amount if needed
            // discountable = lazy(lambda: self._discountable_amount(global_discount_reward))
            // total_is_zero = lazy(lambda: self.currency_id.is_zero(discountable))
            // 
            // for coupon in all_coupons:
            //     # Skip coupons generated by this order that only apply on future orders
            //     if coupon.program_id.applies_on == 'future' and coupon.order_id == self:
            //         continue
            //     points = self._get_real_points_for_coupon(coupon)
            //     for reward in coupon.program_id.reward_ids:
            //         if (
            //             reward.is_global_discount
            //             and global_discount_reward
            //             and self._best_global_discount_already_applied(
            //                 global_discount_reward, reward, discountable
            //             )
            //         ):
            //             continue
            //         # Discounts are not allowed if the total is zero unless there is a payment reward, in which case we allow discounts.
            //         # If the total is 0 again without the payment reward it will be removed.
            //         is_discount = reward.reward_type == 'discount'
            //         is_payment_program = reward.program_id.is_payment_program
            //         if is_discount and total_is_zero and (not has_payment_reward or is_payment_program):
            //             continue
            //         # Skip discount that has already been applied if not part of a payment program
            //         if is_discount and not is_payment_program and reward in self.order_line.reward_id:
            //             continue
            //         if reward.reward_type == 'product' and not reward.filtered_domain(
            //             active_products_domain
            //         ):
            //             continue
            //         if points >= reward.required_points:
            //             result[coupon] |= reward
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _get_claimable_rewards(self, forced_coupons=None):
            // res = super()._get_claimable_rewards(forced_coupons)
            // if any(reward.reward_type == 'shipping' for reward in self.order_line.reward_id):
            //     # Allow only one reward of type shipping at the same time
            //     filtered_res = {}
            //     for coupon, rewards in res.items():
            //         filtered_rewards = rewards.filtered(lambda r: r.reward_type != 'shipping')
            //         if filtered_rewards:
            //             filtered_res[coupon] = filtered_rewards
            //     res = filtered_res
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> GetCommonProductLinesInternalAsync(Guid product_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _get_common_product_lines(self, product_id=None):
            // """Get all the lines of the current order with the given product."""
            // return self.order_line.filtered(lambda sol: sol.product_id.id == product_id)
            */
            return default;
        }

        protected async Task<SaleOrder> GetConfirmationTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_confirmation_template(self):
            // """ Get the mail template sent on SO confirmation (or for confirmed SO's).
            // 
            // :return: `mail.template` record or None if default template wasn't found
            // """
            // self.ensure_one()
            // default_confirmation_template_id = self.env['ir.config_parameter'].sudo().get_param(
            //     'sale.default_confirmation_template'
            // )
            // default_confirmation_template = default_confirmation_template_id \
            //     and self.env['mail.template'].browse(int(default_confirmation_template_id)).exists()
            // if default_confirmation_template:
            //     return default_confirmation_template
            // else:
            //     return self.env.ref('sale.mail_template_sale_confirmation', raise_if_not_found=False)
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _get_confirmation_template(self):
            // self.ensure_one()
            // return self.sale_order_template_id.mail_template_id or super()._get_confirmation_template()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_confirmation_template(self):
            // """Override of `sale` to use the website specific order confirmation email template if set."""
            // self.ensure_one()
            // 
            // if self.website_id and self.website_id.confirmation_email_template_id:
            //     return self.website_id.confirmation_email_template_id
            // 
            // return super()._get_confirmation_template()
            */
            return default;
        }

        protected async Task<SaleOrder> GetConfirmedTxCreateDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_confirmed_tx_create_date(self):
            // """Return the creation date of the earliest confirmed transaction to check which loyalty
            // programs are applicable. If no transactions are confirmed, return the current day, using
            // the company's time zone.
            // """
            // self.ensure_one()
            // order_tz = self._get_program_timezone()
            // confirmed_txs_dates = self.sudo().transaction_ids.filtered(
            //     lambda tx: tx.state in ('done', 'authorized'),
            // ).mapped('create_date')
            // if confirmed_txs_dates:
            //     # If order is getting confirmed, use the earliest finalized transaction's create date
            //     tx_date = min(confirmed_txs_dates)
            //     return tx_date.astimezone(timezone(order_tz)).date()
            // return fields.Date.context_today(self.with_context(tz=order_tz))
            */
            return default;
        }

        protected async Task<SaleOrder> GetCopiableOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_copiable_order_lines(self):
            // """Returns the order lines that can be copied to a new order."""
            // return self.order_line.filtered(lambda l: not l.is_downpayment)
            */
            return default;
        }

        protected async Task<SaleOrder> GetDefaultPaymentLinkValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_default_payment_link_values(self):
            // """ Override of `payment` to compute the default values of the payment link wizard. """
            // self.ensure_one()
            // 
            // prepayment_amount = self._get_prepayment_required_amount()
            // remaining_balance = self.amount_total - self.amount_paid
            // if self.state in ('draft', 'sent') and self.require_payment:
            //     suggested_amount = prepayment_amount  # Suggest the amount needed to confirm the quote.
            // else:  # The order is confirmed or doesn't require payment.
            //     suggested_amount = remaining_balance
            // return {
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_invoice_id.id,
            //     'amount': suggested_amount,
            //     'amount_max': remaining_balance,
            //     'amount_paid': self.amount_paid,
            //     'prepayment_amount': prepayment_amount,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> GetDeliveryMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_delivery_methods(self):
            // # searching on website_published will also search for available website (_search method on computed field)
            // return self.env['delivery.carrier'].sudo().search([
            //     ('website_published', '=', True),
            //     *self.env['delivery.carrier']._check_company_domain(self.company_id),
            // ]).filtered(lambda carrier: carrier._is_available_for_order(self))
            */
            return default;
        }

        protected async Task<SaleOrder> GetDiscountAmountInternalAsync(object reward, object discountable)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_discount_amount(self, reward, discountable):
            // """Compute the discount amount for the given reward, w.r.t. the discountable amount.
            // 
            // :param loyalty.reward reward: The reward for which to calculate the maximum discount.
            // :param float discountable: The total discountable amount of the sale order.
            // :return: The maximum discount amount.
            // :rtype: float
            // """
            // if reward.discount_mode == 'per_order':
            //     return reward.currency_id._convert(
            //         from_amount=reward.discount,
            //         to_currency=self.currency_id,
            //         company=self.company_id,
            //         date=fields.Date.today(),
            //     )
            // elif reward.discount_mode == 'percent':
            //     return discountable * (reward.discount / 100)
            */
            return default;
        }

        protected async Task<SaleOrder> GetEdiBuildersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_edi_builders(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py) ---
            // def _get_edi_builders(self):
            // return super()._get_edi_builders() + [self.env['sale.edi.xml.ubl_bis3']]
            */
            return default;
        }

        protected async Task<SaleOrder> GetEdiDecoderInternalAsync(object file_data, object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // """ Override of sale to add edi decoder for xml files.
            // 
            // :param dict file_data: File data to decode.
            // """
            // if file_data['import_file_type'] == 'sale.edi.xml.ubl_bis3':
            //     return {
            //         'priority': 20,
            //         'decoder': self.env['sale.edi.xml.ubl_bis3']._import_order_ubl,
            //     }
            // return super()._get_edi_decoder(file_data, new)
            */
            return default;
        }

        [ApiModel]
        public async Task<SaleOrder> GetEmptyListHelpAsync(SaleOrderGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("sale order"),
            // )
            // return super().get_empty_list_help(help_message)
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetEstimatedWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _get_estimated_weight(self):
            // self.ensure_one()
            // weight = 0.0
            // for order_line in self.order_line.filtered(lambda l: l.product_id.type == 'consu' and not l.is_delivery and not l.display_type and l.product_uom_qty > 0):
            //     weight += order_line.product_qty * order_line.product_id.weight
            // return weight
            */
            return default;
        }

        public async Task<SaleOrder> GetFirstServiceLineAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def get_first_service_line(self):
            // line = next((sol for sol in self.order_line if sol.is_service), False)
            // if not line:
            //     raise UserError(self.env._('The Sales Order must contain at least one service product.'))
            // return line
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetFreeQtyInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _get_free_qty(self, product):
            // return product.with_context(warehouse_id=self._get_shop_warehouse_id()).free_qty
            */
            return default;
        }

        protected async Task<SaleOrder> GetFreeShippingLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_free_shipping_lines(self):
            // self.ensure_one()
            // return self.order_line.filtered(lambda l: l.reward_id.reward_type == 'shipping')
            */
            return default;
        }

        protected async Task<SaleOrder> GetImportFileTypeInternalAsync(object file_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py) ---
            // def _get_import_file_type(self, file_data):
            // """ Identify UBL files. """
            // # EXTENDS 'account'
            // if (tree := file_data['xml_tree']) is not None:
            //     customization_id = tree.find('{*}CustomizationID')
            //     if customization_id is not None:
            //         if customization_id.text == 'urn:fdc:peppol.eu:poacc:trns:order:3':
            //             return 'sale.edi.xml.ubl_bis3'
            // return super()._get_import_file_type(file_data)
            */
            return default;
        }

        [ApiModel]
        public async Task<SaleOrder> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Quotations'),
            //     'template': '/sale/static/xls/quotations_import_template.xlsx',
            // }]
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetInsufficientStockDataInternalAsync(Guid wh_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _get_insufficient_stock_data(self, wh_id):
            // """Return the mapping of order lines with insufficient stock in the given warehouse to their
            // maximum available quantity in the line's UoM.
            // If there are multiple order lines for the same product, consider the sum of their
            // quantities.
            // 
            // :param int wh_id: The warehouse in which to check the stock, as a `stock.warehouse` id.
            // :return: The mapping of order lines to their maximum available quantity.
            // :rtype: dict
            // """
            // insufficient_stock_data = {}
            // for product, ols in self.order_line.grouped('product_id').items():
            //     if not product.is_storable or product.allow_out_of_stock_order:
            //         continue
            //     free_qty = product.with_context(warehouse_id=wh_id).free_qty
            //     for ol in ols:
            //         free_qty_in_uom = max(int(product.uom_id._compute_quantity(
            //             free_qty, ol.product_uom_id, rounding_method="DOWN"
            //         )), 0)  # Round down as only integer quantities can be sold.
            //         line_qty_in_uom = ol.product_uom_qty
            //         if line_qty_in_uom > free_qty_in_uom:  # Not enough stock.
            //             # Set a warning on the order line.
            //             insufficient_stock_data[ol] = free_qty_in_uom
            //             ol.shop_warning = self.env._(
            //                 "%(available_qty)s/%(line_qty)s available at this location",
            //                 available_qty=free_qty_in_uom, line_qty=int(line_qty_in_uom),
            //             )
            //         free_qty -= ol.product_uom_id._compute_quantity(line_qty_in_uom, product.uom_id)
            // return insufficient_stock_data
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoiceGroupingKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoice_grouping_keys(self):
            // return ['company_id', 'partner_id', 'partner_shipping_id', 'currency_id', 'fiscal_position_id']
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoiceableLinesInternalAsync(object final)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoiceable_lines(self, final=False):
            // """Return the invoiceable lines for order `self`."""
            // down_payment_line_ids = []
            // invoiceable_line_ids = []
            // section_line_ids = []
            // subsection_line_ids = []
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // 
            // for line in self.order_line:
            //     if line.display_type == 'line_section':
            //         section_line_ids = [line.id]  # Start a new section.
            //         subsection_line_ids = []
            //         continue
            //     if line.display_type == 'line_subsection':
            //         subsection_line_ids = [line.id]  # Start a new subsection.
            //         continue
            //     if line.display_type != 'line_note' and float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //         continue
            //     if line.qty_to_invoice > 0 or (line.qty_to_invoice < 0 and final) or line.display_type == 'line_note':
            //         if line.is_downpayment:
            //             # Keep down payment lines separately, to put them together
            //             # at the end of the invoice, in a specific dedicated section.
            //             down_payment_line_ids.append(line.id)
            //             continue
            //         # If the invoicable line is under subsection
            //         if subsection_line_ids:
            //             if line.display_type:
            //                 subsection_line_ids.append(line.id)
            //                 continue
            //             # Extend the subsection lines too if altleast one invoicable line is under subsection
            //             invoiceable_line_ids.extend(section_line_ids + subsection_line_ids)
            //             subsection_line_ids = []
            //             section_line_ids = []
            //         # If the invoicable line is under section
            //         elif section_line_ids:
            //             if line.display_type:
            //                 section_line_ids.append(line.id)
            //                 continue
            //             invoiceable_line_ids.extend(section_line_ids)
            //             section_line_ids = []
            //             subsection_line_ids = []
            //         invoiceable_line_ids.append(line.id)
            // 
            // return self.env['sale.order.line'].browse(invoiceable_line_ids + down_payment_line_ids)
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoiced(self):
            // # The invoice_ids are obtained thanks to the invoice lines of the SO
            // # lines, and we also search for possible refunds created directly from
            // # existing invoices. This is necessary since such a refund is not
            // # directly linked to the SO.
            // for order in self:
            //     invoices = order.order_line.invoice_lines.move_id.filtered(lambda r: r.move_type in ('out_invoice', 'out_refund'))
            //     order.invoice_ids = invoices
            //     order.invoice_count = len(invoices)
            */
            return default;
        }

        protected async Task<SaleOrder> GetLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_lang(self):
            // self.ensure_one()
            // 
            // if self.partner_id.lang and not self.partner_id.is_public:
            //     return self.partner_id.lang
            // 
            // return self.env.lang
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_lang(self):
            // res = super()._get_lang()
            // 
            // if self.website_id and request and request.is_frontend:
            //     # Use request lang as cart lang if request comes from frontend
            //     return request.env.lang
            // 
            // return res
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> GetLineValsListInternalAsync(object lines_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py) ---
            // def _get_line_vals_list(self, lines_vals):
            // """ Get sale order line values list.
            // 
            // :param list lines_vals: List of values [name, qty, price, tax].
            // :return: List of dict values.
            // """
            // 
            // return [{
            //     'sequence': 0,  # be sure to put these lines above the 'real' order lines
            //     'name': name,
            //     'product_uom_qty': quantity,
            //     'price_unit': price_unit,
            //     'tax_ids': [Command.set(tax_ids)],
            // } for name, quantity, price_unit, tax_ids in lines_vals]
            */
            return default;
        }

        protected async Task<SaleOrder> GetMatrixInternalAsync(object product_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py) ---
            // def _get_matrix(self, product_template):
            // """Return the matrix of the given product, updated with current SOLines quantities.
            // 
            // :param product.template product_template:
            // :return: matrix to display
            // :rtype: dict
            // """
            // def has_ptavs(line, sorted_attr_ids):
            //     # TODO instead of sorting on ids, use odoo-defined order for matrix ?
            //     ptav = line.product_template_attribute_value_ids.ids
            //     pnav = line.product_no_variant_attribute_value_ids.ids
            //     pav = pnav + ptav
            //     pav.sort()
            //     return pav == sorted_attr_ids
            // matrix = product_template._get_template_matrix(
            //     company_id=self.company_id,
            //     currency_id=self.currency_id,
            //     display_extra_price=True)
            // if self.order_line:
            //     lines = matrix['matrix']
            //     order_lines = self.order_line.filtered(lambda line: line.product_template_id == product_template)
            //     for line in lines:
            //         for cell in line:
            //             if not cell.get('name', False):
            //                 line = order_lines.filtered(lambda line: has_ptavs(line, cell['ptav_ids']))
            //                 if line and not line.combo_item_id:
            //                     cell.update({
            //                         'qty': sum(line.mapped('product_uom_qty'))
            //                     })
            // return matrix
            */
            return default;
        }

        protected async Task<SaleOrder> GetNamePortalContentViewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_portal_content_view(self):
            // """ This method can be inherited by localizations who want to localize the online quotation view. """
            // self.ensure_one()
            // return 'sale.sale_order_portal_content'
            */
            return default;
        }

        protected async Task<SaleOrder> GetNameTaxTotalsViewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_tax_totals_view(self):
            // """ This method can be inherited by localizations who want to localize the taxes displayed on the portal and sale order report. """
            // return 'sale.document_tax_totals'
            */
            return default;
        }

        protected async Task<SaleOrder> GetNoEffectOnThresholdLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_no_effect_on_threshold_lines(self):
            // """Return the lines that have no effect on the minimum amount to reach."""
            // self.ensure_one()
            // return self.env['sale.order.line']
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _get_no_effect_on_threshold_lines(self):
            // res = super()._get_no_effect_on_threshold_lines()
            // return res + self.order_line.filtered(
            //     lambda line: line.is_delivery or line.reward_id.reward_type == 'shipping')
            */
            return default;
        }

        protected async Task<SaleOrder> GetNonDeliveryLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_non_delivery_lines(self):
            // """Exclude delivery-related lines."""
            // return self.order_line.filtered(lambda line: not line.is_delivery)
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_non_delivery_lines(self):
            // """Override of `website_sale` to exclude delivery reward lines."""
            // return super()._get_non_delivery_lines() - self._get_free_shipping_lines()
            */
            return default;
        }

        protected async Task<SaleOrder> GetNotRewardedOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_not_rewarded_order_lines(self):
            // return self.order_line.filtered(lambda line: line.product_id and not line.reward_id)
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _get_not_rewarded_order_lines(self):
            // """Exclude delivery lines from consideration for reward points."""
            // order_line = super()._get_not_rewarded_order_lines()
            // return order_line.filtered(lambda line: not line.is_delivery)
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> GetNoteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_note_url(self):
            // return self.env.company.get_base_url()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_note_url(self):
            // website_id = self.env.context.get('website_id')
            // if website_id:
            //     return self.env['website'].browse(website_id).get_base_url()
            // return super()._get_note_url()
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderLinePriceInternalAsync(object order_line, object price_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_order_line_price(self, order_line, price_type):
            // return sum(order_line._get_lines_with_price().mapped(price_type))
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderLinesToReportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_order_lines_to_report(self):
            // down_payment_lines = self.order_line.filtered(lambda line:
            //     line.is_downpayment
            //     and not line.display_type
            //     and not line._get_downpayment_state()
            // )
            // 
            // def show_line(line):
            //     if line.is_downpayment:
            //         return (
            //             # Only show the down payment section if down payments were posted
            //             (line.display_type and down_payment_lines)
            //             # Only show posted down payments
            //             or line in down_payment_lines
            //         )
            //     return (
            //         line.display_type == 'line_section'
            //         or not (
            //             line.parent_id.collapse_composition
            //             or line.parent_id.parent_id.collapse_composition
            //         )
            //     )
            // 
            // return self.order_line.filtered(show_line)
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderWithValidServiceProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _get_order_with_valid_service_product(self):
            // SaleOrderLine = self.env['sale.order.line']
            // return SaleOrderLine._read_group(Domain.AND([
            //     SaleOrderLine._domain_sale_line_service(),
            //     [
            //         ('order_id', 'in', self.ids),
            //         '|', ('product_id.service_type', 'not in', ['milestones', 'manual']),
            //              ('product_id.invoice_policy', '!=', 'delivery'),
            //     ]
            // ]), aggregates=['order_id:array_agg'])[0][0]
            */
            return default;
        }

        protected async Task<SaleOrder> GetParentFieldOnChildModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_parent_field_on_child_model(self):
            // return 'order_id'
            */
            return default;
        }

        protected async Task<SaleOrder> GetPickupLocationsInternalAsync(object zip_code, object country)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _get_pickup_locations(self, zip_code=None, country=None, **kwargs):
            // """ Return the pickup locations of the delivery method close to a given zip code.
            // 
            // Use provided `zip_code` and `country` or the order's delivery address to determine the zip
            // code and the country to use.
            // 
            // Note: self.ensure_one()
            // 
            // :param int zip_code: The zip code to look up to, optional.
            // :param res.country country: The country to look up to, required if `zip_code` is provided.
            // :return: The close pickup locations data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // if zip_code:
            //     assert country  # country is required if zip_code is provided.
            //     partner_address = self.env['res.partner'].new({
            //         'active': False,
            //         'country_id': country.id,
            //         'zip': zip_code,
            //     })
            // else:
            //     partner_address = self.partner_shipping_id
            // try:
            //     error = {'error': _("No pick-up points are available for this delivery address.")}
            //     function_name = f'_{self.carrier_id.delivery_type}_get_close_locations'
            //     if not hasattr(self.carrier_id, function_name):
            //         return error
            //     pickup_locations = getattr(self.carrier_id, function_name)(partner_address, **kwargs)
            //     if not pickup_locations:
            //         return error
            //     return {'pickup_locations': pickup_locations}
            // except UserError as e:
            //     return {'error': str(e)}
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _get_pickup_locations(self, zip_code=None, country=None, **kwargs):
            // """ Override of `website_sale` to ensure that a country is provided when there is a zip
            // code.
            // 
            // If the country cannot be found (e.g., the GeoIP request fails), the zip code is cleared to
            // prevent the parent method's assertion to fail.
            // """
            // if zip_code and not country:
            //     country_code = None
            //     if self.pickup_location_data:
            //         country_code = self.pickup_location_data['country_code']
            //     elif request.geoip.country_code:
            //         country_code = request.geoip.country_code
            //     country = self.env['res.country'].search([('code', '=', country_code)], limit=1)
            //     if not country:
            //         zip_code = None  # Reset the zip code to skip the `assert` in the `super` call.
            // return super()._get_pickup_locations(zip_code=zip_code, country=country, **kwargs)
            */
            return default;
        }

        protected async Task<SaleOrder> GetPointChangesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_point_changes(self):
            // """
            // Returns the changes in points per coupon as a dict.
            // 
            // Used when validating/cancelling an order
            // """
            // points_per_coupon = defaultdict(lambda: 0)
            // for coupon_point in self.coupon_point_ids:
            //     points_per_coupon[coupon_point.coupon_id] += coupon_point.points
            // for line in self.order_line:
            //     if not line.reward_id or not line.coupon_id:
            //         continue
            //     points_per_coupon[line.coupon_id] -= line.points_cost
            // return points_per_coupon
            */
            return default;
        }

        protected async Task<SaleOrder> GetPointsProgramsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_points_programs(self):
            // """
            // Returns all programs that give points on the current order.
            // """
            // self.ensure_one()
            // return self.coupon_point_ids.filtered('points').coupon_id.program_id
            */
            return default;
        }

        public async Task<SaleOrder> GetPortalLastTransactionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_portal_last_transaction(self):
            // self.ensure_one()
            // return self.sudo().transaction_ids._get_last()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetPortalReturnActionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_portal_return_action(self):
            // """ Return the action used to display orders when returning from customer portal. """
            // self.ensure_one()
            // return self.env.ref('sale.action_quotations_with_onboarding')
            */
            return default;
        }

        protected async Task<SaleOrder> GetPreferredDeliveryMethodInternalAsync(object available_delivery_methods)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_preferred_delivery_method(self, available_delivery_methods):
            // """ Get the preferred delivery method based on available delivery methods for the order.
            // 
            // The preferred delivery method is selected as follows:
            // 
            // 1. The one that is already set if it is compatible.
            // 2. The default one if compatible.
            // 3. The first compatible one.
            // 
            // :param delivery.carrier available_delivery_methods: The available delivery methods for
            //        the order.
            // :return: The preferred delivery method for the order.
            // :rtype: delivery.carrier
            // """
            // self.ensure_one()
            // 
            // delivery_method = self.carrier_id
            // if available_delivery_methods and delivery_method not in available_delivery_methods:
            //     if self.partner_shipping_id.property_delivery_carrier_id in available_delivery_methods:
            //         delivery_method = self.partner_shipping_id.property_delivery_carrier_id
            //     else:
            //         delivery_method = available_delivery_methods[0]
            // return delivery_method
            */
            return default;
        }

        protected async Task<SaleOrder> GetPrepaidServiceLinesToUpsellInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _get_prepaid_service_lines_to_upsell(self):
            // """ Retrieve all sols which need to display an upsell activity warning in the SO
            // 
            //     These SOLs should contain a product which has:
            //         - type="service",
            //         - service_policy="ordered_prepaid",
            // """
            // self.ensure_one()
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // return self.order_line.filtered(lambda sol:
            //     sol.is_service
            //     and sol.invoice_status != "invoiced"
            //     and not sol.has_displayed_warning_upsell  # we don't want to display many times the warning each time we timesheet on the SOL
            //     and sol.product_id.service_policy == 'ordered_prepaid'
            //     and float_compare(
            //         sol.qty_delivered,
            //         sol.product_uom_qty * (sol.product_id.service_upsell_threshold or 1.0),
            //         precision_digits=precision
            //     ) > 0
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> GetPrepaymentRequiredAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_prepayment_required_amount(self):
            // """ Return the minimum amount needed to automatically confirm the quotation.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The minimum amount needed to automatically confirm the quotation.
            // :rtype: float
            // """
            // self.ensure_one()
            // 
            // if not self.require_payment:
            //     return 0
            // else:
            //     return self.currency_id.round(self.amount_total * self.prepayment_percent)
            */
            return default;
        }

        protected async Task<SaleOrder> GetPricedLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_priced_lines(self):
            // return self.order_line.filtered(lambda x: not x.display_type)
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('service_tracking', '!=', 'event_booth')
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('service_tracking', '!=', 'event')
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('sale_ok', '=', True)
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // pricelist = self.pricelist_id._get_products_price(
            //     quantity=1.0,
            //     products=products,
            //     currency=self.currency_id,
            //     date=self.date_order,
            //     **kwargs,
            // )
            // res = super()._get_product_catalog_order_data(products, **kwargs)
            // has_warning_group = self.env.user.has_group('sale.group_warning_sale')
            // for product in products:
            //     res[product.id]['price'] = pricelist.get(product.id)
            //     if product.sale_line_warn_msg and has_warning_group:
            //         res[product.id]['warning'] = product.sale_line_warn_msg
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, *, section_id=None, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['sale.order.line'])
            // if section_id is None:
            //     section_id = (
            //         self.order_line[:1].id
            //         if self.order_line[:1].display_type == 'line_section'
            //         else False
            //     )
            // for line in self.order_line:
            //     if (
            //         line.display_type
            //         or line.product_id.id not in product_ids
            //         or line.get_parent_section_line().id != section_id
            //     ):
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductDocumentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_documents(self):
            // self.ensure_one()
            // 
            // documents = (
            //     self.order_line.product_id.product_document_ids
            //     | self.order_line.product_template_id.product_document_ids
            // )
            // return self._filter_product_documents(documents).sorted()
            */
            return default;
        }

        protected async Task<SaleOrder> GetProgramDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_program_domain(self):
            // """
            // Returns the base domain that all programs have to comply to.
            // """
            // self.ensure_one()
            // today = self._get_confirmed_tx_create_date()
            // return [('active', '=', True), ('sale_ok', '=', True),
            //         *self.env['loyalty.program']._check_company_domain([self.company_id.id, self.company_id.parent_id.id]),
            //         '|', ('pricelist_ids', '=', False), ('pricelist_ids', 'in', [self.pricelist_id.id]),
            //         '|', ('date_from', '=', False), ('date_from', '<=', today),
            //         '|', ('date_to', '=', False), ('date_to', '>=', today)]
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_program_domain(self):
            // res = super()._get_program_domain()
            // # Replace `sale_ok` leaf with `ecommerce_ok` if order is linked to a website
            // if self.website_id:
            //     for idx, leaf in enumerate(res):
            //         if leaf[0] != 'sale_ok':
            //             continue
            //         res[idx] = ('ecommerce_ok', '=', True)
            //         return Domain.AND([res, [('website_id', 'in', (self.website_id.id, False))]])
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> GetProgramTimezoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_program_timezone(self):
            // """Get the timezone to be used for loyalty date checking on the current order."""
            // self.ensure_one()
            // return (
            //     self.company_id.partner_id.tz
            //     or self.env['ir.config_parameter'].sudo().get_param('loyalty.timezone', 'UTC')
            // )
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_program_timezone(self):
            // return self.website_id.salesperson_id.tz or super()._get_program_timezone()
            */
            return default;
        }

        public async Task<SaleOrder> GetPromoCodeErrorAsync(SaleOrderGetPromoCodeErrorRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def get_promo_code_error(self, delete=True):
            // error = request.session.get('error_promo_code')
            // if error and delete:
            //     request.session.pop('error_promo_code')
            // return error
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetPromoCodeSuccessMessageAsync(SaleOrderGetPromoCodeSuccessMessageRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def get_promo_code_success_message(self, delete=True):
            // if not request.session.get('successful_code'):
            //     return False
            // code = request.session.get('successful_code')
            // if delete:
            //     request.session.pop('successful_code')
            // return code
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetPurchaseOrdersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def _get_purchase_orders(self):
            // return self.order_line.purchase_line_ids.order_id
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: sale_order.py) ---
            // def _get_purchase_orders(self):
            // return super()._get_purchase_orders() | self.stock_reference_ids.purchase_ids
            */
            return default;
        }

        protected async Task<SaleOrder> GetRealPointsForCouponInternalAsync(object coupon, object post_confirm)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_real_points_for_coupon(self, coupon, post_confirm=False):
            // """
            // Returns the actual points usable for this coupon for this order. Set pos_confirm to True to include points for future orders.
            // 
            // This is calculated by taking the points on the coupon, the points the order will give to the coupon (if applicable) and removing the points taken by already applied rewards.
            // """
            // self.ensure_one()
            // points = coupon.points
            // if self.state not in ('sale', 'done'):
            //     if coupon.program_id.applies_on != 'future':
            //         # Points that will be given by the order upon confirming the order
            //         points += self.coupon_point_ids.filtered(lambda p: p.coupon_id == coupon).points
            //     # Points already used by rewards
            //     points -= sum(self.order_line.filtered(lambda l: l.coupon_id == coupon).mapped('points_cost'))
            // points = coupon.currency_id.round(points)
            // return points
            */
            return default;
        }

        protected async Task<SaleOrder> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_report_base_filename(self):
            // self.ensure_one()
            // return f'{self.type_name} {self.name}'
            */
            return default;
        }

        public async Task<SaleOrder> GetReportMatrixesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py) ---
            // def get_report_matrixes(self):
            // """Reporting method.
            // 
            // :return: array of matrices to display in the report
            // :rtype: list
            // """
            // matrixes = []
            // if self.report_grids:
            //     grid_configured_templates = self.order_line.filtered('is_configurable_product').product_template_id.filtered(lambda ptmpl: ptmpl.product_add_mode == 'matrix')
            //     for template in grid_configured_templates:
            //         if len(self.order_line.filtered(lambda line: line.product_template_id == template)) > 1:
            //             matrix = self._get_matrix(template)
            //             matrix_data = []
            //             for row in matrix['matrix']:
            //                 if any(column['qty'] != 0 for column in row[1:]):
            //                     matrix_data.append(row)
            //             matrix['matrix'] = matrix_data
            //             matrixes.append(matrix)
            // return matrixes
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetRewardCouponsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_reward_coupons(self):
            // """
            // Returns all coupons that are a reward.
            // """
            // self.ensure_one()
            // return self.coupon_point_ids.filtered('points').coupon_id.filtered(
            //     lambda c: c.program_id.applies_on == 'future',
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardLineValuesInternalAsync(object reward, object coupon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_reward_line_values(self, reward, coupon, **kwargs):
            // self.ensure_one()
            // self = self.with_context(lang=self._get_lang())
            // reward = reward.with_context(lang=self._get_lang())
            // if reward.reward_type == 'discount':
            //     return self._get_reward_values_discount(reward, coupon, **kwargs)
            // elif reward.reward_type == 'product':
            //     return self._get_reward_values_product(reward, coupon, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _get_reward_line_values(self, reward, coupon, **kwargs):
            // self.ensure_one()
            // if reward.reward_type == 'shipping':
            //     self = self.with_context(lang=self._get_lang())
            //     reward = reward.with_context(lang=self._get_lang())
            //     return self._get_reward_values_free_shipping(reward, coupon, **kwargs)
            // return super()._get_reward_line_values(reward, coupon, **kwargs)
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardProgramsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_reward_programs(self):
            // """
            // Returns all programs that are being used for rewards.
            // """
            // self.ensure_one()
            // return self.order_line.reward_id.program_id
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesDiscountInternalAsync(object reward, object coupon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_reward_values_discount(self, reward, coupon, **kwargs):
            // self.ensure_one()
            // assert reward.reward_type == 'discount'
            // 
            // reward_applies_on = reward.discount_applicability
            // reward_product = reward.discount_line_product_id
            // reward_program = reward.program_id
            // reward_currency = reward.currency_id
            // sequence = max(
            //     self.order_line.filtered(lambda x: not x.is_reward_line).mapped('sequence'),
            //     default=10
            // ) + 1
            // base_reward_line_values = {
            //     'product_id': reward_product.id,
            //     'product_uom_qty': 1.0,
            //     'tax_ids': [Command.clear()],
            //     'name': reward.description,
            //     'reward_id': reward.id,
            //     'coupon_id': coupon.id,
            //     'sequence': sequence,
            //     'reward_identifier_code': _generate_random_reward_code(),
            // }
            // 
            // discountable = 0
            // discountable_per_tax = defaultdict(int)
            // if reward_applies_on == 'order':
            //     discountable, discountable_per_tax = self._discountable_order(reward)
            // elif reward_applies_on == 'specific':
            //     discountable, discountable_per_tax = self._discountable_specific(reward)
            // elif reward_applies_on == 'cheapest':
            //     discountable, discountable_per_tax = self._discountable_cheapest(reward)
            // 
            // if not discountable:
            //     if not reward_program.is_payment_program and any(line.reward_id.program_id.is_payment_program for line in self.order_line):
            //         return [{
            //             **base_reward_line_values,
            //             'name': _("TEMPORARY DISCOUNT LINE"),
            //             'price_unit': 0,
            //             'product_uom_qty': 0,
            //             'points_cost': 0,
            //         }]
            //     raise UserError(_("There is nothing to discount"))
            // 
            // max_discount = reward_currency._convert(reward.discount_max_amount, self.currency_id, self.company_id, fields.Date.today()) or float('inf')
            // # discount should never surpass the order's current total amount
            // max_discount = min(self.amount_total, max_discount)
            // if reward.discount_mode == 'per_point':
            //     points = self._get_real_points_for_coupon(coupon)
            //     if not reward_program.is_payment_program:
            //         # Rewards cannot be partially offered to customers
            //         points = points // reward.required_points * reward.required_points
            //     max_discount = min(max_discount,
            //         reward_currency._convert(reward.discount * points,
            //             self.currency_id, self.company_id, fields.Date.today()))
            // elif reward.discount_mode == 'per_order':
            //     max_discount = min(max_discount,
            //         reward_currency._convert(reward.discount, self.currency_id, self.company_id, fields.Date.today()))
            // elif reward.discount_mode == 'percent':
            //     max_discount = min(max_discount, discountable * (reward.discount / 100))
            // 
            // # Discount per taxes
            // point_cost = reward.required_points if not reward.clear_wallet else self._get_real_points_for_coupon(coupon)
            // if reward.discount_mode == 'per_point' and not reward.clear_wallet:
            //     # Calculate the actual point cost if the cost is per point
            //     converted_discount = self.currency_id._convert(min(max_discount, discountable), reward_currency, self.company_id, fields.Date.today())
            //     point_cost = coupon.currency_id.round(converted_discount / reward.discount)
            // 
            // if reward_program.is_payment_program:  # Gift card / eWallet
            //     reward_line_values = {
            //         **base_reward_line_values,
            //         'price_unit': -min(max_discount, discountable),
            //         'points_cost': point_cost,
            //     }
            // 
            //     if reward_program.program_type == 'gift_card':
            //         # For gift cards, the SOL should consider the discount product taxes
            //         taxes_to_apply = reward_product.taxes_id._filter_taxes_by_company(self.company_id)
            //         if taxes_to_apply:
            //             mapped_taxes = self.fiscal_position_id.map_tax(taxes_to_apply)
            //             price_incl_taxes = mapped_taxes.filtered('price_include')
            //             tax_res = mapped_taxes.with_context(
            //                 force_price_include=True,
            //                 round=False,
            //                 round_base=False,
            //             ).compute_all(
            //                 reward_line_values['price_unit'],
            //                 currency=self.currency_id,
            //             )
            //             new_price = tax_res['total_excluded']
            //             new_price += sum(
            //                 tax_data['amount']
            //                 for tax_data in tax_res['taxes']
            //                 if tax_data['id'] in price_incl_taxes.ids
            //             )
            //             reward_line_values.update({
            //                 'price_unit': new_price,
            //                 'tax_ids': [Command.set(mapped_taxes.ids)],
            //             })
            //     return [reward_line_values]
            // 
            // discount_factor = min(1, (max_discount / discountable)) if discountable else 1
            // reward_dict = {}
            // for tax, price in discountable_per_tax.items():
            //     if not price:
            //         continue
            //     mapped_taxes = self.fiscal_position_id.map_tax(tax)
            //     tax_desc = ''
            //     if len(discountable_per_tax) > 1 and any(t.name for t in mapped_taxes):
            //         tax_desc = _(
            //             " - On products with the following taxes: %(taxes)s",
            //             taxes=", ".join(mapped_taxes.mapped('name')),
            //         )
            //     reward_dict[tax] = {
            //         **base_reward_line_values,
            //         'name': _(
            //             "Discount %(desc)s%(tax_str)s",
            //             desc=reward.description,
            //             tax_str=tax_desc,
            //         ) if mapped_taxes else reward.description,
            //         'price_unit': -(price * discount_factor),
            //         'points_cost': 0,
            //         'tax_ids': [Command.clear()] + [Command.link(tax.id) for tax in mapped_taxes]
            //     }
            // # We only assign the point cost to one line to avoid counting the cost multiple times
            // if reward_dict:
            //     reward_dict[next(iter(reward_dict))]['points_cost'] = point_cost
            // # Returning .values() directly does not return a subscribable list
            // return list(reward_dict.values())
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesFreeShippingInternalAsync(object reward, object coupon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py) ---
            // def _get_reward_values_free_shipping(self, reward, coupon, **kwargs):
            // delivery_line = self.order_line.filtered(lambda l: l.is_delivery)[:1]
            // taxes = delivery_line.product_id.taxes_id._filter_taxes_by_company(self.company_id)
            // taxes = self.fiscal_position_id.map_tax(taxes)
            // max_discount = reward.discount_max_amount or float('inf')
            // return [{
            //     'name': _('Free Shipping - %s', reward.description),
            //     'reward_id': reward.id,
            //     'coupon_id': coupon.id,
            //     'points_cost': reward.required_points if not reward.clear_wallet else self._get_real_points_for_coupon(coupon),
            //     'product_id': reward.discount_line_product_id.id,
            //     'price_unit': -min(max_discount, delivery_line.price_unit or 0),
            //     'product_uom_qty': 1,
            //     'order_id': self.id,
            //     'is_reward_line': True,
            //     'sequence': max(self.order_line.filtered(lambda x: not x.is_reward_line).mapped('sequence'), default=0) + 1,
            //     'tax_ids': [Command.clear()] + [Command.link(tax.id) for tax in taxes],
            // }]
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesProductInternalAsync(object reward, object coupon, object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_reward_values_product(self, reward, coupon, product=None, **kwargs):
            // """
            // Returns an array of dict containing the values required for the reward lines
            // """
            // self.ensure_one()
            // assert reward.reward_type == 'product'
            // 
            // reward_products = reward.reward_product_ids
            // product = product or reward_products[:1]
            // if not product or product not in reward_products:
            //     raise UserError(_("Invalid product to claim."))
            // taxes = self.fiscal_position_id.map_tax(product.taxes_id._filter_taxes_by_company(self.company_id))
            // points = self._get_real_points_for_coupon(coupon)
            // claimable_count = float_round(points / reward.required_points, precision_rounding=1, rounding_method='DOWN') if not reward.clear_wallet else 1
            // cost = points if reward.clear_wallet else claimable_count * reward.required_points
            // return [{
            //     'name': reward.description,
            //     'product_id': product.id,
            //     'discount': 100,
            //     'product_uom_qty': reward.reward_product_qty * claimable_count,
            //     'reward_id': reward.id,
            //     'coupon_id': coupon.id,
            //     'points_cost': cost,
            //     'reward_identifier_code': _generate_random_reward_code(),
            //     'sequence': max(self.order_line.filtered(lambda x: not x.is_reward_line).mapped('sequence'), default=10) + 1,
            //     'tax_ids': [Command.clear()] + [Command.link(tax.id) for tax in taxes],
            // }]
            */
            return default;
        }

        protected async Task<SaleOrder> GetShopWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _get_shop_warehouse_id(self):
            // """Override of `website_sale_stock` to consider the chosen warehouse."""
            // self.ensure_one()
            // if self.carrier_id.delivery_type == 'in_store':
            //     return self.warehouse_id.id
            // return super()._get_shop_warehouse_id()
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _get_shop_warehouse_id(self):
            // """Return the warehouse to use for shop availability checks.
            // 
            // If no warehouse is specified on the website, all warehouses are considered,
            // regardless of the warehouse automatically assigned to the order.
            // 
            // Note: self.ensure_one()
            // 
            // :returns: `stock.warehouse` id
            // :rtype: int or False
            // """
            // self.ensure_one()
            // return self.website_id.warehouse_id.id
            */
            return default;
        }

        protected async Task<SaleOrder> GetShopWarningInternalAsync(object clear)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _get_shop_warning(self, clear=True):
            // self.ensure_one()
            // warn = self.shop_warning
            // if clear:
            //     self.shop_warning = ''
            // return warn
            */
            return default;
        }

        protected async Task<SaleOrder> GetSpecificDiscountableLinesInternalAsync(object reward)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_specific_discountable_lines(self, reward):
            // """
            // Returns all lines to which `reward` can apply
            // """
            // self.ensure_one()
            // assert reward.discount_applicability == 'specific'
            // 
            // discountable_lines = self.env['sale.order.line']
            // for line in (self.order_line - self._get_no_effect_on_threshold_lines()):
            //     domain = reward._get_discount_product_domain()
            //     if (
            //         not line.reward_id
            //         and not line.combo_item_id
            //         and line.product_id.filtered_domain(domain)
            //     ):
            //         discountable_lines |= line._get_lines_with_price()
            // return discountable_lines
            */
            return default;
        }

        protected async Task<SaleOrder> GetTriggerDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _get_trigger_domain(self):
            // """
            // Returns the base domain that all triggers have to comply to.
            // """
            // self.ensure_one()
            // today = self._get_confirmed_tx_create_date()
            // return [('active', '=', True), ('program_id.sale_ok', '=', True),
            //         *self.env['loyalty.program']._check_company_domain([self.company_id.id, self.company_id.parent_id.id]),
            //         '|', ('program_id.pricelist_ids', '=', False),
            //              ('program_id.pricelist_ids', 'in', [self.pricelist_id.id]),
            //         '|', ('program_id.date_from', '=', False), ('program_id.date_from', '<=', today),
            //         '|', ('program_id.date_to', '=', False), ('program_id.date_to', '>=', today)]
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _get_trigger_domain(self):
            // res = super()._get_trigger_domain()
            // # Replace `sale_ok` leaf with `ecommerce_ok` if order is linked to a website
            // if self.website_id:
            //     for idx, leaf in enumerate(res):
            //         if leaf[0] != 'program_id.sale_ok':
            //             continue
            //         res[idx] = ('program_id.ecommerce_ok', '=', True)
            //         return Domain.AND([res, [('program_id.website_id', 'in', (self.website_id.id, False))]])
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> GetUnavailableQuantityFromKitsInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_mrp, FILE: sale_order.py) ---
            // def _get_unavailable_quantity_from_kits(self, product):
            // """
            // If any line of the order refers to a kit product, the availability of the product
            // might be impacted (if the product is a kit or a component of one).
            // 
            // This method computes the quantity that becomes unavailable for the product because
            // of the order lines that do not refer to it directly.
            // 
            // :param ProductProduct product: the product for which the unavailability is computed.
            // """
            // self.ensure_one()
            // unavailable_qty = 0
            // if product.is_kits:
            //     # Explode the kit to fetch the set of relevant components to track.
            //     kit_bom = self.env['mrp.bom'].sudo()._bom_find(product, company_id=self.company_id.id, bom_type='phantom')[product]
            //     _, bom_sub_lines = kit_bom.explode(product, quantity=1.0)
            //     unavailable_component_qties = {}
            //     qty_per_kit = defaultdict(float)
            //     for bom_line, bom_line_data in bom_sub_lines:
            //         if not bom_line.product_id.is_storable:
            //             # Relevant only for storable components.
            //             continue
            //         if float_is_zero(bom_line_data['qty'], precision_rounding=bom_line.product_uom_id.rounding):
            //             # As BoMs allow components with a quantity of 0 (i.e., optional components), we
            //             # skip those to avoid a division by zero.
            //             continue
            //         component = bom_line.product_id
            //         unavailable_component_qties[component] = sum(self.order_line.filtered(lambda sol: sol.product_id == component).mapped('product_uom_qty'))
            //         uom_qty_per_kit = bom_line_data['qty'] / bom_line_data['original_qty']
            //         qty_per_kit[component] += bom_line.product_uom_id._compute_quantity(uom_qty_per_kit / kit_bom.product_qty, component.uom_id, round=False)
            // 
            // for line in self.order_line:
            //     if not line.product_id.is_kits or line.product_id == product:
            //         continue
            //     # Other kit lines might influence the availability of the product.
            //     line_kit_bom = self.env['mrp.bom'].sudo()._bom_find(line.product_id, company_id=self.company_id.id, bom_type='phantom')[line.product_id]
            //     component_qties = line._get_bom_component_qty(line_kit_bom)
            //     unavailable_qty += component_qties.get(product.id, {}).get('qty', 0) * line.product_uom_qty / line_kit_bom.product_qty
            //     if product.is_kits:
            //         # If the product is a kit, the availability of its components can be influenced by other kits.
            //         for component, _ in unavailable_component_qties.items():
            //             unavailable_component_qties[component] += component_qties.get(component.id, {}).get('qty', 0) * line.product_uom_qty / line_kit_bom.product_qty
            // 
            // if product.is_kits:
            //     # If the product is a kit, recompute availability based on the availability of its components.
            //     max_free_kit_qty = free_qty = product.sudo().free_qty
            //     for component, unavailable_component_qty in unavailable_component_qties.items():
            //         max_free_kit_qty = min(max_free_kit_qty, (component.free_qty - unavailable_component_qty) // qty_per_kit[component])
            //     unavailable_qty += free_qty - max_free_kit_qty
            // return unavailable_qty
            */
            return default;
        }

        public async Task<SaleOrder> GetUpdateIncludedPdfParamsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py) ---
            // def get_update_included_pdf_params(self):
            // if not self:
            //     return {
            //         'headers': {},
            //         'files': {},
            //         'footers': {},
            //     }
            // self.ensure_one()
            // existing_mapping = (
            //     self.customizable_pdf_form_fields
            //     and json.loads(self.customizable_pdf_form_fields)
            // ) or {}
            // 
            // available_docs = self.available_quotation_document_ids | self.quotation_document_ids
            // headers_available = available_docs.filtered(
            //     lambda doc: doc.document_type == 'header'
            // )
            // footers_available = available_docs.filtered(
            //     lambda doc: doc.document_type == 'footer'
            // )
            // selected_documents = self.quotation_document_ids
            // selected_headers = selected_documents.filtered(lambda doc: doc.document_type == 'header')
            // selected_footers = selected_documents - selected_headers
            // lines_params = []
            // for line in self.order_line:
            //     if line.available_product_document_ids:
            //         lines_params.append({
            //             'name': _("Product") + " > " + line.name.splitlines()[0],
            //             'id': line.id,
            //             'files': [{
            //                 'name': doc.name.rstrip('.pdf'),
            //                 'id': doc.id,
            //                 'is_selected': doc in line.sudo().product_document_ids, # User should be
            //                 # able to access all product documents even without sales access
            //                 'custom_form_fields': [{
            //                     'name': custom_form_field.name,
            //                     'value': existing_mapping.get('line', {}).get(str(line.id), {}).get(
            //                         str(doc.id), {}
            //                     ).get('custom_form_fields', {}).get(custom_form_field.name, ""),
            //                 } for custom_form_field in doc.form_field_ids.filtered(
            //                     lambda ff: not ff.path
            //                 )],
            //             } for doc in line.available_product_document_ids]
            //         })
            // dialog_params = {
            //     'headers': {'name': _("Header"), 'files': [{
            //         'id': header.id,
            //         'name': header.name,
            //         'is_selected': header in selected_headers,
            //         'custom_form_fields': [{
            //             'name': custom_form_field.name,
            //             'value': existing_mapping.get('header', {}).get(str(header.id), {}).get(
            //                 'custom_form_fields', {}
            //             ).get(custom_form_field.name, ""),
            //         } for custom_form_field in header.form_field_ids.filtered(lambda ff: not ff.path)],
            //     } for header in headers_available]},
            //     'lines': lines_params,
            //     'footers': {'name': _("Footer"), 'files': [{
            //         'id': footer.id,
            //         'name': footer.name,
            //         'is_selected': footer in selected_footers,
            //         'custom_form_fields': [{
            //             'name': custom_form_field.name,
            //             'value': existing_mapping.get('footer', {}).get(str(footer.id), {}).get(
            //                 'custom_form_fields', {}
            //             ).get(custom_form_field.name, ""),
            //         } for custom_form_field in footer.form_field_ids.filtered(lambda ff: not ff.path)],
            //     } for footer in footers_available]},
            // }
            // return dialog_params
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> GetUpdatePricesLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _get_update_prices_lines(self):
            // """ Exclude delivery lines from price list recomputation based on product instead of carrier """
            // lines = super()._get_update_prices_lines()
            // return lines.filtered(lambda line: not line.is_delivery)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_update_prices_lines(self):
            // """ Hook to exclude specific lines which should not be updated based on price list recomputation """
            // return self.order_line.filtered(lambda line: not line.display_type)
            */
            return default;
        }

        protected async Task<SaleOrder> HasDeliverableProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _has_deliverable_products(self):
            // """ Return whether the order has lines with products that should be delivered.
            // 
            // :return: Whether the order has deliverable products.
            // :rtype: bool
            // """
            // return bool(self.order_line.product_id) and not self.only_services
            */
            return default;
        }

        protected async Task<SaleOrder> HasToBePaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _has_to_be_paid(self):
            // """A sale order has to be paid when:
            // - its state is 'draft' or `sent`;
            // - it's not expired;
            // - it requires a payment;
            // - the last transaction's state isn't `done`;
            // - the total amount is strictly positive.
            // - confirmation amount is not reached
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether the sale order has to be paid.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (
            //     self.state in ['draft', 'sent']
            //     and not self.is_expired
            //     and self.require_payment
            //     and self.amount_total > 0
            //     and not self._is_confirmation_amount_reached()
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> HasToBeSignedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _has_to_be_signed(self):
            // """A sale order has to be signed when:
            // - its state is 'draft' or `sent`
            // - it's not expired;
            // - it requires a signature;
            // - it's not already signed.
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether the sale order has to be signed.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (
            //     self.state in ['draft', 'sent']
            //     and not self.is_expired
            //     and self.require_signature
            //     and not self.signature
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> InitColumnInternalAsync(object column_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _init_column(self, column_name):
            // """ Ensure the default warehouse_id is correctly assigned
            // 
            // At column initialization, the ir.model.fields for res.users.property_warehouse_id isn't created,
            // which means trying to read the property field to get the default value will crash.
            // We therefore enforce the default here, without going through
            // the default function on the warehouse_id field.
            // """
            // if column_name != "warehouse_id":
            //     return super(SaleOrder, self)._init_column(column_name)
            // 
            // default_warehouse = self.env["stock.warehouse"].search([], limit=1)
            // 
            // query = """
            // UPDATE sale_order so
            // SET warehouse_id = COALESCE(wh.id, %s)
            // FROM stock_warehouse wh
            // WHERE so.company_id = wh.company_id and so.warehouse_id IS NULL and wh.active
            // """
            // params = [default_warehouse.id]
            // 
            // _logger.debug("Initializing column '%s' in table '%s'", column_name, self._table)
            // self.env.cr.execute(query, params)
            */
            return default;
        }

        protected async Task<SaleOrder> IsAnonymousCartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _is_anonymous_cart(self):
            // """ Return whether the cart was created by the public user and no address was added yet.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: Whether the cart is anonymous.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.partner_id.id == request.website.user_id.sudo().partner_id.id
            */
            return default;
        }

        protected async Task<SaleOrder> IsCartReadyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _is_cart_ready(self):
            // """ Whether the cart is valid and can be confirmed (and paid for)
            // 
            // :rtype: bool
            // """
            // return bool(self)
            */
            return default;
        }

        protected async Task<SaleOrder> IsConfirmationAmountReachedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_confirmation_amount_reached(self):
            // """ Return whether `self.amount_paid` is higher than the prepayment required amount.
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether `self.amount_paid` is higher than the prepayment required amount.
            // :rtype: bool
            // """
            // self.ensure_one()
            // amount_comparison = self.currency_id.compare_amounts(
            //     self._get_prepayment_required_amount(), self.amount_paid,
            // )
            // return amount_comparison <= 0
            */
            return default;
        }

        protected async Task<SaleOrder> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _is_display_stock_in_catalog(self):
            // return True
            */
            return default;
        }

        protected async Task<SaleOrder> IsInStockInternalAsync(Guid wh_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _is_in_stock(self, wh_id):
            // """ Check whether all storable products of the cart are in stock in the given warehouse.
            // 
            // :param int wh_id: The warehouse in which to check the stock, as a `stock.warehouse` id.
            // :return: Whether all storable products are in stock.
            // :rtype: bool
            // """
            // return not self._get_insufficient_stock_data(wh_id)
            */
            return default;
        }

        protected async Task<SaleOrder> IsPaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_paid(self):
            // """ Return whether the sale order is paid or not based on the linked transactions.
            // 
            // A sale order is considered paid if the sum of all the linked transaction is equal to or
            // higher than `self.amount_total`.
            // 
            // :return: Whether the sale order is paid or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.currency_id.compare_amounts(self.amount_paid, self.amount_total) >= 0
            */
            return default;
        }

        protected async Task<SaleOrder> IsReadonlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_readonly(self):
            // """ Return Whether the sale order is read-only or not based on the state or the lock status.
            // 
            // A sale order is considered read-only if its state is 'cancel' or if the sale order is
            // locked.
            // 
            // :return: Whether the sale order is read-only or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.state == 'cancel' or self.locked
            */
            return default;
        }

        protected async Task<SaleOrder> IsReorderAllowedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _is_reorder_allowed(self):
            // self.ensure_one()
            // return self.state == 'sale' and any(
            //     line._is_reorder_allowed() for line in self.order_line if line.product_id
            // )
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [['pos_order_line_ids.order_id.state', '=', 'draft']]
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['name', 'state', 'user_id', 'order_line', 'partner_id', 'pricelist_id', 'fiscal_position_id', 'amount_total', 'amount_untaxed', 'amount_unpaid',
            //     'picking_ids', 'partner_shipping_id', 'partner_invoice_id', 'date_order', 'write_date', 'amount_paid']
            */
            return default;
        }

        public async Task<SaleOrder> LoadSaleOrderFromPosAsync(SaleOrderLoadSaleOrderFromPosRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def load_sale_order_from_pos(self, config_id):
            // product_ids = self.order_line.product_id.ids
            // product_tmpls = self.env['product.template'].load_product_from_pos(
            //     config_id,
            //     [('product_variant_ids.id', 'in', product_ids)]
            // )
            // sale_order_fields = self._load_pos_data_fields(config_id)
            // sale_order_read = self.read(sale_order_fields, load=False)
            // sale_order_line_fields = self.order_line._load_pos_data_fields(config_id)
            // sale_order_line_read = self.order_line.read(sale_order_line_fields, load=False)
            // sale_order_fp_fields = self.env['account.fiscal.position']._load_pos_data_fields(config_id)
            // sale_order_fp_read = self.fiscal_position_id.read(sale_order_fp_fields, load=False)
            // partner_fields = self.env['res.partner']._load_pos_data_fields(config_id)
            // 
            // return {
            //     'sale.order': sale_order_read,
            //     'sale.order.line': sale_order_line_read,
            //     'account.fiscal.position': sale_order_fp_read,
            //     'res.partner': self.partner_id.read(partner_fields, load=False),
            //     **product_tmpls,
            // }
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> LockAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_lock(self):
            // self.locked = True
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> LogDecreaseOrderedQuantityInternalAsync(object documents, object cancel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _log_decrease_ordered_quantity(self, documents, cancel=False):
            // 
            // def _render_note_exception_quantity_so(rendering_context):
            //     order_exceptions, visited_moves = rendering_context
            //     visited_moves = list(visited_moves)
            //     visited_moves = self.env[visited_moves[0]._name].concat(*visited_moves)
            //     order_line_ids = self.env['sale.order.line'].browse([order_line.id for order in order_exceptions.values() for order_line in order[0]])
            //     sale_order_ids = order_line_ids.mapped('order_id')
            //     impacted_pickings = visited_moves.filtered(lambda m: m.state not in ('done', 'cancel')).mapped('picking_id')
            //     values = {
            //         'sale_order_ids': sale_order_ids,
            //         'order_exceptions': order_exceptions.values(),
            //         'impacted_pickings': impacted_pickings,
            //         'cancel': cancel
            //     }
            //     return self.env['ir.qweb']._render('sale_stock.exception_on_so', values)
            // 
            // self.env['stock.picking']._log_activity(_render_note_exception_quantity_so, documents)
            */
            return default;
        }

        protected async Task<SaleOrder> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: sale_order.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // """ Exclude by default canceled orders when performing a mass mailing. """
            // return [('state', '!=', 'cancel')]
            */
            return default;
        }

        protected async Task<SaleOrder> MessageMailAfterHookInternalAsync(object mails)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _message_mail_after_hook(self, mails):
            // # After sending recovery cart emails, update orders to avoid sending it again
            // if self.env.context.get('website_sale_send_recovery_email'):
            //     self.filtered_domain([
            //         ('cart_recovery_email_sent', '=', False),
            //         ('is_abandoned_cart', '=', True)
            //     ]).cart_recovery_email_sent = True
            // return super()._message_mail_after_hook(mails)
            */
            return default;
        }

        protected async Task<SaleOrder> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // # After sending recovery cart emails, update orders to avoid sending it again
            // if self.env.context.get('website_sale_send_recovery_email'):
            //     self.cart_recovery_email_sent = True
            // return super()._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<SaleOrder> MessagePostAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_so_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').with_context(tracking_disable=True).write({'state': 'sent'})
            //     kwargs['notify_author_mention'] = kwargs.get('notify_author_mention', True)
            // return super().message_post(**kwargs)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> NeedsCustomerAddressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _needs_customer_address(self):
            // """Return whether we need the address details of the customer (country, street, ...).
            // 
            // If an order only has services, unless the customer wants an invoice, their checkout can
            // be sped up by allowing them to only provide their name, email and phone numbers.
            // """
            // return not self.only_services
            */
            return default;
        }

        protected async Task<SaleOrder> NothingToInvoiceErrorMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _nothing_to_invoice_error_message(self):
            // return _(
            //     "Cannot create an invoice. No items are available to invoice.\n\n"
            //     "To resolve this issue, please ensure that:\n"
            //     "   \u2022 The products have been delivered before attempting to invoice them.\n"
            //     "   \u2022 The invoicing policy of the product is configured correctly.\n\n"
            //     "If you want to invoice based on ordered quantities instead:\n"
            //     "   \u2022 For consumable or storable products, open the product, go to the 'General Information' tab and change the 'Invoicing Policy' from 'Delivered Quantities' to 'Ordered Quantities'.\n"
            //     "   \u2022 For services (and other products), change the 'Invoicing Policy' to 'Prepaid/Fixed Price'.\n"
            // )
            */
            return default;
        }

        protected async Task<SaleOrder> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // lang_code = render_context.get('lang')
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id.name else record.name]
            // if self.amount_total:
            //     # Do not show the price in subtitles if zero (e.g. e-commerce orders are created empty)
            //     subtitles.append(
            //         format_amount(self.env, self.amount_total, self.currency_id, lang_code=lang_code),
            //     )
            // 
            // render_context['subtitles'] = subtitles
            // return render_context
            */
            return default;
        }

        protected async Task<SaleOrder> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # Give access button to users and portal customer as portal is integrated
            // # in sale. Customer and portal group have probably no right to see
            // # the document so they don't have the access button.
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.env.context.get('proforma'):
            //     for group in [g for g in groups if g[0] in ('portal_customer', 'portal', 'follower', 'customer')]:
            //         group[2]['has_button_access'] = False
            //     return groups
            // local_msg_vals = dict(msg_vals or {})
            // 
            // # portal customers have full access (existence not granted, depending on partner_id)
            // try:
            //     customer_portal_group = next(group for group in groups if group[0] == 'portal_customer')
            // except StopIteration:
            //     pass
            // else:
            //     access_opt = customer_portal_group[2].setdefault('button_access', {})
            //     is_tx_pending = self.get_portal_last_transaction().state == 'pending'
            //     if self._has_to_be_signed():
            //         if self._has_to_be_paid():
            //             access_opt['title'] = _("View Quotation") if is_tx_pending else _("Sign & Pay Quotation")
            //         else:
            //             access_opt['title'] = _("Accept & Sign Quotation")
            //     elif self._has_to_be_paid() and not is_tx_pending:
            //         access_opt['title'] = _("Accept & Pay Quotation")
            //     elif self.state in ('draft', 'sent'):
            //         access_opt['title'] = _("View Quotation")
            // 
            // return groups
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # In case of cart recovery email, update link to redirect directly
            // # to the cart (like ``mail_template_sale_cart_recovery`` template).
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // customer_portal_group = next((group for group in groups if group[0] == 'portal_customer'), None)
            // if customer_portal_group:
            //     access_opt = customer_portal_group[2].setdefault('button_access', {})
            //     if self.env.context.get('website_sale_send_recovery_email'):
            //         access_opt['title'] = _('Resume Order')
            //         access_opt['url'] = f'{self.get_base_url()}/shop/cart?id={self.id}&access_token={self.access_token}'
            // return groups
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCommitmentDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_commitment_date(self):
            // """ Warn if the commitment dates is sooner than the expected date """
            // if self.commitment_date and self.expected_date and self.commitment_date < self.expected_date:
            //     return {
            //         'warning': {
            //             'title': _('Requested date is too soon.'),
            //             'message': _("The delivery date is sooner than the expected date."
            //                          " You may be unable to honor the delivery date.")
            //         }
            //     }
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_company_id(self):
            // for order in self:
            //     # This can't be caught by a python constraint as it is only triggered at save
            //     # and a compute methodd needs this data to be set correctly before saving
            //     if not order.company_id:
            //         raise ValidationError(_("The company is required, please select one before making any other changes to the sale order."))
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _onchange_company_id(self):
            // """Trigger quotation template recomputation on unsaved records company change"""
            // super()._onchange_company_id()
            // if self._origin.id:
            //     return
            // self._compute_sale_order_template_id()
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCompanyIdWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_company_id_warning(self):
            // self.show_update_pricelist = True
            // if self.env.context.get('sale_onchange_first_call'):
            //     return
            // if self.order_line and self.state == 'draft':
            //     return {
            //         'warning': {
            //             'title': _("Warning for the change of your quotation's company"),
            //             'message': _("Changing the company of an existing quotation might need some "
            //                          "manual adjustments in the details of the lines. You might "
            //                          "consider updating the prices."),
            //         }
            //     }
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeFposIdShowUpdateFposInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_fpos_id_show_update_fpos(self):
            // if self.order_line and (
            //     not self.fiscal_position_id
            //     or (self.fiscal_position_id and self._origin.fiscal_position_id != self.fiscal_position_id)
            // ):
            //     self.show_update_fpos = True
            */
            return default;
        }

        public async Task<SaleOrder> OnchangeOrderLineAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def onchange_order_line(self):
            // self.ensure_one()
            // delivery_line = self.order_line.filtered('is_delivery')
            // if delivery_line:
            //     self.recompute_delivery_price = True
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> OnchangeOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_order_line(self):
            // for index, line in enumerate(self.order_line):
            //     combo_item_lines = line._get_linked_lines().filtered('combo_item_id')
            //     if line.product_template_id.type != 'combo':
            //         if combo_item_lines:
            //             # Delete any linked combo item lines if the line's product is no longer a combo
            //             # product.
            //             self.order_line = [
            //                 Command.delete(linked_line.id) for linked_line in combo_item_lines
            //             ]
            //     elif line.selected_combo_items:
            //         selected_combo_items = json.loads(line.selected_combo_items)
            //         if (
            //             selected_combo_items
            //             and len(selected_combo_items) != len(line.product_template_id.sudo().combo_ids)
            //         ):
            //             raise ValidationError(_(
            //                 "The number of selected combo items must match the number of available"
            //                 " combo choices."
            //             ))
            // 
            //         # Delete any existing combo item lines.
            //         delete_commands = [Command.delete(linked_line.id) for linked_line in combo_item_lines]
            //         # Create a new combo item line for each selected combo item.
            //         create_commands = [Command.create({
            //             'product_id': combo_item['product_id'],
            //             'product_uom_qty': line.product_uom_qty,
            //             'combo_item_id': combo_item['combo_item_id'],
            //             'product_no_variant_attribute_value_ids': [
            //                 Command.set(combo_item['no_variant_attribute_value_ids'])
            //             ],
            //             'product_custom_attribute_value_ids': [Command.clear()] + [
            //                 Command.create(attribute_value)
            //                 for attribute_value in combo_item['product_custom_attribute_values']
            //             ],
            //             # Combo item lines should come directly after their combo product line.
            //             'sequence': line.sequence + item_index + 1,
            //             # If the linked line exists in DB, populate linked_line_id, otherwise populate
            //             # linked_virtual_id.
            //             'linked_line_id': line.id if line._origin else False,
            //             'linked_virtual_id': line.virtual_id if not line._origin else False,
            //         }) for item_index, combo_item in enumerate(selected_combo_items)]
            //         # Shift any lines coming after the combo product line so that the combo item lines
            //         # come first.
            //         update_commands = [Command.update(
            //             order_line.id,
            //             {'sequence': order_line.sequence + len(selected_combo_items)},
            //         ) for order_line in self.order_line if order_line.sequence > line.sequence]
            // 
            //         # Clear `selected_combo_items` to avoid applying the same changes multiple times.
            //         line.selected_combo_items = False
            //         self.order_line = delete_commands + create_commands + update_commands
            //     elif (
            //         combo_item_lines
            //         # Only update the combo item lines if the line's combo choices haven't changed.
            //         and combo_item_lines.combo_item_id.combo_id == line.product_template_id.combo_ids
            //     ):
            //         combo_item_lines.update({
            //             'product_uom_qty': line.product_uom_qty,
            //             'discount': line.discount,
            //         })
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _onchange_partner_id(self):
            // """Reload template for unsaved orders with unmodified lines & orders."""
            // if self._origin or not self.sale_order_template_id:
            //     return
            // 
            // def line_eqv(line, t_line):
            //     return line and t_line and all(
            //         line[fname] == t_line[fname]
            //         for fname in ['product_id', 'product_uom_id', 'product_uom_qty', 'display_type']
            //     )
            // 
            // lines = self.order_line
            // t_lines = self.sale_order_template_id.sale_order_template_line_ids
            // 
            // if all(starmap(line_eqv, zip_longest(lines, t_lines))):
            //     self._onchange_sale_order_template_id()
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePartnerShippingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _onchange_partner_shipping_id(self):
            // res = {}
            // pickings = self.picking_ids.filtered(
            //     lambda p: p.state not in ['done', 'cancel'] and p.partner_id != self.partner_shipping_id
            // )
            // if pickings:
            //     res['warning'] = {
            //         'title': _('Warning!'),
            //         'message': _(
            //             'Do not forget to change the partner on the following delivery orders: %s',
            //             ','.join(pickings.mapped('name')))
            //     }
            // return res
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePrepaymentPercentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_prepayment_percent(self):
            // if not self.prepayment_percent:
            //     self.require_payment = False
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePricelistIdShowUpdatePricesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_pricelist_id_show_update_prices(self):
            // self.show_update_pricelist = bool(self.order_line)
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeSaleOrderTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py) ---
            // def _onchange_sale_order_template_id(self):
            // if not self.sale_order_template_id:
            //     return
            // 
            // sale_order_template = self.sale_order_template_id.with_context(lang=self.partner_id.lang)
            // 
            // order_lines_data = [fields.Command.clear()]
            // order_lines_data += [
            //     fields.Command.create(line._prepare_order_line_values())
            //     for line in sale_order_template.sale_order_template_line_ids
            // ]
            // 
            // # set first line to sequence -99, so a resequence on first page doesn't cause following page
            // # lines (that all have sequence 10 by default) to get mixed in the first page
            // if len(order_lines_data) >= 2:
            //     order_lines_data[1][2]['sequence'] = -99
            // 
            // self.order_line = order_lines_data
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py) ---
            // def _onchange_sale_order_template_id(self):
            // super()._onchange_sale_order_template_id()
            // 
            // # Remove documents which are no longer available.
            // self.quotation_document_ids &= self.available_quotation_document_ids
            // 
            // if not self.sale_order_template_id.quotation_document_ids:
            //     return
            // self.quotation_document_ids |= self.sale_order_template_id.quotation_document_ids.filtered(
            //     lambda doc: doc.company_id.id in [False, self.company_id.id] and doc.add_by_default
            // )
            */
            return default;
        }

        public async Task<SaleOrder> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_open_business_doc(self):
            // self.ensure_one()
            // return {
            //     'name': _("Order"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order',
            //     'res_id': self.id,
            //     'views': [(False, 'form')],
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenDeliveryWizardAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def action_open_delivery_wizard(self):
            // view_id = self.env.ref('delivery.choose_delivery_carrier_view_form').id
            // if self.env.context.get('carrier_recompute'):
            //     name = _('Update shipping cost')
            // else:
            //     name = _('Add a shipping method')
            // return {
            //     'name': name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'choose.delivery.carrier',
            //     'view_id': view_id,
            //     'views': [(view_id, 'form')],
            //     'target': 'new',
            //     'context': {
            //         'default_order_id': self.id,
            //         'default_carrier_id': self.carrier_id,
            //         'default_total_weight': self._get_estimated_weight()
            //     }
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def action_open_delivery_wizard(self):
            // """ Override of `delivery` to set a Gelato delivery method by default in the wizard. """
            // res = super().action_open_delivery_wizard()
            // 
            // if (
            //     not self.env.context.get('carrier_recompute')
            //     and any(line.product_id.gelato_product_uid for line in self.order_line)
            // ):
            //     gelato_delivery_method = self.env['delivery.carrier'].search(
            //         [('delivery_type', '=', 'gelato')], limit=1
            //     )
            //     res['context']['default_carrier_id'] = gelato_delivery_method.id
            // return res
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenDiscountWizardAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_open_discount_wizard(self):
            // self.ensure_one()
            // return {
            //     'name': _("Discount"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order.discount',
            //     'view_mode': 'form',
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenRewardWizardAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def action_open_reward_wizard(self):
            // self.ensure_one()
            // self._update_programs_and_rewards()
            // claimable_rewards = self._get_claimable_rewards()
            // if len(claimable_rewards) == 1:
            //     coupon = next(iter(claimable_rewards))
            //     rewards = claimable_rewards[coupon]
            //     if len(rewards) == 1 and not rewards.multi_product:
            //         self._apply_program_reward(claimable_rewards[coupon], coupon)
            //         return True
            // elif not claimable_rewards:
            //     return True
            // return self.env['ir.actions.actions']._for_xml_id('sale_loyalty.sale_loyalty_reward_wizard_action')
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> PaymentCaptureAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_capture(self):
            // """ Capture all transactions linked to this sale order. """
            // self.ensure_one()
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // return self.sudo().transaction_ids.action_capture()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> PaymentVoidAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_void(self):
            // """ Void all transactions linked to this sale order. """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // self.sudo().authorized_transaction_ids.action_void()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _phone_get_number_fields(self):
            // """ No phone or mobile field is available on sale model. Instead SMS will
            // fallback on partner-based computation using ``_mail_get_partner_fields``. """
            // return []
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareAnalyticAccountDataInternalAsync(object prefix)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_analytic_account_data(self, prefix=None):
            // """ Prepare SO analytic account creation values.
            // 
            // :return: `account.analytic.account` creation values
            // :rtype: dict
            // """
            // self.ensure_one()
            // name = self.name
            // if prefix:
            //     name = prefix + ": " + self.name
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return {
            //     'name': name,
            //     'code': self.client_order_ref,
            //     'company_id': self.company_id.id,
            //     'plan_id': project_plan.id,
            //     'partner_id': self.partner_id.id,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareConfirmationValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_confirmation_values(self):
            // """ Prepare the sales order confirmation values.
            // 
            // Note: self can contain multiple records.
            // 
            // :return: Sales Order confirmation values
            // :rtype: dict
            // """
            // return {
            //     'state': 'sale',
            //     'date_order': fields.Datetime.now()
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDeliveryLineValsInternalAsync(object carrier, object price_unit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _prepare_delivery_line_vals(self, carrier, price_unit):
            // context = {}
            // if self.partner_id:
            //     # set delivery detail in the customer language
            //     context['lang'] = self.partner_id.lang
            //     carrier = carrier.with_context(lang=self.partner_id.lang)
            // 
            // # Apply fiscal position
            // taxes = carrier.product_id.taxes_id._filter_taxes_by_company(self.company_id)
            // taxes_ids = taxes.ids
            // if self.partner_id and self.fiscal_position_id:
            //     taxes_ids = self.fiscal_position_id.map_tax(taxes).ids
            // 
            // # Create the sales order line
            // 
            // if carrier.product_id.description_sale:
            //     so_description = '%s: %s' % (carrier.name,
            //                                 carrier.product_id.description_sale)
            // else:
            //     so_description = carrier.name
            // values = {
            //     'order_id': self.id,
            //     'name': so_description,
            //     'price_unit': price_unit,
            //     'product_uom_qty': 1,
            //     'product_id': carrier.product_id.id,
            //     'tax_ids': [(6, 0, taxes_ids)],
            //     'is_delivery': True,
            // }
            // if carrier.free_over and self.currency_id.is_zero(price_unit) :
            //     values['name'] = _('%s\nFree Shipping', values['name'])
            // if self.order_line:
            //     values['sequence'] = self.order_line[-1].sequence + 1
            // del context
            // return values
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentLineSectionValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_line_section_values(self):
            // """ Prepare the values to create a section line for the down payment on the current SO.
            // 
            // :return: A dictionary to create a new SO section line.
            // """
            // self.ensure_one()
            // return {
            //     'order_id': self.id,
            //     'display_type': 'line_section',
            //     'is_downpayment': True,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentLineValuesFromBaseLineInternalAsync(object base_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_line_values_from_base_line(self, base_line):
            // # EXTENDS 'sale'
            // so_line_values = super()._prepare_down_payment_line_values_from_base_line(base_line)
            // if (
            //     base_line
            //     and base_line['record']
            //     and isinstance(base_line['record'], models.Model)
            //     and base_line['record']._name == 'pos.order.line'
            // ):
            //     pos_order_line = base_line['record']
            //     so_line_values['name'] = _(
            //         "Down payment (ref: %(order_reference)s on \n %(date)s)",
            //         order_reference=pos_order_line.name,
            //         date=format_date(pos_order_line.env, pos_order_line.order_id.date_order),
            //     )
            //     so_line_values['pos_order_line_ids'] = [Command.set(pos_order_line.ids)]
            // return so_line_values
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_line_values_from_base_line(self, base_line):
            // """ Convert the base line passed as parameter representing a down payment into a
            // dictionary to be converted into a sale order line in the current sale order.
            // 
            // :param base_line: A base line (see '_prepare_base_line_for_taxes_computation').
            // :return: A dictionary to create a new SO line.
            // """
            // self.ensure_one()
            // extra_tax_data = self.env['account.tax']._export_base_line_extra_tax_data(base_line)
            // return {
            //     'order_id': self.id,
            //     'is_downpayment': True,
            //     'product_uom_qty': 0.0,
            //     'price_unit': base_line['price_unit'],
            //     'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //     'analytic_distribution': base_line['analytic_distribution'],
            //     'extra_tax_data': extra_tax_data,
            // }
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentSectionLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_section_line(self, **optional_values):
            // """ Prepare the values to create a new down payment section.
            // 
            // :param dict optional_values: any parameter that should be added to the returned down payment section
            // :return: `account.move.line` creation values
            // :rtype: dict
            // """
            // self.ensure_one()
            // context = {'lang': self.partner_id.lang}
            // down_payments_section_line = {
            //     'display_type': 'line_section',
            //     'name': _("Down Payments"),
            //     'product_id': False,
            //     'product_uom_id': False,
            //     'quantity': 0,
            //     'discount': 0,
            //     'price_unit': 0,
            //     'account_id': False,
            //     **optional_values
            // }
            // del context
            // return down_payments_section_line
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareInStoreDefaultLocationDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _prepare_in_store_default_location_data(self):
            // """ Prepare the default pickup location values for each in-store delivery method available
            // for the order. """
            // default_pickup_locations = {}
            // for dm in self._get_delivery_methods():
            //     if (
            //         dm.delivery_type == 'in_store'
            //         and dm.id != self.carrier_id.id
            //         and len(dm.warehouse_ids) == 1
            //     ):
            //         pickup_location_data = dm.warehouse_ids[0]._prepare_pickup_location_data()
            //         if pickup_location_data:
            //             default_pickup_locations[dm.id] = {
            //                 'pickup_location_data': pickup_location_data,
            //                 'insufficient_stock_data': self._get_insufficient_stock_data(
            //                     pickup_location_data['id']
            //                 ),
            //             }
            // 
            // return {'default_pickup_locations': default_pickup_locations}
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_invoice(self):
            // """
            // Prepare the dict of values to create the new invoice for a sales order. This method may be
            // overridden to implement custom invoice generation (making sure to call super() to establish
            // a clean extension chain).
            // """
            // self.ensure_one()
            // 
            // txs_to_be_linked = self.sudo().transaction_ids.filtered(
            //     lambda tx: (
            //         tx.state in ('pending', 'authorized')
            //         or (tx.state == 'done' and not tx.payment_id.is_reconciled)
            //     )
            // )
            // 
            // values = {
            //     'ref': self.client_order_ref or self.name,
            //     'move_type': 'out_invoice',
            //     'narration': self.note,
            //     'currency_id': self.currency_id.id,
            //     'campaign_id': self.campaign_id.id,
            //     'medium_id': self.medium_id.id,
            //     'source_id': self.source_id.id,
            //     'team_id': self.team_id.id,
            //     'partner_id': self.partner_invoice_id.id,
            //     'partner_shipping_id': self.partner_shipping_id.id,
            //     'fiscal_position_id': (self.fiscal_position_id or self.fiscal_position_id._get_fiscal_position(self.partner_invoice_id)).id,
            //     'invoice_origin': self.name,
            //     'invoice_payment_term_id': self.payment_term_id.id,
            //     'preferred_payment_method_line_id': self.preferred_payment_method_line_id.id,
            //     'invoice_user_id': self.user_id.id,
            //     'payment_reference': self.reference,
            //     'transaction_ids': [Command.set(txs_to_be_linked.ids)],
            //     'company_id': self.company_id.id,
            //     'invoice_line_ids': [],
            //     'user_id': self.user_id.id,
            // }
            // if self.journal_id:
            //     values['journal_id'] = self.journal_id.id
            // return values
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _prepare_invoice(self):
            // invoice_vals = super(SaleOrder, self)._prepare_invoice()
            // invoice_vals['invoice_incoterm_id'] = self.incoterm.id
            // invoice_vals['delivery_date'] = self.effective_date
            // return invoice_vals
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareOrderLineUpdateValuesInternalAsync(object order_line, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py) ---
            // def _prepare_order_line_update_values(
            //     self, order_line, quantity, *, event_booth_pending_ids=False, registration_values=None,
            //     **kwargs
            // ):
            //     """Delete existing booth registrations and create new ones with the update values."""
            //     values = super()._prepare_order_line_update_values(order_line, quantity, **kwargs)
            // 
            //     if not event_booth_pending_ids:
            //         return values
            // 
            //     booths = self.env['event.booth'].browse(event_booth_pending_ids)
            //     values['event_booth_registration_ids'] = [
            //         Command.delete(registration.id)
            //         for registration in order_line.event_booth_registration_ids
            //     ] + [
            //         Command.create({
            //             'event_booth_id': booth.id,
            //             **registration_values,
            //         }) for booth in booths
            //     ]
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _prepare_order_line_update_values(self, order_line, quantity, **kwargs):
            // self.ensure_one()
            // values = {}
            // 
            // if quantity != order_line.product_uom_qty:
            //     values['product_uom_qty'] = quantity
            // 
            // return values
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareOrderLineValuesInternalAsync(Guid product_id, object quantity, Guid uom_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py) ---
            // def _prepare_order_line_values(
            //     self, *args, event_booth_pending_ids=False, registration_values=None,
            //     **kwargs
            // ):
            //     """Add corresponding event to the SOline creation values (if booths are provided)."""
            //     values = super()._prepare_order_line_values(
            //         *args,
            //         event_booth_pending_ids=event_booth_pending_ids,
            //         registration_values=registration_values,
            //         **kwargs,
            //     )
            // 
            //     if not event_booth_pending_ids:
            //         return values
            // 
            //     booths = self.env['event.booth'].browse(event_booth_pending_ids)
            // 
            //     values['event_id'] = booths.event_id.id
            //     values['event_booth_registration_ids'] = [
            //         Command.create({
            //             'event_booth_id': booth.id,
            //             **registration_values,
            //         }) for booth in booths
            //     ]
            // 
            //     return values
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py) ---
            // def _prepare_order_line_values(self, product_id, *args, event_slot_id=False, event_ticket_id=False, **kwargs):
            // """Add corresponding event to the SOline creation values (if ticket is provided)."""
            // values = super()._prepare_order_line_values(
            //     product_id, *args, event_ticket_id=event_ticket_id, **kwargs,
            // )
            // 
            // if not event_ticket_id:
            //     return values
            // 
            // ticket = self.env['event.event.ticket'].browse(event_ticket_id)
            // 
            // if ticket.product_id.id != product_id:
            //     raise UserError(_("The ticket doesn't match with this product."))
            // 
            // values['event_id'] = ticket.event_id.id
            // values['event_ticket_id'] = ticket.id
            // values['event_slot_id'] = event_slot_id
            // 
            // return values
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _prepare_order_line_values(
            //     self,
            //     product_id,
            //     quantity,
            //     uom_id,
            //     *,
            //     linked_line_id=False,
            //     no_variant_attribute_value_ids=None,
            //     product_custom_attribute_values=None,
            //     combo_item_id=None,
            //     **kwargs
            // ):
            //     self.ensure_one()
            //     product = self.env['product.product'].browse(product_id)
            // 
            //     no_variant_attribute_values = product.env['product.template.attribute.value'].browse(
            //         no_variant_attribute_value_ids
            //     )
            //     received_combination = product.product_template_attribute_value_ids | no_variant_attribute_values
            //     product_template = product.product_tmpl_id
            // 
            //     # handle all cases where incorrect or incomplete data are received
            //     combination = product_template._get_closest_possible_combination(received_combination)
            // 
            //     # get or create (if dynamic) the correct variant
            //     product = product_template._create_product_variant(combination)
            // 
            //     if not product:
            //         raise UserError(_("The given combination does not exist therefore it cannot be added to cart."))
            // 
            //     if linked_line_id and linked_line_id not in self.order_line.ids:
            //         # Make sure the provided parent line belongs to the current order.
            //         raise UserError(_("Invalid request parameters."))
            // 
            //     values = {
            //         'product_id': product.id,
            //         'product_uom_qty': quantity,
            //         'product_uom_id': uom_id or product.uom_id.id,
            //         'order_id': self.id,
            //         'linked_line_id': linked_line_id,
            //         'combo_item_id': combo_item_id,
            //     }
            // 
            //     # add no_variant attributes that were not received
            //     no_variant_attribute_values |= combination.filtered(
            //         lambda ptav: ptav.attribute_id.create_variant == 'no_variant'
            //     )
            // 
            //     if no_variant_attribute_values:
            //         values['product_no_variant_attribute_value_ids'] = [Command.set(no_variant_attribute_values.ids)]
            // 
            //     # add is_custom attribute values that were not received
            //     custom_values = product_custom_attribute_values or []
            //     received_custom_values = product.env['product.template.attribute.value'].browse([
            //         int(ptav['custom_product_template_attribute_value_id'])
            //         for ptav in custom_values
            //     ])
            // 
            //     for ptav in combination.filtered(lambda ptav: ptav.is_custom and ptav not in received_custom_values):
            //         custom_values.append({
            //             'custom_product_template_attribute_value_id': ptav.id,
            //             'custom_value': '',
            //         })
            // 
            //     if custom_values:
            //         values['product_custom_attribute_value_ids'] = [
            //             fields.Command.create({
            //                 'custom_product_template_attribute_value_id': custom_value['custom_product_template_attribute_value_id'],
            //                 'custom_value': custom_value['custom_value'],
            //             }) for custom_value in custom_values
            //         ]
            // 
            //     return values
            */
            return default;
        }

        protected async Task<SaleOrder> PreventMixingGelatoAndNonGelatoProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py) ---
            // def _prevent_mixing_gelato_and_non_gelato_products(self):
            // """ Ensure that the order lines don't mix Gelato and non-Gelato products.
            // 
            // This method is not a constraint and is called from the `create` and `write` methods of
            // `sale.order.line` to cover the cases where adding/writing on order lines would not trigger a
            // constraint check (e.g., adding products through the Catalog).
            // 
            // :return: None
            // :raise ValidationError: If Gelato and non-Gelato products are mixed.
            // """
            // for order in self:
            //     gelato_lines = order.order_line.filtered(lambda l: l.product_id.gelato_product_uid)
            //     non_gelato_lines = (order.order_line - gelato_lines).filtered(
            //         lambda l: l.product_id.sale_ok and l.product_id.type != 'service'
            //     )  # Filter out non-saleable (sections, etc.) and non-deliverable products.
            //     if gelato_lines and non_gelato_lines:
            //         raise ValidationError(
            //             _("You cannot mix Gelato products with non-Gelato products in the same order."))
            */
            return default;
        }

        public async Task<SaleOrder> PreviewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_preview_sale_order(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.get_portal_url(),
            // }
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def action_preview_sale_order(self):
            // action = super().action_preview_sale_order()
            // if action['url'].startswith('/'):
            //     # URL should always be relative, safety check
            //     action['url'] = f'/@{action["url"]}'
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> ProgramCheckComputePointsInternalAsync(object programs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _program_check_compute_points(self, programs):
            // """
            // Checks the program validity from the order lines aswell as computing the number of points to add.
            // 
            // Returns a dict containing the error message or the points that will be given with the keys 'points'.
            // """
            // self.ensure_one()
            // 
            // # Prepare quantities
            // order_lines = self._get_not_rewarded_order_lines().filtered(
            //     lambda line: not line.combo_item_id
            // )
            // products = order_lines.product_id
            // products_qties = dict.fromkeys(products, 0)
            // for line in order_lines:
            //     products_qties[line.product_id] += line.product_uom_qty
            // # Contains the products that can be applied per rule
            // products_per_rule = programs._get_valid_products(products)
            // 
            // # Prepare amounts
            // so_products_per_rule = programs._get_valid_products(self.order_line.product_id)
            // lines_per_rule = defaultdict(lambda: self.env['sale.order.line'])
            // # Skip lines that have no effect on the minimum amount to reach.
            // for line in self.order_line - self._get_no_effect_on_threshold_lines():
            //     is_discount = line.reward_id.reward_type == 'discount'
            //     reward_program = line.reward_id.program_id
            //     # Skip lines for automatic discounts, as well as combo item lines.
            //     if (is_discount and reward_program.trigger == 'auto') or line.combo_item_id:
            //         continue
            //     for program in programs:
            //         # Skip lines for the current program's discounts.
            //         if is_discount and reward_program == program:
            //             continue
            //         for rule in program.rule_ids:
            //             # Skip lines to which the rule doesn't apply.
            //             if line.product_id in so_products_per_rule.get(rule, []):
            //                 lines_per_rule[rule] |= line._get_lines_with_price()
            // 
            // result = {}
            // for program in programs:
            //     # Used for error messages
            //     # By default False, but True if no rules and applies_on current -> misconfigured coupons program
            //     code_matched = not bool(program.rule_ids) and program.applies_on == 'current' # Stays false if all triggers have code and none have been activated
            //     minimum_amount_matched = code_matched
            //     product_qty_matched = code_matched
            //     points = 0
            //     # Some rules may split their points per unit / money spent
            //     #  (i.e. gift cards 2x50$ must result in two 50$ codes)
            //     rule_points = []
            //     program_result = result.setdefault(program, dict())
            //     for rule in program.rule_ids:
            //         # prevent bottomless ewallet spending
            //         if program.program_type == 'ewallet' and not program.trigger_product_ids:
            //             break
            //         if rule.mode == 'with_code' and rule not in self.code_enabled_rule_ids:
            //             continue
            //         code_matched = True
            //         rule_amount = rule._compute_amount(self.currency_id)
            //         untaxed_amount = sum(lines_per_rule[rule].mapped('price_subtotal'))
            //         tax_amount = sum(lines_per_rule[rule].mapped('price_tax'))
            //         if rule_amount > (rule.minimum_amount_tax_mode == 'incl' and (untaxed_amount + tax_amount) or untaxed_amount):
            //             continue
            //         minimum_amount_matched = True
            //         if not products_per_rule.get(rule):
            //             continue
            //         rule_products = products_per_rule[rule]
            //         ordered_rule_products_qty = sum(products_qties[product] for product in rule_products)
            //         if ordered_rule_products_qty < rule.minimum_qty or not rule_products:
            //             continue
            //         product_qty_matched = True
            //         if not rule.reward_point_amount:
            //             continue
            //         # Count all points separately if the order is for the future and the split option is enabled
            //         if program.applies_on == 'future' and rule.reward_point_split and rule.reward_point_mode != 'order':
            //             if rule.reward_point_mode == 'unit':
            //                 rule_points.extend(rule.reward_point_amount for _ in range(int(ordered_rule_products_qty)))
            //             elif rule.reward_point_mode == 'money':
            //                 for line in self.order_line:
            //                     if (
            //                         line.is_reward_line
            //                         or line.combo_item_id
            //                         or line.product_id not in rule_products
            //                         or line.product_uom_qty <= 0
            //                     ):
            //                         continue
            //                     line_price_total = self._get_order_line_price(line, 'price_total')
            //                     points_per_unit = float_round(
            //                         (rule.reward_point_amount * line_price_total / line.product_uom_qty),
            //                         precision_digits=2, rounding_method='DOWN')
            //                     if not points_per_unit:
            //                         continue
            //                     rule_points.extend([points_per_unit] * int(line.product_uom_qty))
            //         else:
            //             # All checks have been passed we can now compute the points to give
            //             if rule.reward_point_mode == 'order':
            //                 points += rule.reward_point_amount
            //             elif rule.reward_point_mode == 'money':
            //                 # Compute amount paid for rule
            //                 # NOTE: this accounts for discounts -> 1 point per $ * (100$ - 30%) will
            //                 # result in 70 points
            //                 amount_paid = 0.0
            //                 rule_products = so_products_per_rule.get(rule, [])
            //                 for line in self.order_line - self._get_no_effect_on_threshold_lines():
            //                     if line.combo_item_id or line.reward_id.program_id.program_type in [
            //                         'ewallet', 'gift_card', program.program_type
            //                     ]:
            //                         continue
            //                     line_price_total = self._get_order_line_price(line, 'price_total')
            //                     amount_paid += (
            //                         line_price_total if line.product_id in rule_products
            //                         else 0.0
            //                     )
            // 
            //                 points += float_round(rule.reward_point_amount * amount_paid, precision_digits=2, rounding_method='DOWN')
            //             elif rule.reward_point_mode == 'unit':
            //                 points += rule.reward_point_amount * ordered_rule_products_qty
            //     # NOTE: for programs that are nominative we always allow the program to be 'applied' on the order
            //     #  with 0 points so that `_get_claimable_rewards` returns the rewards associated with those programs
            //     if not program.is_nominative:
            //         if not code_matched:
            //             program_result['error'] = _("This program requires a code to be applied.")
            //         elif not minimum_amount_matched:
            //             program_result['error'] = _(
            //                 "A minimum of %(amount)s %(currency)s should be purchased to get the reward",
            //                 amount=min(program.rule_ids.mapped('minimum_amount')),
            //                 currency=program.currency_id.name,
            //             )
            //         elif not product_qty_matched:
            //             program_result['error'] = _("You don't have the required product quantities on your sales order.")
            //     elif self.partner_id.is_public and not self._allow_nominative_programs():
            //         program_result['error'] = _("This program is not available for public users.")
            //     if 'error' not in program_result:
            //         points_result = [points] + rule_points
            //         program_result['points'] = points_result
            // return result
            */
            return default;
        }

        public async Task<SaleOrder> QuotationSendAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_quotation_send(self):
            // """ Opens a wizard to compose an email, with relevant mail template loaded by default """
            // self.filtered(lambda so: so.state in ('draft', 'sent')).order_line._validate_analytic_distribution()
            // 
            // ctx = {
            //     'default_model': 'sale.order',
            //     'default_res_ids': self.ids,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': 'mail.mail_notification_layout_with_responsible_signature',
            //     'email_notification_allow_footer': True,
            //     'hide_mail_template_management_options': True,
            //     'proforma': self.env.context.get('proforma', False),
            // }
            // 
            // if len(self) > 1:
            //     ctx['default_composition_mode'] = 'mass_mail'
            // else:
            //     ctx.update({
            //         'force_email': True,
            //     })
            //     if not self.env.context.get('hide_default_template'):
            //         mail_template = self._find_mail_template()
            //         if mail_template:
            //             ctx.update({
            //                 'default_template_id': mail_template.id,
            //                 'mark_so_as_sent': True,
            //             })
            //     else:
            //         for order in self:
            //             order._portal_ensure_token()
            // 
            // action = {
            //     'name': _('Send'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(False, 'form')],
            //     'view_id': False,
            //     'target': 'new',
            //     'context': ctx,
            // }
            // if (
            //     self.env.context.get('check_document_layout')
            //     and not self.env.context.get('discard_logo_check')
            //     and self.env.is_admin()
            //     and not self.env.company.external_report_layout_id
            // ):
            //     layout_action = self.env['ir.actions.report']._action_configure_external_report_layout(
            //         action,
            //     )
            //     # Need to remove this context for windows action
            //     action.pop('close_on_report_download', None)
            //     layout_action['context']['dialog_size'] = 'extra-large'
            //     return layout_action
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> QuotationSentAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_quotation_sent(self):
            // """ Mark the given draft quotation(s) as sent.
            // 
            // :raise: UserError if any given SO is not in draft state.
            // """
            // if any(order.state != 'draft' for order in self):
            //     raise UserError(_("Only draft orders can be marked as sent directly."))
            // 
            // self.write({'state': 'sent'})
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> RecNamesSearchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _rec_names_search(self):
            // if self.env.context.get('sale_show_partner_name'):
            //     return ['name', 'partner_id.name']
            // return ['name']
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputeCartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _recompute_cart(self):
            // """Recompute taxes and prices for the current cart."""
            // self._recompute_taxes()
            // self._recompute_prices()
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _recompute_cart(self):
            // """Recompute cart with loyalty programs and rewards applied."""
            // self._update_programs_and_rewards()
            // self._auto_apply_rewards()
            // super()._recompute_cart()
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputePricesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _recompute_prices(self):
            // lines_to_recompute = self._get_update_prices_lines()
            // lines_to_recompute.invalidate_recordset(['pricelist_item_id'])
            // lines_to_recompute.with_context(force_price_recomputation=True)._compute_price_unit()
            // # Special case: we want to overwrite the existing discount on _recompute_prices call
            // # i.e. to make sure the discount is correctly reset
            // # if pricelist rule is different than when the price was first computed.
            // lines_to_recompute.discount = 0.0
            // lines_to_recompute._compute_discount()
            // self.show_update_pricelist = False
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _recompute_prices(self):
            // """Recompute coupons/promotions after pricelist prices reset."""
            // super()._recompute_prices()
            // for order in self:
            //     if any(line.is_reward_line for line in order.order_line):
            //         order._update_programs_and_rewards()
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputeTaxesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _recompute_taxes(self):
            // lines_to_recompute = self.order_line.filtered(lambda line: not line.display_type)
            // lines_to_recompute._compute_tax_ids()
            // self.show_update_fpos = False
            */
            return default;
        }

        public async Task<SaleOrder> RecoveryEmailSendAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def action_recovery_email_send(self):
            // for order in self:
            //     order._portal_ensure_token()
            // composer_form_view_id = self.env.ref('mail.email_compose_message_wizard_form').id
            // 
            // template_id = self._get_cart_recovery_template().id
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'view_id': composer_form_view_id,
            //     'target': 'new',
            //     'context': {
            //         'default_composition_mode': 'mass_mail' if len(self.ids) > 1 else 'comment',
            //         'default_email_layout_xmlid': 'mail.mail_notification_layout_with_responsible_signature',
            //         'default_res_ids': self.ids,
            //         'default_model': 'sale.order',
            //         'default_template_id': template_id,
            //         'website_sale_send_recovery_email': True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> RemoveDeliveryLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _remove_delivery_line(self):
            // """Remove delivery products from the sales orders"""
            // delivery_lines = self.order_line.filtered("is_delivery")
            // if not delivery_lines:
            //     return
            // to_delete = delivery_lines.filtered(lambda x: x.qty_invoiced == 0)
            // if not to_delete:
            //     raise UserError(
            //         _('You can not update the shipping costs on an order where it was already invoiced!\n\nThe following delivery lines (product, invoiced quantity and price) have already been processed:\n\n')
            //         + '\n'.join(['- %s: %s x %s' % (line.product_id.with_context(display_default_code=False).display_name, line.qty_invoiced, line.price_unit) for line in delivery_lines])
            //     )
            // to_delete.unlink()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _remove_delivery_line(self):
            // super()._remove_delivery_line()
            // self.pickup_location_data = {}
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _remove_delivery_line(self):
            // super()._remove_delivery_line()
            // self._update_programs_and_rewards()
            */
            return default;
        }

        protected async Task<SaleOrder> RemoveProgramFromPointsInternalAsync(object programs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _remove_program_from_points(self, programs):
            // self.coupon_point_ids.filtered(lambda p: p.coupon_id.program_id in programs).sudo().unlink()
            */
            return default;
        }

        protected async Task<SaleOrder> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _remove_reference(self, reference):
            // """ remove the given references from the list of references. """
            // self.ensure_one()
            // self.stock_reference_ids = [Command.unlink(stock_reference.id) for stock_reference in reference]
            */
            return default;
        }

        protected async Task<SaleOrder> ResetHasDisplayedWarningUpsellOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def _reset_has_displayed_warning_upsell_order_lines(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // for line in self.order_line:
            //     if line.has_displayed_warning_upsell and line.product_uom_id and float_compare(line.qty_delivered, line.product_uom_qty, precision_digits=precision) == 0:
            //         line.has_displayed_warning_upsell = False
            */
            return default;
        }

        protected async Task<SaleOrder> SearchAbandonedCartInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _search_abandoned_cart(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // website_ids = self.env['website'].search_read(fields=['id', 'cart_abandoned_delay', 'partner_id'])
            // return Domain.AND((
            //     Domain('state', '=', 'draft'),
            //     Domain('order_line', '!=', False),
            //     Domain.OR(
            //         [
            //             ('website_id', '=', website_id['id']),
            //             ('date_order', '<=', fields.Datetime.to_string(fields.Datetime.now() - relativedelta(hours=website_id['cart_abandoned_delay'] or 1.0))),
            //             ('partner_id', '!=', website_id['partner_id'][0]),
            //         ]
            //         for website_id in website_ids
            //     ),
            // ))
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: sale_order.py) ---
            // def _search_display_name(self, operator, value):
            // """ For expense, we want to show all sales order but only their display_name (no ir.rule applied), this is the only way to do it. """
            // if (
            //     self.env.context.get('sale_expense_all_order')
            //     and self.env.user.has_group('sales_team.group_sale_salesman')
            //     and not self.env.user.has_group('sales_team.group_sale_salesman_all_leads')
            // ):
            //     if operator in Domain.NEGATIVE_OPERATORS:
            //         return NotImplemented
            //     domain = super()._search_display_name(operator, value)
            //     company_domain = Domain('state', '=', 'sale') & ('company_id', 'in', self.env.companies.ids)
            //     query = self.sudo()._search(domain & company_domain)
            //     return Domain('id', 'in', query)
            // return super()._search_display_name(operator, value)
            */
            return default;
        }

        protected async Task<SaleOrder> SearchInvoiceIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _search_invoice_ids(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // if operator == 'in' and value:
            //     falsy_domain = []
            //     if False in value:
            //         # special case for [('invoice_ids', '=', False)], i.e. "Invoices is not set"
            //         #
            //         # We cannot just search [('order_line.invoice_lines', '=', False)]
            //         # because it returns orders with uninvoiced lines, which is not
            //         # same "Invoices is not set" (some lines may have invoices and some
            //         # don't)
            //         #
            //         # A solution is using the 'not any' operators with inverted search first
            //         # ("orders with invoiced lines").
            //         falsy_domain = [('order_line', 'not any', [
            //             ('invoice_lines.move_id.move_type', 'in', ('out_invoice', 'out_refund'))
            //         ])]
            //         if len(value) == 1:
            //             return falsy_domain
            //     self.env.cr.execute("""
            //         SELECT array_agg(so.id)
            //             FROM sale_order so
            //             JOIN sale_order_line sol ON sol.order_id = so.id
            //             JOIN sale_order_line_invoice_rel soli_rel ON soli_rel.order_line_id = sol.id
            //             JOIN account_move_line aml ON aml.id = soli_rel.invoice_line_id
            //             JOIN account_move am ON am.id = aml.move_id
            //         WHERE
            //             am.move_type in ('out_invoice', 'out_refund') AND
            //             am.id = ANY(%s)
            //     """, (list(value),))
            //     so_ids = self.env.cr.fetchone()[0] or []
            //     return [('id', 'in', so_ids)] + falsy_domain
            // return [('order_line.invoice_lines', 'any', [
            //     ('move_id.move_type', 'in', ('out_invoice', 'out_refund')),
            //     ('move_id', operator, value),
            // ])]
            */
            return default;
        }

        protected async Task<SaleOrder> SearchLateAvailabilityInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _search_late_availability(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     return NotImplemented
            // 
            // sub_query = self.env['stock.picking']._search([
            //     ('sale_id', '!=', False), ('products_availability_state', operator, 'late')
            // ])
            // return [('picking_ids', 'in', sub_query)]
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> SearchTasksIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _search_tasks_ids(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // task_domain = [
            //     ('display_name' if isinstance(value, str) else 'id', operator, value),
            //     ('sale_order_id', '!=', False),
            // ]
            // query = self.env['project.task']._search(task_domain)
            // return [('id', 'in', query.subselect('sale_order_id'))]
            */
            return default;
        }

        protected async Task<SaleOrder> SelectExpectedDateInternalAsync(object expected_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _select_expected_date(self, expected_dates):
            // self.ensure_one()
            // return min(expected_dates)
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def _select_expected_date(self, expected_dates):
            // if self.picking_policy == "direct":
            //     return super()._select_expected_date(expected_dates)
            // return max(expected_dates)
            */
            return default;
        }

        protected async Task<SaleOrder> SendOrderConfirmationMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_order_confirmation_mail(self):
            // """ Send a mail to the SO customer to inform them that their order has been confirmed.
            // 
            // :return: None
            // """
            // for order in self:
            //     mail_template = order._get_confirmation_template()
            //     order._send_order_notification_mail(mail_template)
            */
            return default;
        }

        protected async Task<SaleOrder> SendOrderNotificationMailInternalAsync(object mail_template, object allow_deferred_sending)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_order_notification_mail(self, mail_template, allow_deferred_sending=True):
            // """ Send a mail to the customer.
            // 
            // If the `sale.async_emails` ICP is set and `allow_deferred_sending` is true, order status
            // emails are sent asynchronously through a cron.
            // 
            // Note: self.ensure_one()
            // 
            // :param mail.template mail_template: the template used to generate the mail
            // :param bool allow_deferred_sending: Whether the email can be sent asynchronously.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // if not mail_template:
            //     return
            // 
            // if self.env.su:
            //     # sending mail in sudo was meant for it being sent from superuser
            //     self = self.with_user(SUPERUSER_ID)
            // 
            // async_send = str2bool(self.env['ir.config_parameter'].sudo().get_param('sale.async_emails'))
            // cron = self.env.ref('sale.send_pending_emails_cron', raise_if_not_found=False)
            // cron_enabled = cron and cron.sudo().active
            // if async_send and cron_enabled and allow_deferred_sending:
            //     # Schedule the email to be sent asynchronously.
            //     self.pending_email_template_id = mail_template
            //     cron._trigger()
            // else:  # Async emails are disabled, either by the user or we are in the cron job.
            //     # Send the email synchronously.
            //     self.with_context(force_send=True).message_post_with_source(
            //         mail_template,
            //         email_layout_xmlid='mail.mail_notification_layout_with_responsible_signature',
            //         subtype_xmlid='mail.mt_comment',
            //     )
            */
            return default;
        }

        protected async Task<SaleOrder> SendPaymentSucceededForOrderMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_payment_succeeded_for_order_mail(self):
            // """ Send a mail to the SO customer to inform them that a payment has been initiated.
            // 
            // :return: None
            // """
            // mail_template = self.env.ref(
            //     'sale.mail_template_sale_payment_executed', raise_if_not_found=False
            // )
            // for order in self:
            //     order._send_order_notification_mail(mail_template)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _send_payment_succeeded_for_order_mail(self):
            // if carts := self.filtered('website_id'):
            //     # Assign a salesman before sending payment confirmation mail.
            //     carts.with_context(force_user_recomputation=True)._compute_user_id()
            // return super()._send_payment_succeeded_for_order_mail()
            */
            return default;
        }

        protected async Task<SaleOrder> SendRewardCouponMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _send_reward_coupon_mail(self):
            // coupons = self.env['loyalty.card']
            // for order in self:
            //     coupons |= order._get_reward_coupons()
            // if coupons:
            //     coupons._send_creation_communication(force_send=True)
            */
            return default;
        }

        public async Task<SaleOrder> SetDeliveryLineAsync(SaleOrderSetDeliveryLineRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def set_delivery_line(self, carrier, amount):
            // self._remove_delivery_line()
            // for order in self:
            //     order.carrier_id = carrier.id
            //     order._create_delivery_line(carrier, amount)
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py) ---
            // def set_delivery_line(self, carrier, amount):
            // res = super().set_delivery_line(carrier, amount)
            // for order in self:
            //     if order.state != 'sale':
            //         continue
            //     pending_deliveries = order.picking_ids.filtered(
            //         lambda p: p.state not in ('done', 'cancel')
            //                   and not any(m.origin_returned_move_id for m in p.move_ids)
            //     )
            //     pending_deliveries.carrier_id = carrier.id
            // return res
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> SetDeliveryMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _set_delivery_method(self, delivery_method, rate=None):
            // """ Set the delivery method on the order and create a delivery line if the shipment rate can
            //  be retrieved.
            // 
            // :param delivery.carrier delivery_method: The delivery_method to set on the order.
            // :param dict rate: The rate of the delivery method.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // self._remove_delivery_line()
            // if not delivery_method or not self._has_deliverable_products():
            //     return
            // 
            // rate = rate or delivery_method.rate_shipment(self)
            // if rate.get('success'):
            //     self.set_delivery_line(delivery_method, rate['price'])
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _set_delivery_method(self, delivery_method, rate=None):
            // """ Override of `website_sale` to recompute warehouse and fiscal position when a new
            // delivery method is not in-store anymore. """
            // 
            // self.ensure_one()
            // was_in_store_order = (
            //     self.carrier_id.delivery_type == 'in_store'
            //     and delivery_method.delivery_type != 'in_store'
            // )
            // super()._set_delivery_method(delivery_method, rate=rate)
            // if was_in_store_order:
            //     self._compute_warehouse_id()
            //     self._compute_fiscal_position_id()
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _set_delivery_method(self, *args, **kwargs):
            // super()._set_delivery_method(*args, **kwargs)
            // self._update_programs_and_rewards()
            */
            return default;
        }

        protected async Task<SaleOrder> SetGridUpInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py) ---
            // def _set_grid_up(self):
            // """Save locally the matrix of the given product.template, to be used by the matrix configurator."""
            // if self.grid_product_tmpl_id:
            //     self.grid_update = False
            //     self.grid = json.dumps(self._get_matrix(self.grid_product_tmpl_id))
            */
            return default;
        }

        protected async Task<SaleOrder> SetPickupLocationInternalAsync(object pickup_location_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _set_pickup_location(self, pickup_location_data):
            // """ Set the pickup location on the current order.
            // 
            // Note: self.ensure_one()
            // 
            // :param str pickup_location_data: The JSON-formatted pickup location address.
            // :return: None
            // """
            // self.ensure_one()
            // use_locations_fname = f'{self.carrier_id.delivery_type}_use_locations'
            // if hasattr(self.carrier_id, use_locations_fname):
            //     use_location = getattr(self.carrier_id, use_locations_fname)
            //     if use_location and pickup_location_data:
            //         pickup_location = json.loads(pickup_location_data)
            //     else:
            //         pickup_location = None
            //     self.pickup_location_data = pickup_location
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _set_pickup_location(self, pickup_location_data):
            // """ Override `website_sale` to set the pickup location for in-store delivery methods.
            // Set account fiscal position depending on selected pickup location to correctly calculate
            // taxes.
            // """
            // super()._set_pickup_location(pickup_location_data)
            // if self.carrier_id.delivery_type != 'in_store':
            //     return
            // 
            // self.pickup_location_data = json.loads(pickup_location_data)
            // if self.pickup_location_data:
            //     self.warehouse_id = self.pickup_location_data['id']
            //     self._compute_fiscal_position_id()
            // else:
            //     self._compute_warehouse_id()
            */
            return default;
        }

        protected async Task<SaleOrder> ShouldBeLockedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _should_be_locked(self):
            // self.ensure_one()
            // # Public user can confirm SO, so we check the group on any record creator.
            // return self.env['res.groups']._is_feature_enabled('sale.group_auto_done_setting')
            */
            return default;
        }

        public async Task<SaleOrder> ShowRepairAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: sale_order.py) ---
            // def action_show_repair(self):
            // self.ensure_one()
            // if self.repair_count == 1:
            //     return {
            //         "type": "ir.actions.act_window",
            //         "res_model": "repair.order",
            //         "views": [[False, "form"]],
            //         "res_id": self.repair_order_ids.id,
            //     }
            // elif self.repair_count > 1:
            //     return {
            //         "name": _("Repair Orders"),
            //         "type": "ir.actions.act_window",
            //         "res_model": "repair.order",
            //         "view_mode": "list,form",
            //         "domain": [('sale_order_id', '=', self.id)],
            //     }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> TasksIdsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def _tasks_ids_domain(self):
            // return ['&', ('is_template', '=', False), ('project_id', '!=', False), '|', ('sale_line_id', 'in', self.order_line.ids), ('sale_order_id', 'in', self.ids), ('has_template_ancestor', '=', False)]
            */
            return default;
        }

        protected async Task<SaleOrder> TrackFinalizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _track_finalize(self):
            // """ Override of `mail` to prevent logging changes when the SO is in a draft state. """
            // if (len(self) == 1
            //     # The method _track_finalize is sometimes called too early or too late and it
            //     # might cause a desynchronization with the cache, thus this condition is needed.
            //     and self.env.cache.contains(self, self._fields['state']) and self._discard_tracking()):
            //     self.env.cr.precommit.data.pop(f'mail.tracking.{self._name}', {})
            //     self.env.flush_all()
            //     return
            // return super()._track_finalize()
            */
            return default;
        }

        protected async Task<SaleOrder> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'sale':
            //     return self.env.ref('sale.mt_order_confirmed')
            // elif 'state' in init_values and self.state == 'sent':
            //     return self.env.ref('sale.mt_order_sent')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<SaleOrder> TryApplyCodeInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _try_apply_code(self, code):
            // """
            // Tries to apply a promotional code to the sales order.
            // It can be either from a coupon or a program rule.
            // 
            // Returns a dict with the following possible keys:
            //  - 'not_found': Populated with True if the code did not yield any result.
            //  - 'error': Any error message that could occur.
            //  OR The result of `_get_claimable_rewards` with the found or newly created coupon, it will be empty if the coupon was consumed completely.
            // """
            // self.ensure_one()
            // 
            // base_domain = self._get_trigger_domain()
            // domain = Domain.AND([base_domain, [('mode', '=', 'with_code'), ('code', '=', code)]])
            // rule = self.env['loyalty.rule'].search(domain)
            // program = rule.program_id
            // coupon = False
            // check_date = self._get_confirmed_tx_create_date()
            // 
            // if rule in self.code_enabled_rule_ids:
            //     return {'error': _("This promo code is already applied.")}
            // 
            // # No trigger was found from the code, try to find a coupon
            // if not program:
            //     coupon = self.env['loyalty.card'].search([('code', '=', code)])
            //     if not coupon or\
            //         not coupon.program_id.active or\
            //         not coupon.program_id.reward_ids or\
            //         not coupon.program_id.filtered_domain(self._get_program_domain()):
            //         return {'error': _("This code is invalid (%s).", code), 'not_found': True}
            //     if coupon.expiration_date and coupon.expiration_date < check_date:
            //         return {'error': _("This coupon is expired.")}
            //     elif coupon.points < min(coupon.program_id.reward_ids.mapped('required_points')):
            //         return {'error': _("This coupon has already been used.")}
            //     program = coupon.program_id
            // 
            // if not program or not program.active:
            //     return {'error': _("This code is invalid (%s).", code), 'not_found': True}
            // elif program.program_type in ('loyalty', 'ewallet'):
            //     return {'error': _("This program cannot be applied with code.")}
            // 
            // # Lock the loyalty program row to block several processes that try to
            // # read it at the same time. We also use NOWAIT to make sure we trigger a
            // # serialization error when the processes don't have the lock and thus,
            // # trigger a retry of the transaction.
            // self.env.cr.execute("""
            //     SELECT id FROM loyalty_program WHERE id=%s FOR UPDATE NOWAIT
            // """, (program.id,))
            // 
            // if (program.limit_usage and program.total_order_count >= program.max_usage):
            //     return {'error': _("This code is expired (%s).", code)}
            // 
            // # Rule will count the next time the points are updated
            // if rule:
            //     self.code_enabled_rule_ids |= rule
            // program_is_applied = program in self._get_points_programs()
            // # Condition that need to apply program (if not applied yet):
            // # current -> always
            // # future -> if no coupon
            // # nominative -> non blocking if card exists with points
            // if coupon:
            //     self.applied_coupon_ids += coupon
            // if program_is_applied:
            //     # Update the points for our programs, this will take the new trigger in account
            //     self._update_programs_and_rewards()
            // elif program.applies_on != 'future' or not coupon:
            //     apply_result = self._try_apply_program(program, coupon)
            //     if 'error' in apply_result and (not program.is_nominative or (program.is_nominative and not coupon)):
            //         if rule:
            //             self.code_enabled_rule_ids -= rule
            //         if coupon and not apply_result.get('already_applied', False):
            //             self.applied_coupon_ids -= coupon
            //         return apply_result
            //     coupon = apply_result.get('coupon', self.env['loyalty.card'])
            // return self._get_claimable_rewards(forced_coupons=coupon)
            */
            return default;
        }

        protected async Task<SaleOrder> TryApplyProgramInternalAsync(object program, object coupon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _try_apply_program(self, program, coupon=None):
            // """
            // Tries to apply a program using the coupon if provided.
            // 
            // This function provides the full routine to apply a program, it will check for applicability
            // aswell as creating the necessary coupons and co-models to give the points to the customer.
            // 
            // This function does not apply any reward to the order, rewards have to be given manually.
            // 
            // Returns a dict containing the error message or containing the associated coupon(s).
            // """
            // self.ensure_one()
            // # Basic checks
            // if not program.filtered_domain(self._get_program_domain()):
            //     return {'error': _("The program is not available for this order.")}
            // elif program in self._get_applied_programs():
            //     return {'error': _("This program is already applied to this order."), 'already_applied': True}
            // elif program.reward_ids:
            //     global_rewards = program.reward_ids.filtered('is_global_discount')
            //     applied_global_reward = self._get_applied_global_discount()
            //     best_global_rewards = max(
            //         global_rewards,
            //         key=lambda reward: self._get_discount_amount(
            //             reward, self._discountable_amount(applied_global_reward)
            //         )
            //     ) if len(global_rewards) > 1 else global_rewards
            //     if (
            //         best_global_rewards
            //         and applied_global_reward
            //         and self._best_global_discount_already_applied(applied_global_reward, best_global_rewards)
            //     ):
            //         return {'error': _(
            //             "This discount (%(discount)s) is not compatible with \"%(other_discount)s\". "
            //             "Please remove it in order to apply this one.",
            //             discount=best_global_rewards.description,
            //             other_discount=applied_global_reward.description
            //         )}
            // # Check for applicability from the program's triggers/rules.
            // # This step should also compute the amount of points to give for that program on that order.
            // status = self._program_check_compute_points(program)[program]
            // if 'error' in status:
            //     return status
            // return self.__try_apply_program(program, coupon, status)
            */
            return default;
        }

        protected async Task<SaleOrder> TryPendingCouponInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _try_pending_coupon(self):
            // if not request:
            //     return False
            // 
            // pending_coupon_code = request.session.get('pending_coupon_code')
            // if pending_coupon_code:
            //     status = self._try_apply_code(pending_coupon_code)
            //     if 'error' not in status: # Returns an array if everything went right
            //         request.session.pop('pending_coupon_code')
            //         if len(status) == 1:
            //             coupon, rewards = next(iter(status.items()))
            //             if len(rewards) == 1 and not rewards.multi_product:
            //                 self._apply_program_reward(rewards, coupon)
            //     return status
            // return True
            */
            return default;
        }

        protected async Task<SaleOrder> UnlinkExceptDraftOrCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _unlink_except_draft_or_cancel(self):
            // for order in self:
            //     if order.state not in ('draft', 'cancel'):
            //         raise UserError(_(
            //             "You can not delete a sent quotation or a confirmed sales order."
            //             " You must first cancel it."))
            */
            return default;
        }

        public async Task<SaleOrder> UnlockAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_unlock(self):
            // self.locked = False
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> UpdateAddressInternalAsync(Guid partner_id, object fnames)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _update_address(self, partner_id, fnames=None):
            // if not fnames:
            //     return
            // 
            // fpos_before = self.fiscal_position_id
            // pricelist_before = self.pricelist_id
            // 
            // self.write(dict.fromkeys(fnames, partner_id))
            // 
            // fpos_changed = fpos_before != self.fiscal_position_id
            // if fpos_changed:
            //     # Recompute taxes on fpos change
            //     self._recompute_taxes()
            // 
            //     new_fpos = self.fiscal_position_id
            //     request.session[FISCAL_POSITION_SESSION_CACHE_KEY] = new_fpos.id
            //     request.fiscal_position = new_fpos
            // 
            // #If user explicitely selected a valid pricelist, we don't want to change it
            // if selected_pricelist_id := request.session.get(PRICELIST_SELECTED_SESSION_CACHE_KEY):
            //     selected_pricelist = (
            //         self.env['product.pricelist'].browse(selected_pricelist_id).exists()
            //     )
            //     if (
            //         selected_pricelist
            //         and selected_pricelist._is_available_on_website(self.website_id)
            //         and selected_pricelist._is_available_in_country(
            //             self.partner_id.country_id.code
            //         )
            //     ):
            //         self.pricelist_id = selected_pricelist
            //     else:
            //         request.session.pop(PRICELIST_SELECTED_SESSION_CACHE_KEY, None)
            // 
            // if self.pricelist_id != pricelist_before or fpos_changed:
            //     # Pricelist may have been recomputed by the `partner_id` field update
            //     # we need to recompute the prices to match the new pricelist if it changed
            //     self._recompute_prices()
            // 
            //     new_pricelist = self.pricelist_id
            //     request.session[PRICELIST_SESSION_CACHE_KEY] = new_pricelist.id
            //     request.pricelist = new_pricelist
            // 
            // if self.carrier_id and 'partner_shipping_id' in fnames and self._has_deliverable_products():
            //     # Update the delivery method on shipping address change.
            //     delivery_methods = self._get_delivery_methods()
            //     delivery_method = self._get_preferred_delivery_method(delivery_methods)
            //     self._set_delivery_method(delivery_method)
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateLoyaltyHistoryInternalAsync(Guid coupon_id, object points)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _update_loyalty_history(self, coupon_id, points):
            // self.ensure_one()
            // order_coupon_history = self.env['loyalty.history'].search([
            //     ('card_id', '=', coupon_id.id),
            //     ('order_model', '=', self._name),
            //     ('order_id', '=', self.id),
            // ], limit=1)
            // order_coupon_history.update({
            //     'used': order_coupon_history.used + points,
            // })
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: sale_order.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Override of `sale` to recompute the delivery prices.
            // 
            // :param int product_id: The product, as a `product.product` id.
            // :return: The unit price price of the product, based on the pricelist of the sale order and
            //          the quantity selected.
            // :rtype: float
            // """
            // price_unit = super()._update_order_line_info(product_id, quantity, **kwargs)
            // if self:
            //     self.onchange_order_line()
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _update_order_line_info(
            //     self, product_id, quantity, *, section_id=False, child_field='order_line', **kwargs
            // ):
            //     """ Update sale order line information for a given product or create a
            //     new one if none exists yet.
            //     :param int product_id: The product, as a `product.product` id.
            //     :param int quantity: The quantity selected in the catalog.
            //     :param int section_id: The id of section selected in the catalog.
            //     :return: The unit price of the product, based on the pricelist of the
            //              sale order and the quantity selected.
            //     :rtype: float
            //     """
            //     request.update_context(catalog_skip_tracking=True)
            //     sol = self.order_line.filtered(
            //         lambda l: l.product_id.id == product_id
            //         and l.get_parent_section_line().id == section_id,
            //     )
            //     if sol:
            //         if quantity != 0:
            //             sol.product_uom_qty = quantity
            //         elif self.state in ['draft', 'sent']:
            //             price_unit = self.pricelist_id._get_product_price(
            //                 product=sol.product_id,
            //                 quantity=1.0,
            //                 currency=self.currency_id,
            //                 date=self.date_order,
            //                 **kwargs,
            //             )
            //             sol.unlink()
            //             return price_unit
            //         else:
            //             sol.product_uom_qty = 0
            //     elif quantity > 0:
            //         sol = self.env['sale.order.line'].create({
            //             'order_id': self.id,
            //             'product_id': product_id,
            //             'product_uom_qty': quantity,
            //             'sequence': self._get_new_line_sequence(child_field, section_id),
            //         })
            //     else:  # quantity of 0, no line to update, return defaut pricelist price
            //         return self.pricelist_id._get_product_price(
            //             product=self.env['product.product'].browse(product_id),
            //             quantity=1.0,
            //             currency=self.currency_id,
            //             date=self.date_order,
            //             **kwargs,
            //         )
            // 
            //     return sol._get_discounted_price()
            */
            return default;
        }

        public async Task<SaleOrder> UpdatePricesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_update_prices(self):
            // self.ensure_one()
            // 
            // self._recompute_prices()
            // 
            // if self.pricelist_id:
            //     message = _("Product prices have been recomputed according to pricelist %s.",
            //         self.pricelist_id._get_html_link())
            // else:
            //     message = _("Product prices have been recomputed.")
            // self.message_post(body=message)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> UpdateProgramsAndRewardsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _update_programs_and_rewards(self):
            // """
            // Updates applied programs's given points with the current state of the order.
            // Checks automatic programs for applicability.
            // Updates applied rewards using the new points and the current state of the order (for example with % discounts).
            // """
            // self.ensure_one()
            // 
            // # +===================================================+
            // # |       STEP 1: Retrieve all applicable programs    |
            // # +===================================================+
            // 
            // # Automatically load in eWallet and loyalty cards coupons with previously received points
            // if self._allow_nominative_programs():
            //     loyalty_card = self.env['loyalty.card'].search([
            //         ('id', 'not in', self.applied_coupon_ids.ids),
            //         ('partner_id', '=', self.partner_id.id),
            //         ('points', '>', 0),
            //         '|', ('program_id.program_type', '=', 'ewallet'),
            //              '&', ('program_id.program_type', '=', 'loyalty'),
            //                   ('program_id.applies_on', '!=', 'current'),
            //     ])
            //     if loyalty_card:
            //         self.applied_coupon_ids += loyalty_card
            // # Programs that are applied to the order and count points
            // points_programs = self._get_points_programs()
            // # Coupon programs that require the program's rules to match but do not count for points
            // coupon_programs = self.applied_coupon_ids.program_id
            // # Programs that are automatic and not yet applied
            // program_domain = self._get_program_domain()
            // domain = Domain.AND([program_domain, [('id', 'not in', points_programs.ids), ('trigger', '=', 'auto'), ('rule_ids.mode', '=', 'auto')]])
            // automatic_programs = self.env['loyalty.program'].search(domain).filtered(lambda p:
            //     not p.limit_usage or p.total_order_count < p.max_usage)
            // 
            // all_programs_to_check = points_programs | coupon_programs | automatic_programs
            // all_coupons = self.coupon_point_ids.coupon_id | self.applied_coupon_ids
            // # First basic check using the program_domain -> for example if a program gets archived mid quotation
            // domain_matching_programs = all_programs_to_check.filtered_domain(program_domain)
            // all_programs_status = {p: {'error': 'error'} for p in all_programs_to_check - domain_matching_programs}
            // # Compute applicability and points given for all programs that passed the domain check
            // # Note that points are computed with reward lines present
            // all_programs_status.update(self._program_check_compute_points(domain_matching_programs))
            // # Delay any unlink to the end of the function since they cause a full cache invalidation
            // lines_to_unlink = self.env['sale.order.line']
            // coupons_to_unlink = self.env['loyalty.card']
            // point_entries_to_unlink = self.env['sale.order.coupon.points']
            // # Remove any coupons that are expired
            // if initial_coupons := self.applied_coupon_ids:
            //     check_date = self._get_confirmed_tx_create_date()
            //     self.applied_coupon_ids = initial_coupons.filtered(
            //         lambda c: not c.expiration_date or c.expiration_date >= check_date,
            //     )
            //     removed = initial_coupons - self.applied_coupon_ids
            //     lines_to_unlink |= self.order_line.filtered(lambda sol: sol.coupon_id in removed)
            // point_ids_per_program = defaultdict(lambda: self.env['sale.order.coupon.points'])
            // for pe in self.coupon_point_ids:
            //     # Update coupons that were created for Public User
            //     if pe.coupon_id.partner_id.is_public and not self.partner_id.is_public:
            //         pe.coupon_id.partner_id = self.partner_id
            //     # Remove any point entry for a coupon that does not belong to the customer
            //     if pe.coupon_id.partner_id and pe.coupon_id.partner_id != self.partner_id:
            //         pe.points = 0
            //         point_entries_to_unlink |= pe
            //     else:
            //         point_ids_per_program[pe.coupon_id.program_id] |= pe
            // 
            // # +==========================================+
            // # |       STEP 2: Update applied programs    |
            // # +==========================================+
            // 
            // # Programs that were not applied via a coupon
            // for program in points_programs:
            //     status = all_programs_status[program]
            //     program_point_entries = point_ids_per_program[program]
            //     if 'error' in status:
            //         # Program is not applicable anymore
            //         coupons_from_order = program_point_entries.coupon_id.filtered(lambda c: c.order_id == self)
            //         all_coupons -= coupons_from_order
            //         # Invalidate those lines so that they don't impact anything further down the line
            //         program_reward_lines = self.order_line.filtered(lambda l: l.coupon_id in coupons_from_order)
            //         program_reward_lines._reset_loyalty(True)
            //         lines_to_unlink |= program_reward_lines
            //         # Delete coupon created by this order for this program if it is not nominative
            //         if not program.is_nominative:
            //             coupons_to_unlink |= coupons_from_order
            //         else:
            //             # Only remove the coupon_point_id
            //             point_entries_to_unlink |= program_point_entries
            //             point_entries_to_unlink.points = 0
            //         # Remove the code activated rules
            //         self.code_enabled_rule_ids -= program.rule_ids
            //     else:
            //         # Program stays applicable, update our points
            //         all_point_changes = [p for p in status['points'] if p]
            //         if not all_point_changes and program.is_nominative:
            //             all_point_changes = [0]
            //         for pe, points in zip(program_point_entries.sudo(), all_point_changes):
            //             pe.points = points
            //         if len(program_point_entries) < len(all_point_changes):
            //             new_coupon_points = all_point_changes[len(program_point_entries):]
            //             # next_order_coupons should be linked to the order's partner
            //             partner_id = program.program_type == 'next_order_coupons' and self.partner_id.id
            //             # NOTE: Maybe we could batch the creation of coupons across multiple programs but this really only applies to gift cards
            //             new_coupons = self.env['loyalty.card'].with_context(loyalty_no_mail=True, tracking_disable=True).create([{
            //                 'program_id': program.id,
            //                 'partner_id': partner_id,
            //                 'points': 0,
            //                 'order_id': self.id,
            //             } for _ in new_coupon_points])
            //             self._add_points_for_coupon({coupon: x for coupon, x in zip(new_coupons, new_coupon_points)})
            //         elif len(program_point_entries) > len(all_point_changes):
            //             point_ids_to_unlink = program_point_entries[len(all_point_changes):]
            //             all_coupons -= point_ids_to_unlink.coupon_id
            //             coupons_to_unlink |= point_ids_to_unlink.coupon_id
            //             point_ids_to_unlink.points = 0
            // 
            // # Programs applied using a coupon
            // applied_coupon_per_program = defaultdict(lambda: self.env['loyalty.card'])
            // for coupon in self.applied_coupon_ids:
            //     applied_coupon_per_program[coupon.program_id] |= coupon
            // for program in coupon_programs:
            //     if program not in domain_matching_programs or\
            //         (program.applies_on == 'current' and 'error' in all_programs_status[program]):
            //         program_reward_lines = self.order_line.filtered(lambda l: l.coupon_id in applied_coupon_per_program[program])
            //         program_reward_lines._reset_loyalty(True)
            //         lines_to_unlink |= program_reward_lines
            //         self.applied_coupon_ids -= applied_coupon_per_program[program]
            //         all_coupons -= applied_coupon_per_program[program]
            // 
            // # +==========================================+
            // # |       STEP 3: Update reward lines        |
            // # +==========================================+
            // 
            // # We will reuse these lines as much as possible, this resets the order in a reward-less state
            // reward_line_pool = self.order_line.filtered(lambda l: l.reward_id and l.coupon_id)._reset_loyalty()
            // seen_rewards = set()
            // line_rewards = []
            // payment_rewards = [] # gift_card and ewallet are considered as payments and should always be applied last
            // for line in self.order_line:
            //     if line.reward_identifier_code in seen_rewards or not line.reward_id or\
            //         not line.coupon_id:
            //         continue
            //     seen_rewards.add(line.reward_identifier_code)
            //     if line.reward_id.program_id.is_payment_program:
            //         payment_rewards.append((line.reward_id, line.coupon_id, line.reward_identifier_code, line.product_id))
            //     else:
            //         line_rewards.append((line.reward_id, line.coupon_id, line.reward_identifier_code, line.product_id))
            // 
            // for reward_key in itertools.chain(line_rewards, payment_rewards):
            //     coupon = reward_key[1]
            //     reward = reward_key[0]
            //     program = reward.program_id
            //     points = self._get_real_points_for_coupon(coupon)
            //     if coupon not in all_coupons or points < reward.required_points or program not in domain_matching_programs:
            //         # Reward is not applicable anymore, the reward lines will simply be removed at the end of this function
            //         continue
            //     try:
            //         values_list = self._get_reward_line_values(reward, coupon, product=reward_key[3])
            //     except UserError:
            //         # It could happen that we have nothing to discount after changing the order.
            //         values_list = []
            //     reward_line_pool = self._write_vals_from_reward_vals(values_list, reward_line_pool, delete=False)
            // 
            // lines_to_unlink |= reward_line_pool
            // 
            // # +==========================================+
            // # |       STEP 4: Apply new programs         |
            // # +==========================================+
            // 
            // for program in automatic_programs:
            //     program_status = all_programs_status[program]
            //     if 'error' in program_status:
            //         continue
            //     self.__try_apply_program(program, False, program_status)
            // 
            // # +==========================================+
            // # |       STEP 5: Cleanup                    |
            // # +==========================================+
            // 
            // order_line_update = [(Command.DELETE, line.id) for line in lines_to_unlink]
            // if order_line_update:
            //     self.write({'order_line': order_line_update})
            // if coupons_to_unlink:
            //     coupons_to_unlink.sudo().unlink()
            // if point_entries_to_unlink:
            //     point_entries_to_unlink.sudo().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _update_programs_and_rewards(self):
            // for order in self:
            //     order._try_pending_coupon()
            // return super()._update_programs_and_rewards()
            */
            return default;
        }

        public async Task<SaleOrder> UpdateTaxesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_update_taxes(self):
            // self.ensure_one()
            // 
            // self._recompute_taxes()
            // 
            // if self.partner_id:
            //     self.message_post(body=_("Product taxes have been recomputed according to fiscal position %s.",
            //         self.fiscal_position_id._get_html_link() if self.fiscal_position_id else "")
            //     )
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<SaleOrder> ValidateOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _validate_order(self):
            // """Confirm the sale order and send a confirmation email.
            // 
            // :return: None
            // """
            // self.with_context(send_email=True).action_confirm()
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _validate_order(self):
            // """
            // Override of sale to create invoice for zero amount order. If the order total is zero and
            // automatic invoicing is enabled, it creates and posts an invoice.
            // 
            // :return: None
            // """
            // super()._validate_order()
            // if self.amount_total or not self.reward_amount:
            //     return
            // auto_invoice = self.env['ir.config_parameter'].get_param('sale.automatic_invoice')
            // if str2bool(auto_invoice):
            //     # create an invoice for order with zero total amount and automatic invoice enabled
            //     self._force_lines_to_invoice_policy_order()
            //     invoice = self._create_invoices(final=True)
            //     invoice.action_post()
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyCartAfterUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _verify_cart_after_update(self):
            // """Global checks on the cart after updates.
            // 
            // Called from controllers to ensure it's only done once by request (combos,
            // optional products, ...).
            // """
            // if self.only_services:
            //     self._remove_delivery_line()
            // elif self.carrier_id:
            //     # Recompute the delivery rate.
            //     rate = self.carrier_id.rate_shipment(self)
            //     if rate['success']:
            //         self.order_line.filtered('is_delivery').price_unit = rate['price']
            //     else:
            //         self._remove_delivery_line()
            // 
            // if request:
            //     request.session['website_sale_cart_quantity'] = self.cart_quantity
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py) ---
            // def _verify_cart_after_update(self):
            // super()._verify_cart_after_update()
            // self._update_programs_and_rewards()
            // self._auto_apply_rewards()
            // if request:  # In case the rewards application modifies the cart quantity
            //     request.session['website_sale_cart_quantity'] = self.cart_quantity
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyCartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _verify_cart(self):
            // """Check cart content and clear outdated/invalid lines."""
            // self.ensure_one()
            // 
            // # Remove lines with inactive products
            // self.order_line.filtered(lambda sol: sol.product_id and not sol.product_id.active).unlink()
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyUpdatedQuantityInternalAsync(object order_line, Guid product_id, object new_qty, Guid uom_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // """Forbid quantity updates on event booth lines."""
            // product = self.env['product.product'].browse(product_id)
            // if product.service_tracking == 'event_booth' and new_qty > 1:
            //     return 1, _('You cannot manually change the quantity of an Event Booth product.')
            // return super()._verify_updated_quantity(order_line, product_id, new_qty, uom_id, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py) ---
            // def _verify_updated_quantity(
            //     self, order_line, product_id, new_qty, uom_id, *, event_slot_id=False, event_ticket_id=False, **kwargs
            // ):
            //     """Restrict quantity updates for event tickets according to available seats."""
            //     new_qty, warning = super()._verify_updated_quantity(
            //         order_line,
            //         product_id,
            //         new_qty,
            //         uom_id,
            //         event_slot_id=event_slot_id,
            //         event_ticket_id=event_ticket_id,
            //         **kwargs,
            //     )
            // 
            //     if not event_ticket_id:
            //         if not order_line.event_ticket_id or new_qty < order_line.product_uom_qty:
            //             return new_qty, warning
            //         else:
            //             return order_line.product_uom_qty, _("You cannot raise manually the event ticket quantity in your cart")
            // 
            //     # Adding new ticket to the cart (might be automatically linked to an existing line)
            //     ticket = self.env['event.event.ticket'].browse(event_ticket_id).exists()
            //     if not ticket:
            //         raise UserError(_("The provided ticket doesn't exist"))
            //     slot = self.env['event.slot'].browse(event_slot_id).exists()
            //     if event_slot_id and not slot:
            //         raise UserError(_("The provided ticket slot doesn't exist"))
            // 
            //     # TODO TDE consider full cart qty and not only added qty
            //     # if event seats are not auto confirmed.
            //     # Since created registrations are automatically reserved
            //     # We should only consider new added qty and not full quantity
            //     # when checking for seat availability
            //     existing_qty = order_line.product_uom_qty if order_line else 0
            //     qty_added = new_qty - existing_qty
            //     warning = ''
            //     ticket_seats_available = ticket.event_id._get_seats_availability([(slot, ticket)])[0] if slot else ticket.seats_available
            //     if ticket.seats_limited and ticket_seats_available <= 0:
            //         # Remove existing line if exists and do not add a new one
            //         # if no ticket is available anymore
            //         new_qty = existing_qty
            //         warning = _(
            //             'Sorry, The %(ticket)s tickets for the %(event)s event are sold out.',
            //             ticket=ticket.name,
            //             event=ticket.event_id.name,
            //         )
            //     elif ticket.seats_limited and qty_added > ticket_seats_available:
            //         new_qty = existing_qty + ticket_seats_available
            //         warning = _(
            //             'Sorry, only %(remaining_seats)d seats are still available for the %(ticket)s ticket for the %(event)s event%(slot)s.',
            //             remaining_seats=ticket_seats_available,
            //             slot=f' on {slot.name}' if slot else '',
            //             ticket=ticket.name,
            //             event=ticket.event_id.name,
            //         )
            // 
            //     return new_qty, warning
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // return new_qty, ''
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // """ Override of `website_sale_stock` to skip the verification when click and collect
            // is activated. The quantity is verified later. """
            // product = self.env['product.product'].browse(product_id)
            // if (
            //     product.is_storable
            //     and not product.allow_out_of_stock_order
            //     and self.website_id.in_store_dm_id
            // ):
            //     return new_qty, ''
            // return super()._verify_updated_quantity(order_line, product_id, new_qty, uom_id, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // """ Override of `website_sale` to prevent mixing Gelato and non-Gelato products in the cart.
            // 
            // This check is not redundant with the constraint on `sale.order` in `sale_gelato` because the
            // constraint would only be enforced at the end of the checkout for eCommerce carts, and would
            // not mention the specific product that caused the issue nor display the warning message in a
            // user-friendly way.
            // 
            // :param sale.order.line order_line: The order line to update.
            // :param int product_id: The ID of the product to update.
            // :param int new_qty: The new quantity of the product.
            // :param kwargs: Additional keyword arguments.
            // :return: The new quantity and an optional warning message.
            // :rtype: tuple[int, str]
            // """
            // product = self.env['product.product'].browse(product_id)
            // mixing_products = product.type != 'service' and any(
            //     (product.gelato_product_uid and not line.product_id.gelato_product_uid)
            //     or (not product.gelato_product_uid and line.product_id.gelato_product_uid)
            //     for line in self.order_line.filtered(lambda l: l.product_id.type != 'service')
            // )  # Whether Gelato and non-Gelato products that require delivery are mixed.
            // if mixing_products:
            //     return 0, _(
            //         "The product %(product_name)s cannot be added to the cart as it requires separate"
            //         " shipping. Please place your order for the current cart first.",
            //         product_name=product.name,
            //     )
            // return super()._verify_updated_quantity(order_line, product_id, new_qty, uom_id, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // """Forbid quantity updates on courses lines."""
            // product = self.env['product.product'].browse(product_id)
            // if product.service_tracking == 'course' and new_qty > 1:
            //     return 1, _('You can only add a course once in your cart.')
            // return super()._verify_updated_quantity(order_line, product_id, new_qty, uom_id, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py) ---
            // def _verify_updated_quantity(self, order_line, product_id, new_qty, uom_id, **kwargs):
            // self.ensure_one()
            // product = self.env['product.product'].browse(product_id)
            // if product.is_storable and not product.allow_out_of_stock_order:
            //     uom = self.env['uom.uom'].browse(uom_id)
            //     product_uom = product.uom_id
            // 
            //     product_qty_in_cart, available_qty = self._get_cart_and_free_qty(product)
            // 
            //     # Convert cart and available quantities to the requested uom
            //     product_qty_in_cart = product_uom._compute_quantity(product_qty_in_cart, uom)
            //     available_qty = product_uom._compute_quantity(available_qty, uom, round=False)
            //     available_qty = float_round(available_qty, precision_digits=0, rounding_method='DOWN')
            // 
            //     old_qty = order_line.product_uom_qty if order_line else 0
            //     added_qty = new_qty - old_qty
            //     total_cart_qty = product_qty_in_cart + added_qty
            //     if available_qty < total_cart_qty:
            //         allowed_line_qty = available_qty - (product_qty_in_cart - old_qty)
            //         if allowed_line_qty > 0:
            //             def format_qty(qty):
            //                 return int(qty) if float(qty).is_integer() else qty
            //             if order_line:
            //                 warning = order_line._set_shop_warning_stock(
            //                     format_qty(total_cart_qty),
            //                     format_qty(available_qty),
            //                     save=False,
            //                 )
            //             else:
            //                 warning = self.env._(
            //                     "You ask for %(desired_qty)s products but only %(available_qty)s is"
            //                     " available.",
            //                     desired_qty=format_qty(total_cart_qty),
            //                     available_qty=format_qty(available_qty),
            //                 )
            //         elif order_line:
            //             # Line will be deleted
            //             warning = self.env._(
            //                 "Some products became unavailable and your cart has been updated. We're"
            //                 " sorry for the inconvenience."
            //             )
            //         else:
            //             warning = self.env._(
            //                 "%(product_name)s has not been added to your cart since it is not available.",
            //                 product_name=product.name,
            //             )
            //         return allowed_line_qty, warning
            // return super()._verify_updated_quantity(order_line, product_id, new_qty, uom_id, **kwargs)
            */
            return default;
        }

        public async Task<SaleOrder> ViewAttendeeListAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py) ---
            // def action_view_attendee_list(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("event.event_registration_action_tree")
            // action['domain'] = [('sale_order_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewBoothListAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py) ---
            // def action_view_booth_list(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('event_booth.event_booth_action')
            // action['domain'] = [('sale_order_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewDeliveryAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def action_view_delivery(self):
            // return self._get_action_view_picking(self.picking_ids)
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py) ---
            // def action_view_delivery(self):
            // return self._get_action_view_picking(self.picking_ids.filtered(lambda p: not p.is_dropship))
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewDropshipAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py) ---
            // def action_view_dropship(self):
            // return self._get_action_view_picking(self.picking_ids.filtered(lambda p: p.is_dropship))
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewGiftCardsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def action_view_gift_cards(self):
            // self.ensure_one()
            // return {
            //     'name': _("Gift Cards"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'res_model': 'loyalty.card',
            //     'domain': [('order_id', '=', self.id), ('program_type', '=', 'gift_card')],
            //     'context': {'create': False},
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewInvoiceAsync(SaleOrderViewInvoiceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_view_invoice(self, invoices=False):
            // if not invoices:
            //     invoices = self.mapped('invoice_ids')
            // action = self.env['ir.actions.actions']._for_xml_id('account.action_move_out_invoice_type')
            // if len(invoices) > 1:
            //     action['domain'] = [('id', 'in', invoices.ids)]
            // elif len(invoices) == 1:
            //     form_view = [(self.env.ref('account.view_move_form').id, 'form')]
            //     if 'views' in action:
            //         action['views'] = form_view + [(state,view) for state,view in action['views'] if view != 'form']
            //     else:
            //         action['views'] = form_view
            //     action['res_id'] = invoices.id
            // else:
            //     action = {'type': 'ir.actions.act_window_close'}
            // 
            // context = {
            //     'default_move_type': 'out_invoice',
            // }
            // if len(self) == 1:
            //     context.update({
            //         'default_partner_id': self.partner_id.id,
            //         'default_partner_shipping_id': self.partner_shipping_id.id,
            //         'default_invoice_payment_term_id': self.payment_term_id.id or self.partner_id.property_payment_term_id.id or self.env['account.move'].default_get(['invoice_payment_term_id']).get('invoice_payment_term_id'),
            //     })
            // action['context'] = context
            // return action
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewMilestoneAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def action_view_milestone(self):
            // self.ensure_one()
            // default_project = self.project_ids and self.project_ids[0]
            // sorted_line = self.order_line.sorted('sequence')
            // default_sale_line = next((
            //     sol for sol in sorted_line
            //         if sol.is_service and sol.product_id.service_policy == 'delivered_milestones'
            // ), self.env['sale.order.line'])
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Milestones'),
            //     'domain': [('sale_line_id', 'in', self.order_line.ids)],
            //     'res_model': 'project.milestone',
            //     'views': [(self.env.ref('sale_project.project_milestone_view_tree').id, 'list')],
            //     'view_mode': 'list',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             No milestones found. Let's create one!
            //         </p><p>
            //             Track major progress points that must be reached to achieve success.
            //         </p>
            //     """),
            //     'context': {
            //         **self.env.context,
            //         'default_project_id': default_project.id,
            //         'default_sale_line_id': default_sale_line.id,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order.py) ---
            // def action_view_mrp_production(self):
            // self.ensure_one()
            // action = {
            //     'res_model': 'mrp.production',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(self.mrp_production_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.mrp_production_ids.id,
            //     })
            // else:
            //     action.update({
            //         'name': _("Manufacturing Orders Generated by %s", self.name),
            //         'domain': [('id', 'in', self.mrp_production_ids.ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py) ---
            // def action_view_pos_order(self):
            // self.ensure_one()
            // linked_orders = self.pos_order_line_ids.mapped('order_id')
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Linked POS Orders'),
            //     'res_model': 'pos.order',
            //     'view_mode': 'list,form',
            //     'domain': [('id', 'in', linked_orders.ids)],
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewProjectIdsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def action_view_project_ids(self):
            // self.ensure_one()
            // if not self.order_line:
            //     return {'type': 'ir.actions.act_window_close'}
            // 
            // sorted_line = self.order_line.sorted('sequence')
            // default_sale_line = next((
            //     sol for sol in sorted_line if sol.product_id.type == 'service'
            // ), self.env['sale.order.line'])
            // project_ids = self.project_ids
            // partner = self.partner_shipping_id or self.partner_id
            // if len(project_ids) == 1:
            //     action = self.env['ir.actions.actions'].with_context(
            //         active_id=self.project_ids.id,
            //     )._for_xml_id('project.act_project_project_2_project_task_all')
            //     action['context'] = {
            //         'active_id': project_ids.id,
            //         'default_partner_id': partner.id,
            //         'default_project_id': self.project_ids.id,
            //         'default_sale_line_id': default_sale_line.id,
            //         'default_user_ids': [self.env.uid],
            //         'search_default_sale_order_id': self.id,
            //     }
            //     return action
            // else:
            //     action = self.env['ir.actions.actions']._for_xml_id('project.open_view_project_all')
            //     action['domain'] = [
            //         '|',
            //         ('sale_order_id', '=', self.id),
            //         ('id', 'in', project_ids.ids),
            //     ]
            //     action['context'] = {
            //         **self.env.context,
            //         'default_partner_id': partner.id,
            //         'default_reinvoiced_sale_order_id': self.id,
            //         'default_sale_line_id': default_sale_line.id,
            //         'default_allow_billable': 1,
            //         'from_sale_order_action': True,
            //     }
            //     return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py) ---
            // def action_view_purchase_orders(self):
            // self.ensure_one()
            // purchase_order_ids = self._get_purchase_orders().ids
            // action = {
            //     'res_model': 'purchase.order',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(purchase_order_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': purchase_order_ids[0],
            //     })
            // else:
            //     action.update({
            //         'name': _("Purchase Order generated from %s", self.name),
            //         'domain': [('id', 'in', purchase_order_ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewTimesheetAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py) ---
            // def action_view_timesheet(self):
            // self.ensure_one()
            // if not self.order_line:
            //     return {'type': 'ir.actions.act_window_close'}
            // 
            // action = self.env["ir.actions.actions"]._for_xml_id("sale_timesheet.timesheet_action_from_sales_order")
            // default_sale_line = next((sale_line for sale_line in self.order_line if sale_line.is_service and sale_line.product_id.service_policy in ['ordered_prepaid', 'delivered_timesheet']), self.env['sale.order.line'])
            // context = {
            //     'search_default_billable_timesheet': True,
            //     'default_is_so_line_edited': True,
            //     'default_so_line': default_sale_line.id,
            // }  # erase default filters
            // 
            // tasks = self.order_line.task_id._filtered_access('write')
            // if tasks:
            //     context['default_task_id'] = tasks[0].id
            // else:
            //     projects = self.order_line.project_id._filtered_access('write')
            //     if projects:
            //         context['default_project_id'] = projects[0].id
            //     elif self.project_ids:
            //         context['default_project_id'] = self.project_ids[0].id
            // action.update({
            //     'context': context,
            //     'domain': [('so_line', 'in', self.order_line.ids), ('project_id', '!=', False)],
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             No activities found. Let's start a new one!
            //         </p><p>
            //             Track your working hours by projects every day and invoice this time to your customers.
            //         </p>
            //     """)
            // })
            // 
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<SaleOrder> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py) ---
            // def write(self, vals):
            // """ Synchronize partner from SO to registrations. This is done notably
            // in website_sale controller shop/address that updates customer, but not
            // only. """
            // result = super(SaleOrder, self).write(vals)
            // if any(line.service_tracking == 'event' for line in self.order_line) and vals.get('partner_id'):
            //     registrations_toupdate = self.env['event.registration'].sudo().search([('sale_order_id', 'in', self.ids)])
            //     registrations_toupdate.write({'partner_id': vals['partner_id']})
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def write(self, vals):
            // if 'pricelist_id' in vals and any(so.state == 'sale' for so in self):
            //     raise UserError(_("You cannot change the pricelist of a confirmed order !"))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'state' in vals and vals['state'] == 'cancel':
            //     # Remove sale line field reference from all projects
            //     self.env['project.project'].sudo().search([('sale_line_id.order_id', 'in', self.ids)]).sale_line_id = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py) ---
            // def write(self, vals):
            // values = vals
            // if values.get('order_line') and self.state == 'sale':
            //     for order in self:
            //         pre_order_line_qty = {order_line: order_line.product_uom_qty for order_line in order.mapped('order_line') if not order_line.is_expense}
            // 
            // if values.get('partner_shipping_id') and self.env.context.get('update_delivery_shipping_partner'):
            //     for order in self:
            //         order.picking_ids.partner_id = values.get('partner_shipping_id')
            // elif values.get('partner_shipping_id'):
            //     new_partner = self.env['res.partner'].browse(values.get('partner_shipping_id'))
            //     for record in self:
            //         picking = record.mapped('picking_ids').filtered(lambda x: x.state not in ('done', 'cancel'))
            //         message = _("""The delivery address has been changed on the Sales Order<br/>
            //                 From <strong>"%(old_address)s"</strong> to <strong>"%(new_address)s"</strong>,
            //                 You should probably update the partner on this document.""",
            //                     old_address=record.partner_shipping_id.display_name, new_address=new_partner.display_name)
            //         picking.activity_schedule('mail.mail_activity_data_warning', note=message, user_id=self.env.user.id)
            // 
            // if 'commitment_date' in values:
            //     # protagate commitment_date as the deadline of the related stock move.
            //     # TODO: Log a note on each down document
            //     deadline_datetime = values.get('commitment_date')
            //     for order in self:
            //         moves = order.order_line.move_ids.filtered(
            //             lambda m: m.state not in ('done', 'cancel') and m.location_dest_id.usage == 'customer'
            //         )
            //         moves.date_deadline = deadline_datetime or order.expected_date
            // 
            // res = super().write(values)
            // if values.get('order_line') and self.state == 'sale':
            //     for order in self:
            //         to_log = {}
            //         order.order_line.fetch(['product_uom_id', 'product_uom_qty', 'display_type', 'is_downpayment'])
            //         for order_line in order.order_line:
            //             if order_line.display_type or order_line.is_downpayment:
            //                 continue
            //             if float_compare(order_line.product_uom_qty, pre_order_line_qty.get(order_line, 0.0), precision_rounding=order_line.product_uom_id.rounding) < 0:
            //                 to_log[order_line] = (order_line.product_uom_qty, pre_order_line_qty.get(order_line, 0.0))
            //         if to_log:
            //             documents = self.env['stock.picking'].sudo()._log_activity_get_documents(to_log, 'move_ids', 'UP')
            //             documents = {k: v for k, v in documents.items() if k[0].state != 'cancel'}
            //             order._log_decrease_ordered_quantity(documents)
            // return res
            */
            return await base.WriteAsync(input);
        }

        protected async Task<SaleOrder> WriteValsFromRewardValsInternalAsync(object reward_vals, object old_lines, object delete)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def _write_vals_from_reward_vals(self, reward_vals, old_lines, delete=True):
            // """
            // Update, create new reward line and delete old lines in one write on `order_line`
            // 
            // Returns the untouched old lines.
            // """
            // self.ensure_one()
            // command_list = []
            // for vals, line in zip(reward_vals, old_lines):
            //     if vals['product_id'] == line.product_id.id:
            //         vals['name'] = line.name  # Preserve custom description
            //     command_list.append((Command.UPDATE, line.id, vals))
            // if len(reward_vals) > len(old_lines):
            //     command_list.extend((Command.CREATE, 0, vals) for vals in reward_vals[len(old_lines):])
            // elif len(reward_vals) < len(old_lines) and delete:
            //     command_list.extend((Command.DELETE, line.id) for line in old_lines[len(reward_vals):])
            // self.write({'order_line': command_list})
            // return self.env['sale.order.line'] if delete else old_lines[len(reward_vals):]
            */
            return default;
        }

        private async Task<SaleOrder> _TryApplyProgramInternalAsync(object program, object coupon, object status)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py) ---
            // def __try_apply_program(self, program, coupon, status):
            // self.ensure_one()
            // all_points = status['points']
            // points = all_points[0]
            // coupons = coupon or self.env['loyalty.card']
            // if coupon:
            //     if program.is_nominative:
            //         self._add_points_for_coupon({coupon: points})
            // elif not coupon:
            //     # If the program only applies on the current order it does not make sense to fetch already existing coupons
            //     if program.is_nominative:
            //         coupon = self.env['loyalty.card'].search(
            //             [('partner_id', '=', self.partner_id.id), ('program_id', '=', program.id)], limit=1)
            //         # Do not apply 'nominative' programs if no point is given and no coupon exists
            //         if not points and not coupon:
            //             return {'error': _("No card found for this loyalty program and no points will be given with this order.")}
            //         elif coupon:
            //             self._add_points_for_coupon({coupon: points})
            //         coupons = coupon
            //     if not coupon:
            //         all_points = [p for p in all_points if p]
            //         partner = False
            //         # Loyalty programs and ewallets are nominative
            //         if program.is_nominative or program.program_type == 'next_order_coupons':
            //             partner = self.partner_id.id
            //         coupons = self.env['loyalty.card'].sudo().with_context(loyalty_no_mail=True, tracking_disable=True).create([{
            //             'program_id': program.id,
            //             'partner_id': partner,
            //             'points': 0,
            //             'order_id': self.id,
            //         } for _ in all_points])
            //         self._add_points_for_coupon({coupon: x for coupon, x in zip(coupons, all_points)})
            // return {'coupon': coupons}
            */
            return default;
        }
    }
}