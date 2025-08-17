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
    public class StockRuleAppService : GenericApplicationService<StockRule>, IStockRuleAppService
    {

        public StockRuleAppService(IRepository<StockRule, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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
            // remaining = self.browse()
            // for rule in self:
            //     if rule.action == 'manufacture':
            //         rule.picking_type_code_domain = 'mrp_operation'
            //     else:
            //         remaining |= rule
            // super(StockRule, remaining)._compute_picking_type_code_domain()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _compute_picking_type_code_domain(self):
            // remaining = self.browse()
            // for rule in self:
            //     if rule.action == 'buy':
            //         rule.picking_type_code_domain = 'incoming'
            //     else:
            //         remaining |= rule
            // super(StockRule, remaining)._compute_picking_type_code_domain()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _compute_picking_type_code_domain(self):
            // self.picking_type_code_domain = False
            */
            return default;
        }

        public async Task<StockRule> CopyDataAsync(Guid id, object @default)
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
            var entity = await Repository.GetAsync(id); return entity;
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
            // manufacture_delay = bom.produce_delay
            // delays['total_delay'] += manufacture_delay
            // delays['manufacture_delay'] += manufacture_delay
            // if not bypass_delay_description:
            //     delay_description.append((_('Manufacturing Lead Time'), _('+ %d day(s)', manufacture_delay)))
            // if bom.type == 'normal':
            //     # pre-production rules
            //     warehouse = self.location_dest_id.warehouse_id
            //     for wh in warehouse:
            //         if wh.manufacture_steps != 'mrp_one_step':
            //             wh_manufacture_rules = product._get_rules_from_location(product.property_stock_production, route_ids=wh.pbm_route_id)
            //             extra_delays, extra_delay_description = (wh_manufacture_rules - self).with_context(global_visibility_days=0)._get_lead_days(product, **values)
            //             for key, value in extra_delays.items():
            //                 delays[key] += value
            //             delay_description += extra_delay_description
            //     # manufacturing security lead time
            //     for comp in self.picking_type_id.company_id:
            //         security_delay = comp.manufacturing_lead
            //         delays['total_delay'] += security_delay
            //         delays['security_lead_days'] += security_delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Manufacture Security Lead Time'), _('+ %d day(s)', security_delay)))
            // days_to_order = values.get('days_to_order', bom.days_to_prepare_mo)
            // delays['total_delay'] += days_to_order
            // if not bypass_delay_description:
            //     delay_description.append((_('Days to Supply Components'), _('+ %d day(s)', days_to_order)))
            // return delays, delay_description
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """For subcontracting, we need to consider both vendor lead time and
            // manufacturing lead time, and DTPMO (Days To Prepare MO).
            // Subcontracting delay =
            //     max(Vendor lead time, Manufacturing lead time + DTPMO) + Days to Purchase + Purchase security lead time
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
            // extra_delays, extra_delay_description = super(StockRule, buy_rule.with_context(ignore_vendor_lead_time=True, global_visibility_days=0))._get_lead_days(product, **values)
            // if seller.delay >= bom.produce_delay + bom.days_to_prepare_mo:
            //     delays['total_delay'] += seller.delay
            //     delays['purchase_delay'] += seller.delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Vendor Lead Time'), _('+ %d day(s)', seller.delay)))
            // else:
            //     manufacture_delay = bom.produce_delay
            //     delays['total_delay'] += manufacture_delay
            //     # set manufacture_delay to purchase_delay so that PO can be created with correct date
            //     delays['purchase_delay'] += manufacture_delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Manufacturing Lead Time'), _('+ %d day(s)', manufacture_delay)))
            //     days_to_order = bom.days_to_prepare_mo
            //     delays['total_delay'] += days_to_order
            //     # add dtpmo to purchase_delay so that PO can be created with correct date
            //     delays['purchase_delay'] += days_to_order
            //     if not bypass_delay_description:
            //         extra_delay_description.append((_('Days to Supply Components'), _('+ %d day(s)', days_to_order)))
            // 
            // for key, value in extra_delays.items():
            //     delays[key] += value
            // return delays, delay_description + extra_delay_description
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_lead_days(self, product, **values):
            // """Add the company security lead time and the supplier delay to the cumulative delay
            // and cumulative description. The company lead time is always displayed for onboarding
            // purpose in order to indicate that those options are available.
            // """
            // delays, delay_description = super()._get_lead_days(product, **values)
            // bypass_delay_description = self.env.context.get('bypass_delay_description')
            // buy_rule = self.filtered(lambda r: r.action == 'buy')
            // seller = 'supplierinfo' in values and values['supplierinfo'] or product.with_company(buy_rule.company_id)._select_seller(quantity=None)
            // if not buy_rule or not seller:
            //     return delays, delay_description
            // buy_rule.ensure_one()
            // if not self.env.context.get('ignore_vendor_lead_time'):
            //     supplier_delay = seller[0].delay
            //     delays['total_delay'] += supplier_delay
            //     delays['purchase_delay'] += supplier_delay
            //     if not bypass_delay_description:
            //         delay_description.append((_('Vendor Lead Time'), _('+ %d day(s)', supplier_delay)))
            // security_delay = buy_rule.picking_type_id.company_id.po_lead
            // delays['total_delay'] += security_delay
            // delays['security_lead_days'] += security_delay
            // if not bypass_delay_description:
            //     delay_description.append((_('Purchase Security Lead Time'), _('+ %d day(s)', security_delay)))
            // days_to_order = buy_rule.company_id.days_to_purchase
            // delays['total_delay'] += days_to_order
            // if not bypass_delay_description:
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
            // _ = self.env._
            // delays = defaultdict(float)
            // delay = sum(self.filtered(lambda r: r.action in ['pull', 'pull_push']).mapped('delay'))
            // delays['total_delay'] += delay
            // global_visibility_days = self.env.context.get('global_visibility_days', self.env['ir.config_parameter'].sudo().get_param('stock.visibility_days', 0))
            // if global_visibility_days:
            //     delays['total_delay'] += int(global_visibility_days)
            // if self.env.context.get('bypass_delay_description'):
            //     delay_description = []
            // else:
            //     delay_description = [
            //         (_('Delay on %s', rule.name), _('+ %d day(s)', rule.delay))
            //         for rule in self
            //         if rule.action in ['pull', 'pull_push'] and rule.delay
            //     ]
            // if global_visibility_days:
            //     delay_description.append((_('Time Horizon'), _('+ %d day(s)', int(global_visibility_days))))
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
            // return self.env['mrp.bom']._bom_find(product_id, picking_type=self.picking_type_id, bom_type='normal', company_id=company_id.id)[product_id]
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

        protected async Task<StockRule> GetPartnerIdInternalAsync(object values, object rule)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _get_partner_id(self, values, rule):
            // return values.get("supplierinfo_name") or (values.get("group_id") and values.get("group_id").partner_id)
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_partner_id(self, values, rule):
            // route = self.env.ref('stock_dropshipping.route_drop_shipping', raise_if_not_found=False)
            // if route and rule.route_id == route:
            //     return False
            // return super()._get_partner_id(values, rule)
            */
            return default;
        }

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

        protected async Task<StockRule> GetStockMoveValuesInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_rule.py) ---
            // def _get_stock_move_values(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values):
            // move_values = super()._get_stock_move_values(product_id, product_qty, product_uom, location_id, name, origin, company_id, values)
            // if values.get('product_description_variants') and values.get('group_id') and values['group_id'].pos_order_id:
            //     move_values['description_picking'] = values['product_description_variants']
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
            // :param procurement: browse record
            // :rtype: dictionary
            // '''
            // group_id = False
            // if self.group_propagation_option == 'propagate':
            //     group_id = values.get('group_id', False) and values['group_id'].id
            // elif self.group_propagation_option == 'fixed':
            //     group_id = self.group_id.id
            // 
            // date_scheduled = fields.Datetime.to_string(
            //     fields.Datetime.from_string(values['date_planned']) - relativedelta(days=self.delay or 0)
            // )
            // date_deadline = values.get('date_deadline') and (fields.Datetime.to_datetime(values['date_deadline']) - relativedelta(days=self.delay or 0)) or False
            // partner = self.partner_address_id or (values.get('group_id', False) and values['group_id'].partner_id)
            // product_id = product_id.with_context(lang=(partner and partner.lang) or self.env.user.lang)
            // picking_description = product_id._get_description(self.picking_type_id)
            // if values.get('product_description_variants'):
            //     picking_description += values['product_description_variants']
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
            // if float_compare(product_qty, 0.0, precision_rounding=product_uom.rounding) < 0:
            //     values['to_refund'] = True
            // 
            // move_values = {
            //     'name': name[:2000],
            //     'company_id': self.company_id.id or self.location_src_id.company_id.id or self.location_dest_id.company_id.id or company_id.id,
            //     'product_id': product_id.id,
            //     'product_uom': product_uom.id,
            //     'product_uom_qty': qty_left,
            //     'partner_id': partner.id if partner else False,
            //     'location_id': self.location_src_id.id,
            //     'location_final_id': location_dest_id.id,
            //     'move_dest_ids': move_dest_ids,
            //     'rule_id': self.id,
            //     'procure_method': self.procure_method,
            //     'origin': origin,
            //     'picking_type_id': self.picking_type_id.id,
            //     'group_id': group_id,
            //     'route_ids': [(4, route.id) for route in values.get('route_ids', [])],
            //     'never_product_template_attribute_value_ids': values.get('never_product_template_attribute_value_ids'),
            //     'warehouse_id': self.warehouse_id.id,
            //     'date': date_scheduled,
            //     'date_deadline': False if self.group_propagation_option == 'fixed' else date_deadline,
            //     'propagate_cancel': self.propagate_cancel,
            //     'description_picking': picking_description,
            //     'priority': values.get('priority', "0"),
            //     'orderpoint_id': values.get('orderpoint_id') and values['orderpoint_id'].id,
            //     'product_packaging_id': values.get('product_packaging_id') and values['product_packaging_id'].id,
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
            // gpo = self.group_propagation_option
            // group = (gpo == 'fixed' and self.group_id) or \
            //         (gpo == 'propagate' and 'group_id' in procurement.values and procurement.values['group_id']) or False
            // domain = (
            //     ('bom_id', '=', bom.id),
            //     ('product_id', '=', procurement.product_id.id),
            //     ('state', 'in', ['draft', 'confirmed']),
            //     ('is_planned', '=', False),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('company_id', '=', procurement.company_id.id),
            //     ('user_id', '=', False),
            // )
            // if procurement.values.get('orderpoint_id'):
            //     procurement_date = datetime.combine(
            //         fields.Date.to_date(procurement.values['date_planned']) - relativedelta(days=int(bom.produce_delay)),
            //         datetime.max.time()
            //     )
            //     domain += ('|',
            //                '&', ('state', '=', 'draft'), ('date_deadline', '<=', procurement_date),
            //                '&', ('state', '=', 'confirmed'), ('date_start', '<=', procurement_date))
            // if group:
            //     domain += (('procurement_group_id', '=', group.id),)
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
            // gpo = self.group_propagation_option
            // group = (gpo == 'fixed' and self.group_id) or \
            //         (gpo == 'propagate' and 'group_id' in values and values['group_id']) or False
            // currency = ('supplier' in values and values['supplier'].currency_id) or \
            //            partner.with_company(company_id).property_purchase_currency_id or \
            //            company_id.currency_id
            // 
            // domain = (
            //     ('partner_id', '=', partner.id),
            //     ('state', '=', 'draft'),
            //     ('picking_type_id', '=', self.picking_type_id.id),
            //     ('company_id', '=', company_id.id),
            //     ('user_id', '=', partner.buyer_id.id),
            //     ('currency_id', '=', currency.id),
            // )
            // delta_days = self.env['ir.config_parameter'].sudo().get_param('purchase_stock.delta_days_merge')
            // if values.get('orderpoint_id') and delta_days is not False:
            //     procurement_date = fields.Date.to_date(values['date_planned']) - relativedelta(days=int(values['supplier'].delay))
            //     delta_days = int(delta_days)
            //     domain += (
            //         ('date_order', '<=', datetime.combine(procurement_date + relativedelta(days=delta_days), datetime.max.time())),
            //         ('date_order', '>=', datetime.combine(procurement_date - relativedelta(days=delta_days), datetime.min.time()))
            //     )
            // strict_partner_dest = self.env['ir.config_parameter'].sudo().get_param('purchase_stock.split_po')
            // if strict_partner_dest:
            //     domain += (
            //         ('dest_address_id', '=', values.get('partner_id', False)),
            //     )
            // if group:
            //     domain += (('group_id', '=', group.id),)
            // return domain
            */
            return default;
        }

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
            //     merged_procurement = self.env['procurement.group'].Procurement(
            //         procurement.product_id, quantity, procurement.product_uom,
            //         procurement.location_id, procurement.name, procurement.origin,
            //         procurement.company_id, values
            //     )
            //     merged_procurements.append(merged_procurement)
            // return merged_procurements
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

        protected async Task<StockRule> PrepareMoValsInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values, object bom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _prepare_mo_vals(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, bom):
            // date_planned = self._get_date_planned(bom, values)
            // date_deadline = values.get('date_deadline') or date_planned + relativedelta(days=bom.produce_delay)
            // mo_values = {
            //     'origin': origin,
            //     'product_id': product_id.id,
            //     'product_description_variants': values.get('product_description_variants'),
            //     'never_product_template_attribute_value_ids': values.get('never_product_template_attribute_value_ids'),
            //     'product_qty': product_uom._compute_quantity(product_qty, bom.product_uom_id) if bom else product_qty,
            //     'product_uom_id': bom.product_uom_id.id if bom else product_uom.id,
            //     'location_src_id': self.picking_type_id.default_location_src_id.id,
            //     'location_dest_id': self.picking_type_id.default_location_dest_id.id or location_dest_id.id,
            //     'location_final_id': location_dest_id.id,
            //     'bom_id': bom.id,
            //     'date_deadline': date_deadline,
            //     'date_start': date_planned,
            //     'procurement_group_id': False,
            //     'propagate_cancel': self.propagate_cancel,
            //     'orderpoint_id': values.get('orderpoint_id', False) and values.get('orderpoint_id').id,
            //     'picking_type_id': self.picking_type_id.id or values['warehouse_id'].manu_type_id.id,
            //     'company_id': company_id.id,
            //     'move_dest_ids': values.get('move_dest_ids') and [(4, x.id) for x in values['move_dest_ids']] or False,
            //     'user_id': False,
            // }
            // # Use the procurement group created in _run_pull mrp override
            // # Preserve the origin from the original stock move, if available
            // if location_dest_id.warehouse_id.manufacture_steps == 'pbm_sam' and values.get('move_dest_ids') and values.get('group_id') and values['group_id'].name not in values['move_dest_ids'][0].origin:
            //     origin = values['move_dest_ids'][0].origin
            //     mo_values.update({
            //         'name': values['group_id'].name,
            //         'procurement_group_id': values['group_id'].id,
            //         'origin': origin,
            //     })
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
            //          or self.location_dest_id.is_subcontracting_location):
            //     values[0]['partner_id'] = values[0]['group_id'].partner_id.id
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
            // gpo = self.group_propagation_option
            // group = (gpo == 'fixed' and self.group_id.id) or \
            //         (gpo == 'propagate' and values.get('group_id') and values['group_id'].id) or False
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
            //     'group_id': group
            // }
            */
            return default;
        }

        protected async Task<StockRule> PushPrepareMoveCopyValuesInternalAsync(object move_to_copy, object new_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _push_prepare_move_copy_values(self, move_to_copy, new_date):
            // new_move_vals = super(StockRule, self)._push_prepare_move_copy_values(move_to_copy, new_date)
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
            // if float_compare(move_to_copy.product_uom_qty, 0, precision_rounding=move_to_copy.product_uom.rounding) < 0:
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
            //     'warehouse_id': self.warehouse_id.id,
            //     'procure_method': 'make_to_order',
            //     'description_picking': move_to_copy.product_id.with_context(lang=move_to_copy._get_lang())._get_description(
            //         self.picking_type_id) or move_to_copy.description_picking,
            // }
            // return new_move_vals
            */
            return default;
        }

        protected async Task<StockRule> RunBuyInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _run_buy(self, procurements):
            // procurements_by_po_domain = defaultdict(list)
            // errors = []
            // for procurement, rule in procurements:
            // 
            //     # Get the schedule date in order to find a valid seller
            //     procurement_date_planned = fields.Datetime.from_string(procurement.values['date_planned'])
            // 
            //     supplier = False
            //     company_id = rule.company_id or procurement.company_id
            //     if procurement.values.get('supplierinfo_id'):
            //         supplier = procurement.values['supplierinfo_id']
            //     elif procurement.values.get('orderpoint_id') and procurement.values['orderpoint_id'].supplier_id:
            //         supplier = procurement.values['orderpoint_id'].supplier_id
            //     else:
            //         supplier = procurement.product_id.with_company(company_id.id)._select_seller(
            //             partner_id=self._get_partner_id(procurement.values, rule),
            //             quantity=procurement.product_qty,
            //             date=max(procurement_date_planned.date(), fields.Date.today()),
            //             uom_id=procurement.product_uom)
            // 
            //     # Fall back on a supplier for which no price may be defined. Not ideal, but better than
            //     # blocking the user.
            //     supplier = supplier or procurement.product_id._prepare_sellers(False).filtered(
            //         lambda s: not s.company_id or s.company_id == company_id
            //     )[:1]
            // 
            //     if not supplier:
            //         msg = _('There is no matching vendor price to generate the purchase order for product %s (no vendor defined, minimum quantity not reached, dates not valid, ...). Go on the product form and complete the list of vendors.', procurement.product_id.display_name)
            //         errors.append((procurement, msg))
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
            //         positive_values = [p.values for p in procurements if float_compare(p.product_qty, 0.0, precision_rounding=p.product_uom.rounding) >= 0]
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
            //         # If a purchase order is found, adapt its `origin` field.
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
            //     grouped_po_lines = groupby(po.order_line.filtered(lambda l: not l.display_type and l.product_uom == l.product_id.uom_po_id), key=lambda l: l.product_id.id)
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
            //             if float_compare(procurement.product_qty, 0, precision_rounding=procurement.product_uom.rounding) <= 0:
            //                 # If procurement contains negative quantity, don't create a new line that would contain negative qty
            //                 continue
            //             # If it does not exist a PO line for current procurement.
            //             # Generate the create values for it and add it to a list in
            //             # order to create it in batch.
            //             partner = procurement.values['supplier'].partner_id
            //             po_line_values.append(self.env['purchase.order.line']._prepare_purchase_order_line_from_procurement(
            //                 *procurement, po))
            //             # Check if we need to advance the order date for the new line
            //             order_date_planned = procurement.values['date_planned'] - relativedelta(
            //                 days=procurement.values['supplier'].delay)
            //             if fields.Date.to_date(order_date_planned) < fields.Date.to_date(po.date_order):
            //                 po.date_order = order_date_planned
            //     self.env['purchase.order.line'].sudo().create(po_line_values)
            */
            return default;
        }

        protected async Task<StockRule> RunManufactureInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _run_manufacture(self, procurements):
            // new_productions_values_by_company = defaultdict(lambda: defaultdict(list))
            // for procurement, rule in procurements:
            //     if float_compare(procurement.product_qty, 0, precision_rounding=procurement.product_uom.rounding) <= 0:
            //         # If procurement contains negative quantity, don't create a MO that would be for a negative value.
            //         continue
            //     bom = rule._get_matching_bom(procurement.product_id, procurement.company_id, procurement.values)
            // 
            //     mo = self.env['mrp.production']
            //     if procurement.origin != 'MPS':
            //         domain = rule._make_mo_get_domain(procurement, bom)
            //         mo = self.env['mrp.production'].sudo().search(domain, limit=1)
            //     if not mo:
            //         procurement_qty = procurement.product_qty
            //         batch_size = procurement.values.get('batch_size', procurement_qty)
            //         if batch_size <= 0:
            //             batch_size = procurement_qty
            //         vals = rule._prepare_mo_vals(*procurement, bom)
            //         while float_compare(procurement_qty, 0, precision_rounding=procurement.product_uom.rounding) > 0:
            //             current_qty = min(procurement_qty, batch_size)
            //             new_productions_values_by_company[procurement.company_id.id]['values'].append({
            //                 **vals,
            //                 'product_qty': procurement.product_uom._compute_quantity(current_qty, bom.product_uom_id) if bom else current_qty,
            //             })
            //             new_productions_values_by_company[procurement.company_id.id]['procurements'].append(procurement)
            //             procurement_qty -= current_qty
            //     else:
            //         self.env['change.production.qty'].sudo().with_context(skip_activity=True).create({
            //             'mo_id': mo.id,
            //             'product_qty': mo.product_id.uom_id._compute_quantity((mo.product_uom_qty + procurement.product_qty), mo.product_uom_id)
            //         }).change_prod_qty()
            // 
            // for company_id in new_productions_values_by_company:
            //     productions_vals_list = new_productions_values_by_company[company_id]['values']
            //     # create the MO as SUPERUSER because the current user may not have the rights to do it (mto product launched by a sale for example)
            //     productions = self.env['mrp.production'].with_user(SUPERUSER_ID).sudo().with_company(company_id).create(productions_vals_list)
            //     productions.filtered(self._should_auto_confirm_procurement_mo).action_confirm()
            //     productions._post_run_manufacture(new_productions_values_by_company[company_id]['procurements'])
            // return True
            */
            return default;
        }

        protected async Task<StockRule> RunPullInternalAsync(object procurements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _run_pull(self, procurements):
            // # Override to correctly assign the move generated from the pull
            // # in its production order (pbm_sam only)
            // for procurement, rule in procurements:
            //     warehouse_id = rule.warehouse_id
            //     if not warehouse_id:
            //         warehouse_id = rule.location_dest_id.warehouse_id
            //     manu_rule = rule.route_id.rule_ids.filtered(lambda r: r.action == 'manufacture' and r.warehouse_id == warehouse_id)
            //     if warehouse_id.manufacture_steps != 'pbm_sam' or not manu_rule:
            //         continue
            //     if rule.picking_type_id == warehouse_id.sam_type_id or (
            //         warehouse_id.sam_loc_id and warehouse_id.sam_loc_id.parent_path in rule.location_src_id.parent_path
            //     ):
            //         if float_compare(procurement.product_qty, 0, precision_rounding=procurement.product_uom.rounding) < 0:
            //             procurement.values['group_id'] = procurement.values['group_id'].stock_move_ids.filtered(
            //                 lambda m: m.state not in ['done', 'cancel']).move_orig_ids.group_id[:1]
            //             continue
            //         manu_type_id = manu_rule[0].picking_type_id
            //         if manu_type_id:
            //             name = manu_type_id.sequence_id.next_by_id()
            //         else:
            //             name = self.env['ir.sequence'].next_by_code('mrp.production') or _('New')
            //         # Create now the procurement group that will be assigned to the new MO
            //         # This ensure that the outgoing move PostProduction -> Stock is linked to its MO
            //         # rather than the original record (MO or SO)
            //         group = procurement.values.get('group_id')
            //         if group:
            //             procurement.values['group_id'] = group.copy({'name': name})
            //         else:
            //             procurement.values['group_id'] = self.env["procurement.group"].create({'name': name})
            // return super()._run_pull(procurements)
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
            // procurements = sorted(procurements, key=lambda proc: float_compare(proc[0].product_qty, 0.0, precision_rounding=proc[0].product_uom.rounding) > 0)
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
            // new_date = fields.Datetime.to_string(move.date + relativedelta(days=self.delay))
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
            //         move.write({'move_dest_ids': [(4, new_move.id)]})
            //     return new_move
            */
            return default;
        }

        protected async Task<StockRule> ShouldAutoConfirmProcurementMoInternalAsync(object p)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _should_auto_confirm_procurement_mo(self, p):
            // return (not p.orderpoint_id and p.move_raw_ids) or (p.move_dest_ids.procure_method != 'make_to_order' and not p.move_raw_ids and not p.workorder_ids)
            */
            return default;
        }

        protected async Task<StockRule> UpdatePurchaseOrderLineInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, object values, object line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _update_purchase_order_line(self, product_id, product_qty, product_uom, company_id, values, line):
            // partner = values['supplier'].partner_id
            // procurement_uom_po_qty = product_uom._compute_quantity(product_qty, product_id.uom_po_id, rounding_method='HALF-UP')
            // seller = product_id.with_company(company_id)._select_seller(
            //     partner_id=partner,
            //     quantity=line.product_qty + procurement_uom_po_qty,
            //     date=line.order_id.date_order and line.order_id.date_order.date(),
            //     uom_id=product_id.uom_po_id)
            // 
            // price_unit = self.env['account.tax']._fix_tax_included_price_company(seller.price, line.product_id.supplier_taxes_id, line.sudo().taxes_id, company_id) if seller else 0.0
            // if price_unit and seller and line.order_id.currency_id and seller.currency_id != line.order_id.currency_id:
            //     price_unit = seller.currency_id._convert(
            //         price_unit, line.order_id.currency_id, line.order_id.company_id, fields.Date.today())
            // 
            // res = {
            //     'product_qty': line.product_qty + procurement_uom_po_qty,
            //     'price_unit': price_unit,
            //     'move_dest_ids': [(4, x.id) for x in values.get('move_dest_ids', [])]
            // }
            // orderpoint_id = values.get('orderpoint_id')
            // if orderpoint_id:
            //     res['orderpoint_id'] = orderpoint_id.id
            // return res
            */
            return default;
        }
    }
}