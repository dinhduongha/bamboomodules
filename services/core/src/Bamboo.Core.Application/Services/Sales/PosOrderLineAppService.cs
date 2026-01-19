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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosOrderLineAppService : GenericApplicationService<PosOrderLine>, IPosOrderLineAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosOrderLineAppService(IRepository<PosOrderLine, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<PosOrderLine> ComputeAmountLineAllInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_amount_line_all(self):
            // self.ensure_one()
            // fpos = self.order_id.fiscal_position_id
            // tax_ids_after_fiscal_position = fpos.map_tax(self.tax_ids)
            // price = self.price_unit * (1 - (self.discount or 0.0) / 100.0)
            // taxes = tax_ids_after_fiscal_position.compute_all(price, self.order_id.currency_id, self.qty, product=self.product_id, partner=self.order_id.partner_id)
            // return {
            //     'price_subtotal_incl': taxes['total_included'],
            //     'price_subtotal': taxes['total_excluded'],
            // }
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeMarginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_margin(self):
            // for line in self:
            //     sign = -1 if line.order_id.is_refund else 1
            //     if line.product_id.type == 'combo':
            //         line.margin = 0
            //         line.margin_percent = 0
            //     else:
            //         line.margin = (line.price_subtotal * sign) - line.total_cost
            //         line.margin_percent = not float_is_zero(line.price_subtotal, precision_rounding=line.currency_id.rounding) \
            //                                 and line.margin / (line.price_subtotal * sign) \
            //                                 or 0
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeQtyDeliveredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _compute_qty_delivered(self):
            // product_qty_left_to_assign = {}
            // for order_line in self:
            //     if order_line.order_id.state in ['paid', 'done']:
            //         outgoing_pickings = order_line.order_id.picking_ids.filtered(
            //             lambda pick: pick.state == 'done' and pick.picking_type_code == 'outgoing'
            //         )
            // 
            //         if outgoing_pickings and order_line.order_id.shipping_date:
            //             moves = outgoing_pickings.move_ids.filtered(
            //                 lambda m: m.state == 'done' and m.product_id == order_line.product_id
            //             )
            //             qty_left = product_qty_left_to_assign.get(order_line.product_id.id, False)
            //             if (qty_left):
            //                 order_line.qty_delivered = min(order_line.qty, qty_left)
            //                 product_qty_left_to_assign[order_line.product_id.id] -= order_line.qty_delivered
            //             else:
            //                 order_line.qty_delivered = min(order_line.qty, sum(moves.mapped('quantity')))
            //                 product_qty_left_to_assign[order_line.product_id.id] = sum(moves.mapped('quantity')) - order_line.qty_delivered
            // 
            //         elif outgoing_pickings:
            //             # If the order is not delivered later, and in a "paid", "done" or "invoiced" state, it fully delivered
            //             order_line.qty_delivered = order_line.qty
            //         else:
            //             order_line.qty_delivered = 0
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeRefundQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_refund_qty(self):
            // for orderline in self:
            //     refund_order_line = orderline.refund_orderline_ids.filtered(lambda l: l.order_id.state != 'cancel')
            //     orderline.refunded_qty = -sum(refund_order_line.mapped('qty'))
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeTotalCostInternalAsync(object stock_moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_total_cost(self, stock_moves):
            // """
            // Compute the total cost of the order lines.
            // :param stock_moves: recordset of `stock.move`, used for fifo/avco lines
            // """
            // for line in self.filtered(lambda l: not l.is_total_cost_computed):
            //     product = line.product_id
            //     cost_currency = product.sudo().cost_currency_id
            //     if line._is_product_storable_fifo_avco() and stock_moves:
            //         moves = line._get_stock_moves_to_consider(stock_moves, product)
            //         product_cost = moves._get_price_unit()
            //         if (cost_currency.is_zero(product_cost) and line.order_id.shipping_date and line.refunded_orderline_id):
            //             product_cost = line.refunded_orderline_id.total_cost / line.refunded_orderline_id.qty
            //     else:
            //         product_cost = product.standard_price
            //     line.total_cost = line.qty * cost_currency._convert(
            //         from_amount=product_cost,
            //         to_currency=line.currency_id,
            //         company=line.company_id or self.env.company,
            //         date=line.order_id.date_order or fields.Date.today(),
            //         round=False,
            //     )
            //     line.is_total_cost_computed = True
            */
            return default;
        }

        public override async Task<PosOrderLine> CreateAsync(PosOrderLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     order = self.env['pos.order'].browse(vals['order_id']) if vals.get('order_id') else False
            //     if order and order.exists() and not vals.get('name'):
            //         # set name based on the sequence specified on the config
            //         config = order.session_id.config_id
            //         if config.order_line_seq_id:
            //             vals['name'] = config.order_line_seq_id._next()
            //     if not vals.get('name'):
            //         # fallback on any pos.order sequence
            //         vals['name'] = self.env['ir.sequence'].next_by_code('pos.order.line')
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if (vals.get('combo_parent_uuid')):
            //         vals.update([
            //             ('combo_parent_id', self.search([('uuid', '=', vals.get('combo_parent_uuid'))]).id)
            //         ])
            //     if 'combo_parent_uuid' in vals:
            //         del vals['combo_parent_uuid']
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PosOrderLine> GetDiscountAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_discount_amount(self):
            // self.ensure_one()
            // original_price = self.tax_ids.compute_all(self.price_unit, self.currency_id, self.qty, product=self.product_id, partner=self.order_id.partner_id)['total_included']
            // return original_price - self.price_subtotal_incl
            */
            return default;
        }

        public async Task<PosOrderLine> GetExistingLotsAsync(Guid id, PosOrderLineGetExistingLotsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def get_existing_lots(self, company_id, config_id, product_id):
            // """
            // Return the lots that are still available in the given company.
            // The lot is available if its quantity in the corresponding stock_quant and pos stock location is > 0.
            // """
            // self.check_access('read')
            // pos_config = self.env['pos.config'].browse(config_id)
            // if not pos_config:
            //     raise UserError(_('No PoS configuration found'))
            // 
            // src_loc = pos_config.picking_type_id.default_location_src_id
            // 
            // domain = [
            //     '|',
            //     ('company_id', '=', False),
            //     ('company_id', '=', company_id),
            //     ('product_id', '=', product_id),
            //     ('location_id', 'in', src_loc.child_internal_location_ids.ids),
            //     ('quantity', '>', 0),
            //     ('lot_id', '!=', False),
            // ]
            // 
            // groups = self.sudo().env['stock.quant']._read_group(
            //     domain=domain,
            //     groupby=['lot_id'],
            //     aggregates=['quantity:sum']
            // )
            // 
            // result = []
            // for lot_recordset, total_quantity in groups:
            //     if lot_recordset:
            //         result.append({
            //             'id': lot_recordset.id,
            //             'name': lot_recordset.name,
            //             'product_qty': total_quantity
            //         })
            // 
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrderLine> GetStockMovesToConsiderInternalAsync(object stock_moves, object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_stock_moves_to_consider(self, stock_moves, product):
            // self.ensure_one()
            // return stock_moves.filtered(lambda ml: ml.product_id.id == product.id)
            --- ODOO METHOD SOURCE (MODULE: pos_mrp, FILE: pos_order.py) ---
            // def _get_stock_moves_to_consider(self, stock_moves, product):
            // self.ensure_one()
            // bom = product.env['mrp.bom']._bom_find(product, company_id=stock_moves.company_id.id, bom_type='phantom').get(product)
            // if not bom:
            //     return super()._get_stock_moves_to_consider(stock_moves, product)
            // boms, components = bom.explode(product, self.qty)
            // #Get a flat list of all bom_line_ids
            // bom_line_ids = [item.id for x in boms for item in x[0].bom_line_ids if set(item.bom_product_template_attribute_value_ids.ids).issubset(product.product_template_variant_value_ids.ids)]
            // ml_product_to_consider = (product.bom_ids and [comp[0].product_id.id for comp in components]) or [product.id]
            // return stock_moves.filtered(lambda ml: ml.product_id.id in ml_product_to_consider and (ml.bom_line_id.id in bom_line_ids))
            */
            return default;
        }

        protected async Task<PosOrderLine> GetTaxIdsAfterFiscalPositionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_tax_ids_after_fiscal_position(self):
            // for line in self:
            //     line.tax_ids_after_fiscal_position = line.order_id.fiscal_position_id.map_tax(line.tax_ids)
            */
            return default;
        }

        protected async Task<PosOrderLine> IsFieldAcceptedInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _is_field_accepted(self, field):
            // return field in self._fields and not field in ['combo_parent_id', 'combo_line_ids']
            */
            return default;
        }

        protected async Task<PosOrderLine> IsProductStorableFifoAvcoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _is_product_storable_fifo_avco(self):
            // self.ensure_one()
            // return self.product_id.is_storable and self.product_id.cost_method in ['fifo', 'average']
            */
            return default;
        }

        protected async Task<PosOrderLine> LaunchStockRuleFromPosOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _launch_stock_rule_from_pos_order_lines(self):
            // 
            // procurements = []
            // for line in self:
            //     line = line.with_company(line.company_id)
            //     if line.product_id.type != 'consu':
            //         continue
            // 
            //     reference_ids = line.order_id.stock_reference_ids
            //     if not reference_ids:
            //         reference_ids = self.env['stock.reference'].create(line._prepare_reference_vals())
            //         line.order_id.stock_reference_ids = [Command.set(reference_ids.ids)]
            // 
            //     values = line._prepare_procurement_values()
            //     product_qty = line.qty
            // 
            //     procurement_uom = line.product_id.uom_id
            //     procurements.append(self.env['stock.rule'].Procurement(
            //         line.product_id, product_qty, procurement_uom,
            //         line.order_id.partner_id.property_stock_customer,
            //         line.name, line.order_id.name, line.order_id.company_id, values))
            // if procurements:
            //     self.env['stock.rule'].run(procurements)
            // 
            // # This next block is currently needed only because the scheduler trigger is done by picking confirmation rather than stock.move confirmation
            // orders = self.mapped('order_id')
            // for order in orders:
            //     pickings_to_confirm = order.picking_ids
            //     if pickings_to_confirm:
            //         # Trigger the Scheduler for Pickings
            //         tracked_lines = order.lines.filtered(lambda l: l.product_id.tracking != 'none')
            //         lines_by_tracked_product = groupby(sorted(tracked_lines, key=lambda l: l.product_id.id), key=lambda l: l.product_id.id)
            //         pickings_to_confirm.action_confirm()
            //         for product_id, lines in lines_by_tracked_product:
            //             lines = self.env['pos.order.line'].concat(*lines)
            //             moves = pickings_to_confirm.move_ids.filtered(lambda m: m.product_id.id == product_id)
            //             moves.move_line_ids.unlink()
            //             moves._add_mls_related_to_order(lines, are_qties_done=False)
            //             moves._recompute_state()
            // return True
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _launch_stock_rule_from_pos_order_lines(self):
            // orders = self.mapped('order_id')
            // for order in orders:
            //     self.env['stock.move'].browse(order.lines.sale_order_line_id.move_ids._rollup_move_origs()).filtered(lambda ml: ml.state not in ['cancel', 'done'])._action_cancel()
            // return super()._launch_stock_rule_from_pos_order_lines()
            */
            return default;
        }

        protected async Task<PosOrderLine> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('order_id', 'in', [order['id'] for order in data['pos.order']])]
            */
            return default;
        }

        protected async Task<PosOrderLine> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_fields(self, config):
            // return [
            //     'qty', 'attribute_value_ids', 'custom_attribute_value_ids', 'price_unit',
            //     'uuid', 'price_subtotal', 'price_subtotal_incl', 'order_id', 'note', 'price_type',
            //     'product_id', 'discount', 'tax_ids', 'pack_lot_ids', 'customer_note',
            //     'refunded_qty', 'price_extra', 'full_product_name', 'refunded_orderline_id',
            //     'combo_parent_id', 'combo_line_ids', 'combo_item_id', 'refund_orderline_ids',
            //     'extra_tax_data', 'write_date',
            // ]
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order_line.py) ---
            // def _load_pos_data_fields(self, config):
            // fields = super()._load_pos_data_fields(config)
            // fields += ['event_ticket_id', 'event_registration_ids']
            // return fields
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order_line.py) ---
            // def _load_pos_data_fields(self, config):
            // params = super()._load_pos_data_fields(config)
            // params += ['is_reward_line', 'reward_id', 'reward_identifier_code', 'points_cost', 'coupon_id']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order_line.py) ---
            // def _load_pos_data_fields(self, config):
            // result = super()._load_pos_data_fields(config)
            // return result + ["course_id"]
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _load_pos_data_fields(self, config):
            // params = super()._load_pos_data_fields(config)
            // params += ['sale_order_origin_id', 'sale_order_line_id', 'down_payment_details']
            // return params
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeAmountLineAllInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_amount_line_all(self):
            // for line in self:
            //     res = line._compute_amount_line_all()
            //     line.update(res)
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_product_id(self):
            // if self.product_id:
            //     price = self.order_id.pricelist_id._get_product_price(
            //         self.product_id, self.qty or 1.0, currency=self.currency_id
            //     )
            //     self.tax_ids = self.product_id.taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(self.company_id))
            //     tax_ids_after_fiscal_position = self.order_id.fiscal_position_id.map_tax(self.tax_ids)
            //     self.price_unit = self.env['account.tax']._fix_tax_included_price_company(price, self.tax_ids, tax_ids_after_fiscal_position, self.company_id)
            //     self._onchange_qty()
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_qty(self):
            // if self.product_id:
            //     price = self.price_unit * (1 - (self.discount or 0.0) / 100.0)
            //     self.price_subtotal = self.price_subtotal_incl = price * self.qty
            //     if (self.tax_ids):
            //         taxes = self.tax_ids.compute_all(price, self.order_id.currency_id, self.qty, product=self.product_id, partner=False)
            //         self.price_subtotal = taxes['total_excluded']
            //         self.price_subtotal_incl = taxes['total_included']
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_base_line_for_taxes_computation(self):
            // self.ensure_one()
            // commercial_partner = self.order_id.partner_id.commercial_partner_id
            // fiscal_position = self.order_id.fiscal_position_id
            // line = self.with_company(self.order_id.company_id)
            // account = line.product_id._get_product_accounts()['income'] or self.order_id.config_id.journal_id.default_account_id
            // if not account:
            //     raise UserError(_(
            //         "Please define income account for this product: '%(product)s' (id:%(id)d).",
            //         product=line.product_id.name, id=line.product_id.id,
            //     ))
            // 
            // if fiscal_position:
            //     account = fiscal_position.map_account(account)
            // 
            // is_refund_order = line.order_id.amount_total < 0.0
            // is_refund_line = line.qty * line.price_unit < 0
            // 
            // lang = line.order_id.partner_id.lang or self.env.user.lang
            // product_name = line.with_context(lang=lang).full_product_name or line.product_id.with_context(lang=lang).display_name
            // if line.product_id.description_sale:
            //     product_name += '\n' + line.product_id.with_context(lang=lang).description_sale
            // return {
            //     **self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //         line,
            //         partner_id=commercial_partner,
            //         currency_id=self.order_id.currency_id,
            //         rate=self.order_id.currency_rate,
            //         product_id=line.product_id,
            //         tax_ids=line.tax_ids_after_fiscal_position,
            //         price_unit=line.price_unit,
            //         quantity=line.qty * (-1 if is_refund_order else 1),
            //         discount=line.discount,
            //         account_id=account,
            //         is_refund=is_refund_line,
            //         sign=1 if is_refund_order else -1,
            //     ),
            //     'uom_id': line.product_uom_id,
            //     'name': product_name,
            // }
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareProcurementValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_procurement_values(self):
            // """ Prepare specific key for moves or other components that will be created from a stock rule
            // coming from a sale order line. This method could be override in order to add other custom key that could
            // be used in move/po creation.
            // """
            // self.ensure_one()
            // # Use the delivery date if there is else use date_order and lead time
            // if self.order_id.shipping_date:
            //     # get timezone from user
            //     # and convert to UTC to avoid any timezone issue
            //     # because shipping_date is date and date_planned is datetime
            //     from_zone = self.env.tz
            //     shipping_date = fields.Datetime.to_datetime(self.order_id.shipping_date)
            //     shipping_date = from_zone.localize(shipping_date)
            //     date_deadline = shipping_date.astimezone(pytz.UTC).replace(tzinfo=None)
            // else:
            //     date_deadline = self.order_id.date_order
            // 
            // values = {
            //     'date_planned': date_deadline,
            //     'date_deadline': date_deadline,
            //     'route_ids': self.order_id.config_id.route_id,
            //     'warehouse_id': self.order_id.config_id.warehouse_id or False,
            //     'partner': self.order_id.partner_id,
            //     'product_description_variants': self.full_product_name,
            //     'company_id': self.order_id.company_id,
            //     'reference_ids': self.order_id.stock_reference_ids,
            // }
            // return values
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareReferenceValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_reference_vals(self):
            // return {
            //     'name': self.order_id.name,
            //     'pos_order_ids': [Command.link(self.order_id.id)],
            // }
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareRefundDataInternalAsync(object refund_order, object PosPackOperationLot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_refund_data(self, refund_order, PosPackOperationLot):
            // """
            // This prepares data for refund order line. Inheritance may inject more data here
            // 
            // @param refund_order: the pre-created refund order
            // @type refund_order: pos.order
            // 
            // @param PosPackOperationLot: the pre-created Pack operation Lot
            // @type PosPackOperationLot: pos.pack.operation.lot
            // 
            // @return: dictionary of data which is for creating a refund order line from the original line
            // @rtype: dict
            // """
            // self.ensure_one()
            // return {
            //     'name': _('%(name)s REFUND', name=self.name),
            //     'qty': -(self.qty - self.refunded_qty),
            //     'order_id': refund_order.id,
            //     'pack_lot_ids': PosPackOperationLot,
            //     'is_total_cost_computed': False,
            //     'refunded_orderline_id': self.id,
            // }
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareTaxBaseLineValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_tax_base_line_values(self):
            // """ Convert pos order lines into dictionaries that would be used to compute taxes later.
            // 
            // :return: A list of python dictionaries (see '_prepare_base_line_for_taxes_computation' in account.tax).
            // """
            // return [line._prepare_base_line_for_taxes_computation() for line in self]
            */
            return default;
        }

        protected async Task<PosOrderLine> UnlinkExceptOrderStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _unlink_except_order_state(self):
            // if self.filtered(lambda x: x.order_id.state not in ["draft", "cancel"]):
            //     raise UserError(_("You can only unlink PoS order lines that are related to orders in new or cancelled state."))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PosOrderLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def write(self, vals):
            // if vals.get('pack_lot_line_ids'):
            //     for pl in vals.get('pack_lot_ids'):
            //         if pl[2].get('server_id'):
            //             pl[2]['id'] = pl[2]['server_id']
            //             del pl[2]['server_id']
            // if self.order_id.config_id.order_edit_tracking and vals.get('qty') is not None and vals.get('qty') < self.qty:
            //     self.is_edited = True
            //     body = _("%(product_name)s: Ordered quantity: %(old_qty)s", product_name=self.full_product_name, old_qty=self.qty)
            //     body += Markup("&rarr;") + str(vals.get('qty'))
            //     for line in self:
            //         line.order_id.message_post(body=line.order_id._prepare_pos_log(body))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def write(self, vals):
            // if (vals.get('combo_parent_uuid')):
            //     vals.update([
            //         ('combo_parent_id', self.search([('uuid', '=', vals.get('combo_parent_uuid'))]).id)
            //     ])
            // if 'combo_parent_uuid' in vals:
            //     del vals['combo_parent_uuid']
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}