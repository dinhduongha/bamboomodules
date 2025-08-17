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
    public class StockLotAppService : GenericApplicationService<StockLot>, IStockLotAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public StockLotAppService(IRepository<StockLot, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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
            // alert_activity_xml_id = "product_expiry.mail_activity_type_alert_date_reached"
            // alert_activity = self.env.ref(alert_activity_xml_id, raise_if_not_found=False)
            // alert_activity_default_user_id = alert_activity.default_user_id.id if alert_activity else None
            // for lot in alert_lots:
            //     user_id = alert_activity_default_user_id or \
            //               lot.product_id.with_company(lot.company_id).responsible_id.id or \
            //               lot.product_id.responsible_id.id or SUPERUSER_ID
            //     lot.activity_schedule(
            //         alert_activity_xml_id,
            //         user_id=user_id,
            //         note=_("The alert date has been reached for this lot/serial number")
            //     )
            // alert_lots.write({
            //     'product_expiry_reminded': True
            // })
            */
            return default;
        }

        protected async Task<StockLot> ChangeStandardPriceInternalAsync(object new_price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _change_standard_price(self, new_price):
            // """Helper to create the stock valuation layers and the account moves
            // after an update of standard price.
            // 
            // :param new_price: new standard price
            // """
            // if self.product_id.filtered(lambda p: p.valuation == 'real_time') and not self.env['stock.valuation.layer'].check_access_rights('read', raise_exception=False):
            //     raise UserError(_("You cannot update the cost of a product in automated valuation as it leads to the creation of a journal entry, for which you don't have the access rights."))
            // 
            // svl_vals_list = []
            // company_id = self.env.company
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // rounded_new_price = float_round(new_price, precision_digits=price_unit_prec)
            // for lot in self:
            //     if lot.product_id.cost_method not in ('standard', 'average'):
            //         continue
            //     quantity_svl = lot.sudo().quantity_svl
            //     if float_compare(quantity_svl, 0.0, precision_rounding=lot.product_id.uom_id.rounding) <= 0:
            //         continue
            //     value_svl = lot.sudo().value_svl
            //     value = company_id.currency_id.round((rounded_new_price * quantity_svl) - value_svl)
            //     if company_id.currency_id.is_zero(value):
            //         continue
            // 
            //     svl_vals = {
            //         'company_id': company_id.id,
            //         'product_id': lot.product_id.id,
            //         'description': _('Lot value manually modified (from %(old)s to %(new)s)', old=lot.standard_price, new=rounded_new_price),
            //         'value': value,
            //         'quantity': 0,
            //         'lot_id': lot.id,
            //     }
            //     svl_vals_list.append(svl_vals)
            // layers = self.env['stock.valuation.layer'].sudo().create(svl_vals_list)
            // layers._change_standart_price_accounting_entries(new_price)
            // for product in self.with_context(disable_auto_svl=True).product_id:
            //     if product.cost_method == 'standard':
            //         continue
            //     if product.quantity_svl:
            //         product.standard_price = product.value_svl / product.quantity_svl
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
            // delivery_ids_by_lot = self._find_delivery_ids_by_lot()
            // for lot in self:
            //     lot.delivery_ids = delivery_ids_by_lot[lot.id]
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
            //     prod_lot.display_complete = prod_lot.id or self._context.get('display_complete')
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

        protected async Task<StockLot> ComputeLastDeliveryPartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _compute_last_delivery_partner_id(self):
            // serial_products = self.filtered(lambda l: l.product_id.tracking == 'serial')
            // delivery_ids_by_lot = serial_products._find_delivery_ids_by_lot()
            // (self - serial_products).last_delivery_partner_id = False
            // for lot in serial_products:
            //     if lot.product_id.tracking == 'serial' and len(delivery_ids_by_lot[lot.id]) > 0:
            //         lot.last_delivery_partner_id = self.env['stock.picking'].browse(delivery_ids_by_lot[lot.id]).sorted(key='date_done', reverse=True)[0].partner_id
            //     else:
            //         lot.last_delivery_partner_id = False
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_last_delivery_partner_id(self):
            // super()._compute_last_delivery_partner_id()
            // for lot in self:
            //     if lot.delivery_count > 0:
            //         last_delivery = max(lot.delivery_ids, key=lambda d: d.date_done)
            //         if last_delivery.is_dropship:
            //             lot.last_delivery_partner_id = last_delivery.sale_id.partner_id
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

        protected async Task<StockLot> ComputeValueSvlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def _compute_value_svl(self):
            // """Compute totals of multiple svl related values"""
            // self.value_svl = 0
            // self.quantity_svl = 0
            // self.avg_cost = 0
            // self.total_value = 0
            // self.company_currency_id = False
            // lots = self.filtered(lambda l: l.product_id.lot_valuated)
            // if not lots:
            //     return
            // company_id = self.env.company
            // self.company_currency_id = company_id.currency_id
            // domain = [
            //     *self.env['stock.valuation.layer']._check_company_domain(company_id),
            //     ('lot_id', 'in', lots.ids),
            // ]
            // if self.env.context.get('to_date'):
            //     to_date = fields.Datetime.to_datetime(self.env.context['to_date'])
            //     domain.append(('create_date', '<=', to_date))
            // groups = self.env['stock.valuation.layer']._read_group(
            //     domain,
            //     groupby=['lot_id'],
            //     aggregates=['value:sum', 'quantity:sum'],
            // )
            // # Browse all lots and compute lots' quantities_dict in batch.
            // group_mapping = {lot: aggregates for lot, *aggregates in groups}
            // for lot in lots:
            //     value_sum, quantity_sum = group_mapping.get(lot._origin, (0, 0))
            //     value_svl = self.company_currency_id.round(value_sum)
            //     avg_cost = value_svl / quantity_sum if quantity_sum else 0
            //     lot.value_svl = value_svl
            //     lot.quantity_svl = quantity_sum
            //     lot.avg_cost = avg_cost
            //     lot.total_value = avg_cost * quantity_sum
            */
            return default;
        }

        public async Task<StockLot> CopyDataAsync(Guid id, object @default)
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
            //         lots_by_product.filtered(lambda lot: not lot.standard_price).with_context(disable_auto_svl=True).write({
            //             'standard_price': product.standard_price
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
            // domain = [
            //     ('lot_id', 'in', self.ids),
            //     ('state', '=', 'done'),
            // ]
            // domain_restriction = self._get_outgoing_domain()
            // domain = expression.AND([domain, domain_restriction])
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

        public async Task<StockLot> GenerateLotNamesAsync(Guid id, object first_lot, object count)
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
            //     ('picking_code', '=', 'outgoing'),
            //     ('produce_line_ids', '!=', False),
            // ]
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_outgoing_domain(self):
            // res = super()._get_outgoing_domain()
            // return expression.OR([res, [
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

        public async Task<StockLot> RevaluationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def action_revaluation(self):
            // # Cannot hide the button in list view for non required field in groupby
            // if not self:
            //     raise UserError(_("Select an existing lot/serial number to be reevaluated"))
            // elif all(float_is_zero(layer.remaining_qty, precision_rounding=self.product_id.uom_id.rounding) for layer in self.stock_valuation_layer_ids):
            //     raise UserError(_("You cannot adjust the valuation of a layer with zero quantity"))
            // self.ensure_one()
            // ctx = dict(self._context, default_lot_id=self.id, default_company_id=self.env.company.id)
            // return {
            //     'name': _("Lot/Serial number Revaluation"),
            //     'view_mode': 'form',
            //     'res_model': 'stock.valuation.layer.revaluation',
            //     'view_id': self.env.ref('stock_account.stock_valuation_layer_revaluation_form_view').id,
            //     'type': 'ir.actions.act_window',
            //     'context': ctx,
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLot> SearchProductQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_lot.py) ---
            // def _search_product_qty(self, operator, value):
            // if operator not in OPERATORS:
            //     raise UserError(_("Invalid domain operator %s", operator))
            // if not isinstance(value, (float, int)):
            //     raise UserError(_("Invalid domain right operand '%s'. It must be of type Integer/Float", value))
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
            //     if OPERATORS[operator](quantity_sum, value):
            //         ids.append(lot_id)
            // if value == 0.0 and operator == '=':
            //     return [('id', 'not in', lot_ids_w_qty)]
            // if value == 0.0 and operator == '!=':
            //     return [('id', 'in', lot_ids_w_qty)]
            // # check if we need include zero values in result
            // include_zero = (
            //     value < 0.0 and operator in ('>', '>=') or
            //     value > 0.0 and operator in ('<', '<=') or
            //     value == 0.0 and operator in ('>=', '<=')
            // )
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

        public async Task<StockLot> ViewPoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def action_view_po(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.purchase_form_action")
            // action['domain'] = [('id', 'in', self.mapped('purchase_order_ids.id'))]
            // action['context'] = dict(self._context, create=False)
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
            // action['context'] = dict(self._context, create=False)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockLot> ViewStockValuationLayersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py) ---
            // def action_view_stock_valuation_layers(self):
            // self.ensure_one()
            // domain = [('lot_id', '=', self.ids)]
            // action = self.env["ir.actions.actions"]._for_xml_id("stock_account.stock_valuation_layer_action")
            // context = literal_eval(action['context'])
            // context.update(self.env.context)
            // context['no_at_date'] = True
            // return dict(action, domain=domain, context=context)
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
            // if 'standard_price' in vals and not self.env.context.get('disable_auto_svl'):
            //     self._change_standard_price(vals['standard_price'])
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}