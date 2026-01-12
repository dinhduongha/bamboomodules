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
    public class StockMoveAppService : GenericApplicationService<StockMove>, IStockMoveAppService
    {

        public StockMoveAppService(IRepository<StockMove, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockMove> AccountAnalyticEntryMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py) ---
            // def _account_analytic_entry_move(self):
            // domain = self._get_valid_moves_domain()
            // domain = OR([[('picking_id', '=', False)], domain])
            // valid_moves = self.filtered_domain(domain)
            // super(StockMove, valid_moves)._account_analytic_entry_move()
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _account_analytic_entry_move(self):
            // for move in self:
            //     analytic_line_vals = move._prepare_analytic_lines()
            //     if analytic_line_vals:
            //         move.analytic_account_line_ids += self.env['account.analytic.line'].sudo().create(analytic_line_vals)
            */
            return default;
        }

        protected async Task<StockMove> AccountEntryMoveInternalAsync(object qty, object description, Guid svl_id, object cost)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _account_entry_move(self, qty, description, svl_id, cost):
            // """
            // In case of a PO return, if the value of the returned product is
            // different from the purchased one, we need to empty the stock_in account
            // with the difference
            // """
            // move_directions = self.env.context.get('move_directions') or False
            // am_vals_list = super(StockMove, self.with_context(move_directions=move_directions))._account_entry_move(qty, description, svl_id, cost)
            // returned_move = self.origin_returned_move_id
            // move = (self | returned_move).with_prefetch(self._prefetch_ids)
            // pdiff_exists = bool(move.stock_valuation_layer_ids.stock_valuation_layer_ids.account_move_line_id)
            // 
            // if not am_vals_list or not self.purchase_line_id or pdiff_exists or float_is_zero(qty, precision_rounding=self.product_id.uom_id.rounding):
            //     return am_vals_list
            // 
            // layer = self.env['stock.valuation.layer'].browse(svl_id)
            // 
            // self_is_out_move = False
            // if move_directions:
            //     self_is_out_move = move_directions.get(self.id) and 'out' in move_directions.get(self.id)
            // else:
            //     self_is_out_move = self._is_out()
            // 
            // if returned_move and self_is_out_move and self._is_returned(valued_type='out'):
            //     returned_layer = returned_move.stock_valuation_layer_ids.filtered(lambda svl: not svl.stock_valuation_layer_id)[:1]
            //     unit_diff = layer._get_layer_price_unit() - returned_layer._get_layer_price_unit() if returned_layer else 0
            // elif returned_move and returned_move._is_out() and returned_move._is_returned(valued_type='out'):
            //     returned_layer = returned_move.stock_valuation_layer_ids.filtered(lambda svl: not svl.stock_valuation_layer_id)[:1]
            //     unit_diff = returned_layer._get_layer_price_unit() - self.purchase_line_id._get_gross_price_unit()
            // else:
            //     return am_vals_list
            // 
            // diff = unit_diff * qty
            // company = self.purchase_line_id.company_id
            // if company.currency_id.is_zero(diff):
            //     return am_vals_list
            // 
            // sm = self.with_company(company).with_context(is_returned=True)
            // accounts = sm.product_id.product_tmpl_id.get_product_accounts()
            // acc_exp_id = accounts['expense'].id
            // acc_stock_in_id = accounts['stock_input'].id
            // journal_id = accounts['stock_journal'].id
            // vals = sm._prepare_account_move_vals(acc_exp_id, acc_stock_in_id, journal_id, qty, description, False, diff)
            // am_vals_list.append(vals)
            // 
            // return am_vals_list
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _account_entry_move(self, qty, description, svl_id, cost):
            // """ Accounting Valuation Entries """
            // self.ensure_one()
            // am_vals = []
            // if not self.product_id.is_storable:
            //     # no stock valuation for consumable products
            //     return am_vals
            // if self._should_exclude_for_valuation():
            //     return am_vals
            // 
            // move_directions = self.env.context.get('move_directions') or False
            // 
            // self_is_out_move = self_is_in_move = False
            // if move_directions:
            //     self_is_out_move = move_directions.get(self.id) and 'out' in move_directions.get(self.id)
            //     self_is_in_move = move_directions.get(self.id) and 'in' in move_directions.get(self.id)
            // else:
            //     self_is_out_move = self._is_out()
            //     self_is_in_move = self._is_in()
            // 
            // company_from = self_is_out_move and self.mapped('move_line_ids.location_id.company_id') or False
            // company_to = self_is_in_move and self.mapped('move_line_ids.location_dest_id.company_id') or False
            // 
            // journal_id, acc_src, acc_dest, acc_valuation = self._get_accounting_data_for_valuation()
            // # Create Journal Entry for products arriving in the company; in case of routes making the link between several
            // # warehouse of the same company, the transit location belongs to this company, so we don't need to create accounting entries
            // if self_is_in_move:
            //     if self._is_returned(valued_type='in'):
            //         am_vals.append(self.with_company(company_to).with_context(is_returned=True)._prepare_account_move_vals(acc_dest, acc_valuation, journal_id, qty, description, svl_id, cost))
            //     else:
            //         am_vals.append(self.with_company(company_to)._prepare_account_move_vals(acc_src, acc_valuation, journal_id, qty, description, svl_id, cost))
            // 
            // # Create Journal Entry for products leaving the company
            // if self_is_out_move:
            //     cost = -1 * cost
            //     if self._is_returned(valued_type='out'):
            //         am_vals.append(self.with_company(company_from).with_context(is_returned=True)._prepare_account_move_vals(acc_valuation, acc_src, journal_id, qty, description, svl_id, cost))
            //     else:
            //         am_vals.append(self.with_company(company_from)._prepare_account_move_vals(acc_valuation, acc_dest, journal_id, qty, description, svl_id, cost))
            // 
            // if self.company_id.anglo_saxon_accounting:
            //     # Creates an account entry from stock_input to stock_output on a dropship move. https://github.com/odoo/odoo/issues/12687
            //     anglosaxon_am_vals = self._prepare_anglosaxon_account_move_vals(acc_src, acc_dest, acc_valuation, journal_id, qty, description, svl_id, cost)
            //     if anglosaxon_am_vals:
            //         am_vals.append(anglosaxon_am_vals)
            // 
            // return am_vals
            */
            return default;
        }

        protected async Task<StockMove> ActionAssignInternalAsync(object force_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _action_assign(self, force_qty=False):
            // res = super(StockMove, self)._action_assign(force_qty=force_qty)
            // for move in self.filtered(lambda x: x.production_id or x.raw_material_production_id):
            //     if move.move_line_ids:
            //         move.move_line_ids.write({'production_id': move.raw_material_production_id.id,
            //                                        'workorder_id': move.workorder_id.id,})
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _action_assign(self, force_qty=False):
            // """ Reserve stock moves by creating their stock move lines. A stock move is
            // considered reserved once the sum of `reserved_qty` for all its move lines is
            // equal to its `product_qty`. If it is less, the stock move is considered
            // partially available.
            // """
            // StockMove = self.env['stock.move']
            // assigned_moves_ids = OrderedSet()
            // partially_available_moves_ids = OrderedSet()
            // # Read the `reserved_availability` field of the moves out of the loop to prevent unwanted
            // # cache invalidation when actually reserving the move.
            // reserved_availability = {move: move.quantity for move in self}
            // 
            // roundings = {move: move.product_id.uom_id.rounding for move in self}
            // move_line_vals_list = []
            // # Once the quantities are assigned, we want to find a better destination location thanks
            // # to the putaway rules. This redirection will be applied on moves of `moves_to_redirect`.
            // moves_to_redirect = OrderedSet()
            // moves_to_assign = self
            // if not force_qty:
            //     moves_to_assign = moves_to_assign.filtered(
            //         lambda m: not m.picked and m.state in ['confirmed', 'waiting', 'partially_available']
            //     )
            // moves_mto = moves_to_assign.filtered(lambda m: m.move_orig_ids and not m._should_bypass_reservation())
            // quants_cache = self.env['stock.quant']._get_quants_by_products_locations(moves_mto.product_id, moves_mto.location_id)
            // for move in moves_to_assign:
            //     move = move.with_company(move.company_id)
            //     rounding = roundings[move]
            //     if not force_qty:
            //         missing_reserved_uom_quantity = move.product_uom_qty - reserved_availability[move]
            //     else:
            //         missing_reserved_uom_quantity = force_qty
            //     if float_compare(missing_reserved_uom_quantity, 0, precision_rounding=rounding) <= 0:
            //         assigned_moves_ids.add(move.id)
            //         continue
            //     missing_reserved_quantity = move.product_uom._compute_quantity(missing_reserved_uom_quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //     if move._should_bypass_reservation():
            //         # create the move line(s) but do not impact quants
            //         if move.move_orig_ids:
            //             available_move_lines = move._get_available_move_lines(assigned_moves_ids, partially_available_moves_ids)
            //             for (location_id, lot_id, package_id, owner_id), quantity in available_move_lines.items():
            //                 qty_added = min(missing_reserved_quantity, quantity)
            //                 move_line_vals = move._prepare_move_line_vals(qty_added)
            //                 move_line_vals.update({
            //                     'location_id': location_id.id,
            //                     'lot_id': lot_id.id,
            //                     'lot_name': lot_id.name,
            //                     'owner_id': owner_id.id,
            //                     'package_id': package_id.id,
            //                 })
            //                 move_line_vals_list.append(move_line_vals)
            //                 missing_reserved_quantity -= qty_added
            //                 if float_is_zero(missing_reserved_quantity, precision_rounding=move.product_id.uom_id.rounding):
            //                     break
            // 
            //         if missing_reserved_quantity and move.product_id.tracking == 'serial' and (move.picking_type_id.use_create_lots or move.picking_type_id.use_existing_lots):
            //             for i in range(0, int(missing_reserved_quantity)):
            //                 move_line_vals_list.append(move._prepare_move_line_vals(quantity=1))
            //         elif missing_reserved_quantity:
            //             to_update = move.move_line_ids.filtered(lambda ml: ml.product_uom_id == move.product_uom and
            //                                                     ml.location_id == move.location_id and
            //                                                     ml.location_dest_id == move.location_dest_id and
            //                                                     ml.picking_id == move.picking_id and
            //                                                     not ml.picked and
            //                                                     not ml.lot_id and
            //                                                     not ml.result_package_id and
            //                                                     not ml.package_id and
            //                                                     not ml.owner_id)
            //             if to_update:
            //                 to_update[0].quantity += move.product_id.uom_id._compute_quantity(
            //                     missing_reserved_quantity, move.product_uom, rounding_method='HALF-UP')
            //             else:
            //                 move_line_vals_list.append(move._prepare_move_line_vals(quantity=missing_reserved_quantity))
            //         assigned_moves_ids.add(move.id)
            //         moves_to_redirect.add(move.id)
            //     else:
            //         if float_is_zero(move.product_uom_qty, precision_rounding=move.product_uom.rounding) and not force_qty:
            //             assigned_moves_ids.add(move.id)
            //         elif not move.move_orig_ids:
            //             if move.procure_method == 'make_to_order':
            //                 continue
            //             # If we don't need any quantity, consider the move assigned.
            //             need = missing_reserved_quantity
            //             if float_is_zero(need, precision_rounding=rounding):
            //                 assigned_moves_ids.add(move.id)
            //                 continue
            //             # Reserve new quants and create move lines accordingly.
            //             forced_package_id = move.package_level_id.package_id or None
            //             taken_quantity = move._update_reserved_quantity(need, move.location_id, package_id=forced_package_id, strict=False)
            //             if float_is_zero(taken_quantity, precision_rounding=rounding):
            //                 continue
            //             moves_to_redirect.add(move.id)
            //             if float_compare(need, taken_quantity, precision_rounding=rounding) == 0:
            //                 assigned_moves_ids.add(move.id)
            //             else:
            //                 partially_available_moves_ids.add(move.id)
            //         else:
            //             # Check what our parents brought and what our siblings took in order to
            //             # determine what we can distribute.
            //             # `quantity` is in `ml.product_uom_id` and, as we will later increase
            //             # the reserved quantity on the quants, convert it here in
            //             # `product_id.uom_id` (the UOM of the quants is the UOM of the product).
            //             available_move_lines = move._get_available_move_lines(assigned_moves_ids, partially_available_moves_ids)
            //             if not available_move_lines:
            //                 continue
            //             for move_line in move.move_line_ids.filtered(lambda m: m.quantity_product_uom):
            //                 if available_move_lines.get((move_line.location_id, move_line.lot_id, move_line.package_id, move_line.owner_id)):
            //                     available_move_lines[(move_line.location_id, move_line.lot_id, move_line.package_id, move_line.owner_id)] -= move_line.quantity_product_uom
            //             for (location_id, lot_id, package_id, owner_id), quantity in available_move_lines.items():
            //                 need = move.product_qty - sum(move.move_line_ids.mapped('quantity_product_uom'))
            //                 # `quantity` is what is brought by chained done move lines. We double check
            //                 # here this quantity is available on the quants themselves. If not, this
            //                 # could be the result of an inventory adjustment that removed totally of
            //                 # partially `quantity`. When this happens, we chose to reserve the maximum
            //                 # still available. This situation could not happen on MTS move, because in
            //                 # this case `quantity` is directly the quantity on the quants themselves.
            // 
            //                 taken_quantity = move.with_context(quants_cache=quants_cache)._update_reserved_quantity(
            //                     min(quantity, need), location_id, lot_id, package_id, owner_id)
            //                 if float_is_zero(taken_quantity, precision_rounding=rounding):
            //                     continue
            //                 moves_to_redirect.add(move.id)
            //                 if float_is_zero(need - taken_quantity, precision_rounding=rounding):
            //                     assigned_moves_ids.add(move.id)
            //                     break
            //                 partially_available_moves_ids.add(move.id)
            //     if move.product_id.tracking == 'serial':
            //         move.next_serial_count = move.product_uom_qty
            // 
            // self.env['stock.move.line'].create(move_line_vals_list)
            // StockMove.browse(partially_available_moves_ids).write({'state': 'partially_available'})
            // StockMove.browse(assigned_moves_ids).write({'state': 'assigned'})
            // if not self.env.context.get('bypass_entire_pack'):
            //     self.picking_id._check_entire_pack()
            // StockMove.browse(moves_to_redirect).move_line_ids._apply_putaway_strategy()
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def _action_assign(self, force_qty=False):
            // super()._action_assign(force_qty=force_qty)
            // self.move_line_ids._auto_wave()
            */
            return default;
        }

        protected async Task<StockMove> ActionCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // res = super(StockMove, self)._action_cancel()
            // if not 'skip_mo_check' in self.env.context:
            //     mo_to_cancel = self.mapped('raw_material_production_id').filtered(lambda p: all(m.state == 'cancel' for m in p.move_raw_ids))
            //     if mo_to_cancel:
            //         mo_to_cancel._action_cancel()
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // productions_to_cancel_ids = OrderedSet()
            // for move in self:
            //     if move.is_subcontract:
            //         active_productions = move.move_orig_ids.production_id.filtered(lambda p: p.state not in ('done', 'cancel'))
            //         moves_todo = self.env.context.get('moves_todo')
            //         not_todo_productions = active_productions.filtered(lambda p: p not in moves_todo.move_orig_ids.production_id) if moves_todo else active_productions
            //         if not_todo_productions:
            //             productions_to_cancel_ids.update(not_todo_productions.ids)
            // 
            // if productions_to_cancel_ids:
            //     productions_to_cancel = self.env['mrp.production'].browse(productions_to_cancel_ids)
            //     productions_to_cancel.with_context(skip_activity=True).action_cancel()
            // 
            // return super()._action_cancel()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // self._clean_repair_sale_order_line()
            // return super()._action_cancel()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // if any(move.state == 'done' and not move.scrapped for move in self):
            //     raise UserError(_('You cannot cancel a stock move that has been set to \'Done\'. Create a return in order to reverse the moves which took place.'))
            // moves_to_cancel = self.filtered(lambda m: m.state != 'cancel' and not (m.state == 'done' and m.scrapped))
            // moves_to_cancel.picked = False
            // # self cannot contain moves that are either cancelled or done, therefore we can safely
            // # unlink all associated move_line_ids
            // moves_to_cancel._do_unreserve()
            // cancel_moves_origin = self.env['ir.config_parameter'].sudo().get_param('stock.cancel_moves_origin')
            // 
            // moves_to_cancel.state = 'cancel'
            // 
            // for move in moves_to_cancel:
            //     siblings_states = (move.move_dest_ids.mapped('move_orig_ids') - move).mapped('state')
            //     if move.propagate_cancel:
            //         # only cancel the next move if all my siblings are also cancelled
            //         if all(state == 'cancel' for state in siblings_states):
            //             move.move_dest_ids.filtered(lambda m: m.state != 'done' and move.location_dest_id == m.location_id)._action_cancel()
            //             if cancel_moves_origin:
            //                 move.move_orig_ids.sudo().filtered(lambda m: m.state != 'done')._action_cancel()
            //     else:
            //         if all(state in ('done', 'cancel') for state in siblings_states):
            //             move_dest_ids = move.move_dest_ids
            //             move_dest_ids.write({
            //                 'procure_method': 'make_to_stock',
            //                 'move_orig_ids': [Command.unlink(move.id)]
            //             })
            // moves_to_cancel.write({
            //     'move_orig_ids': [(5, 0, 0)],
            //     'procure_method': 'make_to_stock',
            // })
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // self.analytic_account_line_ids.unlink()
            // return super()._action_cancel()
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def _action_cancel(self):
            // res = super()._action_cancel()
            // 
            // for picking in self.picking_id:
            //     # Remove the picking from the batch if the whole batch isn't cancelled.
            //     if picking.state == 'cancel' and picking.batch_id and any(p.state != 'cancel' for p in picking.batch_id.picking_ids):
            //         picking.batch_id = None
            // return res
            */
            return default;
        }

        protected async Task<StockMove> ActionConfirmInternalAsync(object merge, object merge_into)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _action_confirm(self, merge=True, merge_into=False):
            // moves = self.action_explode()
            // merge_into = merge_into and merge_into.action_explode()
            // # we go further with the list of ids potentially changed by action_explode
            // return super(StockMove, moves)._action_confirm(merge=merge, merge_into=merge_into)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _action_confirm(self, merge=True, merge_into=False):
            // subcontract_details_per_picking = defaultdict(list)
            // for move in self:
            //     if move.location_id.usage != 'supplier' or move.location_dest_id.usage == 'supplier':
            //         continue
            //     if move.move_orig_ids.production_id:
            //         continue
            //     bom = move._get_subcontract_bom()
            //     if not bom:
            //         continue
            //     company = move.company_id
            //     subcontracting_location = \
            //         move.picking_id.partner_id.with_company(company).property_stock_subcontractor \
            //         or company.subcontracting_location_id
            //     move.write({
            //         'is_subcontract': True,
            //         'location_id': subcontracting_location.id
            //     })
            //     move._action_assign()  # Re-reserve as the write on location_id will break the link
            // res = super()._action_confirm(merge=merge, merge_into=merge_into)
            // for move in res:
            //     if move.is_subcontract:
            //         subcontract_details_per_picking[move.picking_id].append((move, move._get_subcontract_bom()))
            // for picking, subcontract_details in subcontract_details_per_picking.items():
            //     picking._subcontracted_produce(subcontract_details)
            // 
            // if subcontract_details_per_picking:
            //     self.env['stock.picking'].concat(*list(subcontract_details_per_picking.keys())).action_assign()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _action_confirm(self, merge=True, merge_into=False):
            // """ Confirms stock move or put it in waiting if it's linked to another move.
            // :param: merge: According to this boolean, a newly confirmed move will be merged
            // in another move of the same picking sharing its characteristics.
            // """
            // # Use OrderedSet of id (instead of recordset + |= ) for performance
            // move_create_proc, move_to_confirm, move_waiting = OrderedSet(), OrderedSet(), OrderedSet()
            // to_assign = defaultdict(OrderedSet)
            // for move in self:
            //     if move.state != 'draft':
            //         continue
            //     # if the move is preceded, then it's waiting (if preceding move is done, then action_assign has been called already and its state is already available)
            //     if move.move_orig_ids:
            //         move_waiting.add(move.id)
            //     elif move.procure_method == 'make_to_order':
            //         move_waiting.add(move.id)
            //         move_create_proc.add(move.id)
            //     elif move.rule_id and move.rule_id.procure_method == 'mts_else_mto':
            //         move_create_proc.add(move.id)
            //         move_to_confirm.add(move.id)
            //     else:
            //         move_to_confirm.add(move.id)
            //     if move._should_be_assigned():
            //         key = (move.group_id.id, move.location_id.id, move.location_dest_id.id)
            //         to_assign[key].add(move.id)
            // 
            // # create procurements for make to order moves
            // procurement_requests = []
            // move_create_proc = self.browse(move_create_proc) if not self.env.context.get('bypass_procurement_creation', False) else self.env['stock.move']
            // quantities = move_create_proc._prepare_procurement_qty()
            // for move, quantity in zip(move_create_proc, quantities):
            //     values = move._prepare_procurement_values()
            //     origin = move._prepare_procurement_origin()
            //     procurement_requests.append(self.env['procurement.group'].Procurement(
            //         move.product_id, quantity, move.product_uom,
            //         move.location_id, move.rule_id and move.rule_id.name or "/",
            //         origin, move.company_id, values))
            // self.env['procurement.group'].run(procurement_requests, raise_user_error=not self.env.context.get('from_orderpoint'))
            // 
            // move_to_confirm, move_waiting = self.browse(move_to_confirm), self.browse(move_waiting)
            // move_to_confirm.write({'state': 'confirmed'})
            // move_waiting.write({'state': 'waiting'})
            // # procure_method sometimes changes with certain workflows so just in case, apply to all moves
            // (move_to_confirm | move_waiting).filtered(lambda m: m.picking_type_id.reservation_method == 'at_confirm')\
            //     .write({'reservation_date': fields.Date.today()})
            // 
            // # assign picking in batch for all confirmed move that share the same details
            // for moves_ids in to_assign.values():
            //     self.browse(moves_ids).with_context(clean_context(self.env.context))._assign_picking()
            // 
            // self._check_company()
            // moves = self
            // if merge:
            //     moves = self._merge_moves(merge_into=merge_into)
            // 
            // neg_r_moves = moves.filtered(lambda move: float_compare(
            //     move.product_uom_qty, 0, precision_rounding=move.product_uom.rounding) < 0)
            // 
            // # Push remaining quantities to next step
            // neg_to_push = neg_r_moves.filtered(lambda move: move.location_final_id and move.location_dest_id != move.location_final_id)
            // new_push_moves = self.env['stock.move']
            // if neg_to_push:
            //     new_push_moves = neg_to_push._push_apply()
            // 
            // # Transform remaining move in returns in case of negative initial demand
            // for move in neg_r_moves:
            //     move.location_id, move.location_dest_id, move.location_final_id = move.location_dest_id, move.location_id, move.location_id
            //     orig_move_ids, dest_move_ids = [], []
            //     for m in move.move_orig_ids | move.move_dest_ids:
            //         from_loc, to_loc = m.location_id, m.location_dest_id
            //         if float_compare(m.product_uom_qty, 0, precision_rounding=m.product_uom.rounding) < 0:
            //             from_loc, to_loc = to_loc, from_loc
            //         if to_loc == move.location_id:
            //             orig_move_ids += m.ids
            //         elif move.location_dest_id == from_loc:
            //             dest_move_ids += m.ids
            //     move.move_orig_ids, move.move_dest_ids = [Command.set(orig_move_ids)], [Command.set(dest_move_ids)]
            //     move.product_uom_qty *= -1
            //     if move.picking_type_id.return_picking_type_id:
            //         move.picking_type_id = move.picking_type_id.return_picking_type_id
            //     # We are returning some products, we must take them in the source location
            //     move.procure_method = 'make_to_stock'
            // neg_r_moves._assign_picking()
            // 
            // # call `_action_assign` on every confirmed move which location_id bypasses the reservation + those expected to be auto-assigned
            // moves.filtered(lambda move: move.state in ('confirmed', 'partially_available')
            //                and (move._should_bypass_reservation() or move._should_assign_at_confirm()))\
            //      ._action_assign()
            // if new_push_moves:
            //     neg_push_moves = new_push_moves.filtered(lambda sm: float_compare(sm.product_uom_qty, 0, precision_rounding=sm.product_uom.rounding) < 0)
            //     (new_push_moves - neg_push_moves).sudo()._action_confirm()
            //     # Negative moves do not have any picking, so we should try to merge it with their siblings
            //     neg_push_moves._action_confirm(merge_into=neg_push_moves.move_orig_ids.move_dest_ids)
            // return moves
            */
            return default;
        }

        protected async Task<StockMove> ActionDoneInternalAsync(object cancel_backorder)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _action_done(self, cancel_backorder=False):
            // # explode kit moves that avoided the action_explode of any confirmation process
            // moves_to_explode = self.filtered(lambda m: m.product_id.is_kits and m.state not in ('draft', 'cancel'))
            // exploded_moves = moves_to_explode.action_explode()
            // moves = (self - moves_to_explode) | exploded_moves
            // return super(StockMove, moves)._action_done(cancel_backorder)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _action_done(self, cancel_backorder=False):
            // moves = self.filtered(
            //     lambda move: move.state == 'draft')._action_confirm(merge=False)
            // moves = (self | moves).exists().filtered(lambda x: x.state not in ('done', 'cancel'))
            // 
            // # Cancel moves where necessary ; we should do it before creating the extra moves because
            // # this operation could trigger a merge of moves.
            // ml_ids_to_unlink = OrderedSet()
            // for move in moves:
            //     if move.picked:
            //         # in theory, we should only have a mix of picked and non-picked mls in the barcode use case
            //         # where non-scanned mls = not picked => we definitely don't want to validate them
            //         ml_ids_to_unlink |= move.move_line_ids.filtered(lambda ml: not ml.picked).ids
            //     if (move.quantity <= 0 or not move.picked) and not move.is_inventory:
            //         if float_compare(move.product_uom_qty, 0.0, precision_rounding=move.product_uom.rounding) == 0 or cancel_backorder:
            //             move._action_cancel()
            // self.env['stock.move.line'].browse(ml_ids_to_unlink).unlink()
            // 
            // moves_todo = moves.filtered(lambda m:
            //     not (m.state == 'cancel' or (m.quantity <= 0 and not m.is_inventory) or not m.picked)
            // )
            // 
            // moves_todo._check_company()
            // if not cancel_backorder:
            //     moves_todo._create_backorder()
            // moves_todo.mapped('move_line_ids').sorted()._action_done()
            // # Check the consistency of the result packages; there should be an unique location across
            // # the contained quants.
            // for result_package in moves_todo\
            //         .move_line_ids.filtered(lambda ml: ml.picked).mapped('result_package_id')\
            //         .filtered(lambda p: p.quant_ids and len(p.quant_ids) > 1):
            //     if len(result_package.quant_ids.filtered(lambda q: float_compare(q.quantity, 0.0, precision_rounding=q.product_uom_id.rounding) > 0).mapped('location_id')) > 1:
            //         raise UserError(_('You cannot move the same package content more than once in the same transfer or split the same package into two location.'))
            // if any(ml.package_id and ml.package_id == ml.result_package_id for ml in moves_todo.move_line_ids):
            //     self.env['stock.quant']._unlink_zero_quants()
            // picking = moves_todo.mapped('picking_id')
            // moves_todo.write({'state': 'done', 'date': fields.Datetime.now()})
            // 
            // move_dests_per_company = defaultdict(lambda: self.env['stock.move'])
            // 
            // # Break move dest link if move dest and move_dest source are not the same,
            // # so that when move_dests._action_assign is called, the move lines are not created with
            // # the new location, they should not be created at all.
            // moves_to_push = moves_todo.filtered(lambda m: not m._skip_push())
            // if moves_to_push:
            //     moves_to_push._push_apply()
            // for move_dest in moves_todo.move_dest_ids:
            //     move_dests_per_company[move_dest.company_id.id] |= move_dest
            // for company_id, move_dests in move_dests_per_company.items():
            //     move_dests.sudo().with_company(company_id)._action_assign()
            // 
            // # We don't want to create back order for scrap moves
            // # Replace by a kwarg in master
            // if self.env.context.get('is_scrap'):
            //     return moves
            // 
            // if picking and not cancel_backorder:
            //     backorder = picking._create_backorder()
            //     if any([m.state == 'assigned' for m in backorder.move_ids]):
            //         backorder._check_entire_pack()
            // if moves_todo:
            //     moves_todo._check_quantity()
            // return moves_todo
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _action_done(self, cancel_backorder=False):
            // # Init a dict that will group the moves by valuation type, according to `move._is_valued_type`.
            // valued_moves = {valued_type: self.env['stock.move'] for valued_type in self._get_valued_types()}
            // for move in self:
            //     if move.state == 'done':
            //         continue
            //     if float_is_zero(move.quantity, precision_rounding=move.product_uom.rounding):
            //         continue
            //     if not any(move.move_line_ids.mapped('picked')):
            //         continue
            //     for valued_type in self._get_valued_types():
            //         if getattr(move, '_is_%s' % valued_type)():
            //             valued_moves[valued_type] |= move
            // 
            // res = super()._action_done(cancel_backorder=cancel_backorder)
            // 
            // # AVCO application
            // valued_moves['in'].product_price_update_before_done()
            // 
            // # '_action_done' might have deleted some exploded stock moves
            // valued_moves = {value_type: moves.exists() for value_type, moves in valued_moves.items()}
            // 
            // # '_action_done' might have created an extra move to be valued
            // for move in res - self:
            //     for valued_type in self._get_valued_types():
            //         if getattr(move, '_is_%s' % valued_type)():
            //             valued_moves[valued_type] |= move
            // 
            // stock_valuation_layers = self.env['stock.valuation.layer'].sudo()
            // # Create the valuation layers in batch by calling `moves._create_valued_type_svl`.
            // for valued_type in self._get_valued_types():
            //     todo_valued_moves = valued_moves[valued_type]
            //     if todo_valued_moves:
            //         todo_valued_moves._sanity_check_for_valuation()
            //         stock_valuation_layers |= getattr(todo_valued_moves, '_create_%s_svl' % valued_type)()
            // 
            // stock_valuation_layers._validate_accounting_entries()
            // stock_valuation_layers._validate_analytic_accounting_entries()
            // 
            // valued_moves['out'].filtered(lambda m: m.product_id.lot_valuated).sudo()._product_price_update_after_done()
            // 
            // stock_valuation_layers._check_company()
            // 
            // # For every in move, run the vacuum for the linked product.
            // products_to_vacuum = valued_moves['in'].mapped('product_id')
            // company = valued_moves['in'].mapped('company_id') and valued_moves['in'].mapped('company_id')[0] or self.env.company
            // products_to_vacuum._run_fifo_vacuum(company)
            // 
            // return res
            */
            return default;
        }

        protected async Task<StockMove> ActionRecordComponentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _action_record_components(self):
            // self.ensure_one()
            // production = self._get_subcontract_production()[-1:]
            // view = self.env.ref('mrp_subcontracting.mrp_production_subcontracting_form_view')
            // if self.env.user._is_portal():
            //     view = self.env.ref('mrp_subcontracting.mrp_production_subcontracting_portal_form_view')
            // context = dict(self._context)
            // context.pop('skip_consumption', False)
            // return {
            //     'name': _('Subcontract'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mrp.production',
            //     'views': [(view.id, 'form')],
            //     'view_id': view.id,
            //     'target': 'new',
            //     'res_id': production.id,
            //     'context': context,
            // }
            */
            return default;
        }

        public async Task<StockMove> AddFromCatalogByproductAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def action_add_from_catalog_byproduct(self):
            // mo = self.env['mrp.production'].browse(self.env.context.get('order_id'))
            // return mo.with_context(child_field='move_byproduct_ids').action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMove> AddFromCatalogRawAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def action_add_from_catalog_raw(self):
            // mo = self.env['mrp.production'].browse(self.env.context.get('order_id'))
            // return mo.with_context(child_field='move_raw_ids').action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMove> AddFromCatalogRepairAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def action_add_from_catalog_repair(self):
            // repair_order = self.env['repair.order'].browse(self.env.context.get('order_id'))
            // return repair_order.action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> AddMlsRelatedToOrderInternalAsync(object related_order_lines, object are_qties_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _add_mls_related_to_order(self, related_order_lines, are_qties_done=True):
            // lines_data = self._prepare_lines_data_dict(related_order_lines)
            // # Moves with product_id not in related_order_lines. This can happend e.g. when product_id has a phantom-type bom.
            // moves_to_assign = self.filtered(lambda m: m.product_id.id not in lines_data or m.product_id.tracking == 'none'
            //                                           or (not m.picking_type_id.use_existing_lots and not m.picking_type_id.use_create_lots))
            // 
            // # Check for any conversion issues in the moves before setting quantities
            // uoms_with_issues = set()
            // for move in moves_to_assign.filtered(lambda m: m.product_uom_qty and m.product_uom != m.product_id.uom_id):
            //     converted_qty = move.product_uom._compute_quantity(
            //         move.product_uom_qty,
            //         move.product_id.uom_id,
            //         rounding_method='HALF-UP'
            //     )
            //     if not converted_qty:
            //         uoms_with_issues.add(
            //             (move.product_uom.name, move.product_id.uom_id.name)
            //         )
            // 
            // if uoms_with_issues:
            //     error_message_lines = [
            //         _("Conversion Error: The following unit of measure conversions result in a zero quantity due to rounding:")
            //     ]
            //     for uom_from, uom_to in uoms_with_issues:
            //         error_message_lines.append(_(' - From "%(uom_from)s" to "%(uom_to)s"', uom_from=uom_from, uom_to=uom_to))
            // 
            //     error_message_lines.append(
            //         _("\nThis issue occurs because the quantity becomes zero after rounding during the conversion. "
            //         "To fix this, adjust the conversion factors or rounding method to ensure that even the smallest quantity in the original unit "
            //         "does not round down to zero in the target unit.")
            //     )
            // 
            //     raise UserError('\n'.join(error_message_lines))
            // 
            // for move in moves_to_assign:
            //     move.quantity = move.product_uom_qty
            // moves_remaining = self - moves_to_assign
            // existing_lots = moves_remaining._create_production_lots_for_pos_order(related_order_lines)
            // move_lines_to_create = []
            // mls_qties = []
            // if are_qties_done:
            //     for move in moves_remaining:
            //         move.move_line_ids.quantity = 0
            //         for line in lines_data[move.product_id.id]['order_lines']:
            //             sum_of_lots = 0
            //             for lot in line.pack_lot_ids.filtered(lambda l: l.lot_name):
            //                 qty = 1 if line.product_id.tracking == 'serial' else abs(line.qty)
            //                 ml_vals = dict(move._prepare_move_line_vals(qty))
            //                 if existing_lots:
            //                     existing_lot = existing_lots.filtered_domain([('product_id', '=', line.product_id.id), ('name', '=', lot.lot_name)])
            //                     quant = self.env['stock.quant']
            //                     if existing_lot:
            //                         quant = self.env['stock.quant'].search(
            //                             [('lot_id', '=', existing_lot.id), ('quantity', '>', '0.0'), ('location_id', 'child_of', move.location_id.id)],
            //                             order='id desc',
            //                             limit=1
            //                         )
            //                         if quant:
            //                             ml_vals.update({
            //                                 'quant_id': quant.id,
            //                             })
            //                         else:
            //                             ml_vals.update({
            //                                 'lot_name': existing_lot.name,
            //                                 'lot_id': existing_lot.id,
            //                             })
            //                 else:
            //                     ml_vals.update({'lot_name': lot.lot_name})
            //                 move_lines_to_create.append(ml_vals)
            //                 mls_qties.append(qty)
            //                 sum_of_lots += qty
            //     self.env['stock.move.line'].create(move_lines_to_create)
            // else:
            //     for move in moves_remaining:
            //         for line in lines_data[move.product_id.id]['order_lines']:
            //             for lot in line.pack_lot_ids.filtered(lambda l: l.lot_name):
            //                 if line.product_id.tracking == 'serial':
            //                     qty = 1
            //                 else:
            //                     qty = abs(line.qty)
            //                 if existing_lots:
            //                     existing_lot = existing_lots.filtered_domain([('product_id', '=', line.product_id.id), ('name', '=', lot.lot_name)])
            //                     if existing_lot:
            //                         move._update_reserved_quantity(qty, move.location_id, lot_id=existing_lot)
            //                         continue
            */
            return default;
        }

        protected async Task<StockMove> AddSerialMoveLineToValsListInternalAsync(object reserved_quant, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _add_serial_move_line_to_vals_list(self, reserved_quant, quantity):
            // return [self._prepare_move_line_vals(quantity=1, reserved_quant=reserved_quant) for i in range(int(quantity))]
            */
            return default;
        }

        protected async Task<StockMove> AdjustProcureMethodInternalAsync(object picking_type_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _adjust_procure_method(self, picking_type_code=False):
            // """ This method will try to apply the procure method MTO on some moves if
            // a compatible MTO route is found. Else the procure method will be set to MTS
            // picking_type_code (str, optional): Adjusts the procurement method based on
            //     the specified picking type code. The code to specify the picking type for
            //     the procurement group. Defaults to False.
            // """
            // # Prepare the MTSO variables. They are needed since MTSO moves are handled separately.
            // # We need 2 dicts:
            // # - needed quantity per location per product
            // # - forecasted quantity per location per product
            // 
            // for move in self:
            //     product_id = move.product_id
            //     domain = [
            //         ('location_src_id', '=', move.location_id.id),
            //         ('location_dest_id', '=', move.location_dest_id.id),
            //         ('action', '!=', 'push')
            //     ]
            //     if picking_type_code:
            //         domain.append(('picking_type_id.code', '=', picking_type_code))
            //     rule = self.env['procurement.group']._search_rule(False, move.product_packaging_id, product_id, move.warehouse_id, domain)
            //     if not rule:
            //         move.procure_method = 'make_to_stock'
            //         continue
            // 
            //     move.rule_id = rule.id
            //     if rule.procure_method in ['make_to_stock', 'make_to_order']:
            //         move.procure_method = rule.procure_method
            //     else:
            //         move.procure_method = 'make_to_stock'
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _assign_picking(self):
            // """ Try to assign the moves to an existing picking that has not been
            // reserved yet and has the same procurement group, locations and picking
            // type (moves should already have them identical). Otherwise, create a new
            // picking to assign them to. """
            // Picking = self.env['stock.picking']
            // grouped_moves = groupby(self, key=lambda m: m._key_assign_picking())
            // for group, moves in grouped_moves:
            //     moves = self.env['stock.move'].concat(*moves)
            //     new_picking = False
            //     # Could pass the arguments contained in group but they are the same
            //     # for each move that why moves[0] is acceptable
            //     picking = moves[0]._search_picking_for_assignation()
            //     if picking:
            //         # If a picking is found, we'll append `move` to its move list and thus its
            //         # `partner_id` and `ref` field will refer to multiple records. In this
            //         # case, we chose to wipe them.
            //         vals = moves._assign_picking_values(picking)
            //         if vals:
            //             picking.write(vals)
            //     else:
            //         # Don't create picking for negative moves since they will be
            //         # reverse and assign to another picking
            //         moves = moves.filtered(lambda m: float_compare(m.product_uom_qty, 0.0, precision_rounding=m.product_uom.rounding) >= 0)
            //         if not moves:
            //             continue
            //         new_picking = True
            //         picking = Picking.create(moves._get_new_picking_values())
            // 
            //     moves.write({'picking_id': picking.id})
            //     moves._assign_picking_post_process(new=new_picking)
            // return True
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingPostProcessInternalAsync(object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _assign_picking_post_process(self, new=False):
            // super(StockMove, self)._assign_picking_post_process(new=new)
            // if new:
            //     picking_id = self.mapped('picking_id')
            //     sale_order_ids = self.mapped('sale_line_id.order_id')
            //     for sale_order_id in sale_order_ids:
            //         picking_id.message_post_with_source(
            //             'mail.message_origin_link',
            //             render_values={'self': picking_id, 'origin': sale_order_id},
            //             subtype_xmlid='mail.mt_note',
            //         )
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _assign_picking_post_process(self, new=False):
            // pass
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def _assign_picking_post_process(self, new=False):
            // super()._assign_picking_post_process(new=new)
            // for picking in self.picking_id:
            //     picking._find_auto_batch()
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingValuesInternalAsync(object picking)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py) ---
            // def _assign_picking_values(self, picking):
            // return {
            //     **super()._assign_picking_values(picking),
            //     'project_id': self[:1].sale_line_id.order_id.project_id.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _assign_picking_values(self, picking):
            // vals = {}
            // if any(picking.partner_id != m.partner_id for m in self):
            //     vals['partner_id'] = False
            // if any(picking.origin != m.origin for m in self):
            //     current_origins = set(picking.origin.split(',') + [False]) if picking.origin else {False}
            //     vals['origin'] = picking.origin
            //     for move in self:
            //         if move.origin not in current_origins:
            //             if not vals['origin']:
            //                 vals['origin'] = move.origin
            //             else:
            //                 vals['origin'] += f',{move.origin}'
            // return vals
            */
            return default;
        }

        public async Task<StockMove> AssignSerialAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_assign_serial(self):
            // """ Opens a wizard to assign SN's name on each move lines.
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.act_assign_serial_numbers")
            // action['context'] = {
            //     'default_product_id': self.product_id.id,
            //     'default_move_id': self.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _auto_init(self):
            // if not column_exists(self.env.cr, "stock_move", "weight"):
            //     # In case of a big database with a lot of stock moves, the RAM gets exhausted
            //     # To prevent a process from being killed We create the column 'weight' manually
            //     # Then we do the computation in a query by multiplying product weight with qty
            //     create_column(self.env.cr, "stock_move", "weight", "numeric")
            //     self.env.cr.execute("""
            //         UPDATE stock_move move
            //         SET weight = move.product_qty * product.weight
            //         FROM product_product product
            //         WHERE move.product_id = product.id
            //         AND move.state != 'cancel'
            //         """)
            // return super()._auto_init()
            */
            return default;
        }

        protected async Task<StockMove> AutoRecordComponentsInternalAsync(object qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _auto_record_components(self, qty):
            // self.ensure_one()
            // subcontracted_productions = self._get_subcontract_production()
            // production = subcontracted_productions.filtered(lambda p: not p._has_been_recorded())[-1:]
            // if not production:
            //     # If new quantity is over the already recorded quantity and we have no open production, then create a new one for the missing quantity.
            //     production = subcontracted_productions[-1:]
            //     production = production.sudo().with_context(allow_more=True)._split_productions({production: [production.qty_producing, qty]})[-1:]
            // qty = self.product_uom._compute_quantity(qty, production.product_uom_id)
            // 
            // if production.product_tracking == 'serial':
            //     qty = float_round(qty, precision_digits=0, rounding_method='UP')  # Makes no sense to have partial quantities for serial number
            //     if float_compare(qty, production.product_qty, precision_rounding=production.product_uom_id.rounding) < 0:
            //         remaining_qty = production.product_qty - qty
            //         productions = production.sudo()._split_productions({production: ([1] * int(qty)) + [remaining_qty]})[:-1]
            //     else:
            //         productions = production.sudo().with_context(allow_more=True)._split_productions({production: ([1] * int(qty))})
            // 
            //     for production in productions:
            //         production.qty_producing = 1
            //         if not production.lot_producing_id:
            //             production.action_generate_serial()
            //         production.with_context(cancel_backorder=False).subcontracting_record_component()
            // else:
            //     production.qty_producing = qty
            //     if float_compare(production.qty_producing, production.product_qty, precision_rounding=production.product_uom_id.rounding) > 0:
            //         self.env['change.production.qty'].with_context(skip_activity=True).create({
            //             'mo_id': production.id,
            //             'product_qty': qty
            //         }).change_prod_qty()
            //     if production.product_tracking == 'lot' and not production.lot_producing_id:
            //         production.action_generate_serial()
            //     production._set_qty_producing()
            //     production.with_context(cancel_backorder=False).subcontracting_record_component()
            */
            return default;
        }

        protected async Task<StockMove> BreakMtoLinkInternalAsync(object parent_move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _break_mto_link(self, parent_move):
            // self.move_orig_ids = [Command.unlink(parent_move.id)]
            // self.procure_method = 'make_to_stock'
            // self._recompute_state()
            */
            return default;
        }

        protected async Task<StockMove> CalMoveWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _cal_move_weight(self):
            // moves_with_weight = self.filtered(lambda moves: moves.product_id.weight > 0.00)
            // for move in moves_with_weight:
            //     move.weight = (move.product_qty * move.product_id.weight)
            // (self - moves_with_weight).weight = 0
            */
            return default;
        }

        protected async Task<StockMove> CheckAccessIfSubcontractorInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _check_access_if_subcontractor(self, vals):
            // if self.env.user._is_portal() and not self.env.su:
            //     if vals.get('state') == 'done':
            //         raise AccessError(_("Portal users cannot create a stock move with a state 'Done' or change the current state to 'Done'."))
            */
            return default;
        }

        protected async Task<StockMove> CheckNegativeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _check_negative_quantity(self):
            // for move in self:
            //     if move.raw_material_production_id and float_compare(move.quantity, 0, precision_rounding=move.product_uom.rounding) < 0:
            //         raise ValidationError(_("Please enter a positive quantity."))
            */
            return default;
        }

        protected async Task<StockMove> CheckQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _check_quantity(self):
            // return self.env['stock.quant'].search([
            //     ('product_id', 'in', self.product_id.ids),
            //     ('location_id', 'child_of', self.location_dest_id.ids),
            //     ('lot_id', 'in', self.lot_ids.ids)
            // ]).check_quantity()
            */
            return default;
        }

        protected async Task<StockMove> CheckUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _check_uom(self):
            // moves_error = self.filtered(lambda move: move.product_id.uom_id.category_id != move.product_uom.category_id)
            // if moves_error:
            //     user_warnings = [
            //         _('You cannot perform moves because their unit of measure has a different category from their product unit of measure.'),
            //         *(
            //             _('%(product_name)s --> Product UoM is %(product_uom)s (%(product_uom_category)s) - Move UoM is %(move_uom)s (%(move_uom_category)s)',
            //               product_name=move.product_id.display_name,
            //               product_uom=move.product_id.uom_id.name,
            //               product_uom_category=move.product_id.uom_id.category_id.name,
            //               move_uom=move.product_uom.name,
            //               move_uom_category=move.product_uom.category_id.name)
            //             for move in moves_error
            //         ),
            //         _('Blocking: %s', ' ,'.join(moves_error.mapped('name')))
            //     ]
            //     raise UserError('\n\n'.join(user_warnings))
            */
            return default;
        }

        protected async Task<StockMove> CleanMergedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _clean_merged(self):
            // super(StockMove, self)._clean_merged()
            // self.write({'created_purchase_line_ids': [Command.clear()]})
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _clean_merged(self):
            // """Cleanup hook used when merging moves"""
            // self.write({'propagate_cancel': False})
            */
            return default;
        }

        protected async Task<StockMove> CleanRepairSaleOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _clean_repair_sale_order_line(self):
            // self.filtered(
            //     lambda m: m.repair_id and m.sale_line_id
            // ).mapped('sale_line_id').write({'product_uom_qty': 0.0})
            */
            return default;
        }

        protected async Task<StockMove> ComputeDelayAlertDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_delay_alert_date(self):
            // for move in self:
            //     if move.state in ('done', 'cancel'):
            //         move.delay_alert_date = False
            //         continue
            //     prev_moves = move.move_orig_ids.filtered(lambda m: m.state not in ('done', 'cancel') and m.date)
            //     prev_max_date = max(prev_moves.mapped("date"), default=False)
            //     if prev_max_date and prev_max_date > move.date:
            //         move.delay_alert_date = prev_max_date
            //     else:
            //         move.delay_alert_date = False
            */
            return default;
        }

        protected async Task<StockMove> ComputeDescriptionBomLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_description_bom_line(self):
            // bom_line_description = {}
            // for bom in self.bom_line_id.bom_id:
            //     if bom.type != 'phantom':
            //         continue
            //     line_ids = self.bom_line_id.filtered(lambda line: line.bom_id == bom).mapped('id')
            //     total = len(line_ids)
            //     for i, line_id in enumerate(line_ids):
            //         bom_line_description[line_id] = '%s - %d/%d' % (bom.display_name, i + 1, total)
            // 
            // for move in self:
            //     move.description_bom_line = bom_line_description.get(move.bom_line_id.id, move.description_bom_line)
            */
            return default;
        }

        protected async Task<StockMove> ComputeDisplayAssignSerialInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_display_assign_serial(self):
            // super()._compute_display_assign_serial()
            // for move in self:
            //     if move.display_import_lot \
            //             and move.raw_material_production_id \
            //             and not move.raw_material_production_id.picking_type_id.use_create_components_lots:
            //         move.display_import_lot = False
            //         move.display_assign_serial = False
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_display_assign_serial(self):
            // super(StockMove, self)._compute_display_assign_serial()
            // for move in self:
            //     if not move.is_subcontract:
            //         continue
            //     productions = move._get_subcontract_production()
            //     if not productions or move.has_tracking == 'none':
            //         continue
            //     if productions._has_tracked_component() or productions[:1].consumption != 'strict':
            //         move.display_assign_serial = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_display_assign_serial(self):
            // for move in self:
            //     move.display_import_lot = (
            //         move.has_tracking != 'none' and
            //         move.product_id and
            //         move.picking_type_id.use_create_lots and
            //         not move.origin_returned_move_id.id and
            //         move.state not in ('done', 'cancel')
            //     )
            //     move.display_assign_serial = move.display_import_lot
            */
            return default;
        }

        protected async Task<StockMove> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_display_name(self):
            // for move in self:
            //     move.display_name = '%s%s%s>%s' % (
            //         move.picking_id.origin and '%s/' % move.picking_id.origin or '',
            //         move.product_id.code and '%s: ' % move.product_id.code or '',
            //         move.location_id.name, move.location_dest_id.name)
            */
            return default;
        }

        protected async Task<StockMove> ComputeForecastInformationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _compute_forecast_information(self):
            // moves_to_compute = self.filtered(lambda move: not move.repair_line_type or move.repair_line_type == 'add')
            // for move in (self - moves_to_compute):
            //     move.forecast_availability = move.product_qty
            //     move.forecast_expected_date = False
            // return super(StockMove, moves_to_compute)._compute_forecast_information()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_forecast_information(self):
            // """ Compute forecasted information of the related product by warehouse."""
            // self.forecast_availability = False
            // self.forecast_expected_date = False
            // 
            // # Prefetch product info to avoid fetching all product fields
            // self.product_id.fetch(['type', 'uom_id'])
            // 
            // not_product_moves = self.filtered(lambda move: not move.product_id.is_storable)
            // for move in not_product_moves:
            //     move.forecast_availability = move.product_qty
            // 
            // product_moves = (self - not_product_moves)
            // 
            // outgoing_unreserved_moves_per_warehouse = defaultdict(set)
            // now = fields.Datetime.now()
            // 
            // def key_virtual_available(move, incoming=False):
            //     warehouse_id = move.location_dest_id.warehouse_id.id if incoming else move.location_id.warehouse_id.id
            //     return warehouse_id, max(move.date or now, now)
            // 
            // # Prefetch efficiently virtual_available for _is_consuming draft move.
            // prefetch_virtual_available = defaultdict(set)
            // virtual_available_dict = {}
            // for move in product_moves:
            //     if move._is_consuming() and move.state == 'draft':
            //         prefetch_virtual_available[key_virtual_available(move)].add(move.product_id.id)
            //     elif move.picking_type_id.code == 'incoming':
            //         prefetch_virtual_available[key_virtual_available(move, incoming=True)].add(move.product_id.id)
            // for key_context, product_ids in prefetch_virtual_available.items():
            //     read_res = self.env['product.product'].browse(product_ids).with_context(warehouse_id=key_context[0], to_date=key_context[1]).read(['virtual_available'])
            //     virtual_available_dict[key_context] = {res['id']: res['virtual_available'] for res in read_res}
            // 
            // for move in product_moves:
            //     if move._is_consuming():
            //         if move.state == 'assigned':
            //             move.forecast_availability = move.product_uom._compute_quantity(
            //                 move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //         elif move.state == 'draft':
            //             # for move _is_consuming and in draft -> the forecast_availability > 0 if in stock
            //             move.forecast_availability = virtual_available_dict[key_virtual_available(move)][move.product_id.id] - move.product_qty
            //         elif move.state in ('waiting', 'confirmed', 'partially_available'):
            //             outgoing_unreserved_moves_per_warehouse[move.location_id.warehouse_id].add(move.id)
            //     elif move.picking_type_id.code == 'incoming':
            //         forecast_availability = virtual_available_dict[key_virtual_available(move, incoming=True)][move.product_id.id]
            //         if move.state == 'draft':
            //             forecast_availability += move.product_qty
            //         move.forecast_availability = forecast_availability
            // 
            // for warehouse, moves_ids in outgoing_unreserved_moves_per_warehouse.items():
            //     if not warehouse:  # No prediction possible if no warehouse.
            //         continue
            //     moves = self.browse(moves_ids)
            //     moves_per_location = defaultdict(lambda: self.env['stock.move'])
            //     for move in moves:
            //         moves_per_location[move.location_id] |= move
            //     for location, mvs in moves_per_location.items():
            //         forecast_info = mvs._get_forecast_availability_outgoing(warehouse, location)
            //         for move in mvs:
            //             move.forecast_availability, move.forecast_expected_date = forecast_info[move]
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_is_done(self):
            // for move in self:
            //     move.is_done = (move.state in ('done', 'cancel'))
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsInitialDemandEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_is_initial_demand_editable(self):
            // for move in self:
            //     move.is_initial_demand_editable = not move.picking_id.is_locked or move.state == 'draft'
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsLockedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_is_locked(self):
            // super(StockMove, self)._compute_is_locked()
            // for move in self:
            //     if move.raw_material_production_id:
            //         move.is_locked = move.raw_material_production_id.is_locked
            //     if move.production_id:
            //         move.is_locked = move.production_id.is_locked
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_is_locked(self):
            // for move in self:
            //     if move.picking_id:
            //         move.is_locked = move.picking_id.is_locked
            //     else:
            //         move.is_locked = False
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsQuantityDoneEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_is_quantity_done_editable(self):
            // for move in self:
            //     move.is_quantity_done_editable = move.product_id
            */
            return default;
        }

        protected async Task<StockMove> ComputeKitQuantitiesInternalAsync(Guid product_id, object kit_qty, object kit_bom, object filters)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_kit_quantities(self, product_id, kit_qty, kit_bom, filters):
            // """ Computes the quantity delivered or received when a kit is sold or purchased.
            // A ratio 'qty_processed/qty_needed' is computed for each component, and the lowest one is kept
            // to define the kit's quantity delivered or received.
            // :param product_id: The kit itself a.k.a. the finished product
            // :param kit_qty: The quantity from the order line
            // :param kit_bom: The kit's BoM
            // :param filters: Dict of lambda expression to define the moves to consider and the ones to ignore
            // :return: The quantity delivered or received
            // """
            // qty_ratios = []
            // kit_qty = kit_qty / kit_bom.product_qty
            // boms, bom_sub_lines = kit_bom.explode(product_id, kit_qty)
            // 
            // def get_qty(move):
            //     if move.picked:
            //         return move.product_uom._compute_quantity(move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //     else:
            //         return move.product_qty
            // 
            // for bom_line, bom_line_data in bom_sub_lines:
            //     # skip service since we never deliver them
            //     if bom_line.product_id.type == 'service':
            //         continue
            //     if float_is_zero(bom_line_data['qty'], precision_rounding=bom_line.product_uom_id.rounding):
            //         # As BoMs allow components with 0 qty, a.k.a. optionnal components, we simply skip those
            //         # to avoid a division by zero.
            //         continue
            //     bom_line_moves = self.filtered(lambda m: m.bom_line_id == bom_line)
            //     if bom_line_moves:
            //         # We compute the quantities needed of each components to make one kit.
            //         # Then, we collect every relevant moves related to a specific component
            //         # to know how many are considered delivered.
            //         uom_qty_per_kit = bom_line_data['qty'] / (bom_line_data['original_qty'])
            //         qty_per_kit = bom_line.product_uom_id._compute_quantity(uom_qty_per_kit / kit_bom.product_qty, bom_line.product_id.uom_id, round=False)
            //         if not qty_per_kit:
            //             continue
            //         incoming_qty = sum(bom_line_moves.filtered(filters['incoming_moves']).mapped(get_qty))
            //         outgoing_qty = sum(bom_line_moves.filtered(filters['outgoing_moves']).mapped(get_qty))
            //         qty_processed = incoming_qty - outgoing_qty
            //         # We compute a ratio to know how many kits we can produce with this quantity of that specific component
            //         qty_ratios.append(float_round(qty_processed / qty_per_kit, precision_rounding=bom_line.product_id.uom_id.rounding))
            //     else:
            //         return 0.0
            // if qty_ratios:
            //     # Now that we have every ratio by components, we keep the lowest one to know how many kits we can produce
            //     # with the quantities delivered of each component. We use the floor division here because a 'partial kit'
            //     # doesn't make sense.
            //     return min(qty_ratios) // 1
            // else:
            //     return 0.0
            */
            return default;
        }

        protected async Task<StockMove> ComputeLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_location_dest_id(self):
            // ids_to_super = set()
            // for move in self:
            //     if move.production_id:
            //         move.location_dest_id = move.production_id.location_dest_id
            //     elif move.raw_material_production_id:
            //         move.location_dest_id = move.product_id.with_company(move.company_id).property_stock_production.id
            //     else:
            //         ids_to_super.add(move.id)
            // return super(StockMove, self.browse(ids_to_super))._compute_location_dest_id()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _compute_location_dest_id(self):
            // ids_to_super = set()
            // for move in self:
            //     if move.repair_id and move.repair_line_type:
            //         move.location_dest_id = move.repair_id[
            //             MAP_REPAIR_LINE_TYPE_TO_MOVE_LOCATIONS_FROM_REPAIR[move.repair_line_type]['location_dest_id']
            //         ]
            //     else:
            //         ids_to_super.add(move.id)
            // return super(StockMove, self.browse(ids_to_super))._compute_location_dest_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_location_dest_id(self):
            // customer_loc, __ = self.env['stock.warehouse']._get_partner_locations()
            // inter_comp_location = self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False)
            // for move in self:
            //     location_dest = False
            //     if move.picking_id:
            //         location_dest = move.picking_id.location_dest_id
            //     elif move.rule_id.location_dest_from_rule:
            //         location_dest = move.rule_id.location_dest_id
            //     elif move.picking_type_id:
            //         location_dest = move.picking_type_id.default_location_dest_id
            //     is_move_to_interco_transit = False
            //     if location_dest:
            //         is_move_to_interco_transit = location_dest._child_of(customer_loc) and move.location_final_id == inter_comp_location
            //     if location_dest and move.location_final_id and (move.location_final_id._child_of(location_dest) or is_move_to_interco_transit):
            //         # Force the location_final as dest in the following cases:
            //         # - The location_final is a sublocation of destination -> Means we reached the end
            //         # - The location dest is an out location (i.e. Customers) but the final dest is different (e.g. Inter-Company transfers)
            //         location_dest = move.location_final_id
            //     move.location_dest_id = location_dest
            */
            return default;
        }

        protected async Task<StockMove> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_location_id(self):
            // ids_to_super = set()
            // for move in self:
            //     if move.production_id:
            //         move.location_id = move.product_id.with_company(move.company_id).property_stock_production.id
            //     elif move.raw_material_production_id:
            //         move.location_id = move.raw_material_production_id.location_src_id
            //     else:
            //         ids_to_super.add(move.id)
            // return super(StockMove, self.browse(ids_to_super))._compute_location_id()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _compute_location_id(self):
            // ids_to_super = set()
            // for move in self:
            //     if move.repair_id and move.repair_line_type:
            //         move.location_id = move.repair_id[
            //             MAP_REPAIR_LINE_TYPE_TO_MOVE_LOCATIONS_FROM_REPAIR[move.repair_line_type]['location_id']
            //         ]
            //     else:
            //         ids_to_super.add(move.id)
            // return super(StockMove, self.browse(ids_to_super))._compute_location_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_location_id(self):
            // for move in self:
            //     if move.picked:
            //         continue
            //     if not (location := move.location_id) or move.picking_id != move._origin.picking_id or move.picking_type_id != move._origin.picking_type_id:
            //         if move.picking_id:
            //             location = move.picking_id.location_id
            //         elif move.picking_type_id:
            //             location = move.picking_type_id.default_location_src_id
            //     move.location_id = location
            */
            return default;
        }

        protected async Task<StockMove> ComputeLotIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_lot_ids(self):
            // domain = [('move_id', 'in', self.ids), ('lot_id', '!=', False), ('quantity', '!=', 0.0)]
            // lots_by_move_id = self.env['stock.move.line']._read_group(
            //     domain,
            //     ['move_id'], ['lot_id:array_agg'],
            // )
            // lots_by_move_id = {move.id: lot_ids for move, lot_ids in lots_by_move_id}
            // for move in self:
            //     move.lot_ids = lots_by_move_id.get(move._origin.id, [])
            */
            return default;
        }

        protected async Task<StockMove> ComputeManualConsumptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_manual_consumption(self):
            // for move in self:
            //     # when computed for new_id in onchange, use value from _origin
            //     if move != move._origin:
            //         move.manual_consumption = move._origin.manual_consumption
            //     elif not move.manual_consumption:
            //         move.manual_consumption = move._is_manual_consumption()
            */
            return default;
        }

        protected async Task<StockMove> ComputeMoveLinesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_move_lines_count(self):
            // for move in self:
            //     move.move_lines_count = len(move.move_line_ids)
            */
            return default;
        }

        protected async Task<StockMove> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _compute_partner_id(self):
            // # dropshipped moves should have their partner_ids directly set
            // not_dropshipped_moves = self.filtered(lambda m: not m._is_dropshipped())
            // super(StockMove, not_dropshipped_moves)._compute_partner_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_partner_id(self):
            // for move in self.filtered(lambda m: m.picking_id):
            //     move.partner_id = move.picking_id.partner_id
            */
            return default;
        }

        protected async Task<StockMove> ComputePickedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_picked(self):
            // subcontracted_moves = self.filtered(lambda m: m.is_subcontract and float_compare(m.product_uom_qty, m.quantity, precision_rounding=m.product_uom.rounding) != 0)
            // super(StockMove, self - subcontracted_moves)._compute_picked()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_picked(self):
            // for move in self:
            //     if move.state == 'done' or any(ml.picked for ml in move.move_line_ids):
            //         move.picked = True
            //     elif move.move_line_ids:
            //         move.picked = False
            */
            return default;
        }

        protected async Task<StockMove> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_picking_type_id(self):
            // super()._compute_picking_type_id()
            // for move in self:
            //     if move.raw_material_production_id or move.production_id:
            //         move.picking_type_id = (move.raw_material_production_id or move.production_id).picking_type_id
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _compute_picking_type_id(self):
            // remaining_moves = self
            // for move in self:
            //     if move.repair_id:
            //         move.picking_type_id = move.repair_id.picking_type_id
            //         remaining_moves -= move
            // return super(StockMove, remaining_moves)._compute_picking_type_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_picking_type_id(self):
            // for move in self:
            //     if move.picking_id:
            //         move.picking_type_id = move.picking_id.picking_type_id
            */
            return default;
        }

        protected async Task<StockMove> ComputePriorityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_priority(self):
            // super()._compute_priority()
            // for move in self:
            //     move.priority = move.raw_material_production_id.priority or move.priority or '0'
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_priority(self):
            // for move in self:
            //     move.priority = move.picking_id.priority or '0'
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_product_availability(self):
            // """ Fill the `availability` field on a stock move, which is the quantity to potentially
            // reserve. When the move is done, `availability` is set to the quantity the move did actually
            // move.
            // """
            // for move in self:
            //     if move.state == 'done':
            //         move.availability = move.product_qty
            //     else:
            //         total_availability = self.env['stock.quant']._get_available_quantity(move.product_id, move.location_id) if move.product_id else 0.0
            //         move.availability = min(move.product_qty, total_availability)
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductPackagingQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_product_packaging_qty(self):
            // self.product_packaging_qty = False
            // for move in self:
            //     if not move.product_packaging_id:
            //         continue
            //     move.product_packaging_qty = move.product_packaging_id._compute_qty(move.product_qty)
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductPackagingQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_product_packaging_quantity(self):
            // self.product_packaging_quantity = False
            // for move in self:
            //     if not move.product_packaging_id:
            //         continue
            //     move.product_packaging_quantity = move.product_packaging_id._compute_qty(move.quantity, move.product_uom)
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_product_qty(self):
            // for move in self:
            //     move.product_qty = move.product_uom._compute_quantity(
            //         move.product_uom_qty, move.product_id.uom_id, rounding_method='HALF-UP')
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_product_uom(self):
            // for move in self:
            //     move.product_uom = move.product_id.uom_id.id
            */
            return default;
        }

        protected async Task<StockMove> ComputeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_quantity(self):
            // """ This field represents the sum of the move lines `quantity`. It allows the user to know
            // if there is still work to do.
            // 
            // We take care of rounding this value at the general decimal precision and not the rounding
            // of the move's UOM to make sure this value is really close to the real sum, because this
            // field will be used in `_action_done` in order to know if the move will need a backorder or
            // an extra move.
            // """
            // if not any(self._ids):
            //     # onchange
            //     for move in self:
            //         move.quantity = move._quantity_sml()
            // else:
            //     # compute
            //     move_lines_ids = set()
            //     for move in self:
            //         move_lines_ids |= set(move.move_line_ids.ids)
            // 
            //     data = self.env['stock.move.line']._read_group(
            //         [('id', 'in', list(move_lines_ids))],
            //         ['move_id', 'product_uom_id'], ['quantity:sum']
            //     )
            //     sum_qty = defaultdict(float)
            //     for move, product_uom, qty_sum in data:
            //         uom = move.product_uom
            //         sum_qty[move.id] += product_uom._compute_quantity(qty_sum, uom, round=False)
            // 
            //     for move in self:
            //         move.quantity = sum_qty[move.id]
            */
            return default;
        }

        protected async Task<StockMove> ComputeReferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_reference(self):
            // moves_with_reference = self.env['stock.move']
            // for move in self:
            //     if move.raw_material_production_id and move.raw_material_production_id.name:
            //         move.reference = move.raw_material_production_id.name
            //         moves_with_reference |= move
            //     if move.production_id and move.production_id.name:
            //         move.reference = move.production_id.name
            //         moves_with_reference |= move
            // super(StockMove, self - moves_with_reference)._compute_reference()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_reference(self):
            // for move in self:
            //     move.reference = move.picking_id.name if move.picking_id else move.name
            */
            return default;
        }

        protected async Task<StockMove> ComputeReservationDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_reservation_date(self):
            // for move in self:
            //     if move.picking_type_id.reservation_method == 'by_date' and move.state in ['draft', 'confirmed', 'waiting', 'partially_available']:
            //         days = move.picking_type_id.reservation_days_before
            //         if move.priority == '1':
            //             days = move.picking_type_id.reservation_days_before_priority
            //         move.reservation_date = fields.Date.to_date(move.date) - timedelta(days=days)
            //     elif move.picking_type_id.reservation_method == 'manual':
            //         move.reservation_date = False
            */
            return default;
        }

        protected async Task<StockMove> ComputeShouldConsumeQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_should_consume_qty(self):
            // for move in self:
            //     mo = move.raw_material_production_id
            //     if not mo or not move.product_uom:
            //         move.should_consume_qty = 0
            //         continue
            //     move.should_consume_qty = float_round((mo.qty_producing - mo.qty_produced) * move.unit_factor, precision_rounding=move.product_uom.rounding)
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowDetailsVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_show_details_visible(self):
            // """ If the move is subcontract and the components are tracked. Then the
            // show details button is visible.
            // """
            // res = super(StockMove, self)._compute_show_details_visible()
            // for move in self:
            //     if not move.is_subcontract:
            //         continue
            //     if self.env.user._is_portal():
            //         move.show_details_visible = any(not p._has_been_recorded() for p in move._get_subcontract_production())
            //         continue
            //     productions = move._get_subcontract_production()
            //     if not productions._has_tracked_component() and productions[:1].consumption == 'strict':
            //         continue
            //     move.show_details_visible = True
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_show_details_visible(self):
            // """ According to this field, the button that calls `action_show_details` will be displayed
            // to work on a move from its picking form view, or not.
            // """
            // has_package = self.env.user.has_group('stock.group_tracking_lot')
            // multi_locations_enabled = self.env.user.has_group('stock.group_stock_multi_locations')
            // consignment_enabled = self.env.user.has_group('stock.group_tracking_owner')
            // 
            // show_details_visible = multi_locations_enabled or has_package or consignment_enabled
            // 
            // for move in self:
            //     if not move.product_id:
            //         move.show_details_visible = False
            //     elif not move.picking_type_id.use_create_lots and not move.picking_type_id.use_existing_lots\
            //         and not self.env.user.has_group('stock.group_stock_tracking_lot')\
            //         and not self.env.user.has_group('stock.group_stock_multi_locations'):
            //         move.show_details_visible = False
            //     elif len(move.move_line_ids) > 1:
            //         move.show_details_visible = True
            //     else:
            //         move.show_details_visible = show_details_visible or move.has_tracking != 'none'
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_show_info(self):
            // super()._compute_show_info()
            // byproduct_moves = self.filtered(lambda m: m.byproduct_id or m in self.production_id.move_finished_ids)
            // byproduct_moves.show_quant = False
            // byproduct_moves.show_lots_m2o = True
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_show_info(self):
            // for move in self:
            //     move.show_quant = move.picking_code != 'incoming'\
            //                    and move.product_id.is_storable
            //     move.show_lots_text = move.has_tracking != 'none'\
            //         and move.picking_type_id.use_create_lots\
            //         and not move.picking_type_id.use_existing_lots\
            //         and move.state != 'done' \
            //         and not move.origin_returned_move_id.id
            //     move.show_lots_m2o = not move.show_quant\
            //         and not move.show_lots_text\
            //         and move.has_tracking != 'none'\
            //         and (move.picking_type_id.use_existing_lots or move.state == 'done' or move.origin_returned_move_id.id)
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowSubcontractingDetailsVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_show_subcontracting_details_visible(self):
            // """ Compute if the action button in order to see moves raw is visible """
            // self.show_subcontracting_details_visible = False
            // for move in self:
            //     if not move.is_subcontract:
            //         continue
            //     if not move.picked or float_is_zero(move.quantity, precision_rounding=move.product_uom.rounding):
            //         continue
            //     productions = move._get_subcontract_production()
            //     if not productions or (productions[:1].consumption == 'strict' and not productions[:1]._has_tracked_component()):
            //         continue
            //     move.show_subcontracting_details_visible = True
            */
            return default;
        }

        protected async Task<StockMove> ComputeUnitFactorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_unit_factor(self):
            // for move in self:
            //     mo = move.raw_material_production_id or move.production_id
            //     if mo:
            //         move.unit_factor = move.product_uom_qty / ((mo.product_qty - mo.qty_produced) or 1)
            //     else:
            //         move.unit_factor = 1.0
            */
            return default;
        }

        protected async Task<StockMove> ConvertStringIntoFieldDataInternalAsync(object @string, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def _convert_string_into_field_data(self, string, options):
            // res = super()._convert_string_into_field_data(string, options)
            // if not res:
            //     try:
            //         datetime = dparser.parse(string, **options)
            //         if self and not self.use_expiration_date:
            //             # The datetime was correctly parsed but this move's product doesn't use expiration date.
            //             return "ignore"
            //         return {'expiration_date': datetime}
            //     except ValueError:
            //         pass
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _convert_string_into_field_data(self, string, options):
            // string = string.replace(',', '.')  # Parsing string as float works only with dot, not comma.
            // if regex_findall(r'^([0-9]+\.?[0-9]*|\.[0-9]+)$', string):  # Number => Quantity.
            //     return {'quantity': float(string)}
            // return False
            */
            return default;
        }

        public async Task<StockMove> CopyDataAsync(Guid id, StockMoveCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for move, vals in zip(self, vals_list):
            //     if 'location_id' in default or not move.is_subcontract:
            //         continue
            //     vals['location_id'] = move.picking_id.location_id.id
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for move, vals in zip(self, vals_list):
            //     if 'repair_id' in default or move.repair_id:
            //         vals['sale_line_id'] = False
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<StockMove> CreateAsync(StockMove entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def create(self, vals_list):
            // """ Enforce consistent values (i.e. match _get_move_raw_values/_get_move_finished_values) for:
            // - Manually added components/byproducts specifically values we can't set via view with "default_"
            // - Moves from a copied MO
            // - Backorders
            // """
            // if self.env.context.get('force_manual_consumption'):
            //     for vals in vals_list:
            //         vals['manual_consumption'] = True
            // mo_id_to_mo = defaultdict(lambda: self.env['mrp.production'])
            // product_id_to_product = defaultdict(lambda: self.env['product.product'])
            // for values in vals_list:
            //     mo_id = values.get('raw_material_production_id', False) or values.get('production_id', False)
            //     location_dest = self.env['stock.location'].browse(values.get('location_dest_id'))
            //     if mo_id and not values.get('scrapped') and not location_dest.scrap_location:
            //         mo = mo_id_to_mo[mo_id]
            //         if not mo:
            //             mo = mo.browse(mo_id)
            //             mo_id_to_mo[mo_id] = mo
            //         values['name'] = mo.name
            //         values['origin'] = mo._get_origin()
            //         values['group_id'] = mo.procurement_group_id.id
            //         values['propagate_cancel'] = mo.propagate_cancel
            //         if values.get('raw_material_production_id', False):
            //             product = product_id_to_product[values['product_id']]
            //             if not product:
            //                 product = product.browse(values['product_id'])
            //             product_id_to_product[values['product_id']] = product
            //             values['location_dest_id'] = mo.production_location_id.id
            //             if not values.get('location_id'):
            //                 values['location_id'] = mo.location_src_id.id
            //             if mo.state in ['progress', 'to_close'] and mo.qty_producing > 0:
            //                 values['picked'] = True
            //             continue
            //         # produced products + byproducts
            //         values['location_id'] = mo.production_location_id.id
            //         values['date'] = mo.date_finished
            //         values['date_deadline'] = mo.date_deadline
            //         if not values.get('location_dest_id'):
            //             values['location_dest_id'] = mo.location_dest_id.id
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._check_access_if_subcontractor(vals)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if not vals.get('repair_id') or 'repair_line_type' not in vals:
            //         continue
            //     repair_id = self.env['repair.order'].browse([vals['repair_id']])
            //     vals['name'] = repair_id.name
            // moves = super().create(vals_list)
            // repair_moves = self.env['stock.move']
            // for move in moves:
            //     if not move.repair_id:
            //         continue
            //     move.group_id = move.repair_id.procurement_group_id.id
            //     move.origin = move.name
            //     move.picking_type_id = move.repair_id.picking_type_id.id
            //     repair_moves |= move
            // no_repair_moves = moves - repair_moves
            // draft_repair_moves = repair_moves.filtered(lambda m: m.state == 'draft' and m.repair_id.state in ('confirmed', 'under_repair'))
            // other_repair_moves = repair_moves - draft_repair_moves
            // draft_repair_moves._check_company()
            // draft_repair_moves._adjust_procure_method(picking_type_code='repair_operation')
            // res = draft_repair_moves._action_confirm()
            // res._trigger_scheduler()
            // confirmed_repair_moves = (res | other_repair_moves)
            // confirmed_repair_moves._create_repair_sale_order_line()
            // return (confirmed_repair_moves | no_repair_moves)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if (vals.get('quantity') or vals.get('move_line_ids')) and 'lot_ids' in vals:
            //         vals.pop('lot_ids')
            //     picking_id = self.env['stock.picking'].browse(vals.get('picking_id'))
            //     if picking_id.group_id and 'group_id' not in vals:
            //         vals['group_id'] = picking_id.group_id.id
            //     if picking_id.state == 'done' and vals.get('state') != 'done':
            //         vals['state'] = 'done'
            //     if vals.get('state') == 'done':
            //         vals['picked'] = True
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<StockMove> CreateBackorderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _create_backorder(self):
            // # Split moves where necessary and move quants
            // backorder_moves_vals = []
            // for move in self:
            //     # To know whether we need to create a backorder or not, round to the general product's
            //     # decimal precision and not the product's UOM.
            //     rounding = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     if float_compare(move.quantity, move.product_uom_qty, precision_digits=rounding) < 0:
            //         # Need to do some kind of conversion here
            //         qty_split = move.product_uom._compute_quantity(move.product_uom_qty - move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //         new_move_vals = move._split(qty_split)
            //         backorder_moves_vals += new_move_vals
            // backorder_moves = self.env['stock.move'].create(backorder_moves_vals)
            // # The backorder moves are not yet in their own picking. We do not want to check entire packs for those
            // # ones as it could messed up the result_package_id of the moves being currently validated
            // backorder_moves.with_context(bypass_entire_pack=True, bypass_procurement_creation=True)._action_confirm(merge=False)
            // return backorder_moves
            */
            return default;
        }

        protected async Task<StockMove> CreateDropshippedReturnedSvlInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_dropshipped_returned_svl(self, forced_quantity=None):
            // """Create a `stock.valuation.layer` from `self`.
            // 
            // :param forced_quantity: under some circumstances, the quantity to value is different than
            //     the initial demand of the move (Default value = None). The lot to value is given in
            //     case of lot valuated product.
            // :type forced_quantity: tuple(stock.lot, float)
            // """
            // return self._create_dropshipped_svl(forced_quantity=forced_quantity)
            */
            return default;
        }

        protected async Task<StockMove> CreateDropshippedSvlInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_dropshipped_svl(self, forced_quantity=None):
            // """Create a `stock.valuation.layer` from `self`.
            // 
            // :param forced_quantity: under some circumstances, the quantity to value is different than
            //     the initial demand of the move (Default value = None). The lot to value is given in
            //     case of lot valuated product.
            // :type forced_quantity: tuple(stock.lot, float)
            // """
            // svl_vals_list = self._get_dropshipped_svl_vals(forced_quantity)
            // return self.env['stock.valuation.layer'].sudo().create(svl_vals_list)
            */
            return default;
        }

        protected async Task<StockMove> CreateInSvlInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_in_svl(self, forced_quantity=None):
            // """Create a `stock.valuation.layer` from `self`.
            // 
            // :param forced_quantity: under some circumstances, the quantity to value is different than
            //     the initial demand of the move (Default value = None). The lot to value is given in
            //     case of lot valuated product.
            // :type forced_quantity: tuple(stock.lot, float)
            // """
            // svl_vals_list = self._get_in_svl_vals(forced_quantity)
            // return self.env['stock.valuation.layer'].sudo().create(svl_vals_list)
            */
            return default;
        }

        protected async Task<StockMove> CreateLotIdsFromMoveLineValsInternalAsync(object vals_list, Guid product_id, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _create_lot_ids_from_move_line_vals(self, vals_list, product_id, company_id=False):
            // """ This method will search or create the lot_id from the lot_name and set it in the vals_list
            // """
            // lot_names = {vals['lot_name'] for vals in vals_list if vals.get('lot_name')}
            // lot_ids = self.env['stock.lot'].search([
            //     ('product_id', '=', product_id),
            //     '|', ('company_id', '=', company_id), ('company_id', '=', False),
            //     ('name', 'in', list(lot_names)),
            // ])
            // 
            // lot_names -= set(lot_ids.mapped('name'))  # lot_names not found to create
            // lots_to_create_vals = [
            //     {'product_id': product_id, 'name': lot_name}
            //     for lot_name in lot_names
            // ]
            // lot_ids |= self.env['stock.lot'].create(lots_to_create_vals)
            // 
            // lot_id_by_name = {lot.name: lot.id for lot in lot_ids}
            // for vals in vals_list:
            //     lot_name = vals.get('lot_name', None)
            //     if not lot_name:
            //         continue
            //     vals['lot_id'] = lot_id_by_name[lot_name]
            //     vals['lot_name'] = False
            */
            return default;
        }

        protected async Task<StockMove> CreateOutSvlInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _create_out_svl(self, forced_quantity=None):
            // product_unbuild_map = defaultdict(self.env['mrp.unbuild'].browse)
            // for move in self:
            //     if move.unbuild_id:
            //         product_unbuild_map[move.product_id] |= move.unbuild_id
            // return super(StockMove, self.with_context(product_unbuild_map=product_unbuild_map))._create_out_svl(forced_quantity)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_out_svl(self, forced_quantity=None):
            // """Create a `stock.valuation.layer` from `self`.
            // 
            // :param forced_quantity: under some circumstances, the quantity to value is different than
            //     the initial demand of the move (Default value = None). The lot to value is given in
            //     case of lot valuated product.
            // :type forced_quantity: tuple(stock.lot, float)
            // """
            // svl_vals_list = self._get_out_svl_vals(forced_quantity)
            // return self.env['stock.valuation.layer'].sudo().create(svl_vals_list)
            */
            return default;
        }

        protected async Task<StockMove> CreateProductionLotsForPosOrderInternalAsync(object lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _create_production_lots_for_pos_order(self, lines):
            // ''' Search for existing lots and create missing ones.
            // 
            //     :param lines: pos order lines with pack lot ids.
            //     :type lines: pos.order.line recordset.
            // 
            //     :return stock.lot recordset.
            // '''
            // valid_lots = self.env['stock.lot']
            // moves = self.filtered(lambda m: m.picking_type_id.use_existing_lots)
            // # Already called in self._action_confirm() but just to be safe when coming from _launch_stock_rule_from_pos_order_lines.
            // self._check_company()
            // if moves:
            //     moves_product_ids = set(moves.mapped('product_id').ids)
            //     lots = lines.pack_lot_ids.filtered(lambda l: l.lot_name and l.product_id.id in moves_product_ids)
            //     lots_data = set(lots.mapped(lambda l: (l.product_id.id, l.lot_name)))
            //     existing_lots = self.env['stock.lot'].search([
            //         '|', ('company_id', '=', False), ('company_id', '=', moves[0].picking_type_id.company_id.id),
            //         ('product_id', 'in', lines.product_id.ids),
            //         ('name', 'in', lots.mapped('lot_name')),
            //     ])
            //     #The previous search may return (product_id.id, lot_name) combinations that have no matching in lines.pack_lot_ids.
            //     for lot in existing_lots:
            //         if (lot.product_id.id, lot.name) in lots_data:
            //             valid_lots |= lot
            //             lots_data.remove((lot.product_id.id, lot.name))
            //     moves = moves.filtered(lambda m: m.picking_type_id.use_create_lots)
            //     if moves:
            //         moves_product_ids = set(moves.mapped('product_id').ids)
            //         missing_lot_values = []
            //         for lot_product_id, lot_name in filter(lambda l: l[0] in moves_product_ids, lots_data):
            //             missing_lot_values.append({'company_id': self.company_id.id, 'product_id': lot_product_id, 'name': lot_name})
            //         valid_lots |= self.env['stock.lot'].create(missing_lot_values)
            // return valid_lots
            */
            return default;
        }

        protected async Task<StockMove> CreateRepairSaleOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _create_repair_sale_order_line(self):
            // if not self:
            //     return
            // so_line_vals = []
            // for move in self:
            //     if move.sale_line_id or move.repair_line_type != 'add' or not move.repair_id.sale_order_id:
            //         continue
            //     product_qty = move.product_uom_qty if move.repair_id.state != 'done' else move.quantity
            //     so_line_vals.append({
            //         'order_id': move.repair_id.sale_order_id.id,
            //         'product_id': move.product_id.id,
            //         'product_uom_qty': product_qty, # When relying only on so_line compute method, the sol quantity is only updated on next sol creation
            //         'product_uom': move.product_uom.id,
            //         'move_ids': [Command.link(move.id)],
            //         'qty_delivered': move.quantity if move.state == 'done' else 0.0,
            //     })
            //     if move.repair_id.under_warranty:
            //         so_line_vals[-1]['price_unit'] = 0.0
            //     elif move.price_unit:
            //         so_line_vals[-1]['price_unit'] = move.price_unit
            // 
            // self.env['sale.order.line'].create(so_line_vals)
            */
            return default;
        }

        public override async Task<StockMove> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def default_get(self, fields_list):
            // defaults = super(StockMove, self).default_get(fields_list)
            // if self.env.context.get('default_raw_material_production_id') or self.env.context.get('default_production_id'):
            //     production_id = self.env['mrp.production'].browse(self.env.context.get('default_raw_material_production_id') or self.env.context.get('default_production_id'))
            //     if production_id.state not in ('draft', 'cancel'):
            //         if production_id.state != 'done':
            //             defaults['state'] = 'draft'
            //         else:
            //             defaults['state'] = 'done'
            //             defaults['additional'] = True
            //         defaults['product_uom_qty'] = 0.0
            //     elif production_id.state == 'draft':
            //         defaults['group_id'] = production_id.procurement_group_id.id
            //         defaults['reference'] = production_id.name
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def default_get(self, fields_list):
            // # We override the default_get to make stock moves created after the picking was confirmed
            // # directly as available in immediate transfer mode. This allows to create extra move lines
            // # in the fp view. In planned transfer, the stock move are marked as `additional` and will be
            // # auto-confirmed.
            // defaults = super(StockMove, self).default_get(fields_list)
            // if self.env.context.get('default_picking_id'):
            //     picking_id = self.env['stock.picking'].browse(self.env.context['default_picking_id'])
            //     if picking_id.state == 'done':
            //         defaults['state'] = 'done'
            //         defaults['additional'] = True
            //     elif picking_id.state not in ['cancel', 'draft', 'done']:
            //         defaults['additional'] = True  # to trigger `_autoconfirm_picking`
            // return defaults
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<StockMove> DefaultGroupIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _default_group_id(self):
            // if self.env.context.get('default_picking_id'):
            //     return self.env['stock.picking'].browse(self.env.context['default_picking_id']).group_id.id
            // return False
            */
            return default;
        }

        protected async Task<StockMove> DelayAlertGetDocumentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _delay_alert_get_documents(self):
            // res = super(StockMove, self)._delay_alert_get_documents()
            // productions = self.raw_material_production_id | self.production_id
            // return res + list(productions)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _delay_alert_get_documents(self):
            // """Returns a list of recordset of the documents linked to the stock.move in `self` in order
            // to post the delay alert next activity. These documents are deduplicated. This method is meant
            // to be overridden by other modules, each of them adding an element by type of recordset on
            // this list.
            // 
            // :return: a list of recordset of the documents linked to `self`
            // :rtype: list
            // """
            // return list(self.mapped('picking_id'))
            */
            return default;
        }

        protected async Task<StockMove> DetermineIsManualConsumptionInternalAsync(object bom_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _determine_is_manual_consumption(self, bom_line):
            // return bom_line and (bom_line.manual_consumption or bom_line.operation_id)
            */
            return default;
        }

        protected async Task<StockMove> DoUnreserveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _do_unreserve(self):
            // moves_to_unreserve = OrderedSet()
            // for move in self:
            //     if move.state == 'cancel' or (move.state == 'done' and move.scrapped) or move.picked:
            //         # We may have cancelled move in an open picking in a "propagate_cancel" scenario.
            //         # We may have done move in an open picking in a scrap scenario.
            //         continue
            //     elif move.state == 'done':
            //         raise UserError(_("You cannot unreserve a stock move that has been set to 'Done'."))
            //     moves_to_unreserve.add(move.id)
            // moves_to_unreserve = self.env['stock.move'].browse(moves_to_unreserve)
            // 
            // ml_to_unlink = OrderedSet()
            // moves_not_to_recompute = OrderedSet()
            // for ml in moves_to_unreserve.move_line_ids:
            //     if ml.picked:
            //         moves_not_to_recompute.add(ml.move_id.id)
            //         continue
            //     ml_to_unlink.add(ml.id)
            // ml_to_unlink = self.env['stock.move.line'].browse(ml_to_unlink)
            // moves_not_to_recompute = self.env['stock.move'].browse(moves_not_to_recompute)
            // 
            // ml_to_unlink.unlink()
            // # `write` on `stock.move.line` doesn't call `_recompute_state` (unlike to `unlink`),
            // # so it must be called for each move where no move line has been deleted.
            // (moves_to_unreserve - moves_not_to_recompute)._recompute_state()
            // return True
            */
            return default;
        }

        public async Task<StockMove> ExplodeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def action_explode(self):
            // """ Explodes pickings """
            // # in order to explode a move, we must have a picking_type_id on that move because otherwise the move
            // # won't be assigned to a picking and it would be weird to explode a move into several if they aren't
            // # all grouped in the same picking.
            // moves_ids_to_return = OrderedSet()
            // moves_ids_to_unlink = OrderedSet()
            // phantom_moves_vals_list = []
            // for move in self:
            //     if (not move.picking_type_id and not (self.env.context.get('is_scrap') or self.env.context.get('skip_picking_assignation'))) or (move.production_id and move.production_id.product_id == move.product_id):
            //         moves_ids_to_return.add(move.id)
            //         continue
            //     bom = self.env['mrp.bom'].sudo()._bom_find(move.product_id, company_id=move.company_id.id, bom_type='phantom')[move.product_id]
            //     if not bom:
            //         moves_ids_to_return.add(move.id)
            //         continue
            //     if float_is_zero(move.product_uom_qty, precision_rounding=move.product_uom.rounding):
            //         factor = move.product_uom._compute_quantity(move.quantity, bom.product_uom_id) / bom.product_qty
            //     else:
            //         factor = move.product_uom._compute_quantity(move.product_uom_qty, bom.product_uom_id) / bom.product_qty
            //     _dummy, lines = bom.sudo().explode(move.product_id, factor, picking_type=bom.picking_type_id, never_attribute_values=move.never_product_template_attribute_value_ids)
            //     for bom_line, line_data in lines:
            //         if float_is_zero(move.product_uom_qty, precision_rounding=move.product_uom.rounding) or self.env.context.get('is_scrap'):
            //             phantom_moves_vals_list += move._generate_move_phantom(bom_line, 0, line_data['qty'])
            //         else:
            //             phantom_moves_vals_list += move._generate_move_phantom(bom_line, line_data['qty'], 0)
            //     # delete the move with original product which is not relevant anymore
            //     moves_ids_to_unlink.add(move.id)
            // 
            // if phantom_moves_vals_list:
            //     phantom_moves = self.env['stock.move'].create(phantom_moves_vals_list)
            //     phantom_moves._adjust_procure_method()
            //     moves_ids_to_return |= phantom_moves.action_explode().ids
            // move_to_unlink = self.env['stock.move'].browse(moves_ids_to_unlink).sudo()
            // move_to_unlink.quantity = 0
            // move_to_unlink._action_cancel()
            // move_to_unlink.unlink()
            // return self.env['stock.move'].browse(moves_ids_to_return)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> FilterAngloSaxonMovesInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _filter_anglo_saxon_moves(self, product):
            // res = super(StockMove, self)._filter_anglo_saxon_moves(product)
            // res += self.filtered(lambda m: m.bom_line_id.bom_id.product_tmpl_id.id == product.product_tmpl_id.id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _filter_anglo_saxon_moves(self, product):
            // return self.filtered(lambda m: m.product_id.id == product.id)
            */
            return default;
        }

        public async Task<StockMove> GenerateLotLineValsAsync(Guid id, StockMoveGenerateLotLineValsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_generate_lot_line_vals(self, context, mode, first_lot, count, lot_text):
            // if not context.get('default_product_id'):
            //     raise UserError(_("No product found to generate Serials/Lots for."))
            // assert mode in ('generate', 'import')
            // default_vals = {}
            // 
            // def generate_lot_qty(quantity, qty_per_lot):
            //     if qty_per_lot <= 0:
            //         raise UserError(_("The quantity per lot should always be a positive value."))
            //     line_count = int(quantity // qty_per_lot)
            //     leftover = quantity % qty_per_lot
            //     qty_array = [qty_per_lot] * line_count
            //     if leftover:
            //         qty_array.append(leftover)
            //     return qty_array
            // 
            // # Get default values
            // def remove_prefix(text, prefix):
            //     if text.startswith(prefix):
            //         return text[len(prefix):]
            //     return text
            // for key in context:
            //     if key.startswith('default_'):
            //         default_vals[remove_prefix(key, 'default_')] = context[key]
            // 
            // if default_vals['tracking'] == 'lot' and mode == 'generate':
            //     lot_qties = generate_lot_qty(default_vals['quantity'], count)
            // else:
            //     lot_qties = [1] * count
            // 
            // if mode == 'generate':
            //     lot_names = self.env['stock.lot'].generate_lot_names(first_lot, len(lot_qties))
            // elif mode == 'import':
            //     lot_names = self.split_lots(lot_text)
            //     lot_qties = [1] * len(lot_names)
            // 
            // vals_list = []
            // for lot, qty in zip(lot_names, lot_qties):
            //     if not lot.get('quantity'):
            //         lot['quantity'] = qty
            //     loc_dest = self.env['stock.location'].browse(default_vals['location_dest_id'])
            //     product = self.env['product.product'].browse(default_vals['product_id'])
            //     loc_dest = loc_dest._get_putaway_strategy(product, lot['quantity'])
            //     vals_list.append({**default_vals,
            //                      **lot,
            //                      'location_dest_id': loc_dest.id,
            //                      'product_uom_id': product.uom_id.id,
            //                     })
            // if default_vals.get('picking_type_id'):
            //     picking_type = self.env['stock.picking.type'].browse(default_vals['picking_type_id'])
            //     if picking_type.use_existing_lots:
            //         self._create_lot_ids_from_move_line_vals(
            //             vals_list, default_vals['product_id'], default_vals['company_id']
            //         )
            // # format many2one values for webclient, id + display_name
            // for values in vals_list:
            //     for key, value in values.items():
            //         if key in self.env['stock.move.line'] and isinstance(self.env['stock.move.line'][key], models.Model):
            //             values[key] = {
            //                 'id': value,
            //                 'display_name': self.env['stock.move.line'][key].browse(value).display_name
            //             }
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> GenerateMovePhantomInternalAsync(object bom_line, object product_qty, object quantity_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _generate_move_phantom(self, bom_line, product_qty, quantity_done):
            // vals = []
            // if bom_line.product_id.type == 'consu':
            //     vals = self.copy_data(default=self._prepare_phantom_move_values(bom_line, product_qty, quantity_done))
            //     if self.state == 'assigned':
            //         for v in vals:
            //             v['state'] = 'assigned'
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> GenerateSerialMoveLineCommandsInternalAsync(object field_data, Guid location_dest_id, object origin_move_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def _generate_serial_move_line_commands(self, field_data, location_dest_id=False, origin_move_line=None):
            // """Override to add a default `expiration_date` into the move lines values."""
            // move_lines_commands = super()._generate_serial_move_line_commands(field_data, location_dest_id, origin_move_line)
            // if self.product_id.use_expiration_date:
            //     date = fields.Datetime.today() + datetime.timedelta(days=self.product_id.expiration_time)
            //     for move_line_command in move_lines_commands:
            //         move_line_vals = move_line_command[2]
            //         if 'expiration_date' not in move_line_vals:
            //             move_line_vals['expiration_date'] = date
            // return move_lines_commands
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _generate_serial_move_line_commands(self, field_data, location_dest_id=False, origin_move_line=None):
            // """Return a list of commands to update the move lines (write on
            // existing ones or create new ones).
            // Called when user want to create and assign multiple serial numbers in
            // one time (using the button/wizard or copy-paste a list in the field).
            // 
            // :param field_data: A list containing dict with at least `lot_name` and `quantity`
            // :type field_data: list
            // :param origin_move_line: A move line to duplicate the value from, empty record by default
            // :type origin_move_line: record of :class:`stock.move.line`
            // :return: A list of commands to create/update :class:`stock.move.line`
            // :rtype: list
            // """
            // self.ensure_one()
            // origin_move_line = origin_move_line or self.env['stock.move.line']
            // loc_dest = origin_move_line.location_dest_id or location_dest_id
            // move_line_vals = {
            //     'picking_id': self.picking_id.id,
            //     'location_id': self.location_id.id,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_id.uom_id.id,
            // }
            // # Select the right move lines depending of the picking type's configuration.
            // move_lines = self.move_line_ids.filtered(lambda ml: not ml.lot_id and not ml.lot_name)
            // 
            // if origin_move_line:
            //     # Copies `owner_id` and `package_id` if new move lines are created from an existing one.
            //     move_line_vals.update({
            //         'owner_id': origin_move_line.owner_id.id,
            //         'package_id': origin_move_line.package_id.id,
            //     })
            // 
            // move_lines_commands = []
            // qty_by_location = defaultdict(float)
            // for command_vals in field_data:
            //     quantity = command_vals['quantity']
            //     # We write the lot name on an existing move line (if we have still one)...
            //     if move_lines:
            //         move_lines_commands.append(Command.update(move_lines[0].id, command_vals))
            //         qty_by_location[move_lines[0].location_dest_id.id] += quantity
            //         move_lines = move_lines[1:]
            //     # ... or create a new move line with the serial name.
            //     else:
            //         loc = loc_dest or self.location_dest_id._get_putaway_strategy(self.product_id, quantity=quantity, packaging=self.product_packaging_id, additional_qty=qty_by_location)
            //         new_move_line_vals = {
            //             **move_line_vals,
            //             **command_vals,
            //             'location_dest_id': loc.id
            //         }
            //         move_lines_commands.append(Command.create(new_move_line_vals))
            //         qty_by_location[loc.id] += quantity
            // return move_lines_commands
            */
            return default;
        }

        protected async Task<StockMove> GenerateSerialNumbersInternalAsync(object next_serial, object next_serial_count, Guid location_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _generate_serial_numbers(self, next_serial, next_serial_count=False, location_id=False):
            // """ This method will generate `lot_name` from a string (field
            // `next_serial`) and create a move line for each generated `lot_name`.
            // """
            // self.ensure_one()
            // if not location_id:
            //     location_id = self.location_dest_id
            // count = next_serial_count or self.next_serial_count
            // if not count:
            //     raise ValidationError(_("The number of Serial Numbers to generate must be greater than zero."))
            // lot_names = self.env['stock.lot'].generate_lot_names(next_serial, count)
            // field_data = [{'lot_name': lot_name['lot_name'], 'quantity': 1} for lot_name in lot_names]
            // if self.picking_type_id.use_existing_lots:
            //     self._create_lot_ids_from_move_line_vals(field_data, self.product_id.id, self.company_id.id)
            // move_lines_commands = self._generate_serial_move_line_commands(field_data)
            // self.move_line_ids = move_lines_commands
            // return True
            */
            return default;
        }

        protected async Task<StockMove> GenerateValuationLinesDataInternalAsync(Guid partner_id, object qty, object debit_value, object credit_value, Guid debit_account_id, Guid credit_account_id, Guid svl_id, object description)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: stock_move.py) ---
            // def _generate_valuation_lines_data(self, partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description):
            // rslt = super()._generate_valuation_lines_data(partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description)
            // 
            // subcontract_production = self.production_id.filtered(lambda p: p.subcontractor_id)
            // rounding = self.product_id.uom_id.rounding
            // if not subcontract_production or float_compare(qty, 0, precision_rounding=rounding) < 0:
            //     return rslt
            // # split the credit line to two, one for component cost, one for subcontracting service cost
            // currency = self.company_id.currency_id
            // if self.product_id.cost_method == 'standard':
            //     # In case of standard price, the component cost is the cost of the product
            //     # the subcontracting service cost may not represent the real cost of the subcontracting service
            //     # the difference should be posted in price difference account in the end
            //     component_cost = abs(currency.round(sum(subcontract_production.move_raw_ids.stock_valuation_layer_ids.mapped('value'))))
            //     subcontract_service_cost = credit_value - component_cost
            // else:
            //     subcontract_service_cost = currency.round(subcontract_production.extra_cost * qty)
            //     component_cost = credit_value - subcontract_service_cost
            // if not currency.is_zero(subcontract_service_cost):
            //     del rslt['credit_line_vals']
            //     service_cost_account = self.product_id.product_tmpl_id.get_product_accounts()['stock_input']
            //     rslt['subcontract_credit_line_vals'] = {
            //         'name': description,
            //         'product_id': self.product_id.id,
            //         'quantity': qty,
            //         'product_uom_id': self.product_id.uom_id.id,
            //         'ref': description,
            //         'partner_id': partner_id,
            //         'balance': -subcontract_service_cost,
            //         'account_id': service_cost_account.id,
            //     }
            //     rslt['component_credit_line_vals'] = {
            //         'name': description,
            //         'product_id': self.product_id.id,
            //         'quantity': qty,
            //         'product_uom_id': self.product_id.uom_id.id,
            //         'ref': description,
            //         'partner_id': partner_id,
            //         'balance': -component_cost,
            //         'account_id': credit_account_id,
            //     }
            // # if svl passed is not linked to the move in self, the valuation is a correction and should always credit the
            // # `stock_input` account as it adds directly to the value of the subcontracted product
            // elif svl_id and self.stock_valuation_layer_ids.ids and svl_id not in self.stock_valuation_layer_ids.ids:
            //     rslt['credit_line_vals']['account_id'] = self.product_id.product_tmpl_id.get_product_accounts()['stock_input'].id
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _generate_valuation_lines_data(self, partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description):
            // """ Overridden from stock_account to support amount_currency on valuation lines generated from po
            // """
            // self.ensure_one()
            // 
            // rslt = super(StockMove, self)._generate_valuation_lines_data(partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description)
            // purchase_currency = self.purchase_line_id.currency_id
            // company_currency = self.company_id.currency_id
            // if not self.purchase_line_id or purchase_currency == company_currency:
            //     return rslt
            // svl = self.env['stock.valuation.layer'].browse(svl_id)
            // if not svl.account_move_line_id:
            //     convert_date = self._get_currency_convert_date()
            //     rslt['credit_line_vals']['amount_currency'] = company_currency._convert(
            //         rslt['credit_line_vals']['balance'],
            //         purchase_currency,
            //         self.company_id,
            //         convert_date
            //     )
            //     rslt['debit_line_vals']['amount_currency'] = company_currency._convert(
            //         rslt['debit_line_vals']['balance'],
            //         purchase_currency,
            //         self.company_id,
            //         convert_date
            //     )
            //     rslt['debit_line_vals']['currency_id'] = purchase_currency.id
            //     rslt['credit_line_vals']['currency_id'] = purchase_currency.id
            // else:
            //     rslt['credit_line_vals']['amount_currency'] = 0
            //     rslt['debit_line_vals']['amount_currency'] = 0
            //     rslt['debit_line_vals']['currency_id'] = purchase_currency.id
            //     rslt['credit_line_vals']['currency_id'] = purchase_currency.id
            //     if not svl.price_diff_value:
            //         return rslt
            //     # The idea is to force using the company currency during the reconciliation process
            //     rslt['debit_line_vals_curr'] = {
            //         'name': _("Currency exchange rate difference"),
            //         'product_id': self.product_id.id,
            //         'quantity': 0,
            //         'product_uom_id': self.product_id.uom_id.id,
            //         'partner_id': partner_id,
            //         'balance': 0,
            //         'account_id': debit_account_id,
            //         'currency_id': purchase_currency.id,
            //         'amount_currency': -svl.price_diff_value,
            //     }
            //     rslt['credit_line_vals_curr'] = {
            //         'name': _("Currency exchange rate difference"),
            //         'product_id': self.product_id.id,
            //         'quantity': 0,
            //         'product_uom_id': self.product_id.uom_id.id,
            //         'partner_id': partner_id,
            //         'balance': 0,
            //         'account_id': credit_account_id,
            //         'currency_id': purchase_currency.id,
            //         'amount_currency': svl.price_diff_value,
            //     }
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _generate_valuation_lines_data(self, partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description):
            // # This method returns a dictionary to provide an easy extension hook to modify the valuation lines (see purchase for an example)
            // self.ensure_one()
            // 
            // line_vals = {
            //     'name': description,
            //     'product_id': self.product_id.id,
            //     'quantity': qty,
            //     'product_uom_id': self.product_id.uom_id.id,
            //     'ref': description,
            //     'partner_id': partner_id,
            // }
            // 
            // svl = self.env['stock.valuation.layer'].browse(svl_id)
            // if svl.account_move_line_id.analytic_distribution:
            //     line_vals['analytic_distribution'] = svl.account_move_line_id.analytic_distribution
            // 
            // rslt = {
            //     'credit_line_vals': {
            //         **line_vals,
            //         'balance': -credit_value,
            //         'account_id': credit_account_id,
            //     },
            //     'debit_line_vals': {
            //         **line_vals,
            //         'balance': debit_value,
            //         'account_id': debit_account_id,
            //     },
            // }
            // 
            // if credit_value != debit_value:
            //     # for supplier returns of product in average costing method, in anglo saxon mode
            //     diff_amount = debit_value - credit_value
            //     price_diff_account = self.env.context.get('price_diff_account')
            //     if not price_diff_account:
            //         raise UserError(_('Configuration error. Please configure the price difference account on the product or its category to process this operation.'))
            // 
            //     rslt['price_diff_line_vals'] = {
            //         'name': self.name,
            //         'product_id': self.product_id.id,
            //         'quantity': qty,
            //         'product_uom_id': self.product_id.uom_id.id,
            //         'balance': -diff_amount,
            //         'ref': description,
            //         'partner_id': partner_id,
            //         'account_id': price_diff_account.id,
            //     }
            // return rslt
            */
            return default;
        }

        public async Task<StockMove> GetAccountMovesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def action_get_account_moves(self):
            // self.ensure_one()
            // action_data = self.env['ir.actions.act_window']._for_xml_id('account.action_move_journal_line')
            // action_data['domain'] = [('id', 'in', self.account_move_ids.ids)]
            // return action_data
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> GetAccountingDataForValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_accounting_data_for_valuation(self):
            // """ Return the accounts and journal to use to post Journal Entries for
            // the real-time valuation of the quant. """
            // self.ensure_one()
            // self = self.with_company(self.company_id)
            // accounts_data = self.product_id.product_tmpl_id.get_product_accounts()
            // 
            // acc_src = self._get_src_account(accounts_data)
            // acc_dest = self._get_dest_account(accounts_data)
            // 
            // acc_valuation = accounts_data.get('stock_valuation', False)
            // if acc_valuation:
            //     acc_valuation = acc_valuation.id
            // if not accounts_data.get('stock_journal', False):
            //     raise UserError(_('You don\'t have any stock journal defined on your product category, check if you have installed a chart of accounts.'))
            // if not acc_src:
            //     raise UserError(_('Cannot find a stock input account for the product %s. You must define one on the product category, or on the location, before processing this operation.', self.product_id.display_name))
            // if not acc_dest:
            //     raise UserError(_('Cannot find a stock output account for the product %s. You must define one on the product category, or on the location, before processing this operation.', self.product_id.display_name))
            // if not acc_valuation:
            //     raise UserError(_('You don\'t have any stock valuation account defined on your product category. You must define one before processing this operation.'))
            // journal_id = accounts_data['stock_journal'].id
            // return journal_id, acc_src, acc_dest, acc_valuation
            */
            return default;
        }

        protected async Task<StockMove> GetAllRelatedAmlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_all_related_aml(self):
            // # The back and for between account_move and account_move_line is necessary to catch the
            // # additional lines from a cogs correction
            // return super()._get_all_related_aml() | self.purchase_line_id.invoice_lines.move_id.line_ids.filtered(
            //     lambda aml: aml.product_id == self.purchase_line_id.product_id)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_all_related_aml(self):
            // return self.account_move_ids.line_ids
            */
            return default;
        }

        protected async Task<StockMove> GetAllRelatedSmInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_all_related_sm(self, product):
            // moves = super()._get_all_related_sm(product)
            // return moves | self.filtered(
            //     lambda m:
            //     m.bom_line_id.bom_id.type == 'phantom' and
            //     m.bom_line_id.bom_id == moves.bom_line_id.bom_id
            // )
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_all_related_sm(self, product):
            // return super()._get_all_related_sm(product) | self.filtered(lambda m: m.purchase_line_id.product_id == product)
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _get_all_related_sm(self, product):
            // return super()._get_all_related_sm(product) | self.filtered(lambda m: m.sale_line_id.product_id == product)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_all_related_sm(self, product):
            // return self.filtered(lambda m: m.product_id == product)
            */
            return default;
        }

        protected async Task<StockMove> GetAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py) ---
            // def _get_analytic_distribution(self):
            // distribution = self.raw_material_production_id.project_id._get_analytic_distribution()
            // return distribution or super()._get_analytic_distribution()
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py) ---
            // def _get_analytic_distribution(self):
            // if not self.picking_type_id.analytic_costs:
            //     return super()._get_analytic_distribution()
            // distribution = self.picking_id.project_id._get_analytic_distribution()
            // return distribution or super()._get_analytic_distribution()
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_analytic_distribution(self):
            // return {}
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesInInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_available_move_lines_in(self):
            // move_lines_in = self.move_orig_ids.move_dest_ids.move_orig_ids.filtered(lambda m: m.state == 'done').mapped('move_line_ids')
            // 
            // def _keys_in_groupby(ml):
            //     return (ml.location_dest_id, ml.lot_id, ml.result_package_id, ml.owner_id)
            // 
            // grouped_move_lines_in = {}
            // for k, g in groupby(move_lines_in, key=_keys_in_groupby):
            //     quantity = 0
            //     for ml in g:
            //         quantity += ml.product_uom_id._compute_quantity(ml.quantity, ml.product_id.uom_id)
            //     grouped_move_lines_in[k] = quantity
            // 
            // return grouped_move_lines_in
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesInternalAsync(List<Guid> assigned_moves_ids, List<Guid> partially_available_moves_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _get_available_move_lines(self, assigned_moves_ids, partially_available_moves_ids):
            // return super(StockMove, self.filtered(lambda m: not m.is_subcontract))._get_available_move_lines(assigned_moves_ids, partially_available_moves_ids)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_available_move_lines(self, assigned_moves_ids, partially_available_moves_ids):
            // grouped_move_lines_in = self._get_available_move_lines_in()
            // grouped_move_lines_out = self._get_available_move_lines_out(assigned_moves_ids, partially_available_moves_ids)
            // available_move_lines = {key: grouped_move_lines_in[key] - grouped_move_lines_out.get(key, 0) for key in grouped_move_lines_in}
            // # pop key if the quantity available amount to 0
            // rounding = self.product_id.uom_id.rounding
            // return dict((k, v) for k, v in available_move_lines.items() if float_compare(v, 0, precision_rounding=rounding) > 0)
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesOutInternalAsync(List<Guid> assigned_moves_ids, List<Guid> partially_available_moves_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_available_move_lines_out(self, assigned_moves_ids, partially_available_moves_ids):
            // move_lines_out_done = (self.move_orig_ids.mapped('move_dest_ids') - self)\
            //     .filtered(lambda m: m.state in ['done'])\
            //     .mapped('move_line_ids')
            // # As we defer the write on the stock.move's state at the end of the loop, there
            // # could be moves to consider in what our siblings already took.
            // StockMove = self.env['stock.move']
            // moves_out_siblings = self.move_orig_ids.mapped('move_dest_ids') - self
            // moves_out_siblings_to_consider = moves_out_siblings & (StockMove.browse(assigned_moves_ids) + StockMove.browse(partially_available_moves_ids))
            // reserved_moves_out_siblings = moves_out_siblings.filtered(lambda m: m.state in ['partially_available', 'assigned'])
            // move_lines_out_reserved = (reserved_moves_out_siblings | moves_out_siblings_to_consider).mapped('move_line_ids')
            // 
            // def _keys_out_groupby(ml):
            //     return (ml.location_id, ml.lot_id, ml.package_id, ml.owner_id)
            // 
            // grouped_move_lines_out = {}
            // for k, g in groupby(move_lines_out_done, key=_keys_out_groupby):
            //     quantity = 0
            //     for ml in g:
            //         quantity += ml.product_uom_id._compute_quantity(ml.quantity, ml.product_id.uom_id)
            //     grouped_move_lines_out[k] = quantity
            // for k, g in groupby(move_lines_out_reserved, key=_keys_out_groupby):
            //     grouped_move_lines_out[k] = sum(self.env['stock.move.line'].concat(*list(g)).mapped('quantity_product_uom'))
            // 
            // return grouped_move_lines_out
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableQuantityInternalAsync(Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict, object allow_negative)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def _get_available_quantity(self, location_id, lot_id=None, package_id=None, owner_id=None, strict=False, allow_negative=False):
            // if self.product_id.use_expiration_date:
            //     return super(StockMove, self.with_context(with_expiration=self.date))._get_available_quantity(location_id, lot_id, package_id, owner_id, strict, allow_negative)
            // return super()._get_available_quantity(location_id, lot_id, package_id, owner_id, strict, allow_negative)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_available_quantity(self, location_id, lot_id=None, package_id=None, owner_id=None, strict=False, allow_negative=False):
            // self.ensure_one()
            // if location_id.should_bypass_reservation():
            //     return self.product_qty
            // return self.env['stock.quant']._get_available_quantity(self.product_id, location_id, lot_id=lot_id, package_id=package_id, owner_id=owner_id, strict=strict, allow_negative=allow_negative)
            */
            return default;
        }

        protected async Task<StockMove> GetBackorderMoveValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_backorder_move_vals(self):
            // self.ensure_one()
            // return {
            //     'state': 'draft' if self.state == 'draft' else 'confirmed',
            //     'reservation_date': self.reservation_date,
            //     'date_deadline': self.date_deadline,
            //     'manual_consumption': self._is_manual_consumption(),
            //     'move_orig_ids': [Command.link(m.id) for m in self.mapped('move_orig_ids')],
            //     'move_dest_ids': [Command.link(m.id) for m in self.mapped('move_dest_ids')],
            //     'procure_method': self.procure_method,
            // }
            */
            return default;
        }

        protected async Task<StockMove> GetCurrencyConvertDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_currency_convert_date(self):
            // self.ensure_one()
            // # The date must be today, and not the date of the move since the move move is still
            // # in assigned state. However, the move date is the scheduled date until move is
            // # done, then date of actual move processing. See:
            // # https://github.com/odoo/odoo/blob/2f789b6863407e63f90b3a2d4cc3be09815f7002/addons/stock/models/stock_move.py#L36
            // convert_date = fields.Date.context_today(self) if self.state != 'done' else self.date
            // line = self.purchase_line_id
            // if not line:
            //     return convert_date
            // 
            // # Use currency rate at bill date when invoice before receipt
            // qty_received = self._get_qty_received_without_self()
            // if float_compare(line.qty_invoiced, qty_received, precision_rounding=line.product_uom.rounding) > 0:
            //     posted_bills = line.sudo().invoice_lines.move_id.filtered(lambda m: m.state == 'posted')
            //     convert_date = max(posted_bills.mapped('invoice_date'), default=convert_date)
            // return convert_date
            */
            return default;
        }

        protected async Task<StockMove> GetDestAccountInternalAsync(object accounts_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_dest_account(self, accounts_data):
            // if self._is_production_consumed():
            //     return self.location_dest_id.valuation_in_account_id.id or accounts_data['production'].id or accounts_data['stock_output'].id
            // return super()._get_dest_account(accounts_data)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_dest_account(self, accounts_data):
            // if not self.location_dest_id.usage in ('production', 'inventory'):
            //     return accounts_data['stock_output'].id
            // else:
            //     return self.location_dest_id.valuation_in_account_id.id or accounts_data['stock_output'].id
            */
            return default;
        }

        protected async Task<StockMove> GetDropshippedSvlValsInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_dropshipped_svl_vals(self, forced_quantity):
            // svl_vals_list = []
            // for move in self:
            //     move = move.with_company(move.company_id)
            //     lines = move.move_line_ids
            //     quantities = defaultdict(float)
            //     if forced_quantity:
            //         quantities[forced_quantity[0]] += forced_quantity[1]
            //     elif move.product_id.lot_valuated:
            //         for line in lines:
            //             quantities[line.lot_id] += line.quantity_product_uom
            //     else:
            //         quantities[self.env['stock.lot']] += move.product_qty
            // 
            //     unit_cost = move._get_price_unit()
            //     if move.product_id.cost_method == 'standard':
            //         if move.product_id.lot_valuated:
            //             unit_cost = {lot: lot.standard_price for lot in quantities}
            //         else:
            //             unit_cost = {self.env['stock.lot']: move.product_id.standard_price}
            // 
            //     common_vals = dict(move._prepare_common_svl_vals(), remaining_qty=0)
            //     if forced_quantity:
            //         common_vals['description'] = _('Correction of %s (modification of past move)', move.picking_id.name or move.name)
            // 
            //     # create the in if it does not come from a valued location (eg subcontract -> customer)
            //     if not move.location_id._should_be_valued():
            //         svl_vals_list += [{
            //             'unit_cost': unit_cost[lot_id],
            //             'value': unit_cost[lot_id] * qty,
            //             'quantity': qty,
            //             'lot_id': lot_id and lot_id.id,
            //             **common_vals,
            //         } for lot_id, qty in quantities.items()]
            // 
            //     # create the out if it does not go to a valued location (eg customer -> subcontract)
            //     if not move.location_dest_id._should_be_valued():
            //         svl_vals_list += [{
            //             'unit_cost': unit_cost[lot_id],
            //             'value': unit_cost[lot_id] * qty * -1,
            //             'quantity': qty * -1,
            //             'lot_id': lot_id and lot_id.id,
            //             **common_vals,
            //         } for lot_id, qty in quantities.items()]
            // 
            // return svl_vals_list
            */
            return default;
        }

        protected async Task<StockMove> GetForecastAvailabilityOutgoingInternalAsync(object warehouse, Guid location_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_forecast_availability_outgoing(self, warehouse, location_id=False):
            // """ Get forcasted information (sum_qty_expected, max_date_expected) of self for the warehouse's locations.
            // :param warehouse: warehouse to search under
            // :param  location_id: location source of outgoing moves
            // :return: a defaultdict of outgoing moves from warehouse for product_id in self, values are tuple (sum_qty_expected, max_date_expected)
            // :rtype: defaultdict
            // """
            // wh_location_query = self.env['stock.location']._search([('id', 'child_of', warehouse.view_location_id.id)])
            // forecast_lines = self.env['stock.forecasted_product_product']._get_report_lines(False, self.product_id.ids, wh_location_query, location_id or warehouse.lot_stock_id, read=False)
            // result = defaultdict(lambda: (0.0, False))
            // for line in forecast_lines:
            //     move_out = line.get('move_out')
            //     if not move_out or not line['quantity']:
            //         continue
            //     move_in = line.get('move_in')
            //     qty_expected = line['quantity'] + result[move_out][0] if line['replenishment_filled'] else -line['quantity']
            //     date_expected = False
            //     if move_in:
            //         date_expected = max(move_in.date, result[move_out][1]) if result[move_out][1] else move_in.date
            //     result[move_out] = (qty_expected, date_expected)
            // 
            // return result
            */
            return default;
        }

        protected async Task<StockMove> GetFormatingOptionsInternalAsync(object strings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def _get_formating_options(self, strings):
            // options = super()._get_formating_options(strings)
            // separators = "-/ "
            // date_regex = f'[^{separators}]+'
            // for string in strings:
            //     # Searches for a date.
            //     date_data = re_findall(date_regex, string)
            //     if len(date_data) < 2:  # Not enough data.
            //         continue
            //     value_1, value_2 = date_data[:2]
            //     if re_findall('[a-zA-Z]', value_1):
            //         # Assumes the first value is the mounth (written in letters). Don't add any option
            //         # as mounth as the first date's value is the default behavior for `dateutil.parse`.
            //         break
            //     # Try to guess if the first data is the day or the year.
            //     if int(value_1) > 31:
            //         options['yearfirst'] = True
            //         break
            //     elif int(value_1) > 12 and (re_findall('[a-zA-Z]', value_2) or int(value_2) <= 12):
            //         options['dayfirst'] = True
            //         break
            //     else:  # Too ambiguous, gets the option from the user's lang's date setting.
            //         user_lang_format = get_lang(self.env).date_format
            //         if re_findall('^%[mbB]', user_lang_format):  # First parameter is for month.
            //             return options
            //         elif re_findall('^%[djaA]', user_lang_format):  # First parameter is for day.
            //             options['dayfirst'] = True
            //             break
            //         elif re_findall('^%[yY]', user_lang_format):  # First parameter is for year.
            //             options['yearfirst'] = True
            //             break
            // return options
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_formating_options(self, strings):
            // return {}
            */
            return default;
        }

        protected async Task<StockMove> GetInMoveLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_in_move_lines(self):
            // """ Returns the `stock.move.line` records of `self` considered as incoming. It is done thanks
            // to the `_should_be_valued` method of their source and destionation location as well as their
            // owner.
            // 
            // :returns: a subset of `self` containing the incoming records
            // :rtype: recordset
            // """
            // self.ensure_one()
            // res = OrderedSet()
            // for move_line in self.move_line_ids:
            //     if not move_line.picked:
            //         continue
            //     if move_line._should_exclude_for_valuation():
            //         continue
            //     if not move_line.location_id._should_be_valued() and move_line.location_dest_id._should_be_valued():
            //         res.add(move_line.id)
            // return self.env['stock.move.line'].browse(res)
            */
            return default;
        }

        protected async Task<StockMove> GetInSvlValsInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_in_svl_vals(self, forced_quantity):
            // svl_vals_list = []
            // for move in self:
            //     move = move.with_company(move.company_id)
            //     lines = move._get_in_move_lines()
            //     quantities = defaultdict(float)
            //     if forced_quantity:
            //         quantities[forced_quantity[0]] += forced_quantity[1]
            //     else:
            //         for line in lines:
            //             quantities[line.lot_id] += line.quantity_product_uom
            //     if move.product_id.lot_valuated:
            //         unit_cost = {lot: lot.standard_price for lot in move.lot_ids}
            //     else:
            //         unit_cost = {self.env['stock.lot']: move.product_id.standard_price}
            //     if move.product_id.cost_method != 'standard':
            //         unit_cost = move._get_price_unit()  # May be negative (i.e. decrease an out move).
            //     if move.product_id.lot_valuated:
            //         vals = []
            //         for lot_id, qty in quantities.items():
            //             vals.append(move.product_id._prepare_in_svl_vals(qty, abs(unit_cost[lot_id]), lot=lot_id))
            //     else:
            //         vals = [move.product_id._prepare_in_svl_vals(sum(quantities.values()), abs(unit_cost[self.env['stock.lot']]))]
            //     for val in vals:
            //         val.update(move._prepare_common_svl_vals())
            //         if forced_quantity:
            //             val['description'] = _('Correction of %s (modification of past move)', move.picking_id.name or move.name)
            //     svl_vals_list += vals
            // return svl_vals_list
            */
            return default;
        }

        protected async Task<StockMove> GetLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_lang(self):
            // """Determine language to use for translated description"""
            // return self.picking_id.partner_id.lang or self.partner_id.lang or self.env.user.lang
            */
            return default;
        }

        protected async Task<StockMove> GetLayerCandidatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_layer_candidates(self):
            // self.ensure_one()
            // return self.stock_valuation_layer_ids
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_layer_candidates(self):
            // layer_candidates = super()._get_layer_candidates()
            // if self._is_dropshipped():
            //     layer_candidates = layer_candidates.filtered(lambda svl: svl.quantity < 0)
            // elif self._is_dropshipped_returned():
            //     layer_candidates = layer_candidates.filtered(lambda svl: svl.quantity > 0)
            // return layer_candidates
            */
            return default;
        }

        protected async Task<StockMove> GetMoveDirectionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_move_directions(self):
            // move_in_ids = set()
            // move_out_ids = set()
            // locations_should_be_valued = (self.move_line_ids.location_id | self.move_line_ids.location_dest_id).filtered(lambda l: l._should_be_valued())
            // for record in self:
            //     for move_line in record.move_line_ids:
            //         if move_line._should_exclude_for_valuation() or not move_line.picked:
            //             continue
            //         if move_line.location_id not in locations_should_be_valued and move_line.location_dest_id in locations_should_be_valued:
            //             move_in_ids.add(record.id)
            //         if move_line.location_id in locations_should_be_valued and move_line.location_dest_id not in locations_should_be_valued:
            //             move_out_ids.add(record.id)
            // 
            // move_directions = defaultdict(set)
            // for record in self:
            //     if record.id in move_in_ids and not record._is_dropshipped_returned():
            //         move_directions[record.id].add('in')
            // 
            //     if record.id in move_out_ids and not record._is_dropshipped():
            //         move_directions[record.id].add('out')
            // 
            // return move_directions
            */
            return default;
        }

        protected async Task<StockMove> GetMovesToPropagateDateDeadlineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_moves_to_propagate_date_deadline(self):
            // res = super()._get_moves_to_propagate_date_deadline()
            // if self.production_id:
            //     res |= self.production_id.move_finished_ids - self
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_moves_to_propagate_date_deadline(self):
            // self.ensure_one()
            // return self.move_dest_ids | self.move_orig_ids
            */
            return default;
        }

        protected async Task<StockMove> GetMtoProcurementDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_mto_procurement_date(self):
            // return self.date
            */
            return default;
        }

        protected async Task<StockMove> GetNewPickingValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _get_new_picking_values(self):
            // vals = super(StockMove, self)._get_new_picking_values()
            // vals['pos_session_id'] = self.mapped('group_id.pos_order_id.session_id').id
            // vals['pos_order_id'] = self.mapped('group_id.pos_order_id').id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py) ---
            // def _get_new_picking_values(self):
            // return {
            //     **super()._get_new_picking_values(),
            //     'project_id': self.sale_line_id.order_id.project_id.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_new_picking_values(self):
            // """ return create values for new picking that will be linked with group
            // of moves in self.
            // """
            // origins = self.filtered(lambda m: m.origin).mapped('origin')
            // origins = list(dict.fromkeys(origins)) # create a list of unique items
            // # Will display source document if any, when multiple different origins
            // # are found display a maximum of 5
            // if len(origins) == 0:
            //     origin = False
            // else:
            //     origin = ','.join(origins[:5])
            //     if len(origins) > 5:
            //         origin += "..."
            // partners = self.mapped('partner_id')
            // partner = len(partners) == 1 and partners.id or False
            // vals = {
            //     'origin': origin,
            //     'company_id': self.mapped('company_id').id,
            //     'user_id': False,
            //     'group_id': self.mapped('group_id').id,
            //     'partner_id': partner,
            //     'picking_type_id': self.mapped('picking_type_id').id,
            //     'location_id': self.mapped('location_id').id,
            // }
            // if self.location_dest_id.ids:
            //     vals['location_dest_id'] = self.location_dest_id.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _get_new_picking_values(self):
            // vals = super(StockMove, self)._get_new_picking_values()
            // carrier_id = self.group_id.sale_id.carrier_id.id
            // vals['carrier_id'] = any(rule.propagate_carrier for rule in self.rule_id) and carrier_id
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> GetOutMoveLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_out_move_lines(self):
            // """ Returns the `stock.move.line` records of `self` considered as outgoing. It is done thanks
            // to the `_should_be_valued` method of their source and destionation location as well as their
            // owner.
            // 
            // :returns: a subset of `self` containing the outgoing records
            // :rtype: recordset
            // """
            // res = self.env['stock.move.line']
            // for move_line in self.move_line_ids:
            //     if not move_line.picked:
            //         continue
            //     if move_line._should_exclude_for_valuation():
            //         continue
            //     if move_line.location_id._should_be_valued() and not move_line.location_dest_id._should_be_valued():
            //         res |= move_line
            // return res
            */
            return default;
        }

        protected async Task<StockMove> GetOutSvlValsInternalAsync(object forced_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_out_svl_vals(self, forced_quantity):
            // unbuild_moves = self.filtered('unbuild_id')
            // # 'real cost' of finished product moves @ build time
            // price_unit_map = {
            //     move.id: (
            //         (move.unbuild_id.mo_id.move_finished_ids |
            //         move.unbuild_id.mo_id.move_raw_ids).stock_valuation_layer_ids.filtered(
            //             lambda svl: svl.product_id == move.product_id
            //         )[0].unit_cost,
            //         move.company_id.currency_id.round,
            //     )
            //     for move in unbuild_moves.sudo()
            //     if move.product_id.cost_method != 'standard' and
            //     move.unbuild_id.mo_id.move_finished_ids.stock_valuation_layer_ids
            // }
            // svl_vals_list = super()._get_out_svl_vals(forced_quantity)
            // if price_unit_map:
            //     for svl_vals in svl_vals_list:
            //         if (move_id := svl_vals['stock_move_id']) in price_unit_map:
            //             unit_cost = price_unit_map[move_id][0]
            //             svl_vals.update({
            //                 'unit_cost': unit_cost,
            //                 'value': price_unit_map[move_id][1](unit_cost * svl_vals['quantity']),
            //             })
            // return svl_vals_list
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_out_svl_vals(self, forced_quantity):
            // svl_vals_list = []
            // for move in self:
            //     move = move.with_company(move.company_id)
            //     lines = move._get_out_move_lines()
            //     quantities = defaultdict(float)
            //     if forced_quantity:
            //         quantities[forced_quantity[0]] += forced_quantity[1]
            //     else:
            //         for line in lines:
            //             quantities[line.lot_id] += line.quantity_product_uom
            //     if float_is_zero(sum(quantities.values()), precision_rounding=move.product_id.uom_id.rounding):
            //         continue
            // 
            //     if move.product_id.lot_valuated:
            //         vals = []
            //         for lot_id, qty in quantities.items():
            //             out_vals = move.product_id._prepare_out_svl_vals(
            //                 qty,
            //                 move.company_id,
            //                 lot=lot_id
            //             )
            //             vals.append(out_vals)
            //     else:
            //         vals = [move.product_id._prepare_out_svl_vals(sum(quantities.values()), move.company_id)]
            //     for val in vals:
            //         val.update(move._prepare_common_svl_vals())
            //         if forced_quantity:
            //             val['description'] = _('Correction of %s (modification of past move)', move.picking_id.name or move.name)
            //         val['description'] += val.pop('rounding_adjustment', '')
            //     svl_vals_list += vals
            // return svl_vals_list
            */
            return default;
        }

        protected async Task<StockMove> GetPartnerIdForValuationLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_partner_id_for_valuation_lines(self):
            // return (self.picking_id.partner_id and self.env['res.partner']._find_accounting_partner(self.picking_id.partner_id).id) or False
            */
            return default;
        }

        protected async Task<StockMove> GetPickedQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_picked_quantity(self):
            // self.ensure_one()
            // if self.picked and any(not ml.picked for ml in self.move_line_ids):
            //     picked_qty = 0
            //     for ml in self.move_line_ids:
            //         if not ml.picked:
            //             continue
            //         picked_qty += ml.product_uom_id._compute_quantity(ml.quantity, self.product_uom, round=False)
            //     return picked_qty
            // else:
            //     return self.quantity
            */
            return default;
        }

        protected async Task<StockMove> GetPriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py) ---
            // def _get_price_unit(self):
            // if self.product_id == self.purchase_line_id.product_id or not self.bom_line_id or self._should_ignore_pol_price():
            //     return super()._get_price_unit()
            // line = self.purchase_line_id
            // # price_unit here with uom of product
            // kit_price_unit = line._get_gross_price_unit()
            // bom_line = self.bom_line_id
            // bom = bom_line.bom_id
            // if line.currency_id != self.company_id.currency_id:
            //     kit_price_unit = line.currency_id._convert(kit_price_unit, self.company_id.currency_id, self.company_id, fields.Date.context_today(self), round=False)
            // cost_share = self.bom_line_id._get_cost_share()
            // uom_factor = 1.0
            // kit_product = bom.product_id or bom.product_tmpl_id
            // 
            // # Convert uom from product_uom to bom_uom for kit product
            // uom_factor = bom.product_uom_id._compute_quantity(uom_factor, kit_product.uom_id)
            // 
            // # Convert uom from bom_line_uom to product_uom for bom_line
            // uom_factor = bom_line.product_id.uom_id._compute_quantity(uom_factor, bom_line.product_uom_id)
            // 
            // price_unit = kit_price_unit * cost_share * uom_factor * bom.product_qty / bom_line.product_qty
            // if self.product_id.lot_valuated:
            //     return {lot: price_unit for lot in self.lot_ids}
            // else:
            //     return {self.env['stock.lot']: price_unit}
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_price_unit(self):
            // """ Returns the unit price for the move"""
            // self.ensure_one()
            // if self._should_ignore_pol_price():
            //     return super(StockMove, self)._get_price_unit()
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // line = self.purchase_line_id
            // order = line.order_id
            // received_qty = self._get_qty_received_without_self()
            // if line.product_id.purchase_method == 'purchase' and float_compare(line.qty_invoiced, received_qty, precision_rounding=line.product_uom.rounding) > 0:
            //     move_layer = line.move_ids.sudo().stock_valuation_layer_ids
            //     invoiced_layer = line.sudo().invoice_lines.stock_valuation_layer_ids
            //     # value on valuation layer is in company's currency, while value on invoice line is in order's currency
            //     receipt_value = 0
            //     for layer in move_layer:
            //         if not layer._should_impact_price_unit_receipt_value():
            //             continue
            //         receipt_value += layer.currency_id._convert(
            //             layer.value, order.currency_id, order.company_id, layer.create_date, round=False)
            //     if invoiced_layer:
            //         receipt_value += sum(invoiced_layer.mapped(lambda l: l.currency_id._convert(
            //             l.value, order.currency_id, order.company_id, l.create_date, round=False)))
            //     total_invoiced_value = 0
            //     invoiced_qty = 0
            //     for invoice_line in line.sudo().invoice_lines:
            //         if invoice_line.move_id.state != 'posted':
            //             continue
            //         # Adjust unit price to account for discounts before adding taxes.
            //         adjusted_unit_price = invoice_line.price_unit * (1 - (invoice_line.discount / 100)) if invoice_line.discount else invoice_line.price_unit
            //         if invoice_line.tax_ids:
            //             invoice_line_value = invoice_line.tax_ids.compute_all(
            //                 adjusted_unit_price,
            //                 currency=invoice_line.currency_id,
            //                 quantity=invoice_line.quantity,
            //                 rounding_method="round_globally",
            //             )['total_void']
            //         else:
            //             invoice_line_value = adjusted_unit_price * invoice_line.quantity
            //         total_invoiced_value += invoice_line.currency_id._convert(
            //                 invoice_line_value, order.currency_id, order.company_id, invoice_line.move_id.invoice_date, round=False)
            //         invoiced_qty += invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_id.uom_id, rounding_method="HALF-UP")
            //     # TODO currency check
            //     remaining_value = total_invoiced_value - receipt_value
            //     # TODO qty_received in product uom
            //     remaining_qty = invoiced_qty - line.product_uom._compute_quantity(received_qty, line.product_id.uom_id, rounding_method="HALF-UP")
            //     has_remaining = (
            //         not order.currency_id.is_zero(remaining_value)
            //         and not float_is_zero(remaining_qty, precision_rounding=line.product_id.uom_id.rounding)
            //     )
            //     if order.currency_id != order.company_id.currency_id and has_remaining:
            //         # will be rounded during currency conversion
            //         price_unit = remaining_value / remaining_qty
            //     elif has_remaining:
            //         price_unit = float_round(remaining_value / remaining_qty, precision_digits=price_unit_prec)
            //     else:
            //         price_unit = line._get_gross_price_unit()
            // else:
            //     price_unit = line._get_gross_price_unit()
            // if order.currency_id != order.company_id.currency_id:
            //     convert_date = self._get_currency_convert_date()
            //     price_unit = order.currency_id._convert(
            //         price_unit, order.company_id.currency_id, order.company_id, convert_date, round=False)
            // if self.product_id.lot_valuated:
            //     return dict.fromkeys(self.lot_ids, price_unit)
            // return {self.env['stock.lot']: price_unit}
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_price_unit(self):
            // """ Returns the unit price to value this stock move """
            // self.ensure_one()
            // price_unit = self.price_unit
            // precision = self.env['decimal.precision'].precision_get('Product Price')
            // # If the move is a return, use the original move's price unit.
            // if self.origin_returned_move_id and self.origin_returned_move_id.sudo().stock_valuation_layer_ids:
            //     layers = self.origin_returned_move_id.sudo().stock_valuation_layer_ids
            //     # dropshipping create additional positive svl to make sure there is no impact on the stock valuation
            //     # We need to remove them from the computation of the price unit.
            //     if self.origin_returned_move_id._is_dropshipped() or self.origin_returned_move_id._is_dropshipped_returned():
            //         layers = layers.filtered(lambda l: float_compare(l.value, 0, precision_rounding=l.product_id.uom_id.rounding) <= 0)
            //     layers |= layers.stock_valuation_layer_ids
            //     if self.product_id.lot_valuated:
            //         layers_by_lot = layers.grouped('lot_id')
            //         prices = defaultdict(lambda: 0)
            //         for lot, stock_layers in layers_by_lot.items():
            //             qty = sum(stock_layers.mapped("quantity"))
            //             val = sum(stock_layers.mapped("value"))
            //             prices[lot] = val / qty if not float_is_zero(qty, precision_rounding=self.product_id.uom_id.rounding) else 0
            //     else:
            //         quantity = sum(layers.mapped("quantity"))
            //         prices = {self.env['stock.lot']: sum(layers.mapped("value")) / quantity if not float_is_zero(quantity, precision_rounding=layers.uom_id.rounding) else 0}
            //     return prices
            // 
            // if not float_is_zero(price_unit, precision) or self._should_force_price_unit():
            //     if self.product_id.lot_valuated:
            //         return dict.fromkeys(self.lot_ids, price_unit)
            //     else:
            //         return {self.env['stock.lot']: price_unit}
            // else:
            //     if self.product_id.lot_valuated:
            //         return {lot: lot.standard_price or self.product_id.with_company(self.company_id).standard_price for lot in self.lot_ids}
            //     else:
            //         return {self.env['stock.lot']: self.product_id.with_company(self.company_id).standard_price}
            */
            return default;
        }

        protected async Task<StockMove> GetProductCatalogLinesDataInternalAsync(object parent_record)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_product_catalog_lines_data(self, parent_record=False, **kwargs):
            // if not (parent_record and self):
            //     return {
            //         'quantity': 0,
            //     }
            // self.product_id.ensure_one()
            // return {
            //     **parent_record._get_product_price_and_data(self.product_id),
            //     'quantity': sum(
            //         self.mapped(
            //             lambda line: line.product_uom._compute_quantity(
            //                 qty=line.product_qty,
            //                 to_unit=line.product_uom,
            //             ),
            //         ),
            //     ),
            //     'readOnly': False,
            // }
            */
            return default;
        }

        protected async Task<StockMove> GetPurchaseLineAndPartnerFromChainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_purchase_line_and_partner_from_chain(self):
            // moves_to_check = deque(self)
            // seen_moves = set()
            // while moves_to_check:
            //     current_move = moves_to_check.popleft()
            //     if current_move.purchase_line_id:
            //         return current_move.purchase_line_id.id, current_move.picking_id.partner_id.id
            //     seen_moves.add(current_move)
            //     moves_to_check.extend(
            //         [move for move in current_move.move_orig_ids if move not in moves_to_check and move not in seen_moves]
            //     )
            // return None, None
            */
            return default;
        }

        protected async Task<StockMove> GetQtyReceivedWithoutSelfInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_qty_received_without_self(self):
            // qty_received = self.purchase_line_id.qty_received
            // if self.state == 'done':
            //     qty_received -= self.product_uom._compute_quantity(
            //         self.quantity, self.purchase_line_id.product_uom, rounding_method='HALF-UP'
            //     )
            // return qty_received
            */
            return default;
        }

        protected async Task<StockMove> GetRelatedInvoicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_related_invoices(self):
            // """ Overridden to return the vendor bills related to this stock move.
            // """
            // rslt = super(StockMove, self)._get_related_invoices()
            // purchase_ids = self.env['purchase.order'].search([('picking_ids', 'in', self.picking_id.ids)])
            // rslt += purchase_ids.invoice_ids.filtered(lambda x: x.state == 'posted')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _get_related_invoices(self):
            // """ Overridden from stock_account to return the customer invoices
            // related to this stock move.
            // """
            // rslt = super(StockMove, self)._get_related_invoices()
            // invoices = self.mapped('picking_id.sale_id.invoice_ids').filtered(lambda x: x.state == 'posted')
            // rslt += invoices
            // #rslt += invoices.mapped('reverse_entry_ids')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_related_invoices(self):  # To be overridden in purchase and sale_stock
            // """ This method is overrided in both purchase and sale_stock modules to adapt
            // to the way they mix stock moves with invoices.
            // """
            // return self.env['account.move']
            */
            return default;
        }

        protected async Task<StockMove> GetRelevantStateAmongMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_relevant_state_among_moves(self):
            // res = super()._get_relevant_state_among_moves()
            // if res == 'partially_available'\
            //         and self.raw_material_production_id\
            //         and all(move.should_consume_qty and float_compare(move.quantity, move.should_consume_qty, precision_rounding=move.product_uom.rounding) >= 0
            //                 or (float_compare(move.quantity, move.product_uom_qty, precision_rounding=move.product_uom.rounding) >= 0 or (move.manual_consumption and move.picked))
            //                 for move in self):
            //     res = 'assigned'
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_relevant_state_among_moves(self):
            // # We sort our moves by importance of state:
            // #     ------------- 0
            // #     | Assigned  |
            // #     -------------
            // #     |  Waiting  |
            // #     -------------
            // #     |  Partial  |
            // #     -------------
            // #     |  Confirm  |
            // #     ------------- len-1
            // sort_map = {
            //     'assigned': 4,
            //     'waiting': 3,
            //     'partially_available': 2,
            //     'confirmed': 1,
            // }
            // moves_todo = self\
            //     .filtered(lambda move: move.state not in ['cancel', 'done'] and not (move.state == 'assigned' and not move.product_uom_qty))\
            //     .sorted(key=lambda move: (sort_map.get(move.state, 0), move.product_uom_qty))
            // if not moves_todo:
            //     return 'assigned'
            // # The picking should be the same for all moves.
            // if moves_todo[:1].picking_id and moves_todo[:1].picking_id.move_type == 'one':
            //     if all(not m.product_uom_qty for m in moves_todo):
            //         return 'assigned'
            //     most_important_move = moves_todo[0]
            //     if most_important_move.state == 'confirmed':
            //         return 'confirmed'
            //     elif most_important_move.state == 'partially_available':
            //         return 'confirmed'
            //     else:
            //         return moves_todo[:1].state or 'draft'
            // elif moves_todo[:1].state != 'assigned' and any(move.state in ['assigned', 'partially_available'] for move in moves_todo):
            //     return 'partially_available'
            // else:
            //     least_important_move = moves_todo[-1:]
            //     if least_important_move.state == 'confirmed' and least_important_move.product_uom_qty == 0:
            //         return 'assigned'
            //     else:
            //         return moves_todo[-1:].state or 'draft'
            */
            return default;
        }

        protected async Task<StockMove> GetRepairLocationsInternalAsync(object repair_line_type, Guid repair_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _get_repair_locations(self, repair_line_type, repair_id=False):
            // location_map = MAP_REPAIR_LINE_TYPE_TO_MOVE_LOCATIONS_FROM_REPAIR.get(repair_line_type)
            // if location_map:
            //     if not repair_id:
            //         self.repair_id.ensure_one()
            //         repair_id = self.repair_id
            //     location_id, location_dest_id = [repair_id[field] for field in location_map.values()]
            // else:
            //     location_id, location_dest_id = False, False
            // return location_id, location_dest_id
            */
            return default;
        }

        protected async Task<StockMove> GetSaleOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _get_sale_order_lines(self):
            // """ Return all possible sale order lines for one stock move. """
            // self.ensure_one()
            // return (self + self.browse(self._rollup_move_origs() | self._rollup_move_dests())).sale_line_id
            */
            return default;
        }

        protected async Task<StockMove> GetSourceDocumentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_source_document(self):
            // res = super()._get_source_document()
            // return res or self.production_id or self.raw_material_production_id
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_source_document(self):
            // res = super()._get_source_document()
            // return self.purchase_line_id.order_id or res
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _get_source_document(self):
            // return self.repair_id or super()._get_source_document()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _get_source_document(self):
            // res = super()._get_source_document()
            // return self.sale_line_id.order_id or res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_source_document(self):
            // """ Return the move's document, used by `stock.forecasted_product_productt`
            // and must be overrided to add more document type in the report.
            // """
            // self.ensure_one()
            // return self.picking_id or False
            */
            return default;
        }

        protected async Task<StockMove> GetSrcAccountInternalAsync(object accounts_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_src_account(self, accounts_data):
            // if self._is_production():
            //     return self.location_id.valuation_out_account_id.id or accounts_data['production'].id or accounts_data['stock_input'].id
            // return super()._get_src_account(accounts_data)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_src_account(self, accounts_data):
            // return self.location_id.valuation_out_account_id.id or accounts_data['stock_input'].id
            */
            return default;
        }

        protected async Task<StockMove> GetStockValuationLayerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_landed_costs, FILE: stock_move.py) ---
            // def _get_stock_valuation_layer_ids(self):
            // self.ensure_one()
            // stock_valuation_layer_ids = super()._get_stock_valuation_layer_ids()
            // subcontracted_productions = self._get_subcontract_production()
            // if self.is_subcontract and subcontracted_productions:
            //     return subcontracted_productions.move_finished_ids.stock_valuation_layer_ids
            // return stock_valuation_layer_ids
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_move.py) ---
            // def _get_stock_valuation_layer_ids(self):
            // self.ensure_one()
            // return self.stock_valuation_layer_ids
            */
            return default;
        }

        protected async Task<StockMove> GetSubcontractBomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _get_subcontract_bom(self):
            // self.ensure_one()
            // bom = self.env['mrp.bom'].sudo()._bom_subcontract_find(
            //     self.product_id,
            //     picking_type=self.picking_type_id,
            //     company_id=self.company_id.id,
            //     bom_type='subcontract',
            //     subcontractor=self.picking_id.partner_id,
            // )
            // return bom
            */
            return default;
        }

        protected async Task<StockMove> GetSubcontractProductionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _get_subcontract_production(self):
            // return self.filtered(lambda m: m.is_subcontract).move_orig_ids.production_id
            */
            return default;
        }

        protected async Task<StockMove> GetUpstreamDocumentsAndResponsiblesInternalAsync(object visited)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // if self.production_id and self.production_id.state not in ('done', 'cancel'):
            //     return [(self.production_id, self.production_id.user_id, visited)]
            // else:
            //     return super(StockMove, self)._get_upstream_documents_and_responsibles(visited)
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // # People without purchase rights should be able to do this operation
            // requisition_lines_sudo = self.sudo().requisition_line_ids
            // if requisition_lines_sudo:
            //     return [(requisition_line.requisition_id, requisition_line.requisition_id.user_id, visited) for requisition_line in requisition_lines_sudo if requisition_line.requisition_id.state not in ('done', 'cancel')]
            // else:
            //     return super(StockMove, self)._get_upstream_documents_and_responsibles(visited)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // created_pl = self.created_purchase_line_ids.filtered(lambda cpl: cpl.state not in ('done', 'cancel') and (cpl.state != 'draft' or self._context.get('include_draft_documents')))
            // if created_pl:
            //     return [(pl.order_id, pl.order_id.user_id, visited) for pl in created_pl]
            // elif self.purchase_line_id and self.purchase_line_id.state not in ('done', 'cancel'):
            //     return[(self.purchase_line_id.order_id, self.purchase_line_id.order_id.user_id, visited)]
            // else:
            //     return super(StockMove, self)._get_upstream_documents_and_responsibles(visited)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // if self.move_orig_ids and any(m.state not in ('done', 'cancel') for m in self.move_orig_ids):
            //     result = set()
            //     visited |= self
            //     for move in self.move_orig_ids:
            //         if move.state not in ('done', 'cancel'):
            //             for document, responsible, visited in move._get_upstream_documents_and_responsibles(visited):
            //                 result.add((document, responsible, visited))
            //     return result
            // else:
            //     return []
            */
            return default;
        }

        protected async Task<StockMove> GetValidMovesDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py) ---
            // def _get_valid_moves_domain(self):
            // return ['&', ('picking_id.project_id', '!=', False), ('picking_type_id.analytic_costs', '!=', False)]
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock_account, FILE: stock_move.py) ---
            // def _get_valid_moves_domain(self):
            // domain = super()._get_valid_moves_domain()
            // # If anglo-saxon accounting enabled: we do not generate AALs for the reinvoiced products
            // if self.env.user.company_id.anglo_saxon_accounting:
            //     domain = AND([domain, [('product_id.expense_policy', 'not in', ('sales_price', 'cost'))]])
            // return domain
            */
            return default;
        }

        protected async Task<StockMove> GetValuationPriceAndQtyInternalAsync(object related_aml, object to_curr)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py) ---
            // def _get_valuation_price_and_qty(self, related_aml, to_curr):
            // valuation_price_unit_total, valuation_total_qty = super()._get_valuation_price_and_qty(related_aml, to_curr)
            // boms = self.env['mrp.bom']._bom_find(related_aml.product_id, company_id=related_aml.company_id.id, bom_type='phantom')
            // if related_aml.product_id in boms:
            //     kit_bom = boms[related_aml.product_id]
            //     order_qty = related_aml.product_id.uom_id._compute_quantity(related_aml.quantity, kit_bom.product_uom_id)
            //     filters = {
            //         'incoming_moves': lambda m: m.location_id.usage == 'supplier' and (not m.origin_returned_move_id or (m.origin_returned_move_id and m.to_refund)),
            //         'outgoing_moves': lambda m: m.location_id.usage != 'supplier' and m.to_refund
            //     }
            //     valuation_total_qty = self._compute_kit_quantities(related_aml.product_id, order_qty, kit_bom, filters)
            //     valuation_total_qty = kit_bom.product_uom_id._compute_quantity(valuation_total_qty, related_aml.product_id.uom_id)
            //     if float_is_zero(valuation_total_qty, precision_rounding=related_aml.product_uom_id.rounding or related_aml.product_id.uom_id.rounding):
            //         raise UserError(_('Odoo is not able to generate the anglo saxon entries. The total valuation of %s is zero.', related_aml.product_id.display_name))
            // return valuation_price_unit_total, valuation_total_qty
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_valuation_price_and_qty(self, related_aml, to_curr):
            // valuation_price_unit_total = 0
            // valuation_total_qty = 0
            // for val_stock_move in self:
            //     # In case val_stock_move is a return move, its valuation entries have been made with the
            //     # currency rate corresponding to the original stock move
            //     valuation_date = val_stock_move.origin_returned_move_id.date or val_stock_move.date
            //     svl = val_stock_move.with_context(active_test=False).mapped('stock_valuation_layer_ids').filtered(
            //         lambda l: l.quantity)
            //     layers_qty = sum(svl.mapped('quantity'))
            //     layers_values = sum(svl.mapped('value'))
            //     valuation_price_unit_total += related_aml.company_currency_id._convert(
            //         layers_values, to_curr, related_aml.company_id, valuation_date, round=False,
            //     )
            //     valuation_total_qty += layers_qty
            // if float_is_zero(valuation_total_qty, precision_rounding=related_aml.product_uom_id.rounding or related_aml.product_id.uom_id.rounding):
            //     raise UserError(
            //         _('Odoo is not able to generate the anglo saxon entries. The total valuation of %s is zero.',
            //           related_aml.product_id.display_name))
            // return valuation_price_unit_total, valuation_total_qty
            */
            return default;
        }

        protected async Task<StockMove> GetValuedTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_valued_types(self):
            // """Returns a list of `valued_type` as strings. During `action_done`, we'll call
            // `_is_[valued_type]'. If the result of this method is truthy, we'll consider the move to be
            // valued.
            // 
            // :returns: a list of `valued_type`
            // :rtype: list
            // """
            // return ['in', 'out', 'dropshipped', 'dropshipped_returned']
            */
            return default;
        }

        protected async Task<StockMove> HasTrackedSubcontractComponentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _has_tracked_subcontract_components(self):
            // return any(m.has_tracking != 'none' for m in self._get_subcontract_production().move_raw_ids)
            */
            return default;
        }

        protected async Task<StockMove> IgnoreAutomaticValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _ignore_automatic_valuation(self):
            // return super()._ignore_automatic_valuation() or bool(self.raw_material_production_id)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _ignore_automatic_valuation(self):
            // return bool(self.picking_id)
            */
            return default;
        }

        public async Task<StockMove> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def init(self):
            // self._cr.execute('SELECT indexname FROM pg_indexes WHERE indexname = %s', ('stock_move_product_location_index',))
            // if not self._cr.fetchone():
            //     self._cr.execute('CREATE INDEX stock_move_product_location_index ON stock_move (product_id, location_id, location_dest_id, company_id, state)')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> InversePickedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _inverse_picked(self):
            // for move in self:
            //     move.move_line_ids.picked = move.picked
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _inverse_picked(self):
            // super()._inverse_picked()
            // self._account_analytic_entry_move()
            */
            return default;
        }

        protected async Task<StockMove> IsConsumingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _is_consuming(self):
            // return super()._is_consuming() or self.picking_type_id.code == 'mrp_operation'
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _is_consuming(self):
            // return super()._is_consuming() or (self.repair_id and self.repair_line_type == 'add')
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _is_consuming(self):
            // self.ensure_one()
            // from_wh = self.location_id.warehouse_id
            // to_wh = self.location_dest_id.warehouse_id
            // return self.picking_type_id.code in ('internal', 'outgoing') or (from_wh and to_wh and from_wh != to_wh)
            */
            return default;
        }

        protected async Task<StockMove> IsDropshippedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py) ---
            // def _is_dropshipped(self):
            // res = super()._is_dropshipped()
            // return res or (
            //         self.partner_id.property_stock_subcontractor.parent_path
            //         and self.partner_id.property_stock_subcontractor.parent_path in self.location_id.parent_path
            //         and self.location_dest_id.usage == 'customer'
            // )
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _is_dropshipped(self):
            // """Check if the move should be considered as a dropshipping move so that the cost method
            // will be able to apply the correct logic.
            // 
            // :returns: True if the move is a dropshipping one else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (self.location_id.usage == 'supplier' or (self.location_id.usage == 'transit' and not self.location_id.company_id)) \
            //    and (self.location_dest_id.usage == 'customer' or (self.location_dest_id.usage == 'transit' and not self.location_dest_id.company_id))
            */
            return default;
        }

        protected async Task<StockMove> IsDropshippedReturnedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py) ---
            // def _is_dropshipped_returned(self):
            // res = super()._is_dropshipped_returned()
            // return res or (
            //         self.location_id.usage == 'customer'
            //         and self.partner_id.property_stock_subcontractor.parent_path
            //         and self.partner_id.property_stock_subcontractor.parent_path in self.location_dest_id.parent_path
            // )
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _is_dropshipped_returned(self):
            // """Check if the move should be considered as a returned dropshipping move so that the cost
            // method will be able to apply the correct logic.
            // 
            // :returns: True if the move is a returned dropshipping one else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (self.location_id.usage == 'customer' or (self.location_id.usage == 'transit' and not self.location_id.company_id)) \
            //    and (self.location_dest_id.usage == 'supplier' or (self.location_dest_id.usage == 'transit' and not self.location_dest_id.company_id))
            */
            return default;
        }

        protected async Task<StockMove> IsInInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _is_in(self):
            // """Check if the move should be considered as entering the company so that the cost method
            // will be able to apply the correct logic.
            // 
            // :returns: True if the move is entering the company else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // if self._get_in_move_lines() and not self._is_dropshipped_returned():
            //     return True
            // return False
            */
            return default;
        }

        protected async Task<StockMove> IsIncomingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _is_incoming(self):
            // self.ensure_one()
            // return self.location_id.usage in ('customer', 'supplier') or (
            //     self.location_id.usage == 'transit' and not self.location_id.company_id
            // )
            */
            return default;
        }

        protected async Task<StockMove> IsManualConsumptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _is_manual_consumption(self):
            // self.ensure_one()
            // return self._determine_is_manual_consumption(self.bom_line_id)
            */
            return default;
        }

        protected async Task<StockMove> IsOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _is_out(self):
            // """Check if the move should be considered as leaving the company so that the cost method
            // will be able to apply the correct logic.
            // 
            // :returns: True if the move is leaving the company else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // if self._get_out_move_lines() and not self._is_dropshipped():
            //     return True
            // return False
            */
            return default;
        }

        protected async Task<StockMove> IsOutgoingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _is_outgoing(self):
            // self.ensure_one()
            // return self.location_dest_id.usage in ('customer', 'supplier') or (
            //     self.location_dest_id.usage == 'transit' and not self.location_dest_id.company_id
            // )
            */
            return default;
        }

        protected async Task<StockMove> IsProductionConsumedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _is_production_consumed(self):
            // self.ensure_one()
            // return self.location_dest_id.usage == 'production' and self.location_id._should_be_valued()
            */
            return default;
        }

        protected async Task<StockMove> IsProductionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _is_production(self):
            // self.ensure_one()
            // return self.location_id.usage == 'production' and self.location_dest_id._should_be_valued()
            */
            return default;
        }

        protected async Task<StockMove> IsPurchaseReturnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py) ---
            // def _is_purchase_return(self):
            // res = super()._is_purchase_return()
            // return res or self._is_dropshipped_returned()
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_move.py) ---
            // def _is_purchase_return(self):
            // res = super()._is_purchase_return()
            // return res or self._is_subcontract_return()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _is_purchase_return(self):
            // self.ensure_one()
            // return self.location_dest_id.usage == "supplier" or (self.origin_returned_move_id and self.location_dest_id == self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False))
            */
            return default;
        }

        protected async Task<StockMove> IsReturnedInternalAsync(object valued_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _is_returned(self, valued_type):
            // self.ensure_one()
            // if valued_type == 'in':
            //     return self.location_id and self.location_id.usage == 'customer'   # goods returned from customer
            // if valued_type == 'out':
            //     return self.location_dest_id and self.location_dest_id.usage == 'supplier'
            */
            return default;
        }

        protected async Task<StockMove> IsSubcontractReturnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _is_subcontract_return(self):
            // self.ensure_one()
            // subcontracting_location = self.picking_id.partner_id.with_company(self.company_id).property_stock_subcontractor
            // return (
            //         not self.is_subcontract
            //         and self.origin_returned_move_id.is_subcontract
            //         and self.location_dest_id.id == subcontracting_location.id
            // )
            */
            return default;
        }

        protected async Task<StockMove> KeyAssignPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _key_assign_picking(self):
            // keys = super(StockMove, self)._key_assign_picking()
            // return keys + (self.created_production_id,)
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _key_assign_picking(self):
            // keys = super(StockMove, self)._key_assign_picking()
            // return keys + (self.group_id.pos_order_id,)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _key_assign_picking(self):
            // self.ensure_one()
            // keys = (self.group_id, self.location_id, self.location_dest_id, self.picking_type_id)
            // if self.partner_id and not self.group_id:
            //     keys += (self.partner_id, )
            // return keys
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _key_assign_picking(self):
            // keys = super(StockMove, self)._key_assign_picking()
            // return keys + (self.sale_line_id.order_id.carrier_id,)
            */
            return default;
        }

        protected async Task<StockMove> MatchSearchedAvailabilityInternalAsync(object @operator, object @value, object get_comparison_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _match_searched_availability(self, operator, value, get_comparison_date):
            // def get_stock_moves(moves, state):
            //     if state == 'available':
            //         return moves.filtered(lambda m: m.forecast_availability == m.product_qty and not m.forecast_expected_date)
            //     elif state == 'expected':
            //         return moves.filtered(lambda m: m.forecast_availability == m.product_qty and m.forecast_expected_date and m.forecast_expected_date <= get_comparison_date(m))
            //     elif state == 'late':
            //         return moves.filtered(lambda m: m.forecast_availability == m.product_qty and m.forecast_expected_date and m.forecast_expected_date > get_comparison_date(m))
            //     elif state == 'unavailable':
            //         return moves if moves.filtered(lambda m: m.forecast_availability < m.product_qty) else self.env['stock.move']
            //     else:
            //         raise UserError(_('Selection not supported.'))
            // 
            // if not value:
            //     raise UserError(_('Search not supported without a value.'))
            // 
            // # We consider an operation without any moves as always available since there is no goods to wait.
            // if len(self) == 0:
            //     is_selected_available = any(val == 'available' for val in value) if isinstance(value, list) else value == 'available'
            //     if is_selected_available == (operator in {'=', 'in'}):
            //         return True
            //     return False
            // moves = self
            // if operator == '=':
            //     moves = get_stock_moves(moves, value)
            // elif operator == '!=':
            //     moves = moves - get_stock_moves(moves, value)
            // elif operator == 'in':
            //     search_moves = self.env['stock.move']
            //     for state in value:
            //         search_moves |= get_stock_moves(moves, state)
            //     moves = search_moves
            // elif operator == 'not in':
            //     search_moves = self.env['stock.move']
            //     for state in value:
            //         search_moves |= get_stock_moves(moves, state)
            //     moves = self - search_moves
            // else:
            //     raise UserError(_('Operation not supported'))
            // return len(moves) == len(self)
            */
            return default;
        }

        protected async Task<StockMove> MergeMoveItemgetterInternalAsync(object distinct_fields, object excluded_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _merge_move_itemgetter(self, distinct_fields, excluded_fields=None):
            // fields = set(distinct_fields or []) - set(excluded_fields or [])
            // float_fields = {f_name for f_name in fields if self.env['stock.move']._fields[f_name].type == 'float'}
            // base_getter = itemgetter(*fields - float_fields)
            // 
            // if not float_fields:
            //     return base_getter
            // 
            // float_precision = {f_name: (self.env['stock.move']._fields[f_name].get_digits(self.env) or (False, 2))[1] for f_name in float_fields}
            // if 'price_unit' in float_fields:
            //     price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            //     currency_precision = self.company_id.currency_id.decimal_places
            //     float_precision['price_unit'] = min(currency_precision, price_unit_prec) if currency_precision else price_unit_prec
            // 
            // def _get_formatted_float_fields(move, f_name, precision):
            //     # Round and cast the value of move.f_name into a string so that rounding errors do not prevent the merge
            //     rounded_value = float_round(move[f_name], precision_digits=precision[f_name])
            //     return "{:.{precision}f}".format(rounded_value, precision=precision[f_name])
            // 
            // return lambda move: base_getter(move) + tuple(_get_formatted_float_fields(move, f_name, float_precision) for f_name in float_fields)
            */
            return default;
        }

        protected async Task<StockMove> MergeMovesFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _merge_moves_fields(self):
            // """ This method will return a dict of stock move’s values that represent the values of all moves in `self` merged. """
            // merge_extra = self.env.context.get('merge_extra')
            // state = self._get_relevant_state_among_moves()
            // origin = '/'.join(set(self.filtered(lambda m: m.origin).mapped('origin')))
            // return {
            //     'product_uom_qty': sum(self.mapped('product_uom_qty')) if not merge_extra else self[0].product_uom_qty,
            //     'date': min(self.mapped('date')) if all(p.move_type == 'direct' for p in self.picking_id) else max(self.mapped('date')),
            //     'move_dest_ids': [(4, m.id) for m in self.mapped('move_dest_ids')],
            //     'move_orig_ids': [(4, m.id) for m in self.mapped('move_orig_ids')],
            //     'state': state,
            //     'origin': origin,
            // }
            */
            return default;
        }

        protected async Task<StockMove> MergeMovesInternalAsync(object merge_into)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _merge_moves(self, merge_into=False):
            // """ This method will, for each move in `self`, go up in their linked picking and try to
            // find in their existing moves a candidate into which we can merge the move.
            // :return: Recordset of moves passed to this method. If some of the passed moves were merged
            // into another existing one, return this one and not the (now unlinked) original.
            // """
            // 
            // candidate_moves_set = set()
            // if not merge_into:
            //     self._update_candidate_moves_list(candidate_moves_set)
            // else:
            //     candidate_moves_set.add(merge_into | self)
            // 
            // distinct_fields = (self | self.env['stock.move'].concat(*candidate_moves_set))._prepare_merge_moves_distinct_fields()
            // 
            // # Move removed after merge
            // moves_to_unlink = self.env['stock.move']
            // # Moves successfully merged
            // merged_moves = self.env['stock.move']
            // # Emptied moves
            // moves_to_cancel = self.env['stock.move']
            // 
            // moves_by_neg_key = defaultdict(lambda: self.env['stock.move'])
            // # Need to check less fields for negative moves as some might not be set.
            // neg_qty_moves = self.filtered(lambda m: float_compare(m.product_qty, 0.0, precision_rounding=m.product_uom.rounding) < 0)
            // # Detach their picking as they will either get absorbed or create a backorder, so no extra logs will be put in the chatter
            // neg_qty_moves.picking_id = False
            // excluded_fields = self._prepare_merge_negative_moves_excluded_distinct_fields()
            // neg_key = self._merge_move_itemgetter(distinct_fields, excluded_fields)
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // 
            // for candidate_moves in candidate_moves_set:
            //     # First step find move to merge.
            //     candidate_moves = candidate_moves.filtered(lambda m: m.state not in ('done', 'cancel', 'draft')) - neg_qty_moves
            //     for __, g in groupby(candidate_moves, key=self._merge_move_itemgetter(distinct_fields)):
            //         moves = self.env['stock.move'].concat(*g)
            //         # Merge all positive moves together
            //         if len(moves) > 1:
            //             # link all move lines to record 0 (the one we will keep).
            //             moves.mapped('move_line_ids').write({'move_id': moves[0].id})
            //             # merge move data
            //             merge_extra = self.env.context.get('merge_extra') and bool(merge_into)
            //             moves[0].write(moves.with_context(merge_extra=merge_extra)._merge_moves_fields())
            //             # update merged moves dicts
            //             moves_to_unlink |= moves[1:]
            //             merged_moves |= moves[0]
            //         # Add the now single positive move to its limited key record
            //         moves_by_neg_key[neg_key(moves[0])] |= moves[0]
            // 
            // for neg_move in neg_qty_moves:
            //     # Check all the candidates that matches the same limited key, and adjust their quantities to absorb negative moves
            //     for pos_move in moves_by_neg_key.get(neg_key(neg_move), []):
            //         new_total_value = pos_move.product_qty * pos_move.price_unit + neg_move.product_qty * neg_move.price_unit
            //         # If quantity can be fully absorbed by a single move, update its quantity and remove the negative move
            //         if float_compare(pos_move.product_uom_qty, abs(neg_move.product_uom_qty), precision_rounding=pos_move.product_uom.rounding) >= 0:
            //             pos_move.product_uom_qty += neg_move.product_uom_qty
            //             pos_move.write({
            //                 'price_unit': float_round(new_total_value / pos_move.product_qty, precision_digits=price_unit_prec) if pos_move.product_qty else 0,
            //                 'move_dest_ids': [Command.link(m.id) for m in neg_move.mapped('move_dest_ids') if m.location_id == pos_move.location_dest_id],
            //                 'move_orig_ids': [Command.link(m.id) for m in neg_move.mapped('move_orig_ids') if m.location_dest_id == pos_move.location_id],
            //             })
            //             merged_moves |= pos_move
            //             moves_to_unlink |= neg_move
            //             if float_is_zero(pos_move.product_uom_qty, precision_rounding=pos_move.product_uom.rounding):
            //                 moves_to_cancel |= pos_move
            //             break
            //         neg_move.product_uom_qty += pos_move.product_uom_qty
            //         neg_move.price_unit = float_round(new_total_value / neg_move.product_qty, precision_digits=price_unit_prec)
            //         pos_move.product_uom_qty = 0
            //         moves_to_cancel |= pos_move
            // 
            // # We are using propagate to False in order to not cancel destination moves merged in moves[0]
            // (moves_to_unlink | moves_to_cancel)._clean_merged()
            // 
            // if moves_to_unlink:
            //     moves_to_unlink._action_cancel()
            //     moves_to_unlink.sudo().unlink()
            // 
            // if moves_to_cancel:
            //     moves_to_cancel.filtered(lambda m: not m.picked)._action_cancel()
            // 
            // return (self | merged_moves) - moves_to_unlink
            */
            return default;
        }

        protected async Task<StockMove> OnchangeLotIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _onchange_lot_ids(self):
            // quantity = sum(ml.quantity_product_uom for ml in self.move_line_ids.filtered(lambda ml: not ml.lot_id and ml.lot_name))
            // quantity += self.product_id.uom_id._compute_quantity(len(self.lot_ids), self.product_uom)
            // self.update({'quantity': quantity})
            // 
            // base_location = self.picking_id.location_id or self.location_id
            // quants = self.env['stock.quant'].sudo().search([
            //     ('product_id', '=', self.product_id.id),
            //     ('lot_id', 'in', self.lot_ids.ids),
            //     ('quantity', '!=', 0),
            //     ('location_id.usage', 'in', ('internal', 'transit', 'customer')),
            //     ('location_id', 'not any', [('location_id', 'child_of', base_location.id)])
            // ])
            // 
            // if quants:
            //     sn_to_location = ""
            //     for quant in quants:
            //         sn_to_location += _("\n(%(serial_number)s) exists in location %(location)s", serial_number=quant.lot_id.display_name, location=quant.location_id.display_name)
            //     return {
            //         'warning': {'title': _('Warning'), 'message': _('Unavailable Serial numbers. Please correct the serial numbers encoded: %(serial_numbers_to_locations)s', serial_numbers_to_locations=sn_to_location)}
            //     }
            */
            return default;
        }

        protected async Task<StockMove> OnchangeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _onchange_product_id(self):
            // product = self.product_id.with_context(lang=self._get_lang())
            // self.name = product.partner_ref
            // if product:
            //     self.description_picking = product._get_description(self.picking_type_id)
            */
            return default;
        }

        protected async Task<StockMove> OnchangeProductUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _onchange_product_uom(self):
            // if self.product_uom.factor > self.product_id.uom_id.factor:
            //     return {
            //         'warning': {
            //             'title': _("Unsafe unit of measure"),
            //             'message': _("You are using a unit of measure smaller than the one you are using in "
            //                          "order to stock your product. This can lead to rounding problem on reserved quantity. "
            //                          "You should use the smaller unit of measure possible in order to valuate your stock or "
            //                          "change its rounding precision to a smaller value (example: 0.00001)."),
            //         }
            //     }
            */
            return default;
        }

        protected async Task<StockMove> OnchangeProductUomQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _onchange_product_uom_qty(self):
            // if self.product_uom and self.raw_material_production_id and self.has_tracking == 'none':
            //     mo = self.raw_material_production_id
            //     new_qty = float_round((mo.qty_producing - mo.qty_produced) * self.unit_factor, precision_rounding=self.product_uom.rounding)
            //     self.quantity = new_qty
            */
            return default;
        }

        protected async Task<StockMove> OnchangeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _onchange_quantity(self):
            // if self.raw_material_production_id and not self.manual_consumption and self.picked and self.product_uom and \
            //    float_compare(self.product_uom_qty, self.quantity, precision_rounding=self.product_uom.rounding) != 0:
            //     self.manual_consumption = True
            */
            return default;
        }

        protected async Task<StockMove> OnchangeSuggestPackagingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _onchange_suggest_packaging(self):
            // # remove packaging if not match the product
            // if self.product_packaging_id.product_id != self.product_id:
            //     self.product_packaging_id = False
            // # suggest biggest suitable packaging
            // if self.product_id and self.product_qty and self.product_uom:
            //     self.product_packaging_id = self.product_id.packaging_ids._find_suitable_product_packaging(self.product_qty, self.product_uom)
            */
            return default;
        }

        public async Task<StockMove> OpenReferenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def action_open_reference(self):
            // res = super().action_open_reference()
            // source = self.production_id or self.raw_material_production_id
            // if source and source.browse().has_access('read'):
            //     return {
            //         'res_model': source._name,
            //         'type': 'ir.actions.act_window',
            //         'views': [[False, "form"]],
            //         'res_id': source.id,
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_open_reference(self):
            // """ Open the form view of the move's reference document, if one exists, otherwise open form view of self
            // """
            // self.ensure_one()
            // source = self.picking_id
            // if source and source.browse().has_access('read'):
            //     return {
            //         'res_model': source._name,
            //         'type': 'ir.actions.act_window',
            //         'views': [[False, "form"]],
            //         'res_id': source.id,
            //     }
            // return {
            //     'res_model': self._name,
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, "form"]],
            //     'res_id': self.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> PostProcessCreatedMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _post_process_created_moves(self):
            // # This method is meant to be overriden in order to execute post 
            // # creation actions that would be bypassed since the move was 
            // # and will probably never be confirmed
            // pass
            */
            return default;
        }

        protected async Task<StockMove> PrepareAccountMoveLineInternalAsync(object qty, object cost, Guid credit_account_id, Guid debit_account_id, Guid svl_id, object description)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_account_move_line(self, qty, cost, credit_account_id, debit_account_id, svl_id, description):
            // """
            // Generate the account.move.line values to post to track the stock valuation difference due to the
            // processing of the given quant.
            // """
            // self.ensure_one()
            // 
            // # the standard_price of the product may be in another decimal precision, or not compatible with the coinage of
            // # the company currency... so we need to use round() before creating the accounting entries.
            // debit_value = self.company_id.currency_id.round(cost)
            // credit_value = debit_value
            // 
            // valuation_partner_id = self._get_partner_id_for_valuation_lines()
            // res = [(0, 0, line_vals) for line_vals in self._generate_valuation_lines_data(valuation_partner_id, qty, debit_value, credit_value, debit_account_id, credit_account_id, svl_id, description).values()]
            // 
            // return res
            */
            return default;
        }

        protected async Task<StockMove> PrepareAccountMoveValsInternalAsync(Guid credit_account_id, Guid debit_account_id, Guid journal_id, object qty, object description, Guid svl_id, object cost)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_account_move_vals(self, credit_account_id, debit_account_id, journal_id, qty, description, svl_id, cost):
            // self.ensure_one()
            // valuation_partner_id = self._get_partner_id_for_valuation_lines()
            // move_ids = self._prepare_account_move_line(qty, cost, credit_account_id, debit_account_id, svl_id, description)
            // svl = self.env['stock.valuation.layer'].browse(svl_id)
            // if self.env.context.get('force_period_date'):
            //     date = self.env.context.get('force_period_date')
            // elif svl.account_move_line_id:
            //     date = svl.account_move_line_id.date
            // else:
            //     date = fields.Date.context_today(self)
            // return {
            //     'journal_id': journal_id,
            //     'line_ids': move_ids,
            //     'partner_id': valuation_partner_id,
            //     'date': date,
            //     'ref': description,
            //     'stock_move_id': self.id,
            //     'stock_valuation_layer_ids': [(6, None, [svl_id])],
            //     'move_type': 'entry',
            //     'is_storno': self.env.context.get('is_returned') and self.company_id.account_storno,
            //     'company_id': self.company_id.id,
            // }
            */
            return default;
        }

        protected async Task<StockMove> PrepareAnalyticLineValuesInternalAsync(object account_field_values, object amount, object unit_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py) ---
            // def _prepare_analytic_line_values(self, account_field_values, amount, unit_amount):
            // res = super()._prepare_analytic_line_values(account_field_values, amount, unit_amount)
            // if self.raw_material_production_id:
            //     res['category'] = 'manufacturing_order'
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py) ---
            // def _prepare_analytic_line_values(self, account_field_values, amount, unit_amount):
            // res = super()._prepare_analytic_line_values(account_field_values, amount, unit_amount)
            // if self.picking_id:
            //     res['name'] = self.picking_id.name
            //     res['category'] = 'picking_entry'
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_analytic_line_values(self, account_field_values, amount, unit_amount):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'amount': amount,
            //     **account_field_values,
            //     'unit_amount': unit_amount,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_id.uom_id.id,
            //     'company_id': self.company_id.id,
            //     'ref': self._description,
            //     'category': 'other',
            // }
            */
            return default;
        }

        protected async Task<StockMove> PrepareAnalyticLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py) ---
            // def _prepare_analytic_lines(self):
            // res = super()._prepare_analytic_lines()
            // if res and self.raw_material_production_id:
            //     # Check that all mandatory plans are set on the project linked to the MO of the stock move before generating the AALs
            //     project = self.raw_material_production_id.project_id
            //     mandatory_plans = project._get_mandatory_plans(self.company_id, business_domain='manufacturing_order')
            //     missing_plan_names = [plan['name'] for plan in mandatory_plans if not project[plan['column_name']]]
            //     if missing_plan_names:
            //         raise ValidationError(_(
            //             "'%(missing_plan_names)s' analytic plan(s) required on the project '%(project_name)s' linked to the manufacturing order.",
            //             missing_plan_names=format_list(self.env, missing_plan_names),
            //             project_name=project.name,
            //         ))
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py) ---
            // def _prepare_analytic_lines(self):
            // res = super()._prepare_analytic_lines()
            // if res and self.picking_id:
            //     # Check that all mandatory plans are set on the project linked to the picking of the stock move before generating the AALs
            //     project = self.picking_id.project_id
            //     mandatory_plans = project._get_mandatory_plans(self.company_id, business_domain='stock_picking')
            //     missing_plan_names = [plan['name'] for plan in mandatory_plans if not project[plan['column_name']]]
            //     if missing_plan_names:
            //         raise ValidationError(_(
            //             "'%(missing_plan_names)s' analytic plan(s) required on the project '%(project_name)s' linked to the stock picking.",
            //             missing_plan_names=format_list(self.env, missing_plan_names),
            //             project_name=project.name,
            //         ))
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_analytic_lines(self):
            // self.ensure_one()
            // if not self._get_analytic_distribution() and not self.analytic_account_line_ids:
            //     return False
            // 
            // if self.state in ['cancel', 'draft']:
            //     return False
            // 
            // amount, unit_amount = 0, 0
            // if self.state != 'done':
            //     if self.picked:
            //         unit_amount = self.product_uom._compute_quantity(
            //             self.quantity, self.product_id.uom_id)
            //         # Falsy in FIFO but since it's an estimation we don't require exact correct cost. Otherwise
            //         # we would have to recompute all the analytic estimation at each out.
            //         amount = - unit_amount * self.product_id.standard_price
            // elif self.product_id.valuation == 'real_time' and not self._ignore_automatic_valuation():
            //     accounts_data = self.product_id.product_tmpl_id.get_product_accounts()
            //     account_valuation = accounts_data.get('stock_valuation', False)
            //     analytic_line_vals = self.stock_valuation_layer_ids.account_move_id.line_ids.filtered(
            //         lambda l: l.account_id == account_valuation)._prepare_analytic_lines()
            //     amount = - sum(vals['amount'] for vals in analytic_line_vals)
            //     unit_amount = - sum(vals['unit_amount'] for vals in analytic_line_vals)
            // elif sum(self.stock_valuation_layer_ids.mapped('quantity')):
            //     amount = sum(self.stock_valuation_layer_ids.mapped('value'))
            //     unit_amount = - sum(self.stock_valuation_layer_ids.mapped('quantity'))
            // 
            // if self.analytic_account_line_ids and amount == 0 and unit_amount == 0:
            //     self.analytic_account_line_ids.unlink()
            //     return False
            // 
            // return self.env['account.analytic.account']._perform_analytic_distribution(
            //     self._get_analytic_distribution(), amount, unit_amount, self.analytic_account_line_ids, self)
            */
            return default;
        }

        protected async Task<StockMove> PrepareAnglosaxonAccountMoveValsInternalAsync(object acc_src, object acc_dest, object acc_valuation, Guid journal_id, object qty, object description, Guid svl_id, object cost)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_anglosaxon_account_move_vals(self, acc_src, acc_dest, acc_valuation, journal_id, qty, description, svl_id, cost):
            // anglosaxon_am_vals = {}
            // if self._is_dropshipped():
            //     if cost > 0:
            //         anglosaxon_am_vals = self.with_company(self.company_id)._prepare_account_move_vals(acc_src, acc_valuation, journal_id, qty, description, svl_id, cost)
            //     else:
            //         cost = -1 * cost
            //         anglosaxon_am_vals = self.with_company(self.company_id)._prepare_account_move_vals(acc_valuation, acc_dest, journal_id, qty, description, svl_id, cost)
            // elif self._is_dropshipped_returned():
            //     if cost > 0 and self.location_dest_id._should_be_valued():
            //         anglosaxon_am_vals = self.with_company(self.company_id).with_context(is_returned=True)._prepare_account_move_vals(acc_valuation, acc_src, journal_id, qty, description, svl_id, cost)
            //     elif cost > 0:
            //         anglosaxon_am_vals = self.with_company(self.company_id).with_context(is_returned=True)._prepare_account_move_vals(acc_dest, acc_valuation, journal_id, qty, description, svl_id, cost)
            //     else:
            //         cost = -1 * cost
            //         anglosaxon_am_vals = self.with_company(self.company_id).with_context(is_returned=True)._prepare_account_move_vals(acc_valuation, acc_src, journal_id, qty, description, svl_id, cost)
            // return anglosaxon_am_vals
            */
            return default;
        }

        protected async Task<StockMove> PrepareCommonSvlValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_common_svl_vals(self):
            // """When a `stock.valuation.layer` is created from a `stock.move`, we can prepare a dict of
            // common vals.
            // 
            // :returns: the common values when creating a `stock.valuation.layer` from a `stock.move`
            // :rtype: dict
            // """
            // self.ensure_one()
            // return {
            //     'stock_move_id': self.id,
            //     'company_id': self.company_id.id,
            //     'product_id': self.product_id.id,
            //     'description': self.reference and '%s - %s' % (self.reference, self.product_id.name) or self.product_id.name,
            // }
            */
            return default;
        }

        protected async Task<StockMove> PrepareLinesDataDictInternalAsync(object order_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _prepare_lines_data_dict(self, order_lines):
            // lines_data = defaultdict(dict)
            // for product_id, olines in groupby(sorted(order_lines, key=lambda l: l.product_id.id), key=lambda l: l.product_id.id):
            //     lines_data[product_id].update({'order_lines': self.env['pos.order.line'].concat(*olines)})
            // return lines_data
            */
            return default;
        }

        protected async Task<StockMove> PrepareMergeMovesDistinctFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_merge_moves_distinct_fields(self):
            // res = super()._prepare_merge_moves_distinct_fields()
            // res += ['created_production_id', 'cost_share']
            // if self.bom_line_id and ("phantom" in self.bom_line_id.bom_id.mapped('type')):
            //     res.append('bom_line_id')
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _prepare_merge_moves_distinct_fields(self):
            // distinct_fields = super(StockMove, self)._prepare_merge_moves_distinct_fields()
            // distinct_fields += ['purchase_line_id', 'created_purchase_line_ids']
            // return distinct_fields
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _prepare_merge_moves_distinct_fields(self):
            // distinct_fields = super(StockMove, self)._prepare_merge_moves_distinct_fields()
            // distinct_fields.append('sale_line_id')
            // return distinct_fields
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_merge_moves_distinct_fields(self):
            // fields = [
            //     'product_id', 'price_unit', 'procure_method', 'location_id', 'location_dest_id', 'location_final_id',
            //     'product_uom', 'restrict_partner_id', 'scrapped', 'origin_returned_move_id',
            //     'package_level_id', 'propagate_cancel', 'description_picking',
            //     'product_packaging_id', 'never_product_template_attribute_value_ids',
            // ]
            // if self.env['ir.config_parameter'].sudo().get_param('stock.merge_only_same_date'):
            //     fields.append('date')
            // if self.env.context.get('merge_extra'):
            //     fields.pop(fields.index('procure_method'))
            // if not self.env['ir.config_parameter'].sudo().get_param('stock.merge_ignore_date_deadline'):
            //     fields.append('date_deadline')
            // return fields
            */
            return default;
        }

        protected async Task<StockMove> PrepareMergeNegativeMovesExcludedDistinctFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_merge_negative_moves_excluded_distinct_fields(self):
            // return super()._prepare_merge_negative_moves_excluded_distinct_fields() + ['created_production_id']
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _prepare_merge_negative_moves_excluded_distinct_fields(self):
            // excluded_fields = super()._prepare_merge_negative_moves_excluded_distinct_fields() + ['created_purchase_line_ids']
            // if self.env['ir.config_parameter'].sudo().get_param('purchase_stock.merge_different_procurement'):
            //     excluded_fields += ['procure_method']
            // return excluded_fields
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_merge_negative_moves_excluded_distinct_fields(self):
            // return ['description_picking']
            */
            return default;
        }

        protected async Task<StockMove> PrepareMoveLineValsInternalAsync(object quantity, object reserved_quant)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_move_line_vals(self, quantity=None, reserved_quant=None):
            // vals = super()._prepare_move_line_vals(quantity, reserved_quant)
            // if self.raw_material_production_id:
            //     vals['production_id'] = self.raw_material_production_id.id
            // if self.production_id.product_tracking == 'lot' and self.product_id == self.production_id.product_id:
            //     vals['lot_id'] = self.production_id.lot_producing_id.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_move_line_vals(self, quantity=None, reserved_quant=None):
            // self.ensure_one()
            // vals = {
            //     'move_id': self.id,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom.id,
            //     'location_id': self.location_id.id,
            //     'location_dest_id': self.location_dest_id.id,
            //     'picking_id': self.picking_id.id,
            //     'company_id': self.company_id.id,
            // }
            // if quantity:
            //     # TODO could be also move in create/write
            //     rounding = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     uom_quantity = self.product_id.uom_id._compute_quantity(quantity, self.product_uom, rounding_method='HALF-UP')
            //     uom_quantity = float_round(uom_quantity, precision_digits=rounding)
            //     uom_quantity_back_to_product_uom = self.product_uom._compute_quantity(uom_quantity, self.product_id.uom_id, rounding_method='HALF-UP')
            //     if float_compare(quantity, uom_quantity_back_to_product_uom, precision_digits=rounding) == 0:
            //         vals = dict(vals, quantity=uom_quantity)
            //     else:
            //         vals = dict(vals, quantity=quantity, product_uom_id=self.product_id.uom_id.id)
            // package = None
            // if reserved_quant:
            //     package = reserved_quant.package_id
            //     vals = dict(
            //         vals,
            //         location_id=reserved_quant.location_id.id,
            //         lot_id=reserved_quant.lot_id.id or False,
            //         package_id=package.id or False,
            //         owner_id =reserved_quant.owner_id.id or False,
            //     )
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> PrepareMoveSplitValsInternalAsync(object uom_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_move_split_vals(self, qty):
            // defaults = super()._prepare_move_split_vals(qty)
            // defaults['workorder_id'] = False
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _prepare_move_split_vals(self, qty):
            // vals = super(StockMove, self)._prepare_move_split_vals(qty)
            // vals['location_id'] = self.location_id.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _prepare_move_split_vals(self, uom_qty):
            // vals = super(StockMove, self)._prepare_move_split_vals(uom_qty)
            // vals['purchase_line_id'] = self.purchase_line_id.id
            // # when backordering an mto move link the bakcorder to the purchase order
            // if self.procure_method == 'make_to_order' and self.created_purchase_line_ids:
            //     vals['created_purchase_line_ids'] = [Command.set(self.created_purchase_line_ids.ids)]
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_move_split_vals(self, qty):
            // vals = {
            //     'product_uom_qty': qty,
            //     'procure_method': self.procure_method,
            //     'move_dest_ids': [(4, x.id) for x in self.move_dest_ids if x.state not in ('done', 'cancel')],
            //     'move_orig_ids': [(4, x.id) for x in self.move_orig_ids],
            //     'origin_returned_move_id': self.origin_returned_move_id.id,
            //     'price_unit': self.price_unit,
            //     'date_deadline': self.date_deadline,
            // }
            // if self.env.context.get('force_split_uom_id'):
            //     vals['product_uom'] = self.env.context['force_split_uom_id']
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _prepare_move_split_vals(self, uom_qty):
            // vals = super(StockMove, self)._prepare_move_split_vals(uom_qty)
            // vals['to_refund'] = self.to_refund
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> PreparePhantomLineValsInternalAsync(object bom_line, object qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def _prepare_phantom_line_vals(self, bom_line, qty):
            // self.ensure_one()
            // product = bom_line.product_id
            // return {
            //     'name': self.name,
            //     'repair_id': self.repair_id.id,
            //     'repair_line_type': self.repair_line_type,
            //     'product_id': product.id,
            //     'price_unit': self.price_unit,
            //     'product_uom_qty': qty,
            //     'location_id': self.location_id.id,
            //     'location_dest_id': self.location_dest_id.id,
            //     'state': 'draft',
            // }
            */
            return default;
        }

        protected async Task<StockMove> PreparePhantomMoveValuesInternalAsync(object bom_line, object product_qty, object quantity_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_phantom_move_values(self, bom_line, product_qty, quantity_done):
            // return {
            //     'picking_id': self.picking_id.id if self.picking_id else False,
            //     'product_id': bom_line.product_id.id,
            //     'product_uom': bom_line.product_uom_id.id,
            //     'product_uom_qty': product_qty,
            //     'quantity': quantity_done,
            //     'name': self.name,
            //     'picked': self.picked,
            //     'bom_line_id': bom_line.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py) ---
            // def _prepare_phantom_move_values(self, bom_line, product_qty, quantity_done):
            // vals = super(StockMove, self)._prepare_phantom_move_values(bom_line, product_qty, quantity_done)
            // if self.purchase_line_id:
            //     vals['purchase_line_id'] = self.purchase_line_id.id
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementOriginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_procurement_origin(self):
            // self.ensure_one()
            // if self.raw_material_production_id and self.raw_material_production_id.orderpoint_id:
            //     return self.origin
            // return super()._prepare_procurement_origin()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_procurement_origin(self):
            // self.ensure_one()
            // return self.group_id and self.group_id.name or (self.origin or self.picking_id.name or "/")
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_procurement_qty(self):
            // quantities = []
            // mtso_products_by_locations = defaultdict(list)
            // mtso_moves = set()
            // for move in self:
            //     if move.rule_id and move.rule_id.procure_method == 'mts_else_mto':
            //         mtso_moves.add(move.id)
            //         mtso_products_by_locations[move.location_id].append(move.product_id.id)
            // 
            // # Get the forecasted quantity for the `mts_else_mto` procurement.
            // forecasted_qties_by_loc = {}
            // for location, product_ids in mtso_products_by_locations.items():
            //     if location.should_bypass_reservation():
            //         continue
            //     products = self.env['product.product'].browse(product_ids).with_context(location=location.id)
            //     forecasted_qties_by_loc[location] = {product.id: product.free_qty for product in products}
            // for move in self:
            //     if move.id not in mtso_moves or float_compare(move.product_qty, 0, precision_rounding=move.product_id.uom_id.rounding) <= 0:
            //         quantities.append(move.product_uom_qty)
            //         continue
            // 
            //     if move._should_bypass_reservation():
            //         quantities.append(move.product_uom_qty)
            //         continue
            // 
            //     free_qty = max(forecasted_qties_by_loc[move.location_id][move.product_id.id], 0)
            //     quantity = max(move.product_qty - free_qty, 0)
            //     product_uom_qty = move.product_id.uom_id._compute_quantity(quantity, move.product_uom, rounding_method='HALF-UP')
            //     quantities.append(product_uom_qty)
            //     forecasted_qties_by_loc[move.location_id][move.product_id.id] -= min(move.product_qty, free_qty)
            // 
            // return quantities
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // res['bom_line_id'] = self.bom_line_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // if self.raw_material_production_id.subcontractor_id:
            //     res['warehouse_id'] = self.picking_type_id.warehouse_id
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // vals = super()._prepare_procurement_values()
            // partner = self.group_id.partner_id
            // if not vals.get('partner_id') and partner and self.location_id.is_subcontracting_location:
            //     vals['partner_id'] = partner.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: stock.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // if res.get('group_id') and len(res['group_id'].mrp_production_ids) == 1:
            //     res['project_id'] = res['group_id'].mrp_production_ids.project_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_mrp_sale, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // project = self.sale_line_id.order_id.project_id
            // if project:
            //     res['project_id'] = project.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // """ Prepare specific key for moves or other componenets that will be created from a stock rule
            // comming from a stock move. This method could be override in order to add other custom key that could
            // be used in move/po creation.
            // """
            // self.ensure_one()
            // group_id = self.group_id or False
            // if self.rule_id:
            //     if self.rule_id.group_propagation_option == 'fixed' and self.rule_id.group_id:
            //         group_id = self.rule_id.group_id
            //     elif self.rule_id.group_propagation_option == 'none':
            //         group_id = False
            // 
            // product_id = self.product_id.with_context(lang=self._get_lang())
            // dates_info = {'date_planned': self._get_mto_procurement_date()}
            // if self.location_id.warehouse_id and self.location_id.warehouse_id.lot_stock_id.parent_path in self.location_id.parent_path:
            //     dates_info = self.product_id._get_dates_info(self.date, self.location_id, route_ids=self.route_ids)
            // warehouse = self.warehouse_id or self.picking_type_id.warehouse_id
            // if not self.location_id.warehouse_id:
            //     warehouse = self.rule_id.propagate_warehouse_id
            // move_dest_ids = False
            // if self.procure_method == "make_to_order":
            //     move_dest_ids = self
            // return {
            //     'product_description_variants': self.description_picking and self.description_picking.replace(product_id._get_description(self.picking_type_id), ''),
            //     'never_product_template_attribute_value_ids': self.never_product_template_attribute_value_ids,
            //     'date_planned': dates_info.get('date_planned'),
            //     'date_order': dates_info.get('date_order'),
            //     'date_deadline': self.date_deadline,
            //     'move_dest_ids': move_dest_ids,
            //     'group_id': group_id,
            //     'route_ids': self.route_ids,
            //     'warehouse_id': warehouse,
            //     'priority': self.priority,
            //     'orderpoint_id': self.orderpoint_id,
            //     'product_packaging_id': self.product_packaging_id,
            // }
            */
            return default;
        }

        public async Task<StockMove> ProductForecastReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_product_forecast_report(self):
            // self.ensure_one()
            // action = self.product_id.action_product_forecast_report()
            // action['context'] = {
            //     'active_id': self.product_id.id,
            //     'active_model': 'product.product',
            //     'move_to_match_ids': self.ids,
            // }
            // if self._is_consuming():
            //     warehouse = self.location_id.warehouse_id
            // else:
            //     warehouse = self.location_dest_id.warehouse_id
            // 
            // if warehouse:
            //     action['context']['warehouse_id'] = warehouse.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> ProductPriceUpdateAfterDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _product_price_update_after_done(self):
            // """ Outgoing moves lot valuation should recompute the standard price of the product as the
            // layer price unit may differ from the product price unit """
            // for product, layers in self.stock_valuation_layer_ids.grouped('product_id').items():
            //     if all(not m._is_out() for m in layers.stock_move_id) or not product.lot_valuated:
            //         continue
            //     if layers.with_company(layers.company_id).product_id.cost_method == 'standard':
            //         continue
            //     product_qty = product.sudo().with_company(layers.company_id).quantity_svl
            //     product_value = product.sudo().with_company(layers.company_id).value_svl
            //     rounding = product.uom_id.rounding
            // 
            //     if float_is_zero(product_qty, precision_rounding=rounding):
            //         return
            // 
            //     # get the standard price
            //     # write the standard price, as superuser_id because a warehouse manager may not have the right to write on products
            //     new_std_price = product_value / product_qty
            //     product.with_company(layers.company_id.id).with_context(disable_auto_svl=True).sudo().write({'standard_price': new_std_price})
            */
            return default;
        }

        public async Task<StockMove> ProductPriceUpdateBeforeDoneAsync(Guid id, StockMoveProductPriceUpdateBeforeDoneRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def product_price_update_before_done(self, forced_qty=None):
            // tmpl_dict = defaultdict(lambda: 0.0)
            // lot_tmpl_dict = defaultdict(lambda: 0.0)
            // # adapt standard price on incomming moves if the product cost_method is 'average'
            // std_price_update = {}
            // std_price_update_lot = {}
            // for move in self:
            //     if not move._is_in():
            //         continue
            //     if move.with_company(move.company_id).product_id.cost_method == 'standard':
            //         continue
            //     product_tot_qty_available = move.product_id.sudo().with_company(move.company_id).quantity_svl + tmpl_dict[move.product_id.id]
            //     rounding = move.product_id.uom_id.rounding
            // 
            //     valued_move_lines = move._get_in_move_lines()
            //     quantity_by_lot = defaultdict(float)
            //     if forced_qty:
            //         quantity_by_lot[forced_qty[0]] += forced_qty[1]
            //     else:
            //         for valued_move_line in valued_move_lines:
            //             quantity_by_lot[valued_move_line.lot_id] += valued_move_line.quantity_product_uom
            // 
            //     qty = sum(quantity_by_lot.values())
            //     move_cost = move._get_price_unit()
            //     if float_is_zero(product_tot_qty_available, precision_rounding=rounding) \
            //             or float_is_zero(product_tot_qty_available + move.product_qty, precision_rounding=rounding) \
            //             or float_is_zero(product_tot_qty_available + qty, precision_rounding=rounding):
            //         new_std_price = next(iter(move_cost.values()))
            //     else:
            //         # Get the standard price
            //         amount_unit = std_price_update.get((move.company_id.id, move.product_id.id)) or move.product_id.with_company(move.company_id).standard_price
            //         new_std_price = ((amount_unit * product_tot_qty_available) + (next(iter(move_cost.values())) * qty)) / (product_tot_qty_available + qty)
            // 
            //     tmpl_dict[move.product_id.id] += qty
            //     # Write the standard price, as SUPERUSER_ID because a warehouse manager may not have the right to write on products
            //     move.product_id.with_company(move.company_id.id).with_context(disable_auto_svl=True).sudo().write({'standard_price': new_std_price})
            //     std_price_update[move.company_id.id, move.product_id.id] = new_std_price
            // 
            //     # Update the standard price of the lot
            //     if not move.product_id.lot_valuated:
            //         continue
            //     for lot, qty in quantity_by_lot.items():
            //         qty_avail = lot.sudo().with_company(move.company_id).quantity_svl + lot_tmpl_dict[lot.id]
            //         if float_is_zero(qty_avail, precision_rounding=rounding) \
            //                 or float_is_zero(qty_avail + qty, precision_rounding=rounding):
            //             new_std_price = move_cost[lot]
            //         else:
            //             # Get the standard price
            //             amount_unit = std_price_update_lot.get((move.company_id.id, lot.id)) or lot.with_company(move.company_id).standard_price
            //             new_std_price = ((amount_unit * qty_avail) + (move_cost[lot] * qty)) / (qty_avail + qty)
            //         lot_tmpl_dict[lot.id] += qty
            //         lot.with_company(move.company_id.id).with_context(disable_auto_svl=True).sudo().standard_price = new_std_price
            //         std_price_update_lot[move.company_id.id, lot.id] = new_std_price
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> PropagateDateLogNoteInternalAsync(object move_orig)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _propagate_date_log_note(self, move_orig):
            // """Post a deadline change alert log note on the documents linked to `self`."""
            // # TODO : get the end document (PO/SO/MO)
            // doc_orig = move_orig._delay_alert_get_documents()
            // documents = self._delay_alert_get_documents()
            // if not documents or not doc_orig:
            //     return
            // 
            // msg = _("The deadline has been automatically updated due to a delay on %s.", doc_orig[0]._get_html_link())
            // msg_subject = _("Deadline updated due to delay on %s", doc_orig[0].name)
            // # write the message on each document
            // for doc in documents:
            //     last_message = doc.message_ids[:1]
            //     # Avoids to write the exact same message multiple times.
            //     if last_message and last_message.subject == msg_subject:
            //         continue
            //     odoobot_id = self.env['ir.model.data']._xmlid_to_res_id("base.partner_root")
            //     doc.message_post(body=msg, author_id=odoobot_id, subject=msg_subject)
            */
            return default;
        }

        protected async Task<StockMove> PropagateProductPackagingInternalAsync(Guid product_package_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _propagate_product_packaging(self, product_package_id):
            // """
            // Propagate the product_packaging_id of a move to its destination and origin.
            // If there is a bifurcation in the chain we do not propagate the package.
            // """
            // already_propagated_ids = self.env.context.get('product_packaging_propagation_ids', set()) | set(self.ids)
            // self = self.with_context(product_packaging_propagation_ids=already_propagated_ids)
            // for move in self:
            //     # propagate on destination move
            //     for move_dest in move.move_dest_ids:
            //         if move_dest.id not in already_propagated_ids and \
            //                 move_dest.state not in ['cancel', 'done'] and \
            //                 move_dest.product_packaging_id.id != product_package_id and \
            //                 move_dest.move_orig_ids == move:  # checks that you are the only parent move of your destination
            //             move_dest.product_packaging_id = product_package_id
            //     # propagate on origin move
            //     for move_orig in move.move_orig_ids:
            //         if move_orig.id not in already_propagated_ids and \
            //                 move_orig.state not in ['cancel', 'done'] and \
            //                 move_orig.product_packaging_id.id != product_package_id and \
            //                 move_orig.move_dest_ids == move:  # checks that you are the only child move of your origin
            //             move_orig.product_packaging_id = product_package_id
            */
            return default;
        }

        protected async Task<StockMove> PushApplyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _push_apply(self):
            // new_moves = []
            // for move in self:
            //     new_move = self.env['stock.move']
            // 
            //     # if the move is a returned move, we don't want to check push rules, as returning a returned move is the only decent way
            //     # to receive goods without triggering the push rules again (which would duplicate chained operations)
            //     # first priority goes to the preferred routes defined on the move itself (e.g. coming from a SO line)
            //     warehouse_id = move.warehouse_id or move.picking_id.picking_type_id.warehouse_id
            // 
            //     ProcurementGroup = self.env['procurement.group']
            //     if move.location_dest_id.company_id not in self.env.companies:
            //         ProcurementGroup = self.env['procurement.group'].sudo()
            //         move = move.with_context(allowed_companies=self.env.user.company_ids.ids)
            //         warehouse_id = False
            // 
            //     rule = ProcurementGroup._get_push_rule(move.product_id, move.location_dest_id, {
            //         'route_ids': move.route_ids, 'product_packaging_id': move.product_packaging_id, 'warehouse_id': warehouse_id,
            //     })
            // 
            //     excluded_rule_ids = []
            //     while (rule and rule.push_domain and not move.filtered_domain(literal_eval(rule.push_domain))):
            //         excluded_rule_ids.append(rule.id)
            //         rule = ProcurementGroup._get_push_rule(move.product_id, move.location_dest_id, {
            //             'route_ids': move.route_ids, 'product_packaging_id': move.product_packaging_id, 'warehouse_id': warehouse_id,
            //             'domain': [('id', 'not in', excluded_rule_ids)],
            //         })
            // 
            //     # Make sure it is not returning the return
            //     if rule and (not move.origin_returned_move_id or move.origin_returned_move_id.location_dest_id.id != rule.location_dest_id.id):
            //         new_move = rule._run_push(move) or new_move
            //         if new_move:
            //             new_moves.append(new_move)
            // 
            //     move_to_propagate_ids = set()
            //     move_to_mts_ids = set()
            //     for m in move.move_dest_ids - new_move:
            //         if new_move and move.location_final_id and m.location_id == move.location_final_id:
            //             move_to_propagate_ids.add(m.id)
            //         elif not m.location_id._child_of(move.location_dest_id):
            //             move_to_mts_ids.add(m.id)
            //     self.env['stock.move'].browse(move_to_mts_ids)._break_mto_link(move)
            //     move.move_dest_ids = [Command.unlink(m_id) for m_id in move_to_propagate_ids]
            //     new_move.move_dest_ids = [Command.link(m_id) for m_id in move_to_propagate_ids]
            // 
            // new_moves = self.env['stock.move'].concat(*new_moves)
            // new_moves = new_moves.sudo()._action_confirm()
            // 
            // return new_moves
            */
            return default;
        }

        protected async Task<StockMove> QuantitySmlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _quantity_sml(self):
            // self.ensure_one()
            // quantity = 0
            // for move_line in self.move_line_ids:
            //     quantity += move_line.product_uom_id._compute_quantity(move_line.quantity, self.product_uom, round=False)
            // return quantity
            */
            return default;
        }

        protected async Task<StockMove> RecomputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _recompute_state(self):
            // if self._context.get('preserve_state'):
            //     return
            // moves_state_to_write = defaultdict(set)
            // for move in self:
            //     rounding = move.product_uom.rounding
            //     if move.state in ('cancel', 'done') or (move.state == 'draft' and not move.quantity):
            //         continue
            //     elif float_compare(move.quantity, move.product_uom_qty, precision_rounding=rounding) >= 0:
            //         moves_state_to_write['assigned'].add(move.id)
            //     elif move.quantity and float_compare(move.quantity, move.product_uom_qty, precision_rounding=rounding) <= 0:
            //         moves_state_to_write['partially_available'].add(move.id)
            //     elif (move.procure_method == 'make_to_order' and not move.move_orig_ids) or\
            //          (move.move_orig_ids and any(float_compare(orig.product_uom_qty, 0, precision_rounding=orig.product_uom.rounding) > 0
            //                                      and orig.state not in ('done', 'cancel') for orig in move.move_orig_ids)):
            //         # In the process of merging a negative move, we may still have a negative move in the move_orig_ids at that point.
            //         moves_state_to_write['waiting'].add(move.id)
            //     else:
            //         moves_state_to_write['confirmed'].add(move.id)
            // for state, moves_ids in moves_state_to_write.items():
            //     self.browse(moves_ids).filtered(lambda m: m.state != state).state = state
            */
            return default;
        }

        protected async Task<StockMove> ReduceSubcontractOrderQtyInternalAsync(object quantity_to_remove)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _reduce_subcontract_order_qty(self, quantity_to_remove):
            // self.ensure_one()
            // productions = self.move_orig_ids.production_id.filtered(lambda p: p.state not in ('done', 'cancel'))[::-1]
            // wip_production = productions[0] if self._context.get('transfer_qty') and len(productions) > 1 else self.env['mrp.production']
            // 
            // # Transfer removed qty to WIP production
            // if wip_production:
            //     self.env['change.production.qty'].with_context(skip_activity=True).create({
            //         'mo_id': wip_production.id,
            //         'product_qty': wip_production.product_qty + quantity_to_remove
            //     }).change_prod_qty()
            // 
            // # Cancel productions until reach new_quantity
            // for production in (productions - wip_production):
            //     if quantity_to_remove >= production.product_qty:
            //         quantity_to_remove -= production.product_qty
            //         production.with_context(skip_activity=True).action_cancel()
            //     else:
            //         if float_is_zero(quantity_to_remove, precision_rounding=production.product_uom_id.rounding):
            //             # No need to do change_prod_qty for no change at all.
            //             break
            //         self.env['change.production.qty'].with_context(skip_activity=True).create({
            //             'mo_id': production.id,
            //             'product_qty': production.product_qty - quantity_to_remove
            //         }).change_prod_qty()
            //         break
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveDestsFetchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _rollup_move_dests_fetch(self):
            // seen = set(self.ids)
            // self.fetch(['move_dest_ids'])
            // move_dest_ids = set(self.move_dest_ids.ids)
            // while not move_dest_ids.issubset(seen):
            //     seen |= move_dest_ids
            //     to_visit = self.browse(move_dest_ids)
            //     to_visit.fetch(['move_dest_ids'])
            //     move_dest_ids = set(to_visit.move_dest_ids.ids)
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveDestsInternalAsync(object seen)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _rollup_move_dests(self, seen=False):
            // if not seen:
            //     seen = OrderedSet()
            // unseen = OrderedSet(self.ids) - seen
            // if not unseen:
            //     return seen
            // seen.update(unseen)
            // self.filtered(lambda m: m.id in unseen).move_dest_ids._rollup_move_dests(seen)
            // return seen
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveOrigsFetchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _rollup_move_origs_fetch(self):
            // seen = set(self.ids)
            // self.fetch(['move_orig_ids'])
            // move_orig_ids = set(self.move_orig_ids.ids)
            // while not move_orig_ids.issubset(seen):
            //     seen |= move_orig_ids
            //     to_visit = self.browse(move_orig_ids)
            //     to_visit.fetch(['move_orig_ids'])
            //     move_orig_ids = set(to_visit.move_orig_ids.ids)
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveOrigsInternalAsync(object seen)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _rollup_move_origs(self, seen=False):
            // if not seen:
            //     seen = OrderedSet()
            // unseen = OrderedSet(self.ids) - seen
            // if not unseen:
            //     return seen
            // seen.update(unseen)
            // self.filtered(lambda m: m.id in unseen).move_orig_ids._rollup_move_origs(seen)
            // return seen
            */
            return default;
        }

        protected async Task<StockMove> RunProcurementInternalAsync(object old_qties)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _run_procurement(self, old_qties=False):
            // procurements = []
            // old_qties = old_qties or {}
            // to_assign = self.env['stock.move']
            // self._adjust_procure_method()
            // for move in self:
            //     if float_compare(move.product_uom_qty - old_qties.get(move.id, 0), 0, precision_rounding=move.product_uom.rounding) < 0\
            //             and move.procure_method == 'make_to_order'\
            //             and all(m.state == 'done' for m in move.move_orig_ids):
            //         continue
            //     if float_compare(move.product_uom_qty, 0, precision_rounding=move.product_uom.rounding) > 0:
            //         if move._should_bypass_reservation() \
            //                 or move.picking_type_id.reservation_method == 'at_confirm' \
            //                 or (move.reservation_date and move.reservation_date <= fields.Date.today()):
            //             to_assign |= move
            // 
            //     if move.procure_method == 'make_to_order':
            //         procurement_qty = move.product_uom_qty - old_qties.get(move.id, 0)
            //         possible_reduceable_qty = -sum(move.move_orig_ids.filtered(lambda m: m.state not in ('done', 'cancel') and m.product_uom_qty).mapped('product_uom_qty'))
            //         procurement_qty = max(procurement_qty, possible_reduceable_qty)
            //         values = move._prepare_procurement_values()
            //         origin = move._prepare_procurement_origin()
            //         procurements.append(self.env['procurement.group'].Procurement(
            //             move.product_id, procurement_qty, move.product_uom,
            //             move.location_id, move.name, origin, move.company_id, values))
            // 
            // to_assign._action_assign()
            // if procurements:
            //     self.env['procurement.group'].run(procurements)
            */
            return default;
        }

        protected async Task<StockMove> SaleGetInvoicePriceInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py) ---
            // def _sale_get_invoice_price(self, order):
            // """ Based on the current stock move, compute the price to reinvoice the analytic line that is going to be created (so the
            //     price of the sale line).
            // """
            // self.ensure_one()
            // 
            // if self.product_id.expense_policy == 'sales_price':
            //     return order.pricelist_id._get_product_price(
            //         self.product_id,
            //         1.0,
            //         uom=self.product_uom,
            //         date=order.date_order,
            //     )
            // 
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // if float_is_zero(self.quantity, precision_digits=uom_precision_digits):
            //     return 0.0
            // 
            // price_unit = self.product_id.standard_price
            // # Prevent unnecessary currency conversion that could be impacted by exchange rate
            // # fluctuations
            // if self.company_id.currency_id and price_unit and self.company_id.currency_id == order.currency_id:
            //     return self.company_id.currency_id.round(price_unit)
            // 
            // currency_id = self.company_id.currency_id
            // if currency_id and currency_id != order.currency_id:
            //     price_unit = currency_id._convert(price_unit, order.currency_id, order.company_id, order.date_order or fields.Date.today())
            // return price_unit
            */
            return default;
        }

        protected async Task<StockMove> SalePrepareSaleLineValuesInternalAsync(object order, object price, object last_sequence)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py) ---
            // def _sale_prepare_sale_line_values(self, order, price, last_sequence):
            // """ Generate the sale.line creation value from the current stock move """
            // self.ensure_one()
            // 
            // fpos = order.fiscal_position_id or order.fiscal_position_id._get_fiscal_position(order.partner_id)
            // product_taxes = self.product_id.taxes_id._filter_taxes_by_company(order.company_id)
            // taxes = fpos.map_tax(product_taxes)
            // 
            // return {
            //     'order_id': order.id,
            //     'name': self.name,
            //     'sequence': last_sequence,
            //     'price_unit': price,
            //     'tax_id': [x.id for x in taxes],
            //     'discount': 0.0,
            //     'product_id': self.product_id.id,
            //     'product_uom_qty': self.product_uom_qty,
            //     'qty_delivered': self.quantity,
            // }
            */
            return default;
        }

        protected async Task<StockMove> SanityCheckForValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _sanity_check_for_valuation(self):
            // for move in self:
            //     # Apply restrictions on the stock move to be able to make
            //     # consistent accounting entries.
            //     if move._is_in() and move._is_out():
            //         raise UserError(_("The move lines are not in a consistent state: some are entering and other are leaving the company."))
            //     company_src = move.mapped('move_line_ids.location_id.company_id')
            //     company_dst = move.mapped('move_line_ids.location_dest_id.company_id')
            //     try:
            //         if company_src:
            //             company_src.ensure_one()
            //         if company_dst:
            //             company_dst.ensure_one()
            //     except ValueError:
            //         raise UserError(_("The move lines are not in a consistent states: they do not share the same origin or destination company."))
            //     if company_src and company_dst and company_src.id != company_dst.id:
            //         raise UserError(_("The move lines are not in a consistent states: they are doing an intercompany in a single step while they should go through the intercompany transit location."))
            */
            return default;
        }

        protected async Task<StockMove> SearchPickingForAssignationDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _search_picking_for_assignation_domain(self):
            // domain = [
            //     ('group_id', '=', self.group_id.id),
            //     ('location_id', '=', self.location_id.id),
            //     ('location_dest_id', '=', (self.location_dest_id.id or self.picking_type_id.default_location_dest_id.id)),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('printed', '=', False),
            //     ('state', 'in', ['draft', 'confirmed', 'waiting', 'partially_available', 'assigned'])]
            // if self.partner_id and not self.group_id:
            //     domain += [('partner_id', '=', self.partner_id.id)]
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def _search_picking_for_assignation_domain(self):
            // domain = super()._search_picking_for_assignation_domain()
            // domain = expression.AND([domain, ['|', ('batch_id', '=', False), ('batch_id.is_wave', '=', False)]])
            // return domain
            */
            return default;
        }

        protected async Task<StockMove> SearchPickingForAssignationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _search_picking_for_assignation(self):
            // self.ensure_one()
            // domain = self._search_picking_for_assignation_domain()
            // picking = self.env['stock.picking'].search(domain, limit=1)
            // return picking
            */
            return default;
        }

        protected async Task<StockMove> SetDateDeadlineInternalAsync(object new_deadline)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_date_deadline(self, new_deadline):
            // # Handle the propagation of `date_deadline` fields (up and down stream - only update by up/downstream documents)
            // already_propagate_ids = self.env.context.get('date_deadline_propagate_ids', set())
            // already_propagate_ids.update(self.ids)
            // self = self.with_context(date_deadline_propagate_ids=already_propagate_ids)
            // for move in self:
            //     moves_to_update = move._get_moves_to_propagate_date_deadline()
            //     if move.date_deadline:
            //         delta = move.date_deadline - fields.Datetime.to_datetime(new_deadline)
            //     else:
            //         delta = 0
            //     for move_update in moves_to_update:
            //         if move_update.state in ('done', 'cancel'):
            //             continue
            //         if move_update.id in already_propagate_ids:
            //             continue
            //         if move_update.date_deadline and delta:
            //             move_update.date_deadline -= delta
            //         else:
            //             move_update.date_deadline = new_deadline
            */
            return default;
        }

        protected async Task<StockMove> SetLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_location_dest_id(self):
            // for ml in self.move_line_ids:
            //     parent_path = [int(loc_id) for loc_id in ml.location_dest_id.parent_path.split('/')[:-1]]
            //     if ml.move_id.location_dest_id.id in parent_path:
            //         continue
            //     loc_dest = ml.move_id.location_dest_id._get_putaway_strategy(ml.product_id, ml.quantity_product_uom)
            //     ml.location_dest_id = loc_dest
            */
            return default;
        }

        protected async Task<StockMove> SetLotIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_lot_ids(self):
            // for move in self:
            //     if move.product_id.tracking != 'serial':
            //         continue
            //     move_lines_commands = []
            //     mls = move.move_line_ids
            //     mls_with_lots = mls.filtered(lambda ml: ml.lot_id)
            //     mls_without_lots = (mls - mls_with_lots)
            //     for ml in mls_with_lots:
            //         if ml.quantity and ml.lot_id not in move.lot_ids:
            //             move_lines_commands.append((2, ml.id))
            //     ls = move.move_line_ids.lot_id
            //     for lot in move.lot_ids:
            //         if lot not in ls:
            //             if mls_without_lots[:1]:  # Updates an existing line without serial number.
            //                 move_line = mls_without_lots[:1]
            //                 move_lines_commands.append(Command.update(move_line.id, {
            //                     'lot_name': lot.name,
            //                     'lot_id': lot.id,
            //                     'product_uom_id': move.product_id.uom_id.id,
            //                     'quantity': 1,
            //                 }))
            //                 mls_without_lots -= move_line
            //             else:  # No line without serial number, creates a new one.
            //                 reserved_quants = self.env['stock.quant']._get_reserve_quantity(move.product_id, move.location_id, 1.0, lot_id=lot)
            //                 if reserved_quants:
            //                     move_line_vals = self._prepare_move_line_vals(quantity=0, reserved_quant=reserved_quants[0][0])
            //                 else:
            //                     move_line_vals = self._prepare_move_line_vals(quantity=0)
            //                     move_line_vals['lot_id'] = lot.id
            //                     move_line_vals['lot_name'] = lot.name
            //                 move_line_vals['product_uom_id'] = move.product_id.uom_id.id
            //                 move_line_vals['quantity'] = 1
            //                 move_lines_commands.append((0, 0, move_line_vals))
            //         else:
            //             move_line = move.move_line_ids.filtered(lambda line: line.lot_id.id == lot.id)
            //             move_line.quantity = 1
            //     move.write({'move_line_ids': move_lines_commands})
            */
            return default;
        }

        protected async Task<StockMove> SetProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_product_qty(self):
            // """ The meaning of product_qty field changed lately and is now a functional field computing the quantity
            // in the default product UoM. This code has been added to raise an error if a write is made given a value
            // for `product_qty`, where the same write should set the `product_uom_qty` field instead, in order to
            // detect errors. """
            // raise UserError(_('The requested operation cannot be processed because of a programming error setting the `product_qty` field instead of the `product_uom_qty`.'))
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityDoneInternalAsync(object qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _set_quantity_done(self, qty):
            // to_set_moves = self
            // for move in self:
            //     if move.is_subcontract and move._subcontracting_possible_record():
            //         # If 'done' quantity is changed through the move, record components as if done through the wizard.
            //         move._auto_record_components(qty)
            //         to_set_moves -= move
            // if to_set_moves:
            //     super(StockMove, to_set_moves)._set_quantity_done(qty)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_quantity_done(self, qty):
            // """
            // Set the given quantity as quantity done on the move through the move lines. The method is
            // able to handle move lines with a different UoM than the move (but honestly, this would be
            // looking for trouble...).
            // @param qty: quantity in the UoM of move.product_uom
            // """
            // existing_smls = self.move_line_ids
            // self.move_line_ids = self._set_quantity_done_prepare_vals(qty)
            // # `_set_quantity_done_prepare_vals` may return some commands to create new SMLs
            // # These new SMLs need to be redirected thanks to putaway rules
            // (self.move_line_ids - existing_smls)._apply_putaway_strategy()
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityDonePrepareValsInternalAsync(object qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_quantity_done_prepare_vals(self, qty):
            // res = []
            // for ml in self.move_line_ids:
            //     ml_qty = ml.quantity
            //     if float_is_zero(qty, precision_rounding=self.product_uom.rounding):
            //         res.append((2, ml.id))
            //         continue
            //     if float_compare(ml_qty, 0, precision_rounding=ml.product_uom_id.rounding) <= 0:
            //         continue
            //     # Convert move line qty into move uom
            //     if ml.product_uom_id != self.product_uom:
            //         ml_qty = ml.product_uom_id._compute_quantity(ml_qty, self.product_uom, round=False)
            // 
            //     taken_qty = min(qty, ml_qty)
            //     # Convert taken qty into move line uom
            //     if ml.product_uom_id != self.product_uom:
            //         taken_qty = self.product_uom._compute_quantity(taken_qty, ml.product_uom_id, round=False)
            // 
            //     # Assign qty_done and explicitly round to make sure there is no inconsistency between
            //     # ml.qty_done and qty.
            //     taken_qty = float_round(taken_qty, precision_rounding=ml.product_uom_id.rounding)
            //     res.append((1, ml.id, {'quantity': taken_qty}))
            //     if ml.product_uom_id != self.product_uom:
            //         taken_qty = ml.product_uom_id._compute_quantity(taken_qty, self.product_uom, round=False)
            //     qty -= taken_qty
            // 
            // if float_compare(qty, 0.0, precision_rounding=self.product_uom.rounding) > 0:
            //     if self.product_id.tracking != 'serial':
            //         vals = self._prepare_move_line_vals(quantity=0)
            //         vals['quantity'] = qty
            //         res.append((0, 0, vals))
            //     else:
            //         uom_qty = self.product_uom._compute_quantity(qty, self.product_id.uom_id)
            //         for i in range(0, int(uom_qty)):
            //             vals = self._prepare_move_line_vals(quantity=0)
            //             vals['quantity'] = 1
            //             vals['product_uom_id'] = self.product_id.uom_id.id
            //             res.append((0, 0, vals))
            // return res
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _set_quantity(self):
            // to_set_moves = self
            // for move in self:
            //     if move.is_subcontract and move._subcontracting_possible_record():
            //         move_line_quantities = sum(move.move_line_ids.filtered(lambda ml: ml.picked).mapped('quantity'))
            //         delta_qty = move.quantity - move_line_quantities
            //         if float_compare(delta_qty, 0, precision_rounding=move.product_uom.rounding) > 0:
            //             move._auto_record_components(delta_qty)
            //             to_set_moves -= move
            //         elif float_compare(delta_qty, 0, precision_rounding=move.product_uom.rounding) < 0:
            //             move.with_context(transfer_qty=True)._reduce_subcontract_order_qty(abs(delta_qty))
            // if to_set_moves:
            //     super(StockMove, to_set_moves)._set_quantity()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_quantity(self):
            //         def _process_decrease(move, quantity):
            //             mls_to_unlink = set()
            //             # Since the move lines might have been created in a certain order to respect
            //             # a removal strategy, they need to be unreserved in the opposite order
            //             for ml in reversed(move.move_line_ids.sorted('id')):
            //                 if self.env.context.get('unreserve_unpicked_only') and ml.picked:
            //                     continue
            //                 if float_is_zero(quantity, precision_rounding=move.product_uom.rounding):
            //                     break
            //                 qty_ml_dec = min(ml.quantity, ml.product_uom_id._compute_quantity(quantity, ml.product_uom_id, round=False))
            //                 if float_is_zero(qty_ml_dec, precision_rounding=ml.product_uom_id.rounding):
            //                     continue
            //                 if float_compare(ml.quantity, qty_ml_dec, precision_rounding=ml.product_uom_id.rounding) == 0 and ml.state not in ['done', 'cancel']:
            //                     mls_to_unlink.add(ml.id)
            //                 else:
            //                     ml.quantity -= qty_ml_dec
            //                 quantity -= move.product_uom._compute_quantity(qty_ml_dec, move.product_uom, round=False)
            //             self.env['stock.move.line'].browse(mls_to_unlink).unlink()
            // 
            //         def _process_increase(move, quantity):
            //             # move._action_assign(quantity)
            //             move._set_quantity_done(move.quantity)
            // 
            //         err = []
            //         for move in self:
            //             uom_qty = float_round(move.quantity, precision_rounding=move.product_uom.rounding, rounding_method='HALF-UP')
            //             precision_digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //             qty = float_round(move.quantity, precision_digits=precision_digits, rounding_method='HALF-UP')
            //             if float_compare(uom_qty, qty, precision_digits=precision_digits) != 0:
            //                 err.append(_("""
            // The quantity done for the product %(product)s doesn't respect the rounding precision defined on the unit of measure %(unit)s.
            // Please change the quantity done or the rounding precision of your unit of measure.""",
            //                              product=move.product_id.display_name, unit=move.product_uom.display_name))
            //                 continue
            //             delta_qty = move.quantity - move._quantity_sml()
            //             if float_compare(delta_qty, 0, precision_rounding=move.product_uom.rounding) > 0:
            //                 _process_increase(move, delta_qty)
            //             elif float_compare(delta_qty, 0, precision_rounding=move.product_uom.rounding) < 0:
            //                 _process_decrease(move, abs(delta_qty))
            //         if err:
            //             raise UserError('\n'.join(err))
            */
            return default;
        }

        protected async Task<StockMove> SetRepairLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _set_repair_locations(self):
            // moves_per_repair = self.filtered(lambda m: (m.repair_id and m.repair_line_type) is not False).grouped('repair_id')
            // if not moves_per_repair:
            //     return
            // for moves in moves_per_repair.values():
            //     grouped_moves = moves.grouped('repair_line_type')
            //     for line_type, m in grouped_moves.items():
            //         m.location_id, m.location_dest_id = m._get_repair_locations(line_type)
            */
            return default;
        }

        protected async Task<StockMove> ShouldAssignAtConfirmInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _should_assign_at_confirm(self):
            // return self._should_bypass_reservation() or self.picking_type_id.reservation_method == 'at_confirm' or (self.reservation_date and self.reservation_date <= fields.Date.today())
            */
            return default;
        }

        protected async Task<StockMove> ShouldBeAssignedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _should_be_assigned(self):
            // res = super(StockMove, self)._should_be_assigned()
            // return bool(res and not (self.production_id or self.raw_material_production_id))
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _should_be_assigned(self):
            // if self.repair_id:
            //     return False
            // return super()._should_be_assigned()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _should_be_assigned(self):
            // self.ensure_one()
            // return bool(not self.picking_id and self.picking_type_id)
            */
            return default;
        }

        protected async Task<StockMove> ShouldBypassReservationInternalAsync(object forced_location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _should_bypass_reservation(self, forced_location=False):
            // return super()._should_bypass_reservation(forced_location) or self.product_id.with_company(self.company_id).is_kits
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _should_bypass_reservation(self, forced_location=False):
            // """ If the move is subcontracted then ignore the reservation. """
            // should_bypass_reservation = super()._should_bypass_reservation(forced_location=forced_location)
            // if not should_bypass_reservation and self.is_subcontract:
            //     return True
            // return should_bypass_reservation
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _should_bypass_reservation(self, forced_location=False):
            // self.ensure_one()
            // location = forced_location or self.location_id
            // return location.should_bypass_reservation() or not self.product_id.is_storable
            */
            return default;
        }

        protected async Task<StockMove> ShouldBypassSetQtyProducingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _should_bypass_set_qty_producing(self):
            // if self.state in ('done', 'cancel'):
            //     return True
            // # Do not update extra product quantities
            // if float_is_zero(self.product_uom_qty, precision_rounding=self.product_uom.rounding):
            //     return True
            // return False
            */
            return default;
        }

        protected async Task<StockMove> ShouldExcludeForValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _should_exclude_for_valuation(self):
            // """Determines if this move should be excluded from valuation based on its partner.
            // :return: True if the move's restrict_partner_id is different from the company's partner (indicating
            //         it should be excluded from valuation), False otherwise.
            // """
            // self.ensure_one()
            // return self.restrict_partner_id and self.restrict_partner_id != self.company_id.partner_id
            */
            return default;
        }

        protected async Task<StockMove> ShouldForcePriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _should_force_price_unit(self):
            // self.ensure_one()
            // return ((self.picking_type_id.code == 'mrp_operation' and self.production_id) or
            //         super()._should_force_price_unit()
            // )
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: stock_move.py) ---
            // def _should_force_price_unit(self):
            // self.ensure_one()
            // return self.is_subcontract or super()._should_force_price_unit()
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _should_force_price_unit(self):
            // self.ensure_one()
            // return False
            */
            return default;
        }

        protected async Task<StockMove> ShouldIgnorePolPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _should_ignore_pol_price(self):
            // self.ensure_one()
            // return self.origin_returned_move_id or not self.purchase_line_id or not self.product_id.id
            */
            return default;
        }

        public async Task<StockMove> ShowDetailsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def action_show_details(self):
            // self.ensure_one()
            // action = super().action_show_details()
            // if self.raw_material_production_id:
            //     action['views'] = [(self.env.ref('mrp.view_stock_move_operations_raw').id, 'form')]
            //     action['context']['show_destination_location'] = False
            //     action['context']['force_manual_consumption'] = True
            //     action['context']['active_mo_id'] = self.raw_material_production_id.id
            // elif self.production_id:
            //     action['views'] = [(self.env.ref('mrp.view_stock_move_operations_finished').id, 'form')]
            //     action['context']['show_source_location'] = False
            //     action['context']['show_reserved_quantity'] = False
            // return action
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def action_show_details(self):
            // """ Open the produce wizard in order to register tracked components for
            // subcontracted product. Otherwise use standard behavior.
            // """
            // self.ensure_one()
            // if self.state != 'done' and (self._subcontrating_should_be_record() or self._subcontrating_can_be_record()):
            //     return self._action_record_components()
            // action = super(StockMove, self).action_show_details()
            // if self.is_subcontract and all(p._has_been_recorded() for p in self._get_subcontract_production()):
            //     action['views'] = [(self.env.ref('stock.view_stock_move_operations').id, 'form')]
            //     action['context'].update({
            //         'show_lots_m2o': self.has_tracking != 'none',
            //         'show_lots_text': False,
            //     })
            // elif self.env.user._is_portal():
            //     action['views'] = [(self.env.ref('mrp_subcontracting.mrp_subcontracting_view_stock_move_operations').id, 'form')]
            // return action
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def action_show_details(self):
            // action = super().action_show_details()
            // if self.repair_line_type == 'recycle':
            //     action['context'].update({'show_quant': False, 'show_destination_location': True})
            // return action
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_show_details(self):
            // """ Returns an action that will open a form view (in a popup) allowing to work on all the
            // move lines of a particular move. This form view is used when "show operations" is not
            // checked on the picking type.
            // """
            // self.ensure_one()
            // view = self.env.ref('stock.view_stock_move_operations')
            // 
            // return {
            //     'name': _('Detailed Operations'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'stock.move',
            //     'views': [(view.id, 'form')],
            //     'view_id': view.id,
            //     'target': 'new',
            //     'res_id': self.id,
            //     'context': dict(
            //         self.env.context,
            //     ),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMove> ShowSubcontractDetailsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def action_show_subcontract_details(self):
            // """ Display moves raw for subcontracted product self. """
            // moves = self._get_subcontract_production().move_raw_ids.filtered(lambda m: m.state != 'cancel')
            // list_view = self.env.ref('mrp_subcontracting.mrp_subcontracting_move_tree_view')
            // form_view = self.env.ref('mrp_subcontracting.mrp_subcontracting_move_form_view')
            // ctx = dict(self._context, search_default_by_product=True)
            // if self.env.user._is_portal():
            //     form_view = self.env.ref('mrp_subcontracting.mrp_subcontracting_portal_move_form_view')
            //     ctx.update(no_breadcrumbs=False)
            // return {
            //     'name': _('Raw Materials for %s', self.product_id.display_name),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.move',
            //     'views': [(list_view.id, 'list'), (form_view.id, 'form')],
            //     'target': 'current',
            //     'domain': [('id', 'in', moves.ids)],
            //     'context': ctx
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> SkipPushInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _skip_push(self):
            // return self.is_inventory or (
            //     self.move_dest_ids and any(m.location_id._child_of(self.location_dest_id) for m in self.move_dest_ids)
            // )
            */
            return default;
        }

        protected async Task<StockMove> SplitInternalAsync(object qty, Guid restrict_partner_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _split(self, qty, restrict_partner_id=False):
            // # When setting the Repair Order as done with partially done moves, do not split these moves
            // if self.repair_id:
            //     return []
            // return super(StockMove, self)._split(qty, restrict_partner_id)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _split(self, qty, restrict_partner_id=False):
            // """ Splits `self` quantity and return values for a new moves to be created afterwards
            // 
            // :param qty: float. quantity to split (given in product UoM)
            // :param restrict_partner_id: optional partner that can be given in order to force the new move to restrict its choice of quants to the ones belonging to this partner.
            // :returns: list of dict. stock move values """
            // self.ensure_one()
            // if self.state in ('done', 'cancel'):
            //     raise UserError(_('You cannot split a stock move that has been set to \'Done\' or \'Cancel\'.'))
            // elif self.state == 'draft':
            //     # we restrict the split of a draft move because if not confirmed yet, it may be replaced by several other moves in
            //     # case of phantom bom (with mrp module). And we don't want to deal with this complexity by copying the product that will explode.
            //     raise UserError(_('You cannot split a draft move. It needs to be confirmed first.'))
            // 
            // if float_is_zero(qty, precision_rounding=self.product_id.uom_id.rounding):
            //     return []
            // 
            // decimal_precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // 
            // # `qty` passed as argument is the quantity to backorder and is always expressed in the
            // # quants UOM. If we're able to convert back and forth this quantity in the move's and the
            // # quants UOM, the backordered move can keep the UOM of the move. Else, we'll create is in
            // # the UOM of the quants.
            // uom_qty = self.product_id.uom_id._compute_quantity(qty, self.product_uom, rounding_method='HALF-UP')
            // if float_compare(qty, self.product_uom._compute_quantity(uom_qty, self.product_id.uom_id, rounding_method='HALF-UP'), precision_digits=decimal_precision) == 0:
            //     defaults = self._prepare_move_split_vals(uom_qty)
            // else:
            //     defaults = self.with_context(force_split_uom_id=self.product_id.uom_id.id)._prepare_move_split_vals(qty)
            // 
            // if restrict_partner_id:
            //     defaults['restrict_partner_id'] = restrict_partner_id
            // 
            // # TDE CLEANME: remove context key + add as parameter
            // if self.env.context.get('source_location_id'):
            //     defaults['location_id'] = self.env.context['source_location_id']
            // new_move_vals = self.copy_data(defaults)
            // 
            // # Update the original `product_qty` of the move. Use the general product's decimal
            // # precision and not the move's UOM to handle case where the `quantity_done` is not
            // # compatible with the move's UOM.
            // new_product_qty = self.product_id.uom_id._compute_quantity(max(0, self.product_qty - qty), self.product_uom, round=False)
            // new_product_qty = float_round(new_product_qty, precision_digits=self.env['decimal.precision'].precision_get('Product Unit of Measure'))
            // self.with_context(do_not_unreserve=True).write({'product_uom_qty': new_product_qty})
            // return new_move_vals
            */
            return default;
        }

        public async Task<StockMove> SplitLotsAsync(Guid id, StockMoveSplitLotsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def split_lots(self, lots):
            // breaking_char = '\n'
            // separation_char = '\t'
            // options = False
            // 
            // if not lots:
            //     return []  # Skip if the `lot_name` doesn't contain multiple values.
            // 
            // # Checks the lines and prepares the move lines' values.
            // split_lines = lots.split(breaking_char)
            // split_lines = list(filter(None, split_lines))
            // move_lines_vals = []
            // for lot_text in split_lines:
            //     move_line_vals = {
            //         'lot_name': lot_text,
            //         'quantity': 1,
            //     }
            //     # Semicolons are also used for separation but for convenience we
            //     # replace them to work only with tabs.
            //     lot_text_parts = lot_text.replace(';', separation_char).split(separation_char)
            //     options = options or self._get_formating_options(lot_text_parts[1:])
            //     for extra_string in lot_text_parts[1:]:
            //         field_data = self._convert_string_into_field_data(extra_string, options)
            //         if field_data:
            //             lot_text = lot_text_parts[0]
            //             if field_data == "ignore":
            //                 # Got an unusable data for this move, updates only the lot_name part.
            //                 move_line_vals.update(lot_name=lot_text)
            //             else:
            //                 move_line_vals.update(**field_data, lot_name=lot_text)
            //         else:
            //             # At least this part of the string is erronous and can't be converted,
            //             # don't try to guess and simply use the full string as the lot name.
            //             move_line_vals['lot_name'] = lot_text
            //             break
            //     move_lines_vals.append(move_line_vals)
            // return move_lines_vals
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMove> SubcontractingPossibleRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _subcontracting_possible_record(self):
            // return self._get_subcontract_production().filtered(lambda p: p._has_tracked_component() or p.consumption != 'strict')
            */
            return default;
        }

        protected async Task<StockMove> SubcontratingCanBeRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _subcontrating_can_be_record(self):
            // return self._get_subcontract_production().filtered(lambda p: not p._has_been_recorded() and p.consumption != 'strict')
            */
            return default;
        }

        protected async Task<StockMove> SubcontratingShouldBeRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _subcontrating_should_be_record(self):
            // return self._get_subcontract_production().filtered(lambda p: not p._has_been_recorded() and p._has_tracked_component())
            */
            return default;
        }

        protected async Task<StockMove> TriggerAssignInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _trigger_assign(self):
            // """ Check for and trigger action_assign for confirmed/partially_available moves related to done moves.
            //     Disable auto reservation if user configured to do so.
            // """
            // if not self or self.env['ir.config_parameter'].sudo().get_param('stock.picking_no_auto_reserve'):
            //     return
            // 
            // domains = [
            //     [('product_id', '=', move.product_id.id), ('location_id', '=', move.location_dest_id.id)]
            //     for move in self
            // ]
            // static_domain = [('state', 'in', ['confirmed', 'partially_available']),
            //                  ('procure_method', '=', 'make_to_stock'),
            //                  '|',
            //                     ('reservation_date', '<=', fields.Date.today()),
            //                     ('picking_type_id.reservation_method', '=', 'at_confirm')
            //                 ]
            // moves_to_reserve = self.env['stock.move'].search(expression.AND([static_domain, expression.OR(domains)]),
            //                                                  order='priority desc, date asc, id asc')
            // moves_to_reserve = moves_to_reserve.sorted(key=lambda m: m.group_id.id in self.group_id.ids, reverse=True)
            // moves_to_reserve._action_assign()
            */
            return default;
        }

        protected async Task<StockMove> TriggerSchedulerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _trigger_scheduler(self):
            // """ Check for auto-triggered orderpoints and trigger them. """
            // if not self or self.env['ir.config_parameter'].sudo().get_param('stock.no_auto_scheduler'):
            //     return
            // 
            // orderpoints_by_company = defaultdict(lambda: self.env['stock.warehouse.orderpoint'])
            // orderpoints_context_by_company = defaultdict(dict)
            // for move in self:
            //     orderpoint = self.env['stock.warehouse.orderpoint'].search([
            //         ('product_id', '=', move.product_id.id),
            //         ('trigger', '=', 'auto'),
            //         ('location_id', 'parent_of', move.location_id.id),
            //         ('company_id', '=', move.company_id.id),
            //         '!', ('location_id', 'parent_of', move.location_dest_id.id),
            //     ], limit=1)
            //     if orderpoint:
            //         orderpoints_by_company[orderpoint.company_id] |= orderpoint
            //     if orderpoint and move.product_qty > orderpoint.product_min_qty and move.origin:
            //         orderpoints_context_by_company[orderpoint.company_id].setdefault(orderpoint.id, [])
            //         orderpoints_context_by_company[orderpoint.company_id][orderpoint.id].append(move.origin)
            // for company, orderpoints in orderpoints_by_company.items():
            //     orderpoints.with_context(origins=orderpoints_context_by_company[company])._procure_orderpoint_confirm(
            //         company_id=company, raise_user_error=False)
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def unlink(self):
            // self._clean_repair_sale_order_line()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def unlink(self):
            // # With the non plannified picking, draft moves could have some move lines.
            // self.with_context(prefetch_fields=False).mapped('move_line_ids').unlink()
            // return super(StockMove, self).unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<StockMove> UnlinkIfDraftOrCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _unlink_if_draft_or_cancel(self):
            // self.filtered('repair_id')._action_cancel()
            // return super()._unlink_if_draft_or_cancel()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _unlink_if_draft_or_cancel(self):
            // if any(move.state not in ('draft', 'cancel') and (move.move_orig_ids or move.move_dest_ids) for move in self):
            //     raise UserError(_('You can not delete moves linked to another operation'))
            */
            return default;
        }

        protected async Task<StockMove> UpdateCandidateMovesListInternalAsync(object candidate_moves_set)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _update_candidate_moves_list(self, candidate_moves_set):
            // super()._update_candidate_moves_list(candidate_moves_set)
            // for production in self.mapped('raw_material_production_id'):
            //     candidate_moves_set.add(production.move_raw_ids.filtered(lambda m: m.product_id in self.product_id))
            // for production in self.mapped('production_id'):
            //     candidate_moves_set.add(production.move_finished_ids.filtered(lambda m: m.product_id in self.product_id))
            // # this will include sibling pickings as a result of merging MOs
            // for picking in self.move_dest_ids.raw_material_production_id.picking_ids:
            //     candidate_moves_set.add(picking.move_ids)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _update_candidate_moves_list(self, candidate_moves_set):
            // for picking in self.mapped('picking_id'):
            //     candidate_moves_set.add(picking.move_ids)
            */
            return default;
        }

        protected async Task<StockMove> UpdateRepairSaleOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _update_repair_sale_order_line(self):
            // if not self:
            //     return
            // moves_to_clean = self.env['stock.move']
            // moves_to_update = self.env['stock.move']
            // for move in self:
            //     if not move.repair_id:
            //         continue
            //     if move.sale_line_id and move.repair_line_type != 'add':
            //         moves_to_clean |= move
            //     if move.sale_line_id and move.repair_line_type == 'add':
            //         moves_to_update |= move
            // moves_to_clean._clean_repair_sale_order_line()
            // for sale_line, _ in groupby(moves_to_update, lambda m: m.sale_line_id):
            //     sale_line.product_uom_qty = sum(sale_line.move_ids.mapped('product_uom_qty'))
            */
            return default;
        }

        protected async Task<StockMove> UpdateReservedQuantityInternalAsync(object need, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def _update_reserved_quantity(self, need, location_id, lot_id=None, package_id=None, owner_id=None, strict=True):
            // if self.product_id.use_expiration_date:
            //     return super(StockMove, self.with_context(with_expiration=self.date))._update_reserved_quantity(need, location_id, lot_id, package_id, owner_id, strict)
            // return super()._update_reserved_quantity(need, location_id, lot_id, package_id, owner_id, strict)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _update_reserved_quantity(self, need, location_id, lot_id=None, package_id=None, owner_id=None, strict=True):
            // """ Create or update move lines and reserves quantity from quants
            //     Expects the need (qty to reserve) and location_id to reserve from.
            //     `quant_ids` can be passed as an optimization since no search on the database
            //     is performed and reservation is done on the passed quants set
            // """
            // self.ensure_one()
            // if not lot_id:
            //     lot_id = self.env['stock.lot']
            // if not package_id:
            //     package_id = self.env['stock.quant.package']
            // if not owner_id:
            //     owner_id = self.env['res.partner']
            // 
            // quants = self.env['stock.quant']._get_reserve_quantity(
            //     self.product_id, location_id, need, product_packaging_id=self.product_packaging_id,
            //     uom_id=self.product_uom, lot_id=lot_id, package_id=package_id, owner_id=owner_id, strict=strict)
            // 
            // taken_quantity = 0
            // rounding = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // # Find a candidate move line to update or create a new one.
            // candidate_lines = {}
            // for line in self.move_line_ids:
            //     if line.result_package_id or line.product_id.tracking == 'serial':
            //         continue
            //     candidate_lines[line.location_id, line.lot_id, line.package_id, line.owner_id] = line
            // move_line_vals = []
            // grouped_quants = {}
            // # Handle quants duplication
            // for quant, quantity in quants:
            //     if (quant.location_id, quant.lot_id, quant.package_id, quant.owner_id) not in grouped_quants:
            //         grouped_quants[quant.location_id, quant.lot_id, quant.package_id, quant.owner_id] = [quant, quantity]
            //     else:
            //         grouped_quants[quant.location_id, quant.lot_id, quant.package_id, quant.owner_id][1] += quantity
            // for reserved_quant, quantity in grouped_quants.values():
            //     taken_quantity += quantity
            //     to_update = candidate_lines.get((reserved_quant.location_id, reserved_quant.lot_id, reserved_quant.package_id, reserved_quant.owner_id))
            //     if to_update:
            //         uom_quantity = self.product_id.uom_id._compute_quantity(quantity, to_update.product_uom_id, rounding_method='HALF-UP')
            //         uom_quantity = float_round(uom_quantity, precision_digits=rounding)
            //         uom_quantity_back_to_product_uom = to_update.product_uom_id._compute_quantity(uom_quantity, self.product_id.uom_id, rounding_method='HALF-UP')
            //     if to_update and float_compare(quantity, uom_quantity_back_to_product_uom, precision_digits=rounding) == 0:
            //         to_update.with_context(reserved_quant=reserved_quant).quantity += uom_quantity
            //     else:
            //         if self.product_id.tracking == 'serial' and (self.picking_type_id.use_create_lots or self.picking_type_id.use_existing_lots):
            //             vals_list = self._add_serial_move_line_to_vals_list(reserved_quant, quantity)
            //             if vals_list:
            //                 move_line_vals += vals_list
            //         else:
            //             move_line_vals.append(self._prepare_move_line_vals(quantity=quantity, reserved_quant=reserved_quant))
            // if move_line_vals:
            //     self.env['stock.move.line'].create(move_line_vals)
            // return taken_quantity
            */
            return default;
        }

        protected async Task<StockMove> UpdateSubcontractOrderQtyInternalAsync(object new_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _update_subcontract_order_qty(self, new_quantity):
            // for move in self:
            //     quantity_to_remove = move.product_uom_qty - new_quantity
            //     if not float_is_zero(quantity_to_remove, precision_rounding=move.product_uom.rounding):
            //         move._reduce_subcontract_order_qty(quantity_to_remove)
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, StockMove entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def write(self, vals):
            // if 'product_id' in vals:
            //     move_to_unlink = self.filtered(lambda m: m.product_id.id != vals.get('product_id'))
            //     other_move = self - move_to_unlink
            //     if move_to_unlink.production_id and move_to_unlink.state not in ['draft', 'cancel', 'done']:
            //         moves_data = move_to_unlink.copy_data()
            //         for move_data in moves_data:
            //             move_data.update({'product_id': vals.get('product_id')})
            //         updated_product_move = self.create(moves_data)
            //         updated_product_move._action_confirm()
            //         move_to_unlink.unlink()
            //         self = other_move + updated_product_move
            // if self.env.context.get('force_manual_consumption'):
            //     vals['manual_consumption'] = True
            // if 'product_uom_qty' in vals and 'move_line_ids' in vals:
            //     # first update lines then product_uom_qty as the later will unreserve
            //     # so possibly unlink lines
            //     move_line_vals = vals.pop('move_line_ids')
            //     super().write({'move_line_ids': move_line_vals})
            // old_demand = {move.id: move.product_uom_qty for move in self}
            // res = super().write(vals)
            // if 'product_uom_qty' in vals and not self.env.context.get('no_procurement', False):
            //     # when updating consumed qty need to update related pickings
            //     # context no_procurement means we don't want the qty update to modify stock i.e create new pickings
            //     # ex. when spliting MO to backorders we don't want to move qty from pre prod to stock in 2/3 step config
            //     self.filtered(lambda m: m.raw_material_production_id.state in ('confirmed', 'progress', 'to_close'))._run_procurement(old_demand)
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def write(self, values):
            // """ If the initial demand is updated then also update the linked
            // subcontract order to the new quantity.
            // """
            // self._check_access_if_subcontractor(values)
            // if 'product_uom_qty' in values and self.env.context.get('cancel_backorder') is not False and not self._context.get('extra_move_mode'):
            //     self.filtered(
            //         lambda m: m.is_subcontract and m.state not in ['draft', 'cancel', 'done']
            //         and float_compare(m.product_uom_qty, values['product_uom_qty'], precision_rounding=m.product_uom.rounding) != 0
            //     )._update_subcontract_order_qty(values['product_uom_qty'])
            // res = super().write(values)
            // if 'date' in values:
            //     for move in self:
            //         if move.state in ('done', 'cancel') or not move.is_subcontract:
            //             continue
            //         move.move_orig_ids.production_id.with_context(from_subcontract=True).filtered(lambda p: p.state not in ('done', 'cancel')).write({
            //             'date_start': move.date,
            //             'date_finished': move.date,
            //         })
            // return res
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // repair_moves = self.env['stock.move']
            // moves_to_create_so_line = self.env['stock.move']
            // for move in self:
            //     if not move.repair_id:
            //         continue
            //     # checks vals update
            //     if not move.sale_line_id and 'sale_line_id' not in vals and move.repair_line_type == 'add':
            //         moves_to_create_so_line |= move
            //     if move.sale_line_id and ('repair_line_type' in vals or 'product_uom_qty' in vals):
            //         repair_moves |= move
            // 
            // repair_moves._update_repair_sale_order_line()
            // moves_to_create_so_line._create_repair_sale_order_line()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def write(self, vals):
            // # Handle the write on the initial demand by updating the reserved quantity and logging
            // # messages according to the state of the stock.move records.
            // receipt_moves_to_reassign = self.env['stock.move']
            // move_to_recompute_state = self.env['stock.move']
            // move_to_check_location = self.env['stock.move']
            // if 'quantity' in vals:
            //     if any(move.state == 'cancel' for move in self):
            //         raise UserError(_('You cannot change a cancelled stock move, create a new line instead.'))
            // if 'product_uom' in vals and any(move.state == 'done' for move in self):
            //     raise UserError(_('You cannot change the UoM for a stock move that has been set to \'Done\'.'))
            // if 'product_uom_qty' in vals:
            //     for move in self.filtered(lambda m: m.state not in ('done', 'draft') and m.picking_id):
            //         if float_compare(vals['product_uom_qty'], move.product_uom_qty, precision_rounding=move.product_uom.rounding):
            //             self.env['stock.move.line']._log_message(move.picking_id, move, 'stock.track_move_template', vals)
            //     if self.env.context.get('do_not_unreserve') is None:
            //         move_to_unreserve = self.filtered(
            //             lambda m: m.state not in ['draft', 'done', 'cancel'] and float_compare(m.quantity, vals.get('product_uom_qty'), precision_rounding=m.product_uom.rounding) == 1
            //         )
            //         move_to_unreserve._do_unreserve()
            //         (self - move_to_unreserve).filtered(lambda m: m.state == 'assigned').write({'state': 'partially_available'})
            //         # When editing the initial demand, directly run again action assign on receipt moves.
            //         receipt_moves_to_reassign |= move_to_unreserve.filtered(lambda m: m.location_id.usage == 'supplier')
            //         receipt_moves_to_reassign |= (self - move_to_unreserve).filtered(
            //             lambda m:
            //                 m.location_id.usage == 'supplier' and
            //                 m.state in ('partially_available', 'assigned')
            //         )
            //         move_to_recompute_state |= self - move_to_unreserve - receipt_moves_to_reassign
            // # propagate product_packaging_id changes in the stock move chain
            // if 'product_packaging_id' in vals:
            //     self._propagate_product_packaging(vals['product_packaging_id'])
            // if 'date_deadline' in vals:
            //     self._set_date_deadline(vals.get('date_deadline'))
            // if 'move_orig_ids' in vals:
            //     move_to_recompute_state |= self.filtered(lambda m: m.state not in ['draft', 'cancel', 'done'])
            // if 'location_id' in vals:
            //     move_to_check_location = self.filtered(lambda m: m.location_id.id != vals.get('location_id'))
            // if 'picking_id' in vals and 'group_id' not in vals:
            //     picking = self.env['stock.picking'].browse(vals['picking_id'])
            //     if picking.group_id:
            //         vals['group_id'] = picking.group_id.id
            // res = super(StockMove, self).write(vals)
            // if move_to_recompute_state:
            //     move_to_recompute_state._recompute_state()
            // if move_to_check_location:
            //     for ml in move_to_check_location.move_line_ids:
            //         parent_path = [int(loc_id) for loc_id in ml.location_id.parent_path.split('/')[:-1]]
            //         if move_to_check_location.location_id.id not in parent_path:
            //             receipt_moves_to_reassign |= move_to_check_location
            //             move_to_check_location.procure_method = 'make_to_stock'
            //             move_to_check_location.move_orig_ids = [Command.clear()]
            //             ml.unlink()
            // if 'location_id' in vals or 'location_dest_id' in vals:
            //     wh_by_moves = defaultdict(self.env['stock.move'].browse)
            //     for move in self:
            //         move_warehouse = move.location_id.warehouse_id or move.location_dest_id.warehouse_id
            //         if move_warehouse == move.warehouse_id:
            //             continue
            //         wh_by_moves[move_warehouse] |= move
            //     for warehouse, moves in wh_by_moves.items():
            //         moves.warehouse_id = warehouse.id
            // if receipt_moves_to_reassign:
            //     receipt_moves_to_reassign._action_assign()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'state' in vals and vals['state'] == 'assigned':
            //     for picking in self.picking_id:
            //         if picking.state != 'assigned':
            //             continue
            //         picking._find_auto_batch()
            // 
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}