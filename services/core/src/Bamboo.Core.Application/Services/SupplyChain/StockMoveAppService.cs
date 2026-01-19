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
    public partial class StockMoveAppService : GenericApplicationService<StockMove>, IStockMoveAppService
    {

        public StockMoveAppService(IRepository<StockMove, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

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
            //                 if move.product_id.uom_id.is_zero(missing_reserved_quantity):
            //                     break
            // 
            //         if missing_reserved_quantity and move.product_id.tracking == 'serial' and (move.picking_type_id.use_create_lots or move.picking_type_id.use_existing_lots):
            //             for _i in range(int(missing_reserved_quantity)):
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
            //         if move.product_uom.is_zero(move.product_uom_qty) and not force_qty:
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
            //             taken_quantity = move._update_reserved_quantity(need, move.location_id, strict=False)
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
            // 
            //             taken_quantities = {}
            //             all_move_line_vals = []
            //             for (location_id, lot_id, package_id, owner_id), quantity in available_move_lines.items():
            //                 need = move.product_qty - sum(move.move_line_ids.mapped('quantity_product_uom')) - sum(taken_quantities.values())
            //                 move_line_vals, taken_quantity = move._update_reserved_quantity_vals(min(quantity, need), location_id, lot_id, package_id, owner_id, strict=True)
            //                 all_move_line_vals += move_line_vals
            //                 if move_line_vals:  # Only subtract for new lines (updates are already reflected in sum(move_line_ids))
            //                     taken_quantities[need, location_id, lot_id, package_id, owner_id] = taken_quantity
            //             if all_move_line_vals:
            //                 self.env['stock.move.line'].create(all_move_line_vals)
            // 
            //             for (need, location_id, lot_id, package_id, owner_id), taken_quantity in taken_quantities.items():
            //                 # `quantity` is what is brought by chained done move lines. We double check
            //                 # here this quantity is available on the quants themselves. If not, this
            //                 # could be the result of an inventory adjustment that removed totally of
            //                 # partially `quantity`. When this happens, we chose to reserve the maximum
            //                 # still available. This situation could not happen on MTS move, because in
            //                 # this case `quantity` is directly the quantity on the quants themselves.
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
            // if any(move.state == 'done' and move.location_dest_usage != 'inventory' for move in self):
            //     raise UserError(_('You cannot cancel a stock move that has been set to \'Done\'. Create a return in order to reverse the moves which took place.'))
            // moves_to_cancel = self.filtered(lambda m: m.state != 'cancel' and not (m.state == 'done' and m.location_dest_usage == 'inventory'))
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
            //             move_dest_to_cancel = move.move_dest_ids.filtered(lambda m: m.state != 'done' and move.location_dest_id == m.location_id)
            //             move_dest_to_cancel._action_cancel()
            //             # Unlink from dest if dest is not in the chain
            //             (move.move_dest_ids - move_dest_to_cancel).write({
            //                 'procure_method': 'make_to_stock',
            //                 'move_orig_ids': [Command.unlink(move.id)]
            //             })
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

        protected async Task<StockMove> ActionConfirmInternalAsync(object merge, object merge_into, object create_proc)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _action_confirm(self, merge=True, merge_into=False, create_proc=True):
            // moves = self.action_explode()
            // merge_into = merge_into and merge_into.action_explode()
            // # we go further with the list of ids potentially changed by action_explode
            // return super(StockMove, moves)._action_confirm(merge=merge, merge_into=merge_into, create_proc=create_proc)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _action_confirm(self, merge=True, merge_into=False, create_proc=True):
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
            // res = super()._action_confirm(merge=merge, merge_into=merge_into, create_proc=create_proc)
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
            // def _action_confirm(self, merge=True, merge_into=False, create_proc=True):
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
            //         if create_proc:
            //             move_create_proc.add(move.id)
            //     elif move.rule_id and move.rule_id.procure_method == 'mts_else_mto':
            //         move_to_confirm.add(move.id)
            //         if create_proc:
            //             move_create_proc.add(move.id)
            //     else:
            //         move_to_confirm.add(move.id)
            //     if move._should_be_assigned():
            //         key = (frozenset(move.reference_ids.ids), move.location_id.id, move.location_dest_id.id)
            //         to_assign[key].add(move.id)
            // 
            // # create procurements for make to order moves
            // procurement_requests = []
            // move_create_proc = self.browse(move_create_proc)
            // quantities = move_create_proc._prepare_procurement_qty()
            // for move, quantity in zip(move_create_proc, quantities):
            //     values = move._prepare_procurement_values()
            //     origin = move._prepare_procurement_origin()
            //     procurement_requests.append(self.env['stock.rule'].Procurement(
            //         move.product_id, quantity, move.product_uom,
            //         move.location_id, move.rule_id and move.rule_id.name or "/",
            //         origin, move.company_id, values))
            // self.env['stock.rule'].run(procurement_requests, raise_user_error=not self.env.context.get('from_orderpoint'))
            // 
            // move_to_confirm, move_waiting = self.browse(move_to_confirm).filtered(lambda m: m.state != 'cancel'), self.browse(move_waiting).filtered(lambda m: m.state != 'cancel')
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
            // neg_r_moves = moves.filtered(lambda move: move.product_uom.compare(move.product_uom_qty, 0) < 0)
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
            //         if m.product_uom.compare(m.product_uom_qty, 0) < 0:
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
            //     neg_push_moves = new_push_moves.filtered(lambda sm: sm.product_uom.compare(sm.product_uom_qty, 0) < 0)
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
            //         if move.product_uom.compare(move.product_uom_qty, 0.0) == 0 or cancel_backorder:
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
            //     if len(result_package.quant_ids.filtered(lambda q: q.product_uom_id.compare(q.quantity, 0.0) > 0).mapped('location_id')) > 1:
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
            //     moves_todo._action_synch_order()
            // return moves_todo
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _action_done(self, cancel_backorder=False):
            // # Use _is_out() instead of is_out since the move is not done
            // # It's called before action_done since we need the current fifo
            // # stack. Limitation when validating at same time out and in.s
            // moves_out = self.filtered(lambda m: m._is_out())
            // moves_out._set_value()
            // moves = super()._action_done(cancel_backorder=cancel_backorder)
            // moves_in = moves.filtered(lambda m: m.is_in or m.is_dropship)
            // moves_in._set_value()
            // moves._create_account_move()
            // # Update standard price on outgoing fifo products
            // moves_out.product_id.filtered(lambda p: p.cost_method == 'fifo')._update_standard_price()
            // (moves_in | moves_out).sudo()._create_analytic_move()
            // return moves
            */
            return default;
        }

        protected async Task<StockMove> ActionSynchOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _action_synch_order(self):
            // purchase_order_lines_vals = []
            // for move in self:
            //     purchase_order = move.picking_id.purchase_id or move.picking_id.return_id.purchase_id
            //     # Creates new PO line only when pickings linked to a purchase order and
            //     # for moves with qty. done and not already linked to a PO line.
            //     if not purchase_order \
            //         or (move.location_id.usage not in ['supplier', 'transit'] and not (move.location_dest_id.usage == 'supplier' and move.to_refund)) \
            //         or move.purchase_line_id \
            //         or not move.picked:
            //         continue
            //     product = move.product_id
            //     if line := purchase_order.order_line.filtered(lambda l: l.product_id == product):
            //         move.purchase_line_id = line[:1]
            //         continue
            //     quantity = move.quantity
            //     if move.location_dest_id.usage in ['supplier', 'transit']:
            //         quantity *= -1
            //     po_line_vals = {
            //         'move_ids': [Command.link(move.id)],
            //         'order_id': purchase_order.id,
            //         'product_id': product.id,
            //         'product_qty': 0,
            //         'product_uom_id': move.product_uom.id,
            //         'qty_received': quantity
            //     }
            //     if product.purchase_method == 'purchase':
            //         # No unit price if the product is purchased on the ordered qty.
            //         po_line_vals['price_unit'] = 0
            //     purchase_order_lines_vals.append(po_line_vals)
            // if purchase_order_lines_vals:
            //     self.env['purchase.order.line'].create(purchase_order_lines_vals)
            // return super()._action_synch_order()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _action_synch_order(self):
            // sale_order_lines_vals = []
            // for move in self:
            //     sale_order = move.picking_id.sale_id
            //     # Creates new SO line only when pickings linked to a sale order and
            //     # for moves with qty. done and not already linked to a SO line.
            //     if not sale_order or move.sale_line_id or not move.picked or not (
            //         (move.location_dest_id.usage in ['customer', 'transit'] and not move.move_dest_ids)
            //         or (move.location_id.usage == 'customer' and move.to_refund)
            //     ):
            //         continue
            // 
            //     product = move.product_id
            // 
            //     if line := sale_order.order_line.filtered(lambda l: l.product_id == product):
            //         move.sale_line_id = line[:1]
            //         continue
            // 
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
            //         so_line = sale_order.order_line.filtered(lambda sol: sol.product_id == product)
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
            // return super()._action_synch_order()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _action_synch_order(self):
            // return True
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
            //         move.move_line_ids.unlink()
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

        public async Task<StockMove> AddPackagesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_add_packages(self):
            // """ Opens a list of suitable packages to add to a picking.
            // """
            // picking = self.env['stock.picking'].browse(self.env.context.get('picking_id'))
            // if not picking:
            //     raise UserError(self.env._("You need a transfer to add these packages to."))
            // return {
            //     'name': self.env._("Select Packages to Move"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.package',
            //     'view_mode': 'list',
            //     'views': [(self.env.ref('stock.stock_package_view_add_list').id, 'list')],
            //     'target': 'new',
            //     'domain': [('location_id', 'child_of', picking.location_id.id)],
            //     'context': {
            //         'picking_id': picking.id,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     location = move.location_id
            //     while location:
            //         domain = [
            //             ('location_src_id', '=', location.id),
            //             ('location_dest_id', '=', move.location_dest_id.id),
            //             ('action', '!=', 'push')
            //         ]
            //         if picking_type_code:
            //             domain.append(('picking_type_id.code', '=', picking_type_code))
            //         rule = self.env['stock.rule']._search_rule(False, move.packaging_uom_id, product_id, move.warehouse_id or move.picking_type_id.warehouse_id, domain)
            //         if rule:
            //             break
            //         location = location.location_id
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

        public async Task<StockMove> AdjustValuationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def action_adjust_valuation(self):
            // if len(self) != 1:
            //     raise UserError(_("You can only adjust valuation for one move at a time."))
            // action = self.env['ir.actions.act_window']._for_xml_id("stock_account.product_value_action")
            // product = self.product_id if len(self.product_id) == 1 else False
            // if product:
            //     action['name'] = _('Adjust Valuation: %(product)s', product=product.display_name)
            // action['target'] = 'new'
            // action['context'] = {
            //     'default_move_id': self.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // for _group, moves in grouped_moves:
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
            //         moves = moves.filtered(lambda m: m.product_uom.compare(m.product_uom_qty, 0.0) >= 0)
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
            //     current_origins = picking.origin.split(',') if picking.origin else []
            //     new_moves_origins = [move.origin for move in self if move.origin]
            //     new_origin = ','.join(OrderedSet(current_origins + new_moves_origins))
            //     if picking.origin != new_origin:
            //         vals['origin'] = new_origin
            // return vals
            */
            return default;
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

        protected async Task<StockMove> CanCreateLotInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _can_create_lot(self):
            // return super()._can_create_lot() or self.env.context.get('force_lot_m2o')
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _can_create_lot(self):
            // return self.picking_type_id.use_existing_lots
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
            //     if move.raw_material_production_id and move.product_uom.compare(move.quantity, 0) < 0:
            //         raise ValidationError(_("Please enter a positive quantity."))
            */
            return default;
        }

        protected async Task<StockMove> CheckQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _check_quantity(self):
            // return self.env['stock.quant'].sudo().search([
            //     ('product_id', 'in', self.product_id.ids),
            //     ('location_id', 'child_of', self.location_dest_id.ids),
            //     ('lot_id', 'in', self.sudo().lot_ids.ids)
            // ]).check_quantity()
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

        protected async Task<StockMove> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_allowed_uom_ids(self):
            // super()._compute_allowed_uom_ids()
            // for move in self:
            //     move.allowed_uom_ids |= move.product_id.bom_ids.product_uom_id
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_allowed_uom_ids(self):
            // for move in self:
            //     move.allowed_uom_ids = move.product_id.uom_id | move.product_id.uom_ids | move.sudo().product_id.seller_ids.product_uom_id
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

        protected async Task<StockMove> ComputeDescriptionPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_description_picking(self):
            // super()._compute_description_picking()
            // bom_line_description = {}
            // for bom in self.bom_line_id.bom_id:
            //     if bom.type != 'phantom':
            //         continue
            //     # mapped('id') to keep NewId
            //     line_ids = self.bom_line_id.filtered(lambda line: line.bom_id == bom).mapped('id')
            //     total = len(line_ids)
            //     for i, line_id in enumerate(line_ids):
            //         bom_line_description[line_id] = '%s - %d/%d' % (bom.display_name, i + 1, total)
            // 
            // for move in self:
            //     if not move.description_picking_manual and move.bom_line_id.id in bom_line_description:
            //         if move.description_picking == move.product_id.display_name:
            //             move.description_picking = ''
            //         move.description_picking += ('\n' if move.description_picking else '') + bom_line_description.get(move.bom_line_id.id)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _compute_description_picking(self):
            // super()._compute_description_picking()
            // for move in self:
            //     if move.purchase_line_id:
            //         seller = move.purchase_line_id.sudo().selected_seller_id
            //         vendor_reference = f'[{seller.product_code}]' if seller.product_code else ''
            //         vendor_reference += f' {seller.product_name}' if seller.product_name else ''
            //         no_variant_attributes = '\n'.join(f'{attribute.attribute_id.name}: {attribute.name}' for attribute in move.purchase_line_id.sudo().product_no_variant_attribute_value_ids)
            //         move.description_picking = (no_variant_attributes + '\n' + vendor_reference + '\n' + move.description_picking).strip()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _compute_description_picking(self):
            // super()._compute_description_picking()
            // for move in self:
            //     if move.sale_line_id and not move.description_picking_manual:
            //         sale_line_id = move.sale_line_id.with_context(lang=move.sale_line_id.order_id.partner_id.lang)
            //         move.description_picking = (sale_line_id._get_sale_order_line_multiline_description_variants() + '\n' + move.description_picking).strip()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_description_picking(self):
            // for move in self:
            //     if move.description_picking_manual:
            //         move.description_picking = move.description_picking_manual
            //     elif move.product_id:
            //         product = move.product_id.with_context(lang=move._get_lang())
            //         move.description_picking = product._get_picking_description(move.picking_type_id) or move._get_description()
            //     else:
            //         move.description_picking = ""
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
            //     if move._is_consuming() and move.state == 'draft' or move.picking_code == 'internal':
            //         prefetch_virtual_available[key_virtual_available(move)].add(move.product_id.id)
            //     elif move.picking_type_id.code == 'incoming':
            //         prefetch_virtual_available[key_virtual_available(move, incoming=True)].add(move.product_id.id)
            // for key_context, product_ids in prefetch_virtual_available.items():
            //     read_res = self.env['product.product'].browse(product_ids).with_context(warehouse_id=key_context[0], to_date=key_context[1]).read([
            //         'virtual_available',
            //         'free_qty',
            //     ])
            //     virtual_available_dict[key_context] = {res['id']: (res['virtual_available'], res['free_qty']) for res in read_res}
            // 
            // for move in product_moves:
            //     if key_virtual_available(move) in virtual_available_dict and move.product_id.id in virtual_available_dict[key_virtual_available(move)]:
            //         free_qty = virtual_available_dict[key_virtual_available(move)][move.product_id.id][1]
            //     else:
            //         free_qty = 0.0
            //     if move.state == 'assigned':
            //         move.forecast_availability = move.product_uom._compute_quantity(
            //             move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //         continue
            //     elif move.state == 'draft' and float_compare(free_qty, move.product_qty, precision_rounding=move.product_id.uom_id.rounding) >= 0:
            //         move.forecast_availability = free_qty
            //         continue
            //     if move._is_consuming():
            //         if move.state == 'draft':
            //             # for move _is_consuming and in draft -> the forecast_availability > 0 if in stock
            //             move.forecast_availability = virtual_available_dict[key_virtual_available(move)][move.product_id.id][0] - move.product_qty
            //         elif move.state in ('waiting', 'confirmed', 'partially_available'):
            //             outgoing_unreserved_moves_per_warehouse[move.location_id.warehouse_id].add(move.id)
            //     elif move.picking_type_id.code == 'internal':
            //         if float_compare(free_qty, move.product_qty, precision_rounding=move.product_id.uom_id.rounding) >= 0:
            //             move.forecast_availability = free_qty
            //             continue
            //     elif move.picking_type_id.code == 'incoming':
            //         forecast_availability = virtual_available_dict[key_virtual_available(move, incoming=True)][move.product_id.id][0]
            //         if move.state == 'draft':
            //             forecast_availability += move.product_qty
            //         move.forecast_availability = forecast_availability
            // 
            // for warehouse, moves_ids in outgoing_unreserved_moves_per_warehouse.items():
            //     if not warehouse:  # No prediction possible if no warehouse.
            //         continue
            //     moves_per_location = self.browse(moves_ids).grouped('location_id')
            //     for location, mvs in moves_per_location.items():
            //         forecast_info = mvs._get_forecast_availability_outgoing(warehouse, location)
            //         for move in mvs:
            //             move.forecast_availability, move.forecast_expected_date = forecast_info[move]
            */
            return default;
        }

        protected async Task<StockMove> ComputeHasLinesWithoutResultPackageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_has_lines_without_result_package(self):
            // for move in self:
            //     move.has_lines_without_result_package = move.move_line_ids.result_package_id and any(not line.result_package_id for line in move.move_line_ids)
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsDateEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_is_date_editable(self):
            // for move in self:
            //     if move.picking_id:
            //         move.is_date_editable = move.picking_id.is_date_editable
            //     else:
            //         move.is_date_editable = True
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsDropshipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_is_dropship(self):
            // for move in self:
            //     if move.state != 'done':
            //         move.is_dropship = False
            //         continue
            //     move.is_dropship = move._is_dropshipped() or move._is_dropshipped_returned()
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsInInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_is_in(self):
            // for move in self:
            //     if move.state != 'done':
            //         move.is_in = False
            //         continue
            //     move.is_in = move._is_in()
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

        protected async Task<StockMove> ComputeIsOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_is_out(self):
            // for move in self:
            //     if move.state != 'done':
            //         move.is_out = False
            //         continue
            //     move.is_out = move._is_out()
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsQuantityDoneEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_is_quantity_done_editable(self):
            // done_moves = self.env['stock.move']
            // for move in self:
            //     if move.is_subcontract:
            //         move.is_quantity_done_editable = move.has_tracking == 'none'
            //         done_moves |= move
            // return super(StockMove, self - done_moves)._compute_is_quantity_done_editable()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_is_quantity_done_editable(self):
            // for move in self:
            //     move.is_quantity_done_editable = move.product_id
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsValuedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_is_valued(self):
            // for move in self:
            //     move.is_valued = move.is_in or move.is_out
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
            //     if bom_line.product_uom_id.is_zero(bom_line_data['qty']):
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
            //         qty_ratios.append(bom_line.product_id.uom_id.round(qty_processed / qty_per_kit))
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

        protected async Task<StockMove> ComputePackageIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_package_ids(self):
            // for move in self:
            //     if move.state in ['done', 'cancel']:
            //         move.package_ids = move.move_line_ids.package_history_id.outermost_dest_id
            //     else:
            //         # Only display the top-level packages until the move is done.
            //         move.package_ids = move.move_line_ids.result_package_id.outermost_package_id
            */
            return default;
        }

        protected async Task<StockMove> ComputePackagingUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_packaging_uom_id(self):
            // super()._compute_packaging_uom_id()
            // for move in self:
            //     if move.production_id:
            //         move.packaging_uom_id = move.production_id.product_uom_id
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _compute_packaging_uom_id(self):
            // super()._compute_packaging_uom_id()
            // for move in self:
            //     if move.purchase_line_id:
            //         move.packaging_uom_id = move.purchase_line_id.product_uom_id
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _compute_packaging_uom_id(self):
            // super()._compute_packaging_uom_id()
            // for move in self:
            //     if move.sale_line_id:
            //         move.packaging_uom_id = move.sale_line_id.product_uom_id
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_packaging_uom_id(self):
            // for move in self:
            //     if move.move_orig_ids.packaging_uom_id:
            //         move.packaging_uom_id = move.move_orig_ids[0].packaging_uom_id
            //     elif move.move_dest_ids.packaging_uom_id:
            //         move.packaging_uom_id = move.move_dest_ids[0].packaging_uom_id
            //     else:
            //         move.packaging_uom_id = move.product_uom
            */
            return default;
        }

        protected async Task<StockMove> ComputePackagingUomQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_packaging_uom_qty(self):
            // for move in self:
            //     if move.packaging_uom_id:
            //         move.packaging_uom_qty = move.product_uom._compute_quantity(move.product_uom_qty, move.packaging_uom_id)
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
            //     if move.unbuild_id and move.unbuild_id.name:
            //         move.reference = move.unbuild_id.name
            //         moves_with_reference |= move
            // super(StockMove, self - moves_with_reference)._compute_reference()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move.py) ---
            // def _compute_reference(self):
            // moves_with_reference = set()
            // for move in self:
            //     if move.repair_id and move.repair_id.name:
            //         move.reference = move.repair_id.name
            //         moves_with_reference.add(move.id)
            // super(StockMove, self - self.env['stock.move'].browse(moves_with_reference))._compute_reference()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _compute_reference(self):
            // for move in self:
            //     if move.scrap_id:
            //         move.reference = move.scrap_id.name
            //     elif move.is_inventory:
            //         if move.inventory_name:
            //             move.reference = move.inventory_name
            //         else:
            //             move.reference = _('Product Quantity Confirmed') if float_is_zero(move.quantity, precision_rounding=move.product_uom.rounding) else _('Product Quantity Updated')
            //             if move.create_uid and move.create_uid.id != SUPERUSER_ID:
            //                 move.reference += f' ({move.create_uid.display_name})'
            //     else:
            //         move.reference = move.picking_id.name
            */
            return default;
        }

        protected async Task<StockMove> ComputeRemainingQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_remaining_qty(self):
            // products = self.product_id
            // remaining_by_product = products._get_remaining_moves()
            // 
            // for move in self:
            //     move.remaining_qty = remaining_by_product.get(move.product_id, {}).get(move, 0)
            */
            return default;
        }

        protected async Task<StockMove> ComputeRemainingValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_remaining_value(self):
            // for move in self:
            //     if not move.is_in:
            //         move.remaining_value = 0
            //         continue
            //     ratio = move.remaining_qty / move.quantity if move.quantity else 0
            //     if move.product_id.cost_method == 'fifo':
            //         move.remaining_value = ratio * move.value if ratio else 0
            //     else:
            //         move.remaining_value = move.remaining_qty * move.with_company(move.company_id).standard_price
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
            //     move.should_consume_qty = move.product_uom.round((mo.qty_producing - mo.qty_produced) * move.unit_factor)
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowDetailsVisibleInternalAsync()
        {
            /*
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
            //     if (
            //         not move.product_id
            //         or move.state == "draft"
            //         or (
            //             not move.picking_type_id.use_create_lots
            //             and not move.picking_type_id.use_existing_lots
            //             and not self.env.user.has_group("stock.group_stock_tracking_lot")
            //             and not self.env.user.has_group("stock.group_stock_multi_locations")
            //         )
            //     ):
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
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _compute_show_info(self):
            // super()._compute_show_info()
            // subcontract_moves = self.filtered(lambda m: m.is_subcontract and m.show_lots_text)
            // subcontract_moves.show_lots_text = False
            // subcontract_moves.show_lots_m2o = True
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
            //     if not move.move_line_ids or move.product_uom.is_zero(move.quantity):
            //         continue
            //     productions = move._get_subcontract_production().filtered(lambda m: m.state != 'cancel')
            //     if not productions:
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

        protected async Task<StockMove> ComputeValueJustificationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_value_justification(self):
            // self.value_justification = False
            // self.value_computed_justification = False
            // for move in self:
            //     if not move.is_in:
            //         continue
            //     move.value_justification = move._get_value_data()['description']
            //     computed_value_data = move._get_value_data(ignore_manual_update=True)
            //     if computed_value_data['description'] == move.value_justification:
            //         move.value_computed_justification = False
            //     else:
            //         value = move.company_currency_id.format(computed_value_data['value'])
            //         move.value_computed_justification = self.env._(
            //             'Computed value: %(value)s\n%(description)s',
            //             value=value, description=computed_value_data['description'])
            */
            return default;
        }

        protected async Task<StockMove> ComputeValueManualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _compute_value_manual(self):
            // for move in self:
            //     move.value_manual = move.value
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

        protected async Task<StockMove> CreateAccountMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_account_move(self):
            // """ Create account move for specific location or analytic."""
            // aml_vals_list = []
            // move_to_link = set()
            // for move in self:
            //     if move._should_create_account_move():
            //         aml_vals_list += move._get_account_move_line_vals()
            //         move_to_link.add(move.id)
            // if not aml_vals_list:
            //     return self.env['account.move']
            // account_move = self.env['account.move'].create({
            //     'journal_id': self.company_id.account_stock_journal_id.id,
            //     'line_ids': [Command.create(aml_vals) for aml_vals in aml_vals_list],
            //     'date': self.env.context.get('force_period_date') or fields.Date.context_today(self),
            // })
            // self.env['stock.move'].browse(move_to_link).account_move_id = account_move.id
            // account_move._post()
            // return account_move
            */
            return default;
        }

        protected async Task<StockMove> CreateAnalyticMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _create_analytic_move(self):
            // for move in self:
            //     analytic_line_vals = move._prepare_analytic_lines()
            //     if analytic_line_vals:
            //         move.analytic_account_line_ids += self.env['account.analytic.line'].sudo().create(analytic_line_vals)
            */
            return default;
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
            //         if 'quantity' in vals:
            //             vals['manual_consumption'] = True
            //         vals['picked'] = True
            // mo_id_to_mo = defaultdict(lambda: self.env['mrp.production'])
            // product_id_to_product = defaultdict(lambda: self.env['product.product'])
            // for values in vals_list:
            //     mo_id = values.get('raw_material_production_id', False) or values.get('production_id', False)
            //     location_dest = self.env['stock.location'].browse(values.get('location_dest_id'))
            //     if mo_id and location_dest.usage != 'inventory':
            //         mo = mo_id_to_mo[mo_id]
            //         if not mo:
            //             mo = mo.browse(mo_id)
            //             mo_id_to_mo[mo_id] = mo
            //         values['origin'] = mo._get_origin()
            //         values['propagate_cancel'] = mo.propagate_cancel
            //         values['reference_ids'] = mo.reference_ids.ids
            //         values['production_group_id'] = mo.production_group_id.id
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
            //         if not values.get('location_final_id'):
            //             values['location_final_id'] = mo.warehouse_id.lot_stock_id.id
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
            //     vals['origin'] = repair_id.name
            // moves = super().create(vals_list)
            // repair_moves = self.env['stock.move']
            // for move in moves:
            //     if not move.repair_id:
            //         continue
            //     move.reference_ids = [Command.link(r.id) for r in move.repair_id.reference_ids]
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
            //     if picking_id.state == 'done' and vals.get('state') != 'done':
            //         vals['state'] = 'done'
            //     if vals.get('state') == 'done':
            //         vals['picked'] = True
            // res = super().create(vals_list)
            // res._update_orderpoints()
            // res._set_references()
            // return res
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
            //     rounding = self.env['decimal.precision'].precision_get('Product Unit')
            //     if float_compare(move.quantity, move.product_uom_qty, precision_digits=rounding) < 0:
            //         # Need to do some kind of conversion here
            //         qty_split = move.product_uom._compute_quantity(move.product_uom_qty - move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //         new_move_vals = move._split(qty_split)
            //         backorder_moves_vals += new_move_vals
            // backorder_moves = self.env['stock.move'].create(backorder_moves_vals)
            // # The backorder moves are not yet in their own picking. We do not want to check entire packs for those
            // # ones as it could messed up the result_package_id of the moves being currently validated
            // backorder_moves.with_context(bypass_entire_pack=True)._action_confirm(merge=False, create_proc=False)
            // return backorder_moves
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
            // lot_names = [vals['lot_name'] for vals in vals_list if vals.get('lot_name')]
            // lot_ids = self.env['stock.lot'].search([
            //     ('product_id', '=', product_id),
            //     '|', ('company_id', '=', company_id), ('company_id', '=', False),
            //     ('name', 'in', lot_names),
            // ])
            // lot_id_names = set(lot_ids.mapped('name'))
            // lot_names = [lot_name for lot_name in lot_names if lot_name not in lot_id_names]  # lot_names not found to create
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
            //         'product_uom_id': move.product_uom.id,
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
            // def default_get(self, fields):
            // defaults = super().default_get(fields)
            // if self.env.context.get('default_raw_material_production_id') or self.env.context.get('default_production_id'):
            //     production_id = self.env['mrp.production'].browse(self.env.context.get('default_raw_material_production_id') or self.env.context.get('default_production_id'))
            // 
            //     if production_id.state not in ('draft', 'cancel'):
            //         if production_id.state != 'done':
            //             defaults['state'] = 'draft'
            //         else:
            //             defaults['state'] = 'done'
            //             defaults['additional'] = True
            //         defaults['product_uom_qty'] = 0.0
            //     elif production_id.state == 'draft':
            //         defaults['reference_ids'] = production_id.reference_ids.ids
            //         defaults['reference'] = production_id.name
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def default_get(self, fields):
            // # We override the default_get to make stock moves created after the picking was confirmed
            // # directly as available in immediate transfer mode. This allows to create extra move lines
            // # in the fp view. In planned transfer, the stock move are marked as `additional` and will be
            // # auto-confirmed.
            // defaults = super().default_get(fields)
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
            // return bom_line and bom_line.operation_id
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
            //     if move.state == 'cancel' or (move.state == 'done' and move.location_dest_usage == 'inventory') or move.picked:
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
            //     if move.product_uom.is_zero(move.product_uom_qty):
            //         factor = move.product_uom._compute_quantity(move.quantity, bom.product_uom_id) / bom.product_qty
            //     else:
            //         factor = move.product_uom._compute_quantity(move.product_uom_qty, bom.product_uom_id) / bom.product_qty
            //     _dummy, lines = bom.sudo().explode(move.product_id, factor, picking_type=bom.picking_type_id, never_attribute_values=move.never_product_template_attribute_value_ids)
            //     phantom_moves_vals_list += move._generate_all_phantom_moves(lines)
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

        protected async Task<StockMove> GenerateAllPhantomMovesInternalAsync(object exploded_lines_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _generate_all_phantom_moves(self, exploded_lines_data):
            // self.ensure_one()
            // phantom_moves_vals_list = []
            // for bom_line, line_data in exploded_lines_data:
            //     if self.product_uom.is_zero(self.product_uom_qty) or self.env.context.get('is_scrap'):
            //         vals = self._generate_move_phantom(bom_line, 0, line_data['qty'])
            //     else:
            //         vals = self._generate_move_phantom(bom_line, line_data['qty'], 0)
            //     for val in vals:
            //         val['cost_share'] = line_data.get('line_cost_share', 0.0)
            //     phantom_moves_vals_list += vals
            // return phantom_moves_vals_list
            */
            return default;
        }

        public async Task<StockMove> GenerateLotLineValsAsync(Guid id, StockMoveGenerateLotLineValsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py) ---
            // def action_generate_lot_line_vals(self, context_data, mode, first_lot, count, lot_text):
            // vals_list = super().action_generate_lot_line_vals(context_data, mode, first_lot, count, lot_text)
            // product = self.env['product.product'].browse(context_data.get('default_product_id'))
            // picking = self.env['stock.picking'].browse(context_data.get('default_picking_id'))
            // if product.use_expiration_date:
            //     from_date = picking.scheduled_date or fields.Datetime.today()
            //     expiration_date = from_date + datetime.timedelta(days=product.expiration_time)
            //     for vals in vals_list:
            //         vals['expiration_date'] = vals.get('expiration_date') or expiration_date
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def action_generate_lot_line_vals(self, context_data, mode, first_lot, count, lot_text):
            // if not context_data.get('default_product_id'):
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
            // for key in context_data:
            //     if key.startswith('default_'):
            //         default_vals[remove_prefix(key, 'default_')] = context_data[key]
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
            //     if picking_type.use_existing_lots or context_data.get('force_lot_m2o'):
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
            //         loc = loc_dest or self.location_dest_id._get_putaway_strategy(self.product_id, quantity=quantity, additional_qty=qty_by_location)
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
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _generate_serial_numbers(self, next_serial, next_serial_count=False, location_id=False):
            // if self.is_subcontract:
            //     return super(StockMove, self.with_context(force_lot_m2o=True))._generate_serial_numbers(next_serial, next_serial_count, location_id)
            // return super()._generate_serial_numbers(next_serial, next_serial_count, location_id)
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
            // if self._can_create_lot():
            //     self._create_lot_ids_from_move_line_vals(field_data, self.product_id.id, self.company_id.id)
            // move_lines_commands = self._generate_serial_move_line_commands(field_data)
            // self.move_line_ids = move_lines_commands
            // return True
            */
            return default;
        }

        protected async Task<StockMove> GetAccountMoveLineValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_account_move_line_vals(self):
            // if self.location_id.valuation_account_id:
            //     debit_acc = self.product_id._get_product_accounts()['stock_valuation']
            //     credit_acc = self.location_id.valuation_account_id
            // else:
            //     debit_acc = self.location_dest_id.valuation_account_id
            //     credit_acc = self.product_id._get_product_accounts()['stock_valuation']
            // value = self._get_aml_value()
            // return [{
            //     'account_id': credit_acc.id,
            //     'name': self.reference + ' - ' + self.product_id.name,
            //     'debit': 0,
            //     'credit': value,
            //     'product_id': self.product_id.id,
            // }, {
            //     'account_id': debit_acc.id,
            //     'name': self.reference + ' - ' + self.product_id.name,
            //     'debit': value,
            //     'credit': 0,
            //     'product_id': self.product_id.id,
            // }]
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
            */
            return default;
        }

        protected async Task<StockMove> GetAmlValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: stock_move.py) ---
            // def _get_aml_value(self):
            // value = super()._get_aml_value()
            // if (
            //     self.production_id
            //     and self.move_dest_ids.filtered(lambda m: m.state == "done")[-1:].is_subcontract
            //     and self.product_id.cost_method != "standard"
            // ):
            //     value -= self.production_id.extra_cost * self.product_uom._compute_quantity(self.quantity, self.product_id.uom_id)
            // return value
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_aml_value(self):
            // self.ensure_one()
            // return self.value
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

        protected async Task<StockMove> GetCostRatioInternalAsync(object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py) ---
            // def _get_cost_ratio(self, quantity):
            // self.ensure_one()
            // if self.bom_line_id.bom_id.type == "phantom":
            //     uom_quantity = self.product_uom._compute_quantity(self.quantity, self.product_id.uom_id)
            //     if not self.product_uom.is_zero(uom_quantity):
            //         return (self.cost_share / 100) * quantity / uom_quantity
            // return super()._get_cost_ratio(quantity)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_cost_ratio(self, quantity):
            // self.ensure_one()
            // return quantity
            */
            return default;
        }

        protected async Task<StockMove> GetDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_description(self):
            // return self.purchase_line_id.name if self.purchase_line_id else super()._get_description()
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: stock_move.py) ---
            // def _get_description(self):
            // # In a dropshipping context we do not need the description of the purchase order or it will be displayed
            // # in Delivery slip report and it may be confusing for the customer to see several times the same text (product name + description_picking).
            // if self.purchase_line_id and self.purchase_line_id.order_id.dest_address_id:
            //     product = self.product_id.with_context(lang=self.purchase_line_id.order_id.dest_address_id.lang or self.env.user.lang)
            //     return product._get_description(self.picking_type_id)
            // return super()._get_description()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_description(self):
            // product = self.product_id.with_context(lang=self._get_lang())
            // return product._get_description(self.picking_type_id)
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

        protected async Task<StockMove> GetInMoveLinesInternalAsync(object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_in_move_lines(self, lot=None):
            // """ Returns the `stock.move.line` records of `self` considered as incoming. It is done thanks
            // to the `_should_be_valued` method of their source and destionation location as well as their
            // owner.
            // 
            // :returns: a subset of `self` containing the incoming records
            // :rtype: recordset
            // """
            // res = OrderedSet()
            // for move_line in self.move_line_ids:
            //     if lot and move_line.lot_id != lot:
            //         continue
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

        protected async Task<StockMove> GetKitPriceUnitInternalAsync(object product, object kit_bom, object valuated_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_kit_price_unit(self, product, kit_bom, valuated_quantity):
            // """ Override the value for kit products """
            // _dummy, exploded_lines = kit_bom.explode(product, valuated_quantity)
            // total_price_unit = 0
            // component_qty_per_kit = defaultdict(float)
            // for line in exploded_lines:
            //     component_qty_per_kit[line[0].product_id] += line[1]['qty']
            // for component, valuated_moves in self.grouped('product_id').items():
            //     price_unit = super(StockMove, valuated_moves)._get_price_unit()
            //     qty_per_kit = component_qty_per_kit[component] / kit_bom.product_qty
            //     total_price_unit += price_unit * qty_per_kit
            // return total_price_unit
            */
            return default;
        }

        protected async Task<StockMove> GetLandedCostInternalAsync(object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_move.py) ---
            // def _get_landed_cost(self, at_date=None):
            // domain = [('move_id', 'in', self.ids), ('cost_id.state', '=', 'done')]
            // if at_date:
            //     domain.append(('cost_id.date', '<=', at_date))
            // landed_cost_group = self.env['stock.valuation.adjustment.lines']._read_group(domain, ['move_id'], ['id:recordset'])
            // return dict(landed_cost_group)
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

        protected async Task<StockMove> GetManualValueInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_manual_value(self, quantity, at_date=None):
            // valuation_data = dict(VALUATION_DICT)
            // domain = Domain([('move_id', '=', self.id)])
            // if at_date:
            //     domain &= Domain([('date', '<=', at_date)])
            // manual_value = self.env['product.value'].search(domain, order="date desc, id desc", limit=1)
            // if manual_value:
            //     valuation_data['value'] = manual_value.value
            //     valuation_data['quantity'] = quantity
            //     description = _("Adjusted on %(date)s by %(user)s",
            //         date=manual_value.date,
            //         user=manual_value.user_id.name,
            //     )
            //     if manual_value.description:
            //         description += "\n" + manual_value.description
            //     valuation_data['description'] = description
            // return valuation_data
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
            // vals = super()._get_new_picking_values()
            // order = self.reference_ids.pos_order_ids
            // if order:
            //     vals['pos_session_id'] = order.session_id.id
            //     vals['pos_order_id'] = order.id
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
            // carrier_id = self.reference_ids.sale_ids.carrier_id.id
            // carrier_tracking_ref = False
            // if self.move_orig_ids.picking_id.carrier_id:
            //     # check if previous picking have carrier_id take carrier from that
            //     # earlier we were taking carrier from sale but since carrier can be changed  or updated in next steps so now we take carrier from prev picking
            //     carrier_id = self.move_orig_ids.picking_id.carrier_id.id
            //     carrier_tracking_ref = self.move_orig_ids.picking_id.carrier_tracking_ref
            // # propagating carrier and tracking ref only if carrier propagation rule allow
            // if any(rule.propagate_carrier for rule in self.rule_id):
            //     vals['carrier_tracking_ref'] = carrier_tracking_ref
            //     vals['carrier_id'] = carrier_id
            // return vals
            */
            return default;
        }

        protected async Task<StockMove> GetOutMoveLinesInternalAsync(object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_out_move_lines(self, lot=None):
            // """ Returns the `stock.move.line` records of `self` considered as outgoing. It is done thanks
            // to the `_should_be_valued` method of their source and destionation location as well as their
            // owner.
            // 
            // :returns: a subset of `self` containing the outgoing records
            // :rtype: recordset
            // """
            // res = self.env['stock.move.line']
            // for move_line in self.move_line_ids:
            //     if lot and move_line.lot_id != lot:
            //         continue
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
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: stock_move.py) ---
            // def _get_price_unit(self):
            // order_line = self.sale_line_id
            // if order_line and all(move.sale_line_id == order_line for move in self) and any(move.product_id != order_line.product_id for move in self):
            //     product = self.product_id.with_company(order_line.company_id)
            //     bom = product.env['mrp.bom']._bom_find(product, company_id=self.company_id.id, bom_type='phantom')[product]
            //     if bom:
            //         return self._get_kit_price_unit(product, bom, order_line.qty_delivered)
            // return super()._get_price_unit()
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_price_unit(self):
            // """ Returns the unit price to value this stock move """
            // if len(self.product_id) > 1:
            //     return 0
            // total_value = sum(self.mapped('value'))
            // total_qty = sum(m._get_valued_qty() for m in self)
            // return total_value / total_qty if total_qty else self.product_id.standard_price
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
            //     'readOnly': len(self) > 1,
            //     'uomDisplayName': len(self) == 1 and self.product_uom.display_name or self.product_id.uom_id.display_name,
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

        protected async Task<StockMove> GetRelatedInvoicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_related_invoices(self):
            // """ Overridden to return the vendor bills related to this stock move.
            // """
            // rslt = super()._get_related_invoices()
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
            //         and all(move.should_consume_qty and move.product_uom.compare(move.quantity, move.should_consume_qty) >= 0
            //                 or (move.product_uom.compare(move.quantity, move.product_uom_qty) >= 0 or (move.manual_consumption and move.picked))
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
            // created_pl = self.created_purchase_line_ids.filtered(lambda cpl: cpl.state != 'cancel' and (cpl.state != 'draft' or self.env.context.get('include_draft_documents')))
            // if created_pl:
            //     return [(pl.order_id, pl.order_id.user_id, visited) for pl in created_pl]
            // elif self.purchase_line_id and self.purchase_line_id.state != 'cancel':
            //     return[(self.purchase_line_id.order_id, self.purchase_line_id.order_id.user_id, visited)]
            // else:
            //     return super(StockMove, self)._get_upstream_documents_and_responsibles(visited)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // if self not in visited and self.move_orig_ids and any(m.state not in ('done', 'cancel') for m in self.move_orig_ids):
            //     visited |= self
            //     return set(itertools.chain.from_iterable(
            //         move._get_upstream_documents_and_responsibles(visited)
            //         for move in self.move_orig_ids
            //         if move.state not in ('done', 'cancel')
            //     ))
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
            //     domain = Domain.AND([domain, [('product_id.expense_policy', 'not in', ('sales_price', 'cost'))]])
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
            //     if related_aml.product_uom_id.rounding or related_aml.product_id.uom_id.is_zero(valuation_total_qty):
            //         raise UserError(_('Odoo is not able to generate the anglo saxon entries. The total valuation of %s is zero.', related_aml.product_id.display_name))
            // return valuation_price_unit_total, valuation_total_qty
            */
            return default;
        }

        protected async Task<StockMove> GetValueDataInternalAsync(object forced_std_price, object at_date, object ignore_manual_update, object add_extra_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_data(
            //     self,
            //     forced_std_price=False,
            //     at_date=False,
            //     ignore_manual_update=False,
            //     add_extra_value=True,
            // ):
            //     """Returns the value and the quantity valued on the move
            //     In priority order:
            //     - Take value from accounting documents (invoices, bills)
            //     - Take value from quotations + landed costs
            //     - Take value from product cost
            // 
            //     Forced standard price is useful when we have to get the value
            //     of a move in the past with the standard price at that time.
            //     """
            //     # TODO: Make multi
            //     self.ensure_one()
            //     # It probably needs a priority order:
            //     # 1. take from Invoice/Bills
            //     # 2. from SO/PO lines
            //     # 3. standard_price
            // 
            //     valued_qty = remaining_qty = self._get_valued_qty()
            //     value = 0
            //     descriptions = []
            // 
            //     if not ignore_manual_update:
            //         manual_data = self._get_manual_value(
            //             remaining_qty, at_date)
            //         # In case of manual update we will skip extra cost
            //         if manual_data['quantity']:
            //             add_extra_value = False
            //         value += manual_data['value']
            //         remaining_qty -= manual_data['quantity']
            //         if manual_data.get('description'):
            //             descriptions.append(manual_data['description'])
            // 
            //     # 1. take from Invoice/Bills
            //     if remaining_qty:
            //         account_data = self._get_value_from_account_move(remaining_qty, at_date)
            //         value += account_data['value']
            //         remaining_qty -= account_data['quantity']
            //         if account_data.get('description'):
            //             descriptions.append(account_data['description'])
            // 
            //     if remaining_qty:
            //         production_data = self._get_value_from_production(remaining_qty, at_date)
            //         value += production_data["value"]
            //         remaining_qty -= production_data["quantity"]
            //         if production_data.get("description"):
            //             descriptions.append(production_data["description"])
            // 
            //     # 2. from SO/PO lines
            //     if remaining_qty:
            //         quotation_data = self._get_value_from_quotation(remaining_qty, at_date)
            //         value += quotation_data['value']
            //         remaining_qty -= quotation_data['quantity']
            //         if quotation_data.get('description'):
            //             descriptions.append(quotation_data['description'])
            // 
            //     # 3. from returns
            //     if remaining_qty:
            //         return_data = self._get_value_from_returns(remaining_qty, at_date)
            //         value += return_data['value']
            //         remaining_qty -= return_data['quantity']
            //         if return_data.get('description'):
            //             descriptions.append(return_data['description'])
            // 
            //     # 4. standard_price
            //     if remaining_qty:
            //         std_price_data = self._get_value_from_std_price(remaining_qty, forced_std_price, at_date)
            //         value += std_price_data['value']
            //         descriptions.append(std_price_data.get('description'))
            // 
            //     if add_extra_value:
            //         extra_data = self._get_value_from_extra(valued_qty, at_date)
            //         value += extra_data['value']
            //         if extra_data.get('description'):
            //             descriptions.append(extra_data['description'])
            // 
            //     return {
            //         'value': value,
            //         'quantity': valued_qty,
            //         'description': '\n'.join(descriptions),
            //     }
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromAccountMoveInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_move.py) ---
            // def _get_value_from_account_move(self, quantity, at_date=None):
            // valuation_data = super()._get_value_from_account_move(quantity, at_date=at_date)
            // if not self.production_id or not self.move_dest_ids.is_subcontract or not self.move_dest_ids.purchase_line_id:
            //     return valuation_data
            // last_done_receipt = self.move_dest_ids.filtered(lambda m: m.state == 'done')
            // if not last_done_receipt:
            //     return valuation_data
            // 
            // bill_data = last_done_receipt._get_value_from_account_move(quantity)
            // po_data = last_done_receipt._get_value_from_quotation(quantity - bill_data['quantity'])
            // if not bill_data['value'] and not po_data['value']:
            //     return valuation_data
            // 
            // old_extra = self.production_id.extra_cost
            // new_extra_cost = (bill_data['value'] + po_data['value']) / quantity
            // 
            // # Recompute finished_move price based on quotation and invoice
            // value = (self.price_unit - old_extra + new_extra_cost) * self.quantity
            // return {
            //     'value': value,
            //     'quantity': quantity,
            //     'description': self.env._('%(value)s for %(quantity)s %(unit)s from %(production)s',
            //         value=self.company_currency_id.format(self.value), quantity=quantity, unit=self.product_id.uom_id.name,
            //         production=self.production_id.display_name),
            // }
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_value_from_account_move(self, quantity, at_date=None):
            // valuation_data = super()._get_value_from_account_move(quantity, at_date=at_date)
            // if not self.purchase_line_id:
            //     return valuation_data
            // 
            // if isinstance(at_date, datetime):
            //     # Since aml.date are Date, we don't need the extra precision here.
            //     at_date = Date.to_date(at_date)
            // 
            // aml_quantity = 0
            // value = 0
            // aml_ids = set()
            // for aml in self.purchase_line_id.invoice_lines:
            //     if at_date and aml.date > at_date:
            //         continue
            //     if aml.move_id.state != 'posted':
            //         continue
            //     aml_ids.add(aml.id)
            //     if aml.move_type == 'in_invoice':
            //         aml_quantity += aml.product_uom_id._compute_quantity(aml.quantity, self.product_id.uom_id)
            //         value += aml.currency_id._convert(aml.price_subtotal, self.company_id.currency_id, date=aml.date)
            //     elif aml.move_type == 'in_refund':
            //         aml_quantity -= aml.product_uom_id._compute_quantity(aml.quantity, self.product_id.uom_id)
            //         value -= aml.currency_id._convert(aml.price_subtotal, self.company_id.currency_id, date=aml.date)
            // 
            // if aml_quantity <= 0:
            //     return valuation_data
            // 
            // other_candidates_qty = 0
            // for move in self.purchase_line_id.move_ids:
            //     if move == self:
            //         continue
            //     if move.product_id != self.product_id:
            //         continue
            //     if move.date > self.date or (move.date == self.date and move.id > self.id):
            //         continue
            //     if move.is_in or move.is_dropship:
            //         other_candidates_qty += move._get_valued_qty()
            //     elif move.is_out:
            //         other_candidates_qty -= -move._get_valued_qty()
            // 
            // if self.product_uom.compare(aml_quantity, other_candidates_qty) <= 0:
            //     return valuation_data
            // 
            // # Remove quantity from prior moves.
            // value = value * ((aml_quantity - other_candidates_qty) / aml_quantity)
            // aml_quantity = aml_quantity - other_candidates_qty
            // 
            // if quantity >= aml_quantity:
            //     valuation_data['quantity'] = aml_quantity
            //     valuation_data['value'] = value
            // else:
            //     valuation_data['quantity'] = quantity
            //     valuation_data['value'] = quantity * value / aml_quantity
            // account_moves = self.env['account.move.line'].browse(aml_ids).move_id
            // valuation_data['description'] = self.env._('%(value)s for %(quantity)s %(unit)s from %(bills)s',
            //     value=self.company_currency_id.format(value), quantity=aml_quantity, unit=self.product_id.uom_id.name,
            //     bills=account_moves.mapped('display_name'))
            // return valuation_data
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_account_move(self, quantity, at_date=None):
            // return dict(VALUATION_DICT)
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromExtraInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_extra(self, quantity, at_date=None):
            // return dict(VALUATION_DICT)
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_move.py) ---
            // def _get_value_from_extra(self, quantity, at_date=None):
            // self.ensure_one()
            // accounting_data = super()._get_value_from_extra(quantity, at_date=at_date)
            // # Add landed costs value
            // lcs = self._get_landed_cost(at_date=at_date)
            // lcs = lcs.get(self)
            // if not lcs:
            //     return accounting_data
            // lcs_desc = []
            // for lc in lcs:
            //     accounting_data["value"] += lc.additional_landed_cost
            //     landed_cost = lc.cost_id
            //     value = lc.additional_landed_cost
            //     vendor_bill = landed_cost.vendor_bill_id
            //     if vendor_bill:
            //         desc = self.env._("+ %(value)s from %(vendor_bill)s (Landed Cost: %(landed_cost)s)",
            //             value=self.company_currency_id.format(value), vendor_bill=vendor_bill.display_name, landed_cost=landed_cost.display_name)
            //     else:
            //         desc = self.env._("+ %(value)s (Landed Cost: %(landed_cost)s)",
            //             value=self.company_currency_id.format(value), landed_cost=landed_cost.display_name)
            //     lcs_desc.append(desc)
            // description = self.env._("Additional landed costs:\n%(landed_cost)s", landed_cost='\n'.join(lcs_desc))
            // if not accounting_data['description']:
            //     accounting_data['description'] = description
            // else:
            //     accounting_data['description'] += '\n' + description
            // return accounting_data
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromProductionInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py) ---
            // def _get_value_from_production(self, quantity, at_date=None):
            // # TODO: Maybe move _cal_price here
            // self.ensure_one()
            // if not self.production_id:
            //     return super()._get_value_from_production(quantity, at_date)
            // value = quantity * self.price_unit
            // return {
            //     'value': value,
            //     'quantity': quantity,
            //     'description': self.env._('%(value)s for %(quantity)s %(unit)s from %(production)s',
            //         value=self.company_currency_id.format(value), quantity=quantity, unit=self.product_id.uom_id.name,
            //         production=self.production_id.display_name),
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_production(self, quantity, at_date=None):
            // return dict(VALUATION_DICT)
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromQuotationInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _get_value_from_quotation(self, quantity, at_date=None):
            // # TODO: Start from global value
            // if not self.purchase_line_id:
            //     return super()._get_value_from_quotation(quantity, at_date)
            // price_unit = self.purchase_line_id.with_context(conversion_date=self.date)._get_stock_move_price_unit()
            // uom_quantity = self.product_uom._compute_quantity(quantity, self.product_id.uom_id)
            // quantity = min(quantity, uom_quantity)
            // cost_ratio = self._get_cost_ratio(quantity)
            // value = price_unit * cost_ratio
            // return {
            //     'value': value,
            //     'quantity': quantity,
            //     'description': self.env._('%(value)s for %(quantity)s %(unit)s from %(quotation)s (not billed)',
            //         value=self.company_currency_id.format(value), quantity=quantity, unit=self.product_id.uom_id.name,
            //         quotation=self.purchase_line_id.order_id.display_name),
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_quotation(self, quantity, at_date=None):
            // return dict(VALUATION_DICT)
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromReturnsInternalAsync(object quantity, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_returns(self, quantity, at_date=None):
            // if self.origin_returned_move_id and self.origin_returned_move_id.is_out:
            //     origin_move = self.origin_returned_move_id
            //     return {
            //         'value': origin_move.value * quantity / origin_move._get_valued_qty(),
            //         'quantity': quantity,
            //         'description': _('Value based on original move %(reference)s', reference=origin_move.reference),
            //     }
            // return dict(VALUATION_DICT)
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromStdPriceInternalAsync(object quantity, object std_price, object at_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value_from_std_price(self, quantity, std_price=False, at_date=None):
            // std_price = std_price if std_price else self.product_id.standard_price
            // if at_date and self.product_id.cost_method == 'standard':
            //     std_price = std_price or self.product_id._get_standard_price_at_date(at_date)
            // return {
            //     'value': std_price * quantity,
            //     'quantity': quantity,
            //     'description': self.env._("%(quantity)s %(uom)s at product's cost",
            //         quantity=quantity,
            //         uom=self.product_id.uom_id.name,
            //     ),
            // }
            */
            return default;
        }

        protected async Task<StockMove> GetValueInternalAsync(object forced_std_price, object at_date, object ignore_manual_update)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_value(self, forced_std_price=False, at_date=False, ignore_manual_update=False):
            // return self._get_value_data(forced_std_price, at_date, ignore_manual_update)['value']
            */
            return default;
        }

        protected async Task<StockMove> GetValuedQtyInternalAsync(object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _get_valued_qty(self, lot=None):
            // self.ensure_one()
            // if self._is_in():
            //     return sum(self._get_in_move_lines(lot).mapped('quantity_product_uom'))
            // if self._is_out():
            //     return sum(self._get_out_move_lines(lot).mapped('quantity_product_uom'))
            // if self.is_dropship:
            //     if lot:
            //         return sum(self.move_line_ids.filtered(lambda ml: ml.lot_id == lot).mapped('quantity_product_uom'))
            //     return self.product_uom._compute_quantity(self.quantity, self.product_id.uom_id)
            // return 0
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

        protected async Task<StockMove> InverseDescriptionPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _inverse_description_picking(self):
            // for move in self:
            //     move.description_picking_manual = move.description_picking
            */
            return default;
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
            // self.sudo()._create_analytic_move()
            */
            return default;
        }

        protected async Task<StockMove> InverseValueManualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _inverse_value_manual(self):
            // for move in self:
            //     if move.value_manual == move.value:
            //         continue
            //     self.env['product.value'].create({
            //         'move_id': move.id,
            //         'value': move.value_manual,
            //         'company_id': move.company_id.id,
            //     })
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
            // return self._get_in_move_lines() and not self._is_dropshipped_returned()
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
            // return self._get_out_move_lines() and not self._is_dropshipped()
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
            // return bool(self.picking_id.return_picking_id)
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
            // return keys + (self.reference_ids.pos_order_ids,)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _key_assign_picking(self):
            // self.ensure_one()
            // keys = (self.reference_ids, self.location_id, self.location_dest_id, self.picking_type_id)
            // if self.partner_id and not self.reference_ids:
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
            // return bool(moves)
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
            //     currency_precision = min(self.company_id.mapped('currency_id.decimal_places')) if self.company_id else False
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
            // neg_qty_moves = self.filtered(lambda m: m.product_uom.compare(m.product_qty, 0.0) < 0)
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
            //         if pos_move.product_uom.compare(pos_move.product_uom_qty, abs(neg_move.product_uom_qty)) >= 0:
            //             pos_move.product_uom_qty += neg_move.product_uom_qty
            //             pos_move.write({
            //                 'price_unit': float_round(new_total_value / pos_move.product_qty, precision_digits=price_unit_prec) if pos_move.product_qty else 0,
            //                 'move_dest_ids': [Command.link(m.id) for m in neg_move.mapped('move_dest_ids') if m.location_id == pos_move.location_dest_id],
            //                 'move_orig_ids': [Command.link(m.id) for m in neg_move.mapped('move_orig_ids') if m.location_dest_id == pos_move.location_id],
            //             })
            //             merged_moves |= pos_move
            //             moves_to_unlink |= neg_move
            //             if pos_move.product_uom.is_zero(pos_move.product_uom_qty):
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

        protected async Task<StockMove> OnchangeProductUomQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _onchange_product_uom_qty(self):
            // if self.product_uom and self.raw_material_production_id and self.has_tracking == 'none'\
            //     and self.state not in ('draft', 'cancel', 'done'):
            //     mo = self.raw_material_production_id
            //     new_qty = self.product_uom.round((mo.qty_producing - mo.qty_produced) * self.unit_factor)
            //     self.quantity = new_qty
            */
            return default;
        }

        protected async Task<StockMove> OnchangeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _onchange_quantity(self):
            // if self.raw_material_production_id and self.product_uom and \
            //     not float_is_zero(self.quantity, precision_rounding=self.product_uom.rounding) and self.product_uom.compare(self.product_uom_qty, self.quantity) != 0:
            //     self.manual_consumption = True
            //     self.picked = True
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
            // if not self.is_inventory and self.location_dest_usage == 'inventory':
            //     return {
            //         'res_model': 'stock.scrap',
            //         'type': 'ir.actions.act_window',
            //         'views': [[False, 'form']],
            //         'res_id': self.scrap_id.id,
            //     }
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
            //     'name': self.reference,
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
            //             missing_plan_names=missing_plan_names,
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
            //             missing_plan_names=missing_plan_names,
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
            // amount, unit_amount = 0, 0
            // 
            // if self.state != 'done':
            //     if self.picked:
            //         unit_amount = self.product_uom._compute_quantity(
            //             self.quantity, self.product_id.uom_id)
            //         # Falsy in FIFO but since it's an estimation we don't require exact correct cost. Otherwise
            //         # we would have to recompute all the analytic estimation at each out.
            //         amount = unit_amount * self.product_id.standard_price
            //     else:
            //         return False
            // else:
            //     amount = self.value
            //     unit_amount = self._get_valued_qty()
            // 
            // if self._is_out():
            //     amount = -amount
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

        protected async Task<StockMove> PrepareExtraMoveValsInternalAsync(object qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py) ---
            // def _prepare_extra_move_vals(self, qty):
            // vals = super()._prepare_extra_move_vals(qty)
            // vals['purchase_line_id'] = self.purchase_line_id.id
            // return vals
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
            // res += ['created_production_id', 'cost_share', 'production_group_id']
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
            // distinct_fields = super()._prepare_merge_moves_distinct_fields()
            // distinct_fields.append('sale_line_id')
            // return distinct_fields
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_merge_moves_distinct_fields(self):
            // fields = [
            //     'product_id', 'price_unit', 'procure_method', 'location_id', 'location_dest_id', 'location_final_id',
            //     'product_uom', 'restrict_partner_id', 'origin_returned_move_id',
            //     'propagate_cancel', 'description_picking', 'never_product_template_attribute_value_ids',
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
            // return super()._prepare_merge_negative_moves_excluded_distinct_fields() + ['created_purchase_line_ids']
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
            // if self.production_id.product_tracking == 'lot' and self.product_id == self.production_id.product_id and self.production_id.lot_producing_ids:
            //     vals['lot_id'] = self.production_id.lot_producing_ids.ids[0]
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
            //     rounding = self.env['decimal.precision'].precision_get('Product Unit')
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

        protected async Task<StockMove> PrepareMoveSplitValsInternalAsync(object qty)
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
            // # when backordering an mto move link the bakcorder to the purchase order
            // if self.procure_method == 'make_to_order' and self.created_purchase_line_ids:
            //     vals['created_purchase_line_ids'] = [Command.set(self.created_purchase_line_ids.ids)]
            // vals['purchase_line_id'] = self.purchase_line_id.id
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
            //     'picked': self.picked,
            //     'bom_line_id': bom_line.id,
            //     'description_picking': self.product_id.display_name,
            // }
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: stock_move.py) ---
            // def _prepare_phantom_move_values(self, bom_line, product_qty, quantity_done):
            // vals = super()._prepare_phantom_move_values(bom_line, product_qty, quantity_done)
            // if self.repair_id:
            //     vals['repair_id'] = self.repair_id.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py) ---
            // def _prepare_phantom_move_values(self, bom_line, product_qty, quantity_done):
            // vals = super()._prepare_phantom_move_values(bom_line, product_qty, quantity_done)
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
            // return (self.reference_ids and self.reference_ids[0].name) or self.origin or self.picking_id.display_name
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
            //     if move.id not in mtso_moves or move.product_id.uom_id.compare(move.product_qty, 0) <= 0:
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
            // res['production_group_id'] = self.production_group_id.id
            // res['bom_line_id'] = self.bom_line_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // if self.raw_material_production_id.subcontractor_id:
            //     res['warehouse_id'] = self.picking_type_id.warehouse_id
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: stock.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // if res.get('group_id') and len(res['group_id'].mrp_production_ids) == 1:
            //     res['project_id'] = res['group_id'].mrp_production_ids.project_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // project = self.sale_line_id.order_id.project_id
            // if project:
            //     res['project_id'] = project.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _prepare_procurement_values(self):
            // res = super()._prepare_procurement_values()
            // # to pass sale_line_id fom SO to MO in mto
            // if self.sale_line_id:
            //     res['sale_line_id'] = self.sale_line_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _prepare_procurement_values(self):
            // """ Prepare specific key for moves or other componenets that will be created from a stock rule
            // comming from a stock move. This method could be override in order to add other custom key that could
            // be used in move/po creation.
            // """
            // self.ensure_one()
            // 
            // product_id = self.product_id.with_context(lang=self._get_lang())
            // dates_info = {'date_planned': self._get_mto_procurement_date()}
            // route = self.route_ids
            // if not route:
            //     related_packages = self.env['stock.package'].search_fetch([('id', 'parent_of', self.move_line_ids.result_package_id.ids)], ['package_type_id'])
            //     route = related_packages.package_type_id.route_ids
            // if self.location_id.warehouse_id and self.location_id.warehouse_id.lot_stock_id.parent_path in self.location_id.parent_path:
            //     dates_info = self.product_id._get_dates_info(self.date, self.location_id, route_ids=route)
            // warehouse = self.warehouse_id or self.picking_type_id.warehouse_id
            // if not self.location_id.warehouse_id:
            //     warehouse = self.rule_id.route_id.supplier_wh_id
            // 
            // move_dest_ids = False
            // if self.procure_method == "make_to_order":
            //     move_dest_ids = self
            // return {
            //     # TODO CLPI: maybe make this a little cleaner
            //     'product_description_variants': self.description_picking and self.description_picking.replace(product_id._get_description(self.picking_type_id), '').replace(product_id._get_picking_description(self.picking_type_id) or '', ''),
            //     'never_product_template_attribute_value_ids': self.never_product_template_attribute_value_ids,
            //     'date_planned': dates_info.get('date_planned'),
            //     'date_order': dates_info.get('date_order'),
            //     'date_deadline': self.date_deadline,
            //     'move_dest_ids': move_dest_ids,
            //     'route_ids': route,
            //     'warehouse_id': warehouse,
            //     'priority': self.priority,
            //     'reference_ids': self.reference_ids,
            //     'orderpoint_id': self.orderpoint_id,
            //     'packaging_uom_id': self.packaging_uom_id,
            //     'procurement_values': self.procurement_values,
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
            //     StockRule = self.env['stock.rule']
            //     if move.location_dest_id.company_id not in self.env.companies:
            //         StockRule = self.env['stock.rule'].sudo()
            //         move = move.with_context(allowed_companies=self.env.user.company_ids.ids)
            //         warehouse_id = False
            // 
            //     related_packages = self.env['stock.package'].search_fetch([('id', 'parent_of', move.move_line_ids.result_package_id.ids)], ['package_type_id'])
            // 
            //     rule = StockRule._get_push_rule(move.product_id, move.location_dest_id, {
            //         'route_ids': move.route_ids | related_packages.package_type_id.route_ids, 'warehouse_id': warehouse_id, 'packaging_uom_id': move.packaging_uom_id,
            //     })
            // 
            //     excluded_rule_ids = []
            //     while (rule and rule.push_domain and not move.filtered_domain(literal_eval(rule.push_domain))):
            //         excluded_rule_ids.append(rule.id)
            //         rule = StockRule._get_push_rule(move.product_id, move.location_dest_id, {
            //             'route_ids': move.route_ids | related_packages.package_type_id.route_ids, 'warehouse_id': warehouse_id, 'packaging_uom_id': move.packaging_uom_id,
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

        protected async Task<StockMove> ReassignSaleLinesInternalAsync(object sale_order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _reassign_sale_lines(self, sale_order):
            // current_order = self.sale_line_id.order_id
            // if len(current_order) <= 1 and current_order != sale_order:
            //     ids_to_reset = set()
            //     if not sale_order:
            //         ids_to_reset.update(self.ids)
            //     else:
            //         line_ids_by_product = dict(self.env['sale.order.line']._read_group(
            //             domain=[('order_id', '=', sale_order.id), ('product_id', 'in', self.product_id.ids)],
            //             aggregates=['id:array_agg'],
            //             groupby=['product_id']
            //         ))
            //         for move in self:
            //             if line_id := line_ids_by_product.get(move.product_id, [])[:1]:
            //                 move.sale_line_id = line_id[0]
            //             else:
            //                 ids_to_reset.add(move.id)
            // 
            //     if ids_to_reset:
            //         self.env['stock.move'].browse(ids_to_reset).sale_line_id = False
            */
            return default;
        }

        protected async Task<StockMove> RecomputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _recompute_state(self):
            // if self.env.context.get('preserve_state'):
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
            //          (move.move_orig_ids and any(orig.product_uom.compare(orig.product_uom_qty, 0) > 0
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
            // def _rollup_move_dests(self, seen=False) -> OrderedSet[int]:
            // return self._rollup_moves(origin=False, seen=seen)
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
            // def _rollup_move_origs(self, seen=False) -> OrderedSet[int]:
            // return self._rollup_moves(seen=seen)
            */
            return default;
        }

        protected async Task<StockMove> RollupMovesInternalAsync(object origin, object seen)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _rollup_moves(self, origin=True, seen=False) -> OrderedSet[int]:
            // """
            //     Find all moves in chain depending the direction (origin)
            // 
            //     origin: if set (default), returns the origin moves, else return the destinations
            // """
            // target_field = "move_orig_ids" if origin else "move_dest_ids"
            // if not seen:
            //     seen = OrderedSet()
            // unseen = OrderedSet(self.ids) - seen
            // if not unseen:
            //     return seen
            // seen.update(unseen)
            // self.filtered(lambda m: m.id in unseen)[target_field]._rollup_moves(origin, seen)
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
            //     if move.product_uom.compare(move.product_uom_qty - old_qties.get(move.id, 0), 0) < 0\
            //             and move.procure_method == 'make_to_order'\
            //             and all(m.state == 'done' for m in move.move_orig_ids):
            //         continue
            //     if move.product_uom.compare(move.product_uom_qty, 0) > 0:
            //         if move._should_bypass_reservation() \
            //                 or move.picking_type_id.reservation_method == 'at_confirm' \
            //                 or (move.reservation_date and move.reservation_date <= fields.Date.today()):
            //             to_assign |= move
            // 
            //     if move.procure_method == 'make_to_order' or move.rule_id.procure_method == 'mts_else_mto':
            //         procurement_qty = move.product_uom_qty - old_qties.get(move.id, 0)
            //         possible_reduceable_qty = -sum(move.move_orig_ids.filtered(lambda m: m.state not in ('done', 'cancel') and m.product_uom_qty).mapped('product_uom_qty'))
            //         procurement_qty = max(procurement_qty, possible_reduceable_qty)
            //         values = move._prepare_procurement_values()
            //         procurements.append(self.env['stock.rule'].Procurement(
            //             move.product_id, procurement_qty, move.product_uom,
            //             move.location_id, move.reference, move.origin, move.company_id, values))
            // 
            // to_assign._action_assign()
            // if procurements:
            //     self.env['stock.rule'].run(procurements)
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
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit')
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
            // order = order.sudo()
            // fpos = order.fiscal_position_id or order.fiscal_position_id._get_fiscal_position(order.partner_id)
            // product_taxes = self.product_id.sudo().taxes_id._filter_taxes_by_company(order.company_id)
            // taxes = fpos.map_tax(product_taxes)
            // 
            // return {
            //     'order_id': order.id,
            //     'name': self.reference,
            //     'sequence': last_sequence,
            //     'price_unit': price,
            //     'tax_ids': [x.id for x in taxes],
            //     'discount': 0.0,
            //     'product_id': self.product_id.id,
            //     'product_uom_qty': self.product_uom_qty,
            //     'qty_delivered': self.quantity,
            // }
            */
            return default;
        }

        protected async Task<StockMove> SearchPickingForAssignationDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _search_picking_for_assignation_domain(self):
            // domain = super()._search_picking_for_assignation_domain()
            // domain += [('production_group_id', '=', self.production_group_id.id)]
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _search_picking_for_assignation_domain(self):
            // domain = [
            //     ('reference_ids', '=', self.reference_ids.ids),
            //     ('location_id', '=', self.location_id.id),
            //     ('location_dest_id', '=', (self.location_dest_id.id or self.picking_type_id.default_location_dest_id.id)),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('printed', '=', False),
            //     ('state', 'in', ['draft', 'confirmed', 'waiting', 'partially_available', 'assigned'])]
            // if self.partner_id and not self.reference_ids:
            //     domain += [('partner_id', '=', self.partner_id.id)]
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def _search_picking_for_assignation_domain(self):
            // domain = super()._search_picking_for_assignation_domain()
            // domain = Domain.AND([domain, ['|', ('batch_id', '=', False), ('batch_id.is_wave', '=', False)]])
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

        public async Task<StockMove> SearchRemainingQtyAsync(Guid id, StockMoveSearchRemainingQtyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def search_remaining_qty(self, operator, value):
            // if operator != '=' or not isinstance(value, bool) or value is not True:
            //     raise UserError(_("Only is set (= True) is supported in search for remaining_qty."))
            // products = 'default_product_id' in self.env.context and self.env['product.product'].browse(self.env.context['default_product_id']) or self.env['product.product']
            // if not products:
            //     products = self.env['product.product'].search([('is_storable', '=', True), ('qty_available', '>', 0)])
            // move_ids = []
            // for qty_by_move in products._get_remaining_moves().values():
            //     for move in qty_by_move:
            //         move_ids.append(move.id)
            // return [('id', 'in', move_ids)]
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     moves_to_update = (move.move_dest_ids | move.move_orig_ids)
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
            //     if move.state == 'assigned' and all(ml.lot_id in move.lot_ids for ml in move.move_line_ids):
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
            //                     'lot_id': lot.id,
            //                     'product_uom_id': move.product_id.uom_id.id if move.product_id.tracking == 'serial' else move.product_uom.id,
            //                     'quantity': 1 if move.product_id.tracking == 'serial' else move.quantity,
            //                 }))
            //                 mls_without_lots -= move_line
            //             else:  # No line without serial number, creates a new one.
            //                 reserved_quants = self.env['stock.quant'].with_context(packaging_uom_id=move.packaging_uom_id)._get_reserve_quantity(move.product_id, move.location_id, 1.0, lot_id=lot)
            //                 if reserved_quants:
            //                     move_line_vals = self._prepare_move_line_vals(quantity=0, reserved_quant=reserved_quants[0][0])
            //                 else:
            //                     move_line_vals = self._prepare_move_line_vals(quantity=0)
            //                     move_line_vals['lot_id'] = lot.id
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
            // def _move_qty(qty):
            //     return self.product_id.uom_id._compute_quantity(qty, self.product_uom, round=False)
            // 
            // self.ensure_one()
            // res = []
            // qty = self.product_uom._compute_quantity(qty, self.product_id.uom_id, round=False)
            // total_qty = qty
            // consumed_quant = set()
            // for ml in self.move_line_ids:
            //     ml_qty = ml.quantity
            //     if ml.product_uom_id.compare(ml_qty, 0) < 0:
            //         continue
            // 
            //     if ml.product_uom_id != self.product_id.uom_id:
            //         ml_qty = ml.product_uom_id._compute_quantity(ml_qty, self.product_id.uom_id, round=False)
            // 
            //     if self.product_uom.is_zero(_move_qty(qty)):
            //         res.append(Command.delete(ml.id))
            //         continue
            // 
            //     if ml.product_id.uom_id.compare(ml_qty, qty) > 0:
            //         if ml.product_uom_id != self.product_id.uom_id:
            //             qty = ml.product_id.uom_id._compute_quantity(qty, ml.product_uom_id, round=False)
            //         res.append(Command.update(ml.id, {'quantity': qty}))
            //         qty = 0
            //         continue
            // 
            //     if ml.result_package_id:
            //         qty -= ml_qty
            //         continue
            //     # remove what already on the line
            //     taken_qty = min(qty, ml_qty)
            //     qty -= taken_qty
            //     if self.product_uom.compare(_move_qty(qty), 0) <= 0:
            //         continue
            // 
            //     # find a quant similar to the move line on which we can reserve
            //     ml_quants = self.env['stock.quant']._get_reserve_quantity(self.product_id,
            //                                                               ml.location_id,
            //                                                               qty,
            //                                                               lot_id=ml.lot_id,
            //                                                               package_id=ml.package_id,
            //                                                               owner_id=ml.owner_id,
            //                                                               strict=True)
            //     avail_qty = sum(q[1] for q in ml_quants)
            //     # the quant did not add the quantity reserved on this specific move line
            //     consumed_quant |= {q[0].id for q in ml_quants}
            //     if self.product_uom.compare(avail_qty, qty) <= 0:
            //         qty -= avail_qty  # decrease the target quantity for the next move lines
            //         avail_qty += ml_qty  # add the actual move line quantity as we will update it and not `+=` it
            //         if ml.product_uom_id != self.product_id.uom_id:
            //             avail_qty = ml.product_id.uom_id._compute_quantity(avail_qty, ml.product_uom_id, round=False)
            //         res.append(Command.update(ml.id, {'quantity': avail_qty}))
            // 
            // # First reserve on quants
            // if self.product_uom.compare(_move_qty(qty), 0.0) > 0:
            //     quants = self.env['stock.quant']._get_reserve_quantity(self.product_id, self.location_id, total_qty)
            //     for quant, avail_qty in quants:
            //         if quant.id in consumed_quant:
            //             continue
            //         # compare the stock move quantity with the product free quantity
            //         taken_qty = min(qty, avail_qty)
            //         qty -= taken_qty
            //         res.append(Command.create(self._prepare_move_line_vals(quantity=taken_qty, reserved_quant=quant)))
            //         if self.product_id.uom_id.compare(_move_qty(qty), 0.0) <= 0:
            //             break
            // 
            // # If quant is not enough, create a(some) move lines from the move itself
            // if self.product_uom.compare(_move_qty(qty), 0.0) > 0:
            //     if self.product_id.tracking != 'serial':
            //         qty = _move_qty(qty)
            //         vals = self._prepare_move_line_vals(quantity=0)
            //         vals['quantity'] = qty
            //         res.append((0, 0, vals))
            //     else:
            //         for _i in range(0, int(qty)):
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
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_quantity(self):
            //         def _process_decrease(move, quantity):
            //             mls_to_unlink = set()
            //             # Since the move lines might have been created in a certain order to respect
            //             # a removal strategy, they need to be unreserved in the opposite order
            //             for ml in reversed(move.move_line_ids.sorted('id')):
            //                 if self.env.context.get('unreserve_unpicked_only') and ml.picked:
            //                     continue
            //                 if move.product_uom.is_zero(quantity):
            //                     break
            //                 qty_ml_dec = min(ml.quantity, ml.product_uom_id._compute_quantity(quantity, ml.product_uom_id, round=False))
            //                 if ml.product_uom_id.is_zero(qty_ml_dec):
            //                     continue
            //                 if ml.product_uom_id.compare(ml.quantity, qty_ml_dec) == 0 and ml.state not in ['done', 'cancel']:
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
            //         precision_digits = self.env['decimal.precision'].precision_get('Product Unit')
            //         for move in self:
            //             rounded_qty = float_round(move.quantity, precision_digits=precision_digits, rounding_method='HALF-UP')
            //             if float_compare(rounded_qty, move.quantity, precision_digits=precision_digits) != 0:
            //                 err.append(_("""
            // The quantity done for the product %(product)s doesn't respect the rounding precision defined on the system.
            // Please change the quantity done or the rounding precision in your settings.""",
            //                              product=move.product_id.display_name))
            //                 continue
            //             delta_qty = move.quantity - move._quantity_sml()
            //             if move.product_uom.compare(delta_qty, 0) > 0:
            //                 _process_increase(move, delta_qty)
            //             elif move.product_uom.compare(delta_qty, 0) < 0:
            //                 _process_decrease(move, abs(delta_qty))
            //         if err:
            //             raise UserError('\n'.join(err))
            */
            return default;
        }

        protected async Task<StockMove> SetReferencesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _set_references(self):
            // super()._set_references()
            // for move in self:
            //     if move.reference_ids:
            //         continue
            //     production = move.raw_material_production_id or move.production_id
            //     if production:
            //         move.reference_ids = [Command.set(production.reference_ids.ids)]
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _set_references(self):
            // for move in self:
            //     if not move.reference_ids and move.picking_id:
            //         move.reference_ids = move.picking_id.reference_ids
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

        protected async Task<StockMove> SetValueInternalAsync(object correction_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _set_value(self, correction_quantity=None):
            // """Set the value of the move.
            // 
            // :param correction_quantity: if set, it means that the quantity of the move has been
            //     changed by this amount (can be positive or negative). In that case, we just update
            //     the value of the move based on the ratio of extra_quantity / quantity. It only applies
            //     on out_move since their value is computed during action_done, and it's used to get a
            //     more accurate value for COGS. In case of in move correction, you have to call _set_value
            //     without arguments.
            // """
            // products_to_recompute = set()
            // lots_to_recompute = set()
            // fifo_qty_processed = defaultdict(float)
            // 
            // for move in self:
            //     # Incoming moves
            //     if move.is_dropship or move.is_in:
            //         products_to_recompute.add(move.product_id.id)
            //         if move.product_id.lot_valuated:
            //             lots_to_recompute.update(move.move_line_ids.lot_id.ids)
            //     if move.is_in:
            //         move.value = move.sudo()._get_value()
            //         continue
            //     # Outgoing moves
            //     if not move._is_out():
            //         continue
            //     if correction_quantity:
            //         previous_qty = move.quantity - correction_quantity
            //         ratio = correction_quantity / previous_qty if previous_qty else 0
            //         move.value += ratio * move.value
            //         continue
            //     if move.product_id.lot_valuated:
            //         value = 0.0
            //         for move_line in move.move_line_ids:
            //             if move_line.lot_id:
            //                 value += move_line.lot_id.standard_price * move_line.quantity_product_uom
            //             else:
            //                 value += move.product_id.standard_price * move_line.quantity_product_uom
            //         move.value = value
            //         continue
            // 
            //     if move.product_id.cost_method == 'fifo':
            //         valued_qty = move._get_valued_qty()
            //         move.value = move.product_id.with_context(fifo_qty_already_processed=fifo_qty_processed[move.product_id])._run_fifo(valued_qty)
            //         fifo_qty_processed[move.product_id] += valued_qty
            //     else:
            //         qty = move.product_uom._compute_quantity(move.quantity, move.product_id.uom_id, rounding_method='HALF-UP')
            //         move.value = move.product_id.standard_price * qty
            // 
            // # Recompute the standard price
            // self.env['product.product'].browse(products_to_recompute)._update_standard_price()
            // self.env['stock.lot'].browse(lots_to_recompute)._update_standard_price()
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
            // return self.product_uom.is_zero(self.product_uom_qty)
            */
            return default;
        }

        protected async Task<StockMove> ShouldCreateAccountMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py) ---
            // def _should_create_account_move(self):
            // """Determines if an account move should be created for this move.
            // :return: True if an account move should be created, False otherwise.
            // """
            // self.ensure_one()
            // return self.product_id.is_storable and self.is_valued\
            // and (self.location_dest_id.valuation_account_id or self.location_id.valuation_account_id)\
            // and self.product_id.valuation == 'real_time'
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
            //     action['name'] = _("Components")
            //     action['views'] = [(self.env.ref('mrp.view_stock_move_operations_raw').id, 'form')]
            //     action['context']['show_destination_location'] = False
            //     action['context']['force_manual_consumption'] = True
            //     action['context']['active_mo_id'] = self.raw_material_production_id.id
            // elif self.production_id:
            //     action['name'] = _("Move Byproduct")
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
            // if self.is_subcontract:
            //     action = super(StockMove, self.with_context(force_lot_m2o=True)).action_show_details()
            //     if self.env.user._is_portal():
            //         action['views'] = [(self.env.ref('mrp_subcontracting.mrp_subcontracting_view_stock_move_operations').id, 'form')]
            //     return action
            // return super().action_show_details()
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
            //         allow_parent_move_picked_reset=True,
            //     ),
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py) ---
            // def action_show_details(self):
            // action = super().action_show_details()
            // if self.picking_id.batch_id:
            //     action['context']['default_picking_id'] = self.picking_id.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMove> ShowSubcontractDetailsAsync(Guid id, StockMoveShowSubcontractDetailsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def action_show_subcontract_details(self, lot_id=None):
            // """ Display moves raw for subcontracted product self. """
            // productions = self._get_subcontract_production().filtered(lambda m: m.state != 'cancel')
            // if lot_id is not None:
            //     if lot_id:
            //         productions = productions.filtered(lambda p: p.lot_producing_ids and p.lot_producing_ids[0] == self.env['stock.lot'].browse(lot_id))
            //     else:
            //         productions = productions.filtered(lambda p: not p.lot_producing_ids)
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
            // else:
            //     action.update({
            //         'views': [(form_view_id.id, 'form')],
            //         'res_id': productions.id,
            //     })
            // return action
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
            // if self.product_id.uom_id.is_zero(qty):
            //     return []
            // 
            // decimal_precision = self.env['decimal.precision'].precision_get('Product Unit')
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
            // new_product_qty = float_round(new_product_qty, precision_digits=self.env['decimal.precision'].precision_get('Product Unit'))
            // self.with_context(do_not_unreserve=True).write({'product_uom_qty': new_product_qty})
            // self._recompute_state()
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

        protected async Task<StockMove> SyncSubcontractingProductionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py) ---
            // def _sync_subcontracting_productions(self):
            // """
            //     Enforce the relationship between subcontracting receipt moves and their respective subcontracting productions.
            //     * For untracked moves:
            //         * There will always be only 1 production.
            //         * Updating the move quantity will update the production quantity.
            //     * For tracked moves:
            //         * There will be 1 production for every lot on this move.
            //         * This method will enforce the synchronisation between the total quantity per lot on the move and the linked productions.
            //         * The split mechanism for productions will be used to create new subcontracting MOs.
            //         * We take care to always keep at least 1 subcontracting production linked to the subcontracting receipt.
            //           This ensures there will always be a production available for splitting.
            // """
            // for move in self:
            //     productions = move._get_subcontract_production()
            //     if not productions:
            //         continue
            //     if move.has_tracking == 'none':
            //         if productions.product_uom_id.compare(productions.product_qty, move.quantity) != 0:
            //             self.sudo().env['change.production.qty'].with_context(skip_activity=True).create([{
            //                 'mo_id': productions.id,
            //                 'product_qty': move.quantity or move.product_uom_qty,
            //             }]).change_prod_qty()
            //             productions.action_assign()
            //     else:
            //         qty_by_lot = dict(move.move_line_ids._read_group([('move_id', '=', move.id)], ['lot_id'], ['quantity_product_uom:sum']))
            //         mos_to_assign = self.env['mrp.production']
            // 
            //         # 1. Ensure quantities of linked MOs still match the quantities on the move
            //         mos_to_create = {}  # lot -> qty
            //         for lot_id, ml_qty in qty_by_lot.items():
            //             lot_mo = productions.filtered(lambda p: (p.lot_producing_ids and p.lot_producing_ids[0] == lot_id) or (not lot_id and not p.lot_producing_ids))
            //             if not lot_mo:
            //                 mos_to_create[lot_id] = ml_qty
            //             elif lot_mo.product_uom_id.compare(lot_mo.product_qty, ml_qty) != 0:
            //                 self.sudo().env['change.production.qty'].with_context(skip_activity=True).create([{
            //                     'mo_id': lot_mo.id,
            //                     'product_qty': ml_qty
            //                 }]).change_prod_qty()
            //                 mos_to_assign |= lot_mo
            // 
            //         # 2. Create new MOs where needed, by splitting them from an existing subcontracting MO
            //         if mos_to_create:
            //             production_to_split = move._get_subcontract_production()[0]
            //             new_mos = production_to_split.sudo().with_context(allow_more=True, mrp_subcontracting=False)._split_productions({
            //                 production_to_split: [production_to_split.product_qty] + list(mos_to_create.values())
            //             }, cancel_remaining_qty=True)[1:]
            //             mos_to_assign |= new_mos
            //             for mo, lot_id in zip(new_mos, mos_to_create.keys()):
            //                 mo.lot_producing_ids = lot_id
            // 
            //         # 3. Delete 'orphan' MOs with lot not linked to any move line
            //         productions = move._get_subcontract_production()
            //         orphan_productions = productions.filtered(lambda p: (p.lot_producing_ids and p.lot_producing_ids[0] not in qty_by_lot) or (not p.lot_producing_ids and self.env['stock.lot'] not in qty_by_lot))
            //         if len(productions) == len(orphan_productions):
            //             # Make sure not to delete all MOs, leave 1 subcontracting MO as 'open' MO for splitting later
            //             production_to_keep = orphan_productions[-1]
            //             production_to_keep.lot_producing_ids = False
            //             orphan_productions = orphan_productions[:-1]
            //         if orphan_productions:
            //             orphan_productions.sudo().with_context(skip_activity=True).unlink()
            //             productions -= orphan_productions
            // 
            //         mos_to_assign.sudo().action_assign()
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
            // product_domains = Domain.OR(
            //     [('product_id', '=', move.product_id.id), ('location_id', '=', move.location_dest_id.id)]
            //     for move in self
            // )
            // static_domain = [('state', 'in', ['confirmed', 'partially_available']),
            //                  ('procure_method', '=', 'make_to_stock'),
            //                  '|',
            //                     ('reservation_date', '<=', fields.Date.today()),
            //                     ('picking_type_id.reservation_method', '=', 'at_confirm')
            //                 ]
            // moves_to_reserve = self.env['stock.move'].search(
            //     Domain(static_domain) & product_domains,
            //     order='priority desc, date asc, id asc')
            // moves_to_reserve = moves_to_reserve.sorted(key=lambda m: any(r in self.reference_ids.ids for r in m.reference_ids.ids), reverse=True)
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
            //     if orderpoint and move.product_qty > orderpoint.product_min_qty and move.reference_ids:
            //         orderpoints_context_by_company[orderpoint.company_id].setdefault(orderpoint.id, set())
            //         orderpoints_context_by_company[orderpoint.company_id][orderpoint.id] |= set(move.reference_ids.ids)
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

        protected async Task<StockMove> UpdateOrderpointsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _update_orderpoints(self):
            // """ Manually mark the relevant orderpoints for re-computation.
            // This allows us to only recompute the qty_to_order for the orderpoints in the relevant warehouse(s),
            // instead of all the orderpoints linked to the product."""
            // if not self:
            //     return
            // domains = []
            // for move in self:
            //     domain_for_move = Domain('product_id', '=', move.product_id.id)
            //     wh_ids = move.location_id.warehouse_id.ids + move.location_dest_id.warehouse_id.ids
            //     if wh_ids:
            //         domain_for_move &= Domain('warehouse_id', 'in', wh_ids)
            //     domains.append(domain_for_move)
            // orderpoints = self.env['stock.warehouse.orderpoint'].sudo().search(Domain.OR(domains), order='id')
            // orderpoints.invalidate_recordset(['qty_to_order', 'qty_forecast'])
            // self.env.add_to_compute(self.env['stock.warehouse.orderpoint']._fields['qty_to_order_computed'], orderpoints)
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
            // move_line_vals, taken_quantity = self._update_reserved_quantity_vals(need, location_id, lot_id, package_id, owner_id, strict)
            // if move_line_vals:
            //     self.env['stock.move.line'].create(move_line_vals)
            // return taken_quantity
            */
            return default;
        }

        protected async Task<StockMove> UpdateReservedQuantityValsInternalAsync(object need, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _update_reserved_quantity_vals(self, need, location_id, lot_id=None, package_id=None, owner_id=None, strict=True):
            // self.ensure_one()
            // if not lot_id:
            //     lot_id = self.env['stock.lot']
            // if not package_id:
            //     package_id = self.env['stock.package']
            // if not owner_id:
            //     owner_id = self.env['res.partner']
            // 
            // quants = self.env['stock.quant'].with_context(packaging_uom_id=self.packaging_uom_id)._get_reserve_quantity(
            //     self.product_id, location_id, need, uom_id=self.product_uom,
            //     lot_id=lot_id, package_id=package_id, owner_id=owner_id, strict=strict)
            // 
            // taken_quantity = 0
            // rounding = self.env['decimal.precision'].precision_get('Product Unit')
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
            // return move_line_vals, taken_quantity
            */
            return default;
        }

        protected async Task<StockMove> VisibleQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move.py) ---
            // def _visible_quantity(self):
            // self.ensure_one()
            // return self.quantity
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
            // if self.env.context.get('force_manual_consumption') and 'quantity' in vals:
            //     moves_to_update = self.filtered(lambda move: move.product_uom_qty != vals['quantity'])
            //     if moves_to_update:
            //         moves_to_update.write({'manual_consumption': True, 'picked': True})
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
            // def write(self, vals):
            // """ If the initial demand is updated then also update the linked
            // subcontract order to the new quantity.
            // """
            // self._check_access_if_subcontractor(vals)
            // res = super().write(vals)
            // if 'date' in vals:
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
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'product_id' in vals:
            //     for move in self:
            //         if move.sale_line_id and move.product_id != move.sale_line_id.product_id:
            //             move.sale_line_id = False
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
            // if 'product_uom' in vals and any(move.state == 'done' for move in self) and not self.env.context.get('skip_uom_conversion'):
            //     raise UserError(_('You cannot change the UoM for a stock move that has been set to \'Done\'.'))
            // if 'product_uom_qty' in vals:
            //     for move in self.filtered(lambda m: m.state not in ('done', 'draft') and m.picking_id):
            //         if move.product_uom.compare(vals['product_uom_qty'], move.product_uom_qty):
            //             self.env['stock.move.line']._log_message(move.picking_id, move, 'stock.track_move_template', vals)
            //     if self.env.context.get('do_not_unreserve') is None:
            //         move_to_unreserve = self.filtered(
            //             lambda m: m.state not in ['draft', 'done', 'cancel'] and m.product_uom.compare(m.quantity, vals.get('product_uom_qty')) == 1
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
            // if 'date_deadline' in vals:
            //     self._set_date_deadline(vals.get('date_deadline'))
            // if 'move_orig_ids' in vals:
            //     move_to_recompute_state |= self.filtered(lambda m: m.state not in ['draft', 'cancel', 'done'])
            // if 'location_id' in vals:
            //     move_to_check_location = self.filtered(lambda m: m.location_id.id != vals.get('location_id'))
            // if 'product_id' in vals or 'location_id' in vals or 'location_dest_id' in vals:
            //     self._update_orderpoints()
            // res = super().write(vals)
            // moves_done = self.filtered(lambda m: m.state == 'done')
            // if 'date' in vals and moves_done:
            //     moves_done.move_line_ids.date = vals['date']
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
            // if ('product_id' in vals or 'state' in vals or 'date' in vals or 'product_uom_qty' in vals or
            //         'location_id' in vals or 'location_dest_id' in vals):
            //     self._update_orderpoints()
            // if 'picking_id' in vals:
            //     self._set_references()
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