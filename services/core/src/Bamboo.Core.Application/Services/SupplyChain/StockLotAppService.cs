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
    public class StockLotAppService : GenericApplicationService<StockLot>, IStockLotAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public StockLotAppService(IRepository<StockLot, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<StockLot> AlertDateExceededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _alert_date_exceeded(self):
            // """Log an activity on internally stored lots whose alert_date has been reached.
            // 
            // No further activity will be generated on lots whose alert_date
            // has already been reached (even if the alert_date is changed).
            // """
            // alert_lots = self.env['stock.lot'].search([
            //     ('alert_date', '<=', fields.Date.today()),
            //     ('product_expiry_reminded', '=', False)])
            // 
            // lot_stock_quants = self.env['stock.quant'].search([
            //     ('lot_id', 'in', alert_lots.ids),
            //     ('quantity', '>', 0),
            //     ('location_id.usage', '=', 'internal')])
            // alert_lots = lot_stock_quants.mapped('lot_id')
            // 
            // for lot in alert_lots:
            //     lot.activity_schedule(
            //         'mail.mail_activity_data_todo',
            //         user_id=lot.product_id.with_company(lot.company_id).responsible_id.id or lot.product_id.responsible_id.id or SUPERUSER_ID,
            //         note=_("The alert date has been reached for this lot/serial number"),
            //         summary=_("Alert Date Reached"),
            //     )
            // alert_lots.write({
            //     'product_expiry_reminded': True
            // })
            */
            return default;
        }

        protected async Task<StockLot> ChangeStandardPriceInternalAsync(object old_price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _change_standard_price(self, old_price):
            // """Helper to create the stock valuation layers and the account moves
            // after an update of standard price.
            // 
            // :param new_price: new standard price
            // """
            // for lot in self:
            //     if lot.product_id.cost_method != 'average' or lot.standard_price == old_price:
            //         continue
            //     product = lot.product_id
            //     self.env['product.value'].sudo().create({
            //         'product_id': product.id,
            //         'lot_id': lot.id,
            //         'value': lot.standard_price,
            //         'company_id': product.company_id.id or self.env.company.id,
            //         'date': fields.Datetime.now(),
            //         'description': _('%(lot)s price update from %(old_price)s to %(new_price)s by %(user)s',
            //             lot=lot.name, old_price=old_price, new_price=lot.standard_price, user=self.env.user.name)
            //     })
            */
            return default;
        }

        protected async Task<StockLot> CheckCreateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_lot.py) ---
            // def _check_create(self):
            // active_mo_id = self.env.context.get('active_mo_id')
            // if active_mo_id:
            //     active_mo = self.env['mrp.production'].browse(active_mo_id)
            //     component_product_ids = set(active_mo.move_raw_ids.product_id.ids)
            //     product_ids = self.env.context.get('lot_product_ids')
            //     if not active_mo.picking_type_id.use_create_components_lots and product_ids & component_product_ids:
            //         raise UserError(_('You are not allowed to create or edit a lot or serial number for the components with the operation type "Manufacturing". To change this, go on the operation type and tick the box "Create New Lots/Serial Numbers for Components".'))
            // return super()._check_create()
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def _check_create(self):
            // active_repair_id = self.env.context.get('active_repair_id')
            // if active_repair_id:
            //     active_repair = self.env['repair.order'].browse(active_repair_id)
            //     if active_repair and not active_repair.picking_type_id.use_create_lots:
            //         raise UserError(_('You are not allowed to create a lot or serial number with this operation type. To change this, go on the operation type and tick the box "Create New Lots/Serial Numbers".'))
            // return super()._check_create()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _check_create(self):
            // active_picking_id = self.env.context.get('active_picking_id', False)
            // if active_picking_id:
            //     picking_id = self.env['stock.picking'].browse(active_picking_id)
            //     if picking_id and not picking_id.picking_type_id.use_create_lots:
            //         raise UserError(_('You are not allowed to create a lot or serial number with this operation type. To change this, go on the operation type and tick the box "Create New Lots/Serial Numbers".'))
            */
            return default;
        }

        protected async Task<StockLot> CheckUniqueLotInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _check_unique_lot(self):
            // domain = [('product_id', 'in', self.product_id.ids),
            //           ('name', 'in', self.mapped('name'))]
            // groupby = ['company_id', 'product_id', 'name']
            // if any(not lot.company_id for lot in self):
            //     # We need to check across other companies to not have duplicates between 'no-company' and a company.
            //     self = self.sudo()
            // records = self._read_group(domain, groupby, ['__count'], order='company_id DESC')
            // error_message_lines = set()
            // cross_lots = {}
            // for company, product, name, count in records:
            //     if not company:
            //         cross_lots[(product, name)] = count
            //     # For company-specific lots, we check that there is no duplicate with 'no-company' lots, but NOT between specific-company ones.
            //     if (company and (cross_lots.get((product, name), 0) + count) > 1) or count > 1:
            //         error_message_lines.add(_(" - Product: %(product)s, Lot/Serial Number: %(lot)s", product=product.display_name, lot=name))
            // if error_message_lines:
            //     raise ValidationError(
            //         _(
            //             "The combination of lot/serial number and product must be unique within a company including when no company is defined.\nThe following combinations contain duplicates:\n%(error_lines)s",
            //             error_lines="\n".join(error_message_lines),
            //         ),
            //     )
            */
            return default;
        }

        protected async Task<StockLot> ComputeAvgCostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _compute_avg_cost(self):
            // """Compute totals of multiple svl related values"""
            // at_date = fields.Datetime.to_datetime(self.env.context.get('to_date'))
            // 
            // self.avg_cost = 0.0
            // for lot in self:
            //     if not lot.lot_valuated:
            //         continue
            // 
            //     qty_available = lot.product_qty
            //     if lot.product_id.cost_method == 'standard':
            //         total_value = lot.standard_price * qty_available
            //     elif lot.product_id.cost_method == 'average':
            //         total_value = lot.product_id._run_avco(at_date=at_date, lot=lot)[1]
            //     else:
            //         total_value = lot.product_id._run_fifo(qty_available, at_date=at_date, lot=lot)
            //     lot.avg_cost = total_value / qty_available if qty_available else 0.0
            */
            return default;
        }

        protected async Task<StockLot> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_company_id(self):
            // for lot in self:
            //     if self.env.company in lot.product_id.company_id.all_child_ids and lot.product_id.company_id not in self.env.companies:
            //         lot.company_id = self.env.company
            //     else:
            //         lot.company_id = lot.product_id.company_id
            */
            return default;
        }

        protected async Task<StockLot> ComputeDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _compute_dates(self):
            // for lot in self:
            //     if not lot.product_id.use_expiration_date:
            //         lot.use_date = False
            //         lot.removal_date = False
            //         lot.alert_date = False
            //     elif lot.expiration_date:
            //         # when create
            //         if lot.product_id != lot._origin.product_id or \
            //            (not lot.use_date and not lot.removal_date and not lot.alert_date) or \
            //            (lot.expiration_date and not lot._origin.expiration_date):
            //             product_tmpl = lot.product_id.product_tmpl_id
            //             lot.use_date = lot.expiration_date - datetime.timedelta(days=product_tmpl.use_time)
            //             lot.removal_date = lot.expiration_date - datetime.timedelta(days=product_tmpl.removal_time)
            //             lot.alert_date = lot.expiration_date - datetime.timedelta(days=product_tmpl.alert_time)
            //         # when change
            //         elif lot._origin.expiration_date:
            //             time_delta = lot.expiration_date - lot._origin.expiration_date
            //             lot.use_date = lot._origin.use_date and lot._origin.use_date + time_delta
            //             lot.removal_date = lot._origin.removal_date and lot._origin.removal_date + time_delta
            //             lot.alert_date = lot._origin.alert_date and lot._origin.alert_date + time_delta
            */
            return default;
        }

        protected async Task<StockLot> ComputeDeliveryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_delivery_ids(self):
            // delivery_ids_by_lot = self._find_delivery_ids_by_lot_iterative()
            // for lot in self:
            //     lot.delivery_ids = delivery_ids_by_lot.get(lot.id, [])
            //     lot.delivery_count = len(lot.delivery_ids)
            */
            return default;
        }

        protected async Task<StockLot> ComputeDisplayCompleteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_display_complete(self):
            // """ Defines if we want to display all fields in the stock.production.lot form view.
            // It will if the record exists (`id` set) or if we precised it into the context.
            // This compute depends on field `name` because as it has always a default value, it'll be
            // always triggered.
            // """
            // for prod_lot in self:
            //     prod_lot.display_complete = prod_lot.id or self.env.context.get('display_complete')
            */
            return default;
        }

        protected async Task<StockLot> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _compute_display_name(self):
            // lots_to_process_ids = []
            // for lot in self:
            //     if lot.env.context.get('formatted_display_name') and lot.use_expiration_date and lot.expiration_date:
            //         name = f"{lot.name}"
            //         if fields.Datetime.now() >= lot.expiration_date:
            //             name += self.env._("\t--Expired--")
            //         elif lot.alert_date and fields.Datetime.now() >= lot.alert_date:
            //             name += self.env._("\t--Expire on %(date)s--", date=fields.Datetime.to_string(lot.expiration_date))
            //         lot.display_name = name
            //     else:
            //         lots_to_process_ids.append(lot.id)
            // if lots_to_process_ids:
            //     super(StockLot, self.env['stock.lot'].browse(lots_to_process_ids))._compute_display_name()
            */
            return default;
        }

        protected async Task<StockLot> ComputeExpirationDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _compute_expiration_date(self):
            // self.expiration_date = False
            // for lot in self:
            //     if lot.product_id.use_expiration_date and not lot.expiration_date:
            //         duration = lot.product_id.product_tmpl_id.expiration_time
            //         lot.expiration_date = datetime.datetime.now() + datetime.timedelta(days=duration)
            */
            return default;
        }

        protected async Task<StockLot> ComputeInRepairCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def _compute_in_repair_count(self):
            // lot_data = self.env['repair.order']._read_group([('lot_id', 'in', self.ids), ('state', 'not in', ('done', 'cancel'))], ['lot_id'], ['__count'])
            // result = {lot.id: count for lot, count in lot_data}
            // for lot in self:
            //     lot.in_repair_count = result.get(lot.id, 0)
            */
            return default;
        }

        protected async Task<StockLot> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_name(self):
            // for lot in self:
            //     if not lot.name:
            //         lot.name = lot.product_id.lot_sequence_id.next_by_id() if lot.product_id.lot_sequence_id else False
            */
            return default;
        }

        protected async Task<StockLot> ComputePartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_partner_ids(self):
            // delivery_ids_by_lot = self._find_delivery_ids_by_lot_iterative()
            // for lot in self:
            //     if delivery_ids_by_lot.get(lot.id, []):
            //         lot.partner_ids = self.env['stock.picking'].browse(delivery_ids_by_lot[lot.id]).sorted(key='date_done', reverse=True).partner_id
            //     else:
            //         lot.partner_ids = False
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_partner_ids(self):
            // delivery_ids_by_lot = self._find_delivery_ids_by_lot()
            // for lot in self:
            //     if delivery_ids_by_lot[lot.id]:
            //         picking_ids = self.env['stock.picking'].browse(delivery_ids_by_lot[lot.id]).sorted(key='date_done', reverse=True)
            //         lot.partner_ids = list(p.sale_id.partner_shipping_id.id if p.is_dropship else p.partner_id.id for p in picking_ids)
            //     else:
            //         lot.partner_ids = False
            */
            return default;
        }

        protected async Task<StockLot> ComputeProductExpiryAlertInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _compute_product_expiry_alert(self):
            // current_date = fields.Datetime.now()
            // for lot in self:
            //     if lot.expiration_date:
            //         lot.product_expiry_alert = lot.expiration_date <= current_date
            //     else:
            //         lot.product_expiry_alert = False
            */
            return default;
        }

        protected async Task<StockLot> ComputePurchaseOrderIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _compute_purchase_order_ids(self):
            // purchase_orders = defaultdict(lambda: self.env['purchase.order'])
            // for move_line in self.env['stock.move.line'].search([('lot_id', 'in', self.ids), ('state', '=', 'done')]):
            //     move = move_line.move_id
            //     if move.picking_id.location_id.usage in ('supplier', 'transit') and move.purchase_line_id.order_id:
            //         purchase_orders[move_line.lot_id.id] |= move.purchase_line_id.order_id
            // for lot in self:
            //     lot.purchase_order_ids = purchase_orders[lot.id]
            //     lot.purchase_order_count = len(lot.purchase_order_ids)
            */
            return default;
        }

        protected async Task<StockLot> ComputeRepairLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def _compute_repair_line_ids(self):
            // repair_orders = defaultdict(lambda: self.env['repair.order'])
            // repair_moves = self.env['stock.move'].search([
            //     ('repair_id', '!=', False),
            //     ('repair_line_type', '!=', False),
            //     ('move_line_ids.lot_id', 'in', self.ids),
            //     ('state', '=', 'done')])
            // for repair_line in repair_moves:
            //     for rl_id in repair_line.lot_ids.ids:
            //         repair_orders[rl_id] |= repair_line.repair_id
            // for lot in self:
            //     lot.repair_line_ids = repair_orders[lot.id]
            //     lot.repair_part_count = len(lot.repair_line_ids)
            */
            return default;
        }

        protected async Task<StockLot> ComputeRepairedCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def _compute_repaired_count(self):
            // lot_data = self.env['repair.order']._read_group([('lot_id', 'in', self.ids), ('state', '=', 'done')], ['lot_id'], ['__count'])
            // result = {lot.id: count for lot, count in lot_data}
            // for lot in self:
            //     lot.repaired_count = result.get(lot.id, 0)
            */
            return default;
        }

        protected async Task<StockLot> ComputeSaleOrderIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _compute_sale_order_ids(self):
            // sale_orders = defaultdict(lambda: self.env['sale.order'])
            // for move_line in self.env['stock.move.line'].search([('lot_id', 'in', self.ids), ('state', '=', 'done')]):
            //     move = move_line.move_id
            //     if move.picking_id.location_dest_id.usage in ('customer', 'transit') and move.sale_line_id.order_id:
            //         sale_orders[move_line.lot_id.id] |= move.sale_line_id.order_id
            // for lot in self:
            //     lot.sale_order_ids = sale_orders[lot.id]
            //     lot.sale_order_count = len(lot.sale_order_ids)
            */
            return default;
        }

        protected async Task<StockLot> ComputeSingleLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_single_location(self):
            // for lot in self:
            //     quants = lot.quant_ids.filtered(lambda q: q.quantity > 0)
            //     lot.location_id = quants.location_id if len(quants.location_id) == 1 else False
            */
            return default;
        }

        protected async Task<StockLot> ComputeValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _compute_value(self):
            // """Compute totals of multiple svl related values"""
            // company_id = self.env.company
            // self.company_currency_id = company_id.currency_id
            // at_date = fields.Datetime.to_datetime(self.env.context.get('to_date'))
            // 
            // for lot in self:
            //     if not lot.lot_valuated:
            //         lot.total_value = 0.0
            //         continue
            // 
            //     qty_available = lot.product_qty
            //     if lot.product_id.cost_method == 'standard':
            //         lot.total_value = lot.standard_price * qty_available
            //     elif lot.product_id.cost_method == 'average':
            //         lot.total_value = lot.product_id._run_avco(at_date=at_date, lot=lot)[1]
            //     else:
            //         lot.total_value = lot.product_id._run_fifo(qty_available, at_date=at_date, lot=lot)
            */
            return default;
        }

        public async Task<StockLot> CopyDataAsync(Guid id, StockLotCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for lot, vals in zip(self, vals_list):
            //         vals['name'] = _("(copy of) %s", lot.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<StockLot> CreateAsync(StockLot entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def create(self, vals_list):
            // lot_product_ids =  {val.get('product_id') for val in vals_list} | {self.env.context.get('default_product_id')}
            // self.with_context(lot_product_ids=lot_product_ids)._check_create()
            // return super(StockLot, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def create(self, vals_list):
            // lots = super().create(vals_list)
            // for product, lots_by_product in lots.grouped('product_id').items():
            //     if product.lot_valuated:
            //         lots_by_product.filtered(lambda lot: not lot.standard_price).with_context(disable_auto_revaluation=True).write({
            //             'standard_price': product.standard_price,
            //         })
            // return lots
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<StockLot> FindDeliveryIdsByLotInternalAsync(object lot_path, object delivery_by_lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _find_delivery_ids_by_lot(self, lot_path=None, delivery_by_lot=None):
            // if lot_path is None:
            //     lot_path = set()
            // domain = Domain([
            //     ('lot_id', 'in', self.ids),
            //     ('state', '=', 'done'),
            // ]) & Domain(self._get_outgoing_domain())
            // move_lines = self.env['stock.move.line'].search(domain)
            // moves_by_lot = {
            //     lot_id: {'producing_lines': set(), 'barren_lines': set()}
            //     for lot_id in move_lines.lot_id.ids
            // }
            // for line in move_lines:
            //     if line.produce_line_ids:
            //         moves_by_lot[line.lot_id.id]['producing_lines'].add(line.id)
            //     else:
            //         moves_by_lot[line.lot_id.id]['barren_lines'].add(line.id)
            // if delivery_by_lot is None:
            //     delivery_by_lot = dict()
            // for lot in self:
            //     delivery_ids = set()
            // 
            //     if moves_by_lot.get(lot.id):
            //         producing_move_lines = self.env['stock.move.line'].browse(moves_by_lot[lot.id]['producing_lines'])
            //         barren_move_lines = self.env['stock.move.line'].browse(moves_by_lot[lot.id]['barren_lines'])
            // 
            //         if producing_move_lines:
            //             lot_path.add(lot.id)
            //             next_lots = producing_move_lines.produce_line_ids.lot_id.filtered(lambda l: l.id not in lot_path)
            //             next_lots_ids = set(next_lots.ids)
            //             # If some producing lots are in lot_path, it means that they have been previously processed.
            //             # Their results are therefore already in delivery_by_lot and we add them to delivery_ids directly.
            //             delivery_ids.update(*(delivery_by_lot.get(lot_id, []) for lot_id in (producing_move_lines.produce_line_ids.lot_id - next_lots).ids))
            // 
            //             for lot_id, delivery_ids_set in next_lots._find_delivery_ids_by_lot(lot_path=lot_path, delivery_by_lot=delivery_by_lot).items():
            //                 if lot_id in next_lots_ids:
            //                     delivery_ids.update(delivery_ids_set)
            //         delivery_ids.update(barren_move_lines.picking_id.ids)
            // 
            //     delivery_by_lot[lot.id] = list(delivery_ids)
            // return delivery_by_lot
            */
            return default;
        }

        protected async Task<StockLot> FindDeliveryIdsByLotIterativeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _find_delivery_ids_by_lot_iterative(self):
            // """ Retrieve all delivery IDs (outgoing picking) linked to the lots
            //     in self and all the lots found when parcouring the produce lines.
            //     :return: A dictionary where keys are the IDs of the original 'stock.lot'
            //               records (self) and values are lists of associated 'stock.picking' IDs.
            //     :rtype: dict
            // """
            // 
            // all_lot_ids = set(self.ids)
            // barren_lines = defaultdict(set)
            // parent_map = defaultdict(set)
            // 
            // # Prefetch the lines linked to lots and split them between producing lines
            // # and barren lines (lines that have `produce_line_ids` and lines that don't
            // # have them respectively) and build the map of the parents of each lot (so we
            // # can browse the tree from the leaves to the root and propagate the pickings)
            // queue = list(self.ids)
            // while queue:
            //     domain = Domain([
            //         ('lot_id', 'in', queue),
            //         ('state', '=', 'done'),
            //     ]) & Domain(self._get_outgoing_domain())
            // 
            //     queue = []
            //     move_lines = self.env['stock.move.line'].search(domain)
            //     for line in move_lines:
            //         lot_id = line.lot_id.id
            // 
            //         produce_line_lot_ids = line.produce_line_ids.lot_id.ids
            //         if produce_line_lot_ids:
            //             for child_lot_id in produce_line_lot_ids:
            //                 parent_map[child_lot_id].add(lot_id)
            //         else:
            //             barren_lines[lot_id].add(line.id)
            // 
            //         next_lots = set(produce_line_lot_ids) - all_lot_ids
            //         all_lot_ids.update(next_lots)
            //         queue.extend(next_lots)
            // 
            // # Initialize delivery_by_lot with barren lines (i.e. the leaves of the lot tree)
            // lots_to_propagate = set()
            // delivery_by_lot = {lot_id: set() for lot_id in all_lot_ids}
            // for lot_id in barren_lines:
            //     barren_line_ids = barren_lines[lot_id]
            //     if barren_line_ids:
            //         barren_move_lines = self.env['stock.move.line'].browse(barren_line_ids)
            //         delivery_by_lot[lot_id].update(barren_move_lines.picking_id.ids)
            //         lots_to_propagate.add(lot_id)
            // 
            // # Propagate the deliveries from the children to their parent lots.
            // # This loop processes lots whose delivery sets have just been updated,
            // # ensuring the new results are merged upward through the parent graph until
            // # all deliveries are propagated
            // while lots_to_propagate:
            //     lot_id = lots_to_propagate.pop()
            // 
            //     parent_ids = parent_map[lot_id]
            //     for parent_id in parent_ids:
            //         if not delivery_by_lot[lot_id].issubset(delivery_by_lot[parent_id]):
            //             delivery_by_lot[parent_id].update(delivery_by_lot[lot_id])
            //             lots_to_propagate.add(parent_id)
            // 
            // return {lot_id: list(delivery_by_lot[lot_id]) for lot_id in delivery_by_lot}
            */
            return default;
        }

        public async Task<StockLot> GenerateLotNamesAsync(Guid id, StockLotGenerateLotNamesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def generate_lot_names(self, first_lot, count):
            // """Generate `lot_names` from a string."""
            // # We look if the first lot contains at least one digit.
            // caught_initial_number = regex_findall(r"\d+", first_lot)
            // if not caught_initial_number:
            //     return self.generate_lot_names(first_lot + "0", count)
            // # We base the series on the last number found in the base lot.
            // initial_number = caught_initial_number[-1]
            // padding = len(initial_number)
            // # We split the lot name to get the prefix and suffix.
            // splitted = regex_split(initial_number, first_lot)
            // # initial_number could appear several times, e.g. BAV023B00001S00001
            // prefix = initial_number.join(splitted[:-1])
            // suffix = splitted[-1]
            // initial_number = int(initial_number)
            // 
            // return [{
            //     'lot_name': '%s%s%s' % (prefix, str(initial_number + i).zfill(padding), suffix),
            // } for i in range(0, count)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLot> GetNextSerialInternalAsync(object company, object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _get_next_serial(self, company, product):
            // """Return the next serial number to be attributed to the product."""
            // if product.tracking != "none":
            //     last_serial = self.env['stock.lot'].search(
            //         ['|', ('company_id', '=', company.id), ('company_id', '=', False), ('product_id', '=', product.id)],
            //         limit=1, order='id DESC')
            //     if last_serial:
            //         return self.env['stock.lot'].generate_lot_names(last_serial.name, 2)[1]['lot_name']
            // return False
            */
            return default;
        }

        protected async Task<StockLot> GetOutgoingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _get_outgoing_domain(self):
            // return [
            //     '|',
            //     '|', ('picking_code', '=', 'outgoing'), ('move_id.picking_code', '=', 'outgoing'),
            //     ('produce_line_ids', '!=', False),
            // ]
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_outgoing_domain(self):
            // res = super()._get_outgoing_domain()
            // return Domain.OR([res, [
            //     ('location_dest_id.usage', '=', 'customer'),
            //     ('location_id.usage', '=', 'supplier'),
            // ]])
            */
            return default;
        }

        public async Task<StockLot> LotOpenQuantsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def action_lot_open_quants(self):
            // self = self.with_context(search_default_lot_id=self.id, create=False)
            // if self.env.user.has_group('stock.group_stock_manager'):
            //     self = self.with_context(inventory_mode=True)
            // return self.env['stock.quant'].action_view_quants()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockLot> LotOpenRepairsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def action_lot_open_repairs(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("repair.action_repair_order_tree")
            // action.update({
            //     'domain': [('lot_id', '=', self.id)],
            //     'context': {
            //         'default_product_id': self.product_id.id,
            //         'default_repair_lot_id': self.id,
            //         'default_company_id': self.company_id.id or self.env.company.id,
            //     },
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockLot> LotOpenTransfersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def action_lot_open_transfers(self):
            // self.ensure_one()
            // 
            // action = {
            //     'res_model': 'stock.picking',
            //     'type': 'ir.actions.act_window'
            // }
            // if len(self.delivery_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.delivery_ids[0].id
            //     })
            // else:
            //     action.update({
            //         'name': _("Delivery orders of %s", self.display_name),
            //         'domain': [('id', 'in', self.delivery_ids.ids)],
            //         'view_mode': 'list,form'
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLot> ProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _product_qty(self):
            // for lot in self:
            //     # We only care for the quants in internal or transit locations.
            //     quants = lot.quant_ids.filtered(lambda q: q.location_id.usage == 'internal' or (q.location_id.usage == 'transit' and q.location_id.company_id))
            //     lot.product_qty = sum(quants.mapped('quantity'))
            */
            return default;
        }

        protected async Task<StockLot> ReadGroupLocationIdInternalAsync(object locations, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _read_group_location_id(self, locations, domain):
            // partner_locations = locations.search([('usage', 'in', ('customer', 'supplier'))])
            // return partner_locations + locations.warehouse_id.search([]).lot_stock_id
            */
            return default;
        }

        protected async Task<StockLot> SearchPartnerIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _search_partner_ids(self, operator, value):
            // """ returns partner_ids that are directly delivered the product of the lot/SN, i.e. not
            // lots/SNs that are consumed within a MO. This means this search is NOT symmetric with the
            // partner_ids field within the form view since it uses different logic that isn't efficient
            // enough for this search due to it being usable within the list view.
            // """
            // if operator in Domain.NEGATIVE_OPERATORS or not isinstance(value, (Iterable)):
            //     return NotImplemented
            // is_no_partner = operator == 'in' and list(value) == [False]
            // domain = Domain([
            //     ('lot_id', '!=', False),
            //     ('state', '=', 'done'),
            // ])
            // if is_no_partner:
            //     # reverse the search, get all lots sent to partner so we can return all lots NOT sent
            //     domain &= Domain('picking_partner_id', 'not in', value)
            // else:
            //     domain &= Domain.OR([
            //         Domain('picking_partner_id', operator, value),
            //         Domain('move_partner_id', operator, value),
            //     ])
            // domain &= Domain(self._get_outgoing_domain())
            // move_lines = self.env['stock.move.line'].search(domain)
            // 
            // if is_no_partner:
            //     return [('id', 'not in', move_lines.lot_id.ids)]
            // return [('id', 'in', move_lines.lot_id.ids)]
            */
            return default;
        }

        protected async Task<StockLot> SearchProductQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _search_product_qty(self, operator, value):
            // op = PY_OPERATORS.get(operator)
            // if not op:
            //     return NotImplemented
            // if isinstance(value, Iterable) and not isinstance(value, str):
            //     value = {float(v) for v in value}
            // else:
            //     value = float(value)
            // domain = [
            //     ('lot_id', '!=', False),
            //     '|', ('location_id.usage', '=', 'internal'),
            //     '&', ('location_id.usage', '=', 'transit'), ('location_id.company_id', '!=', False)
            // ]
            // lots_w_qty = self.env['stock.quant']._read_group(domain=domain, groupby=['lot_id'], aggregates=['quantity:sum'], having=[('quantity:sum', '!=', 0)])
            // ids = []
            // lot_ids_w_qty = []
            // for lot, quantity_sum in lots_w_qty:
            //     lot_id = lot.id
            //     lot_ids_w_qty.append(lot_id)
            //     if op(quantity_sum, value):
            //         ids.append(lot_id)
            // 
            // # check if we need include zero values in result
            // include_zero = op(0.0, value)
            // if include_zero:
            //     return ['|', ('id', 'in', ids), ('id', 'not in', lot_ids_w_qty)]
            // return [('id', 'in', ids)]
            */
            return default;
        }

        protected async Task<StockLot> SetSingleLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _set_single_location(self):
            // quants = self.quant_ids.filtered(lambda q: q.quantity > 0)
            // if len(quants.location_id) == 1:
            //     unpack = len(quants.package_id.quant_ids) > 1
            //     quants.move_quants(location_dest_id=self.location_id, message=_("Lot/Serial Number Relocated"), unpack=unpack)
            // elif len(quants.location_id) > 1:
            //     raise UserError(_('You can only move a lot/serial to a new location if it exists in a single location.'))
            */
            return default;
        }

        protected async Task<StockLot> UpdateStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _update_standard_price(self):
            // # TODO: Add extra value and extra quantity kwargs to avoid total recomputation
            // for lot in self:
            //     lot = lot.with_context(disable_auto_revaluation=True)
            //     if not lot.product_id.lot_valuated:
            //         continue
            //     if lot.product_id.cost_method == 'standard':
            //         if not lot.standard_price:
            //             lot.standard_price = lot.product_id.standard_price
            //         continue
            //     lot.standard_price = lot.product_id._run_avco(lot=lot)[0]
            */
            return default;
        }

        public async Task<StockLot> ViewPoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def action_view_po(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.purchase_form_action")
            // action['domain'] = [('id', 'in', self.mapped('purchase_order_ids.id'))]
            // action['context'] = dict(self.env.context, create=False)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockLot> ViewRoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_lot.py) ---
            // def action_view_ro(self):
            // self.ensure_one()
            // 
            // action = {
            //     'res_model': 'repair.order',
            //     'type': 'ir.actions.act_window'
            // }
            // if len(self.repair_line_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.repair_line_ids[0].id
            //     })
            // else:
            //     action.update({
            //         'name': _("Repair orders of %s", self.name),
            //         'domain': [('id', 'in', self.repair_line_ids.ids)],
            //         'view_mode': 'list,form'
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockLot> ViewSoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def action_view_so(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // action['domain'] = [('id', 'in', self.mapped('sale_order_ids.id'))]
            // action['context'] = dict(self.env.context, create=False)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, StockLot entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def write(self, vals):
            // if 'company_id' in vals:
            //     for lot in self:
            //         if lot.location_id.company_id and vals['company_id'] and lot.location_id.company_id.id != vals['company_id']:
            //             raise UserError(_("You cannot change the company of a lot/serial number currently in a location belonging to another company."))
            // if 'product_id' in vals and any(vals['product_id'] != lot.product_id.id for lot in self):
            //     move_lines = self.env['stock.move.line'].search([('lot_id', 'in', self.ids), ('product_id', '!=', vals['product_id'])])
            //     if move_lines:
            //         raise UserError(_(
            //             'You are not allowed to change the product linked to a serial or lot number '
            //             'if some stock moves have already been created with that number. '
            //             'This would lead to inconsistencies in your stock.'
            //         ))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def write(self, vals):
            // old_price = False
            // if 'standard_price' in vals and not self.env.context.get('disable_auto_revaluation'):
            //     old_price = {lot: lot.standard_price for lot in self}
            // res = super().write(vals)
            // if old_price:
            //     self._change_standard_price(old_price)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}