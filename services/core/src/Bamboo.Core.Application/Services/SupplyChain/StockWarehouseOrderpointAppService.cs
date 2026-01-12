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
    public class StockWarehouseOrderpointAppService : GenericApplicationService<StockWarehouseOrderpoint>, IStockWarehouseOrderpointAppService
    {

        public StockWarehouseOrderpointAppService(IRepository<StockWarehouseOrderpoint, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockWarehouseOrderpoint> CheckMinMaxQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _check_min_max_qty(self):
            // if any(orderpoint.product_min_qty > orderpoint.product_max_qty for orderpoint in self):
            //     raise ValidationError(_('The minimum quantity must be less than or equal to the maximum quantity.'))
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> CheckProductIsNotKitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def check_product_is_not_kit(self):
            // domain = [
            //     '|', ('product_id', 'in', self.product_id.ids),
            //          '&', ('product_id', '=', False),
            //               ('product_tmpl_id', 'in', self.product_id.product_tmpl_id.ids),
            //     ('type', '=', 'phantom'),
            // ]
            // if self.env['mrp.bom'].search_count(domain, limit=1):
            //     raise ValidationError(_("A product with a kit-type bill of materials can not have a reordering rule."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> CheckProductUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _check_product_uom(self):
            // ''' Check if the UoM has the same category as the product standard UoM '''
            // if any(orderpoint.product_id.uom_id.category_id != orderpoint.product_uom.category_id for orderpoint in self):
            //     raise ValidationError(_('You have to select a product unit of measure that is in the same category as the default unit of measure of the product'))
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeAllowedLocationIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_allowed_location_ids(self):
            // # We want to keep only the locations
            // #  - strictly belonging to our warehouse
            // #  - not belonging to any warehouses
            // for orderpoint in self:
            //     loc_domain = [('usage', 'in', ('internal', 'view'))]
            //     other_warehouses = self.env['stock.warehouse'].search([('id', '!=', orderpoint.warehouse_id.id)])
            //     for view_location_id in other_warehouses.mapped('view_location_id'):
            //         loc_domain = expression.AND([loc_domain, ['!', ('id', 'child_of', view_location_id.id)]])
            //         loc_domain = expression.AND([loc_domain, ['|', ('company_id', '=', False), ('company_id', '=', orderpoint.company_id.id)]])
            //     orderpoint.allowed_location_ids = self.env['stock.location'].search(loc_domain)
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeDaysToOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _compute_days_to_order(self):
            // res = super()._compute_days_to_order()
            // # Avoid computing rule_ids in case no manufacture rules.
            // if not self.env['stock.rule'].search([('action', '=', 'manufacture')]):
            //     return res
            // # Compute rule_ids only for orderpoint with boms
            // orderpoints_with_bom = self.filtered(lambda orderpoint: orderpoint.product_id.variant_bom_ids or orderpoint.product_id.bom_ids)
            // for orderpoint in orderpoints_with_bom:
            //     if 'manufacture' in orderpoint.rule_ids.mapped('action'):
            //         boms = (orderpoint.product_id.variant_bom_ids or orderpoint.product_id.bom_ids)
            //         orderpoint.days_to_order = boms and boms[0].days_to_prepare_mo or 0
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_days_to_order(self):
            // res = super()._compute_days_to_order()
            // # Avoid computing rule_ids if no stock.rules with the buy action
            // if not self.env['stock.rule'].search([('action', '=', 'buy')]):
            //     return res
            // # Compute rule_ids only for orderpoint whose compnay_id.days_to_purchase != orderpoint.days_to_order
            // orderpoints_to_compute = self.filtered(lambda orderpoint: orderpoint.days_to_order != orderpoint.company_id.days_to_purchase)
            // for orderpoint in orderpoints_to_compute:
            //     if 'buy' in orderpoint.rule_ids.mapped('action'):
            //         orderpoint.days_to_order = orderpoint.company_id.days_to_purchase
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_days_to_order(self):
            // self.days_to_order = 0
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeLeadDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_lead_days(self):
            // return super()._compute_lead_days()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_lead_days(self):
            // orderpoints_to_compute = self.filtered(lambda orderpoint: orderpoint.product_id and orderpoint.location_id)
            // for orderpoint in orderpoints_to_compute.with_context(bypass_delay_description=True):
            //     values = orderpoint._get_lead_days_values()
            //     lead_days, dummy = orderpoint.rule_ids._get_lead_days(orderpoint.product_id, **values)
            //     lead_days_date = fields.Date.today() + relativedelta.relativedelta(days=lead_days['total_delay'])
            //     orderpoint.lead_days_date = lead_days_date
            // (self - orderpoints_to_compute).lead_days_date = False
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_location_id(self):
            // """ Finds location id for changed warehouse. """
            // for orderpoint in self:
            //     warehouse = orderpoint.warehouse_id
            //     if not warehouse:
            //         warehouse = orderpoint.env['stock.warehouse'].search([
            //             ('company_id', '=', orderpoint.company_id.id)
            //         ], limit=1)
            //     orderpoint.location_id = warehouse.lot_stock_id.id
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeProductMaxQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_product_max_qty(self):
            // for orderpoint in self:
            //     if orderpoint.product_max_qty < orderpoint.product_min_qty or not orderpoint.product_max_qty:
            //         orderpoint.product_max_qty = orderpoint.product_min_qty
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeProductMinQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_product_min_qty(self):
            // for orderpoint in self:
            //     if orderpoint.product_max_qty < orderpoint.product_min_qty or not orderpoint.product_min_qty:
            //         orderpoint.product_min_qty = orderpoint.product_max_qty
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeProductSupplierIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_product_supplier_id(self):
            // for orderpoint in self:
            //     orderpoint.product_supplier_id = orderpoint.product_tmpl_id.seller_ids.sorted('sequence')[:1].partner_id.id
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_qty(self):
            // """ Extend to add more depends values """
            // return super()._compute_qty()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_qty(self):
            // orderpoints_contexts = defaultdict(lambda: self.env['stock.warehouse.orderpoint'])
            // for orderpoint in self:
            //     if not orderpoint.product_id or not orderpoint.location_id:
            //         orderpoint.qty_on_hand = False
            //         orderpoint.qty_forecast = False
            //         continue
            //     orderpoint_context = orderpoint._get_product_context()
            //     product_context = frozendict({**orderpoint_context})
            //     orderpoints_contexts[product_context] |= orderpoint
            // for orderpoint_context, orderpoints_by_context in orderpoints_contexts.items():
            //     products_qty = {
            //         p['id']: p for p in orderpoints_by_context.product_id.with_context(orderpoint_context).read(['qty_available', 'virtual_available'])
            //     }
            //     products_qty_in_progress = orderpoints_by_context._quantity_in_progress()
            //     for orderpoint in orderpoints_by_context:
            //         orderpoint.qty_on_hand = products_qty[orderpoint.product_id.id]['qty_available']
            //         orderpoint.qty_forecast = products_qty[orderpoint.product_id.id]['virtual_available'] + products_qty_in_progress[orderpoint.id]
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyToOrderComputedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_qty_to_order_computed(self):
            // def to_compute(orderpoint):
            //     rounding = orderpoint.product_uom.rounding
            //     # The check is on purpose. We only want to consider the visibility days if the forecast is negative and
            //     # there is a already something to ressuply base on lead times.
            //     return (
            //         orderpoint.id
            //         and float_compare(orderpoint.qty_forecast, orderpoint.product_min_qty, precision_rounding=rounding) < 0
            //     )
            // 
            // orderpoints = self.filtered(to_compute)
            // qty_in_progress_by_orderpoint = orderpoints._quantity_in_progress()
            // for orderpoint in orderpoints:
            //     orderpoint.qty_to_order_computed = orderpoint._get_qty_to_order(qty_in_progress_by_orderpoint=qty_in_progress_by_orderpoint)
            // (self - orderpoints).qty_to_order_computed = False
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyToOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_qty_to_order(self):
            // for orderpoint in self:
            //     orderpoint.qty_to_order = orderpoint.qty_to_order_manual if orderpoint.qty_to_order_manual else orderpoint.qty_to_order_computed
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_rules(self):
            // orderpoints_to_compute = self.filtered(lambda orderpoint: orderpoint.product_id and orderpoint.location_id)
            // # Small cache mapping (location_id, route_id, product_id.route_ids | product_id.categ_id.total_route_ids) -> stock.rule.
            // # This reduces calls to _get_rules_from_location for products without routes and products with the same routes.
            // rules_cache = {}
            // for orderpoint in orderpoints_to_compute:
            //     cache_key = (orderpoint.location_id, orderpoint.route_id, orderpoint.product_id.route_ids | orderpoint.product_id.categ_id.total_route_ids)
            //     rule_ids = rules_cache.get(cache_key) or orderpoint.product_id._get_rules_from_location(
            //         orderpoint.location_id, route_ids=orderpoint.route_id
            //     )
            //     orderpoint.rule_ids = rule_ids
            //     rules_cache[cache_key] = rule_ids
            // (self - orderpoints_to_compute).rule_ids = False
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeShowBomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _compute_show_bom(self):
            // manufacture_route = []
            // for res in self.env['stock.rule'].search_read([('action', '=', 'manufacture')], ['route_id']):
            //     manufacture_route.append(res['route_id'][0])
            // for orderpoint in self:
            //     orderpoint.show_bom = orderpoint.route_id.id in manufacture_route
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeShowSuppplierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_show_suppplier(self):
            // buy_route = []
            // for res in self.env['stock.rule'].search_read([('action', '=', 'buy')], ['route_id']):
            //     buy_route.append(res['route_id'][0])
            // for orderpoint in self:
            //     orderpoint.show_supplier = orderpoint.route_id.id in buy_route
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeUnwantedReplenishInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_unwanted_replenish(self):
            // for orderpoint in self:
            //     if not orderpoint.product_id or float_is_zero(orderpoint.qty_to_order, precision_rounding=orderpoint.product_uom.rounding) or float_compare(orderpoint.product_max_qty, 0, precision_rounding=orderpoint.product_uom.rounding) == -1:
            //         orderpoint.unwanted_replenish = False
            //     else:
            //         after_replenish_qty = orderpoint.product_id.with_context(company_id=orderpoint.company_id.id, location=orderpoint.location_id.id).virtual_available + orderpoint.qty_to_order
            //         orderpoint.unwanted_replenish = float_compare(after_replenish_qty, orderpoint.product_max_qty, precision_rounding=orderpoint.product_uom.rounding) > 0
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeVisibilityDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _compute_visibility_days(self):
            // res = super()._compute_visibility_days()
            // for orderpoint in self:
            //     if 'manufacture' in orderpoint.rule_ids.mapped('action'):
            //         orderpoint.visibility_days = orderpoint.manufacturing_visibility_days
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_visibility_days(self):
            // res = super()._compute_visibility_days()
            // for orderpoint in self:
            //     if 'buy' in orderpoint.rule_ids.mapped('action'):
            //         orderpoint.visibility_days = orderpoint.purchase_visibility_days
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_visibility_days(self):
            // self.visibility_days = 0
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _compute_warehouse_id(self):
            // for orderpoint in self:
            //     if orderpoint.location_id.warehouse_id:
            //         orderpoint.warehouse_id = orderpoint.location_id.warehouse_id
            //     elif orderpoint.company_id:
            //         orderpoint.warehouse_id = orderpoint.env['stock.warehouse'].search([
            //             ('company_id', '=', orderpoint.company_id.id)
            //         ], limit=1)
            //     if not orderpoint.warehouse_id:
            //         self.env['stock.warehouse']._warehouse_redirect_warning()
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetLeadDaysValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _get_lead_days_values(self):
            // values = super()._get_lead_days_values()
            // if self.supplier_id:
            //     values['supplierinfo'] = self.supplier_id
            // return values
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_lead_days_values(self):
            // self.ensure_one()
            // return {
            //     'days_to_order': self.days_to_order,
            // }
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointActionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_orderpoint_action(self):
            // """Create manual orderpoints for missing product in each warehouses. It also removes
            // orderpoints that have been replenish. In order to do it:
            // - It uses the report.stock.quantity to find missing quantity per product/warehouse
            // - It checks if orderpoint already exist to refill this location.
            // - It checks if it exists other sources (e.g RFQ) tha refill the warehouse.
            // - It creates the orderpoints for missing quantity that were not refill by an upper option.
            // 
            // return replenish report ir.actions.act_window
            // """
            // def is_parent_path_in(resupply_loc, path_dict, record_loc):
            //     return record_loc and resupply_loc.parent_path in path_dict.get(record_loc, '')
            // 
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_orderpoint_replenish")
            // action['context'] = self.env.context
            // # Search also with archived ones to avoid to trigger product_location_check SQL constraints later
            // # It means that when there will be a archived orderpoint on a location + product, the replenishment
            // # report won't take in account this location + product and it won't create any manual orderpoint
            // # In master: the active field should be remove
            // orderpoints = self.env['stock.warehouse.orderpoint'].with_context(active_test=False).search([])
            // # Remove previous automatically created orderpoint that has been refilled.
            // orderpoints_removed = orderpoints._unlink_processed_orderpoints()
            // orderpoints = orderpoints - orderpoints_removed
            // to_refill = defaultdict(float)
            // all_product_ids = self._get_orderpoint_products()
            // all_replenish_location_ids = self._get_orderpoint_locations()
            // ploc_per_day = defaultdict(set)
            // # For each replenish location get products with negative virtual_available aka forecast
            // 
            // 
            // Move = self.env['stock.move'].with_context(active_test=False)
            // Quant = self.env['stock.quant'].with_context(active_test=False)
            // domain_quant, domain_move_in_loc, domain_move_out_loc = all_product_ids._get_domain_locations_new(all_replenish_location_ids.ids)
            // domain_state = [('state', 'in', ('waiting', 'confirmed', 'assigned', 'partially_available'))]
            // domain_product = [['product_id', 'in', all_product_ids.ids]]
            // 
            // domain_quant = expression.AND([domain_product, domain_quant])
            // domain_move_in = expression.AND([domain_product, domain_state, domain_move_in_loc])
            // domain_move_out = expression.AND([domain_product, domain_state, domain_move_out_loc])
            // 
            // moves_in = defaultdict(list)
            // for item in Move._read_group(domain_move_in, ['product_id', 'location_dest_id', 'location_final_id'], ['product_qty:sum']):
            //     moves_in[item[0]].append((item[1], item[2], item[3]))
            // 
            // moves_out = defaultdict(list)
            // for item in Move._read_group(domain_move_out, ['product_id', 'location_id'], ['product_qty:sum']):
            //     moves_out[item[0]].append((item[1], item[2]))
            // 
            // quants = defaultdict(list)
            // for item in Quant._read_group(domain_quant, ['product_id', 'location_id'], ['quantity:sum']):
            //     quants[item[0]].append((item[1], item[2]))
            // 
            // rounding = {product.id: product.uom_id.rounding for product in all_product_ids}
            // path = {loc: loc.parent_path for loc in self.env['stock.location'].with_context(active_test=False).search([('id', 'child_of', all_replenish_location_ids.ids)])}
            // for loc in all_replenish_location_ids:
            //     for product in all_product_ids:
            //         qty_available = sum(q[1] for q in quants.get(product, [(0, 0)]) if is_parent_path_in(loc, path, q[0]))
            //         incoming_qty = sum(m[2] for m in moves_in.get(product, [(0, 0, 0)]) if is_parent_path_in(loc, path, m[0]) or is_parent_path_in(loc, path, m[1]))
            //         outgoing_qty = sum(m[1] for m in moves_out.get(product, [(0, 0)]) if is_parent_path_in(loc, path, m[0]))
            //         if float_compare(qty_available + incoming_qty - outgoing_qty, 0, precision_rounding=rounding[product.id]) < 0:
            //             # group product by lead_days and location in order to read virtual_available
            //             # in batch
            //             rules = product._get_rules_from_location(loc)
            //             lead_days = rules.with_context(bypass_delay_description=True)._get_lead_days(product)[0]['total_delay']
            //             ploc_per_day[(lead_days, loc)].add(product.id)
            // 
            // # recompute virtual_available with lead days
            // today = fields.datetime.now().replace(hour=23, minute=59, second=59)
            // product_ids = set()
            // location_ids = set()
            // for (days, loc), prod_ids in ploc_per_day.items():
            //     products = self.env['product.product'].browse(prod_ids)
            //     qties = products.with_context(
            //         location=loc.id,
            //         to_date=today + relativedelta.relativedelta(days=days)
            //     ).read(['virtual_available'])
            //     for (product, qty) in zip(products, qties):
            //         if float_compare(qty['virtual_available'], 0, precision_rounding=product.uom_id.rounding) < 0:
            //             to_refill[(qty['id'], loc.id)] = qty['virtual_available']
            //             product_ids.add(qty['id'])
            //             location_ids.add(loc.id)
            //     products.invalidate_recordset()
            // if not to_refill:
            //     return action
            // 
            // # Remove incoming quantity from other origin than moves (e.g RFQ)
            // product_ids = list(product_ids)
            // location_ids = list(location_ids)
            // qty_by_product_loc = self.env['product.product'].browse(product_ids)._get_quantity_in_progress(location_ids=location_ids)[0]
            // rounding = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // # Group orderpoint by product-location
            // orderpoint_by_product_location = self.env['stock.warehouse.orderpoint']._read_group(
            //     [('id', 'in', orderpoints.ids), ('product_id', 'in', product_ids)],
            //     ['product_id', 'location_id'],
            //     ['id:recordset'])
            // orderpoint_by_product_location = {
            //     (product.id, location.id): orderpoint.qty_to_order
            //     for product, location, orderpoint in orderpoint_by_product_location
            // }
            // for (product, location), product_qty in to_refill.items():
            //     qty_in_progress = qty_by_product_loc.get((product, location)) or 0.0
            //     qty_in_progress += orderpoint_by_product_location.get((product, location), 0.0)
            //     # Add qty to order for other orderpoint under this location.
            //     if not qty_in_progress:
            //         continue
            //     to_refill[(product, location)] = product_qty + qty_in_progress
            // to_refill = {k: v for k, v in to_refill.items() if float_compare(
            //     v, 0.0, precision_digits=rounding) < 0.0}
            // 
            // # With archived ones to avoid `product_location_check` SQL constraints
            // orderpoint_by_product_location = self.env['stock.warehouse.orderpoint'].with_context(active_test=False)._read_group(
            //     [('id', 'in', orderpoints.ids), ('product_id', 'in', product_ids)],
            //     ['product_id', 'location_id'],
            //     ['id:recordset'])
            // orderpoint_by_product_location = {
            //     (product.id, location.id): orderpoint
            //     for product, location, orderpoint in orderpoint_by_product_location
            // }
            // 
            // orderpoint_values_list = []
            // for (product, location_id), product_qty in to_refill.items():
            //     orderpoint = orderpoint_by_product_location.get((product, location_id))
            //     if orderpoint:
            //         orderpoint.qty_forecast += product_qty
            //     else:
            //         orderpoint_values = self.env['stock.warehouse.orderpoint']._get_orderpoint_values(product, location_id)
            //         location = self.env['stock.location'].browse(location_id)
            //         orderpoint_values.update({
            //             'name': _('Replenishment Report'),
            //             'warehouse_id': location.warehouse_id.id or self.env['stock.warehouse'].search([('company_id', '=', location.company_id.id)], limit=1).id,
            //             'company_id': location.company_id.id,
            //         })
            //         orderpoint_values_list.append(orderpoint_values)
            // 
            // orderpoints = self.env['stock.warehouse.orderpoint'].with_user(SUPERUSER_ID).create(orderpoint_values_list)
            // for orderpoint in orderpoints:
            //     orderpoint._set_default_route_id()
            //     orderpoint.qty_multiple = orderpoint._get_qty_multiple_to_order()
            // return action
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_orderpoint_locations(self):
            // return self.env['stock.location'].search([('replenish_location', '=', True)])
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointProcurementDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_orderpoint_procurement_date(self):
            // return timezone(self.company_id.partner_id.tz or 'UTC').localize(datetime.combine(self.lead_days_date, time(12))).astimezone(UTC).replace(tzinfo=None)
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_orderpoint_products(self):
            // non_kit_ids = []
            // for products in split_every(2000, super()._get_orderpoint_products().ids, self.env['product.product'].browse):
            //     kit_ids = set(k.id for k in self.env['mrp.bom']._bom_find(products, bom_type='phantom').keys())
            //     non_kit_ids.extend(id_ for id_ in products.ids if id_ not in kit_ids)
            //     products.invalidate_recordset()
            // return self.env['product.product'].browse(non_kit_ids)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_orderpoint_products(self):
            // return self.env['product.product'].search([('is_storable', '=', True), ('stock_move_ids', '!=', False)])
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointValuesInternalAsync(object product, object location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_orderpoint_values(self, product, location):
            // return {
            //     'product_id': product,
            //     'location_id': location,
            //     'product_max_qty': 0.0,
            //     'product_min_qty': 0.0,
            //     'trigger': 'manual',
            // }
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetProductContextInternalAsync(object visibility_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_product_context(self, visibility_days=0):
            // """Used to call `virtual_available` when running an orderpoint."""
            // self.ensure_one()
            // return {
            //     'location': self.location_id.id,
            //     'to_date': datetime.combine(self.lead_days_date + relativedelta.relativedelta(days=visibility_days), time.max)
            // }
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetQtyMultipleToOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _get_qty_multiple_to_order(self):
            // """ Calculates the minimum quantity that can be ordered according to the qty and UoM of the BoM
            // """
            // self.ensure_one()
            // qty_multiple_to_order = super()._get_qty_multiple_to_order()
            // if 'manufacture' in self.rule_ids.mapped('action'):
            //     bom = self.env['mrp.bom']._bom_find(self.product_id, bom_type='normal')[self.product_id]
            //     return bom.product_uom_id._compute_quantity(bom.product_qty, self.product_uom)
            // return qty_multiple_to_order
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_qty_multiple_to_order(self):
            // """ Calculates the minimum quantity that can be ordered according to the PO UoM or BoM
            // """
            // self.ensure_one()
            // return 0
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetQtyToOrderInternalAsync(object force_visibility_days, object qty_in_progress_by_orderpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_qty_to_order(self, force_visibility_days=False, qty_in_progress_by_orderpoint=None):
            // self.ensure_one()
            // visibility_days = self.visibility_days
            // if force_visibility_days is not False:
            //     # Accepts falsy values such as 0.
            //     visibility_days = force_visibility_days
            // qty_to_order = 0.0
            // qty_in_progress_by_orderpoint = qty_in_progress_by_orderpoint or {}
            // qty_in_progress = qty_in_progress_by_orderpoint.get(self.id)
            // if qty_in_progress is None:
            //     qty_in_progress = self._quantity_in_progress()[self.id]
            // rounding = self.product_uom.rounding
            // # The check is on purpose. We only want to consider the visibility days if the forecast is negative and
            // # there is a already something to ressuply base on lead times.
            // if float_compare(self.qty_forecast, self.product_min_qty, precision_rounding=rounding) < 0:
            //     product_context = self._get_product_context(visibility_days=visibility_days)
            //     qty_forecast_with_visibility = self.product_id.with_context(product_context).read(['virtual_available'])[0]['virtual_available'] + qty_in_progress
            //     qty_to_order = max(self.product_min_qty, self.product_max_qty) - qty_forecast_with_visibility
            //     remainder = (self.qty_multiple > 0.0 and qty_to_order % self.qty_multiple) or 0.0
            //     if (float_compare(remainder, 0.0, precision_rounding=rounding) > 0
            //             and float_compare(self.qty_multiple - remainder, 0.0, precision_rounding=rounding) > 0):
            //         if float_is_zero(self.product_max_qty, precision_rounding=rounding):
            //             qty_to_order += self.qty_multiple - remainder
            //         else:
            //             qty_to_order -= remainder
            // return qty_to_order
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetReplenishmentOrderNotificationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _get_replenishment_order_notification(self):
            // self.ensure_one()
            // domain = [('orderpoint_id', 'in', self.ids)]
            // if self.env.context.get('written_after'):
            //     domain = AND([domain, [('write_date', '>=', self.env.context.get('written_after'))]])
            // production = self.env['mrp.production'].search(domain, limit=1)
            // if production:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'title': _('The following replenishment order has been generated'),
            //             'message': '%s',
            //             'links': [{
            //                 'label': production.name,
            //                 'url': f'/odoo/action-mrp.action_mrp_production_form/{production.id}'
            //             }],
            //             'sticky': False,
            //             'next': {'type': 'ir.actions.act_window_close'},
            //         }
            //     }
            // return super()._get_replenishment_order_notification()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _get_replenishment_order_notification(self):
            // self.ensure_one()
            // domain = [('orderpoint_id', 'in', self.ids)]
            // if self.env.context.get('written_after'):
            //     domain = AND([domain, [('write_date', '>=', self.env.context.get('written_after'))]])
            // order = self.env['purchase.order.line'].search(domain, limit=1).order_id
            // if order:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'title': _('The following replenishment order has been generated'),
            //             'message': '%s',
            //             'links': [{
            //                 'label': order.display_name,
            //                 'url': f'/odoo/action-purchase.action_rfq_form/{order.id}',
            //             }],
            //             'sticky': False,
            //             'next': {'type': 'ir.actions.act_window_close'},
            //         }
            //     }
            // return super()._get_replenishment_order_notification()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _get_replenishment_order_notification(self):
            // self.ensure_one()
            // domain = [('orderpoint_id', 'in', self.ids)]
            // if self.env.context.get('written_after'):
            //     domain = expression.AND([domain, [('write_date', '>=', self.env.context.get('written_after'))]])
            // move = self.env['stock.move'].search(domain, limit=1)
            // if ((move.location_id.warehouse_id and move.location_id.warehouse_id != self.warehouse_id)
            //     or move.location_id.usage == 'transit') and move.picking_id:
            //     action = self.env.ref('stock.stock_picking_action_picking_type')
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'title': _('The inter-warehouse transfers have been generated'),
            //             'message': '%s',
            //             'links': [{
            //                 'label': move.picking_id.name,
            //                 'url': f'/odoo/action-stock.stock_picking_action_picking_type/{move.picking_id.id}'
            //             }],
            //             'sticky': False,
            //             'next': {'type': 'ir.actions.act_window_close'},
            //         }
            //     }
            // return False
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> GetVisibilityDaysAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def get_visibility_days(self):
            // return self.env['ir.config_parameter'].sudo().get_param('stock.visibility_days', 0)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> InverseQtyToOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _inverse_qty_to_order(self):
            // for orderpoint in self:
            //     if orderpoint.trigger == 'auto':
            //         orderpoint.qty_to_order_manual = 0
            //     elif not orderpoint.qty_to_order_manual and not orderpoint.qty_to_order:
            //         orderpoint.qty_to_order = orderpoint.qty_to_order_computed
            //     elif orderpoint.qty_to_order != orderpoint.qty_to_order_computed:
            //         orderpoint.qty_to_order_manual = orderpoint.qty_to_order
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> OnchangeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _onchange_product_id(self):
            // if self.product_id:
            //     self.product_uom = self.product_id.uom_id.id
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> OnchangeRouteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _onchange_route_id(self):
            // if self.route_id:
            //     self.qty_multiple = self._get_qty_multiple_to_order()
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> OpenOrderpointsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_open_orderpoints(self):
            // return self._get_orderpoint_action()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> PostProcessSchedulerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _post_process_scheduler(self):
            // """ Confirm the productions only after all the orderpoints have run their
            // procurement to avoid the new procurement created from the production conflict
            // with them. """
            // self.env['mrp.production'].sudo().search([
            //     ('orderpoint_id', 'in', self.ids),
            //     ('move_raw_ids', '!=', False),
            //     ('state', '=', 'draft'),
            // ]).action_confirm()
            // return super()._post_process_scheduler()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _post_process_scheduler(self):
            // return True
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> PrepareProcurementValuesInternalAsync(object date, object @group)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _prepare_procurement_values(self, date=False, group=False):
            // values = super()._prepare_procurement_values(date=date, group=group)
            // values['bom_id'] = self.bom_id
            // return values
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_orderpoint.py) ---
            // def _prepare_procurement_values(self, date=False, group=False):
            // vals = super()._prepare_procurement_values(date, group)
            // if not vals.get('partner_id') and self.location_id.is_subcontracting_location and len(self.location_id.subcontractor_ids) == 1:
            //     vals['partner_id'] = self.location_id.subcontractor_ids.id
            // return vals
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _prepare_procurement_values(self, date=False, group=False):
            // values = super()._prepare_procurement_values(date=date, group=group)
            // values['supplierinfo_id'] = self.supplier_id
            // return values
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _prepare_procurement_values(self, date=False, group=False):
            // """ Prepare specific key for moves or other components that will be created from a stock rule
            // comming from an orderpoint. This method could be override in order to add other custom key that could
            // be used in move/po creation.
            // """
            // date_deadline = date or fields.Date.today()
            // dates_info = self.product_id._get_dates_info(date_deadline, self.location_id, route_ids=self.route_id)
            // return {
            //     'route_ids': self.route_id,
            //     'date_planned': dates_info['date_planned'],
            //     'date_order': dates_info['date_order'],
            //     'date_deadline': date or False,
            //     'warehouse_id': self.warehouse_id,
            //     'orderpoint_id': self,
            //     'group_id': group or self.group_id,
            // }
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ProcureOrderpointConfirmInternalAsync(object use_new_cursor, Guid company_id, object raise_user_error)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _procure_orderpoint_confirm(self, use_new_cursor=False, company_id=None, raise_user_error=True):
            // """ Create procurements based on orderpoints.
            // :param bool use_new_cursor: if set, use a dedicated cursor and auto-commit after processing
            //     1000 orderpoints.
            //     This is appropriate for batch jobs only.
            // """
            // self = self.with_company(company_id)
            // 
            // for orderpoints_batch_ids in split_every(1000, self.ids):
            //     if use_new_cursor:
            //         assert isinstance(self._cr, BaseCursor)
            //         cr = Registry(self._cr.dbname).cursor()
            //         self = self.with_env(self.env(cr=cr))
            //     try:
            //         orderpoints_batch = self.env['stock.warehouse.orderpoint'].browse(orderpoints_batch_ids)
            //         all_orderpoints_exceptions = []
            //         while orderpoints_batch:
            //             procurements = []
            //             for orderpoint in orderpoints_batch:
            //                 origins = orderpoint.env.context.get('origins', {}).get(orderpoint.id, False)
            //                 if origins:
            //                     origin = '%s - %s' % (orderpoint.display_name, ','.join(origins))
            //                 else:
            //                     origin = orderpoint.name
            //                 if float_compare(orderpoint.qty_to_order, 0.0, precision_rounding=orderpoint.product_uom.rounding) == 1:
            //                     date = orderpoint._get_orderpoint_procurement_date()
            //                     global_visibility_days = self.env.context.get('global_visibility_days', self.env['ir.config_parameter'].sudo().get_param('stock.visibility_days', 0))
            //                     if global_visibility_days:
            //                         date -= relativedelta.relativedelta(days=int(global_visibility_days))
            //                     values = orderpoint._prepare_procurement_values(date=date)
            //                     procurements.append(self.env['procurement.group'].Procurement(
            //                         orderpoint.product_id, orderpoint.qty_to_order, orderpoint.product_uom,
            //                         orderpoint.location_id, orderpoint.name, origin,
            //                         orderpoint.company_id, values))
            // 
            //             try:
            //                 with self.env.cr.savepoint():
            //                     self.env['procurement.group'].with_context(from_orderpoint=True).run(procurements, raise_user_error=raise_user_error)
            //             except ProcurementException as errors:
            //                 orderpoints_exceptions = []
            //                 for procurement, error_msg in errors.procurement_exceptions:
            //                     orderpoints_exceptions += [(procurement.values.get('orderpoint_id'), error_msg)]
            //                 all_orderpoints_exceptions += orderpoints_exceptions
            //                 failed_orderpoints = self.env['stock.warehouse.orderpoint'].concat(*[o[0] for o in orderpoints_exceptions])
            //                 if not failed_orderpoints:
            //                     _logger.error('Unable to process orderpoints')
            //                     break
            //                 orderpoints_batch -= failed_orderpoints
            // 
            //             except OperationalError:
            //                 if use_new_cursor:
            //                     cr.rollback()
            //                     continue
            //                 else:
            //                     raise
            //             else:
            //                 orderpoints_batch._post_process_scheduler()
            //                 break
            // 
            //         # Log an activity on product template for failed orderpoints.
            //         for orderpoint, error_msg in all_orderpoints_exceptions:
            //             existing_activity = self.env['mail.activity'].search([
            //                 ('res_id', '=', orderpoint.product_id.product_tmpl_id.id),
            //                 ('res_model_id', '=', self.env.ref('product.model_product_template').id),
            //                 ('note', '=', error_msg)])
            //             if not existing_activity:
            //                 orderpoint.product_id.product_tmpl_id.sudo().activity_schedule(
            //                     'mail.mail_activity_data_warning',
            //                     note=error_msg,
            //                     user_id=orderpoint.product_id.responsible_id.id or SUPERUSER_ID,
            //                 )
            // 
            //     finally:
            //         if use_new_cursor:
            //             try:
            //                 cr.commit()
            //             finally:
            //                 cr.close()
            //             _logger.info("A batch of %d orderpoints is processed and committed", len(orderpoints_batch_ids))
            // 
            // return {}
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> ProductForecastReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_product_forecast_report(self):
            // self.ensure_one()
            // action = self.product_id.action_product_forecast_report()
            // action['context'] = {
            //     'active_id': self.product_id.id,
            //     'active_model': 'product.product',
            //     'lead_days_date': format_date(self.env, self.lead_days_date),
            //     'qty_to_order': self._get_qty_to_order(force_visibility_days=0),
            //     'visibility_days_date': format_date(self.env, fields.Date.add(self.lead_days_date, days=int(self.visibility_days))),
            //     'qty_to_order_with_visibility_days': self.qty_to_order_computed,
            // }
            // warehouse = self.warehouse_id
            // if warehouse:
            //     action['context']['warehouse_id'] = warehouse.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> QuantityInProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _quantity_in_progress(self):
            // bom_kits = self.env['mrp.bom']._bom_find(self.product_id, bom_type='phantom')
            // bom_kit_orderpoints = {
            //     orderpoint: bom_kits[orderpoint.product_id]
            //     for orderpoint in self
            //     if orderpoint.product_id in bom_kits
            // }
            // orderpoints_without_kit = self - self.env['stock.warehouse.orderpoint'].concat(*bom_kit_orderpoints.keys())
            // res = super(StockWarehouseOrderpoint, orderpoints_without_kit)._quantity_in_progress()
            // for orderpoint in bom_kit_orderpoints:
            //     dummy, bom_sub_lines = bom_kit_orderpoints[orderpoint].explode(orderpoint.product_id, 1)
            //     ratios_qty_available = []
            //     # total = qty_available + in_progress
            //     ratios_total = []
            //     for bom_line, bom_line_data in bom_sub_lines:
            //         component = bom_line.product_id
            //         if not component.is_storable or float_is_zero(bom_line_data['qty'], precision_rounding=bom_line.product_uom_id.rounding):
            //             continue
            //         uom_qty_per_kit = bom_line_data['qty'] / bom_line_data['original_qty']
            //         qty_per_kit = bom_line.product_uom_id._compute_quantity(uom_qty_per_kit, bom_line.product_id.uom_id, raise_if_failure=False)
            //         if not qty_per_kit:
            //             continue
            //         qty_by_product_location, dummy = component._get_quantity_in_progress(orderpoint.location_id.ids)
            //         qty_in_progress = qty_by_product_location.get((component.id, orderpoint.location_id.id), 0.0)
            //         qty_available = component.qty_available / qty_per_kit
            //         ratios_qty_available.append(qty_available)
            //         ratios_total.append(qty_available + (qty_in_progress / qty_per_kit))
            //     # For a kit, the quantity in progress is :
            //     #  (the quantity if we have received all in-progress components) - (the quantity using only available components)
            //     product_qty = min(ratios_total or [0]) - min(ratios_qty_available or [0])
            //     res[orderpoint.id] = orderpoint.product_id.uom_id._compute_quantity(product_qty, orderpoint.product_uom, round=False)
            // 
            // bom_manufacture = self.env['mrp.bom']._bom_find(orderpoints_without_kit.product_id, bom_type='normal')
            // bom_manufacture = self.env['mrp.bom'].concat(*bom_manufacture.values())
            // # add quantities coming from draft MOs
            // productions_group = self.env['mrp.production']._read_group(
            //     [
            //         ('bom_id', 'in', bom_manufacture.ids),
            //         ('state', '=', 'draft'),
            //         ('orderpoint_id', 'in', orderpoints_without_kit.ids),
            //         ('id', 'not in', self.env.context.get('ignore_mo_ids', [])),
            //     ],
            //     ['orderpoint_id', 'product_uom_id'],
            //     ['product_qty:sum'])
            // for orderpoint, uom, product_qty_sum in productions_group:
            //     res[orderpoint.id] += uom._compute_quantity(
            //         product_qty_sum, orderpoint.product_uom, round=False)
            // 
            // # add quantities coming from confirmed MO to be started but not finished
            // # by the end of the stock forecast
            // in_progress_productions = self.env['mrp.production'].search([
            //     ('bom_id', 'in', bom_manufacture.ids),
            //     ('state', '=', 'confirmed'),
            //     ('orderpoint_id', 'in', orderpoints_without_kit.ids),
            //     ('id', 'not in', self.env.context.get('ignore_mo_ids', [])),
            // ])
            // for prod in in_progress_productions:
            //     date_start, date_finished, orderpoint = prod.date_start, prod.date_finished, prod.orderpoint_id
            //     lead_days_date = datetime.combine(orderpoint.lead_days_date, time.max)
            //     if date_start <= lead_days_date < date_finished:
            //         res[orderpoint.id] += prod.product_uom_id._compute_quantity(
            //                 prod.product_qty, orderpoint.product_uom, round=False)
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _quantity_in_progress(self):
            // res = super()._quantity_in_progress()
            // qty_by_product_location, dummy = self.product_id._get_quantity_in_progress(self.location_id.ids)
            // for orderpoint in self:
            //     product_qty = qty_by_product_location.get((orderpoint.product_id.id, orderpoint.location_id.id), 0.0)
            //     product_uom_qty = orderpoint.product_id.uom_id._compute_quantity(product_qty, orderpoint.product_uom, round=False)
            //     res[orderpoint.id] += product_uom_qty
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _quantity_in_progress(self):
            // """Return Quantities that are not yet in virtual stock but should be deduced from orderpoint rule
            // (example: purchases created from orderpoints)"""
            // return dict(self.mapped(lambda x: (x.id, 0.0)))
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> RemoveManualQtyToOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_remove_manual_qty_to_order(self):
            // self.qty_to_order_manual = 0
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockWarehouseOrderpoint> ReplenishAsync(Guid id, StockWarehouseOrderpointReplenishRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_replenish(self, force_to_max=False):
            // now = self.env.cr.now()
            // if force_to_max:
            //     for orderpoint in self:
            //         orderpoint.qty_to_order = orderpoint.product_max_qty - orderpoint.qty_forecast
            //         remainder = orderpoint.qty_multiple > 0 and orderpoint.qty_to_order % orderpoint.qty_multiple or 0.0
            //         if not float_is_zero(remainder, precision_rounding=orderpoint.product_uom.rounding):
            //             orderpoint.qty_to_order += orderpoint.qty_multiple - remainder
            // try:
            //     self._procure_orderpoint_confirm(company_id=self.env.company)
            // except UserError as e:
            //     if len(self) != 1:
            //         raise e
            //     raise RedirectWarning(e, {
            //         'name': self.product_id.display_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'product.product',
            //         'res_id': self.product_id.id,
            //         'views': [(self.env.ref('product.product_normal_form_view').id, 'form')],
            //     }, _('Edit Product'))
            // notification = False
            // if len(self) == 1:
            //     notification = self.with_context(written_after=now)._get_replenishment_order_notification()
            // # Forced to call compute quantity because we don't have a link.
            // self.action_remove_manual_qty_to_order()
            // self._compute_qty_to_order()
            // self.filtered(lambda o: o.create_uid.id == SUPERUSER_ID and o.qty_to_order <= 0.0 and o.trigger == 'manual').unlink()
            // return notification
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockWarehouseOrderpoint> ReplenishAutoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_replenish_auto(self):
            // self.trigger = 'auto'
            // return self.action_replenish()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> SearchQtyToOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _search_qty_to_order(self, operator, value):
            // records = self.search_fetch([('qty_to_order_manual', 'in', [0, False])], ['qty_to_order_computed'])
            // matched_ids = records.filtered_domain([('qty_to_order_computed', operator, value)]).ids
            // return ['|',
            //             ('qty_to_order_manual', operator, value),
            //             ('id', 'in', matched_ids)
            //         ]
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SetDefaultRouteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _set_default_route_id(self):
            // route_ids = self.env['stock.rule'].search([
            //     ('action', '=', 'manufacture')
            // ]).route_id
            // for orderpoint in self:
            //     if not orderpoint.product_id.bom_ids:
            //         continue
            //     route_id = orderpoint.rule_ids.route_id & route_ids
            //     if not route_id:
            //         continue
            //     orderpoint.route_id = route_id[0].id
            // return super()._set_default_route_id()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _set_default_route_id(self):
            // route_ids = self.env['stock.rule'].search([
            //     ('action', '=', 'buy')
            // ]).route_id
            // for orderpoint in self:
            //     route_id = orderpoint.rule_ids.route_id & route_ids
            //     if not orderpoint.product_id.seller_ids:
            //         continue
            //     if not route_id:
            //         continue
            //     orderpoint.route_id = route_id[0].id
            // return super()._set_default_route_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _set_default_route_id(self):
            // """ Write the `route_id` field on `self`. This method is intendend to be called on the
            // orderpoints generated when openning the replenish report.
            // """
            // self = self.filtered(lambda o: not o.route_id)
            // rules_groups = self.env['stock.rule']._read_group([
            //     '|', ('route_id.product_selectable', '!=', False),
            //     ('route_id.product_categ_selectable', '!=', False),
            //     ('location_dest_id', 'in', self.location_id.ids),
            //     ('action', 'in', ['pull_push', 'pull']),
            //     ('route_id.active', '!=', False)
            // ], ['location_dest_id', 'route_id'])
            // for location_dest, route in rules_groups:
            //     orderpoints = self.filtered(lambda o: not o.route_id and route in (o.product_id.route_ids | o.product_id.categ_id.route_ids) and o.location_id.id == location_dest.id)
            //     orderpoints.route_id = route
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SetVisibilityDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py) ---
            // def _set_visibility_days(self):
            // res = super()._set_visibility_days()
            // for orderpoint in self:
            //     if 'manufacture' in orderpoint.rule_ids.mapped('action'):
            //         orderpoint.manufacturing_visibility_days = orderpoint.visibility_days
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _set_visibility_days(self):
            // res = super()._set_visibility_days()
            // for orderpoint in self:
            //     if 'buy' in orderpoint.rule_ids.mapped('action'):
            //         orderpoint.purchase_visibility_days = orderpoint.visibility_days
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _set_visibility_days(self):
            // return True
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> StockReplenishmentInfoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def action_stock_replenishment_info(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('stock.action_stock_replenishment_info')
            // action['name'] = _(
            //     'Replenishment Information for %(product)s in %(warehouse)s',
            //     product=self.product_id.display_name,
            //     warehouse=self.warehouse_id.display_name,
            // )
            // res = self.env['stock.replenishment.info'].create({
            //     'orderpoint_id': self.id,
            // })
            // action['res_id'] = res.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouseOrderpoint> UnlinkProcessedOrderpointsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py) ---
            // def _unlink_processed_orderpoints(self):
            // domain = [
            //     ('create_uid', '=', SUPERUSER_ID),
            //     ('trigger', '=', 'manual'),
            // ]
            // if self.ids:
            //     expression.AND([domain, [('ids', 'in', self.ids)]])
            // manual_orderpoints = self.env['stock.warehouse.orderpoint'].with_context(active_test=False).search(domain)
            // orderpoints_to_remove = manual_orderpoints.filtered(lambda o: o.qty_to_order <= 0.0)
            // # Remove previous automatically created orderpoint that has been refilled.
            // orderpoints_to_remove.unlink()
            // return orderpoints_to_remove
            */
            return default;
        }

        public async Task<StockWarehouseOrderpoint> ViewPurchaseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def action_view_purchase(self):
            // """ This function returns an action that display existing
            // purchase orders of given orderpoint.
            // """
            // result = self.env['ir.actions.act_window']._for_xml_id('purchase.purchase_rfq')
            // 
            // # Remvove the context since the action basically display RFQ and not PO.
            // result['context'] = {}
            // order_line_ids = self.env['purchase.order.line'].search([('orderpoint_id', '=', self.id)])
            // purchase_ids = order_line_ids.mapped('order_id')
            // 
            // result['domain'] = "[('id','in',%s)]" % (purchase_ids.ids)
            // 
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}