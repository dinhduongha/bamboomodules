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
    [Module("Purchase", Depends = new[] { "account" })]
    public class PurchaseOrderAppService : GenericApplicationService<PurchaseOrder>, IPurchaseOrderAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public PurchaseOrderAppService(IRepository<PurchaseOrder, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        protected async Task<PurchaseOrder> ActivityCancelOnSaleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py) ---
            // def _activity_cancel_on_sale(self):
            // """ If some PO are cancelled, we need to put an activity on their origin SO (only the open ones). Since a PO can have
            //     been modified by several SO, when cancelling one PO, many next activities can be schedulded on different SO.
            // """
            // sale_to_notify_map = {}  # map SO -> recordset of PO as {sale.order: set(purchase.order.line)}
            // for order in self:
            //     for purchase_line in order.order_line:
            //         if purchase_line.sale_line_id:
            //             sale_order = purchase_line.sale_line_id.order_id
            //             sale_to_notify_map.setdefault(sale_order, self.env['purchase.order.line'])
            //             sale_to_notify_map[sale_order] |= purchase_line
            // 
            // for sale_order, purchase_order_lines in sale_to_notify_map.items():
            //     sale_order._activity_schedule_with_view('mail.mail_activity_data_warning',
            //         user_id=sale_order.user_id.id or self.env.uid,
            //         views_or_xmlid='sale_purchase.exception_sale_on_purchase_cancellation',
            //         render_context={
            //             'purchase_orders': purchase_order_lines.mapped('order_id'),
            //             'purchase_order_lines': purchase_order_lines,
            //     })
            */
            return default;
        }

        public async Task<PurchaseOrder> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // if res['context'].get('product_catalog_order_model') == 'purchase.order':
            //     res['search_view_id'] = [self.env.ref('purchase.product_view_search_catalog').id, 'search']
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def action_add_from_catalog(self):
            // # Replaces the product's kanban view by the purchase specific one.
            // action = super().action_add_from_catalog()
            // kanban_view_id = self.env.ref('purchase_stock.product_view_kanban_catalog_purchase_only').id
            // action['views'] = [(kanban_view_id, view_type) if view_type == 'kanban' else (view_id, view_type) for (view_id, view_type) in action['views']]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> AddPickingInfoInternalAsync(object activity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _add_picking_info(self, activity):
            // """Helper method to add picking info to the Date Updated activity when
            // vender updates date_planned of the po lines.
            // """
            // validated_picking = self.picking_ids.filtered(lambda p: p.state == 'done')
            // if validated_picking:
            //     message = _("Those dates couldn’t be modified accordingly on the receipt %s which had already been validated.", validated_picking[0].name)
            // elif not self.picking_ids:
            //     message = _("Corresponding receipt not found.")
            // else:
            //     message = _("Those dates have been updated accordingly on the receipt %s.", self.picking_ids[0].name)
            // activity.note += Markup('<p>{}</p>').format(message)
            */
            return default;
        }

        protected async Task<PurchaseOrder> AddSupplierToProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _add_supplier_to_product(self):
            // # Add the partner in the supplier list of the product if the supplier is not registered for
            // # this product. We limit to 10 the number of suppliers for a product to avoid the mess that
            // # could be caused for some generic products ("Miscellaneous").
            // for line in self.order_line:
            //     # Do not add a contact as a supplier
            //     partner = self.partner_id if not self.partner_id.parent_id else self.partner_id.parent_id
            //     already_seller = (partner | self.partner_id) & line.product_id.seller_ids.mapped('partner_id')
            //     if line.product_id and not already_seller and len(line.product_id.seller_ids) <= 10:
            //         price = line.price_unit
            //         # Compute the price for the template's UoM, because the supplier's UoM is related to that UoM.
            //         if line.product_id.product_tmpl_id.uom_po_id != line.product_uom:
            //             default_uom = line.product_id.product_tmpl_id.uom_po_id
            //             price = line.product_uom._compute_price(price, default_uom)
            // 
            //         supplierinfo = self._prepare_supplier_info(partner, line, price, line.currency_id)
            //         # In case the order partner is a contact address, a new supplierinfo is created on
            //         # the parent company. In this case, we keep the product name and code.
            //         seller = line.product_id._select_seller(
            //             partner_id=line.partner_id,
            //             quantity=line.product_qty,
            //             date=line.order_id.date_order and line.order_id.date_order.date(),
            //             uom_id=line.product_uom)
            //         if seller:
            //             supplierinfo['product_name'] = seller.product_name
            //             supplierinfo['product_code'] = seller.product_code
            //         vals = {
            //             'seller_ids': [(0, 0, supplierinfo)],
            //         }
            //         # supplier info should be added regardless of the user access rights
            //         line.product_id.product_tmpl_id.sudo().write(vals)
            */
            return default;
        }

        protected async Task<PurchaseOrder> AmountAllInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _amount_all(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
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
            //     order.amount_total_cc = tax_totals['total_amount']
            */
            return default;
        }

        protected async Task<PurchaseOrder> ApplyGridInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def _apply_grid(self):
            // if self.grid and self.grid_update:
            //     grid = json.loads(self.grid)
            //     product_template = self.env['product.template'].browse(grid['product_template_id'])
            //     product_ids = set()
            //     dirty_cells = grid['changes']
            //     Attrib = self.env['product.template.attribute.value']
            //     default_po_line_vals = {}
            //     new_lines = []
            //     for cell in dirty_cells:
            //         combination = Attrib.browse(cell['ptav_ids'])
            //         no_variant_attribute_values = combination - combination._without_no_variant_attributes()
            // 
            //         # create or find product variant from combination
            //         product = product_template._create_product_variant(combination)
            //         # TODO replace the check on product_id by a first check on the ptavs and pnavs?
            //         # and only create/require variant after no line has been found ???
            //         order_lines = self.order_line.filtered(lambda line: (line._origin or line).product_id == product and (line._origin or line).product_no_variant_attribute_value_ids == no_variant_attribute_values)
            // 
            //         # if product variant already exist in order lines
            //         old_qty = sum(order_lines.mapped('product_qty'))
            //         qty = cell['qty']
            //         diff = qty - old_qty
            // 
            //         if not diff:
            //             continue
            // 
            //         product_ids.add(product.id)
            // 
            //         if order_lines:
            //             if qty == 0:
            //                 if self.state in ['draft', 'sent']:
            //                     # Remove lines if qty was set to 0 in matrix
            //                     # only if PO state = draft/sent
            //                     self.order_line -= order_lines
            //                 else:
            //                     order_lines.update({'product_qty': 0.0})
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
            //                     raise ValidationError(_("You cannot change the quantity of a product present in multiple purchase lines."))
            //                 else:
            //                     order_lines[0].product_qty = qty
            //                     # If we want to support multiple lines edition:
            //                     # removal of other lines.
            //                     # For now, an error is raised instead
            //                     # if len(order_lines) > 1:
            //                     #     # Remove 1+ lines
            //                     #     self.order_line -= order_lines[1:]
            //         else:
            //             if not default_po_line_vals:
            //                 OrderLine = self.env['purchase.order.line']
            //                 default_po_line_vals = OrderLine.default_get(OrderLine._fields.keys())
            //             last_sequence = self.order_line[-1:].sequence
            //             if last_sequence:
            //                 default_po_line_vals['sequence'] = last_sequence
            //             new_lines.append((0, 0, dict(
            //                 default_po_line_vals,
            //                 product_id=product.id,
            //                 product_qty=qty,
            //                 product_no_variant_attribute_value_ids=no_variant_attribute_values.ids)
            //             ))
            //     if product_ids:
            //         res = False
            //         if new_lines:
            //             # Add new PO lines
            //             self.update(dict(order_line=new_lines))
            // 
            //         # Recompute prices for new/modified lines:
            //         for line in self.order_line.filtered(lambda line: line.product_id.id in product_ids):
            //             line._product_id_change()
            //             res = line.onchange_product_id_warning() or res
            //         return res
            */
            return default;
        }

        protected async Task<PurchaseOrder> ApprovalAllowedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _approval_allowed(self):
            // """Returns whether the order qualifies to be approved by the current user"""
            // self.ensure_one()
            // return (
            //     self.company_id.po_double_validation == 'one_step'
            //     or (self.company_id.po_double_validation == 'two_step'
            //         and self.amount_total < self.env.company.currency_id._convert(
            //             self.company_id.po_double_validation_amount, self.currency_id, self.company_id,
            //             self.date_order or fields.Date.today()))
            //     or self.env.user.has_group('purchase.group_purchase_manager'))
            */
            return default;
        }

        public async Task<PurchaseOrder> BillMatchingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_bill_matching(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Bill Matching"),
            //     'res_model': 'purchase.bill.line.match',
            //     'domain': [
            //         ('partner_id', '=', self.partner_id.id),
            //         ('company_id', 'in', self.env.company.ids),
            //         ('purchase_order_id', 'in', [self.id, False]),
            //     ],
            //     'views': [(self.env.ref('purchase.purchase_bill_line_match_tree').id, 'list')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonApproveAsync(Guid id, object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_approve(self, force=False):
            // self = self.filtered(lambda order: order._approval_allowed())
            // self.write({'state': 'purchase', 'date_approve': fields.Datetime.now()})
            // self.filtered(lambda p: p.company_id.po_lock == 'lock').write({'state': 'done'})
            // return {}
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def button_approve(self, force=False):
            // result = super(PurchaseOrder, self).button_approve(force=force)
            // self._create_picking()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_cancel(self):
            // purchase_orders_with_invoices = self.filtered(lambda po: any(i.state not in ('cancel', 'draft') for i in po.invoice_ids))
            // if purchase_orders_with_invoices:
            //     raise UserError(_("Unable to cancel purchase order(s): %s. You must first cancel their related vendor bills.", format_list(self.env, purchase_orders_with_invoices.mapped('display_name'))))
            // self.write({'state': 'cancel', 'mail_reminder_confirmed': False})
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def button_cancel(self):
            // order_lines_ids = OrderedSet()
            // pickings_to_cancel_ids = OrderedSet()
            // 
            // purchase_orders_with_receipt = self.filtered(lambda po: any(move.state == 'done' for move in po.order_line.move_ids))
            // if purchase_orders_with_receipt:
            //     raise UserError(_("Unable to cancel purchase order(s): %s since they have receipts that are already done.", format_list(self.env, purchase_orders_with_receipt.mapped('display_name'))))
            // for order in self:
            //     # If the product is MTO, change the procure_method of the closest move to purchase to MTS.
            //     # The purpose is to link the po that the user will manually generate to the existing moves's chain.
            //     if order.state in ('draft', 'sent', 'to approve', 'purchase'):
            //         order_lines_ids.update(order.order_line.ids)
            // 
            //     pickings_to_cancel_ids.update(order.picking_ids.filtered(lambda r: r.state != 'cancel').ids)
            // 
            // order_lines = self.env['purchase.order.line'].browse(order_lines_ids)
            // 
            // moves_to_cancel_ids = OrderedSet()
            // moves_to_recompute_ids = OrderedSet()
            // for order_line in order_lines:
            //     moves_to_cancel_ids.update(order_line.move_ids.ids)
            //     if order_line.move_dest_ids:
            //         move_dest_ids = order_line.move_dest_ids.filtered(lambda move: move.state != 'done' and not move.scrapped)
            //         moves_to_mts = move_dest_ids.filtered(lambda move: move.rule_id.route_id != move.location_dest_id.warehouse_id.reception_route_id)
            //         move_dest_ids -= moves_to_mts
            //         moves_to_recompute_ids.update(moves_to_mts.ids)
            //         moves_to_unlink = move_dest_ids.filtered(lambda m: len(m.created_purchase_line_ids.ids) > 1)
            //         if moves_to_unlink:
            //             moves_to_unlink.created_purchase_line_ids = [Command.unlink(order_line.id)]
            //         move_dest_ids -= moves_to_unlink
            //         if order_line.propagate_cancel:
            //             moves_to_cancel_ids.update(move_dest_ids.ids)
            //         else:
            //             moves_to_recompute_ids.update(move_dest_ids.ids)
            //     if order_line.group_id:
            //         order_line.group_id.purchase_line_ids = [Command.unlink(order_line.id)]
            // 
            // if moves_to_cancel_ids:
            //     moves_to_cancel = self.env['stock.move'].browse(moves_to_cancel_ids)
            //     moves_to_cancel._action_cancel()
            // 
            // if moves_to_recompute_ids:
            //     moves_to_recompute = self.env['stock.move'].browse(moves_to_recompute_ids)
            //     moves_to_recompute.write({'procure_method': 'make_to_stock'})
            //     moves_to_recompute._recompute_state()
            // 
            // if pickings_to_cancel_ids:
            //     pikings_to_cancel = self.env['stock.picking'].browse(pickings_to_cancel_ids)
            //     pikings_to_cancel.action_cancel()
            // 
            // if order_lines:
            //     order_lines.write({'move_dest_ids': [(5, 0, 0)]})
            // 
            // return super().button_cancel()
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py) ---
            // def button_cancel(self):
            // result = super(PurchaseOrder, self).button_cancel()
            // self.sudo()._activity_cancel_on_sale()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_confirm(self):
            // for order in self:
            //     if order.state not in ['draft', 'sent']:
            //         continue
            //     order.order_line._validate_analytic_distribution()
            //     order._add_supplier_to_product()
            //     # Deal with double validation process
            //     if order._approval_allowed():
            //         order.button_approve()
            //     else:
            //         order.write({'state': 'to approve'})
            //     if order.partner_id not in order.message_partner_ids:
            //         order.message_subscribe([order.partner_id.id])
            // return True
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def button_confirm(self):
            // if self.alternative_po_ids and not self.env.context.get('skip_alternative_check', False):
            //     alternative_po_ids = self.alternative_po_ids.filtered(lambda po: po.state in ['draft', 'sent', 'to approve'] and po.id not in self.ids)
            //     if alternative_po_ids:
            //         view = self.env.ref('purchase_requisition.purchase_requisition_alternative_warning_form')
            //         return {
            //             'name': _("What about the alternative Requests for Quotations?"),
            //             'type': 'ir.actions.act_window',
            //             'view_mode': 'form',
            //             'res_model': 'purchase.requisition.alternative.warning',
            //             'views': [(view.id, 'form')],
            //             'target': 'new',
            //             'context': dict(self.env.context, default_alternative_po_ids=alternative_po_ids.ids, default_po_ids=self.ids),
            //         }
            // res = super(PurchaseOrder, self).button_confirm()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_done(self):
            // self.write({'state': 'done', 'priority': '0'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_draft(self):
            // self.write({'state': 'draft'})
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ButtonUnlockAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_unlock(self):
            // self.write({'state': 'purchase'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> CheckOrderLineCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
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

        public async Task<PurchaseOrder> CompareAlternativeLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def action_compare_alternative_lines(self):
            // ctx = dict(
            //     self.env.context,
            //     search_default_groupby_product=True,
            //     purchase_order_id=self.id,
            // )
            // view_id = self.env.ref('purchase_requisition.purchase_order_line_compare_tree').id
            // return {
            //     'name': _('Compare Order Lines'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list',
            //     'res_model': 'purchase.order.line',
            //     'views': [(view_id, "list")],
            //     'domain': [('order_id', 'in', (self | self.alternative_po_ids).ids), ('display_type', '=', False)],
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> ComputeAccessUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_access_url(self):
            // super(PurchaseOrder, self)._compute_access_url()
            // for order in self:
            //     order.access_url = '/my/purchase/%s' % (order.id)
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeAmountTotalCcInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_amount_total_cc(self):
            // for order in self:
            //     order.amount_total_cc = order.amount_total / order.currency_rate
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
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

        protected async Task<PurchaseOrder> ComputeDateCalendarStartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_date_calendar_start(self):
            // for order in self:
            //     order.date_calendar_start = order.date_approve if (order.state in ['purchase', 'done']) else order.date_order
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDatePlannedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_date_planned(self):
            // """ date_planned = the earliest date_planned across all order lines. """
            // for order in self:
            //     dates_list = order.order_line.filtered(lambda x: not x.display_type and x.date_planned).mapped('date_planned')
            //     if dates_list:
            //         order.date_planned = min(dates_list)
            //     else:
            //         order.date_planned = False
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDestAddressIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py) ---
            // def _compute_dest_address_id(self):
            // dropship_subcontract_pos = self.filtered(lambda po: po.default_location_dest_id_is_subcontracting_loc)
            // for order in dropship_subcontract_pos:
            //     subcontractor_ids = order.picking_type_id.default_location_dest_id.subcontractor_ids
            //     order.dest_address_id = subcontractor_ids if len(subcontractor_ids) == 1 else False
            // super(PurchaseOrder, self - dropship_subcontract_pos)._compute_dest_address_id()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_dest_address_id(self):
            // self.filtered(lambda po: po.picking_type_id.default_location_dest_id.usage != 'customer').dest_address_id = False
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_display_name(self):
            // for po in self:
            //     name = po.name
            //     if po.partner_ref:
            //         name += ' (' + po.partner_ref + ')'
            //     if self.env.context.get('show_total_amount') and po.amount_total:
            //         name += ': ' + formatLang(self.env, po.amount_total, currency_obj=po.currency_id)
            //     po.display_name = name
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_effective_date(self):
            // for order in self:
            //     pickings = order.picking_ids.filtered(lambda x: x.state == 'done' and x.location_dest_id.usage != 'supplier' and x.date_done)
            //     order.effective_date = min(pickings.mapped('date_done'), default=False)
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeHasAlternativesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _compute_has_alternatives(self):
            // self.has_alternatives = False
            // if self.env.user.has_group('purchase_requisition.group_purchase_alternatives'):
            //     self.filtered(lambda po: po.purchase_group_id).has_alternatives = True
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeIncomingPickingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_incoming_picking_count(self):
            // for order in self:
            //     order.incoming_picking_count = len(order.picking_ids)
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py) ---
            // def _compute_incoming_picking_count(self):
            // super()._compute_incoming_picking_count()
            // for order in self:
            //     dropship_count = len(order.picking_ids.filtered(lambda p: p.is_dropship))
            //     order.incoming_picking_count -= dropship_count
            //     order.dropship_picking_count = dropship_count
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_invoice(self):
            // for order in self:
            //     invoices = order.mapped('order_line.invoice_lines.move_id')
            //     order.invoice_ids = invoices
            //     order.invoice_count = len(invoices)
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeIsShippedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_is_shipped(self):
            // for order in self:
            //     if order.picking_ids and all(x.state in ['done', 'cancel'] for x in order.picking_ids):
            //         order.is_shipped = True
            //     else:
            //         order.is_shipped = False
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeL10nInGstTreatmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_purchase, FILE: purchase_order.py) ---
            // def _compute_l10n_in_gst_treatment(self):
            // for order in self:
            //     # set default value as False so CacheMiss error never occurs for this field.
            //     order.l10n_in_gst_treatment = False
            //     if order.country_code == 'IN':
            //         l10n_in_gst_treatment = order.partner_id.l10n_in_gst_treatment
            //         if not l10n_in_gst_treatment and order.partner_id.country_id and order.partner_id.country_id.code != 'IN':
            //             l10n_in_gst_treatment = 'overseas'
            //         if not l10n_in_gst_treatment:
            //             l10n_in_gst_treatment = order.partner_id.vat and 'regular' or 'consumer'
            //         order.l10n_in_gst_treatment = l10n_in_gst_treatment
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeMrpProductionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _compute_mrp_production_count(self):
            // for purchase in self:
            //     purchase.mrp_production_count = len(purchase._get_mrp_productions())
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeOnTimeRatePercInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase.py) ---
            // def _compute_on_time_rate_perc(self):
            // for po in self:
            //     if po.on_time_rate >= 0:
            //         po.on_time_rate_perc = po.on_time_rate / 100
            //     else:
            //         po.on_time_rate_perc = -1
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputePickingIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_picking_ids(self):
            // for order in self:
            //     order.picking_ids = order.order_line.move_ids.picking_id
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeReceiptReminderEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_receipt_reminder_email(self):
            // for order in self:
            //     order.receipt_reminder_email = order.partner_id.with_company(order.company_id).receipt_reminder_email
            //     order.reminder_date_before_receipt = order.partner_id.with_company(order.company_id).reminder_date_before_receipt
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeReceiptStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _compute_receipt_status(self):
            // for order in self:
            //     if not order.picking_ids or all(p.state == 'cancel' for p in order.picking_ids):
            //         order.receipt_status = False
            //     elif all(p.state in ['done', 'cancel'] for p in order.picking_ids):
            //         order.receipt_status = 'full'
            //     elif any(p.state == 'done' for p in order.picking_ids):
            //         order.receipt_status = 'partial'
            //     else:
            //         order.receipt_status = 'pending'
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeRepairCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_repair, FILE: purchase_order.py) ---
            // def _compute_repair_count(self):
            // for purchase in self:
            //     purchase.repair_count = len(purchase.order_line.move_dest_ids.repair_id)
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py) ---
            // def _compute_sale_order_count(self):
            // for purchase in self:
            //     purchase.sale_order_count = len(purchase._get_sale_orders())
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _compute_sale_order_count(self):
            // super()._compute_sale_order_count()
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeSubcontractingResupplyPickingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py) ---
            // def _compute_subcontracting_resupply_picking_count(self):
            // for purchase in self:
            //     purchase.subcontracting_resupply_picking_count = len(purchase._get_subcontracting_resupplies())
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_country_id(self):
            // for record in self:
            //     if record.fiscal_position_id.foreign_vat:
            //         record.tax_country_id = record.fiscal_position_id.country_id
            //     else:
            //         record.tax_country_id = record.company_id.account_fiscal_country_id
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_id(self):
            // """
            // Trigger the recompute of the taxes if the fiscal position is changed on the PO.
            // """
            // self.order_line._compute_tax_id()
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_totals(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     if not order.company_id:
            //         order.tax_totals = False
            //         continue
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     order.tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            //     if order.currency_id != order.company_currency_id:
            //         order.tax_totals['amount_total_cc'] = f"({formatLang(self.env, order.amount_total_cc, currency_obj=self.company_currency_id)})"
            */
            return default;
        }

        protected async Task<PurchaseOrder> ConfirmReceptionMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _confirm_reception_mail(self):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reception_confirmed:
            //         order.mail_reception_confirmed = True
            //         order.message_post(body=_("The order receipt has been acknowledged by %s.", order.partner_id.name))
            //     elif order.state == 'sent' and not order.mail_reception_confirmed:
            //         order.mail_reception_confirmed = True
            //         order.message_post(body=_("The RFQ has been acknowledged by %s.", order.partner_id.name))
            */
            return default;
        }

        public async Task<PurchaseOrder> ConfirmReminderMailAsync(Guid id, object confirmed_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def confirm_reminder_mail(self, confirmed_date=False):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reminder_confirmed:
            //         order.mail_reminder_confirmed = True
            //         date_planned = order.get_localized_date_planned(confirmed_date).date()
            //         order.message_post(body=_("%(vendor)s confirmed the receipt will take place on %(date)s.", vendor=order.partner_id.name, date=date_planned))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> CreateAlternativeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def action_create_alternative(self):
            // ctx = dict(**self.env.context, default_origin_po_id=self.id)
            // return {
            //     'name': _('Create alternative'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'purchase.requisition.create.alternative',
            //     'view_id': self.env.ref('purchase_requisition.purchase_requisition_create_alternative_form').id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<PurchaseOrder> CreateAsync(PurchaseOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def create(self, vals_list):
            // orders = self.browse()
            // partner_vals_list = []
            // for vals in vals_list:
            //     company_id = vals.get('company_id', self.default_get(['company_id'])['company_id'])
            //     # Ensures default picking type and currency are taken from the right company.
            //     self_comp = self.with_company(company_id)
            //     if vals.get('name', 'New') == 'New':
            //         seq_date = None
            //         if 'date_order' in vals:
            //             seq_date = fields.Datetime.context_timestamp(self, fields.Datetime.to_datetime(vals['date_order']))
            //         vals['name'] = self_comp.env['ir.sequence'].next_by_code('purchase.order', sequence_date=seq_date) or '/'
            //     vals, partner_vals = self._write_partner_values(vals)
            //     partner_vals_list.append(partner_vals)
            //     orders |= super(PurchaseOrder, self_comp).create(vals)
            // for order, partner_vals in zip(orders, partner_vals_list):
            //     if partner_vals:
            //         order.sudo().write(partner_vals)  # Because the purchase user doesn't have write on `res.partner`
            // return orders
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def create(self, vals_list):
            // orders = super().create(vals_list)
            // if self.env.context.get('origin_po_id'):
            //     # po created as an alt to another PO:
            //     origin_po_id = self.env['purchase.order'].browse(self.env.context.get('origin_po_id'))
            //     if origin_po_id.purchase_group_id:
            //         origin_po_id.purchase_group_id.order_ids |= orders
            //     else:
            //         self.env['purchase.order.group'].create({'order_ids': [Command.set(origin_po_id.ids + orders.ids)]})
            // for order in orders:
            //     if order.requisition_id:
            //         order.message_post_with_source(
            //             'mail.message_origin_link',
            //             render_values={'self': order, 'origin': order.requisition_id},
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return orders
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PurchaseOrder> CreateDownpaymentsInternalAsync(object line_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _create_downpayments(self, line_vals):
            // self.ensure_one()
            // 
            // # create section
            // if not any(line.display_type and line.is_downpayment for line in self.order_line):
            //     section_line = self.order_line.create(self._prepare_down_payment_section_values())
            // else:
            //     section_line = self.order_line.filtered(lambda line: line.display_type and line.is_downpayment)
            // vals = [
            //     {
            //         **line_val,
            //         'sequence': section_line.sequence + i,
            //     }
            //     for i, line_val in enumerate(line_vals, start=1)
            // ]
            // downpayment_lines = self.env['purchase.order.line'].create(vals)
            // self.order_line = [
            //     Command.link(line_id)
            //     for line_id in downpayment_lines.ids
            // ]  # a simple concatenation would cause all order_line to recompute, we do not want it to happen
            // return downpayment_lines
            */
            return default;
        }

        public async Task<PurchaseOrder> CreateInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_create_invoice(self):
            // """Create the invoice associated to the PO.
            // """
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // 
            // # 1) Prepare invoice vals and clean-up the section lines
            // invoice_vals_list = []
            // sequence = 10
            // for order in self:
            //     if order.invoice_status != 'to invoice':
            //         continue
            // 
            //     order = order.with_company(order.company_id)
            //     pending_section = None
            //     # Invoice values.
            //     invoice_vals = order._prepare_invoice()
            //     # Invoice line values (keep only necessary sections).
            //     for line in order.order_line:
            //         if line.display_type == 'line_section':
            //             pending_section = line
            //             continue
            //         if not float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //             if pending_section:
            //                 line_vals = pending_section._prepare_account_move_line()
            //                 line_vals.update({'sequence': sequence})
            //                 invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //                 sequence += 1
            //                 pending_section = None
            //             line_vals = line._prepare_account_move_line()
            //             line_vals.update({'sequence': sequence})
            //             invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //             sequence += 1
            //     invoice_vals_list.append(invoice_vals)
            // 
            // if not invoice_vals_list:
            //     raise UserError(_('There is no invoiceable line. If a product has a control policy based on received quantity, please make sure that a quantity has been received.'))
            // 
            // # 2) group by (company_id, partner_id, currency_id) for batch creation
            // new_invoice_vals_list = []
            // for grouping_keys, invoices in groupby(invoice_vals_list, key=lambda x: (x.get('company_id'), x.get('partner_id'), x.get('currency_id'))):
            //     origins = set()
            //     payment_refs = set()
            //     refs = set()
            //     ref_invoice_vals = None
            //     for invoice_vals in invoices:
            //         if not ref_invoice_vals:
            //             ref_invoice_vals = invoice_vals
            //         else:
            //             ref_invoice_vals['invoice_line_ids'] += invoice_vals['invoice_line_ids']
            //         origins.add(invoice_vals['invoice_origin'])
            //         payment_refs.add(invoice_vals['payment_reference'])
            //         refs.add(invoice_vals['ref'])
            //     ref_invoice_vals.update({
            //         'ref': ', '.join(refs)[:2000],
            //         'invoice_origin': ', '.join(origins),
            //         'payment_reference': len(payment_refs) == 1 and payment_refs.pop() or False,
            //     })
            //     new_invoice_vals_list.append(ref_invoice_vals)
            // invoice_vals_list = new_invoice_vals_list
            // 
            // # 3) Create invoices.
            // moves = self.env['account.move']
            // AccountMove = self.env['account.move'].with_context(default_move_type='in_invoice')
            // for vals in invoice_vals_list:
            //     moves |= AccountMove.with_company(vals['company_id']).create(vals)
            // 
            // # 4) Some moves might actually be refunds: convert them if the total amount is negative
            // # We do this after the moves have been created since we need taxes, etc. to know if the total
            // # is actually negative or not
            // moves.filtered(lambda m: m.currency_id.round(m.amount_total) < 0).action_switch_move_type()
            // 
            // return self.action_view_invoice(moves)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> CreatePickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _create_picking(self):
            // StockPicking = self.env['stock.picking']
            // for order in self.filtered(lambda po: po.state in ('purchase', 'done')):
            //     if any(product.type == 'consu' for product in order.order_line.product_id):
            //         order = order.with_company(order.company_id)
            //         pickings = order.picking_ids.filtered(lambda x: x.state not in ('done', 'cancel'))
            //         if not pickings:
            //             res = order._prepare_picking()
            //             picking = StockPicking.with_user(SUPERUSER_ID).create(res)
            //             pickings = picking
            //         else:
            //             picking = pickings[0]
            //         moves = order.order_line._create_stock_moves(picking)
            //         moves = moves.filtered(lambda x: x.state not in ('done', 'cancel'))._action_confirm()
            //         seq = 0
            //         for move in sorted(moves, key=lambda move: move.date):
            //             seq += 5
            //             move.sequence = seq
            //         moves._action_assign()
            //         # Get following pickings (created by push rules) to confirm them as well.
            //         forward_pickings = self.env['stock.picking']._get_impacted_pickings(moves)
            //         (pickings | forward_pickings).action_confirm()
            //         picking.message_post_with_source(
            //             'mail.message_origin_link',
            //             render_values={'self': picking, 'origin': order},
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return True
            */
            return default;
        }

        protected async Task<PurchaseOrder> CreateUpdateDateActivityInternalAsync(object updated_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _create_update_date_activity(self, updated_dates):
            // note = Markup('<p>%s</p>\n') % _('%s modified receipt dates for the following products:', self.partner_id.name)
            // for line, date in updated_dates:
            //     note += Markup('<p> - %s</p>\n') % _(
            //         '%(product)s from %(original_receipt_date)s to %(new_receipt_date)s',
            //         product=line.product_id.display_name,
            //         original_receipt_date=line.date_planned.date(),
            //         new_receipt_date=date.date()
            //     )
            // activity = self.activity_schedule(
            //     'mail.mail_activity_data_warning',
            //     summary=_("Date Updated"),
            //     user_id=self.user_id.id
            // )
            // # add the note after we post the activity because the note can be soon
            // # changed when updating the date of the next PO line. So instead of
            // # sending a mail with incomplete note, we send one with no note.
            // activity.note = note
            // return activity
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _create_update_date_activity(self, updated_dates):
            // activity = super()._create_update_date_activity(updated_dates)
            // self._add_picking_info(activity)
            */
            return default;
        }

        protected async Task<PurchaseOrder> DeclineReceptionMailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _decline_reception_mail(self):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reception_declined:
            //         order.mail_reception_declined = True
            //         order.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('The vendor asked to decline this confirmed RfQ, if you agree on that, cancel this PO'))
            //         order.message_post(body=_("The order receipt has been declined by %s.", order.partner_id.name))
            //     elif order.state  == 'sent' and not order.mail_reception_declined:
            //         order.mail_reception_declined = True
            //         order.message_post(body=_("The RFQ has been declined by %s.", order.partner_id.name))
            */
            return default;
        }

        protected async Task<PurchaseOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['purchase.order.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        protected async Task<PurchaseOrder> DefaultPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _default_picking_type(self):
            // return self._get_picking_type(self.env.context.get('company_id') or self.env.company.id)
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'display_uom': self.env.user.has_group('uom.group_uom'),
            //     'precision': self.env['decimal.precision'].precision_get('Product Unit of Measure'),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            //     'search_default_seller_ids': self.partner_id.name,
            // }
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetActionViewPickingInternalAsync(object pickings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _get_action_view_picking(self, pickings):
            // """ This function returns an action that display existing picking orders of given purchase order ids. When only one found, show the picking immediately.
            // """
            // self.ensure_one()
            // result = self.env["ir.actions.actions"]._for_xml_id('stock.action_picking_tree_all')
            // # override the context to get rid of the default filtering on operation type
            // result['context'] = {'default_partner_id': self.partner_id.id, 'default_origin': self.name, 'default_picking_type_id': self.picking_type_id.id}
            // # choose the view_mode accordingly
            // if not pickings or len(pickings) > 1:
            //     result['domain'] = [('id', 'in', pickings.ids)]
            // elif len(pickings) == 1:
            //     res = self.env.ref('stock.view_picking_form', False)
            //     form_view = [(res and res.id or False, 'form')]
            //     result['views'] = form_view + [(state, view) for state, view in result.get('views', []) if view != 'form']
            //     result['res_id'] = pickings.id
            // return result
            */
            return default;
        }

        public async Task<PurchaseOrder> GetConfirmUrlAsync(Guid id, object confirm_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_confirm_url(self, confirm_type=None):
            // """Create url for confirm reminder or purchase reception email for sending
            // in mail."""
            // if confirm_type in ['reminder', 'reception', 'decline']:
            //     param = url_encode({
            //         'confirm': confirm_type,
            //         'confirmed_date': self.date_planned and self.date_planned.date(),
            //     })
            //     return self.get_portal_url(query_string='&%s' % param)
            // return self.get_portal_url()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> GetDestinationLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py) ---
            // def _get_destination_location(self):
            // self.ensure_one()
            // if self.default_location_dest_id_is_subcontracting_loc:
            //     return self.dest_address_id.property_stock_subcontractor.id
            // return super()._get_destination_location()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _get_destination_location(self):
            // self.ensure_one()
            // if self.dest_address_id and self.picking_type_id.code == "dropship":
            //     return self.dest_address_id.property_stock_customer.id
            // return self.picking_type_id.default_location_dest_id.id
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetEdiBuildersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_edi_builders(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py) ---
            // def _get_edi_builders(self):
            // return super()._get_edi_builders() + [self.env['purchase.edi.xml.ubl_bis3']]
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetFinalLocationRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _get_final_location_record(self):
            // self.ensure_one()
            // if self.picking_type_id.code == 'dropship':
            //     if self.dest_address_id:
            //         return self.dest_address_id.property_stock_customer
            //     return self.picking_type_id.default_location_dest_id
            // return self.picking_type_id.warehouse_id.lot_stock_id
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_invoiced(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for order in self:
            //     if order.state not in ('purchase', 'done'):
            //         order.invoice_status = 'no'
            //         continue
            // 
            //     if any(
            //         not float_is_zero(line.qty_to_invoice, precision_digits=precision)
            //         for line in order.order_line.filtered(lambda l: not l.display_type)
            //     ):
            //         order.invoice_status = 'to invoice'
            //     elif (
            //         all(
            //             float_is_zero(line.qty_to_invoice, precision_digits=precision)
            //             for line in order.order_line.filtered(lambda l: not l.display_type)
            //         )
            //         and order.invoice_ids
            //     ):
            //         order.invoice_status = 'invoiced'
            //     else:
            //         order.invoice_status = 'no'
            */
            return default;
        }

        public async Task<PurchaseOrder> GetLocalizedDatePlannedAsync(Guid id, object date_planned)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_localized_date_planned(self, date_planned=False):
            // """Returns the localized date planned in the timezone of the order's user or the
            // company's partner or UTC if none of them are set."""
            // self.ensure_one()
            // date_planned = date_planned or self.date_planned
            // if not date_planned:
            //     return False
            // if isinstance(date_planned, str):
            //     date_planned = fields.Datetime.from_string(date_planned)
            // tz = self.get_order_timezone()
            // return date_planned.astimezone(tz)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> GetMatrixInternalAsync(object product_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def _get_matrix(self, product_template):
            // def has_ptavs(line, sorted_attr_ids):
            //     ptav = line.product_template_attribute_value_ids.ids
            //     pnav = line.product_no_variant_attribute_value_ids.ids
            //     pav = pnav + ptav
            //     pav.sort()
            //     return pav == sorted_attr_ids
            // matrix = product_template._get_template_matrix(
            //     company_id=self.company_id,
            //     currency_id=self.currency_id)
            // if self.order_line:
            //     lines = matrix['matrix']
            //     order_lines = self.order_line.filtered(lambda line: line.product_template_id == product_template)
            //     for line in lines:
            //         for cell in line:
            //             if not cell.get('name', False):
            //                 line = order_lines.filtered(lambda line: has_ptavs(line, cell['ptav_ids']))
            //                 if line:
            //                     cell.update({
            //                         'qty': sum(line.mapped('product_qty'))
            //                     })
            // return matrix
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetMrpProductionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py) ---
            // def _get_mrp_productions(self, **kwargs):
            // productions = super()._get_mrp_productions(**kwargs)
            // if kwargs.get('remove_archived_picking_types', True):
            //     productions = productions.filtered(lambda production: production.with_context(active_test=False).picking_type_id.active)
            // return productions
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _get_mrp_productions(self, **kwargs):
            // linked_mo = self.order_line.move_dest_ids.group_id.mrp_production_ids \
            //           | self.env['stock.move'].browse(self.order_line.move_ids._rollup_move_dests()).group_id.mrp_production_ids
            // group_mo = self.order_line.group_id.mrp_production_ids
            // 
            // return linked_mo | group_mo
            */
            return default;
        }

        public async Task<PurchaseOrder> GetOrderTimezoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_order_timezone(self):
            // """ Returns the timezone of the order's user or the company's partner
            // or UTC if none of them are set. """
            // self.ensure_one()
            // return timezone(self.user_id.tz or self.company_id.partner_id.tz or 'UTC')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> GetOrdersToRemindInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_orders_to_remind(self):
            // """When auto sending a reminder mail, only send for unconfirmed purchase
            // order and not all products are service."""
            // return self.search([
            //     ('partner_id', '!=', False),
            //     ('state', 'in', ['purchase', 'done']),
            //     ('mail_reminder_confirmed', '=', False)
            // ]).filtered(lambda p: p.partner_id.with_company(p.company_id).receipt_reminder_email and\
            //     p.mapped('order_line.product_id.product_tmpl_id.type') != ['service'])
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _get_orders_to_remind(self):
            // """When auto sending reminder mails, don't send for purchase order with
            // validated receipts."""
            // return super()._get_orders_to_remind().filtered(lambda p: not p.effective_date)
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetPickingTypeInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _get_picking_type(self, company_id):
            // picking_type = self.env['stock.picking.type'].search([('code', '=', 'incoming'), ('warehouse_id.company_id', '=', company_id)])
            // if not picking_type:
            //     picking_type = self.env['stock.picking.type'].search([('code', '=', 'incoming'), ('warehouse_id', '=', False)])
            // if not picking_type:
            //     picking_type = self.env['stock.picking.type'].with_context(active_test=False).search([('code', '=', 'incoming'), ('warehouse_id', '=', False)])
            // return picking_type[:1]
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_domain(self):
            // return expression.AND([super()._get_product_catalog_domain(), [('purchase_ok', '=', True)]])
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // res = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     res[product.id] |= self._get_product_price_and_data(product)
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids, object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, child_field=False):
            // grouped_lines = defaultdict(lambda: self.env['purchase.order.line'])
            // for line in self.order_line:
            //     if line.display_type or line.product_id.id not in product_ids:
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_price_and_data(self, product):
            // """ Fetch the product's data used by the purchase's catalog.
            // 
            // :return: the product's price and, if applicable, the minimum quantity to
            //          buy and the product's packaging data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // product_infos = {
            //     'price': product.standard_price,
            //     'uom': {
            //         'display_name': product.uom_id.display_name,
            //         'id': product.uom_id.id,
            //     },
            // }
            // if product.purchase_line_warn_msg:
            //     product_infos['warning'] = product.purchase_line_warn_msg
            // if product.purchase_line_warn == "block":
            //     product_infos['readOnly'] = True
            // if product.uom_id != product.uom_po_id:
            //     product_infos['purchase_uom'] = {
            //         'display_name': product.uom_po_id.display_name,
            //         'id': product.uom_po_id.id,
            //     }
            // params = {'order_id': self}
            // # Check if there is a price and a minimum quantity for the order's vendor.
            // seller = product._select_seller(
            //     partner_id=self.partner_id,
            //     quantity=None,
            //     date=self.date_order and self.date_order.date(),
            //     uom_id=product.uom_id,
            //     ordered_by='min_qty',
            //     params=params
            // )
            // if seller:
            //     product_infos.update(
            //         price=seller.price_discounted,
            //         min_qty=seller.min_qty,
            //     )
            // # Check if the product uses some packaging.
            // packaging = self.env['product.packaging'].search(
            //     [('product_id', '=', product.id), ('purchase', '=', True)], limit=1
            // )
            // if packaging:
            //     qty = packaging.product_uom_id._compute_quantity(packaging.qty, product.uom_po_id)
            //     product_infos.update(
            //         packaging={
            //             'id': packaging.id,
            //             'name': packaging.display_name,
            //             'qty': qty,
            //         }
            //     )
            // return product_infos
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_report_base_filename(self):
            // self.ensure_one()
            // return 'Purchase Order-%s' % (self.name)
            */
            return default;
        }

        public async Task<PurchaseOrder> GetReportMatrixesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def get_report_matrixes(self):
            // """Reporting method."""
            // matrixes = []
            // if self.report_grids:
            //     grid_configured_templates = self.order_line.filtered('is_configurable_product').product_template_id
            //     # TODO is configurable product and product_variant_count > 1
            //     # configurable products are only configured through the matrix in purchase, so no need to check product_add_mode.
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> GetSaleOrdersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py) ---
            // def _get_sale_orders(self):
            // return self.order_line.sale_order_id
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _get_sale_orders(self):
            // linked_so = self.order_line.move_dest_ids.group_id.sale_id \
            //           | self.env['stock.move'].browse(self.order_line.move_ids._rollup_move_dests()).group_id.sale_id
            // group_so = self.order_line.group_id.sale_id
            // 
            // return super()._get_sale_orders() | linked_so | group_so
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetSubcontractingResuppliesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py) ---
            // def _get_subcontracting_resupplies(self):
            // moves_subcontracted = self.order_line.move_ids.filtered(lambda m: m.is_subcontract)
            // subcontracted_productions = moves_subcontracted.move_orig_ids.production_id
            // return subcontracted_productions.picking_ids
            */
            return default;
        }

        public async Task<PurchaseOrder> GetTenderBestLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def get_tender_best_lines(self):
            // product_to_best_price_line = defaultdict(lambda: self.env['purchase.order.line'])
            // product_to_best_date_line = defaultdict(lambda: self.env['purchase.order.line'])
            // product_to_best_price_unit = defaultdict(lambda: self.env['purchase.order.line'])
            // po_alternatives = self | self.alternative_po_ids
            // 
            // for line in po_alternatives.order_line:
            //     if not line.product_qty or not line.price_total_cc or line.state in ['cancel', 'purchase', 'done']:
            //         continue
            // 
            //     # if no best price line => no best price unit line either
            //     if not product_to_best_price_line[line.product_id]:
            //         product_to_best_price_line[line.product_id] = line
            //         product_to_best_price_unit[line.product_id] = line
            //     else:
            //         price_subtotal = line.price_total_cc
            //         price_unit = line.price_total_cc / line.product_qty
            //         current_price_subtotal = product_to_best_price_line[line.product_id][0].price_total_cc
            //         current_price_unit = product_to_best_price_unit[line.product_id][0].price_total_cc / product_to_best_price_unit[line.product_id][0].product_qty
            // 
            //         if current_price_subtotal > price_subtotal:
            //             product_to_best_price_line[line.product_id] = line
            //         elif current_price_subtotal == price_subtotal:
            //             product_to_best_price_line[line.product_id] |= line
            //         if current_price_unit > price_unit:
            //             product_to_best_price_unit[line.product_id] = line
            //         elif current_price_unit == price_unit:
            //             product_to_best_price_unit[line.product_id] |= line
            // 
            //     if not product_to_best_date_line[line.product_id] or product_to_best_date_line[line.product_id][0].date_planned > line.date_planned:
            //         product_to_best_date_line[line.product_id] = line
            //     elif product_to_best_date_line[line.product_id][0].date_planned == line.date_planned:
            //         product_to_best_date_line[line.product_id] |= line
            // 
            // best_price_ids = set()
            // best_date_ids = set()
            // best_price_unit_ids = set()
            // for lines in product_to_best_price_line.values():
            //     best_price_ids.update(lines.ids)
            // for lines in product_to_best_date_line.values():
            //     best_date_ids.update(lines.ids)
            // for lines in product_to_best_price_unit.values():
            //     best_price_unit_ids.update(lines.ids)
            // return list(best_price_ids), list(best_date_ids), list(best_price_unit_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> GetUpdateUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_update_url(self):
            // """Create portal url for user to update the scheduled date on purchase
            // order lines."""
            // update_param = url_encode({'update': 'True'})
            // return self.get_portal_url(query_string='&%s' % update_param)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> IsReadonlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _is_readonly(self):
            // """ Return whether the purchase order is read-only or not based on the state.
            // A purchase order is considered read-only if its state is 'cancel'.
            // 
            // :return: Whether the purchase order is read-only or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.state == 'cancel'
            */
            return default;
        }

        protected async Task<PurchaseOrder> LogDecreaseOrderedQuantityInternalAsync(object purchase_order_lines_quantities)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _log_decrease_ordered_quantity(self, purchase_order_lines_quantities):
            // 
            // def _keys_in_groupby(move):
            //     """ group by picking and the responsible for the product the
            //     move.
            //     """
            //     return (move.picking_id, move.product_id.responsible_id)
            // 
            // def _render_note_exception_quantity_po(order_exceptions):
            //     order_line_ids = self.env['purchase.order.line'].browse([order_line.id for order in order_exceptions.values() for order_line in order[0]])
            //     purchase_order_ids = order_line_ids.mapped('order_id')
            //     move_ids = self.env['stock.move'].concat(*rendering_context.keys())
            //     impacted_pickings = move_ids.mapped('picking_id')._get_impacted_pickings(move_ids) - move_ids.mapped('picking_id')
            //     values = {
            //         'purchase_order_ids': purchase_order_ids,
            //         'order_exceptions': order_exceptions.values(),
            //         'impacted_pickings': impacted_pickings,
            //     }
            //     return self.env['ir.qweb']._render('purchase_stock.exception_on_po', values)
            // 
            // documents = self.env['stock.picking']._log_activity_get_documents(purchase_order_lines_quantities, 'move_ids', 'DOWN', _keys_in_groupby)
            // filtered_documents = {}
            // for (parent, responsible), rendering_context in documents.items():
            //     if parent._name == 'stock.picking':
            //         if parent.state in ['cancel', 'done']:
            //             continue
            //     filtered_documents[(parent, responsible)] = rendering_context
            // self.env['stock.picking']._log_activity(_render_note_exception_quantity_po, filtered_documents)
            */
            return default;
        }

        protected async Task<PurchaseOrder> MergeAlternativePoInternalAsync(object rfqs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _merge_alternative_po(self, rfqs):
            // pass
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _merge_alternative_po(self, rfqs):
            // if self.alternative_po_ids:
            //     super()._merge_alternative_po(rfqs)
            //     self.alternative_po_ids += rfqs.mapped('alternative_po_ids')
            */
            return default;
        }

        public async Task<PurchaseOrder> MergeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_merge(self):
            // all_origin = []
            // all_vendor_references = []
            // rfq_to_merge = self.filtered(lambda r: r.state in ['draft', 'sent'])
            // 
            // # Group RFQs by vendor
            // if len(rfq_to_merge) < 2:
            //     raise UserError(_("Please select at least two purchase orders with state RFQ and RFQ sent to merge."))
            // 
            // rfqs_grouped = defaultdict(lambda: self.env['purchase.order'])
            // for rfq in rfq_to_merge:
            //     key = self._prepare_grouped_data(rfq)
            //     rfqs_grouped[key] += rfq
            // 
            // bunches_of_rfq_to_be_merge = list(rfqs_grouped.values())
            // if all(len(rfq_bunch) == 1 for rfq_bunch in list(bunches_of_rfq_to_be_merge)):
            //     raise UserError(_("In selected purchase order to merge these details must be same\nVendor, currency, destination, dropship address and agreement"))
            // bunches_of_rfq_to_be_merge = [rfqs for rfqs in bunches_of_rfq_to_be_merge if len(rfqs) > 1]
            // 
            // for rfqs in bunches_of_rfq_to_be_merge:
            //     if len(rfqs) <= 1:
            //         continue
            //     oldest_rfq = min(rfqs, key=lambda r: r.date_order)
            //     if oldest_rfq:
            //         # Merge RFQs into the oldest purchase order
            //         rfqs -= oldest_rfq
            //         for rfq_line in rfqs.order_line:
            //             existing_line = oldest_rfq.order_line.filtered(lambda l: l.display_type not in ['line_note', 'line_section'] and
            //                                                                         l.product_id == rfq_line.product_id and
            //                                                                         l.product_uom == rfq_line.product_uom and
            //                                                                         l.product_packaging_id == rfq_line.product_packaging_id and
            //                                                                         l.product_packaging_qty == rfq_line.product_packaging_qty and
            //                                                                         l.analytic_distribution == rfq_line.analytic_distribution and
            //                                                                         l.discount == rfq_line.discount and
            //                                                                         abs(l.date_planned - rfq_line.date_planned).total_seconds() <= 86400  # 24 hours in seconds
            //                                                                 )
            //             if len(existing_line) > 1:
            //                 existing_line[0].product_qty += sum(existing_line[1:].mapped('product_qty'))
            //                 existing_line[1:].unlink()
            //                 existing_line = existing_line[0]
            // 
            //             if existing_line:
            //                 existing_line._merge_po_line(rfq_line)
            //             else:
            //                 rfq_line.order_id = oldest_rfq
            // 
            //         # Merge source documents and vendor references
            //         all_origin = rfqs.mapped('origin')
            //         all_vendor_references = rfqs.mapped('partner_ref')
            // 
            //         oldest_rfq.origin = ', '.join(filter(None, [oldest_rfq.origin, *all_origin]))
            //         oldest_rfq.partner_ref = ', '.join(filter(None, [oldest_rfq.partner_ref, *all_vendor_references]))
            // 
            //         rfq_names = rfqs.mapped('name')
            //         merged_names = ", ".join(rfq_names)
            //         oldest_rfq_message = _("RFQ merged with %(oldest_rfq_name)s and %(cancelled_rfq)s", oldest_rfq_name=oldest_rfq.name, cancelled_rfq=merged_names)
            // 
            //         for rfq in rfqs:
            //             cancelled_rfq_message = _("RFQ merged with %s", oldest_rfq._get_html_link())
            //             rfq.message_post(body=cancelled_rfq_message)
            //         oldest_rfq.message_post(body=oldest_rfq_message)
            // 
            //         rfqs.filtered(lambda r: r.state != 'cancel').button_cancel()
            //         oldest_rfq._merge_alternative_po(rfqs)
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('purchase orders merged'),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> MessagePostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_rfq_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').write({'state': 'sent'})
            // po_ctx = {'mail_post_autofollow': self.env.context.get('mail_post_autofollow', True)}
            // if self.env.context.get('mark_rfq_as_sent') and 'notify_author' not in kwargs:
            //     kwargs['notify_author'] = self.env.user.partner_id.id in (kwargs.get('partner_ids') or [])
            // return super(PurchaseOrder, self.with_context(**po_ctx)).message_post(**kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> MustDeleteDatePlannedInternalAsync(object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _must_delete_date_planned(self, field_name):
            // # To be overridden
            // return field_name == 'order_line'
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def _must_delete_date_planned(self, field_name):
            // return super()._must_delete_date_planned(field_name) or field_name == "grid"
            */
            return default;
        }

        protected async Task<PurchaseOrder> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // subtitles = [render_context['record'].name]
            // # don't show price on RFQ mail
            // if self.state in ['draft', 'sent']:
            //     subtitles.append(_('Order\N{NO-BREAK SPACE}due\N{NO-BREAK SPACE}%(date)s',
            //         date=format_date(self.env, self.date_order, lang_code=render_context.get('lang'))
            //     ))
            // else:
            //     subtitles.append(format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')))
            // render_context['subtitles'] = subtitles
            // return render_context
            */
            return default;
        }

        protected async Task<PurchaseOrder> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Tweak 'view document' button for portal customers, calling directly
            // routes for confirm specific to PO model. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // try:
            //     customer_portal_group = next(group for group in groups if group[0] == 'portal_customer')
            // except StopIteration:
            //     pass
            // else:
            //     access_opt = customer_portal_group[2].setdefault('button_access', {})
            //     if self.env.context.get('is_reminder'):
            //         access_opt['title'] = _('View')
            //         actions = customer_portal_group[2].setdefault('actions', list())
            //         actions.extend([
            //             {'url': self.get_confirm_url(confirm_type='reminder'), 'title': _('Accept')},
            //             {'url': self.get_update_url(), 'title': _('Update Dates')},
            //         ])
            //     else:
            //         access_opt['title'] = _('View Quotation') if self.state in ('draft', 'sent') else _('View Order')
            //         access_opt['url'] = self.get_confirm_url()
            // 
            // return groups
            */
            return default;
        }

        protected async Task<PurchaseOrder> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _onchange_company_id(self):
            // p_type = self.picking_type_id
            // if not(p_type and p_type.code == 'incoming' and (p_type.warehouse_id.company_id == self.company_id or not p_type.warehouse_id)):
            //     self.picking_type_id = self._get_picking_type(self.company_id.id)
            */
            return default;
        }

        public async Task<PurchaseOrder> OnchangeDatePlannedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_date_planned(self):
            // if self.date_planned:
            //     self.order_line.filtered(lambda line: not line.display_type).date_planned = self.date_planned
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> OnchangePartnerIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_partner_id(self):
            // # Ensures all properties and fiscal positions
            // # are taken with the company of the order
            // # if not defined, with_company doesn't change anything.
            // self = self.with_company(self.company_id)
            // default_currency = self._context.get("default_currency_id")
            // if not self.partner_id:
            //     self.fiscal_position_id = False
            //     self.currency_id = default_currency or self.env.company.currency_id.id
            // else:
            //     self.fiscal_position_id = self.env['account.fiscal.position']._get_fiscal_position(self.partner_id)
            //     self.payment_term_id = self.partner_id.property_supplier_payment_term_id.id
            //     self.currency_id = default_currency or self.partner_id.property_purchase_currency_id.id or self.env.company.currency_id.id
            //     if self.partner_id.buyer_id:
            //         self.user_id = self.partner_id.buyer_id
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> OnchangePartnerIdWarningAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_partner_id_warning(self):
            // if not self.partner_id or not self.env.user.has_group('purchase.group_warning_purchase'):
            //     return
            // 
            // partner = self.partner_id
            // 
            // # If partner has no warning, check its company
            // if partner.purchase_warn == 'no-message' and partner.parent_id:
            //     partner = partner.parent_id
            // 
            // if partner.purchase_warn and partner.purchase_warn != 'no-message':
            //     # Block if partner only has warning but parent company is blocked
            //     if partner.purchase_warn != 'block' and partner.parent_id and partner.parent_id.purchase_warn == 'block':
            //         partner = partner.parent_id
            //     title = _("Warning for %s", partner.name)
            //     message = partner.purchase_warn_msg
            //     warning = {
            //         'title': title,
            //         'message': message
            //     }
            //     if partner.purchase_warn == 'block':
            //         self.update({'partner_id': False})
            //     return {'warning': warning}
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> OnchangePickingTypeIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py) ---
            // def onchange_picking_type_id(self):
            // if self.default_location_dest_id_is_subcontracting_loc:
            //     return {
            //         'warning': {'title': _('Warning'), 'message': _('Please note this purchase order is for subcontracting purposes.')}
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> OnchangeRequisitionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _onchange_requisition_id(self):
            // if not self.requisition_id:
            //     return
            // 
            // self = self.with_company(self.company_id)
            // requisition = self.requisition_id
            // if self.partner_id:
            //     partner = self.partner_id
            // else:
            //     partner = requisition.vendor_id
            // payment_term = partner.property_supplier_payment_term_id
            // 
            // FiscalPosition = self.env['account.fiscal.position']
            // fpos = FiscalPosition.with_company(self.company_id)._get_fiscal_position(partner)
            // 
            // self.partner_id = partner.id
            // self.fiscal_position_id = fpos.id
            // self.payment_term_id = payment_term.id
            // self.company_id = requisition.company_id.id
            // self.currency_id = requisition.currency_id.id
            // if not self.origin or requisition.name not in self.origin.split(', '):
            //     if self.origin:
            //         if requisition.name:
            //             self.origin = self.origin + ', ' + requisition.name
            //     else:
            //         self.origin = requisition.name
            // self.notes = requisition.description
            // if requisition.date_start:
            //     self.date_order = max(fields.Datetime.now(), fields.Datetime.to_datetime(requisition.date_start))
            // else:
            //     self.date_order = fields.Datetime.now()
            // 
            // # Create PO lines if necessary
            // order_lines = []
            // for line in requisition.line_ids:
            //     # Compute name
            //     product_lang = line.product_id.with_context(
            //         lang=partner.lang or self.env.user.lang,
            //         partner_id=partner.id
            //     )
            //     name = product_lang.display_name
            //     if product_lang.description_purchase:
            //         name += '\n' + product_lang.description_purchase
            // 
            //     # Compute taxes
            //     taxes_ids = fpos.map_tax(line.product_id.supplier_taxes_id.filtered(lambda tax: tax.company_id == requisition.company_id)).ids
            // 
            //     # Compute quantity and price_unit
            //     if line.product_uom_id != line.product_id.uom_po_id:
            //         product_qty = line.product_uom_id._compute_quantity(line.product_qty, line.product_id.uom_po_id)
            //         price_unit = line.product_uom_id._compute_price(line.price_unit, line.product_id.uom_po_id)
            //     else:
            //         product_qty = line.product_qty
            //         price_unit = line.price_unit
            // 
            //     if requisition.requisition_type != 'purchase_template':
            //         product_qty = 0
            // 
            //     # Create PO line
            //     order_line_values = line._prepare_purchase_order_line(
            //         name=name, product_qty=product_qty, price_unit=price_unit,
            //         taxes_ids=taxes_ids)
            //     order_lines.append((0, 0, order_line_values))
            // self.order_line = order_lines
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase.py) ---
            // def _onchange_requisition_id(self):
            // super(PurchaseOrder, self)._onchange_requisition_id()
            // if self.requisition_id:
            //     self.picking_type_id = self.requisition_id.picking_type_id.id
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareDownPaymentSectionValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_down_payment_section_values(self):
            // self.ensure_one()
            // context = {'lang': self.partner_id.lang}
            // res = {
            //     'product_qty': 0.0,
            //     'order_id': self.id,
            //     'display_type': 'line_section',
            //     'is_downpayment': True,
            //     'sequence': (self.order_line[-1:].sequence or 9) + 1,
            //     'name': _("Down Payments"),
            // }
            // del context
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareGroupValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_group_vals(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'partner_id': self.partner_id.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py) ---
            // def _prepare_group_vals(self):
            // res = super()._prepare_group_vals()
            // sale_orders = self.order_line.sale_order_id
            // if len(sale_orders) == 1:
            //     res['sale_id'] = sale_orders.id
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareGroupedDataInternalAsync(object rfq)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_grouped_data(self, rfq):
            // return (rfq.partner_id.id, rfq.currency_id.id, rfq.dest_address_id.id)
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _prepare_grouped_data(self, rfq):
            // match_fields = super()._prepare_grouped_data(rfq)
            // return match_fields + (rfq.requisition_id.id,)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_grouped_data(self, rfq):
            // match_fields = super()._prepare_grouped_data(rfq)
            // return match_fields + (rfq.picking_type_id.id,)
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_invoice(self):
            // """Prepare the dict of values to create the new invoice for a purchase order.
            // """
            // self.ensure_one()
            // move_type = self._context.get('default_move_type', 'in_invoice')
            // 
            // partner_invoice = self.env['res.partner'].browse(self.partner_id.address_get(['invoice'])['invoice'])
            // partner_bank_id = self.partner_id.commercial_partner_id.bank_ids.filtered_domain(['|', ('company_id', '=', False), ('company_id', '=', self.company_id.id)])[:1]
            // 
            // invoice_vals = {
            //     'ref': self.partner_ref or '',
            //     'move_type': move_type,
            //     'narration': self.notes,
            //     'currency_id': self.currency_id.id,
            //     'partner_id': partner_invoice.id,
            //     'fiscal_position_id': (self.fiscal_position_id or self.fiscal_position_id._get_fiscal_position(partner_invoice)).id,
            //     'payment_reference': self.partner_ref or '',
            //     'partner_bank_id': partner_bank_id.id,
            //     'invoice_origin': self.name,
            //     'invoice_payment_term_id': self.payment_term_id.id,
            //     'invoice_line_ids': [],
            //     'company_id': self.company_id.id,
            // }
            // return invoice_vals
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_invoice(self):
            // invoice_vals = super()._prepare_invoice()
            // invoice_vals['invoice_incoterm_id'] = self.incoterm_id.id
            // return invoice_vals
            */
            return default;
        }

        protected async Task<PurchaseOrder> PreparePickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_picking(self):
            // res = super()._prepare_picking()
            // if not self.project_id:
            //     return res
            // return {
            //     **res,
            //     'project_id': self.project_id.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_picking(self):
            // if not self.group_id:
            //     self.group_id = self.group_id.create(self._prepare_group_vals())
            // if not self.partner_id.property_stock_supplier.id:
            //     raise UserError(_("You must set a Vendor Location for this partner %s", self.partner_id.name))
            // return {
            //     'picking_type_id': self.picking_type_id.id,
            //     'partner_id': self.partner_id.id,
            //     'user_id': False,
            //     'date': self.date_order,
            //     'origin': self.name,
            //     'location_dest_id': self._get_destination_location(),
            //     'location_id': self.partner_id.property_stock_supplier.id,
            //     'company_id': self.company_id.id,
            //     'state': 'draft',
            // }
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareSupplierInfoInternalAsync(object partner, object line, object price, object currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_supplier_info(self, partner, line, price, currency):
            // # Prepare supplierinfo data when adding a product
            // return {
            //     'partner_id': partner.id,
            //     'sequence': max(line.product_id.seller_ids.mapped('sequence')) + 1 if line.product_id.seller_ids else 1,
            //     'min_qty': 1.0,
            //     'price': price,
            //     'currency_id': currency.id,
            //     'discount': line.discount,
            //     'delay': 0,
            // }
            */
            return default;
        }

        public async Task<PurchaseOrder> PrintQuotationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def print_quotation(self):
            // self.write({'state': "sent"})
            // return self.env.ref('purchase.report_purchase_quotation').report_action(self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> RetrieveDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def retrieve_dashboard(self):
            // """ This function returns the values to populate the custom dashboard in
            //     the purchase order views.
            // """
            // self.browse().check_access('read')
            // 
            // result = {
            //     'all_to_send': 0,
            //     'all_waiting': 0,
            //     'all_late': 0,
            //     'my_to_send': 0,
            //     'my_waiting': 0,
            //     'my_late': 0,
            //     'all_avg_order_value': 0,
            //     'all_avg_days_to_purchase': 0,
            //     'all_total_last_7_days': 0,
            //     'all_sent_rfqs': 0,
            //     'company_currency_symbol': self.env.company.currency_id.symbol
            // }
            // 
            // one_week_ago = fields.Datetime.to_string(fields.Datetime.now() - relativedelta(days=7))
            // 
            // query = """SELECT COUNT(1)
            //            FROM mail_message m
            //            JOIN purchase_order po ON (po.id = m.res_id)
            //            WHERE m.create_date >= %s
            //              AND m.model = 'purchase.order'
            //              AND m.message_type = 'notification'
            //              AND m.subtype_id = %s
            //              AND po.company_id = %s;
            //         """
            // 
            // self.env.cr.execute(query, (one_week_ago, self.env.ref('purchase.mt_rfq_sent').id, self.env.company.id))
            // res = self.env.cr.fetchone()
            // result['all_sent_rfqs'] = res[0] or 0
            // 
            // # easy counts
            // po = self.env['purchase.order']
            // result['all_to_send'] = po.search_count([('state', '=', 'draft')])
            // result['my_to_send'] = po.search_count([('state', '=', 'draft'), ('user_id', '=', self.env.uid)])
            // result['all_waiting'] = po.search_count([('state', '=', 'sent'), ('date_order', '>=', fields.Datetime.now())])
            // result['my_waiting'] = po.search_count([('state', '=', 'sent'), ('date_order', '>=', fields.Datetime.now()), ('user_id', '=', self.env.uid)])
            // result['all_late'] = po.search_count([('state', 'in', ['draft', 'sent', 'to approve']), ('date_order', '<', fields.Datetime.now())])
            // result['my_late'] = po.search_count([('state', 'in', ['draft', 'sent', 'to approve']), ('date_order', '<', fields.Datetime.now()), ('user_id', '=', self.env.uid)])
            // 
            // # Calculated values ('avg order value', 'avg days to purchase', and 'total last 7 days') note that 'avg order value' and
            // # 'total last 7 days' takes into account exchange rate and current company's currency's precision.
            // # This is done via SQL for scalability reasons
            // query = """SELECT AVG(COALESCE(po.amount_total / NULLIF(po.currency_rate, 0), po.amount_total)),
            //                   AVG(extract(epoch from age(po.date_approve,po.create_date)/(24*60*60)::decimal(16,2))),
            //                   SUM(CASE WHEN po.date_approve >= %s THEN COALESCE(po.amount_total / NULLIF(po.currency_rate, 0), po.amount_total) ELSE 0 END)
            //            FROM purchase_order po
            //            WHERE po.state in ('purchase', 'done')
            //              AND po.company_id = %s
            //         """
            // self._cr.execute(query, (one_week_ago, self.env.company.id))
            // res = self.env.cr.fetchone()
            // result['all_avg_days_to_purchase'] = round(res[1] or 0, 2)
            // currency = self.env.company.currency_id
            // result['all_avg_order_value'] = format_amount(self.env, res[0] or 0, currency)
            // result['all_total_last_7_days'] = format_amount(self.env, res[2] or 0, currency)
            // 
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> RfqSendAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_rfq_send(self):
            // '''
            // This function opens a window to compose an email, with the edi purchase template message loaded by default
            // '''
            // self.ensure_one()
            // ir_model_data = self.env['ir.model.data']
            // try:
            //     if self.env.context.get('send_rfq', False):
            //         template_id = ir_model_data._xmlid_lookup('purchase.email_template_edi_purchase')[1]
            //     else:
            //         template_id = ir_model_data._xmlid_lookup('purchase.email_template_edi_purchase_done')[1]
            // except ValueError:
            //     template_id = False
            // try:
            //     compose_form_id = ir_model_data._xmlid_lookup('mail.email_compose_message_wizard_form')[1]
            // except ValueError:
            //     compose_form_id = False
            // ctx = dict(self.env.context or {})
            // ctx.update({
            //     'default_model': 'purchase.order',
            //     'default_res_ids': self.ids,
            //     'default_template_id': template_id,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': "mail.mail_notification_layout_with_responsible_signature",
            //     'email_notification_allow_footer': True,
            //     'force_email': True,
            //     'mark_rfq_as_sent': True,
            // })
            // 
            // # In the case of a RFQ or a PO, we want the "View..." button in line with the state of the
            // # object. Therefore, we pass the model description in the context, in the language in which
            // # the template is rendered.
            // lang = self.env.context.get('lang')
            // if {'default_template_id', 'default_model', 'default_res_id'} <= ctx.keys():
            //     template = self.env['mail.template'].browse(ctx['default_template_id'])
            //     if template and template.lang:
            //         lang = template._render_lang([ctx['default_res_id']])[ctx['default_res_id']]
            // 
            // self = self.with_context(lang=lang)
            // if self.state in ['draft', 'sent']:
            //     ctx['model_description'] = _('Request for Quotation')
            // else:
            //     ctx['model_description'] = _('Purchase Order')
            // 
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form_id, 'form')],
            //     'view_id': compose_form_id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> SendReminderMailInternalAsync(object send_single)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _send_reminder_mail(self, send_single=False):
            // if not self.env.user.has_group('purchase.group_send_reminder'):
            //     return
            // 
            // template = self.env.ref('purchase.email_template_edi_purchase_reminder', raise_if_not_found=False)
            // if template:
            //     orders = self if send_single else self._get_orders_to_remind()
            //     for order in orders:
            //         date = order.date_planned
            //         if date and (send_single or (date - relativedelta(days=order.reminder_date_before_receipt)).date() == datetime.today().date()):
            //             if send_single:
            //                 return order._send_reminder_open_composer(template.id)
            //             else:
            //                 order.with_context(is_reminder=True).message_post_with_source(
            //                     template,
            //                     email_layout_xmlid="mail.mail_notification_layout_with_responsible_signature",
            //                     subtype_xmlid='mail.mt_comment',
            //                 )
            */
            return default;
        }

        protected async Task<PurchaseOrder> SendReminderOpenComposerInternalAsync(Guid template_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _send_reminder_open_composer(self,template_id):
            // self.ensure_one()
            // try:
            //     compose_form_id = self.env['ir.model.data']._xmlid_lookup('mail.email_compose_message_wizard_form')[1]
            // except ValueError:
            //     compose_form_id = False
            // ctx = dict(self.env.context or {})
            // ctx.update({
            //     'default_model': 'purchase.order',
            //     'default_res_ids': self.ids,
            //     'default_template_id': template_id,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': "mail.mail_notification_layout_with_responsible_signature",
            //     'force_email': True,
            //     'mark_rfq_as_sent': True,
            // })
            // lang = self.env.context.get('lang')
            // if {'default_template_id', 'default_model', 'default_res_id'} <= ctx.keys():
            //     template = self.env['mail.template'].browse(ctx['default_template_id'])
            //     if template and template.lang:
            //         lang = template._render_lang([ctx['default_res_id']])[ctx['default_res_id']]
            // self = self.with_context(lang=lang)
            // ctx['model_description'] = _('Purchase Order')
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form_id, 'form')],
            //     'view_id': compose_form_id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            return default;
        }

        public async Task<PurchaseOrder> SendReminderPreviewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def send_reminder_preview(self):
            // self.ensure_one()
            // if not self.env.user.has_group('purchase.group_send_reminder'):
            //     return
            // 
            // template = self.env.ref('purchase.email_template_edi_purchase_reminder', raise_if_not_found=False)
            // if template and self.env.user.email and self.id:
            //     template.with_context(is_reminder=True).send_mail(
            //         self.id,
            //         force_send=True,
            //         raise_exception=False,
            //         email_layout_xmlid="mail.mail_notification_layout_with_responsible_signature",
            //         email_values={'email_to': self.env.user.email, 'recipient_ids': []},
            //     )
            //     return {'toast_message': escape(_("A sample email has been sent to %s.", self.env.user.email))}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrder> SetGridUpInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def _set_grid_up(self):
            // if self.grid_product_tmpl_id:
            //     self.grid_update = False
            //     self.grid = json.dumps(self._get_matrix(self.grid_product_tmpl_id))
            */
            return default;
        }

        protected async Task<PurchaseOrder> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'purchase':
            //     if init_values['state'] == 'to approve':
            //         return self.env.ref('purchase.mt_rfq_approved')
            //     return self.env.ref('purchase.mt_rfq_confirmed')
            // elif 'state' in init_values and self.state == 'to approve':
            //     return self.env.ref('purchase.mt_rfq_confirmed')
            // elif 'state' in init_values and self.state == 'done':
            //     return self.env.ref('purchase.mt_rfq_done')
            // elif 'state' in init_values and self.state == 'sent':
            //     return self.env.ref('purchase.mt_rfq_sent')
            // return super(PurchaseOrder, self)._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<PurchaseOrder> UnlinkIfCancelledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _unlink_if_cancelled(self):
            // for order in self:
            //     if not order.state == 'cancel':
            //         raise UserError(_('In order to delete a purchase order, you must cancel it first.'))
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateDatePlannedForLinesInternalAsync(object updated_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_date_planned_for_lines(self, updated_dates):
            // # create or update the activity
            // activity = self.env['mail.activity'].search([
            //     ('summary', '=', _('Date Updated')),
            //     ('res_model_id', '=', 'purchase.order'),
            //     ('res_id', '=', self.id),
            //     ('user_id', '=', self.user_id.id)], limit=1)
            // if activity:
            //     self._update_update_date_activity(updated_dates, activity)
            // else:
            //     self._create_update_date_activity(updated_dates)
            // 
            // # update the date on PO line
            // for line, date in updated_dates:
            //     line._update_date_planned(date)
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Update purchase order line information for a given product or create
            // a new one if none exists yet.
            // :param int product_id: The product, as a `product.product` id.
            // :return: The unit price of the product, based on the pricelist of the
            //          purchase order and the quantity selected.
            // :rtype: float
            // """
            // self.ensure_one()
            // product_packaging_qty = kwargs.get('product_packaging_qty', False)
            // product_packaging_id = kwargs.get('product_packaging_id', False)
            // pol = self.order_line.filtered(lambda line: line.product_id.id == product_id)
            // if pol:
            //     if product_packaging_qty:
            //         pol.product_packaging_id = product_packaging_id
            //         pol.product_packaging_qty = product_packaging_qty
            //     elif quantity != 0:
            //         pol.product_qty = quantity
            //     elif self.state in ['draft', 'sent']:
            //         price_unit = self._get_product_price_and_data(pol.product_id)['price']
            //         pol.unlink()
            //         return price_unit
            //     else:
            //         pol.product_qty = 0
            // elif quantity > 0:
            //     pol = self.env['purchase.order.line'].create({
            //         'order_id': self.id,
            //         'product_id': product_id,
            //         'product_qty': quantity,
            //         'sequence': ((self.order_line and self.order_line[-1].sequence + 1) or 10),  # put it at the end of the order
            //     })
            //     seller = pol.product_id._select_seller(
            //         partner_id=pol.partner_id,
            //         quantity=pol.product_qty,
            //         date=pol.order_id.date_order and pol.order_id.date_order.date() or fields.Date.context_today(pol),
            //         uom_id=pol.product_uom)
            //     if seller:
            //         # Fix the PO line's price on the seller's one.
            //         pol.price_unit = seller.price_discounted
            // return pol.price_unit_discounted
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateUpdateDateActivityInternalAsync(object updated_dates, object activity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_update_date_activity(self, updated_dates, activity):
            // for line, date in updated_dates:
            //     activity.note += Markup('<p> - %s</p>\n') %  _(
            //         '%(product)s from %(original_receipt_date)s to %(new_receipt_date)s',
            //         product=line.product_id.display_name,
            //         original_receipt_date=line.date_planned.date(),
            //         new_receipt_date=date.date()
            //     )
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def _update_update_date_activity(self, updated_dates, activity):
            // # remove old picking info to update it
            // note_lines = activity.note.split('<p>')
            // note_lines.pop()
            // activity.note = Markup('<p>').join(note_lines)
            // super()._update_update_date_activity(updated_dates, activity)
            // self._add_picking_info(activity)
            */
            return default;
        }

        public async Task<PurchaseOrder> ViewDropshipAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py) ---
            // def action_view_dropship(self):
            // return self._get_action_view_picking(self.picking_ids.filtered(lambda p: p.is_dropship))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewInvoiceAsync(Guid id, object invoices)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_view_invoice(self, invoices=False):
            // """This function returns an action that display existing vendor bills of
            // given purchase order ids. When only one found, show the vendor bill
            // immediately.
            // """
            // if not invoices:
            //     self.invalidate_model(['invoice_ids'])
            //     invoices = self.invoice_ids
            // 
            // result = self.env['ir.actions.act_window']._for_xml_id('account.action_move_in_invoice_type')
            // # choose the view_mode accordingly
            // if len(invoices) > 1:
            //     result['domain'] = [('id', 'in', invoices.ids)]
            // elif len(invoices) == 1:
            //     res = self.env.ref('account.view_move_form', False)
            //     form_view = [(res and res.id or False, 'form')]
            //     if 'views' in result:
            //         result['views'] = form_view + [(state, view) for state, view in result['views'] if view != 'form']
            //     else:
            //         result['views'] = form_view
            //     result['res_id'] = invoices.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // 
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewMrpProductionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def action_view_mrp_productions(self):
            // self.ensure_one()
            // mrp_production_ids = self._get_mrp_productions().ids
            // action = {
            //     'res_model': 'mrp.production',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(mrp_production_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': mrp_production_ids[0],
            //     })
            // else:
            //     action.update({
            //         'name': _("Manufacturing Source of %s", self.name),
            //         'domain': [('id', 'in', mrp_production_ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewPickingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def action_view_picking(self):
            // return self._get_action_view_picking(self.picking_ids)
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py) ---
            // def action_view_picking(self):
            // return self._get_action_view_picking(self.picking_ids.filtered(lambda p: not p.is_dropship))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewRepairOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_repair, FILE: purchase_order.py) ---
            // def action_view_repair_orders(self):
            // self.ensure_one()
            // repair_ids = self.order_line.move_dest_ids.repair_id
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'repair.order',
            //     'views': [[False, 'form']]
            // }
            // if self.repair_count == 1:
            //     action['res_id'] = repair_ids.id
            // elif self.repair_count > 1:
            //     action['name'] = _("Repair Source of %s", self.name)
            //     action['views'] = [[False, 'list']]
            //     action['domain'] = [('id', 'in', repair_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewSaleOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py) ---
            // def action_view_sale_orders(self):
            // self.ensure_one()
            // sale_order_ids = self._get_sale_orders().ids
            // action = {
            //     'res_model': 'sale.order',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(sale_order_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': sale_order_ids[0],
            //     })
            // else:
            //     action.update({
            //         'name': _('Sources Sale Orders %s', self.name),
            //         'domain': [('id', 'in', sale_order_ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrder> ViewSubcontractingResupplyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py) ---
            // def action_view_subcontracting_resupply(self):
            // return self._get_action_view_picking(self._get_subcontracting_resupplies())
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PurchaseOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def write(self, vals):
            // vals, partner_vals = self._write_partner_values(vals)
            // res = super().write(vals)
            // if partner_vals:
            //     self.partner_id.sudo().write(partner_vals)  # Because the purchase user doesn't have write on `res.partner`
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def write(self, vals):
            // if vals.get('purchase_group_id', False):
            //     # store in case linking to a PO with existing linkages
            //     orig_purchase_group = self.purchase_group_id
            // result = super(PurchaseOrder, self).write(vals)
            // if vals.get('requisition_id'):
            //     for order in self:
            //         order.message_post_with_source(
            //             'mail.message_origin_link',
            //             render_values={'self': order, 'origin': order.requisition_id, 'edit': True},
            //             subtype_xmlid='mail.mt_note',
            //         )
            // if vals.get('alternative_po_ids', False):
            //     if not self.purchase_group_id and len(self.alternative_po_ids + self) > len(self):
            //         # this can create a new group + delete an existing one (or more) when linking to already linked PO(s), but this is
            //         # simplier than additional logic checking if exactly 1 exists or merging multiple groups if > 1
            //         self.env['purchase.order.group'].create({'order_ids': [Command.set(self.ids + self.alternative_po_ids.ids)]})
            //     elif self.purchase_group_id and len(self.alternative_po_ids + self) <= 1:
            //         # write in purchase group isn't called so we have to manually unlink obsolete groups here
            //         self.purchase_group_id.unlink()
            // if vals.get('purchase_group_id', False):
            //     # the write is for multiple POs => don't double count the POs of the final group
            //     additional_groups = orig_purchase_group - self.purchase_group_id
            //     if additional_groups:
            //         additional_pos = (additional_groups.order_ids - self.purchase_group_id.order_ids)
            //         additional_groups.unlink()
            //         if additional_pos:
            //             self.purchase_group_id.order_ids |= additional_pos
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py) ---
            // def write(self, vals):
            // if vals.get('order_line') and self.state == 'purchase':
            //     for order in self:
            //         pre_order_line_qty = {order_line: order_line.product_qty for order_line in order.mapped('order_line')}
            // res = super(PurchaseOrder, self).write(vals)
            // if vals.get('order_line') and self.state == 'purchase':
            //     for order in self:
            //         to_log = {}
            //         for order_line in order.order_line:
            //             if pre_order_line_qty.get(order_line, False) and float_compare(pre_order_line_qty[order_line], order_line.product_qty, precision_rounding=order_line.product_uom.rounding) > 0:
            //                 to_log[order_line] = (order_line.product_qty, pre_order_line_qty[order_line])
            //         if to_log:
            //             order._log_decrease_ordered_quantity(to_log)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        protected async Task<PurchaseOrder> WritePartnerValuesInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _write_partner_values(self, vals):
            // partner_values = {}
            // if 'receipt_reminder_email' in vals:
            //     partner_values['receipt_reminder_email'] = vals.pop('receipt_reminder_email')
            // if 'reminder_date_before_receipt' in vals:
            //     partner_values['reminder_date_before_receipt'] = vals.pop('reminder_date_before_receipt')
            // return vals, partner_values
            */
            return default;
        }
    }
}