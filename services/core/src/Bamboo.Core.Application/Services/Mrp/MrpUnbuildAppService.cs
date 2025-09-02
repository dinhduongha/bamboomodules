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
    [Module("Mrp", Depends = new[] { "product", "stock", "resource" })]
    public class MrpUnbuildAppService : GenericApplicationService<MrpUnbuild>, IMrpUnbuildAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public MrpUnbuildAppService(IRepository<MrpUnbuild, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<MrpUnbuild> ComputeBomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_bom_id(self):
            // for order in self:
            //     if order.mo_id:
            //         order.bom_id = order.mo_id.bom_id
            //     else:
            //         order.bom_id = self.env['mrp.bom']._bom_find(
            //             order.product_id, company_id=order.company_id.id
            //         )[order.product_id]
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_location_id(self):
            // for order in self:
            //     if order.company_id:
            //         warehouse = self.env['stock.warehouse'].search([('company_id', '=', order.company_id.id)], limit=1)
            //         if order.location_id.company_id != order.company_id:
            //             order.location_id = warehouse.lot_stock_id
            //         if order.location_dest_id.company_id != order.company_id:
            //             order.location_dest_id = warehouse.lot_stock_id
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeLotIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_lot_id(self):
            // for order in self:
            //     if order.mo_id:
            //         order.lot_id = order.mo_id.lot_producing_id
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_product_id(self):
            // for order in self:
            //     if order.mo_id and order.mo_id.product_id:
            //         order.product_id = order.mo_id.product_id
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_product_qty(self):
            // for order in self:
            //     if order.mo_id:
            //         if order.has_tracking == 'serial':
            //             order.product_qty = 1
            //         else:
            //             order.product_qty = order.mo_id.qty_produced
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _compute_product_uom_id(self):
            // for record in self:
            //     if record.mo_id.product_id and record.mo_id.product_id == record.product_id:
            //         record.product_uom_id = record.mo_id.product_uom_id.id
            //     else:
            //         record.product_uom_id = record.product_id.uom_id.id
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateConsumeMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _generate_consume_moves(self):
            // moves = self.env['stock.move']
            // for unbuild in self:
            //     if unbuild.mo_id:
            //         finished_moves = unbuild.mo_id.move_finished_ids.filtered(lambda move: move.state == 'done')
            //         factor = unbuild.product_qty / unbuild.mo_id.product_uom_id._compute_quantity(unbuild.mo_id.qty_produced, unbuild.product_uom_id)
            //         for finished_move in finished_moves:
            //             moves += unbuild._generate_move_from_existing_move(finished_move, factor, unbuild.location_id, finished_move.location_id)
            //     else:
            //         factor = unbuild.product_uom_id._compute_quantity(unbuild.product_qty, unbuild.bom_id.product_uom_id) / unbuild.bom_id.product_qty
            //         moves += unbuild._generate_move_from_bom_line(self.product_id, self.product_uom_id, unbuild.product_qty)
            //         for byproduct in unbuild.bom_id.byproduct_ids:
            //             if byproduct._skip_byproduct_line(unbuild.product_id):
            //                 continue
            //             quantity = byproduct.product_qty * factor
            //             moves += unbuild._generate_move_from_bom_line(byproduct.product_id, byproduct.product_uom_id, quantity, byproduct_id=byproduct.id)
            // return moves
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateMoveFromBomLineInternalAsync(object product, object product_uom, object quantity, Guid bom_line_id, Guid byproduct_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _generate_move_from_bom_line(self, product, product_uom, quantity, bom_line_id=False, byproduct_id=False):
            // product_prod_location = product.with_company(self.company_id).property_stock_production
            // location_id = bom_line_id and product_prod_location or self.location_id
            // location_dest_id = bom_line_id and self.location_dest_id or product_prod_location
            // warehouse = location_dest_id.warehouse_id
            // return self.env['stock.move'].create({
            //     'name': self.name,
            //     'date': self.create_date,
            //     'bom_line_id': bom_line_id,
            //     'byproduct_id': byproduct_id,
            //     'product_id': product.id,
            //     'product_uom_qty': quantity,
            //     'product_uom': product_uom.id,
            //     'procure_method': 'make_to_stock',
            //     'location_dest_id': location_dest_id.id,
            //     'location_id': location_id.id,
            //     'warehouse_id': warehouse.id,
            //     'unbuild_id': self.id,
            //     'company_id': self.company_id.id,
            // })
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateMoveFromExistingMoveInternalAsync(object move, object factor, Guid location_id, Guid location_dest_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _generate_move_from_existing_move(self, move, factor, location_id, location_dest_id):
            // return self.env['stock.move'].create({
            //     'name': self.name,
            //     'date': self.create_date,
            //     'product_id': move.product_id.id,
            //     'product_uom_qty': move.quantity * factor,
            //     'product_uom': move.product_uom.id,
            //     'procure_method': 'make_to_stock',
            //     'location_dest_id': location_dest_id.id,
            //     'location_id': location_id.id,
            //     'warehouse_id': location_dest_id.warehouse_id.id,
            //     'unbuild_id': self.id,
            //     'company_id': move.company_id.id,
            //     'origin_returned_move_id': move.id,
            // })
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateProduceMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _generate_produce_moves(self):
            // moves = self.env['stock.move']
            // for unbuild in self:
            //     if unbuild.mo_id:
            //         raw_moves = unbuild.mo_id.move_raw_ids.filtered(lambda move: move.state == 'done')
            //         factor = unbuild.product_qty / unbuild.mo_id.product_uom_id._compute_quantity(unbuild.mo_id.qty_produced, unbuild.product_uom_id)
            //         for raw_move in raw_moves:
            //             moves += unbuild._generate_move_from_existing_move(raw_move, factor, raw_move.location_dest_id, self.location_dest_id)
            //     else:
            //         factor = unbuild.product_uom_id._compute_quantity(unbuild.product_qty, unbuild.bom_id.product_uom_id) / unbuild.bom_id.product_qty
            //         boms, lines = unbuild.bom_id.explode(unbuild.product_id, factor, picking_type=unbuild.bom_id.picking_type_id)
            //         for line, line_data in lines:
            //             moves += unbuild._generate_move_from_bom_line(line.product_id, line.product_uom_id, line_data['qty'], bom_line_id=line.id)
            // return moves
            */
            return default;
        }

        protected async Task<MrpUnbuild> PrepareFinishedMoveLineValsInternalAsync(object finished_move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _prepare_finished_move_line_vals(self, finished_move):
            // return {
            //     'move_id': finished_move.id,
            //     'lot_id': self.lot_id.id,
            //     'quantity': finished_move.product_uom_qty,
            //     'product_id': finished_move.product_id.id,
            //     'product_uom_id': finished_move.product_uom.id,
            //     'location_id': finished_move.location_id.id,
            //     'location_dest_id': finished_move.location_dest_id.id,
            // }
            */
            return default;
        }

        protected async Task<MrpUnbuild> PrepareMoveLineValsInternalAsync(object move, object origin_move_line, object taken_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _prepare_move_line_vals(self, move, origin_move_line, taken_quantity):
            // return {
            //     'move_id': move.id,
            //     'lot_id': origin_move_line.lot_id.id,
            //     'quantity': taken_quantity,
            //     'product_id': move.product_id.id,
            //     'product_uom_id': origin_move_line.product_uom_id.id,
            //     'location_id': move.location_id.id,
            //     'location_dest_id': move.location_dest_id.id,
            // }
            */
            return default;
        }

        public async Task<MrpUnbuild> UnbuildAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def action_unbuild(self):
            // self.ensure_one()
            // self._check_company()
            // # remove the default_* keys that was only needed in the unbuild wizard
            // self.env.context = dict(clean_context(self.env.context))
            // if self.product_id.tracking != 'none' and not self.lot_id.id:
            //     raise UserError(_('You should provide a lot number for the final product.'))
            // 
            // if self.mo_id and self.mo_id.state != 'done':
            //     raise UserError(_('You cannot unbuild a undone manufacturing order.'))
            // 
            // consume_moves = self._generate_consume_moves()
            // consume_moves._action_confirm()
            // produce_moves = self._generate_produce_moves()
            // produce_moves._action_confirm()
            // produce_moves.quantity = 0
            // 
            // finished_moves = consume_moves.filtered(lambda m: m.product_id == self.product_id)
            // consume_moves -= finished_moves
            // 
            // if any(produce_move.has_tracking != 'none' and not self.mo_id for produce_move in produce_moves):
            //     raise UserError(_('Some of your components are tracked, you have to specify a manufacturing order in order to retrieve the correct components.'))
            // 
            // if any(consume_move.has_tracking != 'none' and not self.mo_id for consume_move in consume_moves):
            //     raise UserError(_('Some of your byproducts are tracked, you have to specify a manufacturing order in order to retrieve the correct byproducts.'))
            // 
            // for finished_move in finished_moves:
            //     finished_move_line_vals = self._prepare_finished_move_line_vals(finished_move)
            //     self.env['stock.move.line'].create(finished_move_line_vals)
            // 
            // # TODO: Will fail if user do more than one unbuild with lot on the same MO. Need to check what other unbuild has aready took
            // qty_already_used = defaultdict(float)
            // for move in produce_moves | consume_moves:
            //     original_move = move in produce_moves and self.mo_id.move_raw_ids or self.mo_id.move_finished_ids
            //     original_move = original_move.filtered(lambda m: m.product_id == move.product_id)
            //     if not original_move:
            //         move.quantity = float_round(move.product_uom_qty, precision_rounding=move.product_uom.rounding)
            //         continue
            //     needed_quantity = move.product_uom_qty
            //     moves_lines = original_move.mapped('move_line_ids')
            //     if move in produce_moves and self.lot_id:
            //         moves_lines = moves_lines.filtered(lambda ml: self.lot_id in ml.produce_line_ids.lot_id)  # FIXME sle: double check with arm
            //     for move_line in moves_lines:
            //         # Iterate over all move_lines until we unbuilded the correct quantity.
            //         taken_quantity = min(needed_quantity, move_line.quantity - qty_already_used[move_line])
            //         taken_quantity = float_round(taken_quantity, precision_rounding=move.product_uom.rounding)
            //         if taken_quantity:
            //             move_line_vals = self._prepare_move_line_vals(move, move_line, taken_quantity)
            //             unbuild_move_line = self.env["stock.move.line"].create(move_line_vals)
            //             needed_quantity -= taken_quantity
            //             qty_already_used[move_line] += taken_quantity
            //             unbuild_move_line._apply_putaway_strategy()
            // 
            // (finished_moves | consume_moves | produce_moves).picked = True
            // finished_moves._action_done()
            // consume_moves._action_done()
            // produce_moves._action_done()
            // produced_move_line_ids = produce_moves.mapped('move_line_ids').filtered(lambda ml: ml.quantity > 0)
            // consume_moves.mapped('move_line_ids').write({'produce_line_ids': [(6, 0, produced_move_line_ids.ids)]})
            // if self.mo_id:
            //     unbuild_msg = _("%(qty)s %(measure)s unbuilt in %(order)s",
            //         qty=self.product_qty,
            //         measure=self.product_uom_id.name,
            //         order=self._get_html_link(),
            //     )
            //     self.mo_id.message_post(
            //         body=unbuild_msg,
            //         subtype_xmlid='mail.mt_note',
            //     )
            // return self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpUnbuild> UnlinkExceptDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def _unlink_except_done(self):
            // if 'done' in self.mapped('state'):
            //     raise UserError(_("You cannot delete an unbuild order if the state is 'Done'."))
            */
            return default;
        }

        public async Task<MrpUnbuild> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py) ---
            // def action_validate(self):
            // self.ensure_one()
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // available_qty = self.env['stock.quant']._get_available_quantity(self.product_id, self.location_id, self.lot_id, strict=True)
            // unbuild_qty = self.product_uom_id._compute_quantity(self.product_qty, self.product_id.uom_id)
            // if float_compare(available_qty, unbuild_qty, precision_digits=precision) >= 0:
            //     return self.action_unbuild()
            // else:
            //     return {
            //         'name': _('%(product)s: Insufficient Quantity To Unbuild', product=self.product_id.display_name),
            //         'view_mode': 'form',
            //         'res_model': 'stock.warn.insufficient.qty.unbuild',
            //         'view_id': self.env.ref('mrp.stock_warn_insufficient_qty_unbuild_form_view').id,
            //         'type': 'ir.actions.act_window',
            //         'context': {
            //             'default_product_id': self.product_id.id,
            //             'default_location_id': self.location_id.id,
            //             'default_unbuild_id': self.id,
            //             'default_quantity': unbuild_qty,
            //             'default_product_uom_name': self.product_id.uom_name,
            //         },
            //         'target': 'new',
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}