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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockRuleAppService : GenericAppService<StockRule>, IStockRuleAppService
    {

        public StockRuleAppService(IRepository<StockRule, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<StockRule> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _check_company_consistency(self):
            // for rule in self:
            //     route = rule.route_id
            //     if route.company_id and rule.company_id.id != route.company_id.id:
            //         raise ValidationError(_(
            //             "Rule %(rule)s belongs to %(rule_company)s while the route belongs to %(route_company)s.",
            //             rule=rule.display_name,
            //             rule_company=rule.company_id.display_name,
            //             route_company=route.company_id.display_name,
            //         ))
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> CheckIntercompLocationInternalAsync(object locations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _check_intercomp_location(self, locations):
            // if locations.filtered(lambda location: location.usage == 'transit'):
            //     inter_comp_location = self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False)
            //     return inter_comp_location and inter_comp_location.id in locations.ids
            */
            return default;
        }

        protected async Task<StockRule> ComputeActionMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _compute_action_message(self):
            // """ Generate dynamicaly a message that describe the rule purpose to the
            // end user.
            // """
            // action_rules = self.filtered(lambda rule: rule.action)
            // for rule in action_rules:
            //     message_dict = rule._get_message_dict()
            //     message = message_dict.get(rule.action) and message_dict[rule.action] or ""
            //     if rule.action == 'pull_push':
            //         message = message_dict['pull'] + "<br/><br/>" + message_dict['push']
            //     rule.rule_message = message
            // (self - action_rules).rule_message = None
            */
            return default;
        }

        protected async Task<StockRule> ComputePickingTypeCodeDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _compute_picking_type_code_domain(self):
            // super()._compute_picking_type_code_domain()
            // for rule in self:
            //     if rule.action == 'manufacture':
            //         rule.picking_type_code_domain = rule.picking_type_code_domain or [] + ['mrp_operation']
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _compute_picking_type_code_domain(self):
            // super()._compute_picking_type_code_domain()
            // for rule in self:
            //     if rule.action == 'buy':
            //         rule.picking_type_code_domain = rule.picking_type_code_domain or [] + ['incoming']
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _compute_picking_type_code_domain(self):
            // self.picking_type_code_domain = []
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_picking_type_code_domain(self):
            // super()._compute_picking_type_code_domain()
            // for rule in self:
            //     if rule.action == 'buy':
            //         rule.picking_type_code_domain += ['dropship']
            */
            return default;
        }

        public async Task<StockRule> CopyDataAsync(StockRuleCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for rule, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", rule.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<StockRule> FilterWarehouseRoutesInternalAsync(object product, object warehouses, object route)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _filter_warehouse_routes(self, product, warehouses, route):
            // if any(rule.action == 'manufacture' for rule in route.rule_ids):
            //     if any(bom.type == 'normal' for bom in product.bom_ids):
            //         return super()._filter_warehouse_routes(product, warehouses, route)
            //     return False
            // return super()._filter_warehouse_routes(product, warehouses, route)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _filter_warehouse_routes(self, product, warehouses, route):
            // if any(rule.action == 'buy' for rule in route.rule_ids):
            //     if product.seller_ids:
            //         return super()._filter_warehouse_routes(product, warehouses, route)
            //     return False
            // return super()._filter_warehouse_routes(product, warehouses, route)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _filter_warehouse_routes(self, product, warehouses, route):
            // return route
            */
            return default;
        }

        protected async Task<StockRule> GetCustomMoveFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_custom_move_fields(self):
            // fields = super(StockRule, self)._get_custom_move_fields()
            // fields += ['bom_line_id']
            // return fields
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock.py) ---
            // def _get_custom_move_fields(self):
            // fields = super(StockRule, self)._get_custom_move_fields()
            // fields += ['sale_line_id', 'partner_id', 'sequence', 'to_refund']
            // return fields
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_custom_move_fields(self):
            // """ The purpose of this method is to be override in order to easily add
            // fields from procurement 'values' argument to move data.
            // """
            // return []
            */
            return default;
        }

        protected async Task<StockRule> GetDatePlannedInternalAsync(Guid bom_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_date_planned(self, bom_id, values):
            // format_date_planned = fields.Datetime.from_string(values['date_planned'])
            // date_planned = format_date_planned - relativedelta(days=bom_id.produce_delay)
            // if date_planned == format_date_planned:
            //     date_planned = date_planned - relativedelta(hours=1)
            // return date_planned
            */
            return default;
        }

        protected async Task<StockRule> GetLeadDaysInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """Add the product and company manufacture delay to the cumulative delay
            // and cumulative description.
            // """
            // delays, delay_description = super()._get_lead_days(product, **values)
            // bypass_delay_description = self.env.context.get('bypass_delay_description')
            // manufacture_rule = self.filtered(lambda r: r.action == 'manufacture')
            // if not manufacture_rule:
            //     return delays, delay_description
            // manufacture_rule.ensure_one()
            // bom = values.get('bom') or self.env['mrp.bom']._bom_find(product, picking_type=manufacture_rule.picking_type_id, company_id=manufacture_rule.company_id.id)[product]
            // if not bom:
            //     delays['total_delay'] += 365
            //     delays['no_bom_found_delay'] += 365
            //     if not bypass_delay_description:
            //         delay_description.append((_('No BoM Found'), _('+ %s day(s)', 365)))
            // manufacture_delay = bom.produce_delay
            // delays['total_delay'] += manufacture_delay
            // delays['manufacture_delay'] += manufacture_delay
            // if not bypass_delay_description:
            //     delay_description.append((_('Production End Date'), manufacture_delay))
            //     delay_description.append((_('Manufacturing Lead Time'), _('+ %d day(s)', manufacture_delay)))
            // if bom.type == 'normal':
            //     # pre-production rules
            //     warehouse = self.location_dest_id.warehouse_id
            //     for wh in warehouse:
            //         if wh.manufacture_steps != 'mrp_one_step':
            //             wh_manufacture_rules = product._get_rules_from_location(product.property_stock_production, route_ids=wh.pbm_route_id)
            //             extra_delays, extra_delay_description = (wh_manufacture_rules - self).with_context(global_horizon_days=0)._get_lead_days(product, **values)
            //             for key, value in extra_delays.items():
            //                 delays[key] += value
            //             delay_description += extra_delay_description
            // days_to_order = values.get('days_to_order', bom.days_to_prepare_mo)
            // delays['total_delay'] += days_to_order
            // if not bypass_delay_description:
            //     delay_description.append((_('Production Start Date'), days_to_order))
            //     delay_description.append((_('Days to Supply Components'), _('+ %d day(s)', days_to_order)))
            // return delays, delay_description
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """For subcontracting, we need to consider both vendor lead time and
            // manufacturing lead time, and DTPMO (Days To Prepare MO).
            // Subcontracting delay =
            //     max(Vendor lead time, Manufacturing lead time + DTPMO) + Days to Purchase
            // """
            // bypass_delay_description = self.env.context.get('bypass_delay_description')
            // buy_rule = self.filtered(lambda r: r.action == 'buy')
            // seller = 'supplierinfo' in values and values['supplierinfo'] or product.with_company(buy_rule.company_id)._select_seller(quantity=None)
            // if not buy_rule or not seller:
            //     return super()._get_lead_days(product, **values)
            // seller = seller[0]
            // bom = self.env['mrp.bom'].sudo()._bom_subcontract_find(
            //     product,
            //     company_id=buy_rule.picking_type_id.company_id.id,
            //     bom_type='subcontract',
            //     subcontractor=seller.partner_id)
            // if not bom:
            //     return super()._get_lead_days(product, **values)
            // 
            // delays, delay_description = super(StockRule, self - buy_rule)._get_lead_days(product, **values)
            // extra_delays, extra_delay_description = super(StockRule, buy_rule.with_context(ignore_vendor_lead_time=True, global_horizon_days=0))._get_lead_days(product, **values)
            // if seller.delay >= bom.produce_delay + bom.days_to_prepare_mo:
            //     delays['total_delay'] += seller.delay
            //     delays['purchase_delay'] += seller.delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Receipt Date'), int(seller.delay)))
            //         delay_description.append((_('Vendor Lead Time'), _('+ %d day(s)', seller.delay)))
            // else:
            //     manufacture_delay = bom.produce_delay
            //     delays['total_delay'] += manufacture_delay
            //     # set manufacture_delay to purchase_delay so that PO can be created with correct date
            //     delays['purchase_delay'] += manufacture_delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Receipt Date'), manufacture_delay))
            //         delay_description.append((_('Manufacturing Lead Time'), _('+ %d day(s)', manufacture_delay)))
            //     days_to_order = bom.days_to_prepare_mo
            //     delays['total_delay'] += days_to_order
            //     # add dtpmo to purchase_delay so that PO can be created with correct date
            //     delays['purchase_delay'] += days_to_order
            //     if not bypass_delay_description:
            //         delay_description.append((_('Production Start Date'), days_to_order))
            //         delay_description.append((_('Days to Supply Components'), _('+ %d day(s)', days_to_order)))
            // 
            // for key, value in extra_delays.items():
            //     delays[key] += value
            // return delays, delay_description + extra_delay_description
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """Add the supplier delay to the cumulative delay and cumulative description.
            // """
            // delays, delay_description = super()._get_lead_days(product, **values)
            // bypass_delay_description = self.env.context.get('bypass_delay_description')
            // buy_rule = self.filtered(lambda r: r.action == 'buy')
            // seller = 'supplierinfo' in values and values['supplierinfo'] or product.with_company(buy_rule.company_id)._select_seller(quantity=None)
            // if not buy_rule:
            //     return delays, delay_description
            // if not seller:
            //     delays['total_delay'] += 365
            //     delays['no_vendor_found_delay'] += 365
            //     if not bypass_delay_description:
            //         delay_description.append((_('No Vendor Found'), _('+ %s day(s)', 365)))
            //     return delays, delay_description
            // buy_rule.ensure_one()
            // if not self.env.context.get('ignore_vendor_lead_time'):
            //     supplier_delay = seller[:1].delay
            //     delays['total_delay'] += supplier_delay
            //     delays['purchase_delay'] += supplier_delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Receipt Date'), supplier_delay))
            //         delay_description.append((_('Vendor Lead Time'), _('+ %d day(s)', supplier_delay)))
            // days_to_order = buy_rule.company_id.days_to_purchase
            // delays['total_delay'] += days_to_order
            // if not bypass_delay_description:
            //     delay_description.append((_('Order Deadline'), days_to_order))
            //     delay_description.append((_('Days to Purchase'), _('+ %d day(s)', days_to_order)))
            // return delays, delay_description
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """Returns the cumulative delay and its description encountered by a
            // procurement going through the rules in `self`.
            // 
            // :param product: the product of the procurement
            // :type product: :class:`~odoo.addons.product.models.product.ProductProduct`
            // :return: the cumulative delay and cumulative delay's description
            // :rtype: tuple[defaultdict(float), list[str, str]]
            // """
            // # FIXME : ensure one product or make the method work with multiple products
            // _ = self.env._
            // delays = defaultdict(float)
            // delay_description = []
            // bypass_delay_description = self.env.context.get('bypass_delay_description')
            // # Check if the rules have lead time
            // delaying_rules = self.filtered(lambda r: r.action in ['pull', 'pull_push'] and r.delay)
            // if delaying_rules:
            //     delays['total_delay'] += sum(delaying_rules.mapped('delay'))
            //     if not bypass_delay_description:
            //         delay_description = [
            //             (_('Delay on %s', rule.name), _('+ %d day(s)', rule.delay))
            //             for rule in delaying_rules
            //         ]
            // # Check if there's a horizon set
            // bypass_global_horizon_days = self.env.context.get('bypass_global_horizon_days')
            // if bypass_global_horizon_days:
            //     return delays, delay_description
            // global_horizon_days = self.env['stock.warehouse.orderpoint'].get_horizon_days()
            // if global_horizon_days:
            //     delays['horizon_time'] += global_horizon_days
            //     if not bypass_delay_description:
            //         delay_description.append((_('Time Horizon'), _('+ %d day(s)', global_horizon_days)))
            // return delays, delay_description
            */
            return default;
        }

        protected async Task<StockRule> GetMatchingBomInternalAsync(Guid product_id, Guid company_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_matching_bom(self, product_id, company_id, values):
            // if values.get('bom_id', False):
            //     return values['bom_id']
            // if values.get('orderpoint_id', False) and values['orderpoint_id'].bom_id:
            //     return values['orderpoint_id'].bom_id
            // bom = self.env['mrp.bom']._bom_find(product_id, picking_type=self.picking_type_id, bom_type='normal', company_id=company_id.id)[product_id]
            // if bom:
            //     return bom
            // return self.env['mrp.bom']._bom_find(product_id, picking_type=False, bom_type='normal', company_id=company_id.id)[product_id]
            */
            return default;
        }

        protected async Task<StockRule> GetMatchingSupplierInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_matching_supplier(self, product_id, product_qty, product_uom, company_id, values):
            // supplier = False
            // # Get the schedule date in order to find a valid seller
            // if 'date_planned' in values:
            //     date = max(fields.Datetime.from_string(values['date_planned']).date(), fields.Date.today())
            // else:
            //     date = None
            // 
            // if values.get('supplierinfo_id'):
            //     supplier = values['supplierinfo_id']
            // elif values.get('orderpoint_id') and values['orderpoint_id'].supplier_id:
            //     supplier = values['orderpoint_id'].supplier_id
            // else:
            //     supplier = product_id.with_company(company_id.id)._select_seller(
            //         partner_id=self._get_partner_id(values, self),
            //         quantity=product_qty,
            //         date=date,
            //         uom_id=product_uom,
            //         params={'force_uom': values.get('force_uom')},
            //     )
            // 
            // # Fall back on a supplier for which no price may be defined. Not ideal, but better than
            // # blocking the user.
            // supplier = supplier or product_id._prepare_sellers(False).filtered(
            //     lambda s: not s.company_id or s.company_id == company_id
            // )[:1]
            // 
            // return supplier
            */
            return default;
        }

        protected async Task<StockRule> GetMessageDictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_message_dict(self):
            // message_dict = super(StockRule, self)._get_message_dict()
            // source, destination, direct_destination, operation = self._get_message_values()
            // manufacture_message = _('When products are needed in <b>%s</b>, <br/> a manufacturing order is created to fulfill the need.', destination)
            // if self.location_src_id:
            //     manufacture_message += _(' <br/><br/> The components will be taken from <b>%s</b>.', source)
            // if direct_destination and not self.location_dest_from_rule:
            //     manufacture_message += _(' <br/><br/> The manufactured products will be moved towards <b>%(destination)s</b>, <br/> as specified from <b>%(operation)s</b> destination.', destination=direct_destination, operation=operation)
            // message_dict['manufacture'] = manufacture_message
            // return message_dict
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_message_dict(self):
            // message_dict = super(StockRule, self)._get_message_dict()
            // __, destination, __, __ = self._get_message_values()
            // message_dict.update({
            //     'buy': _('When products are needed in <b>%s</b>, <br/> '
            //              'a request for quotation is created to fulfill the need.<br/>'
            //              'Note: This rule will be used in combination with the rules<br/>'
            //              'of the reception route(s)', destination)
            // })
            // return message_dict
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_message_dict(self):
            // """ Return a dict with the different possible message used for the
            // rule message. It should return one message for each stock.rule action
            // (except push and pull). This function is override in mrp and
            // purchase_stock in order to complete the dictionary.
            // """
            // message_dict = {}
            // source, destination, direct_destination, operation = self._get_message_values()
            // if self.action in ('push', 'pull', 'pull_push'):
            //     suffix = ""
            //     if self.action in ('pull', 'pull_push') and direct_destination and not self.location_dest_from_rule:
            //         suffix = _("<br>The products will be moved towards <b>%(destination)s</b>, <br/> as specified from <b>%(operation)s</b> destination.", destination=direct_destination, operation=operation)
            //     if self.procure_method == 'make_to_order' and self.location_src_id:
            //         suffix += _("<br>A need is created in <b>%s</b> and a rule will be triggered to fulfill it.", source)
            //     if self.procure_method == 'mts_else_mto' and self.location_src_id:
            //         suffix += _("<br>If the products are not available in <b>%s</b>, a rule will be triggered to bring the missing quantity in this location.", source)
            //     message_dict = {
            //         'pull': _(
            //             'When products are needed in <b>%(destination)s</b>, <br> <b>%(operation)s</b> are created from <b>%(source_location)s</b> to fulfill the need. %(suffix)s',
            //             destination=destination,
            //             operation=operation,
            //             source_location=source,
            //             suffix=suffix,
            //         ),
            //         'push': _(
            //             'When products arrive in <b>%(source_location)s</b>, <br> <b>%(operation)s</b> are created to send them to <b>%(destination)s</b>.',
            //             source_location=source,
            //             operation=operation,
            //             destination=destination,
            //         ),
            //     }
            // return message_dict
            */
            return default;
        }

        protected async Task<StockRule> GetMessageValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_message_values(self):
            // """ Return the source, destination and picking_type applied on a stock
            // rule. The purpose of this function is to avoid code duplication in
            // _get_message_dict functions since it often requires those data.
            // """
            // source = self.location_src_id and self.location_src_id.display_name or _('Source Location')
            // destination = self.location_dest_id and self.location_dest_id.display_name or _('Destination Location')
            // direct_destination = self.picking_type_id and self.picking_type_id.default_location_dest_id != self.location_dest_id and self.picking_type_id.default_location_dest_id.display_name
            // operation = self.picking_type_id and self.picking_type_id.name or _('Operation Type')
            // return source, destination, direct_destination, operation
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetMovesToAssignDomainInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_moves_to_assign_domain(self, company_id):
            // domain = super()._get_moves_to_assign_domain(company_id)
            // return Domain(domain) & Domain('production_id', '=', False)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_moves_to_assign_domain(self, company_id):
            // return Domain([
            //     ('company_id', '=?', company_id),
            //     ('state', 'in', ['confirmed', 'partially_available']),
            //     ('product_uom_qty', '!=', 0.0),
            //     '|',
            //         ('reservation_date', '<=', fields.Date.today()),
            //         ('picking_type_id.reservation_method', '=', 'at_confirm'),
            // ])
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetOrderpointDomainInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_orderpoint_domain(self, company_id=False):
            // domain = [('trigger', '=', 'auto'), ('product_id.active', '=', True)]
            // if company_id:
            //     domain += [('company_id', '=', company_id)]
            // return domain
            */
            return default;
        }

        protected async Task<StockRule> GetPartnerIdInternalAsync(object values, object rule)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_partner_id(self, values, rule):
            // return values.get("supplierinfo_name") or (values.get("force_uom") and values.get("partner"))
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_partner_id(self, values, rule):
            // route = self.env.ref('stock_dropshipping.route_drop_shipping', raise_if_not_found=False)
            // if route and rule.route_id == route:
            //     return False
            // return super()._get_partner_id(values, rule)
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetProcurementsToMergeGroupbyInternalAsync(object procurement)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_procurements_to_merge_groupby(self, procurement):
            // # Do not group procument from different orderpoint. 1. _quantity_in_progress
            // # directly depends from the orderpoint_id on the line. 2. The stock move
            // # generated from the order line has the orderpoint's location as
            // # destination location. In case of move_dest_ids those two points are not
            // # necessary anymore since those values are taken from destination moves.
            // return procurement.product_id, procurement.product_uom, procurement.values['propagate_cancel'],\
            //     procurement.values.get('product_description_variants'),\
            //     (procurement.values.get('orderpoint_id') and not procurement.values.get('move_dest_ids')) and procurement.values['orderpoint_id']
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_procurements_to_merge_groupby(self, procurement):
            // """ Do not group purchase order line if they are linked to different
            // sale order line. The purpose is to compute the delivered quantities.
            // """
            // return procurement.values.get('sale_line_id'), super(StockRule, self)._get_procurements_to_merge_groupby(procurement)
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetProcurementsToMergeInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_procurements_to_merge(self, procurements):
            // """ Get a list of procurements values and create groups of procurements
            // that would use the same purchase order line.
            // params procurements_list list: procurements requests (not ordered nor
            // sorted).
            // return list: procurements requests grouped by their product_id.
            // """
            // return [pro_g for __, pro_g in groupby(procurements, key=self._get_procurements_to_merge_groupby)]
            */
            return default;
        }

        protected async Task<StockRule> GetPushNewDateInternalAsync(object move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_push_new_date(self, move):
            // """ Get the new date for a push rule.
            // 
            // :param move: The stock move being processed
            // :type move: stock.move
            // :return: The new date as a string
            // :rtype: str
            // """
            // return fields.Datetime.to_string(move.date + relativedelta(days=self.delay))
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetPushRuleInternalAsync(Guid product_id, Guid location_dest_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_push_rule(self, product_id, location_dest_id, values):
            // """ Find a push rule for the location_dest_id, with a fallback to the parent locations if none could be found.
            // """
            // found_rule = self.env['stock.rule']
            // location = location_dest_id
            // while (not found_rule) and location:
            //     domain = Domain('location_src_id', '=', location.id) & Domain('action', 'in', ('push', 'pull_push'))
            //     if dom := values.get('domain'):
            //         domain &= Domain(dom)
            //     found_rule = self._search_rule(values.get('route_ids'), values.get('packaging_uom_id'), product_id, values.get('warehouse_id'), domain)
            //     location = location.location_id
            // return found_rule
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetRuleDomainInternalAsync(object location, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_rule_domain(self, locations, values):
            // location_ids = locations.ids
            // # If the method is called to find rules towards the Inter-company location, also add the 'Customer' location in the domain.
            // # This is to avoid having to duplicate every rules that deliver to Customer to have the Inter-company part.
            // if self._check_intercomp_location(locations):
            //     location_ids.append(self.env.ref('stock.stock_location_customers', raise_if_not_found=False).id)
            // domain = Domain('location_dest_id', 'in', location_ids) & Domain('action', '!=', 'push')
            // # In case the method is called by the superuser, we need to restrict the rules to the
            // # ones of the company. This is not useful as a regular user since there is a record
            // # rule to filter out the rules based on the company.
            // if self.env.su and values.get('company_id'):
            //     company_ids = set(values.get('company_id').ids)
            //     if values.get('route_ids'):
            //         company_ids |= set(values['route_ids'].company_id.ids)
            //     domain_company = ['|', ('company_id', '=', False), ('company_id', 'child_of', list(company_ids))]
            //     domain &= Domain(domain_company)
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_rule_domain(self, location, values):
            // domain = super()._get_rule_domain(location, values)
            // if 'sale_line_id' in values and values.get('company_id'):
            //     domain = Domain.AND([domain, [('company_id', '=', values['company_id'].id)]])
            // return domain
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetRuleInternalAsync(Guid product_id, Guid location_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_rule(self, product_id, location_id, values):
            // """ Find a pull rule for the location_id, fallback on the parent
            // locations if it could not be found.
            // """
            // result = self.env['stock.rule']
            // if not location_id:
            //     return result
            // locations = location_id
            // # Get the location hierarchy, starting from location_id up to its root location.
            // while locations[-1].location_id:
            //     locations |= locations[-1].location_id
            // domain = self._get_rule_domain(locations, values)
            // # Get a mapping (location_id, route_id) -> warehouse_id -> rule_id
            // rule_dict = self._search_rule_for_warehouses(
            //     values.get("route_ids", False),
            //     values.get("packaging_uom_id", False),
            //     product_id,
            //     values.get("warehouse_id", locations.warehouse_id),
            //     domain,
            // )
            // 
            // def extract_rule(rule_dict, route_ids, warehouse_id, location_dest_id):
            //     rule = self.env['stock.rule']
            //     for route_id in sorted(route_ids, key=lambda r: (r not in product_id.route_ids, r.sequence)):
            //         sub_dict = rule_dict.get((location_dest_id.id, route_id.id))
            //         if not sub_dict:
            //             continue
            //         if not warehouse_id:
            //             rule = sub_dict[next(iter(sub_dict))]
            //         else:
            //             rule = sub_dict.get(warehouse_id.id)
            //             rule = rule or sub_dict[False]
            //         if rule:
            //             break
            //     return rule
            // 
            // def get_rule_for_routes(rule_dict, route_ids, packaging_uom_id, product_id, warehouse_id, location_dest_id):
            //     res = self.env['stock.rule']
            //     if route_ids:
            //         res = extract_rule(rule_dict, route_ids, warehouse_id, location_dest_id)
            //     if not res and packaging_uom_id:
            //         res = extract_rule(rule_dict, packaging_uom_id.package_type_id.route_ids, warehouse_id, location_dest_id)
            //     if not res:
            //         res = extract_rule(rule_dict, product_id.route_ids | product_id.categ_id.total_route_ids, warehouse_id, location_dest_id)
            //     if not res and warehouse_id:
            //         res = extract_rule(rule_dict, warehouse_id.route_ids, warehouse_id, location_dest_id)
            //     return res
            // 
            // location = location_id
            // # Go through the location hierarchy again, this time breaking at the first valid stock.rule found
            // # in rules_by_location.
            // inter_comp_location_checked = False
            // while (not result) and location:
            //     candidate_locations = location
            //     if not inter_comp_location_checked and self._check_intercomp_location(location):
            //         # Add the intercomp location to candidate_locations as the intercomp domain was added
            //         # above in the call to _get_rule_domain.
            //         inter_comp_location = self.env.ref('stock.stock_location_customers', raise_if_not_found=False)
            //         candidate_locations |= inter_comp_location
            //         inter_comp_location_checked = True
            //     for candidate_location in candidate_locations:
            //         result = get_rule_for_routes(
            //             rule_dict,
            //             values.get("route_ids", self.env['stock.route']),
            //             values.get("packaging_uom_id", self.env['uom.uom']),
            //             product_id,
            //             values.get("warehouse_id", candidate_location.warehouse_id),
            //             candidate_location,
            //         )
            //         if result:
            //             break
            //     else:
            //         location = location.location_id
            // return result
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetSchedulerTasksToDoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // return super()._get_scheduler_tasks_to_do() + 1
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_rule.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // return super()._get_scheduler_tasks_to_do() + 1
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // """ Number of task to be executed by the stock scheduler. This number will be given in log
            // message to know how many tasks succeeded."""
            // return 3
            */
            return default;
        }

        protected async Task<StockRule> GetStockMoveValuesInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_stock_move_values(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values):
            // res = super()._get_stock_move_values(product_id, product_qty, product_uom, location_id, name, origin, company_id, values)
            // res['production_group_id'] = values.get('production_group_id')
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_rule.py) ---
            // def _get_stock_move_values(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values):
            // move_values = super()._get_stock_move_values(product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values)
            // if not move_values.get('partner_id'):
            //     if values.get('move_dest_ids') and values['move_dest_ids'].raw_material_production_id.subcontractor_id:
            //         move_values['partner_id'] = values['move_dest_ids'].raw_material_production_id.subcontractor_id.id
            // return move_values
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: stock_rule.py) ---
            // def _get_stock_move_values(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values):
            // move_values = super()._get_stock_move_values(product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values)
            // if (sol_id := values.get('sale_line_id')) is not None and 'product_id' in move_values:
            //     # if the SOL is for a kit
            //     sol = self.env['sale.order.line'].browse(sol_id)
            //     if move_values['product_id'] != sol.product_id.id:
            //         active_moves = sol.move_ids.filtered(lambda m: m.state != 'cancel')
            //         bom_line_id = active_moves.bom_line_id.filtered(
            //             lambda bl: bl.product_id.id == move_values.get('product_id')
            //         )[:1].id
            //         if bom_line_id:
            //             move_values['bom_line_id'] = bom_line_id
            // return move_values
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_stock_move_values(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values):
            // ''' Returns a dictionary of values that will be used to create a stock move from a procurement.
            // This function assumes that the given procurement has a rule (action == 'pull' or 'pull_push') set on it.
            // 
            // :rtype: dictionary
            // '''
            // 
            // date_scheduled = fields.Datetime.to_string(
            //     fields.Datetime.from_string(values['date_planned']) - relativedelta(days=self.delay or 0)
            // )
            // date_deadline = values.get('date_deadline') and (fields.Datetime.to_datetime(values['date_deadline']) - relativedelta(days=self.delay or 0)) or False
            // partner = self.partner_address_id or values.get('partner', False)
            // # it is possible that we've already got some move done, so check for the done qty and create
            // # a new move with the correct qty
            // qty_left = product_qty
            // 
            // move_dest_ids = values.get('move_dest_ids') and [(4, x.id) for x in values['move_dest_ids']] or []
            // 
            // # when create chained moves for inter-warehouse transfers, set the warehouses as partners
            // if not partner and move_dest_ids:
            //     move_dest = values['move_dest_ids']
            //     if location_dest_id == company_id.internal_transit_location_id:
            //         partners = move_dest.location_dest_id.warehouse_id.partner_id
            //         if len(partners) == 1:
            //             partner = partners
            //         move_dest.partner_id = self.location_src_id.warehouse_id.partner_id or self.company_id.partner_id
            // 
            // # If the quantity is negative the move should be considered as a refund
            // if product_uom.compare(product_qty, 0.0) < 0:
            //     values['to_refund'] = True
            // 
            // move_values = {
            //     'company_id': self.company_id.id or self.location_src_id.company_id.id or self.location_dest_id.company_id.id or company_id.id,
            //     'product_id': product_id.id,
            //     'product_uom': product_uom.id,
            //     'product_uom_qty': qty_left,
            //     'partner_id': partner.id if partner else False,
            //     'location_id': self.location_src_id.id,
            //     'location_final_id': location_dest_id.id,
            //     'move_dest_ids': move_dest_ids,
            //     'rule_id': self.id,
            //     'reference_ids': [Command.set(values.get('reference_ids', self.env['stock.reference']).ids)],
            //     'procure_method': self.procure_method,
            //     'origin': origin,
            //     'picking_type_id': self.picking_type_id.id,
            //     'procurement_values': self._serialize_procurement_values(values),
            //     'route_ids': [Command.clear()] + [Command.link(route.id) for route in values.get('route_ids', [])],
            //     'never_product_template_attribute_value_ids': values.get('never_product_template_attribute_value_ids'),
            //     'warehouse_id': self.warehouse_id.id,
            //     'date': date_scheduled,
            //     'date_deadline': date_deadline,
            //     'propagate_cancel': self.propagate_cancel,
            //     'priority': values.get('priority', "0"),
            //     'orderpoint_id': values.get('orderpoint_id') and values['orderpoint_id'].id,
            // }
            // if self.location_dest_from_rule:
            //     move_values['location_dest_id'] = self.location_dest_id.id
            // for field in self._get_custom_move_fields():
            //     if field in values:
            //         move_values[field] = values.get(field)
            // return move_values
            */
            return default;
        }

        protected async Task<StockRule> MakeMoGetDomainInternalAsync(object procurement, object bom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _make_mo_get_domain(self, procurement, bom):
            // domain = (
            //     ('bom_id', '=', bom.id),
            //     ('product_id', '=', procurement.product_id.id),
            //     ('state', 'in', ['draft', 'confirmed']),
            //     ('is_planned', '=', False),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('company_id', '=', procurement.company_id.id),
            //     ('user_id', '=', False),
            //     ('reference_ids', '=', procurement.values.get('reference_ids', self.env['stock.reference']).ids),
            // )
            // if procurement.values.get('orderpoint_id'):
            //     procurement_date = datetime.combine(
            //         fields.Date.to_date(procurement.values['date_planned']) - relativedelta(days=int(bom.produce_delay)),
            //         datetime.max.time()
            //     )
            //     domain += ('|',
            //                '&', ('state', '=', 'draft'), ('date_deadline', '<=', procurement_date),
            //                '&', ('state', '=', 'confirmed'), ('date_start', '<=', procurement_date))
            // return domain
            */
            return default;
        }

        protected async Task<StockRule> MakePoGetDomainInternalAsync(Guid company_id, object values, object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_rule.py) ---
            // def _make_po_get_domain(self, company_id, values, partner):
            // domain = super()._make_po_get_domain(company_id, values, partner)
            // if values.get('partner_id', False):
            //     domain += (('dest_address_id', '=', values.get('partner_id')),)
            // return domain
            --- ODOO METHOD SOURCE (MODULE: project_purchase_stock, FILE: stock_rule.py) ---
            // def _make_po_get_domain(self, company_id, values, partner):
            // domain = super()._make_po_get_domain(company_id, values, partner)
            // domain += (('project_id', '=', values.get('project_id', False)),)
            // return domain
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py) ---
            // def _make_po_get_domain(self, company_id, values, partner):
            // domain = super(StockRule, self)._make_po_get_domain(company_id, values, partner)
            // if 'supplier' in values and values['supplier'].purchase_requisition_id:
            //     domain += (
            //         ('requisition_id', '=', values['supplier'].purchase_requisition_id.id),
            //     )
            // return domain
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _make_po_get_domain(self, company_id, values, partner):
            // currency = ('supplier' in values and values['supplier'].currency_id) or \
            //            partner.with_company(company_id).property_purchase_currency_id or \
            //            company_id.currency_id
            // domain = (
            //     ('partner_id', '=', partner.id),
            //     ('state', '=', 'draft'),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('company_id', '=', company_id.id),
            //     ('user_id', '=', partner.buyer_id.id),
            //     ('currency_id', '=', currency.id),
            // )
            // if partner.group_rfq == 'default':
            //     if values.get('reference_ids'):
            //         domain += (('reference_ids', 'in', tuple(values['reference_ids'].ids)),)
            // date_planned = fields.Datetime.from_string(values['date_planned'])
            // if partner.group_rfq == 'day':
            //     start_dt = datetime.combine(date_planned, datetime.min.time())
            //     end_dt = datetime.combine(date_planned, datetime.max.time())
            //     domain += (('date_planned', '>=', start_dt), ('date_planned', '<=', end_dt))
            // if partner.group_rfq == 'week':
            //     if partner.group_on == 'default':
            //         start_dt = datetime.combine(date_planned - relativedelta(days=date_planned.isoweekday()), datetime.min.time())
            //         end_dt = datetime.combine(date_planned + relativedelta(days=6 - date_planned.isoweekday()), datetime.max.time())
            //         domain += (('date_planned', '>=', start_dt), ('date_planned', '<=', end_dt))
            //     else:
            //         delta_days = (7 + int(partner.group_on) - date_planned.isoweekday()) % 7
            //         date = date_planned + relativedelta(days=delta_days)
            //         start_dt = datetime.combine(date, datetime.min.time())
            //         end_dt = datetime.combine(date, datetime.max.time())
            //         domain += (('date_planned', '>=', start_dt), ('date_planned', '<=', end_dt))
            // 
            // return domain
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> MergeProcurementsInternalAsync(object procurements_to_merge)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _merge_procurements(self, procurements_to_merge):
            // """ Merge the quantity for procurements requests that could use the same
            // order line.
            // params similar_procurements list: list of procurements that have been
            // marked as 'alike' from _get_procurements_to_merge method.
            // return a list of procurements values where values of similar_procurements
            // list have been merged.
            // """
            // merged_procurements = []
            // for procurements in procurements_to_merge:
            //     quantity = 0
            //     move_dest_ids = self.env['stock.move']
            //     orderpoint_id = self.env['stock.warehouse.orderpoint']
            //     for procurement in procurements:
            //         if procurement.values.get('move_dest_ids'):
            //             move_dest_ids |= procurement.values['move_dest_ids']
            //         if not orderpoint_id and procurement.values.get('orderpoint_id'):
            //             orderpoint_id = procurement.values['orderpoint_id']
            //         quantity += procurement.product_qty
            //     # The merged procurement can be build from an arbitrary procurement
            //     # since they were mark as similar before. Only the quantity and
            //     # some keys in values are updated.
            //     values = dict(procurement.values)
            //     values.update({
            //         'move_dest_ids': move_dest_ids,
            //         'orderpoint_id': orderpoint_id,
            //     })
            //     merged_procurement = self.env['stock.rule'].Procurement(
            //         procurement.product_id, quantity, procurement.product_uom,
            //         procurement.location_id, procurement.name, procurement.origin,
            //         procurement.company_id, values
            //     )
            //     merged_procurements.append(merged_procurement)
            // return merged_procurements
            */
            return default;
        }

        protected async Task<StockRule> NotifyResponsibleInternalAsync(object procurement)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_rule.py) ---
            // def _notify_responsible(self, procurement):
            // super()._notify_responsible(procurement)
            // origin_order = self.env.context.get('po_to_notify')
            // if origin_order:
            //     notified_users = procurement.product_id.responsible_id.partner_id | origin_order.user_id.partner_id
            //     self._post_vendor_notification(origin_order, notified_users, procurement.product_id)
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_rule.py) ---
            // def _notify_responsible(self, procurement):
            // super()._notify_responsible(procurement)
            // origin_orders = procurement.values.get('group_id').mrp_production_ids if procurement.values.get('group_id') else False
            // if origin_orders:
            //     notified_users = procurement.product_id.responsible_id.partner_id | origin_orders.user_id.partner_id
            //     self._post_vendor_notification(origin_orders, notified_users, procurement.product_id)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _notify_responsible(self, procurement):
            // pass
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: stock_rule.py) ---
            // def _notify_responsible(self, procurement):
            // super()._notify_responsible(procurement)
            // origin_orders = procurement.values.get('reference_ids').sale_ids if procurement.values.get('reference_ids') else False
            // if origin_orders:
            //     notified_users = procurement.product_id.responsible_id.partner_id | origin_orders.user_id.partner_id
            //     self._post_vendor_notification(origin_orders, notified_users, procurement.product_id)
            */
            return default;
        }

        protected async Task<StockRule> OnchangeActionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _onchange_action(self):
            // if self.action == 'buy':
            //     self.location_src_id = False
            */
            return default;
        }

        protected async Task<StockRule> OnchangePickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _onchange_picking_type(self):
            // """ Modify locations to the default picking type's locations source and
            // destination.
            // Enable the delay alert if the picking type is a delivery
            // """
            // self.location_src_id = self.picking_type_id.default_location_src_id.id
            // self.location_dest_id = self.picking_type_id.default_location_dest_id.id
            */
            return default;
        }

        protected async Task<StockRule> OnchangeRouteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _onchange_route(self):
            // """ Ensure that the rule's company is the same than the route's company. """
            // if self.route_id.company_id:
            //     self.company_id = self.route_id.company_id
            // if self.picking_type_id.warehouse_id.company_id != self.route_id.company_id:
            //     self.picking_type_id = False
            */
            return default;
        }

        protected async Task<StockRule> PostVendorNotificationInternalAsync(object records_to_notify, object users_to_notify, object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _post_vendor_notification(self, records_to_notify, users_to_notify, product):
            // notification_msg = Markup(" ").join(Markup("%s") % user._get_html_link(f'@{user.name}') for user in users_to_notify)
            // notification_msg += Markup("<br/>%s <strong>%s</strong>, %s") % (_("No supplier has been found to replenish"), product.display_name, _("this product should be manually replenished."))
            // records_to_notify.message_post(body=notification_msg, partner_ids=users_to_notify.ids)
            */
            return default;
        }

        protected async Task<StockRule> PrepareMoValsInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values, object bom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _prepare_mo_vals(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, bom):
            // date_planned = self._get_date_planned(bom, values)
            // date_deadline = values.get('date_deadline') or date_planned + relativedelta(days=bom.produce_delay)
            // picking_type = bom.picking_type_id or self.picking_type_id
            // mo_values = {
            //     'origin': origin,
            //     'product_id': product_id.id,
            //     'product_description_variants': values.get('product_description_variants'),
            //     'never_product_template_attribute_value_ids': values.get('never_product_template_attribute_value_ids'),
            //     'product_qty': product_uom._compute_quantity(product_qty, bom.product_uom_id) if bom else product_qty,
            //     'product_uom_id': bom.product_uom_id.id if bom else product_uom.id,
            //     'location_src_id': picking_type.default_location_src_id.id,
            //     'location_dest_id': picking_type.default_location_dest_id.id or location_dest_id.id,
            //     'location_final_id': location_dest_id.id,
            //     'bom_id': bom.id,
            //     'date_deadline': date_deadline,
            //     'date_start': date_planned,
            //     'reference_ids': [Command.set(values.get('reference_ids', self.env['stock.reference']).ids)],
            //     'propagate_cancel': self.propagate_cancel,
            //     'orderpoint_id': values.get('orderpoint_id', False) and values.get('orderpoint_id').id,
            //     'picking_type_id': picking_type.id or values['warehouse_id'].manu_type_id.id,
            //     'company_id': company_id.id,
            //     'move_dest_ids': values.get('move_dest_ids') and [(4, x.id) for x in values['move_dest_ids']] or False,
            //     'user_id': False,
            // }
            // if self.location_dest_from_rule:
            //     mo_values['location_dest_id'] = self.location_dest_id.id
            // return mo_values
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: stock.py) ---
            // def _prepare_mo_vals(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values, bom):
            // res = super()._prepare_mo_vals(product_id, product_qty, product_uom, location_id, name, origin, company_id, values, bom)
            // if values.get('project_id'):
            //     res['project_id'] = values.get('project_id')
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_rule.py) ---
            // def _prepare_mo_vals(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values, bom):
            // res = super()._prepare_mo_vals(product_id, product_qty, product_uom, location_id, name, origin, company_id, values, bom)
            // if values.get('project_id'):
            //     res['project_id'] = values['project_id']
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: stock_rule.py) ---
            // def _prepare_mo_vals(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, bom):
            // res = super()._prepare_mo_vals(product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, bom)
            // if values.get('sale_line_id'):
            //     res['sale_line_id'] = values['sale_line_id']
            // return res
            */
            return default;
        }

        protected async Task<StockRule> PreparePurchaseOrderInternalAsync(Guid company_id, object origins, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_rule.py) ---
            // def _prepare_purchase_order(self, company_id, origins, values):
            // if 'partner_id' not in values[0] \
            //     and (company_id.subcontracting_location_id.parent_path in self.location_dest_id.parent_path
            //          or self.location_dest_id.is_subcontract()):
            //     move = values[0].get('move_dest_ids')
            //     if move and move.raw_material_production_id.subcontractor_id:
            //         values[0]['partner_id'] = move.raw_material_production_id.subcontractor_id.id
            // return super()._prepare_purchase_order(company_id, origins, values)
            --- ODOO METHOD SOURCE (MODULE: project_purchase_stock, FILE: stock_rule.py) ---
            // def _prepare_purchase_order(self, company_id, origins, values):
            // res = super()._prepare_purchase_order(company_id, origins, values)
            // if values[0].get('project_id'):
            //     res['project_id'] = values[0].get('project_id')
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py) ---
            // def _prepare_purchase_order(self, company_id, origins, values):
            // res = super(StockRule, self)._prepare_purchase_order(company_id, origins, values)
            // values = values[0]
            // res['partner_ref'] = values['supplier'].purchase_requisition_id.name
            // res['requisition_id'] = values['supplier'].purchase_requisition_id.id
            // if values['supplier'].purchase_requisition_id.currency_id:
            //     res['currency_id'] = values['supplier'].purchase_requisition_id.currency_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _prepare_purchase_order(self, company_id, origins, values):
            // """ Create a purchase order for procuremets that share the same domain
            // returned by _make_po_get_domain.
            // params values: values of procurements
            // params origins: procuremets origins to write on the PO
            // """
            // purchase_date = min([value.get('date_order') or fields.Datetime.from_string(value['date_planned']) - relativedelta(days=int(value['supplier'].delay)) for value in values])
            // 
            // # Since the procurements are grouped if they share the same domain for
            // # PO but the PO does not exist. In this case it will create the PO from
            // # the common procurements values. The common values are taken from an
            // # arbitrary procurement. In this case the first.
            // values = values[0]
            // partner = values['supplier'].partner_id
            // currency = values['supplier'].currency_id
            // 
            // fpos = self.env['account.fiscal.position'].with_company(company_id)._get_fiscal_position(partner)
            // 
            // return {
            //     'partner_id': partner.id,
            //     'user_id': partner.buyer_id.id,
            //     'picking_type_id': self.picking_type_id.id,
            //     'company_id': company_id.id,
            //     'currency_id': currency.id or partner.with_company(company_id).property_purchase_currency_id.id or company_id.currency_id.id,
            //     'dest_address_id': values.get('partner_id', False),
            //     'origin': ', '.join(origins),
            //     'payment_term_id': partner.with_company(company_id).property_supplier_payment_term_id.id,
            //     'date_order': purchase_date,
            //     'fiscal_position_id': fpos.id,
            //     'reference_ids': [Command.set(values.get('reference_ids', self.env['stock.reference']).ids)],
            // }
            */
            return default;
        }

        protected async Task<StockRule> PushPrepareMoveCopyValuesInternalAsync(object move_to_copy, object new_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _push_prepare_move_copy_values(self, move_to_copy, new_date):
            // new_move_vals = super()._push_prepare_move_copy_values(move_to_copy, new_date)
            // new_move_vals['production_group_id'] = move_to_copy.production_group_id.id
            // new_move_vals['production_id'] = False
            // return new_move_vals
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_rule.py) ---
            // def _push_prepare_move_copy_values(self, move_to_copy, new_date):
            // new_move_vals = super(StockRule, self)._push_prepare_move_copy_values(move_to_copy, new_date)
            // new_move_vals["is_subcontract"] = False
            // return new_move_vals
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _push_prepare_move_copy_values(self, move_to_copy, new_date):
            // res = super(StockRule, self)._push_prepare_move_copy_values(move_to_copy, new_date)
            // res['purchase_line_id'] = None
            // if self.location_dest_id.usage == "supplier":
            //     res['purchase_line_id'], res['partner_id'] = move_to_copy._get_purchase_line_and_partner_from_chain()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _push_prepare_move_copy_values(self, move_to_copy, new_date):
            // company_id = self.company_id.id
            // copied_quantity = move_to_copy.quantity
            // final_location_id = False
            // if move_to_copy.location_final_id and not move_to_copy.location_dest_id._child_of(move_to_copy.location_final_id):
            //     final_location_id = move_to_copy.location_final_id.id
            // if move_to_copy.product_uom.compare(move_to_copy.product_uom_qty, 0) < 0:
            //     copied_quantity = move_to_copy.product_uom_qty
            // if not company_id:
            //     company_id = self.sudo().warehouse_id and self.sudo().warehouse_id.company_id.id or self.sudo().picking_type_id.warehouse_id.company_id.id
            // new_move_vals = {
            //     'product_uom_qty': copied_quantity,
            //     'origin': move_to_copy.origin or move_to_copy.picking_id.name or "/",
            //     'location_id': move_to_copy.location_dest_id.id,
            //     'location_dest_id': self.location_dest_id.id,
            //     'location_final_id': final_location_id,
            //     'rule_id': self.id,
            //     'date': new_date,
            //     'date_deadline': move_to_copy.date_deadline,
            //     'company_id': company_id,
            //     'picking_id': False,
            //     'picking_type_id': self.picking_type_id.id,
            //     'propagate_cancel': self.propagate_cancel,
            //     'warehouse_id': self.warehouse_id.id or move_to_copy.location_dest_id.warehouse_id.id,
            //     'procure_method': 'make_to_order',
            // }
            // return new_move_vals
            */
            return default;
        }

        [ApiModel]
        public async Task<StockRule> RunAsync(StockRuleRunRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def run(self, procurements, raise_user_error=True):
            // """ If 'run' is called on a kit, this override is made in order to call
            // the original 'run' method with the values of the components of that kit.
            // """
            // procurements_without_kit = []
            // product_by_company = defaultdict(OrderedSet)
            // for procurement in procurements:
            //     product_by_company[procurement.company_id].add(procurement.product_id.id)
            // kits_by_company = {
            //     company: self.env['mrp.bom']._bom_find(self.env['product.product'].browse(product_ids), company_id=company.id, bom_type='phantom')
            //     for company, product_ids in product_by_company.items()
            // }
            // for procurement in procurements:
            //     bom_kit = kits_by_company[procurement.company_id].get(procurement.product_id)
            //     if bom_kit:
            //         order_qty = procurement.product_uom._compute_quantity(procurement.product_qty, bom_kit.product_uom_id, round=False)
            //         qty_to_produce = (order_qty / bom_kit.product_qty)
            //         _dummy, bom_sub_lines = bom_kit.explode(procurement.product_id, qty_to_produce, never_attribute_values=procurement.values.get("never_product_template_attribute_value_ids"))
            //         for bom_line, bom_line_data in bom_sub_lines:
            //             bom_line_uom = bom_line.product_uom_id
            //             quant_uom = bom_line.product_id.uom_id
            //             # recreate dict of values since each child has its own bom_line_id
            //             values = dict(procurement.values, bom_line_id=bom_line.id)
            //             component_qty, procurement_uom = bom_line_uom._adjust_uom_quantities(bom_line_data['qty'], quant_uom)
            //             procurements_without_kit.append(self.env['stock.rule'].Procurement(
            //                 bom_line.product_id, component_qty, procurement_uom,
            //                 procurement.location_id, procurement.name,
            //                 procurement.origin, procurement.company_id, values))
            //     else:
            //         procurements_without_kit.append(procurement)
            // return super().run(procurements_without_kit, raise_user_error=raise_user_error)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def run(self, procurements, raise_user_error=True):
            // wh_by_comp = dict()
            // for procurement in procurements:
            //     routes = procurement.values.get('route_ids')
            //     if routes and any(r.action == 'buy' for r in routes.rule_ids):
            //         company = procurement.company_id
            //         if company not in wh_by_comp:
            //             wh_by_comp[company] = self.env['stock.warehouse'].search([('company_id', '=', company.id)])
            //         wh = wh_by_comp[company]
            //         procurement.values['route_ids'] |= wh.reception_route_id
            // return super().run(procurements, raise_user_error=raise_user_error)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def run(self, procurements, raise_user_error=True):
            // """Fulfil `procurements` with the help of stock rules.
            // 
            // Procurements are needs of products at a certain location. To fulfil
            // these needs, we need to create some sort of documents (`stock.move`
            // by default, but extensions of `_run_` methods allow to create every
            // type of documents).
            // 
            // :param procurements: the description of the procurement
            // :type procurements: list of `~odoo.addons.stock.models.stock_rule.ProcurementGroup.Procurement`
            // :param raise_user_error: will raise either an UserError or a ProcurementException
            // :type raise_user_error: boolan, optional
            // :raises UserError: if `raise_user_error` is True and a procurement isn't fulfillable
            // :raises ProcurementException: if `raise_user_error` is False and a procurement isn't fulfillable
            // """
            // 
            // def raise_exception(procurement_errors):
            //     if raise_user_error:
            //         dummy, errors = zip(*procurement_errors)
            //         raise UserError('\n'.join(errors))
            //     else:
            //         raise ProcurementException(procurement_errors)
            // actions_to_run = defaultdict(list)
            // procurement_errors = []
            // for procurement in procurements:
            //     procurement.values.setdefault('company_id', procurement.location_id.company_id)
            //     procurement.values.setdefault('priority', '0')
            //     procurement.values.setdefault('date_planned', procurement.values.get('date_planned', False) or fields.Datetime.now())
            //     if self._skip_procurement(procurement):
            //         continue
            //     rule = self._get_rule(procurement.product_id, procurement.location_id, procurement.values)
            //     if not rule:
            //         error = _('No rule has been found to replenish "%(product)s" in "%(location)s".\nVerify the routes configuration on the product.',
            //             product=procurement.product_id.display_name, location=procurement.location_id.display_name)
            //         procurement_errors.append((procurement, error))
            //     else:
            //         action = 'pull' if rule.action == 'pull_push' else rule.action
            //         actions_to_run[action].append((procurement, rule))
            // 
            // if procurement_errors:
            //     raise_exception(procurement_errors)
            // 
            // for action, procurements in actions_to_run.items():
            //     if hasattr(self.env['stock.rule'], '_run_%s' % action):
            //         try:
            //             getattr(self.env['stock.rule'], '_run_%s' % action)(procurements)
            //         except ProcurementException as e:
            //             procurement_errors += e.procurement_exceptions
            //     else:
            //         _logger.error("The method _run_%s doesn't exist on the procurement rules" % action)
            // 
            // if procurement_errors:
            //     raise_exception(procurement_errors)
            // return True
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunBuyInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _run_buy(self, procurements):
            // procurements_by_po_domain = defaultdict(list)
            // errors = []
            // for procurement, rule in procurements:
            //     company_id = rule.company_id or procurement.company_id
            // 
            //     supplier = rule._get_matching_supplier(
            //         procurement.product_id, procurement.product_qty, procurement.product_uom,
            //         company_id, procurement.values
            //     )
            // 
            //     if not supplier and self.env.context.get('from_orderpoint'):
            //         msg = _('There is no matching vendor price to generate the purchase order for product %s (no vendor defined, minimum quantity not reached, dates not valid, ...). Go on the product form and complete the list of vendors.', procurement.product_id.display_name)
            //         errors.append((procurement, msg))
            //     elif not supplier:
            //         # If the supplier is not set, we cannot create a PO.
            //         moves = procurement.values.get('move_dest_ids') or self.env['stock.move']
            //         if moves.propagate_cancel:
            //             moves._action_cancel()
            //         moves.procure_method = 'make_to_stock'
            //         self._notify_responsible(procurement)
            //         continue
            // 
            //     partner = supplier.partner_id
            //     # we put `supplier_info` in values for extensibility purposes
            //     procurement.values['supplier'] = supplier
            //     procurement.values['propagate_cancel'] = rule.propagate_cancel
            // 
            //     domain = rule._make_po_get_domain(company_id, procurement.values, partner)
            //     procurements_by_po_domain[domain].append((procurement, rule))
            // 
            // if errors:
            //     raise ProcurementException(errors)
            // 
            // for domain, procurements_rules in procurements_by_po_domain.items():
            //     # Get the procurements for the current domain.
            //     # Get the rules for the current domain. Their only use is to create
            //     # the PO if it does not exist.
            //     procurements, rules = zip(*procurements_rules)
            // 
            //     # Get the set of procurement origin for the current domain.
            //     origins = set([p.origin for p in procurements if p.origin])
            //     # Check if a PO exists for the current domain.
            //     po = self.env['purchase.order'].sudo().search([dom for dom in domain], limit=1)
            //     company_id = rules[0].company_id or procurements[0].company_id
            //     if not po:
            //         positive_values = [p.values for p in procurements if p.product_uom.compare(p.product_qty, 0.0) >= 0]
            //         if positive_values:
            //             # We need a rule to generate the PO. However the rule generated
            //             # the same domain for PO and the _prepare_purchase_order method
            //             # should only uses the common rules's fields.
            //             vals = rules[0]._prepare_purchase_order(company_id, origins, positive_values)
            //             # The company_id is the same for all procurements since
            //             # _make_po_get_domain add the company in the domain.
            //             # We use SUPERUSER_ID since we don't want the current user to be follower of the PO.
            //             # Indeed, the current user may be a user without access to Purchase, or even be a portal user.
            //             po = self.env['purchase.order'].with_company(company_id).with_user(SUPERUSER_ID).create(vals)
            //     else:
            //         reference_ids = set()
            //         for procurement in procurements:
            //             reference_ids |= set(procurement.values.get('reference_ids', self.env['stock.reference']).ids)
            //         # If a purchase order is found, adapt its `origin` field.
            //         po.reference_ids = [Command.link(ref_id) for ref_id in reference_ids]
            //         if po.origin:
            //             missing_origins = origins - set(po.origin.split(', '))
            //             if missing_origins:
            //                 po.write({'origin': po.origin + ', ' + ', '.join(missing_origins)})
            //         else:
            //             po.write({'origin': ', '.join(origins)})
            // 
            //     procurements_to_merge = self._get_procurements_to_merge(procurements)
            //     procurements = self._merge_procurements(procurements_to_merge)
            // 
            //     po_lines_by_product = {}
            //     grouped_po_lines = groupby(po.order_line.filtered(lambda l: not l.display_type), key=lambda l: l.product_id.id)
            //     for product, po_lines in grouped_po_lines:
            //         po_lines_by_product[product] = self.env['purchase.order.line'].concat(*po_lines)
            //     po_line_values = []
            //     for procurement in procurements:
            //         po_lines = po_lines_by_product.get(procurement.product_id.id, self.env['purchase.order.line'])
            //         po_line = po_lines._find_candidate(*procurement)
            // 
            //         if po_line:
            //             # If the procurement can be merge in an existing line. Directly
            //             # write the new values on it.
            //             vals = self._update_purchase_order_line(procurement.product_id,
            //                 procurement.product_qty, procurement.product_uom, company_id,
            //                 procurement.values, po_line)
            //             po_line.sudo().write(vals)
            //         else:
            //             if procurement.product_uom.compare(procurement.product_qty, 0) <= 0:
            //                 # If procurement contains negative quantity, don't create a new line that would contain negative qty
            //                 continue
            //             # If it does not exist a PO line for current procurement.
            //             # Generate the create values for it and add it to a list in
            //             # order to create it in batch.
            //             partner = procurement.values['supplier'].partner_id
            //             po_line_values.append(self.env['purchase.order.line']._prepare_purchase_order_line_from_procurement(
            //                 *procurement, po))
            //             # Check if we need to advance the order date for the new line
            //             date_planned = po.date_planned or min(v['date_planned'] for v in po_line_values)
            //             order_date_planned = date_planned - relativedelta(
            //                 days=procurement.values['supplier'].delay)
            //             if fields.Date.to_date(order_date_planned) < fields.Date.to_date(po.date_order):
            //                 po.date_order = order_date_planned
            // 
            //     self.env['purchase.order.line'].sudo().create(po_line_values)
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunManufactureInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _run_manufacture(self, procurements):
            // new_productions_values_by_company = defaultdict(lambda: defaultdict(list))
            // for procurement, rule in procurements:
            //     if procurement.product_uom.compare(procurement.product_qty, 0) <= 0:
            //         # If procurement contains negative quantity, don't create a MO that would be for a negative value.
            //         continue
            //     bom = rule._get_matching_bom(procurement.product_id, procurement.company_id, procurement.values)
            // 
            //     mo = self.env['mrp.production']
            //     if procurement.origin != 'MPS':
            //         domain = rule._make_mo_get_domain(procurement, bom)
            //         mo = self.env['mrp.production'].sudo().search(domain, limit=1)
            //     is_batch_size = bom and bom.enable_batch_size
            //     if not mo or is_batch_size:
            //         procurement_qty = procurement.product_qty
            //         batch_size = bom.product_uom_id._compute_quantity(bom.batch_size, procurement.product_uom) if is_batch_size else procurement_qty
            //         vals = rule._prepare_mo_vals(*procurement, bom)
            //         while procurement.product_uom.compare(procurement_qty, 0) > 0:
            //             new_productions_values_by_company[procurement.company_id.id]['values'].append({
            //                 **vals,
            //                 'product_qty': procurement.product_uom._compute_quantity(batch_size, bom.product_uom_id) if bom else procurement_qty,
            //             })
            //             new_productions_values_by_company[procurement.company_id.id]['procurements'].append(procurement)
            //             procurement_qty -= batch_size
            //     else:
            //         procurement_product_uom_qty = procurement.product_uom._compute_quantity(procurement.product_qty, procurement.product_id.uom_id)
            //         self.env['change.production.qty'].sudo().with_context(skip_activity=True).create({
            //             'mo_id': mo.id,
            //             'product_qty': mo.product_id.uom_id._compute_quantity((mo.product_uom_qty + procurement_product_uom_qty), mo.product_uom_id),
            //         }).change_prod_qty()
            // 
            // for company_id in new_productions_values_by_company:
            //     productions_vals_list = new_productions_values_by_company[company_id]['values']
            //     # create the MO as SUPERUSER because the current user may not have the rights to do it (mto product launched by a sale for example)
            //     productions = self.env['mrp.production'].with_user(SUPERUSER_ID).sudo().with_company(company_id).create(productions_vals_list)
            //     for mo in productions:
            //         if self._should_auto_confirm_procurement_mo(mo):
            //             mo.action_confirm()
            //     productions._post_run_manufacture(new_productions_values_by_company[company_id]['procurements'])
            // return True
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunPullInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _run_pull(self, procurements):
            // moves_values_by_company = defaultdict(list)
            // 
            // # To handle the `mts_else_mto` procure method, we do a preliminary loop to
            // # isolate the products we would need to read the forecasted quantity,
            // # in order to to batch the read. We also make a sanitary check on the
            // # `location_src_id` field.
            // for procurement, rule in procurements:
            //     if not rule.location_src_id:
            //         msg = _('No source location defined on stock rule: %s!', rule.name)
            //         raise ProcurementException([(procurement, msg)])
            // 
            // # Prepare the move values, adapt the `procure_method` if needed.
            // procurements = sorted(procurements, key=lambda proc: proc[0].product_uom.compare(proc[0].product_qty, 0.0) > 0)
            // for procurement, rule in procurements:
            //     procure_method = rule.procure_method
            //     if rule.procure_method == 'mts_else_mto':
            //         procure_method = 'make_to_stock'
            // 
            //     move_values = rule._get_stock_move_values(*procurement)
            //     move_values['procure_method'] = procure_method
            //     moves_values_by_company[procurement.company_id.id].append(move_values)
            // 
            // for company_id, moves_values in moves_values_by_company.items():
            //     # create the move as SUPERUSER because the current user may not have the rights to do it (mto product launched by a sale for example)
            //     moves = self.env['stock.move'].sudo().with_company(company_id).create(moves_values)
            //     # Since action_confirm launch following procurement_group we should activate it.
            //     moves._action_confirm()
            // return True
            */
            return default;
        }

        protected async Task<StockRule> RunPushInternalAsync(object move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _run_push(self, move):
            // """ Apply a push rule on a move.
            // If the rule is 'no step added' it will modify the destination location
            // on the move.
            // If the rule is 'manual operation' it will generate a new move in order
            // to complete the section define by the rule.
            // Care this function is not call by method run. It is called explicitely
            // in stock_move.py inside the method _push_apply
            // """
            // self.ensure_one()
            // new_date = self._get_push_new_date(move)
            // if self.auto == 'transparent':
            //     old_dest_location = move.location_dest_id
            //     move.write({'date': new_date, 'location_dest_id': self.location_dest_id.id})
            //     # make sure the location_dest_id is consistent with the move line location dest
            //     if move.move_line_ids:
            //         move.move_line_ids.location_dest_id = move.location_dest_id._get_putaway_strategy(move.product_id) or move.location_dest_id
            // 
            //     # avoid looping if a push rule is not well configured; otherwise call again push_apply to see if a next step is defined
            //     if self.location_dest_id != old_dest_location:
            //         # TDE FIXME: should probably be done in the move model IMO
            //         return move._push_apply()[:1]
            // else:
            //     new_move_vals = self._push_prepare_move_copy_values(move, new_date)
            //     new_move = move.sudo().copy(new_move_vals)
            //     # when no more push we should reach final destination
            //     if new_move._skip_push():
            //         new_move.write({'location_dest_id': new_move.location_final_id.id})
            //     if new_move._should_bypass_reservation():
            //         new_move.write({'procure_method': 'make_to_stock'})
            //     if not new_move.location_id.should_bypass_reservation():
            //         move.sudo().write({'move_dest_ids': [(4, new_move.id)]})
            //     return new_move
            */
            return default;
        }

        [ApiModel]
        public async Task<StockRule> RunSchedulerAsync(StockRuleRunSchedulerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def run_scheduler(self, use_new_cursor=False, company_id=False):
            // """ Call the scheduler in order to check the running procurements (super method), to check the minimum stock rules
            // and the availability of moves. This function is intended to be run for all the companies at the same time, so
            // we run functions as SUPERUSER to avoid intercompanies and access rights issues. """
            // try:
            //     self._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // except Exception:
            //     _logger.error("Error during stock scheduler", exc_info=True)
            //     raise
            // return {}
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunSchedulerTasksInternalAsync(object use_new_cursor, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // super()._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // self.env['pos.session']._alert_old_session()
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(1)
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: stock_rule.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // super()._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // self.env['stock.lot']._alert_date_exceeded()
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(1)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(remaining=self._get_scheduler_tasks_to_do())
            // 
            // # Minimum stock rules
            // domain = self._get_orderpoint_domain(company_id=company_id)
            // orderpoints = self.env['stock.warehouse.orderpoint'].search(domain)
            // orderpoints.sudo()._compute_qty_to_order_computed()
            // orderpoints.sudo()._compute_deadline_date()
            // orderpoints.sudo()._procure_orderpoint_confirm(use_new_cursor=use_new_cursor, company_id=company_id, raise_user_error=False)
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(1)
            // 
            // # Search all confirmed stock_moves and try to assign them
            // domain = self._get_moves_to_assign_domain(company_id)
            // moves_to_assign = self.env['stock.move'].search(domain, limit=None,
            //     order='reservation_date, priority desc, date asc, id asc')
            // for moves_chunk in split_every(1000, moves_to_assign.ids):
            //     self.env['stock.move'].browse(moves_chunk).sudo()._action_assign()
            //     if use_new_cursor:
            //         self.env.cr.commit()
            //         _logger.info("A batch of %d moves are assigned and committed", len(moves_chunk))
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(1)
            // 
            // # Merge duplicated quants
            // self.env['stock.quant']._quant_tasks()
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._commit_progress(1)
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> SearchRuleForWarehousesInternalAsync(List<Guid> route_ids, Guid packaging_uom_id, Guid product_id, List<Guid> warehouse_ids, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _search_rule_for_warehouses(self, route_ids, packaging_uom_id, product_id, warehouse_ids, domain):
            // domain = Domain(domain)
            // if warehouse_ids:
            //     domain &= Domain('warehouse_id', 'in', [False, *warehouse_ids.ids])
            // valid_route_ids = set()
            // if route_ids:
            //     valid_route_ids |= set(route_ids.ids)
            // if packaging_uom_id:
            //     packaging_routes = packaging_uom_id.package_type_id.route_ids
            //     valid_route_ids |= set(packaging_routes.ids)
            // valid_route_ids |= set((product_id.route_ids | product_id.categ_id.total_route_ids).ids)
            // if warehouse_ids:
            //     filter_function = partial(self._filter_warehouse_routes, product_id, warehouse_ids)
            //     valid_route_ids |= set(warehouse_ids.route_ids.filtered(filter_function).ids)
            // if valid_route_ids:
            //     domain &= Domain('route_id', 'in', list(valid_route_ids))
            // res = self.env["stock.rule"]._read_group(
            //     domain,
            //     groupby=["location_dest_id", "warehouse_id", "route_id"],
            //     aggregates=["id:recordset"],
            //     order="route_sequence:min, sequence:min",
            // )
            // rule_dict = defaultdict(OrderedDict)
            // for group in res:
            //     rule_dict[group[0].id, group[2].id][group[1].id] = group[3].sorted(lambda rule: (rule.route_sequence, rule.sequence))[0]
            // return rule_dict
            */
            return default;
        }

        protected async Task<StockRule> SearchRuleInternalAsync(List<Guid> route_ids, Guid packaging_uom_id, Guid product_id, Guid warehouse_id, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _search_rule(self, route_ids, packaging_uom_id, product_id, warehouse_id, domain):
            // """ First find a rule among the ones defined on the procurement
            // group, then try on the routes defined for the product, finally fallback
            // on the default behavior
            // """
            // Rule = self.env['stock.rule']
            // res = self.env['stock.rule']
            // domain = Domain(domain)
            // if warehouse_id:
            //     domain &= Domain('warehouse_id', 'in', [False, warehouse_id.id])
            // domain = domain.optimize(Rule)
            // if route_ids:
            //     res = Rule.search(Domain('route_id', 'in', route_ids.ids) & domain, order='route_sequence, sequence', limit=1)
            // if not res and packaging_uom_id:
            //     packaging_routes = packaging_uom_id.package_type_id.route_ids
            //     if packaging_routes:
            //         res = Rule.search(Domain('route_id', 'in', packaging_routes.ids) & domain, order='route_sequence, sequence', limit=1)
            // if not res:
            //     product_routes = product_id.route_ids | product_id.categ_id.total_route_ids
            //     if product_routes:
            //         res = Rule.search(Domain('route_id', 'in', product_routes.ids) & domain, order='route_sequence, sequence', limit=1)
            // if not res and warehouse_id:
            //     warehouse_routes = warehouse_id.route_ids
            //     if warehouse_routes:
            //         res = Rule.search(Domain('route_id', 'in', warehouse_routes.ids) & domain, order='route_sequence, sequence', limit=1)
            // return res
            */
            return default;
        }

        protected async Task<StockRule> SerializeProcurementValuesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _serialize_procurement_values(self, values):
            // """Helper method to serialize procurement values for storage.
            // 
            // This method handles the serialization of different types of values:
            // - BaseModel instances are converted to their IDs
            // - Datetime and Date fields are converted to strings
            // - Other values are kept as is
            // 
            // :param values: Dictionary of procurement values
            // :return: Dictionary with serialized values
            // """
            // serialized = {}
            // for key, value in values.items():
            //     if isinstance(value, models.BaseModel):
            //         serialized[key] = value.ids
            //     elif isinstance(value, (datetime.datetime, datetime.date)):
            //         serialized[key] = value.isoformat()
            //     elif isinstance(value, (fields.Datetime, fields.Date)):
            //         serialized[key] = fields.Datetime.to_string(value) if isinstance(value, fields.Datetime) else fields.Date.to_string(value)
            //     else:
            //         serialized[key] = value
            // return serialized
            */
            return default;
        }

        protected async Task<StockRule> ShouldAutoConfirmProcurementMoInternalAsync(object p)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _should_auto_confirm_procurement_mo(self, p):
            // if not p.move_raw_ids:
            //     return (not p.workorder_ids and (p.orderpoint_id or p.move_dest_ids.procure_method == 'make_to_stock'))
            // return not p.orderpoint_id
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> SkipProcurementInternalAsync(object procurement)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _skip_procurement(self, procurement):
            // return procurement.product_id.type != "consu" or float_is_zero(
            //     procurement.product_qty, precision_rounding=procurement.product_uom.rounding
            // )
            */
            return default;
        }

        protected async Task<StockRule> UpdatePurchaseOrderLineInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, object values, object line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _update_purchase_order_line(self, product_id, product_qty, product_uom, company_id, values, line):
            // partner = values['supplier'].partner_id
            // procurement_uom_po_qty = product_uom._compute_quantity(product_qty, line.product_uom_id, rounding_method='HALF-UP')
            // seller = product_id.with_company(company_id)._select_seller(
            //     partner_id=partner,
            //     quantity=line.product_qty + procurement_uom_po_qty,
            //     date=line.order_id.date_order and line.order_id.date_order.date(),
            //     uom_id=line.product_uom_id,
            //     params={'force_uom': values.get('force_uom')})
            // 
            // price_unit = self.env['account.tax']._fix_tax_included_price_company(seller.price, line.product_id.supplier_taxes_id, line.sudo().tax_ids, company_id) if seller else 0.0
            // if price_unit and seller and line.order_id.currency_id and seller.currency_id != line.order_id.currency_id:
            //     price_unit = seller.currency_id._convert(
            //         price_unit, line.order_id.currency_id, line.order_id.company_id, fields.Date.today())
            // 
            // res = {
            //     'product_qty': line.product_qty + procurement_uom_po_qty,
            //     'price_unit': price_unit,
            //     'move_dest_ids': [(4, x.id) for x in values.get('move_dest_ids', [])]
            // }
            // if seller.product_uom_id != line.product_uom_id and not values.get('force_uom'):
            //     res['product_qty'] = line.product_uom_id._compute_quantity(res['product_qty'], seller.product_uom_id, rounding_method='HALF-UP')
            //     res['product_uom_id'] = seller.product_uom_id
            // orderpoint_id = values.get('orderpoint_id')
            // if orderpoint_id:
            //     res['orderpoint_id'] = orderpoint_id.id
            // return res
            */
            return default;
        }
    }
}