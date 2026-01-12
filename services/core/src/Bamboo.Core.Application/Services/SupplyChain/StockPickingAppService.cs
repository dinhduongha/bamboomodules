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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockPickingAppService : GenericApplicationService<StockPicking>, IStockPickingAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public StockPickingAppService(IRepository<StockPicking, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<StockPicking> ActionDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _action_done(self):
            // res = super(StockPicking, self)._action_done()
            // for picking in self:
            //     productions_to_done = picking._get_subcontract_production().sudo()
            //     productions_to_done.button_mark_done()
            //     # For concistency, set the date on production move before the date
            //     # on picking. (Traceability report + Product Moves menu item)
            //     production_moves = productions_to_done.move_raw_ids | productions_to_done.move_finished_ids
            //     if production_moves:
            //         minimum_date = min(picking.move_line_ids.mapped('date'))
            //         production_moves.write({'date': minimum_date - timedelta(seconds=1)})
            //         production_moves.move_line_ids.write({'date': minimum_date - timedelta(seconds=1)})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _action_done(self):
            // self.purchase_id.sudo().action_acknowledge()
            // return super()._action_done()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _action_done(self):
            // res = super()._action_done()
            // sale_order_lines_vals = []
            // for move in self.move_ids:
            //     ref_sale = move.picking_id.reference_ids.sale_ids
            //     sale_order = ref_sale and ref_sale[0] or move.sale_line_id.order_id
            //     # Creates new SO line only when pickings linked to a sale order and
            //     # for moves with qty. done and not already linked to a SO line.
            //     if not sale_order or move.sale_line_id or not move.picked or not (
            //         (move.location_dest_id.usage in ['customer', 'transit'] and not move.move_dest_ids)
            //         or (move.location_id.usage == 'customer' and move.to_refund)
            //     ):
            //         continue
            //     product = move.product_id
            //     quantity = move.quantity
            //     if move.location_id.usage in ['customer', 'transit']:
            //         quantity *= -1
            // 
            //     so_line_vals = {
            //         'move_ids': [(4, move.id, 0)],
            //         'name': product.display_name,
            //         'order_id': sale_order.id,
            //         'product_id': product.id,
            //         'product_uom_qty': 0,
            //         'qty_delivered': quantity,
            //         'product_uom_id': move.product_uom.id,
            //     }
            //     so_line = sale_order.order_line.filtered(lambda sol: sol.product_id == product)
            //     if product.invoice_policy == 'delivery':
            //         # Check if there is already a SO line for this product to get
            //         # back its unit price (in case it was manually updated).
            //         if so_line:
            //             so_line_vals['price_unit'] = so_line[0].price_unit
            //     elif product.invoice_policy == 'order':
            //         # No unit price if the product is invoiced on the ordered qty.
            //         so_line_vals['price_unit'] = 0
            //     # New lines should be added at the bottom of the SO (higher sequence number)
            //     if not so_line:
            //         so_line_vals['sequence'] = max(sale_order.order_line.mapped('sequence')) + len(sale_order_lines_vals) + 1
            //     sale_order_lines_vals.append(so_line_vals)
            // 
            // if sale_order_lines_vals:
            //     self.env['sale.order.line'].with_context(skip_procurement=True).create(sale_order_lines_vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _action_done(self):
            // """Call `_action_done` on the `stock.move` of the `stock.picking` in `self`.
            // This method makes sure every `stock.move.line` is linked to a `stock.move` by either
            // linking them to an existing one or a newly created one.
            // 
            // If the context key `cancel_backorder` is present, backorders won't be created.
            // 
            // :return: True
            // :rtype: bool
            // """
            // self._check_company()
            // 
            // todo_moves = self.move_ids.filtered(lambda self: self.state in ['draft', 'waiting', 'partially_available', 'assigned', 'confirmed'])
            // for picking in self:
            //     if picking.owner_id:
            //         picking.move_ids.write({'restrict_partner_id': picking.owner_id.id})
            //         picking.move_line_ids.write({'owner_id': picking.owner_id.id})
            // todo_moves._action_done(cancel_backorder=self.env.context.get('cancel_backorder'))
            // self.write({'date_done': fields.Datetime.now(), 'priority': '0'})
            // 
            // # if incoming/internal moves make other confirmed/partially_available moves available, assign them
            // done_incoming_moves = self.filtered(lambda p: p.picking_type_id.code in ('incoming', 'internal')).move_ids.filtered(lambda m: m.state == 'done')
            // done_incoming_moves._trigger_assign()
            // 
            // self._send_confirmation_email()
            // return True
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateBackorderWizardInternalAsync(object show_transfers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _action_generate_backorder_wizard(self, show_transfers=False):
            // view = self.env.ref('stock.view_backorder_confirmation')
            // return {
            //     'name': _('Create Backorder?'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'stock.backorder.confirmation',
            //     'views': [(view.id, 'form')],
            //     'view_id': view.id,
            //     'target': 'new',
            //     'context': dict(self.env.context, default_show_transfers=show_transfers, default_pick_ids=[(4, p.id) for p in self]),
            // }
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateExpiredWizardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py) ---
            // def _action_generate_expired_wizard(self):
            // expired_lot_ids = self.move_line_ids.filtered(lambda ml: ml.lot_id.product_expiry_alert or (ml.removal_date and ml.removal_date <= datetime.datetime.now())).lot_id.ids
            // view_id = self.env.ref('product_expiry.confirm_expiry_view').id
            // context = dict(self.env.context)
            // 
            // context.update({
            //     'default_picking_ids': [(6, 0, self.ids)],
            //     'default_lot_ids': [(6, 0, expired_lot_ids)],
            // })
            // return {
            //     'name': _('Confirmation'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'expiry.picking.confirmation',
            //     'view_mode': 'form',
            //     'views': [(view_id, 'form')],
            //     'view_id': view_id,
            //     'target': 'new',
            //     'context': context,
            // }
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateWarnSmsWizardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py) ---
            // def _action_generate_warn_sms_wizard(self):
            // view = self.env.ref('stock_sms.view_confirm_stock_sms')
            // wiz = self.env['confirm.stock.sms'].create({'pick_ids': [(4, p.id) for p in self]})
            // return {
            //     'name': _('SMS'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'confirm.stock.sms',
            //     'views': [(view.id, 'form')],
            //     'view_id': view.id,
            //     'target': 'new',
            //     'res_id': wiz.id,
            //     'context': self.env.context,
            // }
            */
            return default;
        }

        protected async Task<StockPicking> AddDeliveryCostToSoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _add_delivery_cost_to_so(self):
            // self.ensure_one()
            // sale_order = self.sale_id
            // if sale_order and self.carrier_id.invoice_policy == 'real' and self.carrier_price:
            //     delivery_lines = self._get_matching_delivery_lines()
            //     if not delivery_lines:
            //         delivery_lines = sale_order._create_delivery_line(self.carrier_id, self.carrier_price)
            //     vals = self._prepare_sale_delivery_line_vals()
            //     delivery_lines[0].write(vals)
            */
            return default;
        }

        public async Task<StockPicking> AddEntirePacksAsync(Guid id, StockPickingAddEntirePacksRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_add_entire_packs(self, package_ids):
            // self.ensure_one()
            // if self.state not in ('done', 'cancel'):
            //     all_packages = self.env['stock.package'].search([('id', 'child_of', package_ids)])
            //     all_package_ids = set(all_packages.ids)
            //     # Remove existing move lines that already pulled from these packages, as using them fully now.
            //     self.move_line_ids.filtered(lambda ml: ml.package_id.id in all_package_ids).unlink()
            //     move_line_vals = self._prepare_entire_pack_move_line_vals(all_packages)
            //     pack_move_lines = self.env['stock.move.line'].create(move_line_vals)
            //     pack_move_lines._apply_putaway_strategy()
            //     # Need to set the right package dest for now fully contained packages
            //     self.move_line_ids.result_package_id._apply_package_dest_for_entire_packs(allowed_package_ids=all_package_ids)
            //     return True
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> AddOperationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def action_add_operations(self):
            // view = self.env.ref('stock_picking_batch.view_move_line_tree_detailed_wave')
            // return {
            //     'name': _('Add Operations'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list',
            //     'view': view,
            //     'views': [(view.id, 'list')],
            //     'res_model': 'stock.move.line',
            //     'target': 'new',
            //     'domain': [
            //         ('picking_id', 'in', self.ids),
            //         ('state', '!=', 'done')
            //     ],
            //     'context': dict(
            //         self.env.context,
            //         picking_to_wave=self.ids,
            //         active_wave_id=self.env.context.get('active_wave_id').id,
            //         search_default_by_location=True,
            //     )}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> AddReferenceInternalAsync(object reference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _add_reference(self, reference=False):
            // """ link the given references to the list of references. """
            // self.ensure_one()
            // self.move_ids.reference_ids = [Command.link(stock_reference.id) for stock_reference in reference]
            */
            return default;
        }

        protected async Task<StockPicking> AddToWavePostPickingSplitHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _add_to_wave_post_picking_split_hook(self):
            // # Hook meant to be overriden
            // pass
            */
            return default;
        }

        public async Task<StockPicking> AssignAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_assign(self):
            // """ Check availability of picking moves.
            // This has the effect of changing the state and reserve quants on available moves, and may
            // also impact the state of the picking as it is computed based on move's states.
            // @return: True
            // """
            // self.filtered(lambda picking: picking.state == 'draft').action_confirm()
            // moves = self.move_ids.filtered(lambda move: move.state not in ('draft', 'cancel', 'done')).sorted(
            //     key=lambda move: (-int(move.priority), not bool(move.date_deadline), move.date_deadline, move.date, move.id)
            // )
            // if not moves:
            //     raise UserError(_('Nothing to check the availability for.'))
            // moves._action_assign()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> AssignBatchUserAsync(Guid id, StockPickingAssignBatchUserRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def assign_batch_user(self, user_id):
            // pickings = self.filtered(lambda p: p.user_id.id != user_id)
            // pickings.write({'user_id': user_id})
            // for pick in pickings:
            //     if user_id:
            //         log_message = _('Assigned to %s Responsible', pick.batch_id._get_html_link())
            //     else:
            //         log_message = _('Unassigned responsible from %s', pick.batch_id._get_html_link())
            //     pick.message_post(body=log_message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> AttachSignInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _attach_sign(self):
            // """ Render the delivery report in pdf and attach it to the picking in `self`. """
            // self.ensure_one()
            // report = self.env['ir.actions.report']._render_qweb_pdf("stock.action_report_delivery", self.id)
            // filename = "%s_signed_delivery_slip" % self.name
            // if self.partner_id:
            //     message = _('Order signed by %s', self.partner_id.name)
            // else:
            //     message = _('Order signed')
            // self.message_post(
            //     attachments=[('%s.pdf' % filename, report[0])],
            //     body=message,
            // )
            // return True
            */
            return default;
        }

        protected async Task<StockPicking> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _auto_init(self):
            // """
            // Create related field here, too slow
            // when computing it afterwards through _compute_related.
            // 
            // Since group_id.sale_id is created in this module,
            // no need for an UPDATE statement.
            // """
            // if not column_exists(self.env.cr, 'stock_picking', 'sale_id'):
            //     create_column(self.env.cr, 'stock_picking', 'sale_id', 'int4')
            // return super()._auto_init()
            */
            return default;
        }

        protected async Task<StockPicking> AutoconfirmPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _autoconfirm_picking(self):
            // """ Automatically run `action_confirm` on `self` if one of the
            // picking's move was added after the initial
            // call to `action_confirm`. Note that `action_confirm` will only work on draft moves.
            // """
            // for picking in self:
            //     if picking.state in ('done', 'cancel'):
            //         continue
            //     if not picking.move_ids:
            //         continue
            //     if any(move.additional for move in picking.move_ids):
            //         picking.action_confirm()
            // to_confirm = self.move_ids.filtered(lambda m: m.state == 'draft' and m.quantity)
            // to_confirm._action_confirm()
            */
            return default;
        }

        public async Task<StockPicking> ButtonScrapAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def button_scrap(self):
            // self.ensure_one()
            // view = self.env.ref('stock.stock_scrap_form_view2')
            // products = self.env['product.product']
            // for move in self.move_ids:
            //     if move.state not in ('draft', 'cancel') and move.product_id.type == 'consu':
            //         products |= move.product_id
            // return {
            //     'name': _('Scrap Products'),
            //     'view_mode': 'form',
            //     'res_model': 'stock.scrap',
            //     'view_id': view.id,
            //     'views': [(view.id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_picking_id': self.id, 'product_ids': products.ids, 'default_company_id': self.company_id.id},
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ButtonValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_picking.py) ---
            // def button_validate(self):
            // res = super().button_validate()
            // if res is not True:
            //     return res
            // 
            // for picking in self:
            //     project = picking.project_id
            //     sale_order = project.sudo().reinvoiced_sale_order_id
            //     if not (sale_order and picking.picking_type_id.analytic_costs):
            //         continue
            //     reinvoicable_stock_moves = picking.move_ids.filtered(lambda m: m.product_id.expense_policy in {'sales_price', 'cost'})
            //     if not reinvoicable_stock_moves:
            //         continue
            //     # raise if the sale order is not currently open
            //     if sale_order.state in ('draft', 'sent'):
            //         raise UserError(_(
            //             "The Sales Order %(order)s linked to the Project %(project)s must be"
            //             " validated before validating the stock picking.",
            //             order=sale_order.name,
            //             project=project.name,
            //         ))
            //     elif sale_order.state == 'cancel':
            //         raise UserError(_(
            //             "The Sales Order %(order)s linked to the Project %(project)s is cancelled."
            //             " You cannot validate a stock picking on a cancelled Sales Order.",
            //             order=sale_order.name,
            //             project=project.name,
            //         ))
            //     elif sale_order.locked:
            //         raise UserError(_(
            //             "The Sales Order %(order)s linked to the Project %(project)s is currently locked."
            //             " You cannot validate a stock picking on a locked Sales Order."
            //             " Please create a new SO linked to this Project.",
            //             order=sale_order.name,
            //             project=project.name,
            //         ))
            //     # Create SOLs in reinvoiced_sale_order_id with reinvoicable stock moves
            //     sale_line_values_to_create = []
            //     # Get last sequence SOL
            //     last_so_line = self.env['sale.order.line'].search_read(
            //         [('order_id', '=', sale_order.id)],
            //         ['sequence'], order='sequence desc', limit=1,
            //     )
            //     last_sequence = next((sol['sequence'] for sol in last_so_line), 100)
            // 
            //     for stock_move in reinvoicable_stock_moves:
            //         # Get price
            //         price = stock_move._sale_get_invoice_price(sale_order)
            //         # Create the sale lines in batch
            //         sale_line_values_to_create.append(stock_move._sale_prepare_sale_line_values(sale_order, price, last_sequence))
            //         last_sequence += 1
            //     self.env['sale.order.line'].with_context(skip_procurement=True).sudo().create(sale_line_values_to_create)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def button_validate(self):
            // self = self.filtered(lambda p: p.state != 'done')
            // draft_picking = self.filtered(lambda p: p.state == 'draft')
            // draft_picking.action_confirm()
            // for move in draft_picking.move_ids:
            //     if move.product_uom.is_zero(move.quantity) and not move.product_uom.is_zero(move.product_uom_qty):
            //         move.quantity = move.product_uom_qty
            // 
            // # Sanity checks.
            // if not self.env.context.get('skip_sanity_check', False):
            //     self._sanity_check()
            // 
            // # Run the pre-validation wizards. Processing a pre-validation wizard should work on the
            // # moves and/or the context and never call `_action_done`.
            // if not self.env.context.get('button_validate_picking_ids'):
            //     self = self.with_context(button_validate_picking_ids=self.ids)
            // res = self._pre_action_done_hook()
            // if res is not True:
            //     return res
            // 
            // # Call `_action_done`.
            // pickings_not_to_backorder = self.filtered(lambda p: p.picking_type_id.create_backorder == 'never')
            // if self.env.context.get('picking_ids_not_to_backorder'):
            //     pickings_not_to_backorder |= self.browse(self.env.context['picking_ids_not_to_backorder']).filtered(
            //         lambda p: p.picking_type_id.create_backorder != 'always'
            //     )
            // pickings_to_backorder = self - pickings_not_to_backorder
            // if pickings_not_to_backorder:
            //     pickings_not_to_backorder.with_context(cancel_backorder=True)._action_done()
            // if pickings_to_backorder:
            //     pickings_to_backorder.with_context(cancel_backorder=False)._action_done()
            // report_actions = self._get_autoprint_report_actions()
            // another_action = False
            // if self.env.user.has_group('stock.group_reception_report'):
            //     pickings_show_report = self.filtered(lambda p: p.picking_type_id.auto_show_reception_report)
            //     lines = pickings_show_report.move_ids.filtered(lambda m: m.product_id.is_storable and m.state != 'cancel' and m.quantity and not m.move_dest_ids)
            //     if lines:
            //         # don't show reception report if all already assigned/nothing to assign
            //         wh_location_ids = self.env['stock.location']._search([('id', 'child_of', pickings_show_report.picking_type_id.warehouse_id.view_location_id.ids), ('usage', '!=', 'supplier')])
            //         if self.env['stock.move'].search_count([
            //                 ('state', 'in', ['confirmed', 'partially_available', 'waiting', 'assigned']),
            //                 ('product_qty', '>', 0),
            //                 ('location_id', 'in', wh_location_ids),
            //                 ('move_orig_ids', '=', False),
            //                 ('picking_id', 'not in', pickings_show_report.ids),
            //                 ('product_id', 'in', lines.product_id.ids)], limit=1):
            //             action = pickings_show_report.action_view_reception_report()
            //             action['context'] = {'default_picking_ids': pickings_show_report.ids}
            //             if not report_actions:
            //                 return action
            //             another_action = action
            // if report_actions:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'do_multi_print',
            //         'params': {
            //             'reports': report_actions,
            //             'anotherAction': another_action,
            //         }
            //     }
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def button_validate(self):
            // res = super().button_validate()
            // to_assign_ids = set()
            // # Having non-done pickings after the `super()` call means it stopped early,
            // # so we shouldn’t remove the pickings from batches yet.
            // if not any(picking.state == 'done' for picking in self):
            //     return res
            // if self and self.env.context.get('pickings_to_detach'):
            //     pickings_to_detach = self.env['stock.picking'].browse(self.env.context['pickings_to_detach'])
            //     pickings_to_detach.batch_id = False
            //     pickings_to_detach.move_ids.filtered(lambda m: not m.quantity).picked = False
            //     to_assign_ids.update(self.env.context['pickings_to_detach'])
            // 
            // for picking in self:
            //     if picking.state != 'done':
            //         continue
            //     # Avoid inconsistencies in states of the same batch when validating a single picking in a batch.
            //     if picking.batch_id and any(p.state != 'done' for p in picking.batch_id.picking_ids):
            //         picking.batch_id = None
            //     # If backorder were made, if auto-batch is enabled, seek a batch for each of them with the selected criterias.
            //     to_assign_ids.update(picking.backorder_ids.ids)
            // 
            // # To avoid inconsistencies, all incorrect pickings must be removed before assigning backorder pickings
            // assignable_pickings = self.env['stock.picking'].browse(to_assign_ids)
            // for picking in assignable_pickings:
            //     picking._find_auto_batch()
            // assignable_pickings.move_line_ids.with_context(skip_auto_waveable=True)._auto_wave()
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> CalWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _cal_weight(self):
            // for picking in self:
            //     picking.weight = sum(move.weight for move in picking.move_ids if move.state != 'cancel')
            */
            return default;
        }

        public async Task<StockPicking> CalculateDateCategoryAsync(Guid id, StockPickingCalculateDateCategoryRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def calculate_date_category(self, datetime):
            // """
            // Assigns given datetime to one of the following categories:
            // - "before"
            // - "yesterday"
            // - "today"
            // - "day_1" (tomorrow)
            // - "day_2" (the day after tomorrow)
            // - "after"
            // 
            // The categories are based on current user's timezone (e.g. "today" will last
            // between 00:00 and 23:59 local time). The datetime itself is assumed to be
            // in UTC. If the datetime is falsy, this function returns "".
            // """
            // start_today = fields.Datetime.context_timestamp(
            //     self.env.user, fields.Datetime.now()
            // ).replace(hour=0, minute=0, second=0, microsecond=0)
            // 
            // start_yesterday = start_today + timedelta(days=-1)
            // start_day_1 = start_today + timedelta(days=1)
            // start_day_2 = start_today + timedelta(days=2)
            // start_day_3 = start_today + timedelta(days=3)
            // 
            // date_category = ""
            // 
            // if datetime:
            //     datetime = datetime.astimezone(pytz.UTC)
            //     if datetime < start_yesterday:
            //         date_category = "before"
            //     elif datetime >= start_yesterday and datetime < start_today:
            //         date_category = "yesterday"
            //     elif datetime >= start_today and datetime < start_day_1:
            //         date_category = "today"
            //     elif datetime >= start_day_1 and datetime < start_day_2:
            //         date_category = "day_1"
            //     elif datetime >= start_day_2 and datetime < start_day_3:
            //         date_category = "day_2"
            //     else:
            //         date_category = "after"
            // 
            // return date_category
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> CanReturnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _can_return(self):
            // self.ensure_one()
            // return super()._can_return() or self.sale_id
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _can_return(self):
            // self.ensure_one()
            // return self.state == 'done'
            */
            return default;
        }

        public async Task<StockPicking> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_cancel(self):
            // self.move_ids._action_cancel()
            // self.write({'is_locked': True})
            // self.filtered(lambda x: not x.move_ids).state = 'cancel'
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def action_cancel(self):
            // res = super().action_cancel()
            // for picking in self:
            //     if picking.batch_id and any(picking.state != 'cancel' for picking in picking.batch_id.picking_ids):
            //         picking.batch_id = None
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> CancelShipmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def cancel_shipment(self):
            // for picking in self:
            //     picking.carrier_id.cancel_shipment(self)
            //     msg = "Shipment %s cancelled" % picking.carrier_tracking_ref
            //     picking.message_post(body=msg)
            //     picking.carrier_tracking_ref = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> CarrierExceptionNoteInternalAsync(object exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _carrier_exception_note(self, exception):
            // self.ensure_one()
            // line_1 = _("Exception occurred with respect to carrier on the transfer")
            // line_2 = _("Manual actions might be needed.")
            // line_3 = _("Exception:")
            // return Markup('<div> {line_1} <a href="#" data-oe-model="stock.picking" data-oe-id="{picking_id}"> {picking_name}</a>. {line_2}<div class="mt16"><p>{line_3} {exception}</p></div></div>').format(line_1=line_1, line_2=line_2, line_3=line_3, picking_id=self.id, picking_name=self.name, exception=exception)
            */
            return default;
        }

        protected async Task<StockPicking> CheckBackdateAllowedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py) ---
            // def _check_backdate_allowed(self):
            // if self.env['ir.config_parameter'].sudo().get_param('stock_account.skip_lock_date_check'):
            //     return
            // for picking in self:
            //     if picking._is_date_in_lock_period():
            //         raise ValidationError(self.env._("You cannot modify the scheduled date of this operation because it falls within a locked fiscal period."))
            */
            return default;
        }

        protected async Task<StockPicking> CheckBackorderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _check_backorder(self):
            // prec = self.env["decimal.precision"].precision_get("Product Unit")
            // backorder_pickings = self.browse()
            // for picking in self:
            //     if picking.picking_type_id.create_backorder != 'ask':
            //         continue
            //     if any(
            //             (move.product_uom_qty and not move.picked) or
            //             float_compare(move._get_picked_quantity(), move.product_uom_qty, precision_digits=prec) < 0
            //             for move in picking.move_ids
            //             if move.state != 'cancel'
            //     ):
            //         backorder_pickings |= picking
            // return backorder_pickings
            */
            return default;
        }

        protected async Task<StockPicking> CheckCarrierDetailsComplianceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _check_carrier_details_compliance(self):
            // """Hook to check if a delivery is compliant in regard of the carrier.
            // """
            // return
            */
            return default;
        }

        protected async Task<StockPicking> CheckEntirePackInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _check_entire_pack(self):
            // """ This function check if entire packs are moved in the picking"""
            // for package in self.move_line_ids.package_id:
            //     pickings = self.move_line_ids.filtered(lambda ml: ml.package_id == package).picking_id
            //     if pickings._is_single_transfer() and pickings._check_move_lines_map_quant_package(package):
            //         move_lines_to_pack = pickings.move_line_ids.filtered(lambda ml: ml.package_id == package and not ml.result_package_id and ml.state not in ('done', 'cancel'))
            //         if package.package_type_id.package_use != 'reusable':
            //             move_lines_to_pack.write({
            //                 'result_package_id': package.id,
            //                 'is_entire_pack': True,
            //             })
            // # If we move all packages within a package, we can consider that they keep their container as well
            // self.move_line_ids.result_package_id._apply_package_dest_for_entire_packs()
            */
            return default;
        }

        protected async Task<StockPicking> CheckExpiredLotsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py) ---
            // def _check_expired_lots(self):
            // expired_pickings = self.move_line_ids.filtered(lambda ml: ml.lot_id.product_expiry_alert or (ml.removal_date and ml.removal_date <= datetime.datetime.now())).picking_id
            // return expired_pickings
            */
            return default;
        }

        protected async Task<StockPicking> CheckMoveLinesMapQuantPackageInternalAsync(object package)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _check_move_lines_map_quant_package(self, package):
            // return package._check_move_lines_map_quant(self.move_line_ids.filtered(lambda ml:
            //     ml.product_id.is_storable
            //     and (ml.package_id == package or ml.package_id in package.all_children_package_ids)))
            */
            return default;
        }

        protected async Task<StockPicking> CheckWarnSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py) ---
            // def _check_warn_sms(self):
            // warn_sms_pickings = self.browse()
            // for picking in self:
            //     is_delivery = picking.company_id._get_text_validation('sms') \
            //             and picking.picking_type_id.code == 'outgoing' \
            //             and picking.partner_id.phone
            //     if is_delivery \
            //             and not modules.module.current_test \
            //             and not picking.company_id.has_received_warning_stock_sms \
            //             and picking.company_id._get_text_validation('sms'):
            //         warn_sms_pickings |= picking
            // return warn_sms_pickings
            */
            return default;
        }

        protected async Task<StockPicking> ComputeAllowedCarrierIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _compute_allowed_carrier_ids(self):
            // for picking in self:
            //     carriers = self.env['delivery.carrier'].search(self.env['delivery.carrier']._check_company_domain(picking.company_id))
            //     picking.allowed_carrier_ids = carriers.available_carriers(picking.partner_id, picking) if picking.partner_id else carriers
            */
            return default;
        }

        protected async Task<StockPicking> ComputeBulkWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_bulk_weight(self):
            // picking_weights = defaultdict(float)
            // res_groups = self.env['stock.move.line']._read_group(
            //     [('picking_id', 'in', self.ids), ('product_id', '!=', False), ('result_package_id', '=', False)],
            //     ['picking_id', 'product_id', 'product_uom_id', 'quantity'],
            //     ['__count'],
            // )
            // for picking, product, product_uom, quantity, count in res_groups:
            //     picking_weights[picking.id] += (
            //         count
            //         * product_uom._compute_quantity(quantity, product.uom_id)
            //         * product.weight
            //     )
            // for picking in self:
            //     picking.weight_bulk = picking_weights[picking.id]
            */
            return default;
        }

        protected async Task<StockPicking> ComputeCarrierTrackingUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _compute_carrier_tracking_url(self):
            // for picking in self:
            //     picking.carrier_tracking_url = picking.carrier_id.get_tracking_link(picking) if picking.carrier_id and picking.carrier_tracking_ref else False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDateDeadlineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_date_deadline(self):
            // for picking in self:
            //     if picking.move_type == 'direct':
            //         picking.date_deadline = min(picking.move_ids.filtered('date_deadline').mapped('date_deadline'), default=False)
            //     else:
            //         picking.date_deadline = max(picking.move_ids.filtered('date_deadline').mapped('date_deadline'), default=False)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDateOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_date_order(self):
            // for picking in self:
            //     picking.delay_pass = picking.purchase_id.date_order if picking.purchase_id else fields.Datetime.now()
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDelayAlertDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_delay_alert_date(self):
            // delay_alert_date_data = self.env['stock.move']._read_group([('id', 'in', self.move_ids.ids), ('delay_alert_date', '!=', False)], ['picking_id'], ['delay_alert_date:max'])
            // delay_alert_date_data = {picking.id: delay_alert_date for picking, delay_alert_date in delay_alert_date_data}
            // for picking in self:
            //     picking.delay_alert_date = delay_alert_date_data.get(picking.id, False)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_effective_date(self):
            // for picking in self:
            //     if picking.state == 'done' and picking.location_dest_id.usage != 'supplier' and picking.date_done:
            //         picking.days_to_arrive = picking.date_done
            //     else:
            //         picking.days_to_arrive = False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasDeadlineIssueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_has_deadline_issue(self):
            // for picking in self:
            //     picking.has_deadline_issue = picking.date_deadline and picking.date_deadline < picking.scheduled_date or False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasKitsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _compute_has_kits(self):
            // for picking in self:
            //     picking.has_kits = any(picking.move_ids.mapped('bom_line_id'))
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_has_tracking(self):
            // for picking in self:
            //     picking.has_tracking = any(m.has_tracking != 'none' for m in picking.move_ids)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsDateEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_is_date_editable(self):
            // for picking in self:
            //     if picking.state in ['done', 'cancel']:
            //         picking.is_date_editable = not picking.is_locked
            //     else:
            //         picking.is_date_editable = True
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py) ---
            // def _compute_is_date_editable(self):
            // super()._compute_is_date_editable()
            // for picking in self:
            //     if picking.is_date_editable and picking.state in ['done', 'cancel'] and picking.ids:
            //         picking.is_date_editable = not picking._is_date_in_lock_period()
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsDropshipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py) ---
            // def _compute_is_dropship(self):
            // dropship_subcontract_pickings = self.filtered(lambda p: p.location_dest_id.is_subcontract() and p.location_id.usage == 'supplier')
            // dropship_subcontract_pickings.is_dropship = True
            // super(StockPicking, self - dropship_subcontract_pickings)._compute_is_dropship()
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_is_dropship(self):
            // for picking in self:
            //     source, dest = picking.location_id, picking.location_dest_id
            //     picking.is_dropship = (source.usage == 'supplier' or (source.usage == 'transit' and not source.company_id)) \
            //                       and (dest.usage == 'customer' or (dest.usage == 'transit' and not dest.company_id))
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsSignedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_is_signed(self):
            // for picking in self:
            //     picking.is_signed = picking.signature
            */
            return default;
        }

        protected async Task<StockPicking> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_json_popover(self):
            // picking_no_alert = self.filtered(lambda p: p.state in ('done', 'cancel') or not p.delay_alert_date)
            // picking_no_alert.json_popover = False
            // for picking in (self - picking_no_alert):
            //     picking.json_popover = json.dumps({
            //         'popoverTemplate': 'stock.PopoverStockRescheduling',
            //         'delay_alert_date': format_datetime(self.env, picking.delay_alert_date, dt_format=False),
            //         'late_elements': [{
            //             'id': late_move.id,
            //             'name': late_move.display_name,
            //             'model': late_move._name,
            //         } for late_move in picking.move_ids.filtered(lambda m: m.delay_alert_date).move_orig_ids._delay_alert_get_documents()
            //         ]
            //     })
            */
            return default;
        }

        protected async Task<StockPicking> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _compute_location_id(self):
            // super()._compute_location_id()
            // 
            // for picking in self:
            //     # If this is a subcontractor resupply transfer, set the destination location
            //     # to the vendor subcontractor location
            //     subcontracting_resupply_type_id = picking.picking_type_id.warehouse_id.subcontracting_resupply_type_id
            //     if picking.picking_type_id == subcontracting_resupply_type_id\
            //         and picking.partner_id.property_stock_subcontractor:
            //         picking.location_dest_id = picking.partner_id.property_stock_subcontractor
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_location_id(self):
            // for picking in self:
            //     if picking.state in ('cancel', 'done') or picking.return_id:
            //         continue
            //     picking = picking.with_company(picking.company_id)
            //     if picking.picking_type_id:
            //         location_src = picking.picking_type_id.default_location_src_id
            //         if location_src.usage == 'supplier' and picking.partner_id:
            //             location_src = picking.partner_id.property_stock_supplier
            //         location_dest = picking.picking_type_id.default_location_dest_id
            //         if location_dest.usage == 'customer' and picking.partner_id:
            //             location_dest = picking.partner_id.property_stock_customer
            //         picking.location_id = location_src.id
            //         picking.location_dest_id = location_dest.id
            */
            return default;
        }

        protected async Task<StockPicking> ComputeMoveTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _compute_move_type(self):
            // super()._compute_move_type()
            // for picking in self:
            //     sale_orders = picking.move_ids.sale_line_id.order_id
            //     if sale_orders:
            //         if any(so.picking_policy == "direct" for so in sale_orders):
            //             picking.move_type = "direct"
            //         else:
            //             picking.move_type = "one"
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_move_type(self):
            // for record in self:
            //     record.move_type = record.picking_type_id.move_type
            */
            return default;
        }

        protected async Task<StockPicking> ComputeMrpProductionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _compute_mrp_production_ids(self):
            // for picking in self:
            //     # hide subcontracting MO from resupply picking
            //     mo = picking.production_ids.filtered(lambda mo: mo.picking_type_id.active)
            //     picking.production_count = len(mo)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeNbrRepairsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_nbr_repairs(self):
            // for picking in self:
            //     picking.nbr_repairs = len(picking.repair_ids)
            */
            return default;
        }

        protected async Task<StockPicking> ComputePackagesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_packages_count(self):
            // done_pickings = self.filtered(lambda picking: picking.state == 'done')
            // other_pickings = self - done_pickings
            // 
            // packages_by_pick = defaultdict(int)
            // # Cannot _read_group() as picking_ids isn't stored, nor grouped() because multiple pickings per package
            // packages = self.env['stock.package'].search([('picking_ids', 'in', other_pickings.ids)])
            // for pack in packages:
            //     for picking in pack.picking_ids:
            //         packages_by_pick[picking] += 1
            // 
            // histories_by_pick = self.env['stock.package.history']._read_group([
            //     ('picking_ids', 'in', done_pickings.ids)], ['picking_ids'], ['__count'])
            // histories_by_pick = dict(histories_by_pick)
            // 
            // for picking in done_pickings:
            //     picking.packages_count = histories_by_pick.get(picking, 0)
            // for picking in other_pickings:
            //     picking.packages_count = packages_by_pick.get(picking, 0)
            */
            return default;
        }

        protected async Task<StockPicking> ComputePickingWarningTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_picking_warning_text(self):
            // if not self.env.user.has_group('stock.group_warning_stock'):
            //     self.picking_warning_text = ''
            //     return
            // for picking in self:
            //     text = ''
            //     if partner_msg := picking.partner_id.picking_warn_msg:
            //         text += partner_msg + '\n'
            //     if parent_msg := picking.partner_id.parent_id.picking_warn_msg:
            //         text += parent_msg + '\n'
            //     picking.picking_warning_text = text
            */
            return default;
        }

        protected async Task<StockPicking> ComputeProductsAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_products_availability(self):
            // pickings = self.filtered(lambda picking:
            //     picking.state in ('waiting', 'confirmed', 'assigned') and
            //     picking.picking_type_code in ('outgoing', 'internal')
            // )
            // pickings.products_availability_state = 'available'
            // pickings.products_availability = _('Available')
            // other_pickings = self - pickings
            // other_pickings.products_availability = False
            // other_pickings.products_availability_state = False
            // 
            // all_moves = pickings.move_ids
            // # Force to prefetch more than 1000 by 1000
            // all_moves._fields['forecast_availability'].compute_value(all_moves)
            // for picking in pickings:
            //     # In case of draft the behavior of forecast_availability is different : if forecast_availability < 0 then there is a issue else not.
            //     if any(move.product_id.uom_id.compare(move.forecast_availability, 0 if move.state == 'draft' else move.product_qty) == -1 for move in picking.move_ids):
            //         picking.products_availability = _('Not Available')
            //         picking.products_availability_state = 'late'
            //     else:
            //         forecast_date = max(picking.move_ids.filtered('forecast_expected_date').mapped('forecast_expected_date'), default=False)
            //         if forecast_date:
            //             picking.products_availability = _('Exp %s', format_date(self.env, forecast_date))
            //             picking.products_availability_state = 'late' if picking.scheduled_date and picking.scheduled_date < forecast_date else 'expected'
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_return_count(self):
            // for picking in self:
            //     picking.return_count = len(picking.return_ids)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _compute_return_label(self):
            // for picking in self:
            //     if picking.carrier_id:
            //         picking.return_label_ids = self.env['ir.attachment'].search([('res_model', '=', 'stock.picking'), ('res_id', '=', picking.id), ('name', '=like', '%s%%' % picking.carrier_id.get_return_label_prefix())])
            //     else:
            //         picking.return_label_ids = False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _compute_return_picking(self):
            // for picking in self:
            //     if picking.carrier_id and picking.carrier_id.can_generate_return:
            //         picking.is_return_picking = any(m.origin_returned_move_id for m in picking.move_ids)
            //     else:
            //         picking.is_return_picking = False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeSaleIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _compute_sale_id(self):
            // for picking in self:
            //     # picking and move should have a link to the SO to see the picking on the stat button.
            //     # This will filter the move chain to the delivery moves only.
            //     picking.sale_id = picking.move_ids.sale_line_id.order_id
            */
            return default;
        }

        protected async Task<StockPicking> ComputeScheduledDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_scheduled_date(self):
            // for picking in self:
            //     if not picking.id:
            //         continue
            //     moves_dates = picking.move_ids.filtered(lambda move: move.state not in ('done', 'cancel')).mapped('date')
            //     if picking.move_type == 'direct':
            //         picking.scheduled_date = min(moves_dates, default=picking.scheduled_date or fields.Datetime.now())
            //     else:
            //         picking.scheduled_date = max(moves_dates, default=picking.scheduled_date or fields.Datetime.now())
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShippingVolumeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_shipping_volume(self):
            // for picking in self:
            //     volume = 0
            //     for move in picking.move_ids:
            //         volume += move.product_uom._compute_quantity(move.quantity, move.product_id.uom_id) * move.product_id.volume
            //     picking.shipping_volume = volume
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShippingWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_shipping_weight(self):
            // for picking in self:
            //     # if shipping weight is not assigned => default to calculated product weight
            //     packages_weight = picking.move_line_ids.result_package_id.sudo()._get_weight(picking.id)
            // 
            //     shipping_weight = picking.weight_bulk
            //     relevant_packages = picking.move_line_ids.result_package_id.outermost_package_id
            //     children_packages_by_pack = relevant_packages._get_all_children_package_dest_ids()[0]
            //     for package in relevant_packages:
            //         if package.shipping_weight:
            //             shipping_weight += package.shipping_weight
            //         else:
            //             shipping_weight += package.package_type_id.base_weight
            //             shipping_weight += sum(packages_weight.get(pack, 0) for pack in self.env['stock.package'].browse(children_packages_by_pack.get(package)))
            // 
            //     picking.shipping_weight = shipping_weight
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowAllocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_show_allocation(self):
            // self.show_allocation = False
            // if not self.env.user.has_group('stock.group_reception_report'):
            //     return
            // for picking in self:
            //     picking.show_allocation = picking._get_show_allocation(picking.picking_type_id)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowCheckAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_show_check_availability(self):
            // """ According to `picking.show_check_availability`, the "check availability" button will be
            // displayed in the form view of a picking.
            // """
            // for picking in self:
            //     if picking.state not in ('confirmed', 'waiting', 'assigned'):
            //         picking.show_check_availability = False
            //         continue
            //     if all(m.picked or m.product_uom_qty == m.quantity for m in picking.move_ids):
            //         picking.show_check_availability = False
            //         continue
            //     picking.show_check_availability = any(
            //         move.state in ('waiting', 'confirmed', 'partially_available') and
            //         move.product_uom.compare(move.product_uom_qty, 0)
            //         for move in picking.move_ids
            //     )
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowLotsTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _compute_show_lots_text(self):
            // super()._compute_show_lots_text()
            // for picking in self:
            //     if any(move.is_subcontract and move.has_tracking != 'none' for move in picking.move_ids):
            //         picking.show_lots_text = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_show_lots_text(self):
            // group_production_lot_enabled = self.env.user.has_group('stock.group_production_lot')
            // for picking in self:
            //     if not picking.move_line_ids and not picking.picking_type_id.use_create_lots:
            //         picking.show_lots_text = False
            //     elif group_production_lot_enabled and picking.picking_type_id.use_create_lots \
            //             and not picking.picking_type_id.use_existing_lots and picking.state != 'done':
            //         picking.show_lots_text = True
            //     else:
            //         picking.show_lots_text = False
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowNextPickingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_show_next_pickings(self):
            // self.show_next_pickings = len(self._get_next_transfers()) != 0
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowSubcontractingDetailsVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _compute_show_subcontracting_details_visible(self):
            // for picking in self:
            //     picking.show_subcontracting_details_visible = any(m.show_subcontracting_details_visible for m in picking.move_ids)
            */
            return default;
        }

        protected async Task<StockPicking> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_state(self):
            // ''' State of a picking depends on the state of its related stock.move
            // - Draft: only used for "planned pickings"
            // - Waiting: if the picking is not ready to be sent so if
            //   - (a) no quantity could be reserved at all or if
            //   - (b) some quantities could be reserved and the shipping policy is "deliver all at once"
            // - Waiting another move: if the picking is waiting for another move
            // - Ready: if the picking is ready to be sent so if:
            //   - (a) all quantities are reserved or if
            //   - (b) some quantities could be reserved and the shipping policy is "as soon as possible"
            //   - (c) it's an incoming picking
            // - Done: if the picking is done.
            // - Cancelled: if the picking is cancelled
            // '''
            // picking_moves_state_map = defaultdict(dict)
            // picking_move_lines = defaultdict(set)
            // for move in self.env['stock.move'].search([('picking_id', 'in', self.ids)]):
            //     picking_id = move.picking_id
            //     move_state = move.state
            //     picking_moves_state_map[picking_id.id].update({
            //         'any_draft': picking_moves_state_map[picking_id.id].get('any_draft', False) or move_state == 'draft',
            //         'all_cancel': picking_moves_state_map[picking_id.id].get('all_cancel', True) and move_state == 'cancel',
            //         'all_cancel_done': picking_moves_state_map[picking_id.id].get('all_cancel_done', True) and move_state in ('cancel', 'done'),
            //         'all_done_are_scrapped': picking_moves_state_map[picking_id.id].get('all_done_are_scrapped', True) and (move.location_dest_usage == 'inventory' if move_state == 'done' else True),
            //         'any_cancel_and_not_scrapped': picking_moves_state_map[picking_id.id].get('any_cancel_and_not_scrapped', False) or (move_state == 'cancel' and move.location_dest_usage != 'inventory'),
            //     })
            //     picking_move_lines[picking_id.id].add(move.id)
            // for picking in self:
            //     picking_id = (picking.ids and picking.ids[0]) or picking.id
            //     if not picking_moves_state_map[picking_id] or picking_moves_state_map[picking_id]['any_draft']:
            //         picking.state = 'draft'
            //     elif picking_moves_state_map[picking_id]['all_cancel']:
            //         picking.state = 'cancel'
            //     elif picking_moves_state_map[picking_id]['all_cancel_done']:
            //         if picking_moves_state_map[picking_id]['all_done_are_scrapped'] and picking_moves_state_map[picking_id]['any_cancel_and_not_scrapped']:
            //             picking.state = 'cancel'
            //         else:
            //             picking.state = 'done'
            //     else:
            //         if picking.location_id.should_bypass_reservation() and all(m.procure_method == 'make_to_stock' for m in picking.move_ids):
            //             picking.state = 'assigned'
            //         else:
            //             relevant_move_state = self.env['stock.move'].browse(picking_move_lines[picking_id])._get_relevant_state_among_moves()
            //             if relevant_move_state == 'partially_available':
            //                 picking.state = 'assigned'
            //             else:
            //                 picking.state = relevant_move_state
            */
            return default;
        }

        protected async Task<StockPicking> ComputeSubcontractingSourcePurchaseCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py) ---
            // def _compute_subcontracting_source_purchase_count(self):
            // for picking in self:
            //     picking.subcontracting_source_purchase_count = len(picking._get_subcontracting_source_purchase())
            */
            return default;
        }

        protected async Task<StockPicking> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _compute_weight_uom_name(self):
            // for package in self:
            //     package.weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<StockPicking> ConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_confirm(self):
            // self._check_company()
            // # call `_action_confirm` on every draft move
            // self.move_ids.filtered(lambda move: move.state == 'draft')._action_confirm()
            // 
            // # run scheduler for moves forecasted to not have enough in stock
            // self.move_ids.filtered(lambda move: move.state not in ('draft', 'cancel', 'done'))._trigger_scheduler()
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def action_confirm(self):
            // res = super().action_confirm()
            // for picking in self:
            //     picking._find_auto_batch()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<StockPicking> CreateAsync(StockPicking entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def create(self, vals_list):
            // scheduled_dates = []
            // for vals in vals_list:
            //     defaults = self.default_get(['name', 'picking_type_id'])
            //     picking_type = self.env['stock.picking.type'].browse(vals.get('picking_type_id', defaults.get('picking_type_id')))
            //     if vals.get('name', '/') == '/' and defaults.get('name', '/') == '/' and vals.get('picking_type_id', defaults.get('picking_type_id')):
            //         if picking_type.sequence_id:
            //             vals['name'] = picking_type.sequence_id.next_by_id()
            // 
            //     # make sure to write `schedule_date` *after* the `stock.move` creation in
            //     # order to get a determinist execution of `_set_scheduled_date`
            //     scheduled_dates.append(vals.pop('scheduled_date', False))
            // 
            // pickings = super().create(vals_list)
            // 
            // for picking, scheduled_date in zip(pickings, scheduled_dates):
            //     if scheduled_date:
            //         picking.with_context(mail_notrack=True).write({'scheduled_date': scheduled_date})
            // pickings._autoconfirm_picking()
            // 
            // return pickings
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def create(self, vals_list):
            // pickings = super().create(vals_list)
            // for picking, vals in zip(pickings, vals_list):
            //     if vals.get('batch_id'):
            //         if not picking.batch_id.picking_type_id:
            //             picking.batch_id.picking_type_id = picking.picking_type_id[0]
            //         picking.batch_id._sanity_check()
            // return pickings
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<StockPicking> CreateBackorderInternalAsync(object backorder_moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _create_backorder(self, backorder_moves=None):
            // """ This method is called when the user chose to create a backorder. It will create a new
            // picking, the backorder, and move the stock.moves that are not `done` or `cancel` into it.
            // """
            // backorders = self.env['stock.picking']
            // bo_to_assign = self.env['stock.picking']
            // for picking in self:
            //     if backorder_moves:
            //         moves_to_backorder = backorder_moves.filtered(lambda m: m.picking_id == picking)
            //     else:
            //         moves_to_backorder = picking._get_moves_to_backorder()
            //     moves_to_backorder._recompute_state()
            //     if moves_to_backorder:
            //         backorder_picking = picking._create_backorder_picking()
            //         moves_to_backorder.write({'picking_id': backorder_picking.id, 'picked': False})
            //         moves_to_backorder.mapped('move_line_ids').write({'picking_id': backorder_picking.id})
            //         backorders |= backorder_picking
            //         backorder_picking.user_id = False
            //         picking.message_post(
            //             body=_('The backorder %s has been created.', backorder_picking._get_html_link())
            //         )
            //         if backorder_picking.picking_type_id.reservation_method == 'at_confirm':
            //             bo_to_assign |= backorder_picking
            // if bo_to_assign:
            //     bo_to_assign.action_assign()
            // return backorders
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _create_backorder(self, backorder_moves=None):
            // pickings_to_detach = self.env['stock.picking'].browse(self.env.context.get('pickings_to_detach'))
            // for picking in self:
            //     # Avoid inconsistencies in states of the same batch when validating a single picking in a batch.
            //     if picking.batch_id and picking.state != 'done' and any(p not in self for p in picking.batch_id.picking_ids - pickings_to_detach):
            //         picking.batch_id = None
            // return super()._create_backorder(backorder_moves)
            */
            return default;
        }

        protected async Task<StockPicking> CreateBackorderPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _create_backorder_picking(self):
            // self.ensure_one()
            // return self.copy({
            //     'name': '/',
            //     'move_ids': [],
            //     'move_line_ids': [],
            //     'backorder_id': self.id,
            // })
            */
            return default;
        }

        protected async Task<StockPicking> CreateMoveFromPosOrderLinesInternalAsync(object lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _create_move_from_pos_order_lines(self, lines):
            // self.ensure_one()
            // 
            // def get_grouping_key(line):
            //     return (line.product_id.id, tuple(sorted(line.attribute_value_ids.ids)))
            // 
            // lines_by_product_and_attrs = groupby(sorted(lines, key=get_grouping_key), key=get_grouping_key)
            // move_vals = []
            // for _product, olines in lines_by_product_and_attrs:
            //     order_lines = self.env['pos.order.line'].concat(*olines)
            //     move_vals.append(self._prepare_stock_move_vals(order_lines[0], order_lines))
            // moves = self.env['stock.move'].create(move_vals)
            // confirmed_moves = moves._action_confirm()
            // confirmed_moves._add_mls_related_to_order(lines, are_qties_done=True)
            // confirmed_moves.picked = True
            // self._link_owner_on_return_picking(lines)
            --- ODOO METHOD SOURCE (MODULE: pos_repair, FILE: stock_picking.py) ---
            // def _create_move_from_pos_order_lines(self, lines):
            // return super()._create_move_from_pos_order_lines(lines.filtered(lambda line: not line.sale_order_line_id or not line.sale_order_line_id.is_repair_line))
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: stock_picking.py) ---
            // def _create_move_from_pos_order_lines(self, lines):
            // lines_to_unreserve = self.env['pos.order.line']
            // for line in lines:
            //     if line.order_id.shipping_date:
            //         continue
            //     if any(wh != line.order_id.config_id.warehouse_id for wh in line.sale_order_line_id.move_ids.location_id.warehouse_id):
            //         continue
            //     lines_to_unreserve |= line
            // lines_to_unreserve.sale_order_line_id.move_ids.filtered(lambda ml: ml.state not in ['cancel', 'done'])._do_unreserve()
            // return super()._create_move_from_pos_order_lines(lines)
            */
            return default;
        }

        protected async Task<StockPicking> CreatePickingFromPosOrderLinesInternalAsync(Guid location_dest_id, object lines, object picking_type, object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _create_picking_from_pos_order_lines(self, location_dest_id, lines, picking_type, partner=False):
            // """We'll create some picking based on order_lines"""
            // 
            // pickings = self.env['stock.picking']
            // stockable_lines = lines.filtered(lambda l: l.product_id.type == 'consu' and not l.product_id.uom_id.is_zero(l.qty))
            // if not stockable_lines:
            //     return pickings
            // positive_lines = stockable_lines.filtered(lambda l: l.qty > 0)
            // negative_lines = stockable_lines - positive_lines
            // 
            // if positive_lines:
            //     location_id = picking_type.default_location_src_id.id
            //     positive_picking = self.env['stock.picking'].create(
            //         self._prepare_picking_vals(partner, picking_type, location_id, location_dest_id)
            //     )
            // 
            //     positive_picking._create_move_from_pos_order_lines(positive_lines)
            //     self.env.flush_all()
            //     try:
            //         with self.env.cr.savepoint():
            //             positive_picking._action_done()
            //     except (UserError, ValidationError):
            //         pass
            // 
            //     pickings |= positive_picking
            // if negative_lines:
            //     if picking_type.return_picking_type_id:
            //         return_picking_type = picking_type.return_picking_type_id
            //         return_location_id = return_picking_type.default_location_dest_id.id
            //     else:
            //         return_picking_type = picking_type
            //         return_location_id = picking_type.default_location_src_id.id
            // 
            //     negative_picking = self.env['stock.picking'].create(
            //         self._prepare_picking_vals(partner, return_picking_type, location_dest_id, return_location_id)
            //     )
            //     negative_picking._create_move_from_pos_order_lines(negative_lines)
            //     self.env.flush_all()
            //     try:
            //         with self.env.cr.savepoint():
            //             negative_picking._action_done()
            //     except (UserError, ValidationError):
            //         pass
            //     pickings |= negative_picking
            // return pickings
            */
            return default;
        }

        public async Task<StockPicking> DateCategoryToDomainAsync(Guid id, StockPickingDateCategoryToDomainRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def date_category_to_domain(self, field_name, date_category):
            // """
            // Given a date category, returns a list of tuples of operator and value
            // that can be used in a domain to filter records based on their scheduled date.
            // 
            // Args:
            //     date_category (str): The date category to use for the computation.
            //         Allowed values are:
            //         * "before"
            //         * "yesterday"
            //         * "today"
            //         * "day_1"
            //         * "day_2"
            //         * "after"
            // 
            // Returns:
            //     a list of tuples:
            //         each tuple consists of an operator and a value that can be used in
            //         a domain to filter records based on their scheduled date.
            //         The operator can be "<" or ">=". The value is a datetime object.
            //         If an incorrect date category is passed, this method returns None.
            // """
            // start_today = fields.Datetime.context_timestamp(
            //     self.env.user, fields.Datetime.now()
            // ).replace(hour=0, minute=0, second=0, microsecond=0)
            // 
            // start_today = start_today.astimezone(pytz.UTC).replace(tzinfo=None)
            // 
            // start_yesterday = start_today + timedelta(days=-1)
            // start_day_1 = start_today + timedelta(days=1)
            // start_day_2 = start_today + timedelta(days=2)
            // start_day_3 = start_today + timedelta(days=3)
            // 
            // date_category_to_search_domain = {
            //     "before": [(field_name, "<", start_yesterday)],
            //     "yesterday": [(field_name, ">=", start_yesterday), (field_name, "<", start_today)],
            //     "today": [(field_name, ">=", start_today), (field_name, "<", start_day_1)],
            //     "day_1": [(field_name, ">=", start_day_1), (field_name, "<", start_day_2)],
            //     "day_2": [(field_name, ">=", start_day_2), (field_name, "<", start_day_3)],
            //     "after": [(field_name, ">=", start_day_3)],
            // }
            // 
            // return date_category_to_search_domain.get(date_category)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _default_picking_type_id(self):
            // picking_type_code = self.env.context.get('restricted_picking_type_code')
            // if picking_type_code:
            //     picking_types = self.env['stock.picking.type'].search([
            //         ('code', '=', picking_type_code),
            //         ('company_id', '=', self.env.company.id),
            //     ])
            //     return picking_types[:1].id
            */
            return default;
        }

        public async Task<StockPicking> DetailedOperationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def action_detailed_operations(self):
            // action = super().action_detailed_operations()
            // action['context']['has_kits'] = self.has_kits
            // return action
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_detailed_operations(self):
            // view_id = self.env.ref('stock.view_stock_move_line_detailed_operation_tree').id
            // return {
            //     'name': _('Detailed Operations'),
            //     'view_mode': 'list',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.move.line',
            //     'views': [(view_id, 'list')],
            //     'domain': [('id', 'in', self.move_line_ids.ids)],
            //     'context': {
            //         'sml_specific_default': True,
            //         'default_picking_id': self.id,
            //         'default_location_id': self.location_id.id,
            //         'default_location_dest_id': self.location_dest_id.id,
            //         'default_company_id': self.company_id.id,
            //         'show_lots_text': self.show_lots_text,
            //         'picking_code': self.picking_type_code,
            //         'create': self.state not in ('done', 'cancel'),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> DoPrintPickingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def do_print_picking(self):
            // self.write({'printed': True})
            // return self.env.ref('stock.action_report_picking').report_action(self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> DoUnreserveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def do_unreserve(self):
            // self.move_ids._do_unreserve()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> FindAutoBatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _find_auto_batch(self):
            // self.ensure_one()
            // # Check if auto_batch is enabled for this picking.
            // if not self.picking_type_id.auto_batch or not self.picking_type_id._is_auto_batch_grouped() or self.batch_id or not self.move_ids or not self._is_auto_batchable():
            //     return False
            // 
            // # Try to find a compatible batch to insert the picking
            // possible_batches = self.env['stock.picking.batch'].sudo().search(self._get_possible_batches_domain())
            // for batch in possible_batches:
            //     if batch._is_picking_auto_mergeable(self):
            //         batch.picking_ids |= self
            //         return batch
            // 
            // # If no batch were found, try to find a compatible picking and put them both in a new batch.
            // possible_pickings = self.env['stock.picking'].search(self._get_possible_pickings_domain())
            // new_batch_data = {
            //     'picking_ids': [Command.link(self.id)],
            //     'company_id': self.company_id.id if self.company_id else False,
            //     'picking_type_id': self.picking_type_id.id,
            //     'description': self._get_auto_batch_description()
            // }
            // for picking in possible_pickings:
            //     if self._is_auto_batchable(picking):
            //         # Add the picking to the new batch
            //         new_batch_data['picking_ids'].append(Command.link(picking.id))
            //         new_batch = self.env['stock.picking.batch'].sudo().create(new_batch_data)
            //         if picking.picking_type_id.batch_auto_confirm:
            //             new_batch.action_confirm()
            //         return new_batch
            // 
            // # If nothing was found after those two steps, then create a batch with the current picking alone
            // new_batch_data['user_id'] = self.user_id.id
            // new_batch = self.env['stock.picking.batch'].sudo().create(new_batch_data)
            // if self.picking_type_id.batch_auto_confirm:
            //     new_batch.action_confirm()
            // return new_batch
            */
            return default;
        }

        protected async Task<StockPicking> GetActionInternalAsync(object action_xmlid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_action(self, action_xmlid):
            // action = self.env["ir.actions.actions"]._for_xml_id(action_xmlid)
            // context = dict(self.env.context)
            // context.update(literal_eval(action['context']))
            // action['context'] = context
            // 
            // action['help'] = self.env['ir.ui.view']._render_template(
            //     'stock.help_message_template', {
            //         'picking_type_code': context.get('restricted_picking_type_code') or self.picking_type_code,
            //     }
            // )
            // 
            // return action
            */
            return default;
        }

        protected async Task<StockPicking> GetAutoBatchDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_auto_batch_description(self):
            // description = super()._get_auto_batch_description()
            // if self.picking_type_id.batch_group_by_carrier and self.carrier_id:
            //     description = f"{description}, {self.carrier_id.name}" if description else self.carrier_id.name
            // return description
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_auto_batch_description(self):
            // """ Get the description of the automatically created batch based on the grouped pickings and grouping criteria """
            // self.ensure_one()
            // description_items = []
            // if self.picking_type_id.batch_group_by_partner and self.partner_id:
            //     description_items.append(self.partner_id.name or '')
            // if self.picking_type_id.batch_group_by_destination and self.partner_id.country_id:
            //     description_items.append(self.partner_id.country_id.name)
            // if self.picking_type_id.batch_group_by_src_loc and self.location_id:
            //     description_items.append(self.location_id.display_name)
            // if self.picking_type_id.batch_group_by_dest_loc and self.location_dest_id:
            //     description_items.append(self.location_dest_id.display_name)
            // return ', '.join(description_items)
            */
            return default;
        }

        protected async Task<StockPicking> GetAutoprintReportActionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_autoprint_report_actions(self):
            // report_actions = []
            // pickings_to_print = self.filtered(lambda p: p.picking_type_id.auto_print_delivery_slip)
            // if pickings_to_print:
            //     action = self.env.ref("stock.action_report_delivery").report_action(pickings_to_print.ids, config=False)
            //     clean_action(action, self.env)
            //     report_actions.append(action)
            // pickings_print_return_slip = self.filtered(lambda p: p.picking_type_id.auto_print_return_slip)
            // if pickings_print_return_slip:
            //     action = self.env.ref("stock.return_label_report").report_action(pickings_print_return_slip.ids, config=False)
            //     clean_action(action, self.env)
            //     report_actions.append(action)
            // 
            // if self.env.user.has_group('stock.group_reception_report'):
            //     reception_reports_to_print = self.filtered(
            //         lambda p: p.picking_type_id.auto_print_reception_report
            //                   and p.picking_type_id.code != 'outgoing'
            //                   and p.move_ids.move_dest_ids
            //     )
            //     if reception_reports_to_print:
            //         action = self.env.ref('stock.stock_reception_report_action').report_action(reception_reports_to_print, config=False)
            //         clean_action(action, self.env)
            //         report_actions.append(action)
            //     reception_labels_to_print = self.filtered(lambda p: p.picking_type_id.auto_print_reception_report_labels and p.picking_type_id.code != 'outgoing')
            //     if reception_labels_to_print:
            //         moves_to_print = reception_labels_to_print.move_ids.move_dest_ids
            //         if moves_to_print:
            //             # needs to be string to support python + js calls to report
            //             quantities = ','.join(str(qty) for qty in moves_to_print.mapped(lambda m: math.ceil(m.product_uom_qty)))
            //             data = {
            //                 'docids': moves_to_print.ids,
            //                 'quantity': quantities,
            //             }
            //             action = self.env.ref('stock.label_picking').report_action(moves_to_print, data=data, config=False)
            //             clean_action(action, self.env)
            //             report_actions.append(action)
            // pickings_print_product_label = self.filtered(lambda p: p.picking_type_id.auto_print_product_labels)
            // pickings_by_print_formats = pickings_print_product_label.grouped(lambda p: p.picking_type_id.product_label_format)
            // for print_format in pickings_print_product_label.picking_type_id.mapped("product_label_format"):
            //     pickings = pickings_by_print_formats.get(print_format)
            //     wizard = self.env['product.label.layout'].create({
            //         'product_ids': pickings.move_ids.product_id.ids,
            //         'move_ids': pickings.move_ids.ids,
            //         'move_quantity': 'move',
            //         'print_format': pickings.picking_type_id.product_label_format,
            //     })
            //     action = wizard.process()
            //     if action:
            //         clean_action(action, self.env)
            //         report_actions.append(action)
            // if self.env.user.has_group('stock.group_production_lot'):
            //     pickings_print_lot_label = self.filtered(lambda p: p.picking_type_id.auto_print_lot_labels and p.move_line_ids.lot_id)
            //     pickings_by_print_formats = pickings_print_lot_label.grouped(lambda p: p.picking_type_id.lot_label_format)
            //     for print_format in pickings_print_lot_label.picking_type_id.mapped("lot_label_format"):
            //         pickings = pickings_by_print_formats.get(print_format)
            //         wizard = self.env['lot.label.layout'].create({
            //             'move_line_ids': pickings.move_line_ids.ids,
            //             'label_quantity': 'lots' if '_lots' in print_format else 'units',
            //             'print_format': '4x12' if '4x12' in print_format else 'zpl',
            //         })
            //         action = wizard.process()
            //         if action:
            //             clean_action(action, self.env)
            //             report_actions.append(action)
            // if self.env.user.has_group('stock.group_tracking_lot'):
            //     pickings_print_packages = self.filtered(lambda p: p.picking_type_id.auto_print_packages and p.move_line_ids.result_package_id)
            //     if pickings_print_packages:
            //         action = self.env.ref("stock.action_report_picking_packages").report_action(pickings_print_packages.ids, config=False)
            //         clean_action(action, self.env)
            //         report_actions.append(action)
            // return report_actions
            */
            return default;
        }

        public async Task<StockPicking> GetClickGraphAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def get_action_click_graph(self):
            // picking_type_id = self.env.context["picking_type_id"]
            // picking_type_code = self.env["stock.picking.type"].browse(picking_type_id).code
            // 
            // if picking_type_code == "mrp_operation":
            //     action = self._get_action("mrp.action_picking_tree_mrp_operation_graph")
            //     action["domain"] = Domain.AND([
            //         literal_eval(action["domain"] or '[]'), [('picking_type_id', '=', picking_type_id)]
            //     ])
            //     allowed_company_ids = self.env.context.get("allowed_company_ids", [])
            //     if allowed_company_ids:
            //         action["context"].update({
            //             "default_company_id": allowed_company_ids[0],
            //         })
            //     return action
            // 
            // return super().get_action_click_graph()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def get_action_click_graph(self):
            // picking_type_code = self.env["stock.picking.type"].browse(
            //     self.env.context["picking_type_id"]
            // ).code
            // 
            // if picking_type_code == "repair_operation":
            //     action = self._get_action("repair.action_picking_repair_graph")
            //     if self:
            //         action["context"].update({
            //             "default_picking_type_id": self.picking_type_id,
            //             "picking_type_id": self.picking_type_id,
            //         })
            //     return action
            // 
            // return super().get_action_click_graph()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_click_graph(self):
            // return self._get_action("stock.action_picking_tree_graph")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _get_default_weight_uom(self):
            // return self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<StockPicking> GetEmptyListHelpAsync(Guid id, StockPickingGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_empty_list_help(self, help_message):
            // return self.env['ir.ui.view']._render_template(
            //     'stock.help_message_template', {
            //         'picking_type_code': self.env.context.get('restricted_picking_type_code') or self.picking_type_code,
            //     }
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> GetEntirePackLocationDestInternalAsync(List<Guid> move_line_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_entire_pack_location_dest(self, move_line_ids):
            // location_dest_ids = move_line_ids.mapped('location_dest_id')
            // if len(location_dest_ids) > 1:
            //     return False
            // return location_dest_ids.id
            */
            return default;
        }

        protected async Task<StockPicking> GetEstimatedWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _get_estimated_weight(self):
            // self.ensure_one()
            // weight = 0.0
            // for move in self.move_ids:
            //     weight += move.product_qty * move.product_id.weight
            // return weight
            */
            return default;
        }

        protected async Task<StockPicking> GetImpactedPickingsInternalAsync(object moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_impacted_pickings(self, moves):
            // """ This function is used in _log_less_quantities_than_expected
            // the purpose is to notify a user with all the pickings that are
            // impacted by an action on a chained move.
            // param: 'moves' contain moves that belong to a common picking.
            // return: all the pickings that contain a destination moves
            // (direct and indirect) from the moves given as arguments.
            // """
            // 
            // def _explore(impacted_pickings, explored_moves, moves_to_explore):
            //     for move in moves_to_explore:
            //         if move not in explored_moves:
            //             impacted_pickings |= move.picking_id
            //             explored_moves |= move
            //             moves_to_explore |= move.move_dest_ids
            //     moves_to_explore = moves_to_explore - explored_moves
            //     if moves_to_explore:
            //         return _explore(impacted_pickings, explored_moves, moves_to_explore)
            //     else:
            //         return impacted_pickings
            // 
            // return _explore(self.env['stock.picking'], self.env['stock.move'], moves)
            */
            return default;
        }

        protected async Task<StockPicking> GetLotMoveLinesForSanityCheckInternalAsync(List<Guid> none_done_picking_ids, object separate_pickings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_lot_move_lines_for_sanity_check(self, none_done_picking_ids, separate_pickings=True):
            // """ Get all move_lines with tracked products that need to be checked over in the sanity check.
            //     :param none_done_picking_ids: Set of all pickings ids that have no quantity set on any move_line.
            //     :param separate_pickings: Indicates if pickings should be checked independently for lot/serial numbers or not.
            // """
            // def get_relevant_move_line_ids(none_done_picking_ids, picking):
            //     # Get all move_lines if picking has no quantity set, otherwise only get the move_lines with some quantity set.
            //     if picking.id in none_done_picking_ids:
            //         return picking.move_line_ids.filtered(lambda ml: ml.product_id and ml.product_id.tracking != 'none').ids
            //     else:
            //         return get_line_with_done_qty_ids(picking.move_line_ids)
            // 
            // def get_line_with_done_qty_ids(move_lines):
            //     # Get only move_lines that has some quantity set.
            //     return move_lines.filtered(lambda ml: ml.product_id and ml.product_id.tracking != 'none' and ml.picked and ml.product_uom_id.compare(ml.quantity, 0)).ids
            // 
            // if separate_pickings:
            //     # If pickings are checked independently, get full/partial move_lines depending if each picking has no quantity set.
            //     lines_to_check_ids = [line_id for picking in self for line_id in get_relevant_move_line_ids(none_done_picking_ids, picking)]
            // else:
            //     # If pickings are checked as one (like in a batch), then get only the move_lines with quantity across all pickings if there is at least one.
            //     if any(picking.id not in none_done_picking_ids for picking in self):
            //         lines_to_check_ids = get_line_with_done_qty_ids(self.move_line_ids)
            //     else:
            //         lines_to_check_ids = self.move_line_ids.filtered(lambda ml: ml.product_id and ml.product_id.tracking != 'none').ids
            // 
            // return self.env['stock.move.line'].browse(lines_to_check_ids)
            */
            return default;
        }

        protected async Task<StockPicking> GetMatchingDeliveryLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _get_matching_delivery_lines(self):
            // return self.sale_id.order_line.filtered(
            //     lambda l: l.is_delivery
            //     and l.currency_id.is_zero(l.price_unit)
            //     and l.product_id == self.carrier_id.product_id
            // )
            */
            return default;
        }

        protected async Task<StockPicking> GetMovesToBackorderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_moves_to_backorder(self):
            // self.ensure_one()
            // return self.move_ids.filtered(lambda x: x.state not in ('done', 'cancel'))
            */
            return default;
        }

        public async Task<StockPicking> GetMultipleCarrierTrackingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def get_multiple_carrier_tracking(self):
            // self.ensure_one()
            // try:
            //     return json.loads(self.carrier_tracking_url)
            // except (ValueError, TypeError):
            //     return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> GetNextTransfersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_next_transfers(self):
            // next_pickings = self.move_ids.move_dest_ids.picking_id
            // return next_pickings.filtered(lambda p: p not in self.return_ids)
            */
            return default;
        }

        protected async Task<StockPicking> GetPackagesForPrintInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_packages_for_print(self):
            // package_ids = OrderedSet()
            // for picking in self:
            //     if picking.state == 'done':
            //         package_ids.update(picking.package_history_ids.package_id.ids)
            //     else:
            //         package_ids.update(picking.move_line_ids.result_package_id._get_all_package_dest_ids())
            // return self.env['stock.package'].browse(package_ids)
            */
            return default;
        }

        public async Task<StockPicking> GetPickingTreeIncomingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_incoming(self):
            // return self._get_action('stock.action_picking_tree_incoming')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> GetPickingTreeInternalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_internal(self):
            // return self._get_action('stock.action_picking_tree_internal')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> GetPickingTreeOutgoingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_outgoing(self):
            // return self._get_action('stock.action_picking_tree_outgoing')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> GetPossibleBatchesDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_possible_batches_domain(self):
            // domain = super()._get_possible_batches_domain()
            // if self.picking_type_id.batch_group_by_carrier:
            //     domain &= Domain('picking_ids.carrier_id', '=', self.carrier_id.id if self.carrier_id else False)
            // 
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_possible_batches_domain(self):
            // self.ensure_one()
            // domain = [
            //     ('state', 'in', ('draft', 'in_progress') if self.picking_type_id.batch_auto_confirm else ('draft',)),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('company_id', '=', self.company_id.id if self.company_id else False),
            //     ('is_wave', '=', False)
            // ]
            // if self.picking_type_id.batch_group_by_partner:
            //     domain.append(('picking_ids.partner_id', '=', self.partner_id.id))
            // if self.picking_type_id.batch_group_by_destination:
            //     domain.append(('picking_ids.partner_id.country_id', '=', self.partner_id.country_id.id))
            // if self.picking_type_id.batch_group_by_src_loc:
            //     domain.append(('picking_ids.location_id', '=', self.location_id.id))
            // if self.picking_type_id.batch_group_by_dest_loc:
            //     domain.append(('picking_ids.location_dest_id', '=', self.location_dest_id.id))
            // 
            // return Domain(domain)
            */
            return default;
        }

        protected async Task<StockPicking> GetPossiblePickingsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_possible_pickings_domain(self):
            // domain = super()._get_possible_pickings_domain()
            // if self.picking_type_id.batch_group_by_carrier:
            //     domain &= Domain('carrier_id', '=', self.carrier_id.id if self.carrier_id else False)
            // 
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_possible_pickings_domain(self):
            // self.ensure_one()
            // domain = [
            //     ('id', '!=', self.id),
            //     ('company_id', '=', self.company_id.id if self.company_id else False),
            //     ('state', '=', 'assigned'),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('batch_id', '=', False),
            // ]
            // if self.picking_type_id.batch_group_by_partner:
            //     domain.append(('partner_id', '=', self.partner_id.id))
            // if self.picking_type_id.batch_group_by_destination:
            //     domain.append(('partner_id.country_id', '=', self.partner_id.country_id.id))
            // if self.picking_type_id.batch_group_by_src_loc:
            //     domain.append(('location_id', '=', self.location_id.id))
            // if self.picking_type_id.batch_group_by_dest_loc:
            //     domain.append(('location_dest_id', '=', self.location_dest_id.id))
            // 
            // return Domain(domain)
            */
            return default;
        }

        protected async Task<StockPicking> GetReportLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_report_lang(self):
            // return self.move_ids and self.move_ids[0].partner_id.lang or self.partner_id.lang or self.env.lang
            */
            return default;
        }

        protected async Task<StockPicking> GetShowAllocationInternalAsync(Guid picking_type_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_show_allocation(self, picking_type_id):
            // """ Helper method for computing "show_allocation" value.
            // Separated out from _compute function so it can be reused in other models (e.g. batch).
            // """
            // if not picking_type_id or picking_type_id.code == 'outgoing':
            //     return False
            // lines = self.move_ids.filtered(lambda m: m.product_id.is_storable and m.state != 'cancel')
            // if lines:
            //     allowed_states = ['confirmed', 'partially_available', 'waiting']
            //     if self[0].state == 'done':
            //         allowed_states += ['assigned']
            //     wh_location_ids = self.env['stock.location']._search([('id', 'child_of', picking_type_id.warehouse_id.view_location_id.id), ('usage', '!=', 'supplier')])
            //     if self.env['stock.move'].search_count([
            //         ('state', 'in', allowed_states),
            //         ('product_qty', '>', 0),
            //         ('location_id', 'in', wh_location_ids),
            //         ('picking_id', 'not in', self.ids),
            //         ('product_id', 'in', lines.product_id.ids),
            //         '|', ('move_orig_ids', '=', False),
            //              ('move_orig_ids', 'in', lines.ids)], limit=1):
            //         return True
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractMoConfirmationCtxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _get_subcontract_mo_confirmation_ctx(self):
            // if self._is_subcontract() and not self.env.context.get('cancel_backorder', True):
            //     # Do not trigger rules on raw moves when creating backorder for a subcontract receipt.
            //     return {'no_procurement': True}
            // return {}
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py) ---
            // def _get_subcontract_mo_confirmation_ctx(self):
            // res = super()._get_subcontract_mo_confirmation_ctx()
            // res['po_to_notify'] = self.move_ids.purchase_line_id.order_id
            // return res
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractProductionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _get_subcontract_production(self):
            // return self.move_ids._get_subcontract_production()
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractingSourcePurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py) ---
            // def _get_subcontracting_source_purchase(self):
            // moves_subcontracted = self.move_ids.move_dest_ids.raw_material_production_id.move_finished_ids.move_dest_ids.filtered(lambda m: m.is_subcontract)
            // return moves_subcontracted.purchase_line_id.order_id
            */
            return default;
        }

        protected async Task<StockPicking> GetWarehouseInternalAsync(object subcontract_move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _get_warehouse(self, subcontract_move):
            // return subcontract_move.warehouse_id or self.picking_type_id.warehouse_id or subcontract_move.move_dest_ids.picking_type_id.warehouse_id
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py) ---
            // def _get_warehouse(self, subcontract_move):
            // if subcontract_move.sale_line_id:
            //     return subcontract_move.sale_line_id.order_id.warehouse_id
            // return super()._get_warehouse(subcontract_move)
            */
            return default;
        }

        protected async Task<StockPicking> GetWithoutQuantitiesErrorMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_without_quantities_error_message(self):
            // """ Returns the error message raised in validation if no quantities are reserved.
            // The purpose of this method is to be overridden in case we want to adapt this message.
            // 
            // :return: Translated error message
            // :rtype: str
            // """
            // return _(
            //     "Transfer trouble alert! Validating a zero quantity transfer? You're not moving invisible goods around are you?\n"
            //     "Set some quantities and let's get moving!"
            // )
            */
            return default;
        }

        protected async Task<StockPicking> HasScrapMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _has_scrap_move(self):
            // result = {
            //     picking
            //     for [picking] in self.env['stock.move']._read_group(
            //         [('picking_id', 'in', self.ids), ('location_dest_usage', '=', 'inventory')],
            //         ['picking_id'],
            //     )
            // }
            // for picking in self:
            //     picking.has_scrap_move = picking._origin in result
            */
            return default;
        }

        protected async Task<StockPicking> IsAutoBatchableInternalAsync(object picking)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _is_auto_batchable(self, picking=None):
            // """ Verifies if a picking can be put in a batch with another picking without violating auto_batch constrains.
            // """
            // res = super()._is_auto_batchable(picking)
            // if not picking:
            //     picking = self.env['stock.picking']
            // if self.picking_type_id.batch_max_weight:
            //     res = res and (self.weight + picking.weight <= self.picking_type_id.batch_max_weight)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _is_auto_batchable(self, picking=None):
            // """ Verifies if a picking can be put in a batch with another picking without violating auto_batch constrains.
            // """
            // if self.state != 'assigned':
            //     return False
            // res = True
            // if not picking:
            //     picking = self.env['stock.picking']
            // if self.picking_type_id.batch_max_lines:
            //     res = res and (len(self.move_ids) + len(picking.move_ids) <= self.picking_type_id.batch_max_lines)
            // if self.picking_type_id.batch_max_pickings:
            //     # Sounds absurd. BUT if we put "batch max picking" to a value <= 1, makes sense ... Or not. Because then there is no point to batch.
            //     res = res and self.picking_type_id.batch_max_pickings > 1
            // return res
            */
            return default;
        }

        protected async Task<StockPicking> IsDateInLockPeriodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py) ---
            // def _is_date_in_lock_period(self):
            // self.ensure_one()
            // lock = self.company_id._get_lock_date_violations(self.scheduled_date.date(), fiscalyear=True, sale=False, purchase=False, tax=False, hard=True)
            // if self.date_done:
            //     lock += self.company_id._get_lock_date_violations(self.date_done.date(), fiscalyear=True, sale=False, purchase=False, tax=False, hard=True)
            // return bool(lock)
            */
            return default;
        }

        protected async Task<StockPicking> IsSingleTransferInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _is_single_transfer(self):
            // # Overriden for batches.
            // return len(self) == 1
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _is_single_transfer(self):
            // return super()._is_single_transfer() or len(self.batch_id) == 1
            */
            return default;
        }

        protected async Task<StockPicking> IsSubcontractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _is_subcontract(self):
            // self.ensure_one()
            // return self.picking_type_id.code == 'incoming' and any(m.is_subcontract for m in self.move_ids)
            */
            return default;
        }

        protected async Task<StockPicking> IsToExternalLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _is_to_external_location(self):
            // self.ensure_one()
            // return self.picking_type_code == 'outgoing'
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _is_to_external_location(self):
            // self.ensure_one()
            // return super()._is_to_external_location() or self.is_dropship
            */
            return default;
        }

        protected async Task<StockPicking> LessQuantitiesThanExpectedAddDocumentsInternalAsync(object moves, object documents)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _less_quantities_than_expected_add_documents(self, moves, documents):
            // documents = super(StockPicking, self)._less_quantities_than_expected_add_documents(moves, documents)
            // 
            // def _keys_in_groupby(move):
            //     """ group by picking and the responsible for the product the
            //     move.
            //     """
            //     return (move.raw_material_production_id, move.product_id.responsible_id)
            // 
            // production_documents = self._log_activity_get_documents(moves, 'move_dest_ids', 'DOWN', _keys_in_groupby)
            // return {**documents, **production_documents}
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _less_quantities_than_expected_add_documents(self, moves, documents):
            // return documents
            */
            return default;
        }

        protected async Task<StockPicking> LinkOwnerOnReturnPickingInternalAsync(object lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _link_owner_on_return_picking(self, lines):
            // """This method tries to retrieve the owner of the returned product"""
            // if lines and lines[0].order_id.refunded_order_id.picking_ids:
            //     returned_lines_picking = lines[0].order_id.refunded_order_id.picking_ids
            //     returnable_qty_by_product = {}
            //     for move_line in returned_lines_picking.move_line_ids:
            //         returnable_qty_by_product[(move_line.product_id.id, move_line.owner_id.id or 0)] = move_line.quantity
            //     for move in self.move_line_ids:
            //         for keys in returnable_qty_by_product:
            //             if move.product_id.id == keys[0] and keys[1] and returnable_qty_by_product[keys] > 0:
            //                 move.write({'owner_id': keys[1]})
            //                 returnable_qty_by_product[keys] -= move.quantity
            */
            return default;
        }

        protected async Task<StockPicking> LogActivityGetDocumentsInternalAsync(object orig_obj_changes, object stream_field, object stream, object groupby_method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _log_activity_get_documents(self, orig_obj_changes, stream_field, stream, groupby_method=False):
            // """ Generic method to log activity. To use with
            // _log_activity method. It either log on uppermost
            // ongoing documents or following documents. This method
            // find all the documents and responsible for which a note
            // has to be log. It also generate a rendering_context in
            // order to render a specific note by documents containing
            // only the information relative to the document it. For example
            // we don't want to notify a picking on move that it doesn't
            // contain.
            // 
            // :param dict orig_obj_changes: contain a record as key and the
            //     change on this record as value.
            //     eg: {'move_id': (new product_uom_qty, old product_uom_qty)}
            // :param str stream_field: It has to be a field of the
            //     records that are register in the key of 'orig_obj_changes'
            //     eg: 'move_dest_ids' if we use move as record (previous example)
            //         - 'UP' if we want to log on the upper most ongoing
            //         documents.
            //         - 'DOWN' if we want to log on following documents.
            // :param str stream: ``'UP'`` or ``'DOWN'``
            // :param groupby_method: Only need when
            //     stream is 'DOWN', it should group by tuple(object on
            //     which the activity is log, the responsible for this object)
            // """
            // if self.env.context.get('skip_activity'):
            //     return {}
            // move_to_orig_object_rel = {co: ooc for ooc in orig_obj_changes.keys() for co in ooc[stream_field]}
            // origin_objects = self.env[list(orig_obj_changes.keys())[0]._name].concat(*list(orig_obj_changes.keys()))
            // # The purpose here is to group each destination object by
            // # (document to log, responsible) no matter the stream direction.
            // # example:
            // # {'(delivery_picking_1, admin)': stock.move(1, 2)
            // #  '(delivery_picking_2, admin)': stock.move(3)}
            // visited_documents = {}
            // if stream == 'DOWN':
            //     if groupby_method:
            //         grouped_moves = groupby(origin_objects.mapped(stream_field), key=groupby_method)
            //     else:
            //         raise AssertionError('You have to define a groupby method and pass them as arguments.')
            // elif stream == 'UP':
            //     # When using upstream document it is required to define
            //     # _get_upstream_documents_and_responsibles on
            //     # destination objects in order to ascend documents.
            //     grouped_moves = {}
            //     for visited_move in origin_objects.mapped(stream_field):
            //         for document, responsible, visited in visited_move._get_upstream_documents_and_responsibles(self.env[visited_move._name]):
            //             if grouped_moves.get((document, responsible)):
            //                 grouped_moves[(document, responsible)] |= visited_move
            //                 visited_documents[(document, responsible)] |= visited
            //             else:
            //                 grouped_moves[(document, responsible)] = visited_move
            //                 visited_documents[(document, responsible)] = visited
            //     grouped_moves = grouped_moves.items()
            // else:
            //     raise AssertionError('Unknown stream.')
            // 
            // documents = {}
            // for (parent, responsible), moves in grouped_moves:
            //     if not parent:
            //         continue
            //     moves = self.env[moves[0]._name].concat(*moves)
            //     # Get the note
            //     rendering_context = {move: (orig_object, orig_obj_changes[orig_object]) for move in moves for orig_object in move_to_orig_object_rel[move]}
            //     if visited_documents:
            //         documents[(parent, responsible)] = rendering_context, visited_documents.values()
            //     else:
            //         documents[(parent, responsible)] = rendering_context
            // return documents
            */
            return default;
        }

        protected async Task<StockPicking> LogActivityInternalAsync(object render_method, object documents)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _log_activity(self, render_method, documents):
            // """ Log a note for each documents, responsible pair in
            // documents passed as argument. The render_method is then
            // call in order to use a template and render it with a
            // rendering_context.
            // 
            // :param dict documents: A tuple (document, responsible) as key.
            //     An activity will be log by key. A rendering_context as value.
            //     If used with _log_activity_get_documents. In 'DOWN' stream
            //     cases the rendering_context will be a dict with format:
            //     {'stream_object': ('orig_object', new_qty, old_qty)}
            //     'UP' stream will add all the documents browsed in order to
            //     get the final/upstream document present in the key.
            // :param callable render_method: a static function that will generate
            //     the html note to log on the activity. The render_method should
            //     use the args:
            //         - rendering_context dict: value of the documents argument
            //     the render_method should return a string with an html format
            // """
            // for (parent, responsible), rendering_context in documents.items():
            //     note = render_method(rendering_context)
            //     parent.sudo().activity_schedule(
            //         'mail.mail_activity_data_warning',
            //         date.today(),
            //         note=note,
            //         user_id=responsible.id,
            //     )
            */
            return default;
        }

        protected async Task<StockPicking> LogLessQuantitiesThanExpectedInternalAsync(object moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _log_less_quantities_than_expected(self, moves):
            // """ Log an activity on sale order that are linked to moves. The
            // note summarize the real processed quantity and promote a
            // manual action.
            // 
            // :param dict moves: a dict with a move as key and tuple with
            // new and old quantity as value. eg: {move_1 : (4, 5)}
            // """
            // 
            // def _keys_in_groupby(sale_line):
            //     """ group by order_id and the sale_person on the order """
            //     return (sale_line.order_id, sale_line.order_id.user_id)
            // 
            // def _render_note_exception_quantity(moves_information):
            //     """ Generate a note with the picking on which the action
            //     occurred and a summary on impacted quantity that are
            //     related to the sale order where the note will be logged.
            // 
            //     :param moves_information dict:
            //     {'move_id': ['sale_order_line_id', (new_qty, old_qty)], ..}
            // 
            //     :return: an html string with all the information encoded.
            //     :rtype: str
            //     """
            //     origin_moves = self.env['stock.move'].browse([move.id for move_orig in moves_information.values() for move in move_orig[0]])
            //     origin_picking = origin_moves.mapped('picking_id')
            //     values = {
            //         'origin_moves': origin_moves,
            //         'origin_picking': origin_picking,
            //         'moves_information': moves_information.values(),
            //     }
            //     return self.env['ir.qweb']._render('sale_stock.exception_on_picking', values)
            // 
            // documents = self.sudo()._log_activity_get_documents(moves, 'sale_line_id', 'DOWN', _keys_in_groupby)
            // self._log_activity(_render_note_exception_quantity, documents)
            // 
            // return super(StockPicking, self)._log_less_quantities_than_expected(moves)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _log_less_quantities_than_expected(self, moves):
            // """ Log an activity on picking that follow moves. The note
            // contains the moves changes and all the impacted picking.
            // 
            // :param dict moves: a dict with a move as key and tuple with
            // new and old quantity as value. eg: {move_1 : (4, 5)}
            // """
            // def _keys_in_groupby(move):
            //     """ group by picking and the responsible for the product the
            //     move.
            //     """
            //     return (move.picking_id, move.product_id.responsible_id)
            // 
            // def _render_note_exception_quantity(rendering_context):
            //     """ :param rendering_context:
            //     {'move_dest': (move_orig, (new_qty, old_qty))}
            //     """
            //     origin_moves = self.env['stock.move'].browse([move.id for move_orig in rendering_context.values() for move in move_orig[0]])
            //     origin_picking = origin_moves.mapped('picking_id')
            //     move_dest_ids = self.env['stock.move'].concat(*rendering_context.keys())
            //     impacted_pickings = origin_picking._get_impacted_pickings(move_dest_ids) - move_dest_ids.mapped('picking_id')
            //     values = {
            //         'origin_picking': origin_picking,
            //         'moves_information': rendering_context.values(),
            //         'impacted_pickings': impacted_pickings,
            //     }
            //     return self.env['ir.qweb']._render('stock.exception_on_picking', values)
            // 
            // documents = self._log_activity_get_documents(moves, 'move_dest_ids', 'DOWN', _keys_in_groupby)
            // documents = self._less_quantities_than_expected_add_documents(moves, documents)
            // self._log_activity(_render_note_exception_quantity, documents)
            */
            return default;
        }

        public async Task<StockPicking> NextTransferAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_next_transfer(self):
            // next_transfers = self._get_next_transfers()
            // 
            // if len(next_transfers) == 1:
            //     return {
            //         "type": "ir.actions.act_window",
            //         "res_model": "stock.picking",
            //         "views": [[False, "form"]],
            //         "res_id": next_transfers.id
            //     }
            // return {
            //     'name': _('Next Transfers'),
            //     "type": "ir.actions.act_window",
            //     "res_model": "stock.picking",
            //     "views": [[False, "list"], [False, "form"]],
            //     "domain": [('id', 'in', next_transfers.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> OnchangeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _onchange_location_id(self):
            // self.move_ids.location_id = self.location_id
            // for move in self.move_ids.filtered(lambda m: m.move_orig_ids):
            //     for ml in move.move_line_ids:
            //         parent_path = [int(loc_id) for loc_id in ml.location_id.parent_path.split('/')[:-1]]
            //         if self.location_id.id not in parent_path:
            //             return {'warning': {
            //                     'title': _("Warning: change source location"),
            //                     'message': _("Updating the location of this transfer will result in unreservation of the currently assigned items. "
            //                                  "An attempt to reserve items at the new location will be made and the link with preceding transfers will be discarded.\n\n"
            //                                  "To avoid this, please discard the source location change before saving.")
            //                 }
            //             }
            */
            return default;
        }

        protected async Task<StockPicking> OnchangePickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _onchange_picking_type(self):
            // if self.picking_type_id and self.state == 'draft':
            //     self = self.with_company(self.company_id)
            //     self.move_ids.filtered(
            //         lambda m: m.picking_type_id != self.picking_type_id
            //     ).picking_type_id = self.picking_type_id
            //     self.move_ids.company_id = self.company_id
            */
            return default;
        }

        public async Task<StockPicking> OpenLabelLayoutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_open_label_layout(self):
            // view = self.env.ref('stock.product_label_layout_form_picking')
            // return {
            //     'name': _('Choose Labels Layout'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'product.label.layout',
            //     'views': [(view.id, 'form')],
            //     'target': 'new',
            //     'context': {
            //         'default_product_ids': self.move_ids.product_id.ids,
            //         'default_move_ids': self.move_ids.ids,
            //         'default_move_quantity': 'move'},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> OpenLabelTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_open_label_type(self):
            // if self.env.user.has_group('stock.group_production_lot') and self.move_line_ids.lot_id:
            //     view = self.env.ref('stock.picking_label_type_form')
            //     return {
            //         'name': _('Choose Type of Labels To Print'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'picking.label.type',
            //         'views': [(view.id, 'form')],
            //         'target': 'new',
            //         'context': {'default_picking_ids': self.ids},
            //     }
            // return self.action_open_label_layout()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def open_website_url(self):
            // self.ensure_one()
            // if not self.carrier_tracking_url:
            //     raise UserError(_("Your delivery method has no redirect on courier provider's website to track this order."))
            // 
            // carrier_trackers = []
            // try:
            //     carrier_trackers = json.loads(self.carrier_tracking_url)
            // except ValueError:
            //     carrier_trackers = self.carrier_tracking_url
            // else:
            //     msg = _("Tracking links for shipment:") + Markup("<br/>")
            //     for tracker in carrier_trackers:
            //         msg += Markup('<a href="%s">%s</a><br/>') % (tracker[1], tracker[0])
            //     self.message_post(body=msg)
            //     return self.env["ir.actions.actions"]._for_xml_id("stock_delivery.act_delivery_trackers_url")
            // 
            // client_action = {
            //     'type': 'ir.actions.act_url',
            //     'name': "Shipment Tracking Page",
            //     'target': 'new',
            //     'url': self.carrier_tracking_url,
            // }
            // return client_action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> PickingMoveTreeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_picking_move_tree(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_move_action")
            // action['views'] = [
            //     (self.env.ref('stock.view_picking_move_tree').id, 'list'),
            // ]
            // action['context'] = self.env.context
            // action['domain'] = [('picking_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> PreActionDoneHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py) ---
            // def _pre_action_done_hook(self):
            // res = super()._pre_action_done_hook()
            // # We use the 'skip_expired' context key to avoid to make the check when
            // # user did already confirmed the wizard about expired lots.
            // if res is True and not self.env.context.get('skip_expired'):
            //     pickings_to_warn_expired = self._check_expired_lots()
            //     if pickings_to_warn_expired:
            //         return pickings_to_warn_expired._action_generate_expired_wizard()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _pre_action_done_hook(self):
            // for picking in self:
            //     has_quantity = False
            //     has_pick = False
            //     for move in picking.move_ids:
            //         if move.quantity:
            //             has_quantity = True
            //         if move.location_dest_usage == 'inventory':
            //             continue
            //         if move.picked:
            //             has_pick = True
            //         if has_quantity and has_pick:
            //             break
            //     if has_quantity and not has_pick:
            //         picking.move_ids.picked = True
            // if not self.env.context.get('skip_backorder'):
            //     pickings_to_backorder = self._check_backorder()
            //     if pickings_to_backorder:
            //         return pickings_to_backorder._action_generate_backorder_wizard(show_transfers=self._should_show_transfers())
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py) ---
            // def _pre_action_done_hook(self):
            // res = super()._pre_action_done_hook()
            // if res is True and not self.env.context.get('skip_sms'):
            //     pickings_to_warn_sms = self._check_warn_sms()
            //     if pickings_to_warn_sms:
            //         return pickings_to_warn_sms._action_generate_warn_sms_wizard()
            // return res
            */
            return default;
        }

        protected async Task<StockPicking> PrepareEntirePackMoveLineValsInternalAsync(object packages)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _prepare_entire_pack_move_line_vals(self, packages):
            // """ Prepares the move line values for every packages within packages and their children that contain products.
            // """
            // self.ensure_one()
            // move_line_vals = []
            // for package_quant in packages.quant_ids:
            //     move_line_vals.append({
            //         'product_id': package_quant.product_id.id,
            //         'quantity': package_quant.quantity,
            //         'product_uom_id': package_quant.product_uom_id.id,
            //         'location_id': package_quant.location_id.id,
            //         'location_dest_id': self.location_dest_id.id,
            //         'picking_id': self.id,
            //         'company_id': self.id,
            //         'package_id': package_quant.package_id.id,
            //         'result_package_id': package_quant.package_id.id,
            //         'lot_id': package_quant.lot_id.id,
            //         'owner_id': package_quant.owner_id.id,
            //         'is_entire_pack': True,
            //     })
            // return move_line_vals
            */
            return default;
        }

        protected async Task<StockPicking> PreparePickingValsInternalAsync(object partner, object picking_type, Guid location_id, Guid location_dest_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _prepare_picking_vals(self, partner, picking_type, location_id, location_dest_id):
            // return {
            //     'partner_id': partner.id if partner else False,
            //     'user_id': False,
            //     'picking_type_id': picking_type.id,
            //     'move_type': 'direct',
            //     'location_id': location_id,
            //     'location_dest_id': location_dest_id,
            //     'state': 'draft',
            // }
            */
            return default;
        }

        protected async Task<StockPicking> PrepareSaleDeliveryLineValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _prepare_sale_delivery_line_vals(self):
            // return {
            //     'price_unit': self.carrier_price,
            //     # remove the estimated price from the description
            //     'name': self.carrier_id.with_context(lang=self.partner_id.lang).name,
            // }
            */
            return default;
        }

        protected async Task<StockPicking> PrepareStockMoveValsInternalAsync(object first_line, object order_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _prepare_stock_move_vals(self, first_line, order_lines):
            // return {
            //     'product_uom': first_line.product_id.uom_id.id,
            //     'picking_id': self.id,
            //     'picking_type_id': self.picking_type_id.id,
            //     'product_id': first_line.product_id.id,
            //     'product_uom_qty': abs(sum(order_lines.mapped('qty'))),
            //     'location_id': self.location_id.id,
            //     'location_dest_id': self.location_dest_id.id,
            //     'company_id': self.company_id.id,
            //     'never_product_template_attribute_value_ids': first_line.attribute_value_ids.filtered(lambda a: a.attribute_id.create_variant == 'no_variant'),
            // }
            */
            return default;
        }

        protected async Task<StockPicking> PrepareSubcontractMoValsInternalAsync(object subcontract_move, object bom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _prepare_subcontract_mo_vals(self, subcontract_move, bom):
            // subcontract_move.ensure_one()
            // reference = self.env['stock.reference'].create({
            //     'name': self.name,
            //     'move_ids': [Command.link(subcontract_move.id)],
            // })
            // product = subcontract_move.product_id
            // warehouse = self._get_warehouse(subcontract_move)
            // subcontracting_location = \
            //     subcontract_move.picking_id.partner_id.with_company(subcontract_move.company_id).property_stock_subcontractor \
            //     or subcontract_move.company_id.subcontracting_location_id
            // vals = {
            //     'company_id': subcontract_move.company_id.id,
            //     'subcontractor_id': subcontract_move.picking_id.partner_id.commercial_partner_id.id,
            //     'picking_ids': [subcontract_move.picking_id.id],
            //     'product_id': product.id,
            //     'product_uom_id': subcontract_move.product_uom.id,
            //     'bom_id': bom.id,
            //     'location_src_id': subcontracting_location.id,
            //     'location_dest_id': subcontracting_location.id,
            //     'product_qty': subcontract_move.product_uom_qty or subcontract_move.quantity,
            //     'picking_type_id': warehouse.subcontracting_type_id.id,
            //     'date_start': subcontract_move.date - relativedelta(days=bom.produce_delay),
            //     'origin': self.name,
            //     'reference_ids': [Command.link(reference.id)],
            // }
            // return vals
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py) ---
            // def _prepare_subcontract_mo_vals(self, subcontract_move, bom):
            // res = super()._prepare_subcontract_mo_vals(subcontract_move, bom)
            // if not res.get('picking_type_id') and (
            //         subcontract_move.location_dest_id.usage == 'customer'
            //         or subcontract_move.location_dest_id.is_subcontract()
            // ):
            //     # If the if-condition is respected, it means that `subcontract_move` is not
            //     # related to a specific warehouse. This can happen if, for instance, the user
            //     # confirms a PO with a subcontracted product that should be delivered to a
            //     # customer (dropshipping). In that case, we can use a default warehouse to
            //     # get the picking type
            //     default_warehouse = self.env['stock.warehouse'].search([('company_id', '=', subcontract_move.company_id.id)], limit=1)
            //     res['picking_type_id'] = default_warehouse.subcontracting_type_id.id,
            // return res
            */
            return default;
        }

        public async Task<StockPicking> PrintReturnLabelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def print_return_label(self):
            // self.ensure_one()
            // self.carrier_id.get_return_label(self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> PutInPackAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_put_in_pack(self, *, package_id=False, package_type_id=False, package_name=False):
            // self.ensure_one()
            // if self.env.context.get('sml_specific_default'):
            //     self = self.with_context(clean_context(self.env.context))
            // if self.state not in ('done', 'cancel'):
            //     return self.move_line_ids.action_put_in_pack(package_id=package_id, package_type_id=package_type_id, package_name=package_name)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _remove_reference(self, reference):
            // """ remove the given references from the list of references. """
            // self.ensure_one()
            // self.move_ids.reference_ids = [Command.unlink(stock_reference.id) for stock_reference in reference]
            */
            return default;
        }

        public async Task<StockPicking> RepairReturnAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def action_repair_return(self):
            // self.ensure_one()
            // ctx = clean_context(self.env.context.copy())
            // warehouse = self.picking_type_id.warehouse_id or self.env.user._get_default_warehouse_id()
            // ctx.update({
            //     'default_repair_picking_id': self.id,
            //     'default_picking_type_id': warehouse.repair_type_id.id,
            //     'default_partner_id': self.partner_id and self.partner_id.id or False,
            // })
            // return {
            //     'name': _('Create Repair'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'repair.order',
            //     'view_id': self.env.ref('repair.view_repair_order_form').id,
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> ResetLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py) ---
            // def _reset_location(self):
            // for picking in self:
            //     moves = picking.move_ids.filtered(lambda m: not m.location_dest_id._child_of(picking.location_dest_id))
            //     moves.write({'location_dest_id': picking.location_dest_id.id})
            */
            return default;
        }

        protected async Task<StockPicking> SanityCheckInternalAsync(object separate_pickings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _sanity_check(self, separate_pickings=True):
            // """ Sanity check for `button_validate()`
            //     :param separate_pickings: Indicates if pickings should be checked independently for lot/serial numbers or not.
            // """
            // pickings_without_lots = self.browse()
            // products_without_lots = self.env['product.product']
            // pickings_without_moves = self.filtered(lambda p: not p.move_ids and not p.move_line_ids)
            // precision_digits = self.env['decimal.precision'].precision_get('Product Unit')
            // 
            // no_quantities_done_ids = set()
            // pickings_without_quantities = self.env['stock.picking']
            // for picking in self:
            //     has_pick = any(move.picked and move.state not in ('done', 'cancel') for move in picking.move_ids)
            //     if all(float_is_zero(move.quantity, precision_digits=precision_digits) for move in picking.move_ids.filtered(lambda m: m.state not in ('done', 'cancel') and (not has_pick or m.picked))):
            //         pickings_without_quantities |= picking
            // 
            // pickings_using_lots = self.filtered(lambda p: p.picking_type_id.use_create_lots or p.picking_type_id.use_existing_lots)
            // if pickings_using_lots:
            //     lines_to_check = pickings_using_lots._get_lot_move_lines_for_sanity_check(no_quantities_done_ids, separate_pickings)
            //     for line in lines_to_check:
            //         if not line.lot_name and not line.lot_id:
            //             pickings_without_lots |= line.picking_id
            //             products_without_lots |= line.product_id
            // 
            // if not self._should_show_transfers():
            //     if pickings_without_moves:
            //         raise UserError(_("You can’t validate an empty transfer. Please add some products to move before proceeding."))
            //     if pickings_without_quantities:
            //         raise UserError(self._get_without_quantities_error_message())
            //     if pickings_without_lots:
            //         raise UserError(_('You need to supply a Lot/Serial number for products %s.', ', '.join(products_without_lots.mapped('display_name'))))
            // else:
            //     message = ""
            //     if pickings_without_moves:
            //         message += _('Transfers %s: Please add some items to move.', ', '.join(pickings_without_moves.mapped('name')))
            //     if pickings_without_lots:
            //         message += _(
            //             '\n\nTransfers %(transfer_list)s: You need to supply a Lot/Serial number for products %(product_list)s.',
            //             transfer_list=pickings_without_lots.mapped('name'),
            //             product_list=products_without_lots.mapped('display_name'),
            //         )
            //     if message:
            //         raise UserError(message.lstrip())
            */
            return default;
        }

        protected async Task<StockPicking> SearchDateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _search_date_category(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return Domain.OR(
            //     self.date_category_to_domain('scheduled_date', item)
            //     for item in value
            // )
            */
            return default;
        }

        protected async Task<StockPicking> SearchDaysToArriveInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _search_days_to_arrive(self, operator, value):
            // return [('date_done', operator, value)]
            */
            return default;
        }

        protected async Task<StockPicking> SearchDelayAlertDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _search_delay_alert_date(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // return [('move_ids.delay_alert_date', operator, value)]
            */
            return default;
        }

        protected async Task<StockPicking> SearchDelayPassInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _search_delay_pass(self, operator, value):
            // return [('purchase_id.date_order', operator, value)]
            */
            return default;
        }

        protected async Task<StockPicking> SearchProductsAvailabilityStateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _search_products_availability_state(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // invalid_states = ('done', 'cancel', 'draft')
            // if False in value:
            //     return ['|', ('state', 'in', invalid_states), *self._search_products_availability_state('in', value - {False})]
            // value = set(self._fields['products_availability_state'].get_values(self.env)) & value
            // if not value:
            //     return Domain.FALSE
            // 
            // def _get_comparison_date(move):
            //     return move.picking_id.scheduled_date
            // 
            // def _filter_picking_moves(picking):
            //     try:
            //         return picking.move_ids._match_searched_availability(operator, value, _get_comparison_date)
            //     except UserError:
            //         # invalid value for search
            //         return False
            // 
            // pickings = self.env['stock.picking'].search([('state', 'not in', invalid_states)], order='id').filtered(_filter_picking_moves)
            // return Domain('id', 'in', pickings.ids)
            */
            return default;
        }

        protected async Task<StockPicking> SearchZipInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py) ---
            // def _search_zip(self, operator, value):
            // return [('partner_id.zip', operator, value)]
            */
            return default;
        }

        public async Task<StockPicking> SeeMoveScrapAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_see_move_scrap(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_stock_scrap")
            // scraps = self.env['stock.scrap'].search([('picking_id', '=', self.id)])
            // action['domain'] = [('id', 'in', scraps.ids)]
            // action['context'] = dict(self.env.context, create=False)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> SeePackageHistoriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_see_package_histories(self):
            // self.ensure_one()
            // return {
            //     'name': self.env._("Packages"),
            //     'res_model': 'stock.package.history',
            //     'view_mode': 'list',
            //     'views': [(False, 'list')],
            //     'type': 'ir.actions.act_window',
            //     'domain': [('picking_ids', '=', self.id)],
            //     'context': {
            //         'search_default_main_packages': 1,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> SeePackagesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_see_packages(self):
            // self.ensure_one()
            // return {
            //     'name': self.env._("Packages"),
            //     'res_model': 'stock.package',
            //     'view_mode': 'list,kanban,form',
            //     'views': [(self.env.ref('stock.stock_package_view_list_editable').id, 'list'), (False, 'kanban'), (False, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'domain': [('picking_ids', 'in', self.ids)],
            //     'context': {
            //         'picking_ids': self.ids,
            //         'location_id': self.location_id.id,
            //         'can_add_entire_packs': self.picking_type_code != 'incoming',
            //         'search_default_main_packages': True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> SeeReturnsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_see_returns(self):
            // self.ensure_one()
            // if len(self.return_ids) == 1:
            //     return {
            //         "type": "ir.actions.act_window",
            //         "res_model": "stock.picking",
            //         "views": [[False, "form"]],
            //         "res_id": self.return_ids.id
            //     }
            // return {
            //     'name': _('Returns'),
            //     "type": "ir.actions.act_window",
            //     "res_model": "stock.picking",
            //     "views": [[False, "list"], [False, "form"]],
            //     "domain": [('id', 'in', self.return_ids.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> SendConfirmationEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _send_confirmation_email(self):
            // # Avoid sending Mail/SMS for POS deliveries
            // pickings = self.filtered(lambda p: p.picking_type_id != p.picking_type_id.warehouse_id.pos_type_id)
            // return super(StockPicking, pickings)._send_confirmation_email()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _send_confirmation_email(self):
            // subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            // for stock_pick in self.filtered(lambda p: p.company_id.stock_move_email_validation and p.picking_type_id.code == 'outgoing'):
            //     delivery_template = stock_pick.company_id.stock_mail_confirmation_template_id
            //     stock_pick.with_context(force_send=True).message_post_with_source(
            //         delivery_template,
            //         email_layout_xmlid='mail.mail_notification_light',
            //         subtype_id=subtype_id,
            //     )
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _send_confirmation_email(self):
            // # The carrier's API processes validity checks and parcels generation one picking at a time.
            // # However, since a UserError of any of the picking will cause a rollback of the entire batch
            // # on Odoo's side and since pickings that were already processed on the carrier's side must
            // # stay validated, UserErrors might need to be replaced by activity warnings.
            // 
            // processed_carrier_picking = False
            // 
            // for pick in self:
            //     try:
            //         if pick.carrier_id and pick.carrier_id.integration_level == 'rate_and_ship' and pick.picking_type_code != 'incoming' and not pick.carrier_tracking_ref and pick.picking_type_id.print_label:
            //             pick.sudo().send_to_shipper()
            //         pick._check_carrier_details_compliance()
            //         if pick.carrier_id:
            //             processed_carrier_picking = True
            //     except (UserError) as e:
            //         if processed_carrier_picking:
            //             # We can not raise a UserError at this point
            //             exception_message = str(e)
            //             pick.message_post(body=exception_message, message_type='notification')
            //             pick.sudo().activity_schedule(
            //                 'mail.mail_activity_data_warning',
            //                 date.today(),
            //                 note=pick._carrier_exception_note(exception_message),
            //                 user_id=pick.user_id.id or self.env.uid,
            //                 )
            //         else:
            //             raise e
            // 
            // return super(StockPicking, self)._send_confirmation_email()
            --- ODOO METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py) ---
            // def _send_confirmation_email(self):
            // super()._send_confirmation_email()
            // if not self.env.context.get('skip_sms') and not modules.module.current_test:
            //     pickings = self.filtered(lambda p: p.company_id._get_text_validation('sms') and p.picking_type_id.code == 'outgoing' and p.partner_id.phone)
            //     for picking in pickings:
            //         # Sudo as the user has not always the right to read this sms template.
            //         template = picking.company_id.sudo().stock_sms_confirmation_template_id
            //         picking._message_sms_with_template(
            //             template=template,
            //             partner_ids=picking.partner_id.ids,
            //             put_in_queue=False
            //         )
            */
            return default;
        }

        public async Task<StockPicking> SendToShipperAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def send_to_shipper(self):
            // self.ensure_one()
            // res = self.carrier_id.send_shipping(self)[0]
            // if self.carrier_id.free_over and self.sale_id:
            //     amount_without_delivery = self.sale_id._compute_amount_total_without_delivery()
            //     if self.carrier_id._compute_currency(self.sale_id, amount_without_delivery, 'pricelist_to_company') >= self.carrier_id.amount:
            //         res['exact_price'] = 0.0
            // self.carrier_price = self.carrier_id._apply_margins(res['exact_price'], self.sale_id)
            // if res['tracking_number']:
            //     related_pickings = self.env['stock.picking'] if self.carrier_tracking_ref and res['tracking_number'] in self.carrier_tracking_ref else self
            //     accessed_moves = previous_moves = self.move_ids.move_orig_ids
            //     while previous_moves:
            //         related_pickings |= previous_moves.picking_id
            //         previous_moves = previous_moves.move_orig_ids - accessed_moves
            //         accessed_moves |= previous_moves
            //     accessed_moves = next_moves = self.move_ids.move_dest_ids
            //     while next_moves:
            //         related_pickings |= next_moves.picking_id
            //         next_moves = next_moves.move_dest_ids - accessed_moves
            //         accessed_moves |= next_moves
            //     without_tracking = related_pickings.filtered(lambda p: not p.carrier_tracking_ref)
            //     without_tracking.carrier_tracking_ref = res['tracking_number']
            //     for p in related_pickings - without_tracking:
            //         p.carrier_tracking_ref += "," + res['tracking_number']
            // order_currency = self.sale_id.currency_id or self.company_id.currency_id
            // msg = _("Shipment sent to carrier %(carrier_name)s for shipping with tracking number %(ref)s",
            //         carrier_name=self.carrier_id.name,
            //         ref=self.carrier_tracking_ref) + \
            //       Markup("<br/>") + \
            //       _("Cost: %(price).2f %(currency)s",
            //         price=self.carrier_price,
            //         currency=order_currency.name)
            // self.message_post(body=msg)
            // self._add_delivery_cost_to_so()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> SetSaleIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _set_sale_id(self):
            // if self.reference_ids:
            //     if self.sale_id:
            //         self.reference_ids.sale_ids = [Command.link(self.sale_id.id)]
            //     else:
            //         sale_order = self.move_ids.sale_line_id.order_id
            //         if len(sale_order) == 1:
            //             self.reference_ids.sale_ids = [Command.unlink(sale_order.id)]
            // else:
            //     if self.sale_id:
            //         reference = self.env['stock.reference'].create({
            //             'sale_ids': [Command.link(self.sale_id.id)],
            //             'name': self.sale_id.name,
            //         })
            //         self._add_reference(reference)
            // self.move_ids._reassign_sale_lines(self.sale_id)
            */
            return default;
        }

        protected async Task<StockPicking> SetScheduledDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _set_scheduled_date(self):
            // for picking in self:
            //     if picking.state == 'cancel':
            //         raise UserError(_("You cannot change the Scheduled Date on a cancelled transfer."))
            //     if picking.state == 'done':
            //         continue
            //     picking.move_ids.write({'date': picking.scheduled_date})
            */
            return default;
        }

        protected async Task<StockPicking> ShouldGenerateCommercialInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py) ---
            // def _should_generate_commercial_invoice(self):
            // self.ensure_one()
            // return self.picking_type_id.warehouse_id.partner_id.country_id != self.partner_id.country_id
            */
            return default;
        }

        protected async Task<StockPicking> ShouldIgnoreBackordersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _should_ignore_backorders(self):
            // """ Checks if the `create_backorder` setting from the picking type should be ignored.
            // """
            // return bool(self.return_id)
            */
            return default;
        }

        public async Task<StockPicking> ShouldPrintDeliveryAddressAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def should_print_delivery_address(self):
            // self.ensure_one()
            // return self.move_ids and (self.move_ids[0].partner_id or self.partner_id) and self._is_to_external_location()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> ShouldShowTransfersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _should_show_transfers(self):
            // """Whether the different transfers should be displayed on the pre action done wizards."""
            // return len(self) > 1
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _should_show_transfers(self):
            // if len(self.batch_id) == 1 and len(self) == (len(self.batch_id.picking_ids) - len(self.env.context.get('pickings_to_detach', []))):
            //     return False
            // return super()._should_show_transfers()
            */
            return default;
        }

        public async Task<StockPicking> ShowSubcontractDetailsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def action_show_subcontract_details(self):
            // productions = self._get_subcontract_production().filtered(lambda m: m.state != 'cancel')
            // ctx = {"mrp_subcontracting": True}
            // if self.env.user._is_portal():
            //     form_view_id = self.env.ref('mrp_subcontracting.mrp_production_subcontracting_portal_form_view')
            //     ctx.update(no_breadcrumbs=False)
            // else:
            //     form_view_id = self.env.ref('mrp_subcontracting.mrp_production_subcontracting_form_view')
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mrp.production',
            //     'target': 'current',
            //     'context': ctx
            // }
            // if len(productions) > 1:
            //     action.update({
            //         'name': _('Subcontracting MOs'),
            //         'views': [
            //             (self.env.ref('mrp_subcontracting.mrp_production_subcontracting_tree_view').id, 'list'),
            //             (form_view_id.id, 'form'),
            //         ],
            //         'domain': [('id', 'in', productions.ids)],
            //     })
            // elif len(productions) == 1:
            //     action.update({
            //         'views': [(form_view_id.id, 'form')],
            //         'res_id': productions.id,
            //     })
            // else:
            //     return {}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> SplitTransferAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_split_transfer(self):
            // if all(m.product_uom.is_zero(m.quantity) for m in self.move_ids):
            //     raise UserError(_("%s: Nothing to split. Fill the quantities you want in a new transfer in the done quantities", self.display_name))
            // if all(m.product_uom.compare(m.quantity, m.product_uom_qty) == 0 for m in self.move_ids):
            //     raise UserError(_("%s: Nothing to split, all demand is done. For split you need at least one line not fully fulfilled", self.display_name))
            // if any(m.product_uom.compare(m.quantity, m.product_uom_qty) > 0 for m in self.move_ids):
            //     raise UserError(_("%s: Can't split: quantities done can't be above demand", self.display_name))
            // 
            // moves = self.move_ids.filtered(lambda m: m.state not in ('done', 'cancel') and m.quantity != 0)
            // backorder_moves = moves._create_backorder()
            // backorder_moves += self.move_ids.filtered(lambda m: m.quantity == 0)
            // self._create_backorder(backorder_moves=backorder_moves)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPicking> SubcontractedProduceInternalAsync(object subcontract_details)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py) ---
            // def _subcontracted_produce(self, subcontract_details):
            // self.ensure_one()
            // group_by_company = defaultdict(lambda: ([], []))
            // for move, bom in subcontract_details:
            //     if move.move_orig_ids.production_id:
            //         if len(move.move_orig_ids.move_dest_ids) > 1:
            //             # Magic spicy sauce for the backorder case:
            //             # To ensure correct splitting of the component moves of the SBC MO, we will invoke a split of the SBC
            //             # MO here directly and then link the backorder MO to the backorder move.
            //             # If we would just run _subcontracted_produce as usual for the newly created SBC receipt move, any
            //             # reservations of raw component moves of the SBC MO would not be preserved properly (for example when
            //             # using resupply subcontractor on order)
            //             production_to_split = move.move_orig_ids[0].production_id
            //             original_qty = move.move_orig_ids[0].product_qty
            //             move.move_orig_ids = False
            //             _, new_mo = production_to_split.with_context(allow_more=True)._split_productions({production_to_split: [original_qty, move.product_qty]})
            //             new_mo.move_finished_ids.move_dest_ids = move
            //             continue
            //         else:
            //             # do not create extra production for move that have their quantity updated
            //             return
            //     quantity = move.product_qty or move.quantity
            //     if move.product_uom.compare(quantity, 0) <= 0:
            //         # If a subcontracted amount is decreased, don't create a MO that would be for a negative value.
            //         continue
            // 
            //     mo_subcontract = self._prepare_subcontract_mo_vals(move, bom)
            //     # Group the MO by company
            //     group_by_company[move.company_id.id][0].append(mo_subcontract)
            //     group_by_company[move.company_id.id][1].append(move)
            // 
            // for company, group in group_by_company.items():
            //     vals_list, moves = group
            //     grouped_mo = self.env['mrp.production'].with_company(company).create(vals_list)
            //     grouped_mo.with_context(self._get_subcontract_mo_confirmation_ctx()).action_confirm()
            //     for mo, move in zip(grouped_mo, moves):
            //         mo.date_finished = move.date
            //         finished_move = mo.move_finished_ids.filtered(lambda m: m.product_id == move.product_id)
            //         finished_move.move_dest_ids = [Command.link(move.id)]
            //     grouped_mo.action_assign()
            */
            return default;
        }

        public async Task<StockPicking> ToggleIsLockedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_toggle_is_locked(self):
            // self.ensure_one()
            // self.is_locked = not self.is_locked
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ViewBatchAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def action_view_batch(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.picking.batch',
            //     'res_id': self.batch_id.id,
            //     'view_mode': 'form'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ViewMrpProductionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def action_view_mrp_production(self):
            // self.ensure_one()
            // action = {
            //     'name': _("Manufacturing Orders"),
            //     'res_model': 'mrp.production',
            //     'type': 'ir.actions.act_window',
            //     'domain': [('id', 'in', self.production_ids.ids)],
            //     'view_mode': 'list,form',
            // }
            // if self.production_count == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.production_ids.id,
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ViewReceptionReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_view_reception_report(self):
            // return self.env["ir.actions.actions"]._for_xml_id("stock.stock_reception_action")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ViewRepairsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def action_view_repairs(self):
            // if self.repair_ids:
            //     action = {
            //         'res_model': 'repair.order',
            //         'type': 'ir.actions.act_window',
            //     }
            //     if len(self.repair_ids) == 1:
            //         action.update({
            //             'view_mode': 'form',
            //             'res_id': self.repair_ids[0].id,
            //         })
            //     else:
            //         action.update({
            //             'name': _('Repair Orders'),
            //             'view_mode': 'list,form',
            //             'domain': [('id', 'in', self.repair_ids.ids)],
            //         })
            //     return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPicking> ViewSubcontractingSourcePurchaseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py) ---
            // def action_view_subcontracting_source_purchase(self):
            // purchase_order_ids = self._get_subcontracting_source_purchase().ids
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
            //         'name': _("Source PO of %s", self.name),
            //         'domain': [('id', 'in', purchase_order_ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, StockPicking entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def write(self, vals):
            // if vals.get('picking_type_id') and any(picking.state in ('done', 'cancel') for picking in self):
            //     raise UserError(_("Changing the operation type of this record is forbidden at this point."))
            // if vals.get('picking_type_id'):
            //     picking_type = self.env['stock.picking.type'].browse(vals.get('picking_type_id'))
            //     for picking in self:
            //         if picking.picking_type_id != picking_type:
            //             picking.name = picking_type.sequence_id.next_by_id()
            //             vals['location_id'] = picking_type.default_location_src_id.id
            //             vals['location_dest_id'] = picking_type.default_location_dest_id.id
            // res = super().write(vals)
            // if vals.get('date_done'):
            //     self.filtered(lambda p: p.state == 'done').move_ids.date = vals['date_done']
            // if vals.get('signature'):
            //     for picking in self:
            //         picking._attach_sign()
            // # Change locations of moves if those of the picking change
            // after_vals = {}
            // if vals.get('location_id'):
            //     after_vals['location_id'] = vals['location_id']
            // if vals.get('location_dest_id'):
            //     after_vals['location_dest_id'] = vals['location_dest_id']
            // if 'partner_id' in vals:
            //     after_vals['partner_id'] = vals['partner_id']
            // if after_vals:
            //     self.move_ids.filtered(lambda move: move.location_dest_usage != 'inventory').write(after_vals)
            // if vals.get('move_ids'):
            //     self._autoconfirm_picking()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'batch_id' not in vals:
            //     return res
            // batch = self.env['stock.picking.batch'].browse(vals.get('batch_id'))
            // if batch and batch.dock_id:
            //     batch._set_moves_destination_to_dock()
            // else:
            //     self._reset_location()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def write(self, vals):
            // old_batches = self.batch_id
            // res = super().write(vals)
            // if vals.get('batch_id'):
            //     old_batches.filtered(lambda b: not b.picking_ids).state = 'cancel'
            //     if not self.batch_id.picking_type_id:
            //         self.batch_id.picking_type_id = self.picking_type_id[0]
            //     self.batch_id._sanity_check()
            //     # assign batch users to batch pickings
            //     self.batch_id.picking_ids.assign_batch_user(self.batch_id.user_id.id)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}