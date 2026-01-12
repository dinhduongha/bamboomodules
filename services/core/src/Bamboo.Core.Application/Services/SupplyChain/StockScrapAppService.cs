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
    public class StockScrapAppService : GenericApplicationService<StockScrap>, IStockScrapAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public StockScrapAppService(IRepository<StockScrap, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockScrap> CheckAvailableQtyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def check_available_qty(self):
            // if not self._should_check_available_qty():
            //     return True
            // 
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // available_qty = self.with_context(
            //     location=self.location_id.id,
            //     lot_id=self.lot_id.id,
            //     package_id=self.package_id.id,
            //     owner_id=self.owner_id.id,
            //     strict=True,
            // ).product_id.qty_available
            // scrap_qty = self.product_uom_id._compute_quantity(self.scrap_qty, self.product_id.uom_id)
            // return float_compare(available_qty, scrap_qty, precision_digits=precision) >= 0
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockScrap> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def _compute_location_id(self):
            // remaining_scrap = self.browse()
            // 
            // for scrap in self:
            //     if scrap.production_id:
            //         if scrap.production_id.state != 'done':
            //             scrap.location_id = scrap.production_id.location_src_id.id
            //         else:
            //             scrap.location_id = scrap.production_id.location_dest_id.id
            //     elif scrap.workorder_id:
            //         scrap.location_id = scrap.workorder_id.production_id.location_src_id.id
            //     else:
            //         remaining_scrap |= scrap
            // 
            // res = super(StockScrap, remaining_scrap)._compute_location_id()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _compute_location_id(self):
            // company_warehouses = self.env['stock.warehouse'].search([('company_id', 'in', self.company_id.ids)])
            // if len(company_warehouses) == 0 and self.company_id:
            //     self.env['stock.warehouse']._warehouse_redirect_warning()
            // groups = company_warehouses._read_group(
            //     [('company_id', 'in', self.company_id.ids)], ['company_id'], ['lot_stock_id:array_agg'])
            // locations_per_company = {
            //     company.id: lot_stock_ids[0] if lot_stock_ids else False
            //     for company, lot_stock_ids in groups
            // }
            // for scrap in self:
            //     if scrap.picking_id:
            //         scrap.location_id = scrap.picking_id.location_dest_id if scrap.picking_id.state == 'done' else scrap.picking_id.location_id
            //     elif scrap.company_id:
            //         scrap.location_id = locations_per_company[scrap.company_id.id]
            */
            return default;
        }

        protected async Task<StockScrap> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _compute_product_uom_id(self):
            // for scrap in self:
            //     scrap.product_uom_id = scrap.product_id.uom_id
            */
            return default;
        }

        protected async Task<StockScrap> ComputeScrapLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _compute_scrap_location_id(self):
            // groups = self.env['stock.location']._read_group(
            //     [('company_id', 'in', self.company_id.ids), ('scrap_location', '=', True)], ['company_id'], ['id:min'])
            // locations_per_company = {
            //     company.id: stock_warehouse_id
            //     for company, stock_warehouse_id in groups
            // }
            // for scrap in self:
            //     if scrap.company_id:
            //         scrap.scrap_location_id = locations_per_company[scrap.company_id.id]
            */
            return default;
        }

        protected async Task<StockScrap> ComputeScrapQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def _compute_scrap_qty(self):
            // self.scrap_qty = 1
            // for scrap in self:
            //     if not scrap.bom_id:
            //         return super(StockScrap, scrap)._compute_scrap_qty()
            //     if scrap.move_ids:
            //         filters = {
            //             'incoming_moves': lambda m: True,
            //             'outgoing_moves': lambda m: False
            //         }
            //         scrap.scrap_qty = scrap.move_ids._compute_kit_quantities(scrap.product_id, scrap.scrap_qty, scrap.bom_id, filters)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _compute_scrap_qty(self):
            // self.scrap_qty = 1
            // for scrap in self:
            //     if scrap.move_ids:
            //         scrap.scrap_qty = scrap.move_ids[0].quantity
            */
            return default;
        }

        public async Task<StockScrap> DoReplenishAsync(Guid id, StockScrapDoReplenishRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def do_replenish(self, values=False):
            // self.ensure_one()
            // values = values or {}
            // if self.production_id and self.production_id.procurement_group_id:
            //     values.update({
            //         'group_id': self.production_id.procurement_group_id,
            //     })
            // super().do_replenish(values)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def do_replenish(self, values=False):
            // self.ensure_one()
            // values = values or {}
            // self.with_context(clean_context(self.env.context)).env['procurement.group'].run([self.env['procurement.group'].Procurement(
            //     self.product_id,
            //     self.scrap_qty,
            //     self.product_uom_id,
            //     self.location_id,
            //     self.name,
            //     self.name,
            //     self.company_id,
            //     values
            // )])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockScrap> DoScrapAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def do_scrap(self):
            // self._check_company()
            // for scrap in self:
            //     scrap.name = self.env['ir.sequence'].next_by_code('stock.scrap') or _('New')
            //     move = self.env['stock.move'].create(scrap._prepare_move_values())
            //     # master: replace context by cancel_backorder
            //     move.with_context(is_scrap=True)._action_done()
            //     scrap.write({'state': 'done'})
            //     scrap.date_done = fields.Datetime.now()
            //     if scrap.should_replenish:
            //         scrap.do_replenish()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockScrap> GetStockMoveLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def action_get_stock_move_lines(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.stock_move_line_action')
            // action['domain'] = [('move_id', 'in', self.move_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockScrap> GetStockPickingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def action_get_stock_picking(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_picking_tree_all')
            // action['domain'] = [('id', '=', self.picking_id.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockScrap> OnchangeSerialNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def _onchange_serial_number(self):
            // if self.product_id.tracking == 'serial' and self.lot_id:
            //     if self.production_id:
            //         message, recommended_location = self.env['stock.quant'].sudo()._check_serial_number(self.product_id,
            //                                                                                             self.lot_id,
            //                                                                                             self.company_id,
            //                                                                                             self.location_id,
            //                                                                                             self.production_id.location_dest_id)
            //         if message:
            //             if recommended_location:
            //                 self.location_id = recommended_location
            //             return {'warning': {'title': _('Warning'), 'message': message}}
            //     else:
            //         return super()._onchange_serial_number()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _onchange_serial_number(self):
            // if self.product_id.tracking == 'serial' and self.lot_id:
            //     message, recommended_location = self.env['stock.quant'].sudo()._check_serial_number(self.product_id,
            //                                                                                         self.lot_id,
            //                                                                                         self.company_id,
            //                                                                                         self.location_id,
            //                                                                                         self.picking_id.location_dest_id)
            //     if message:
            //         if recommended_location:
            //             self.location_id = recommended_location
            //         return {'warning': {'title': _('Warning'), 'message': message}}
            */
            return default;
        }

        protected async Task<StockScrap> PrepareMoveValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def _prepare_move_values(self):
            // vals = super(StockScrap, self)._prepare_move_values()
            // if self.production_id:
            //     vals['origin'] = vals['origin'] or self.production_id.name
            //     if self.product_id in self.production_id.move_finished_ids.mapped('product_id'):
            //         vals.update({'production_id': self.production_id.id})
            //     else:
            //         vals.update({'raw_material_production_id': self.production_id.id})
            // return vals
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _prepare_move_values(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'origin': self.origin or self.picking_id.name or self.name,
            //     'company_id': self.company_id.id,
            //     'product_id': self.product_id.id,
            //     'product_uom': self.product_uom_id.id,
            //     'state': 'draft',
            //     'product_uom_qty': self.scrap_qty,
            //     'location_id': self.location_id.id,
            //     'scrapped': True,
            //     'scrap_id': self.id,
            //     'location_dest_id': self.scrap_location_id.id,
            //     'move_line_ids': [(0, 0, {
            //         'product_id': self.product_id.id,
            //         'product_uom_id': self.product_uom_id.id,
            //         'quantity': self.scrap_qty,
            //         'location_id': self.location_id.id,
            //         'location_dest_id': self.scrap_location_id.id,
            //         'package_id': self.package_id.id,
            //         'owner_id': self.owner_id.id,
            //         'lot_id': self.lot_id.id,
            //     })],
            //     # 'restrict_partner_id': self.owner_id.id,
            //     'picked': True,
            //     'picking_id': self.picking_id.id
            // }
            */
            return default;
        }

        protected async Task<StockScrap> ShouldCheckAvailableQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py) ---
            // def _should_check_available_qty(self):
            // return super()._should_check_available_qty() or self.product_is_kit
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _should_check_available_qty(self):
            // return self.product_id.is_storable
            */
            return default;
        }

        protected async Task<StockScrap> UnlinkExceptDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def _unlink_except_done(self):
            // if 'done' in self.mapped('state'):
            //     raise UserError(_('You cannot delete a scrap which is done.'))
            */
            return default;
        }

        public async Task<StockScrap> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py) ---
            // def action_validate(self):
            // self.ensure_one()
            // if float_is_zero(self.scrap_qty,
            //                  precision_rounding=self.product_uom_id.rounding):
            //     raise UserError(_('You can only enter positive quantities.'))
            // if self.check_available_qty():
            //     return self.do_scrap()
            // else:
            //     ctx = dict(self.env.context)
            //     ctx.update({
            //         'default_product_id': self.product_id.id,
            //         'default_location_id': self.location_id.id,
            //         'default_scrap_id': self.id,
            //         'default_quantity': self.product_uom_id._compute_quantity(self.scrap_qty, self.product_id.uom_id),
            //         'default_product_uom_name': self.product_id.uom_name
            //     })
            //     return {
            //         'name': _('%(product)s: Insufficient Quantity To Scrap', product=self.product_id.display_name),
            //         'view_mode': 'form',
            //         'res_model': 'stock.warn.insufficient.qty.scrap',
            //         'view_id': self.env.ref('stock.stock_warn_insufficient_qty_scrap_form_view').id,
            //         'type': 'ir.actions.act_window',
            //         'context': ctx,
            //         'target': 'new'
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}