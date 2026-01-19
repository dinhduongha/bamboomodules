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
    [Module("Repair", Category = "SupplyChain", Depends = new[] { "sale_stock", "sale_management" })]
    public partial class RepairOrderAppService : GenericApplicationService<RepairOrder>, IRepairOrderAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public RepairOrderAppService(IRepository<RepairOrder, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        protected async Task<RepairOrder> ActionRepairConfirmInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _action_repair_confirm(self):
            // """ Repair order state is set to 'Confirmed'.
            // @param *arg: Arguments
            // @return: True
            // """
            // repairs_to_confirm = self.filtered(lambda repair: repair.state == 'draft')
            // repairs_to_confirm._check_company()
            // repairs_to_confirm.move_ids._check_company()
            // repairs_to_confirm.move_ids._adjust_procure_method(picking_type_code='repair_operation')
            // repairs_to_confirm.move_ids._action_confirm()
            // repairs_to_confirm.move_ids._trigger_scheduler()
            // repairs_to_confirm.write({'state': 'confirmed'})
            // return True
            */
            return default;
        }

        public async Task<RepairOrder> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // res['search_view_id'] = [self.env.ref('repair.product_view_search_catalog').id, 'search']
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> AssignAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_assign(self):
            // return self.move_ids._action_assign()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> ComputeAllowedLotIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_allowed_lot_ids(self):
            // for repair in self:
            //     domain = Domain('product_id', '=', repair.product_id.id)
            //     if repair.picking_id:
            //         domain &= Domain('id', 'in', repair.picking_id.move_ids.lot_ids.ids)
            //     repair.allowed_lot_ids = self.env['stock.lot'].search(domain)
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_allowed_uom_ids(self):
            // for repair in self:
            //     repair.allowed_uom_ids = repair.product_id.uom_id | repair.product_id.uom_ids | repair.product_id.seller_ids.product_uom_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeAvailabilityBooleanInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_availability_boolean(self):
            // self.is_parts_available, self.is_parts_late = False, False
            // for repair in self:
            //     if not repair.parts_availability_state:
            //         continue
            //     if repair.parts_availability_state == 'available':
            //         repair.is_parts_available = True
            //     elif repair.parts_availability_state == 'late':
            //         repair.is_parts_late = True
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeHasUncompleteMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_has_uncomplete_moves(self):
            // for repair in self:
            //     repair.has_uncomplete_moves = any(move.product_uom and move.product_uom.compare(move.quantity, move.product_uom_qty) < 0 for move in repair.move_ids)
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_location_id(self):
            // for repair in self:
            //     repair.location_id = repair.picking_type_id.default_location_src_id
            */
            return default;
        }

        public async Task<RepairOrder> ComputeLotIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def compute_lot_id(self):
            // for repair in self:
            //     if (repair.product_id and repair.lot_id and repair.lot_id.product_id != repair.product_id) or not repair.product_id:
            //         repair.lot_id = False
            //     elif len(repair.picking_id.move_ids.lot_ids) == 1:
            //         repair.lot_id = repair.picking_id.move_ids.lot_ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_partner_id(self):
            // for repair in self:
            //     repair.partner_id = repair.picking_id.partner_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePartsAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_parts_availability(self):
            // repairs = self.filtered(lambda ro: ro.state in ('confirmed', 'under_repair'))
            // repairs.parts_availability_state = 'available'
            // repairs.parts_availability = _('Available')
            // 
            // other_repairs = self - repairs
            // other_repairs.parts_availability = False
            // other_repairs.parts_availability_state = False
            // 
            // all_moves = repairs.move_ids
            // # Force to prefetch more than 1000 by 1000
            // all_moves._fields['forecast_availability'].compute_value(all_moves)
            // for repair in repairs:
            //     if any(move.product_id.uom_id.compare(move.forecast_availability, move.product_qty) < 0 for move in repair.move_ids):
            //         repair.parts_availability = _('Not Available')
            //         repair.parts_availability_state = 'late'
            //         continue
            //     forecast_date = max(repair.move_ids.filtered('forecast_expected_date').mapped('forecast_expected_date'), default=False)
            //     if not forecast_date:
            //         continue
            //     repair.parts_availability = _('Exp %s', format_date(self.env, forecast_date))
            //     if repair.schedule_date:
            //         repair.parts_availability_state = 'late' if forecast_date > repair.schedule_date else 'expected'
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingProductIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_picking_product_ids(self):
            // for repair in self:
            //     repair.picking_product_ids = repair.picking_id.move_ids.product_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_picking_type_id(self):
            // picking_type_by_company = self._get_picking_type()
            // for ro in self:
            //     ro.picking_type_id = picking_type_by_company.get((ro.company_id, ro.user_id)) or\
            //         picking_type_by_company.get((ro.company_id, False))
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingTypeVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_picking_type_visible(self):
            // repair_type_by_company = dict(self.env['stock.picking.type']._read_group([
            //         ('code', '=', 'repair_operation'),
            //         ('company_id', 'in', self.company_id.ids)
            //     ], groupby=['company_id'], aggregates=['__count']))
            // for ro in self:
            //     ro.picking_type_visible = repair_type_by_company.get(ro.company_id, 0) > 1
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_product_location_dest_id(self):
            // for record in self:
            //     record.product_location_dest_id = record.picking_type_id.default_product_location_dest_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductLocationSrcIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_product_location_src_id(self):
            // for record in self:
            //     record.product_location_src_id = record.picking_type_id.default_product_location_src_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_product_qty(self):
            // for repair in self:
            //     if repair.picking_id:
            //         if repair.tracking in ['serial', 'lot'] and repair.lot_id:
            //             lot_move_lines = repair.picking_id.move_line_ids.filtered(lambda m: m.product_id == repair.product_id and m.lot_id == repair.lot_id)
            //             repair.product_qty = sum(lot_move_lines.mapped('quantity'))
            //         else:
            //             product_moves = repair.picking_id.move_ids.filtered(lambda m: m.product_id == repair.product_id)
            //             repair.product_qty = sum(product_moves.mapped('quantity'))
            //     else:
            //         repair.product_qty = 1.0
            */
            return default;
        }

        public async Task<RepairOrder> ComputeProductUomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def compute_product_uom(self):
            // for repair in self:
            //     if not repair.product_id:
            //         repair.product_uom = False
            //     elif not repair.product_uom:
            //         repair.product_uom = repair.product_id.uom_id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> ComputeProductionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def _compute_production_count(self):
            // for repair in self:
            //     repair.production_count = len(repair.reference_ids.production_ids)
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePurchaseCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_repair, FILE: repair_order.py) ---
            // def _compute_purchase_count(self):
            // for repair in self:
            //     repair.purchase_count = len(repair.move_ids.created_purchase_line_ids.order_id)
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeRecycleLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_recycle_location_id(self):
            // for repair in self:
            //     repair.recycle_location_id = repair.picking_type_id.default_recycle_location_dest_id
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeUnreserveVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _compute_unreserve_visible(self):
            // for repair in self:
            //     repair.unreserve_visible = (
            //         repair.state not in ('draft', 'done', 'cancel') and
            //         any(repair.move_ids.move_line_ids.mapped('quantity_product_uom'))
            //     )
            //     repair.reserve_visible = (
            //         repair.state in ('confirmed', 'under_repair') and
            //         any(not move.picked and move.product_uom_qty and move.state in ['confirmed', 'partially_available'] for move in repair.move_ids)
            //     )
            */
            return default;
        }

        public override async Task<RepairOrder> CreateAsync(RepairOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def create(self, vals_list):
            // orders = super().create(vals_list)
            // orders.action_explode()
            // return orders
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def create(self, vals_list):
            // # We generate a standard reference
            // for vals in vals_list:
            //     picking_type = self.env['stock.picking.type'].browse(
            //         vals.get('picking_type_id', self.default_get(['picking_type_id'])['picking_type_id'])
            //     )
            //     if 'picking_type_id' not in vals:
            //         vals['picking_type_id'] = picking_type.id
            //     if not vals.get('name', False) or vals['name'] == 'New':
            //         vals['name'] = picking_type.sequence_id.next_by_id()
            //     if not vals.get('reference_ids'):
            //         vals['reference_ids'] = [Command.link(self.env["stock.reference"].create({'name': vals['name']}).id)]
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<RepairOrder> CreateSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_create_sale_order(self):
            // if any(repair.sale_order_id for repair in self):
            //     concerned_ro = self.filtered('sale_order_id')
            //     ref_str = "\n".join(ro.name for ro in concerned_ro)
            //     raise UserError(
            //         _(
            //             "You cannot create a quotation for a repair order that is already linked to an existing sale order.\nConcerned repair order(s):\n%(ref_str)s",
            //             ref_str=ref_str,
            //         ),
            //     )
            // if any(not repair.partner_id for repair in self):
            //     concerned_ro = self.filtered(lambda ro: not ro.partner_id)
            //     ref_str = "\n".join(ro.name for ro in concerned_ro)
            //     raise UserError(
            //         _(
            //             "You need to define a customer for a repair order in order to create an associated quotation.\nConcerned repair order(s):\n%(ref_str)s",
            //             ref_str=ref_str,
            //         ),
            //     )
            // sale_order_values_list = []
            // for repair in self:
            //     sale_order_values_list.append({
            //         "company_id": self.company_id.id,
            //         "partner_id": self.partner_id.id,
            //         "warehouse_id": self.picking_type_id.warehouse_id.id,
            //         "repair_order_ids": [Command.link(repair.id)],
            //         "origin": repair.name,
            //     })
            // self.env['sale.order'].create(sale_order_values_list)
            // # Add Sale Order Lines for 'add' move_ids
            // self.move_ids._create_repair_sale_order_line()
            // return self.action_view_sale_order()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['stock.move']._get_product_catalog_lines_data(parent_record=self)
            // 
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        protected async Task<RepairOrder> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _default_picking_type_id(self):
            // return self._get_picking_type().get((self.env.company, self.env.user))
            */
            return default;
        }

        public async Task<RepairOrder> ExplodeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def action_explode(self):
            // lines_to_unlink_ids = set()
            // line_vals_list = []
            // for op in self.move_ids:
            //     bom = self.env['mrp.bom'].sudo()._bom_find(op.product_id, company_id=op.company_id.id, bom_type='phantom')[op.product_id]
            //     if not bom:
            //         continue
            //     factor = op.product_uom._compute_quantity(op.product_uom_qty, bom.product_uom_id) / bom.product_qty
            //     _boms, lines = bom.sudo().explode(op.product_id, factor, picking_type=bom.picking_type_id)
            //     for bom_line, line_data in lines:
            //         if bom_line.product_id.type != 'service':
            //             line_vals_list.append(op._prepare_phantom_line_vals(bom_line, line_data['qty']))
            //     lines_to_unlink_ids.add(op.id)
            // 
            // self.env['stock.move'].browse(lines_to_unlink_ids).sudo().unlink()
            // if line_vals_list:
            //     self.env['stock.move'].create(line_vals_list)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> GenerateSerialAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_generate_serial(self):
            // self.ensure_one()
            // name = self.product_id.lot_sequence_id.next_by_id()
            // exist_lot = not name or self.env['stock.lot'].search([
            //     ('product_id', '=', self.product_id.id),
            //     '|', ('company_id', '=', False), ('company_id', '=', self.company_id.id),
            //     ('name', '=', name),
            // ], limit=1)
            // if exist_lot:
            //     name = self.env['stock.lot']._get_next_serial(self.company_id, self.product_id)
            // if not name:
            //     raise UserError(_("Please set the first Serial Number or a default sequence"))
            // self.lot_id = self.env['stock.lot'].create({'product_id': self.product_id.id, 'name': name})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // bom = self.env['mrp.bom']._bom_find(self.product_id, company_id=self.company_id.id)[self.product_id]
            // product_ids = [line.product_id.id for line in bom.bom_line_ids] if bom else []
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'catalog_bom_product_ids': product_ids,
            //     'search_default_bom_parts': bool(product_ids)
            // }
            */
            return default;
        }

        protected async Task<RepairOrder> GetLocationInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_location(self, field):
            // return self.picking_type_id[MAP_REPAIR_TO_PICKING_LOCATIONS[field]]
            */
            return default;
        }

        protected async Task<RepairOrder> GetPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_picking_type(self):
            // companies = self.company_id or self.env.company
            // if not self:
            //     # default case
            //     default_warehouse = self.env.user.with_company(companies.id)._get_default_warehouse_id()
            //     if default_warehouse and default_warehouse.repair_type_id:
            //         return {(companies, self.env.user): default_warehouse.repair_type_id}
            // 
            // picking_type_by_company_user = {}
            // without_default_warehouse_companies = set()
            // for company, user in unique((r.company_id, r.user_id) for r in self):
            //     default_warehouse = user.with_company(company.id)._get_default_warehouse_id()
            //     if default_warehouse and default_warehouse.repair_type_id:
            //         picking_type_by_company_user[(company, user)] = default_warehouse.repair_type_id
            //     else:
            //         without_default_warehouse_companies.add(company.id)
            // 
            // if not without_default_warehouse_companies:
            //     return picking_type_by_company_user
            // 
            // domain = [
            //     ('code', '=', 'repair_operation'),
            //     ('warehouse_id.company_id', 'in', list(without_default_warehouse_companies)),
            // ]
            // 
            // picking_types = self.env['stock.picking.type'].search_read(domain, ['company_id'], load=False)
            // for picking_type in picking_types:
            //     if (picking_type.company_id, False) not in picking_type_by_company_user:
            //         picking_type_by_company_user[(picking_type.company_id, False)] = picking_type
            // return picking_type_by_company_user
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('type', '=', 'consu')
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // product_catalog = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     product_catalog[product.id] |= self._get_product_price_and_data(product)
            // return product_catalog
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['stock.move'])
            // 
            // for line in self.move_ids:
            //     if line.product_id.id in product_ids:
            //         grouped_lines[line.product_id] |= line
            // 
            // return grouped_lines
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _get_product_price_and_data(self, product):
            // self.ensure_one()
            // return {'price': product.list_price}
            */
            return default;
        }

        protected async Task<RepairOrder> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _is_display_stock_in_catalog(self):
            // return True
            */
            return default;
        }

        public async Task<RepairOrder> MessagePostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def message_post(self, **kwargs):
            // kwargs['notify_author_mention'] = kwargs.get('notify_author_mention', True)
            // return super().message_post(**kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> OnchangeLocationPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _onchange_location_picking(self):
            // location_warehouse = self.location_id.warehouse_id
            // picking_warehouse = self.picking_id.location_dest_id.warehouse_id
            // if location_warehouse and picking_warehouse and location_warehouse != picking_warehouse:
            //     return {
            //         'warning': {'title': _("Warning"), 'message': _("Note that the warehouses of the return and repair locations don't match!")},
            //     }
            */
            return default;
        }

        public async Task<RepairOrder> OnchangeProductUomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def onchange_product_uom(self):
            // res = {}
            // if not self.product_id or not self.product_uom:
            //     return res
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> PrintRepairOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def print_repair_order(self):
            // return self.env.ref('repair.action_report_repair_order').report_action(self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> RepairCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_repair_cancel(self):
            // if any(repair.state == 'done' for repair in self):
            //     raise UserError(_("You cannot cancel a Repair Order that's already been completed"))
            // for repair in self:
            //     if repair.sale_order_id:
            //         repair.sale_order_line_id.write({'product_uom_qty': 0.0})  # Quantity of the product that generated the RO is set to 0
            // self.move_ids._action_cancel()  # Quantity of parts added from the RO to the SO is set to 0
            // return self.write({'state': 'cancel'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> RepairCancelDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_repair_cancel_draft(self):
            // if self.filtered(lambda repair: repair.state != 'cancel'):
            //     self.action_repair_cancel()
            // sale_line_to_update = self.move_ids.sale_line_id.filtered(lambda l: l.order_id.state != 'cancel' and l.product_uom_id.is_zero(l.product_uom_qty))
            // sale_line_to_update.move_ids._update_repair_sale_order_line()
            // self.move_ids.state = 'draft'
            // self.state = 'draft'
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> RepairDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_repair_done(self):
            // """ Creates stock move for final product of repair order.
            // Writes move_id and move_ids state to 'done'.
            // Writes repair order state to 'Repaired'.
            // @return: True
            // """
            // 
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // product_move_vals = []
            // 
            // # Cancel moves with 0 quantity
            // self.move_ids.filtered(lambda m: m.product_uom.is_zero(m.quantity))._action_cancel()
            // 
            // no_service_policy = 'service_policy' not in self.env['product.template']
            // #SOL qty delivered = repair.move_ids.quantity
            // for repair in self:
            //     if all(not move.picked for move in repair.move_ids):
            //         repair.move_ids.picked = True
            //     if repair.sale_order_line_id:
            //         ro_origin_product = repair.sale_order_line_id.product_template_id
            //         # TODO: As 'service_policy' only appears with 'sale_project' module, isolate conditions related to this field in a 'sale_project_repair' module if it's worth
            //         if ro_origin_product.type == 'service' and (no_service_policy or ro_origin_product.service_policy == 'ordered_prepaid'):
            //             repair.sale_order_line_id.qty_delivered = repair.sale_order_line_id.product_uom_qty
            //     if not repair.product_id:
            //         continue
            // 
            //     if repair.product_id.product_tmpl_id.tracking != 'none' and not repair.lot_id:
            //         raise ValidationError(_(
            //             "Serial number is required for product to repair : %s",
            //             repair.product_id.display_name
            //         ))
            // 
            //     # Try to create move with the appropriate owner
            //     owner_id = False
            //     available_qty_owner = self.env['stock.quant']._get_available_quantity(repair.product_id, repair.location_id, repair.lot_id, owner_id=repair.partner_id, strict=True)
            //     if float_compare(available_qty_owner, repair.product_qty, precision_digits=precision) >= 0:
            //         owner_id = repair.partner_id.id
            // 
            //     product_move_vals.append({
            //         'product_id': repair.product_id.id,
            //         'product_uom': repair.product_uom.id or repair.product_id.uom_id.id,
            //         'product_uom_qty': repair.product_qty,
            //         'partner_id': repair.partner_id.id,
            //         'location_id': repair.product_location_src_id.id,
            //         'location_dest_id': repair.product_location_dest_id.id,
            //         'picked': True,
            //         'picking_id': False,
            //         'move_line_ids': [(0, 0, {
            //             'product_id': repair.product_id.id,
            //             'lot_id': repair.lot_id.id,
            //             'product_uom_id': repair.product_uom.id or repair.product_id.uom_id.id,
            //             'quantity': repair.product_qty,
            //             'package_id': False,
            //             'result_package_id': False,
            //             'owner_id': owner_id,
            //             'location_id': repair.product_location_src_id.id,
            //             'company_id': repair.company_id.id,
            //             'location_dest_id': repair.product_location_dest_id.id,
            //             'consume_line_ids': [(6, 0, repair.move_ids.move_line_ids.ids)]
            //         })],
            //         'repair_id': repair.id,
            //         'origin': repair.name,
            //         'company_id': repair.company_id.id,
            //     })
            // 
            // product_moves = self.env['stock.move'].create(product_move_vals)
            // repair_move = {m.repair_id.id: m for m in product_moves}
            // for repair in self:
            //     move_id = repair_move.get(repair.id, False)
            //     if move_id:
            //         repair.move_id = move_id
            // all_moves = self.move_ids + product_moves
            // all_moves._action_done(cancel_backorder=True)
            // 
            // for sale_line in self.move_ids.sale_line_id:
            //     price_unit = sale_line.price_unit
            //     sale_line.write({'product_uom_qty': sale_line.qty_delivered, 'price_unit': price_unit})
            // 
            // self.state = 'done'
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> RepairEndAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_repair_end(self):
            // """ Checks before action_repair_done.
            // @return: True
            // """
            // if self.filtered(lambda repair: repair.state != 'under_repair'):
            //     raise UserError(_("Repair must be under repair in order to end reparation."))
            // partial_moves = set()
            // picked_moves = set()
            // for move in self.move_ids:
            //     if move.product_uom.compare(move.quantity, move.product_uom_qty) < 0:
            //         partial_moves.add(move.id)
            //     if move.picked:
            //         picked_moves.add(move.id)
            // return self.action_repair_done()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> RepairStartAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_repair_start(self):
            // """ Writes repair order state to 'Under Repair'
            // """
            // if self.filtered(lambda repair: repair.state != 'confirmed'):
            //     self._action_repair_confirm()
            // return self.write({'state': 'under_repair'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> SearchDateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _search_date_category(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return Domain.OR(
            //     self.env['stock.picking'].date_category_to_domain('schedule_date', item)
            //     for item in value
            // )
            */
            return default;
        }

        protected async Task<RepairOrder> UnlinkExceptConfirmedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _unlink_except_confirmed(self):
            // repairs_to_cancel = self.filtered(lambda ro: ro.state not in ('draft', 'cancel'))
            // repairs_to_cancel.action_repair_cancel()
            */
            return default;
        }

        public async Task<RepairOrder> UnreserveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_unreserve(self):
            // return self.move_ids.filtered(lambda m: m.state in ('assigned', 'partially_available'))._do_unreserve()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RepairOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // move = self.move_ids.filtered(lambda e: e.product_id.id == product_id)
            // if move:
            //     if quantity != 0:
            //         move.product_uom_qty = quantity
            //     else:
            //         move.unlink()
            // elif quantity > 0:
            //     move = self.env['stock.move'].create({
            //         'repair_id': self.id,
            //         'product_uom_qty': quantity,
            //         'product_id': product_id,
            //         'location_id': self.location_id.id,
            //         'location_dest_id': self.location_dest_id.id,
            //         'repair_line_type': 'add'
            //     })
            // 
            // return self.env['product.product'].browse(product_id).list_price
            */
            return default;
        }

        protected async Task<RepairOrder> UpdateSaleOrderLinePriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def _update_sale_order_line_price(self):
            // for repair in self:
            //     add_moves = repair.move_ids.filtered(lambda m: m.repair_line_type == 'add' and m.sale_line_id)
            //     if repair.under_warranty:
            //         add_moves.sale_line_id.write({'price_unit': 0.0, 'technical_price_unit': 0.0})
            //     else:
            //         add_moves.sale_line_id._compute_price_unit()
            */
            return default;
        }

        public async Task<RepairOrder> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_validate(self):
            // self.ensure_one()
            // if self.filtered(lambda repair: any(m.product_uom_qty < 0 for m in repair.move_ids)):
            //     raise UserError(_("You can not enter negative quantities."))
            // if not self.product_id or not self.product_id.is_storable:
            //     return self._action_repair_confirm()
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // available_qty_owner = sum(self.env['stock.quant'].search([
            //     ('product_id', '=', self.product_id.id),
            //     ('location_id', '=', self.product_location_src_id.id),
            //     ('lot_id', '=', self.lot_id.id),
            //     ('owner_id', '=', self.partner_id.id),
            // ]).mapped('quantity'))
            // available_qty_noown = sum(self.env['stock.quant'].search([
            //     ('product_id', '=', self.product_id.id),
            //     ('location_id', '=', self.product_location_src_id.id),
            //     ('lot_id', '=', self.lot_id.id),
            //     ('owner_id', '=', False),
            // ]).mapped('quantity'))
            // repair_qty = self.product_uom._compute_quantity(self.product_qty, self.product_id.uom_id)
            // for available_qty in [available_qty_owner, available_qty_noown]:
            //     if float_compare(available_qty, repair_qty, precision_digits=precision) >= 0:
            //         return self._action_repair_confirm()
            // 
            // return {
            //     'name': _('%(product)s: Insufficient Quantity To Repair', product=self.product_id.display_name),
            //     'view_mode': 'form',
            //     'res_model': 'stock.warn.insufficient.qty.repair',
            //     'view_id': self.env.ref('repair.stock_warn_insufficient_qty_repair_form_view').id,
            //     'type': 'ir.actions.act_window',
            //     'context': {
            //         'default_product_id': self.product_id.id,
            //         'default_location_id': self.product_location_src_id.id,
            //         'default_repair_id': self.id,
            //         'default_quantity': repair_qty,
            //         'default_product_uom_name': self.product_id.uom_name
            //     },
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> ViewMrpProductionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def action_view_mrp_productions(self):
            // self.ensure_one()
            // production_order_ids = self.reference_ids.production_ids
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mrp.production',
            //     'views': [[False, 'form']],
            // }
            // 
            // if self.production_count == 1:
            //     action['res_id'] = production_order_ids.id
            // elif self.production_count > 1:
            //     action['name'] = _("Manufacturing Orders generated by %s", self.name)
            //     action['views'] = [[False, 'list']]
            //     action['domain'] = [('id', 'in', production_order_ids.ids)]
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> ViewPurchaseOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_repair, FILE: repair_order.py) ---
            // def action_view_purchase_orders(self):
            // self.ensure_one()
            // purchase_ids = self.move_ids.created_purchase_line_ids.order_id
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'purchase.order',
            //     'views': [[False, 'form']],
            // }
            // if self.purchase_count == 1:
            //     action['res_id'] = purchase_ids.id
            // elif self.purchase_count > 1:
            //     action['name'] = _('Purchase Orders')
            //     action['views'] = [[False, 'list']]
            //     action['domain'] = [('id', 'in', purchase_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RepairOrder> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def action_view_sale_order(self):
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "sale.order",
            //     "views": [[False, "form"]],
            //     "res_id": self.sale_order_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, RepairOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // self.action_explode()
            // return res
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: repair.py) ---
            // def write(self, vals):
            // moves_to_reassign = self.env['stock.move']
            // if vals.get('picking_type_id'):
            //     picking_type = self.env['stock.picking.type'].browse(vals.get('picking_type_id'))
            //     for repair in self:
            //         if repair.state in ('cancel', 'done'):
            //             continue
            //         if picking_type != repair.picking_type_id:
            //             repair.name = picking_type.sequence_id.next_by_id()
            //             moves_to_reassign |= repair.move_ids
            // res = super().write(vals)
            // if 'product_id' in vals and self.tracking == 'serial':
            //     self.write({'product_qty': 1.0})
            // 
            // for repair in self:
            //     has_modified_location = any(key in vals for key in MAP_REPAIR_TO_PICKING_LOCATIONS)
            //     if has_modified_location:
            //         repair.move_ids._set_repair_locations()
            //     if 'schedule_date' in vals:
            //         (repair.move_id + repair.move_ids).filtered(lambda m: m.state not in ('done', 'cancel')).write({'date': repair.schedule_date})
            //     if 'under_warranty' in vals:
            //         repair._update_sale_order_line_price()
            // if moves_to_reassign:
            //     moves_to_reassign._do_unreserve()
            //     moves_to_reassign = moves_to_reassign.filtered(
            //         lambda move: move.state in ('confirmed', 'partially_available')
            //         and (move._should_bypass_reservation()
            //             or move.picking_type_id.reservation_method == 'at_confirm'
            //             or (move.reservation_date and move.reservation_date <= fields.Date.today())))
            //     moves_to_reassign._action_assign()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}