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
    [Module("Stock", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockMoveLineAppService : GenericApplicationService<StockMoveLine>, IStockMoveLineAppService
    {

        public StockMoveLineAppService(IRepository<StockMoveLine, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockMoveLine> ActionDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _action_done(self):
            // """ This method is called during a move's `action_done`. It'll actually move a quant from
            // the source location to the destination location, and unreserve if needed in the source
            // location.
            // 
            // This method is intended to be called on all the move lines of a move. This method is not
            // intended to be called when editing a `done` move (that's what the override of `write` here
            // is done.
            // """
            // 
            // # First, we loop over all the move lines to do a preliminary check: `quantity` should not
            // # be negative and, according to the presence of a picking type or a linked inventory
            // # adjustment, enforce some rules on the `lot_id` field. If `quantity` is null, we unlink
            // # the line. It is mandatory in order to free the reservation and correctly apply
            // # `action_done` on the next move lines.
            // ml_ids_tracked_without_lot = OrderedSet()
            // ml_ids_to_delete = OrderedSet()
            // ml_ids_to_create_lot = OrderedSet()
            // ml_ids_to_check = defaultdict(OrderedSet)
            // 
            // for ml in self:
            //     # Check here if `ml.quantity` respects the rounding of `ml.product_uom_id`.
            //     uom_qty = float_round(ml.quantity, precision_rounding=ml.product_uom_id.rounding, rounding_method='HALF-UP')
            //     precision_digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     quantity = float_round(ml.quantity, precision_digits=precision_digits, rounding_method='HALF-UP')
            //     if float_compare(uom_qty, quantity, precision_digits=precision_digits) != 0:
            //         raise UserError(_('The quantity done for the product "%(product)s" doesn\'t respect the rounding precision '
            //                           'defined on the unit of measure "%(unit)s". Please change the quantity done or the '
            //                           'rounding precision of your unit of measure.',
            //                           product=ml.product_id.display_name, unit=ml.product_uom_id.name))
            // 
            //     qty_done_float_compared = float_compare(ml.quantity, 0, precision_rounding=ml.product_uom_id.rounding)
            //     if qty_done_float_compared > 0:
            //         if ml.product_id.tracking == 'none':
            //             continue
            //         picking_type_id = ml.move_id.picking_type_id
            //         if not picking_type_id and not ml.is_inventory and not ml.lot_id and not ml.move_id.scrap_id:
            //             ml_ids_tracked_without_lot.add(ml.id)
            //             continue
            //         if not picking_type_id or ml.lot_id or (not picking_type_id.use_create_lots and not picking_type_id.use_existing_lots):
            //             # If the user disabled both `use_create_lots` and `use_existing_lots`
            //             # checkboxes on the picking type, he's allowed to enter tracked
            //             # products without a `lot_id`.
            //             continue
            //         if picking_type_id.use_create_lots:
            //             ml_ids_to_check[(ml.product_id, ml.company_id)].add(ml.id)
            //         else:
            //             ml_ids_tracked_without_lot.add(ml.id)
            // 
            //     elif qty_done_float_compared < 0:
            //         raise UserError(_('No negative quantities allowed'))
            //     elif not ml.is_inventory:
            //         ml_ids_to_delete.add(ml.id)
            // 
            // for (product, company), mls in ml_ids_to_check.items():
            //     mls = self.env['stock.move.line'].browse(mls)
            //     lots = self.env['stock.lot'].search([
            //         '|', ('company_id', '=', False), ('company_id', '=', ml.company_id.id),
            //         ('product_id', '=', product.id),
            //         ('name', 'in', mls.mapped('lot_name')),
            //     ])
            //     lots = {lot.name: lot for lot in lots}
            //     for ml in mls:
            //         lot = lots.get(ml.lot_name)
            //         if lot:
            //             ml.lot_id = lot.id
            //         elif ml.lot_name:
            //             ml_ids_to_create_lot.add(ml.id)
            //         else:
            //             ml_ids_tracked_without_lot.add(ml.id)
            // 
            // if ml_ids_tracked_without_lot:
            //     mls_tracked_without_lot = self.env['stock.move.line'].browse(ml_ids_tracked_without_lot)
            //     products_list = "\n".join(f"- {product_name}" for product_name in mls_tracked_without_lot.mapped("product_id.display_name"))
            //     raise UserError(
            //         _(
            //             "You need to supply a Lot/Serial Number for product:\n%(products)s",
            //             products=products_list,
            //         ),
            //     )
            // if ml_ids_to_create_lot:
            //     self.env['stock.move.line'].browse(ml_ids_to_create_lot)._create_and_assign_production_lot()
            // 
            // mls_to_delete = self.env['stock.move.line'].browse(ml_ids_to_delete)
            // mls_to_delete.unlink()
            // 
            // mls_todo = (self - mls_to_delete)
            // mls_todo._check_company()
            // 
            // # Now, we can actually move the quant.
            // ml_ids_to_ignore = OrderedSet()
            // quants_cache = self.env['stock.quant']._get_quants_by_products_locations(
            //     mls_todo.product_id, mls_todo.location_id | mls_todo.location_dest_id,
            //     extra_domain=['|', ('lot_id', 'in', mls_todo.lot_id.ids), ('lot_id', '=', False)])
            // 
            // for ml in mls_todo.with_context(quants_cache=quants_cache):
            //     # if this move line is force assigned, unreserve elsewhere if needed
            //     ml._synchronize_quant(-ml.quantity_product_uom, ml.location_id, action="reserved")
            //     available_qty, in_date = ml._synchronize_quant(-ml.quantity_product_uom, ml.location_id)
            //     ml._synchronize_quant(ml.quantity_product_uom, ml.location_dest_id, package=ml.result_package_id, in_date=in_date)
            //     if available_qty < 0:
            //         ml._free_reservation(
            //             ml.product_id, ml.location_id,
            //             abs(available_qty), lot_id=ml.lot_id, package_id=ml.package_id,
            //             owner_id=ml.owner_id, ml_ids_to_ignore=ml_ids_to_ignore)
            //     ml_ids_to_ignore.add(ml.id)
            // # Reset the reserved quantity as we just moved it to the destination location.
            // mls_todo.write({
            //     'date': fields.Datetime.now(),
            // })
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def _action_done(self):
            // for line in self:
            //     if not line.lot_id and not line.lot_name and line.product_id.lot_valuated:
            //         raise UserError(_("Lot/Serial number is mandatory for product valuated by lot"))
            // return super()._action_done()
            */
            return default;
        }

        protected async Task<StockMoveLine> AddToWaveInternalAsync(object wave, object description)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _add_to_wave(self, wave=False, description=False):
            // """ Detach lines (and corresponding stock move from a picking to another). If wave is
            // passed, attach new picking into it. If not attach line to their original picking.
            // 
            // :param int wave: id of the wave picking on which to put the move lines. """
            // 
            // if not wave:
            //     wave = self.env['stock.picking.batch'].create({
            //         'is_wave': True,
            //         'picking_type_id': self.picking_type_id and self.picking_type_id[0].id,
            //         'user_id': self.env.context.get('active_owner_id'),
            //         'description': description,
            //     })
            // line_by_picking = defaultdict(lambda: self.env['stock.move.line'])
            // for line in self:
            //     line_by_picking[line.picking_id] |= line
            // picking_to_wave_vals_list = []
            // for picking, lines in line_by_picking.items():
            //     # Move the entire picking if all the line are taken
            //     line_by_move = defaultdict(lambda: self.env['stock.move.line'])
            //     qty_by_move = defaultdict(float)
            //     for line in lines:
            //         move = line.move_id
            //         line_by_move[move] |= line
            //         qty = line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id, rounding_method='HALF-UP')
            //         qty_by_move[line.move_id] += qty
            // 
            //     # If all moves are to be transferred to the wave, link the picking to the wave
            //     if lines == picking.move_line_ids and lines.move_id == picking.move_ids:
            //         add_all_moves = True
            //         for move, qty in qty_by_move.items():
            //             if float_is_zero(qty, precision_rounding=move.product_uom.rounding):
            //                 add_all_moves = False
            //                 break
            //         if add_all_moves:
            //             wave.picking_ids = [Command.link(picking.id)]
            //             continue
            // 
            //     # Split the picking in two part to extract only line that are taken on the wave
            //     picking_to_wave_vals = picking.copy_data({
            //         'move_ids': [],
            //         'move_line_ids': [],
            //         'batch_id': wave.id,
            //         'scheduled_date': picking.scheduled_date,
            //     })[0]
            //     for move, move_lines in line_by_move.items():
            //         picking_to_wave_vals['move_line_ids'] += [Command.link(line.id) for line in lines]
            //         # if all the line of a stock move are taken we change the picking on the stock move
            //         if move_lines == move.move_line_ids:
            //             picking_to_wave_vals['move_ids'] += [Command.link(move.id)]
            //             continue
            //         # Split the move
            //         qty = qty_by_move[move]
            //         new_move = move._split(qty)
            //         new_move[0]['move_line_ids'] = [Command.set(move_lines.ids)]
            //         picking_to_wave_vals['move_ids'] += [Command.create(new_move[0])]
            // 
            //     picking_to_wave_vals_list.append(picking_to_wave_vals)
            // 
            // if picking_to_wave_vals_list:
            //     self.env['stock.picking'].create(picking_to_wave_vals_list)
            // if wave.picking_type_id.batch_auto_confirm:
            //     wave.action_confirm()
            */
            return default;
        }

        protected async Task<StockMoveLine> ApplyPutawayStrategyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _apply_putaway_strategy(self):
            // if self._context.get('avoid_putaway_rules'):
            //     return
            // self = self.with_context(do_not_unreserve=True)
            // for package, smls in groupby(self, lambda sml: sml.result_package_id):
            //     smls = self.env['stock.move.line'].concat(*smls)
            //     excluded_smls = set(smls.ids)
            //     if package.package_type_id:
            //         best_loc = smls.move_id.location_dest_id.with_context(exclude_sml_ids=excluded_smls, products=smls.product_id)._get_putaway_strategy(self.env['product.product'], package=package)
            //         smls.location_dest_id = smls.package_level_id.location_dest_id = best_loc
            //     elif package:
            //         used_locations = set()
            //         for sml in smls:
            //             if len(used_locations) > 1:
            //                 break
            //             sml.location_dest_id = sml.move_id.location_dest_id.with_context(exclude_sml_ids=excluded_smls)._get_putaway_strategy(sml.product_id, quantity=sml.quantity)
            //             excluded_smls.discard(sml.id)
            //             used_locations.add(sml.location_dest_id)
            //         if len(used_locations) > 1:
            //             for move, grouped_smls in smls.grouped('move_id').items():
            //                 grouped_smls.location_dest_id = move.location_dest_id
            //         else:
            //             smls.package_level_id.location_dest_id = smls.location_dest_id
            //     else:
            //         for sml in smls:
            //             putaway_loc_id = sml.move_id.location_dest_id.with_context(exclude_sml_ids=excluded_smls)._get_putaway_strategy(
            //                 sml.product_id, quantity=sml.quantity, packaging=sml.move_id.product_packaging_id,
            //             )
            //             if putaway_loc_id != sml.location_dest_id:
            //                 sml.location_dest_id = putaway_loc_id
            //             excluded_smls.discard(sml.id)
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py) ---
            // def _auto_init(self):
            // """ Create column for 'expiration_date' here to avoid MemoryError when letting
            // the ORM compute it after module installation. Since both 'lot_id.expiration_date'
            // and 'product_id.use_expiration_date' are new fields introduced in this module,
            // there is no need for an UPDATE statement here.
            // """
            // if not column_exists(self._cr, "stock_move_line", "expiration_date"):
            //     create_column(self._cr, "stock_move_line", "expiration_date", "timestamp")
            // return super()._auto_init()
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _auto_wave(self):
            // """ Try to find compatible waves to attach the move lines to, otherwise create new waves when possible/appropriate. """
            // wave_locs_by_picking_type = {}
            // for picking_type in self.picking_type_id:
            //     if not picking_type.wave_group_by_location:
            //         continue
            //     if picking_type in wave_locs_by_picking_type:
            //         continue
            //     wave_locs_by_picking_type[picking_type] = set(picking_type.wave_location_ids.ids)
            // lines_nearest_parent_locations = defaultdict(lambda: self.env['stock.location'])
            // batchable_line_ids = OrderedSet()
            // for line in self:
            //     if not line._is_auto_waveable():
            //         continue
            //     if not line.picking_type_id.wave_group_by_location:
            //         batchable_line_ids.add(line.id)
            //         continue
            //     # We want to find the most descendant location in the wave locations list that is a parent of the line location.
            //     # Since the wave locations are ordered by complete_name (from the most descendant to the most ancestor), we can iterate in reverse order.
            //     wave_locs_set = wave_locs_by_picking_type[line.picking_type_id]
            //     loc = line.location_id
            //     while (loc):
            //         if loc.id in wave_locs_set:
            //             lines_nearest_parent_locations[line] = loc
            //             batchable_line_ids.add(line.id)
            //             break
            //         loc = loc.location_id
            // batchable_lines = self.env['stock.move.line'].browse(batchable_line_ids)
            // 
            // remaining_line_ids = batchable_lines._auto_wave_lines_into_existing_waves(nearest_parent_locations=lines_nearest_parent_locations)
            // remaining_lines = self.env['stock.move.line'].browse(remaining_line_ids)
            // if remaining_lines:
            //     remaining_lines._auto_wave_lines_into_new_waves(nearest_parent_locations=lines_nearest_parent_locations)
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveLinesIntoExistingWavesInternalAsync(object nearest_parent_locations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _auto_wave_lines_into_existing_waves(self, nearest_parent_locations=False):
            // """ Try to add move lines to existing waves if possible, return move lines of which no appropriate waves were found to link to
            //  :param nearest_parent_locations (defaultdict): the key is the move line and the value is the nearest parent location in the wave locations list"""
            // remaining_lines = OrderedSet()
            // for (picking_type, lines) in self.grouped(lambda l: l.picking_type_id).items():
            //     if lines:
            //         domain = [
            //             ('picking_type_id', '=', picking_type.id),
            //             ('company_id', 'in', lines.mapped('company_id').ids),
            //             ('is_wave', '=', True)
            //         ]
            //         if picking_type.batch_auto_confirm:
            //             domain = expression.AND([domain, [('state', 'not in', ['done', 'cancel'])]])
            //         else:
            //             domain = expression.AND([domain, [('state', '=', 'draft')]])
            //         if picking_type.batch_group_by_partner:
            //             domain = expression.AND([domain, [('picking_ids.partner_id', 'in', lines.move_id.partner_id.ids)]])
            //         if picking_type.batch_group_by_destination:
            //             domain = expression.AND([domain, [('picking_ids.partner_id.country_id', 'in', lines.move_id.partner_id.country_id.ids)]])
            //         if picking_type.batch_group_by_src_loc:
            //             domain = expression.AND([domain, [('picking_ids.location_id', 'in', lines.location_id.ids)]])
            //         if picking_type.batch_group_by_dest_loc:
            //             domain = expression.AND([domain, [('picking_ids.location_dest_id', 'in', lines.location_dest_id.ids)]])
            // 
            //         potential_waves = self.env['stock.picking.batch'].search(domain)
            //         wave_to_new_lines = defaultdict(set)
            // 
            //         # These dictionaries are used to enforce batch max lines/transfers/weight limits
            //         # Each time a line is matched to a wave, we update the corresponding values
            //         wave_to_new_moves = defaultdict(set)
            //         waves_to_new_pickings = defaultdict(set)
            //         waves_new_extra_weight = defaultdict(float)
            // 
            //         waves_nearest_parent_locations = defaultdict(int)
            //         if picking_type.wave_group_by_location:
            //             valid_wave_ids = set()
            //             # We want to find the most descendant location in the wave locations list that is a parent of all the lines in each wave.
            //             # We also want to exclude waves that have lines that are not in these locations.
            //             for wave in potential_waves:
            //                 for wave_location in reversed(picking_type.wave_location_ids):
            //                     if all(loc._child_of(wave_location) for loc in wave.move_line_ids.location_id):
            //                         waves_nearest_parent_locations[wave] = wave_location.id
            //                         valid_wave_ids.add(wave.id)
            //                         break
            //             potential_waves = self.env['stock.picking.batch'].browse(valid_wave_ids)
            // 
            //         for line in lines:
            //             wave_found = False
            //             for wave in potential_waves:
            //                 if line.company_id != wave.company_id \
            //                 or (picking_type.batch_group_by_partner and line.move_id.partner_id != wave.picking_ids.partner_id) \
            //                 or (picking_type.batch_group_by_destination and line.move_id.partner_id.country_id != wave.picking_ids.partner_id.country_id) \
            //                 or (picking_type.batch_group_by_src_loc and line.location_id != wave.picking_ids.location_id) \
            //                 or (picking_type.batch_group_by_dest_loc and line.location_dest_id != wave.picking_ids.location_dest_id) \
            //                 or (picking_type.wave_group_by_product and line.product_id != wave.move_line_ids.product_id) \
            //                 or (picking_type.wave_group_by_category and line.product_id.categ_id != wave.move_line_ids.product_id.categ_id) \
            //                 or (picking_type.wave_group_by_location and waves_nearest_parent_locations[wave] != nearest_parent_locations[line].id):
            //                     continue
            // 
            //                 wave_new_move_ids = wave_to_new_moves[wave]
            //                 wave_new_picking_ids = waves_to_new_pickings[wave]
            //                 wave_move_ids = set(wave.move_line_ids.mapped('move_id.id'))
            //                 wave_picking_ids = set(wave.move_line_ids.mapped('picking_id.id'))
            //                 # `is_line_auto_mergeable` is a method that checks if the line can be added to the wave without exceeding the limits
            //                 # It takes as arguments the number of new moves that will be added to the wave, the number of new pickings that will be added to the wave
            //                 # and the extra weight that will be added to the wave. So we need to check that the move/picking of the line is not already in the wave
            //                 # so that we don't count them as new moves/pickings.
            //                 if not wave._is_line_auto_mergeable(
            //                     line.move_id.id not in wave_move_ids and line.move_id.id not in wave_new_move_ids and len(wave_new_move_ids) + 1,
            //                     line.picking_id.id not in wave_picking_ids and line.picking_id.id not in wave_new_picking_ids and len(wave_new_picking_ids) + 1,
            //                     waves_new_extra_weight[wave] + line.product_id.weight * line.quantity_product_uom
            //                 ):
            //                     continue
            // 
            //                 if line.move_id.id not in wave_move_ids:
            //                     wave_to_new_moves[wave].add(line.move_id.id)
            //                 if line.picking_id.id not in wave_picking_ids:
            //                     waves_to_new_pickings[wave].add(line.picking_id.id)
            //                 waves_new_extra_weight[wave] += line.product_id.weight * line.quantity_product_uom
            //                 wave_to_new_lines[wave].add(line.id)
            //                 wave_found = True
            //                 break
            //             if not wave_found:
            //                 remaining_lines.add(line.id)
            //         for wave, line_ids in wave_to_new_lines.items():
            //             lines = self.env['stock.move.line'].browse(line_ids)
            //             lines._add_to_wave(wave)
            // return list(remaining_lines)
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveLinesIntoNewWavesInternalAsync(object nearest_parent_locations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _auto_wave_lines_into_new_waves(self, nearest_parent_locations=False):
            // """ Create new waves for the move lines that could not be added to existing waves. """
            // picking_types = self.picking_type_id
            // for picking_type in picking_types:
            //     lines = self.filtered(lambda l: l.picking_type_id == picking_type)
            //     domain = [
            //         ('id', 'in', lines.ids),
            //         ('company_id', 'in', self.company_id.ids),
            //         ('picking_id.state', '=', 'assigned'),
            //         ('picking_type_id', '=', picking_type.id),
            //         '|',
            //         ('batch_id', '=', False),
            //         ('batch_id.is_wave', '=', False)
            //     ]
            //     if picking_type.batch_group_by_partner:
            //         domain = expression.AND([domain, [('move_id.partner_id', 'in', lines.move_id.partner_id.ids)]])
            //     if picking_type.batch_group_by_destination:
            //         domain = expression.AND([domain, [('move_id.partner_id.country_id', 'in', lines.move_id.partner_id.country_id.ids)]])
            //     if picking_type.batch_group_by_src_loc:
            //         domain = expression.AND([domain, [('location_id', 'in', lines.location_id.ids)]])
            //     if picking_type.batch_group_by_dest_loc:
            //         domain = expression.AND([domain, [('location_dest_id', 'in', lines.location_dest_id.ids)]])
            //     if picking_type.wave_group_by_product:
            //         domain = expression.AND([domain, [('product_id', 'in', lines.product_id.ids)]])
            //     if picking_type.wave_group_by_category:
            //         domain = expression.AND([domain, [('product_id.categ_id', 'in', lines.product_id.categ_id.ids)]])
            //     if picking_type.wave_group_by_location:
            //         domain = expression.AND([domain, [('location_id', 'child_of', picking_type.wave_location_ids.ids)]])
            // 
            //     potential_lines = self.env['stock.move.line'].search(domain)
            //     lines_nearest_parent_locations = defaultdict(int)
            //     if picking_type.wave_group_by_location:
            //         for line in potential_lines:
            //             for location in reversed(picking_type.wave_location_ids):
            //                 if line.location_id._child_of(location):
            //                     lines_nearest_parent_locations[line] = location.id
            //                     break
            // 
            //     line_to_lines = defaultdict(set)
            //     matched_lines = set()
            //     remaining_line_ids = OrderedSet()
            //     for line in lines:
            //         lines_found = False
            //         if line.id in matched_lines:
            //             continue
            //         for potential_line in potential_lines:
            //             if line.id == potential_line.id \
            //             or line.company_id != potential_line.company_id \
            //             or (picking_type.batch_group_by_partner and line.move_id.partner_id != potential_line.move_id.partner_id) \
            //             or (picking_type.batch_group_by_destination and line.move_id.partner_id.country_id != potential_line.move_id.partner_id.country_id) \
            //             or (picking_type.batch_group_by_src_loc and line.location_id != potential_line.location_id) \
            //             or (picking_type.batch_group_by_dest_loc and line.location_dest_id != potential_line.location_dest_id) \
            //             or (picking_type.wave_group_by_product and line.product_id != potential_line.product_id) \
            //             or (picking_type.wave_group_by_category and line.product_id.categ_id != potential_line.product_id.categ_id) \
            //             or (picking_type.wave_group_by_location and lines_nearest_parent_locations[potential_line] != nearest_parent_locations[line].id):
            //                 continue
            // 
            //             line_to_lines[line].add(potential_line.id)
            //             matched_lines.add(potential_line.id)
            //             lines_found = True
            //         if not lines_found:
            //             remaining_line_ids.add(line.id)
            // 
            //     for line, potential_line_ids in line_to_lines.items():
            //         if line.batch_id.is_wave:
            //             continue
            // 
            //         potential_lines = self.env['stock.move.line'].browse(potential_line_ids | {line.id})
            // 
            //         # We want to make sure that batch/wave limits specified in the picking type are respected.
            //         # We want also to reduce picking splits as much as possible. So we try to group as much as possible by sorting the lines by picking and move.
            //         potential_lines = potential_lines.sorted(key=lambda l: (l.picking_id.id, l.move_id.id))
            // 
            //         while potential_lines:
            //             new_wave = self.env['stock.picking.batch'].create({
            //                 'is_wave': True,
            //                 'picking_type_id': picking_type.id,
            //                 'description': line._get_auto_wave_description(nearest_parent_locations[line]),
            //             })
            //             wave_move_ids = set()
            //             wave_picking_ids = set()
            //             wave_weight = 0
            // 
            //             wave_line_ids = set()
            // 
            //             for potential_line in potential_lines:
            //                 if potential_line.batch_id.is_wave:
            //                     continue
            //                 wave_move_ids.add(potential_line.move_id.id)
            //                 wave_picking_ids.add(potential_line.picking_id.id)
            //                 wave_weight += potential_line.product_id.weight * potential_line.quantity_product_uom
            //                 if new_wave._is_line_auto_mergeable(
            //                     len(wave_move_ids),
            //                     len(wave_picking_ids),
            //                     wave_weight
            //                 ):
            //                     wave_line_ids.add(potential_line.id)
            //                 else:
            //                     break
            //             wave_lines = self.env['stock.move.line'].browse(wave_line_ids)
            //             wave_lines._add_to_wave(new_wave)
            //             potential_lines -= wave_lines
            // 
            //     remaining_lines = self.env['stock.move.line'].browse(remaining_line_ids)
            //     remaining_waves = self.env['stock.picking.batch'].create([{
            //         'is_wave': True,
            //         'picking_type_id': picking_type.id,
            //         'description': remaining_line._get_auto_wave_description(nearest_parent_locations[remaining_line]),
            //     } for remaining_line in remaining_lines])
            //     for (line, wave) in zip(remaining_lines, remaining_waves):
            //         line._add_to_wave(wave)
            */
            return default;
        }

        protected async Task<StockMoveLine> CheckLotProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _check_lot_product(self):
            // for line in self:
            //     if line.lot_id and line.product_id != line.lot_id.sudo().product_id:
            //         raise ValidationError(_(
            //             'This lot %(lot_name)s is incompatible with this product %(product_name)s',
            //             lot_name=line.lot_id.name,
            //             product_name=line.product_id.display_name
            //         ))
            */
            return default;
        }

        protected async Task<StockMoveLine> CheckPositiveQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _check_positive_quantity(self):
            // if any(ml.quantity < 0 for ml in self):
            //     raise ValidationError(_('You can not enter negative quantities.'))
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeExpirationDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py) ---
            // def _compute_expiration_date(self):
            // for move_line in self:
            //     if move_line.lot_id.expiration_date:
            //         move_line.expiration_date = move_line.lot_id.expiration_date
            //     elif move_line.picking_type_use_create_lots:
            //         if move_line.product_id.use_expiration_date:
            //             if not move_line.expiration_date:
            //                 from_date = move_line.picking_id.scheduled_date or fields.Datetime.today()
            //                 move_line.expiration_date = from_date + datetime.timedelta(days=move_line.product_id.expiration_time)
            //         else:
            //             move_line.expiration_date = False
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_location_id(self):
            // for line in self:
            //     if not line.location_id:
            //         line.location_id = line.move_id.location_id or line.picking_id.location_id
            //     if not line.location_dest_id:
            //         line.location_dest_id = line.move_id.location_dest_id or line.picking_id.location_dest_id
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeLotsVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_lots_visible(self):
            // for line in self:
            //     picking = line.picking_id
            //     if picking.picking_type_id and line.product_id.tracking != 'none':  # TDE FIXME: not sure correctly migrated
            //         line.lots_visible = picking.picking_type_id.use_existing_lots or picking.picking_type_id.use_create_lots
            //     else:
            //         line.lots_visible = line.product_id.tracking != 'none'
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputePackagingQtysInternalAsync(object aggregated_move_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_packaging_qtys(self, aggregated_move_lines):
            // non_kit_ml = {}
            // kit_aggregated_ml = set()
            // kit_moves = defaultdict(lambda: self.env['stock.move'])
            // kit_qty = {}
            // 
            // for line in aggregated_move_lines.values():
            //     if line['packaging']:
            //         bom_id = line['bom']
            //         if bom_id and bom_id.type == "phantom":
            //             kit_aggregated_ml.add(line['line_key'])
            //             kit_moves[bom_id] |= line['move']
            //         else:
            //             non_kit_ml[line['line_key']] = line
            // 
            // filters = {'incoming_moves': lambda m: True, 'outgoing_moves': lambda m: False}
            // for bom, moves in kit_moves.items():
            //     if moves.picking_id.backorder_ids:
            //         kit_qty_ordered = (moves + moves.picking_id.backorder_ids.move_ids)._compute_kit_quantities(bom.product_id or bom.product_tmpl_id.product_variant_id, 1, bom, filters)
            //         kit_qty_done = moves._compute_kit_quantities(bom.product_id or bom.product_tmpl_id.product_variant_id, 1, bom, filters)
            //     else:
            //         kit_qty_done = moves._compute_kit_quantities(bom.product_id or bom.product_tmpl_id.product_variant_id, 1, bom, filters)
            //         kit_qty_ordered = kit_qty_done
            //     kit_qty[bom.id] = (kit_qty_ordered, kit_qty_done)
            // 
            // for key in kit_aggregated_ml:
            //     line = aggregated_move_lines[key]
            //     bom_id = line['bom']
            //     kit_qty_ordered, kit_qty_done = kit_qty[bom_id.id]
            //     if line['packaging'].product_id == line['product']:
            //         # If packaging has been set directly on the move
            //         line['packaging_qty'] = line['packaging']._compute_qty(line['qty_ordered'], line['product_uom'])
            //         line['packaging_quantity'] = line['packaging']._compute_qty(line['quantity'], line['product_uom'])
            //     else:
            //         # If packaging comes from the kit
            //         line['packaging_qty'] = line['packaging']._compute_qty(kit_qty_ordered, bom_id.product_uom_id)
            //         line['packaging_quantity'] = line['packaging']._compute_qty(kit_qty_done, bom_id.product_uom_id)
            //     aggregated_move_lines[key] = line
            // 
            // non_kit_ml = super()._compute_packaging_qtys(non_kit_ml)
            // for line in non_kit_ml.values():
            //     aggregated_move_lines[line['line_key']] = line
            // 
            // return aggregated_move_lines
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_packaging_qtys(self, aggregated_move_lines):
            // # Needs to be computed after aggregation of line qtys
            // for line in aggregated_move_lines.values():
            //     if line['packaging']:
            //         line['packaging_qty'] = line['packaging']._compute_qty(line['qty_ordered'], line['product_uom'])
            //         line['packaging_quantity'] = line['packaging']._compute_qty(line['quantity'], line['product_uom'])
            // return aggregated_move_lines
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputePickedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_picked(self):
            // for line in self:
            //     if line.move_id.state == 'done':
            //         line.picked = True
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_picking_type_id(self):
            // line_to_remove = self.env['stock.move.line']
            // for line in self:
            //     if not line.production_id:
            //         continue
            //     line.picking_type_id = line.production_id.picking_type_id
            //     line_to_remove |= line
            // return super(StockMoveLine, self - line_to_remove)._compute_picking_type_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_picking_type_id(self):
            // self.picking_type_id = False
            // for line in self:
            //     if line.picking_id:
            //         line.picking_type_id = line.picking_id.picking_type_id
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeProductPackagingQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _compute_product_packaging_qty(self):
            // # we catch kit lines where the packaging is still the one from the final product (it has
            // # not been changed to a packaging of a component)
            // kit_lines = self.filtered(lambda move_line: move_line.move_id.bom_line_id.bom_id.type == 'phantom' and
            // move_line.move_id.product_packaging_id and move_line.product_id != move_line.move_id.product_packaging_id.product_id)
            // for move_line in kit_lines:
            //     move = move_line.move_id
            //     bom_line = move.bom_line_id
            //     kit_bom = bom_line.bom_id
            // 
            //     # Convert the move line quantity to the product's move uom
            //     qty_move_uom = move_line.product_uom_id._compute_quantity(move_line.quantity, move_line.move_id.product_uom)
            //     # Convert the product's move uom to the bom line's uom
            //     qty_bom_uom = move.product_uom._compute_quantity(qty_move_uom, bom_line.product_uom_id)
            //     # calculate the bom's kit qty in kit product uom qty
            //     bom_qty_product_uom = kit_bom.product_uom_id._compute_quantity(kit_bom.product_qty, kit_bom.product_tmpl_id.uom_id)
            //     # calculate the comp/final_prod ratio of the BOM
            //     kit_ratio = bom_line.product_qty / bom_qty_product_uom
            //     # calculate the number of kit on the move line according to the number of comp
            //     kit_qty = qty_bom_uom / kit_ratio
            //     # calculate the quantity needed of packaging
            //     move_line.product_packaging_qty = kit_qty / move_line.move_id.product_packaging_id.qty
            // super(StockMoveLine, self - kit_lines)._compute_product_packaging_qty()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_product_packaging_qty(self):
            // self.product_packaging_qty = 0
            // for line in self:
            //     if not line.move_id.product_packaging_id:
            //         continue
            //     line.product_packaging_qty = line.move_id.product_packaging_id._compute_qty(line.quantity, line.product_uom_id)
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_product_uom_id(self):
            // for line in self:
            //     if not line.product_uom_id or line.product_uom_id.category_id != line.product_id.uom_id.category_id:
            //         if line.move_id.product_uom:
            //             line.product_uom_id = line.move_id.product_uom.id
            //         else:
            //             line.product_uom_id = line.product_id.uom_id.id
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_quantity(self):
            // for record in self:
            //     if not record.quant_id or record.quantity:
            //         continue
            //     product_uom = record.product_id.uom_id
            //     sml_uom = record.product_uom_id
            // 
            //     move_demand = record.move_id.product_uom._compute_quantity(record.move_id.product_uom_qty, sml_uom, rounding_method='HALF-UP')
            //     move_quantity = record.move_id.product_uom._compute_quantity(record.move_id.quantity, sml_uom, rounding_method='HALF-UP')
            //     quant_qty = product_uom._compute_quantity(record.quant_id.available_quantity, sml_uom, rounding_method='HALF-UP')
            // 
            //     if float_compare(move_demand, move_quantity, precision_rounding=sml_uom.rounding) > 0:
            //         record.quantity = max(0, min(quant_qty, move_demand - move_quantity))
            //     else:
            //         record.quantity = max(0, quant_qty)
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeQuantityProductUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_quantity_product_uom(self):
            // for line in self:
            //     line.quantity_product_uom = line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id, rounding_method='HALF-UP')
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeSalePriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: stock_move_line.py) ---
            // def _compute_sale_price(self):
            // kit_lines = self.filtered(lambda move_line: move_line.move_id.bom_line_id.bom_id.type == 'phantom')
            // for move_line in kit_lines:
            //     unit_price = move_line.product_id.list_price
            //     qty = move_line.product_uom_id._compute_quantity(move_line.quantity, move_line.product_id.uom_id)
            //     move_line.sale_price = unit_price * qty
            // super(StockMoveLine, self - kit_lines)._compute_sale_price()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _compute_sale_price(self):
            // # To Override
            // pass
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _compute_sale_price(self):
            // for move_line in self:
            //     sale_line_id = move_line.move_id.sale_line_id
            //     if sale_line_id and sale_line_id.product_id == move_line.product_id:
            //         unit_price = sale_line_id.price_reduce_taxinc
            //         qty = move_line.product_uom_id._compute_quantity(move_line.quantity, sale_line_id.product_uom)
            //     else:
            //         # For kits, use the regular unit price
            //         unit_price = move_line.product_id.list_price
            //         qty = move_line.product_uom_id._compute_quantity(move_line.quantity, move_line.product_id.uom_id)
            //     move_line.sale_price = unit_price * qty
            // super(StockMoveLine, self)._compute_sale_price()
            */
            return default;
        }

        protected async Task<StockMoveLine> CopyQuantInfoInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _copy_quant_info(self, vals):
            // quant = self.env['stock.quant'].browse(vals.get('quant_id', 0))
            // line_data = {
            //     'product_id': quant.product_id.id,
            //     'lot_id': quant.lot_id.id,
            //     'package_id': quant.package_id.id,
            //     'location_id': quant.location_id.id,
            //     'owner_id': quant.owner_id.id,
            // }
            // return line_data
            */
            return default;
        }

        protected async Task<StockMoveLine> CreateAndAssignProductionLotInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _create_and_assign_production_lot(self):
            // """ Creates and assign new production lots for move lines."""
            // lot_vals = []
            // # It is possible to have multiple time the same lot to create & assign,
            // # so we handle the case with 2 dictionaries.
            // key_to_index = {}  # key to index of the lot
            // key_to_mls = defaultdict(lambda: self.env['stock.move.line'])  # key to all mls
            // for ml in self:
            //     key = (ml.product_id.id, ml.lot_name)
            //     key_to_mls[key] |= ml
            //     if ml.tracking != 'lot' or key not in key_to_index:
            //         key_to_index[key] = len(lot_vals)
            //         lot_vals.append(ml._prepare_new_lot_vals())
            // 
            // lots = self.env['stock.lot'].create(lot_vals)
            // for key, mls in key_to_mls.items():
            //     lot = lots[key_to_index[key]].with_prefetch(lots._ids)   # With prefetch to reconstruct the ones broke by accessing by index
            //     mls.with_prefetch(self._prefetch_ids).write({'lot_id': lot.id})
            */
            return default;
        }

        public override async Task<StockMoveLine> CreateAsync(StockMoveLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def create(self, values):
            // res = super(StockMoveLine, self).create(values)
            // for line in res:
            //     # If the line is added in a done production, we need to map it
            //     # manually to the produced move lines in order to see them in the
            //     # traceability report
            //     if line.move_id.raw_material_production_id and line.state == 'done':
            //         mo = line.move_id.raw_material_production_id
            //         finished_lots = mo.lot_producing_id
            //         finished_lots |= mo.move_finished_ids.filtered(lambda m: m.product_id != mo.product_id).move_line_ids.lot_id
            //         if finished_lots:
            //             produced_move_lines = mo.move_finished_ids.move_line_ids.filtered(lambda sml: sml.lot_id in finished_lots)
            //             line.produce_line_ids = [(6, 0, produced_move_lines.ids)]
            //         else:
            //             produced_move_lines = mo.move_finished_ids.move_line_ids
            //             line.produce_line_ids = [(6, 0, produced_move_lines.ids)]
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('move_id'):
            //         vals['company_id'] = self.env['stock.move'].browse(vals['move_id']).company_id.id
            //     elif vals.get('picking_id'):
            //         vals['company_id'] = self.env['stock.picking'].browse(vals['picking_id']).company_id.id
            //     if vals.get('move_id') and 'picked' not in vals:
            //         vals['picked'] = self.env['stock.move'].browse(vals['move_id']).picked
            //     if vals.get('quant_id'):
            //         vals.update(self._copy_quant_info(vals))
            // 
            // mls = super().create(vals_list)
            // 
            // created_moves = set()
            // def create_move(move_line):
            //     new_move = self.env['stock.move'].create(move_line._prepare_stock_move_vals())
            //     move_line.move_id = new_move.id
            //     created_moves.add(new_move.id)
            // 
            // # If the move line is directly create on the picking view.
            // # If this picking is already done we should generate an
            // # associated done move.
            // for move_line in mls:
            //     if move_line.move_id or not move_line.picking_id:
            //         continue
            //     if move_line.picking_id.state != 'done':
            //         moves = move_line._get_linkable_moves()
            //         if moves:
            //             vals = {
            //                 'move_id': moves[0].id,
            //                 'picking_id': moves[0].picking_id.id,
            //             }
            //             if moves[0].picked:
            //                 vals['picked'] = True
            //             move_line.write(vals)
            //         else:
            //             create_move(move_line)
            //     else:
            //         create_move(move_line)
            // 
            // move_to_recompute_state = set()
            // for move_line in mls:
            //     if move_line.state == 'done':
            //         continue
            //     location = move_line.location_id
            //     product = move_line.product_id
            //     move = move_line.move_id
            //     if move:
            //         reservation = not move._should_bypass_reservation()
            //     else:
            //         reservation = product.is_storable and not location.should_bypass_reservation()
            //     if move_line.quantity_product_uom and reservation:
            //         self.env.context.get('reserved_quant', self.env['stock.quant'])._update_reserved_quantity(
            //             product, location, move_line.quantity_product_uom, lot_id=move_line.lot_id, package_id=move_line.package_id, owner_id=move_line.owner_id)
            // 
            //         if move:
            //             move_to_recompute_state.add(move.id)
            // self.env['stock.move'].browse(move_to_recompute_state)._recompute_state()
            // self.env['stock.move'].browse(created_moves)._post_process_created_moves()
            // 
            // for ml, vals in zip(mls, vals_list):
            //     if ml.state == 'done':
            //         if ml.product_id.is_storable:
            //             Quant = self.env['stock.quant']
            //             quantity = ml.product_uom_id._compute_quantity(ml.quantity, ml.move_id.product_id.uom_id, rounding_method='HALF-UP')
            //             in_date = None
            //             available_qty, in_date = Quant._update_available_quantity(ml.product_id, ml.location_id, -quantity, lot_id=ml.lot_id, package_id=ml.package_id, owner_id=ml.owner_id)
            //             if available_qty < 0 and ml.lot_id:
            //                 # see if we can compensate the negative quants with some untracked quants
            //                 untracked_qty = Quant._get_available_quantity(ml.product_id, ml.location_id, lot_id=False, package_id=ml.package_id, owner_id=ml.owner_id, strict=True)
            //                 if untracked_qty:
            //                     taken_from_untracked_qty = min(untracked_qty, abs(quantity))
            //                     Quant._update_available_quantity(ml.product_id, ml.location_id, -taken_from_untracked_qty, lot_id=False, package_id=ml.package_id, owner_id=ml.owner_id)
            //                     Quant._update_available_quantity(ml.product_id, ml.location_id, taken_from_untracked_qty, lot_id=ml.lot_id, package_id=ml.package_id, owner_id=ml.owner_id)
            //             Quant._update_available_quantity(ml.product_id, ml.location_dest_id, quantity, lot_id=ml.lot_id, package_id=ml.result_package_id, owner_id=ml.owner_id, in_date=in_date)
            //         next_moves = ml.move_id.move_dest_ids.filtered(lambda move: move.state not in ('done', 'cancel'))
            //         next_moves._do_unreserve()
            //         next_moves._action_assign()
            // move_done = mls.filtered(lambda m: m.state == "done").move_id
            // if move_done:
            //     move_done._check_quantity()
            // return mls
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def create(self, vals_list):
            // analytic_move_to_recompute = set()
            // move_lines = super(StockMoveLine, self).create(vals_list)
            // for move_line in move_lines:
            //     move = move_line.move_id
            //     analytic_move_to_recompute.add(move.id)
            //     move_line._update_svl_quantity(move_line.quantity)
            // if analytic_move_to_recompute:
            //     self.env['stock.move'].browse(
            //         analytic_move_to_recompute)._account_analytic_entry_move()
            // return move_lines
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<StockMoveLine> CreateCorrectionSvlInternalAsync(object move, object diff)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def _create_correction_svl(self, move, diff):
            // lot = self.lot_id if self.product_id.lot_valuated else self.env['stock.lot']
            // qty = (lot, abs(diff))
            // stock_valuation_layers = self.env['stock.valuation.layer']
            // if (move._is_in() and diff > 0) or (move._is_out() and diff < 0):
            //     move.product_price_update_before_done(forced_qty=(lot, diff))
            //     stock_valuation_layers |= move._create_in_svl(forced_quantity=qty)
            //     if move.product_id.cost_method in ('average', 'fifo'):
            //         move.product_id._run_fifo_vacuum(move.company_id)
            // elif (move._is_in() and diff < 0) or (move._is_out() and diff > 0):
            //     stock_valuation_layers |= move._create_out_svl(forced_quantity=qty)
            //     if move.product_id.lot_valuated:
            //         move._product_price_update_after_done()
            // elif (move._is_dropshipped() and diff > 0) or (move._is_dropshipped_returned() and diff < 0):
            //     stock_valuation_layers |= move._create_dropshipped_svl(forced_quantity=qty)
            // elif (move._is_dropshipped() and diff < 0) or (move._is_dropshipped_returned() and diff > 0):
            //     stock_valuation_layers |= move._create_dropshipped_returned_svl(forced_quantity=qty)
            // 
            // stock_valuation_layers._validate_accounting_entries()
            */
            return default;
        }

        protected async Task<StockMoveLine> FreeReservationInternalAsync(Guid product_id, Guid location_id, object quantity, Guid lot_id, Guid package_id, Guid owner_id, object ml_ids_to_ignore)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _free_reservation(self, product_id, location_id, quantity, lot_id=None, package_id=None, owner_id=None, ml_ids_to_ignore=None):
            // """ When editing a done move line or validating one with some forced quantities, it is
            // possible to impact quants that were not reserved. It is therefore necessary to edit or
            // unlink the move lines that reserved a quantity now unavailable.
            // 
            // :param ml_ids_to_ignore: OrderedSet of `stock.move.line` ids that should NOT be unreserved
            // """
            // self.ensure_one()
            // if ml_ids_to_ignore is None:
            //     ml_ids_to_ignore = OrderedSet()
            // ml_ids_to_ignore |= self.ids
            // 
            // if self.move_id._should_bypass_reservation(location_id):
            //     return
            // 
            // # We now have to find the move lines that reserved our now unavailable quantity. We
            // # take care to exclude ourselves and the move lines were work had already been done.
            // outdated_move_lines_domain = [
            //     ('state', 'not in', ['done', 'cancel']),
            //     ('product_id', '=', product_id.id),
            //     ('lot_id', '=', lot_id.id if lot_id else False),
            //     ('location_id', '=', location_id.id),
            //     ('owner_id', '=', owner_id.id if owner_id else False),
            //     ('package_id', '=', package_id.id if package_id else False),
            //     ('quantity_product_uom', '>', 0.0),
            //     ('picked', '=', False),
            //     ('id', 'not in', tuple(ml_ids_to_ignore)),
            // ]
            // 
            // # We take the current picking first, then the pickings with the latest scheduled date
            // def current_picking_first(cand):
            //     return (
            //         cand.picking_id != self.move_id.picking_id,
            //         -(cand.picking_id.scheduled_date or cand.move_id.date).timestamp()
            //         if cand.picking_id or cand.move_id else 0,
            //         -cand.id)
            // 
            // outdated_candidates = self.env['stock.move.line'].search(outdated_move_lines_domain).sorted(current_picking_first)
            // 
            // # As the move's state is not computed over the move lines, we'll have to manually
            // # recompute the moves which we adapted their lines.
            // move_to_reassign = self.env['stock.move']
            // to_unlink_candidate_ids = set()
            // 
            // rounding = self.product_uom_id.rounding
            // for candidate in outdated_candidates:
            //     move_to_reassign |= candidate.move_id
            //     if float_compare(candidate.quantity_product_uom, quantity, precision_rounding=rounding) <= 0:
            //         quantity -= candidate.quantity_product_uom
            //         to_unlink_candidate_ids.add(candidate.id)
            //         if float_is_zero(quantity, precision_rounding=rounding):
            //             break
            //     else:
            //         candidate.quantity -= candidate.product_id.uom_id._compute_quantity(quantity, candidate.product_uom_id, rounding_method='HALF-UP')
            //         break
            // 
            // move_line_to_unlink = self.env['stock.move.line'].browse(to_unlink_candidate_ids)
            // for m in (move_line_to_unlink.move_id | move_to_reassign):
            //     m.write({
            //         'procure_method': 'make_to_stock',
            //         'move_orig_ids': [Command.clear()]
            //     })
            // move_line_to_unlink.unlink()
            // move_to_reassign._action_assign()
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAggregatedProductQuantitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_aggregated_product_quantities(self, **kwargs):
            // """Returns dictionary of products and corresponding values of interest grouped by optional kit_name
            // 
            // Removes descriptions where description == kit_name. kit_name is expected to be passed as a
            // kwargs value because this is not directly stored in move_line_ids. Unfortunately because we
            // are working with aggregated data, we have to loop through the aggregation to do this removal.
            // 
            // arguments: kit_name (optional): string value of a kit name passed as a kwarg
            // returns: dictionary {same_key_as_super: {same_values_as_super, ...}
            // """
            // aggregated_move_lines = super()._get_aggregated_product_quantities(**kwargs)
            // kit_name = kwargs.get('kit_name')
            // 
            // to_be_removed = []
            // for aggregated_move_line in aggregated_move_lines:
            //     bom = aggregated_move_lines[aggregated_move_line]['bom']
            //     is_phantom = bom.type == 'phantom' if bom else False
            //     if kit_name:
            //         product = bom.product_id or bom.product_tmpl_id if bom else False
            //         display_name = product.display_name if product else False
            //         description = aggregated_move_lines[aggregated_move_line]['description']
            //         if not is_phantom or display_name != kit_name:
            //             to_be_removed.append(aggregated_move_line)
            //         elif description == kit_name:
            //             aggregated_move_lines[aggregated_move_line]['description'] = ""
            //     elif not kwargs and is_phantom:
            //         to_be_removed.append(aggregated_move_line)
            // 
            // for move_line in to_be_removed:
            //     del aggregated_move_lines[move_line]
            // 
            // return aggregated_move_lines
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_aggregated_product_quantities(self, **kwargs):
            // """ Returns a dictionary of products (key = id+name+description+uom+packaging) and corresponding values of interest.
            // 
            // Allows aggregation of data across separate move lines for the same product. This is expected to be useful
            // in things such as delivery reports. Dict key is made as a combination of values we expect to want to group
            // the products by (i.e. so data is not lost). This function purposely ignores lots/SNs because these are
            // expected to already be properly grouped by line.
            // 
            // returns: dictionary {product_id+name+description+uom+packaging: {product, name, description, quantity, product_uom, packaging}, ...}
            // """
            // aggregated_move_lines = {}
            // 
            // # Loops to get backorders, backorders' backorders, and so and so...
            // backorders = self.env['stock.picking']
            // pickings = self.picking_id
            // while pickings.backorder_ids:
            //     backorders |= pickings.backorder_ids
            //     pickings = pickings.backorder_ids
            // 
            // for move_line in self:
            //     if kwargs.get('except_package') and move_line.result_package_id:
            //         continue
            //     aggregated_properties = self._get_aggregated_properties(move_line=move_line)
            //     line_key, uom = aggregated_properties['line_key'], aggregated_properties['product_uom']
            //     quantity = move_line.product_uom_id._compute_quantity(move_line.quantity, uom)
            //     if line_key not in aggregated_move_lines:
            //         qty_ordered = None
            //         if backorders and not kwargs.get('strict'):
            //             qty_ordered = move_line.move_id.product_uom_qty
            //             # Filters on the aggregation key (product, description and uom) to add the
            //             # quantities delayed to backorders to retrieve the original ordered qty.
            //             following_move_lines = backorders.move_line_ids.filtered(
            //                 lambda ml: self._get_aggregated_properties(move=ml.move_id)['line_key'] == line_key
            //             )
            //             qty_ordered += sum(following_move_lines.move_id.mapped('product_uom_qty'))
            //             # Remove the done quantities of the other move lines of the stock move
            //             previous_move_lines = move_line.move_id.move_line_ids.filtered(
            //                 lambda ml: self._get_aggregated_properties(move=ml.move_id)['line_key'] == line_key and ml.id != move_line.id
            //             )
            //             qty_ordered -= sum([m.product_uom_id._compute_quantity(m.quantity, uom) for m in previous_move_lines])
            //         aggregated_move_lines[line_key] = {
            //             **aggregated_properties,
            //             'quantity': quantity,
            //             'qty_ordered': qty_ordered or quantity,
            //             'product': move_line.product_id,
            //         }
            //     else:
            //         aggregated_move_lines[line_key]['qty_ordered'] += quantity
            //         aggregated_move_lines[line_key]['quantity'] += quantity
            // 
            // # Does the same for empty move line to retrieve the ordered qty. for partially done moves
            // # (as they are splitted when the transfer is done and empty moves don't have move lines).
            // if kwargs.get('strict'):
            //     return self._compute_packaging_qtys(aggregated_move_lines)
            // pickings = (self.picking_id | backorders)
            // for empty_move in pickings.move_ids:
            //     to_bypass = False
            //     if not (empty_move.product_uom_qty and float_is_zero(empty_move.quantity, precision_rounding=empty_move.product_uom.rounding)):
            //         continue
            //     if empty_move.state != "cancel":
            //         if empty_move.state != "confirmed" or empty_move.move_line_ids:
            //             continue
            //         else:
            //             to_bypass = True
            //     aggregated_properties = self._get_aggregated_properties(move=empty_move)
            //     line_key = aggregated_properties['line_key']
            // 
            //     if line_key not in aggregated_move_lines and not to_bypass:
            //         qty_ordered = empty_move.product_uom_qty
            //         aggregated_move_lines[line_key] = {
            //             **aggregated_properties,
            //             'quantity': False,
            //             'qty_ordered': qty_ordered,
            //             'product': empty_move.product_id,
            //         }
            //     elif line_key in aggregated_move_lines:
            //         aggregated_move_lines[line_key]['qty_ordered'] += empty_move.product_uom_qty
            // 
            // return self._compute_packaging_qtys(aggregated_move_lines)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py) ---
            // def _get_aggregated_product_quantities(self, **kwargs):
            // """Returns dictionary of products and corresponding values of interest + hs_code
            // 
            // Unfortunately because we are working with aggregated data, we have to loop through the
            // aggregation to add more values to each datum. This extension adds on the hs_code value.
            // 
            // returns: dictionary {same_key_as_super: {same_values_as_super, hs_code}, ...}
            // """
            // aggregated_move_lines = super()._get_aggregated_product_quantities(**kwargs)
            // for aggregated_move_line in aggregated_move_lines:
            //     hs_code = aggregated_move_lines[aggregated_move_line]['product'].product_tmpl_id.hs_code
            //     aggregated_move_lines[aggregated_move_line]['hs_code'] = hs_code
            // return aggregated_move_lines
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAggregatedPropertiesInternalAsync(object move_line, object move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_aggregated_properties(self, move_line=False, move=False):
            // aggregated_properties = super()._get_aggregated_properties(move_line, move)
            // bom = aggregated_properties['move'].bom_line_id.bom_id
            // aggregated_properties['bom'] = bom or False
            // aggregated_properties['line_key'] += f'_{bom.id if bom else ""}'
            // return aggregated_properties
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_aggregated_properties(self, move_line=False, move=False):
            // move = move or move_line.move_id
            // uom = move.product_uom or move_line.product_uom_id
            // name = move.product_id.display_name
            // description = move.description_picking or ""
            // product = move.product_id
            // if description.startswith(name):
            //     description = description.removeprefix(name).strip()
            // elif description.startswith(product.name):
            //     description = description.removeprefix(product.name).strip()
            // line_key = f'{product.id}_{product.display_name}_{description or ""}_{uom.id}_{move.product_packaging_id or ""}'
            // return {
            //     'line_key': line_key,
            //     'name': name,
            //     'description': description,
            //     'product_uom': uom,
            //     'move': move,
            //     'packaging': move.product_packaging_id,
            // }
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAutoWaveDescriptionInternalAsync(object nearest_parent_location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _get_auto_wave_description(self, nearest_parent_location=False):
            // self.ensure_one()
            // description = self.picking_id._get_auto_batch_description()
            // description_items = []
            // if description:
            //     description_items.append(description)
            // 
            // if self.picking_type_id.wave_group_by_product:
            //     description_items.append(self.product_id.display_name)
            // if self.picking_type_id.wave_group_by_category:
            //     description_items.append(self.product_id.categ_id.complete_name)
            // if self.picking_type_id.wave_group_by_location:
            //     description_items.append(nearest_parent_location.complete_name)
            // 
            // description = ', '.join(description_items)
            // return description
            */
            return default;
        }

        protected async Task<StockMoveLine> GetDefaultDestLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_default_dest_location(self):
            // if not self.env.user.has_group('stock.group_stock_multi_locations'):
            //     return self.location_dest_id[:1]
            // if self.env.context.get('default_location_dest_id'):
            //     return self.env['stock.location'].browse([self.env.context.get('default_location_dest_id')])
            // return (self.move_id.location_dest_id or self.picking_id.location_dest_id or self.location_dest_id)[:1]
            */
            return default;
        }

        protected async Task<StockMoveLine> GetLinkableMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_linkable_moves(self):
            // """ Don't linke move lines with kit products to moves with dissimilar locations so that
            // post `action_explode()` move lines will have accurate location data.
            // """
            // self.ensure_one()
            // if self.product_id and self.product_id.is_kits:
            //     moves = self.picking_id.move_ids.filtered(lambda move:
            //         move.product_id == self.product_id and
            //         move.location_id == self.location_id and
            //         move.location_dest_id == self.location_dest_id
            //     )
            //     return sorted(moves, key=lambda m: m.quantity < m.product_qty, reverse=True)
            // else:
            //     return super()._get_linkable_moves()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_linkable_moves(self):
            // self.ensure_one()
            // moves = self.picking_id.move_ids.filtered(lambda x: x.product_id == self.product_id)
            // return sorted(moves, key=lambda m: m.quantity < m.product_qty, reverse=True)
            */
            return default;
        }

        public async Task<StockMoveLine> GetMoveLineQuantMatchAsync(Guid id, Guid move_id, List<Guid> dirty_move_line_ids, List<Guid> dirty_quant_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def get_move_line_quant_match(self, move_id, dirty_move_line_ids, dirty_quant_ids):
            // # Since the quant_id field is neither stored nor computed, this method is used to compute the match if it exists
            // move = self.env['stock.move'].browse(move_id)
            // deleted_move_lines = move.move_line_ids - self
            // dirty_move_lines = self.env['stock.move.line'].browse(dirty_move_line_ids)
            // quants_data = []
            // move_lines_data = []
            // domain = [("id", "in", dirty_quant_ids)]
            // for move_line in dirty_move_lines | deleted_move_lines:
            //     move_line_domain = [
            //         ("product_id", "=", move_line.product_id.id),
            //         ("lot_id", "=", move_line.lot_id.id),
            //         ("location_id", "=", move_line.location_id.id),
            //         ("package_id", "=", move_line.package_id.id),
            //         ("owner_id", "=", move_line.owner_id.id),
            //     ]
            //     domain = expression.OR([domain, move_line_domain])
            // if domain:
            //     quants = self.env['stock.quant'].search(domain)
            //     for quant in quants:
            //         dirty_lines = dirty_move_lines.filtered(lambda ml: ml.product_id == quant.product_id
            //             and ml.lot_id == quant.lot_id
            //             and ml.location_id == quant.location_id
            //             and ml.package_id == quant.package_id
            //             and ml.owner_id == quant.owner_id
            //         )
            //         deleted_lines = deleted_move_lines.filtered(lambda ml: ml.product_id == quant.product_id
            //             and ml.lot_id == quant.lot_id
            //             and ml.location_id == quant.location_id
            //             and ml.package_id == quant.package_id
            //             and ml.owner_id == quant.owner_id
            //         )
            //         quants_data.append((quant.id, {"available_quantity": quant.available_quantity + sum(ml.quantity_product_uom for ml in deleted_lines), "move_line_ids": dirty_lines.ids}))
            //         move_lines_data += [(ml.id, {"quantity": ml.quantity, "quant_id": quant.id}) for ml in dirty_lines]
            // return [quants_data, move_lines_data]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMoveLine> GetPutawayAdditionalQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_putaway_additional_qty(self):
            // addtional_qty = {}
            // for ml in self._origin:
            //     qty = ml.product_uom_id._compute_quantity(ml.quantity, ml.product_id.uom_id)
            //     addtional_qty[ml.location_dest_id.id] = addtional_qty.get(ml.location_dest_id.id, 0) - qty
            // return addtional_qty
            */
            return default;
        }

        protected async Task<StockMoveLine> GetRevertInventoryMoveValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_revert_inventory_move_values(self):
            // self.ensure_one()
            // return {
            //     'name':_('%s [reverted]', self.reference),
            //     'product_id': self.product_id.id,
            //     'product_uom': self.product_uom_id.id,
            //     'product_uom_qty': self.quantity,
            //     'company_id': self.company_id.id or self.env.company.id,
            //     'state': 'confirmed',
            //     'location_id': self.location_dest_id.id,
            //     'location_dest_id': self.location_id.id,
            //     'is_inventory': True,
            //     'picked': True,
            //     'move_line_ids': [(0, 0, {
            //         'product_id': self.product_id.id,
            //         'product_uom_id': self.product_uom_id.id,
            //         'quantity': self.quantity,
            //         'location_id': self.location_dest_id.id,
            //         'location_dest_id': self.location_id.id,
            //         'company_id': self.company_id.id or self.env.company.id,
            //         'lot_id': self.lot_id.id,
            //         'package_id': self.package_id.id,
            //         'result_package_id': self.package_id.id,
            //         'owner_id': self.owner_id.id,
            //     })]
            // }
            */
            return default;
        }

        protected async Task<StockMoveLine> GetSimilarMoveLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _get_similar_move_lines(self):
            // lines = super(StockMoveLine, self)._get_similar_move_lines()
            // if self.move_id.production_id:
            //     finished_moves = self.move_id.production_id.move_finished_ids
            //     finished_move_lines = finished_moves.mapped('move_line_ids')
            //     lines |= finished_move_lines.filtered(lambda ml: ml.product_id == self.product_id and (ml.lot_id or ml.lot_name))
            // if self.move_id.raw_material_production_id:
            //     raw_moves = self.move_id.raw_material_production_id.move_raw_ids
            //     raw_moves_lines = raw_moves.mapped('move_line_ids')
            //     lines |= raw_moves_lines.filtered(lambda ml: ml.product_id == self.product_id and (ml.lot_id or ml.lot_name))
            // return lines
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _get_similar_move_lines(self):
            // self.ensure_one()
            // lines = self.env['stock.move.line']
            // picking_id = self.move_id.picking_id if self.move_id else self.picking_id
            // if picking_id:
            //     lines |= picking_id.move_line_ids.filtered(lambda ml: ml.product_id == self.product_id and (ml.lot_id or ml.lot_name))
            // return lines
            */
            return default;
        }

        public async Task<StockMoveLine> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def init(self):
            // if not tools.index_exists(self._cr, 'stock_move_line_free_reservation_index'):
            //     self._cr.execute("""
            //         CREATE INDEX stock_move_line_free_reservation_index
            //         ON
            //             stock_move_line (id, company_id, product_id, lot_id, location_id, owner_id, package_id)
            //         WHERE
            //             (state IS NULL OR state NOT IN ('cancel', 'done')) AND quantity_product_uom > 0 AND not picked""")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMoveLine> IsAutoWaveableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def _is_auto_waveable(self):
            // self.ensure_one()
            // if not self.picking_id \
            //    or (self.picking_id.state != 'assigned' or float_is_zero(self.quantity, precision_rounding=self.product_uom_id.rounding)) and not self.env.context.get('skip_auto_waveable')  \
            //    or self.batch_id.is_wave \
            //    or not self.picking_type_id._is_auto_wave_grouped() \
            //    or (self.picking_type_id.wave_group_by_category and self.product_id.categ_id not in self.picking_type_id.wave_category_ids):  # noqa: SIM103
            //     return False
            // return True
            */
            return default;
        }

        protected async Task<StockMoveLine> LogMessageInternalAsync(object record, object move, object template, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _log_message(self, record, move, template, vals):
            // data = vals.copy()
            // if 'lot_id' in vals and vals['lot_id'] != move.lot_id.id:
            //     data['lot_name'] = self.env['stock.lot'].browse(vals.get('lot_id')).name
            // if 'location_id' in vals:
            //     data['location_name'] = self.env['stock.location'].browse(vals.get('location_id')).name
            // if 'location_dest_id' in vals:
            //     data['location_dest_name'] = self.env['stock.location'].browse(vals.get('location_dest_id')).name
            // if 'package_id' in vals and vals['package_id'] != move.package_id.id:
            //     data['package_name'] = self.env['stock.quant.package'].browse(vals.get('package_id')).name
            // if 'package_result_id' in vals and vals['package_result_id'] != move.package_result_id.id:
            //     data['result_package_name'] = self.env['stock.quant.package'].browse(vals.get('result_package_id')).name
            // if 'owner_id' in vals and vals['owner_id'] != move.owner_id.id:
            //     data['owner_name'] = self.env['res.partner'].browse(vals.get('owner_id')).name
            // record.message_post_with_source(
            //     template,
            //     render_values={'move': move, 'vals': dict(vals, **data)},
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py) ---
            // def _onchange_product_id(self):
            // res = super()._onchange_product_id()
            // if self.picking_type_use_create_lots:
            //     if self.product_id.use_expiration_date:
            //         from_date = self.picking_id.scheduled_date or fields.Datetime.today()
            //         self.expiration_date = from_date + datetime.timedelta(days=self.product_id.expiration_time)
            //     else:
            //         self.expiration_date = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _onchange_product_id(self):
            // if self.product_id:
            //     if self.picking_id:
            //         product = self.product_id.with_context(lang=self.picking_id.partner_id.lang or self.env.user.lang)
            //         self.description_picking = product._get_description(self.picking_id.picking_type_id)
            //     self.lots_visible = self.product_id.tracking != 'none'
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangePutawayLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _onchange_putaway_location(self):
            // default_dest_location = self._get_default_dest_location()
            // if not self.id and self.env.user.has_group('stock.group_stock_multi_locations') and self.product_id and self.quantity_product_uom \
            //         and self.location_dest_id == default_dest_location:
            //     quantity = self.quantity_product_uom
            //     self.location_dest_id = default_dest_location.with_context(exclude_sml_ids=self.ids)._get_putaway_strategy(
            //         self.product_id, quantity=quantity, package=self.result_package_id,
            //         packaging=self.move_id.product_packaging_id)
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _onchange_quantity(self):
            // """ When the user is encoding a move line for a tracked product, we apply some logic to
            // help him. This onchange will warn him if he set `quantity` to a non-supported value.
            // """
            // res = {}
            // if self.quantity and self.product_id.tracking == 'serial':
            //     if float_compare(self.quantity_product_uom, 1.0, precision_rounding=self.product_id.uom_id.rounding) != 0 and not float_is_zero(self.quantity_product_uom, precision_rounding=self.product_id.uom_id.rounding):
            //         raise UserError(_('You can only process 1.0 %s of products with unique serial number.', self.product_id.uom_id.name))
            // return res
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeSerialNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py) ---
            // def _onchange_serial_number(self):
            // current_location_id = self.location_id
            // res = super()._onchange_serial_number()
            // if res and not self.lot_name and current_location_id.is_subcontracting_location:
            //     # we want to avoid auto-updating source location in this case + change the warning message
            //     self.location_id = current_location_id
            //     res['warning']['message'] = res['warning']['message'].split("\n\n", 1)[0] + "\n\n" + \
            //         _("Make sure you validate or adapt the related resupply picking to your subcontractor in order to avoid inconsistencies in your stock.")
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _onchange_serial_number(self):
            // """ When the user is encoding a move line for a tracked product, we apply some logic to
            // help him. This includes:
            //     - automatically switch `quantity` to 1.0
            //     - warn if he has already encoded `lot_name` in another move line
            //     - warn (and update if appropriate) if the SN is in a different source location than selected
            // """
            // res = {}
            // if self.product_id.tracking == 'serial':
            //     if not self.quantity:
            //         self.quantity = 1
            // 
            //     message = None
            //     if self.lot_name or self.lot_id:
            //         move_lines_to_check = self._get_similar_move_lines() - self
            //         if self.lot_name:
            //             counter = Counter([line.lot_name for line in move_lines_to_check])
            //             if counter.get(self.lot_name) and counter[self.lot_name] > 1:
            //                 message = _('You cannot use the same serial number twice. Please correct the serial numbers encoded.')
            //             elif not self.lot_id:
            //                 lots = self.env['stock.lot'].search([('product_id', '=', self.product_id.id),
            //                                                      ('name', '=', self.lot_name),
            //                                                      '|', ('company_id', '=', False), ('company_id', '=', self.company_id.id)])
            //                 quants = lots.quant_ids.filtered(lambda q: q.quantity != 0 and q.location_id.usage in ['customer', 'internal', 'transit'])
            //                 if quants:
            //                     message = _(
            //                         'Serial number (%(serial_number)s) already exists in location(s): %(location_list)s. Please correct the serial number encoded.',
            //                         serial_number=self.lot_name,
            //                         location_list=format_list(self.env, quants.location_id.mapped('display_name'))
            //                     )
            //         elif self.lot_id:
            //             counter = Counter([line.lot_id.id for line in move_lines_to_check])
            //             if counter.get(self.lot_id.id) and counter[self.lot_id.id] > 1:
            //                 message = _('You cannot use the same serial number twice. Please correct the serial numbers encoded.')
            //             else:
            //                 # check if in correct source location
            //                 message, recommended_location = self.env['stock.quant'].sudo()._check_serial_number(
            //                     self.product_id, self.lot_id, self.company_id, self.location_id, self.picking_id.location_id)
            //                 if recommended_location:
            //                     self.location_id = recommended_location
            //     if message:
            //         res['warning'] = {'title': _('Warning'), 'message': message}
            // return res
            */
            return default;
        }

        public async Task<StockMoveLine> OpenAddToWaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py) ---
            // def action_open_add_to_wave(self):
            // # This action can be called from the move line list view or from the 'Add to wave' wizard
            // if 'active_wave_id' in self.env.context:
            //     wave = self.env['stock.picking.batch'].browse(self.env.context.get('active_wave_id'))
            //     return self._add_to_wave(wave)
            // view = self.env.ref('stock_picking_batch.stock_add_to_wave_form')
            // return {
            //     'name': _('Add to Wave'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'stock.add.to.wave',
            //     'views': [(view.id, 'form')],
            //     'view_id': view.id,
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMoveLine> OpenReferenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def action_open_reference(self):
            // self.ensure_one()
            // if self.move_id:
            //     action = self.move_id.action_open_reference()
            //     if action['res_model'] != 'stock.move':
            //         return action
            // return {
            //     'res_model': self._name,
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, "form"]],
            //     'res_id': self.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMoveLine> PrepareNewLotValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py) ---
            // def _prepare_new_lot_vals(self):
            // vals = super()._prepare_new_lot_vals()
            // if self.expiration_date:
            //     vals['expiration_date'] = self.expiration_date
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _prepare_new_lot_vals(self):
            // self.ensure_one()
            // vals =  {
            //     'name': self.lot_name,
            //     'product_id': self.product_id.id,
            // }
            // if self.product_id.company_id and self.company_id in (self.product_id.company_id.all_child_ids | self.product_id.company_id):
            //     vals['company_id'] = self.company_id.id
            // return vals
            */
            return default;
        }

        protected async Task<StockMoveLine> PrepareStockMoveValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _prepare_stock_move_vals(self):
            // move_vals = super()._prepare_stock_move_vals()
            // if self.env['product.product'].browse(move_vals['product_id']).is_kits:
            //     move_vals['location_id'] = self.location_id.id
            //     move_vals['location_dest_id'] = self.location_dest_id.id
            // return move_vals
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _prepare_stock_move_vals(self):
            // self.ensure_one()
            // return {
            //     'name': _('New Move: %(product)s', product=self.product_id.display_name),
            //     'product_id': self.product_id.id,
            //     'product_uom_qty': 0 if self.picking_id and self.picking_id.state != 'done' else self.quantity,
            //     'product_uom': self.product_uom_id.id,
            //     'description_picking': self.description_picking or self.product_id.with_context(lang=self.env.context.get('lang'))._get_description(self.picking_type_id),
            //     'location_id': self.picking_id.location_id.id,
            //     'location_dest_id': self.picking_id.location_dest_id.id,
            //     'picked': self.picked,
            //     'picking_id': self.picking_id.id,
            //     'state': self.picking_id.state,
            //     'picking_type_id': self.picking_id.picking_type_id.id,
            //     'restrict_partner_id': self.picking_id.owner_id.id,
            //     'company_id': self.picking_id.company_id.id,
            //     'partner_id': self.picking_id.partner_id.id,
            //     'package_level_id': self.package_level_id.id,
            // }
            */
            return default;
        }

        public async Task<StockMoveLine> PutInPackAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def action_put_in_pack(self):
            // if len(self.picking_id) > 1:
            //     raise UserError(_("You cannot directly pack quantities from different transfers into the same package through this view. Try adding them to a batch picking and pack it there."))
            // return self.picking_id.action_put_in_pack(move_lines_to_pack=self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockMoveLine> RevertInventoryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def action_revert_inventory(self):
            // move_vals = []
            // # remove inventory mode
            // self = self.with_context(inventory_mode=False)
            // processed_move_line = self.env['stock.move.line']
            // for move_line in self:
            //     if move_line.is_inventory and not float_is_zero(move_line.quantity, precision_rounding=move_line.product_uom_id.rounding):
            //         processed_move_line += move_line
            //         move_vals.append(move_line._get_revert_inventory_move_values())
            // if not processed_move_line:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'message': _("There are no inventory adjustments to revert."),
            //         }
            //     }
            // moves = self.env['stock.move'].create(move_vals)
            // moves._action_done()
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _("The inventory adjustments have been reverted."),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockMoveLine> SearchPickingTypeIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def _search_picking_type_id(self, operator, value):
            // res = super()._search_picking_type_id(operator=operator, value=value)
            // if operator in ['not in', '!=', 'not ilike']:
            //     if value is False:
            //         return expression.OR([[('production_id.picking_type_id', operator, value)], res])
            //     else:
            //         return expression.AND([[('production_id.picking_type_id', operator, value)], res])
            // else:
            //     if value is False:
            //         return expression.AND([[('production_id.picking_type_id', operator, value)], res])
            //     else:
            //         return expression.OR([[('production_id.picking_type_id', operator, value)], res])
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _search_picking_type_id(self, operator, value):
            // return [('picking_id.picking_type_id', operator, value)]
            */
            return default;
        }

        protected async Task<StockMoveLine> ShouldExcludeForValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def _should_exclude_for_valuation(self):
            // """
            // Determines if this move line should be excluded from valuation based on its ownership.
            // :return: True if the move line's owner is different from the company's partner (indicating
            //         it should be excluded from valuation), False otherwise.
            // """
            // self.ensure_one()
            // return self.owner_id and self.owner_id != self.company_id.partner_id
            */
            return default;
        }

        protected async Task<StockMoveLine> ShouldShowLotInInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_move_line.py) ---
            // def _should_show_lot_in_invoice(self):
            // return super()._should_show_lot_in_invoice() or self.move_id.repair_line_type
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _should_show_lot_in_invoice(self):
            // return 'customer' in {self.location_id.usage, self.location_dest_id.usage}
            */
            return default;
        }

        protected async Task<StockMoveLine> SortingMoveLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _sorting_move_lines(self):
            // return (self.id,)
            */
            return default;
        }

        protected async Task<StockMoveLine> SynchronizeQuantInternalAsync(object quantity, object location, object action, object in_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _synchronize_quant(self, quantity, location, action="available", in_date=False, **quants_value):
            // """ quantity should be express in product's UoM"""
            // lot = quants_value.get('lot', self.lot_id)
            // package = quants_value.get('package', self.package_id)
            // owner = quants_value.get('owner', self.owner_id)
            // available_qty = 0
            // if not self.product_id.is_storable or float_is_zero(quantity, precision_rounding=self.product_uom_id.rounding):
            //     return 0, False
            // if action == "available":
            //     available_qty, in_date = self.env['stock.quant']._update_available_quantity(self.product_id, location, quantity, lot_id=lot, package_id=package, owner_id=owner, in_date=in_date)
            // elif action == "reserved" and not self.move_id._should_bypass_reservation(location):
            //     self.env['stock.quant']._update_reserved_quantity(self.product_id, location, quantity, lot_id=lot, package_id=package, owner_id=owner)
            // if available_qty < 0 and lot:
            //     # see if we can compensate the negative quants with some untracked quants
            //     untracked_qty = self.env['stock.quant']._get_available_quantity(self.product_id, location, lot_id=False, package_id=package, owner_id=owner, strict=True)
            //     if not untracked_qty:
            //         return available_qty, in_date
            //     taken_from_untracked_qty = min(untracked_qty, abs(quantity))
            //     self.env['stock.quant']._update_available_quantity(self.product_id, location, -taken_from_untracked_qty, lot_id=False, package_id=package, owner_id=owner, in_date=in_date)
            //     self.env['stock.quant']._update_available_quantity(self.product_id, location, taken_from_untracked_qty, lot_id=lot, package_id=package, owner_id=owner, in_date=in_date)
            // return available_qty, in_date
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def unlink(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for ml in self:
            //     # Unlinking a move line should unreserve.
            //     if not float_is_zero(ml.quantity_product_uom, precision_digits=precision) and ml.move_id and not ml.move_id._should_bypass_reservation(ml.location_id):
            //         self.env['stock.quant']._update_reserved_quantity(ml.product_id, ml.location_id, -ml.quantity_product_uom, lot_id=ml.lot_id, package_id=ml.package_id, owner_id=ml.owner_id, strict=True)
            // moves = self.mapped('move_id')
            // package_levels = self.package_level_id
            // res = super().unlink()
            // package_levels = package_levels.filtered(lambda pl: not (pl.move_line_ids or pl.move_ids))
            // if package_levels:
            //     package_levels.unlink()
            // if moves:
            //     # Add with_prefetch() to set the _prefecht_ids = _ids
            //     # because _prefecht_ids generator look lazily on the cache of move_id
            //     # which is clear by the unlink of move line
            //     moves.with_prefetch()._recompute_state()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def unlink(self):
            // analytic_move_to_recompute = self.move_id
            // res = super().unlink()
            // analytic_move_to_recompute._account_analytic_entry_move()
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<StockMoveLine> UnlinkExceptDoneOrCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def _unlink_except_done_or_cancel(self):
            // for ml in self:
            //     if ml.state in ('done', 'cancel'):
            //         raise UserError(_('You can not delete product moves if the picking is done. You can only correct the done quantities.'))
            */
            return default;
        }

        protected async Task<StockMoveLine> UpdateSvlQuantityInternalAsync(object added_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def _update_svl_quantity(self, added_qty):
            // self.ensure_one()
            // if self.state != 'done':
            //     return
            // product_uom = self.product_id.uom_id
            // added_uom_qty = self.product_uom_id._compute_quantity(added_qty, product_uom, rounding_method='HALF-UP')
            // if float_is_zero(added_uom_qty, precision_rounding=product_uom.rounding):
            //     return
            // self._create_correction_svl(self.move_id, added_uom_qty)
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, StockMoveLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_move.py) ---
            // def write(self, vals):
            // for move_line in self:
            //     production = move_line.move_id.production_id or move_line.move_id.raw_material_production_id
            //     if production and move_line.state == 'done' and any(field in vals for field in ('lot_id', 'location_id', 'quantity')):
            //         move_line._log_message(production, move_line, 'mrp.track_production_move_template', vals)
            // return super(StockMoveLine, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py) ---
            // def write(self, vals):
            // for move_line in self:
            //     if vals.get('lot_id') and move_line.move_id.is_subcontract and move_line.location_id.is_subcontracting_location:
            //         # Update related subcontracted production to keep consistency between production and reception.
            //         subcontracted_production = move_line.move_id._get_subcontract_production().filtered(lambda p: p.state not in ('done', 'cancel') and p.lot_producing_id == move_line.lot_id)
            //         if subcontracted_production:
            //             subcontracted_production.lot_producing_id = vals['lot_id']
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py) ---
            // def write(self, vals):
            // if 'product_id' in vals and any(vals.get('state', ml.state) != 'draft' and vals['product_id'] != ml.product_id.id for ml in self):
            //     raise UserError(_("Changing the product is only allowed in 'Draft' state."))
            // 
            // if ('lot_id' in vals or 'quant_id' in vals) and len(self.product_id) > 1:
            //     raise UserError(_("Changing the Lot/Serial number for move lines with different products is not allowed."))
            // 
            // moves_to_recompute_state = self.env['stock.move']
            // triggers = [
            //     ('location_id', 'stock.location'),
            //     ('location_dest_id', 'stock.location'),
            //     ('lot_id', 'stock.lot'),
            //     ('package_id', 'stock.quant.package'),
            //     ('result_package_id', 'stock.quant.package'),
            //     ('owner_id', 'res.partner'),
            //     ('product_uom_id', 'uom.uom')
            // ]
            // if vals.get('quant_id'):
            //     vals.update(self._copy_quant_info(vals))
            // updates = {}
            // for key, model in triggers:
            //     if key in vals:
            //         updates[key] = vals[key] if isinstance(vals[key], models.BaseModel) else self.env[model].browse(vals[key])
            // 
            // if 'result_package_id' in updates:
            //     for ml in self.filtered(lambda ml: ml.package_level_id):
            //         if updates.get('result_package_id'):
            //             ml.package_level_id.package_id = updates.get('result_package_id')
            //         else:
            //             # TODO: make package levels less of a pain and fix this
            //             package_level = ml.package_level_id
            //             ml.package_level_id = False
            //             # Only need to unlink the package level if it's empty. Otherwise will unlink it to still valid move lines.
            //             if not package_level.move_line_ids:
            //                 package_level.unlink()
            // # When we try to write on a reserved move line any fields from `triggers`, result_package_id excepted,
            // # or directly reserved_uom_qty` (the actual reserved quantity), we need to make sure the associated
            // # quants are correctly updated in order to not make them out of sync (i.e. the sum of the
            // # move lines `reserved_uom_qty` should always be equal to the sum of `reserved_quantity` on
            // # the quants). If the new charateristics are not available on the quants, we chose to
            // # reserve the maximum possible.
            // if (updates and {'result_package_id'}.difference(updates.keys())) or 'quantity' in vals:
            //     for ml in self:
            //         if not ml.product_id.is_storable or ml.state == 'done':
            //             continue
            //         if 'quantity' in vals or 'product_uom_id' in vals:
            //             new_ml_uom = updates.get('product_uom_id', ml.product_uom_id)
            //             new_reserved_qty = new_ml_uom._compute_quantity(
            //                 vals.get('quantity', ml.quantity), ml.product_id.uom_id, rounding_method='HALF-UP')
            //             # Make sure `reserved_uom_qty` is not negative.
            //             if float_compare(new_reserved_qty, 0, precision_rounding=ml.product_id.uom_id.rounding) < 0:
            //                 raise UserError(_('Reserving a negative quantity is not allowed.'))
            //         else:
            //             new_reserved_qty = ml.quantity_product_uom
            // 
            //         # Unreserve the old charateristics of the move line.
            //         if not float_is_zero(ml.quantity_product_uom, precision_rounding=ml.product_uom_id.rounding):
            //             ml._synchronize_quant(-ml.quantity_product_uom, ml.location_id, action="reserved")
            // 
            //         # Reserve the maximum available of the new charateristics of the move line.
            //         if not ml.move_id._should_bypass_reservation(updates.get('location_id', ml.location_id)):
            //             ml._synchronize_quant(
            //                 new_reserved_qty, updates.get('location_id', ml.location_id), action="reserved",
            //                 lot=updates.get('lot_id', ml.lot_id), package=updates.get('package_id', ml.package_id),
            //                 owner=updates.get('owner_id', ml.owner_id))
            // 
            //         if ('quantity' in vals and vals['quantity'] != ml.quantity) or 'product_uom_id' in vals:
            //             moves_to_recompute_state |= ml.move_id
            // 
            // # When editing a done move line, the reserved availability of a potential chained move is impacted. Take care of running again `_action_assign` on the concerned moves.
            // mls = self.env['stock.move.line']
            // if updates or 'quantity' in vals:
            //     next_moves = self.env['stock.move']
            //     mls = self.filtered(lambda ml: ml.move_id.state == 'done' and ml.product_id.is_storable)
            //     if not updates:  # we can skip those where quantity is already good up to UoM rounding
            //         mls = mls.filtered(lambda ml: not float_is_zero(ml.quantity - vals['quantity'], precision_rounding=ml.product_uom_id.rounding))
            //     for ml in mls:
            //         # undo the original move line
            //         in_date = ml._synchronize_quant(-ml.quantity_product_uom, ml.location_dest_id, package=ml.result_package_id)[1]
            //         ml._synchronize_quant(ml.quantity_product_uom, ml.location_id, in_date=in_date)
            // 
            //         # Unreserve and reserve following move in order to have the real reserved quantity on move_line.
            //         next_moves |= ml.move_id.move_dest_ids.filtered(lambda move: move.state not in ('done', 'cancel'))
            // 
            //         # Log a note
            //         if ml.picking_id:
            //             ml._log_message(ml.picking_id, ml, 'stock.track_move_template', vals)
            //     move_done = mls.move_id
            //     if move_done:
            //         move_done._check_quantity()
            // 
            // # update the date when it seems like (additional) quantities are "done" and the date hasn't been manually updated
            // if 'date' not in vals and ('product_uom_id' in vals or 'quantity' in vals or vals.get('picked', False)):
            //     updated_ml_ids = set()
            //     for ml in self:
            //         if ml.state in ['draft', 'cancel', 'done']:
            //             continue
            //         if vals.get('picked', False) and not ml.picked:
            //             updated_ml_ids.add(ml.id)
            //             continue
            //         if ('quantity' in vals or 'product_uom_id' in vals) and ml.picked:
            //             new_qty = updates.get('product_uom_id', ml.product_uom_id)._compute_quantity(vals.get('quantity', ml.quantity), ml.product_id.uom_id, rounding_method='HALF-UP')
            //             old_qty = ml.product_uom_id._compute_quantity(ml.quantity, ml.product_id.uom_id, rounding_method='HALF-UP')
            //             if float_compare(old_qty, new_qty, precision_rounding=ml.product_uom_id.rounding) < 0:
            //                 updated_ml_ids.add(ml.id)
            //     self.env['stock.move.line'].browse(updated_ml_ids).date = fields.Datetime.now()
            // 
            // res = super(StockMoveLine, self).write(vals)
            // 
            // for ml in mls:
            //     available_qty, dummy = ml._synchronize_quant(-ml.quantity_product_uom, ml.location_id)
            //     ml._synchronize_quant(ml.quantity_product_uom, ml.location_dest_id, package=ml.result_package_id)
            //     if available_qty < 0:
            //         ml._free_reservation(
            //             ml.product_id, ml.location_id,
            //             abs(available_qty), lot_id=ml.lot_id, package_id=ml.package_id,
            //             owner_id=ml.owner_id)
            // 
            // # As stock_account values according to a move's `product_uom_qty`, we consider that any
            // # done stock move should have its `quantity_done` equals to its `product_uom_qty`, and
            // # this is what move's `action_done` will do. So, we replicate the behavior here.
            // if updates or 'quantity' in vals:
            //     next_moves._do_unreserve()
            //     next_moves._action_assign()
            // 
            // if moves_to_recompute_state:
            //     moves_to_recompute_state._recompute_state()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py) ---
            // def write(self, vals):
            // analytic_move_to_recompute = set()
            // if 'quantity' in vals or 'move_id' in vals:
            //     for move_line in self:
            //         move_id = vals.get('move_id', move_line.move_id.id)
            //         analytic_move_to_recompute.add(move_id)
            // new_lot = False
            // if 'lot_id' in vals:
            //     new_lot = vals.get('lot_id')
            // if 'quant_id' in vals:
            //     new_quant = vals.get('quant_id')
            //     new_lot = self.env['stock.quant'].browse(new_quant).lot_id.id
            // if new_lot:
            //     # remove quantity of old lot
            //     for move_line in self:
            //         move_line._update_svl_quantity(-move_line.quantity)
            // elif 'quantity' in vals:
            //     # directly updates the right quantity if no lot change
            //     for move_line in self:
            //         move_line._update_svl_quantity(vals['quantity'] - move_line.quantity)
            // if 'location_id' in vals or 'location_dest_id' in vals:
            //     for move_line in self:
            //         if move_line.state != 'done':
            //             continue
            //         new_loc_id = vals.get('location_id', move_line.location_id.id)
            //         new_loc = self.env['stock.location'].browse(new_loc_id)
            //         new_dest_loc_id = vals.get('location_dest_id', move_line.location_dest_id.id)
            //         new_dest_loc = self.env['stock.location'].browse(new_dest_loc_id)
            //         if move_line.location_id._should_be_valued() != new_loc._should_be_valued() \
            //                 or move_line.location_dest_id._should_be_valued() != new_dest_loc._should_be_valued():
            //             raise ValidationError(_("The stock valuation of a move is based on the type of the source and destination locations. "
            //                                     "As the move is already processed, you cannot modify the locations in a way that changes the "
            //                                     "valuation logic defined during the initial processing."))
            // res = super().write(vals)
            // if new_lot:
            //     # add quantity of new lot
            //     for move_line in self:
            //         move_line._update_svl_quantity(vals.get('quantity', move_line.quantity))
            // if analytic_move_to_recompute:
            //     self.env['stock.move'].browse(analytic_move_to_recompute)._account_analytic_entry_move()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}