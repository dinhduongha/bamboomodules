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
    [Module("Delivery", Category = "Sales", Depends = new[] { "sale", "payment_custom" })]
    public class DeliveryCarrierAppService : GenericApplicationService<DeliveryCarrier>, IDeliveryCarrierAppService
    {
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        public DeliveryCarrierAppService(IRepository<DeliveryCarrier, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
        }

        protected async Task<DeliveryCarrier> ApplyMarginsInternalAsync(object price, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _apply_margins(self, price, order=False):
            // self.ensure_one()
            // if self.delivery_type == 'fixed':
            //     return float(price)
            // fixed_margin_in_sale_currency = self._compute_currency(order, self.fixed_margin, 'company_to_pricelist') if order else self.fixed_margin
            // return float(price) * (1.0 + self.margin) + fixed_margin_in_sale_currency
            */
            return default;
        }

        public async Task<DeliveryCarrier> AvailableCarriersAsync(Guid id, DeliveryCarrierAvailableCarriersRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def available_carriers(self, partner, source):
            // return self.filtered(lambda c: c._match(partner, source))
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def available_carriers(self, partner, source):
            // """ Override of `delivery` to filter out regular delivery methods from Gelato orders and
            // Gelato delivery methods from non-Gelato orders.
            // 
            // :param res.partner partner: The partner to check.
            // :param sale.order or stock.picking source: The current order or stock transfer.
            // :return: The available delivery methods.
            // :rtype: delivery.carrier
            // """
            // available_delivery_methods = super().available_carriers(partner, source)
            // if source._name == 'sale.order':
            //     is_gelato_order = any(source.order_line.product_id.mapped('gelato_product_uid'))
            // elif source._name == 'stock.picking':
            //     is_gelato_order = any(source.move_ids.product_id.mapped('gelato_product_uid'))
            // else:
            //     raise UserError(_("Invalid source document type"))
            // if is_gelato_order:
            //     return available_delivery_methods.filtered(lambda m: m.delivery_type == 'gelato')
            // else:
            //     return available_delivery_methods.filtered(lambda m: m.delivery_type != 'gelato')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> BaseOnRuleCancelShipmentAsync(Guid id, DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_cancel_shipment(self, pickings):
            // raise NotImplementedError()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> BaseOnRuleGetTrackingLinkAsync(Guid id, DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def base_on_rule_get_tracking_link(self, picking):
            // if self.is_mondialrelay:
            //     return 'https://www.mondialrelay.com/public/permanent/tracking.aspx?ens=%(brand)s&exp=%(track)s&language=%(lang)s' % {
            //         'brand': picking.carrier_id.mondialrelay_brand,
            //         'track': picking.carrier_tracking_ref,
            //         'lang': (picking.partner_id.lang or 'fr').split('_')[0],
            //     }
            // return super().base_on_rule_get_tracking_link(picking)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_get_tracking_link(self, picking):
            // if self.tracking_url and picking.carrier_tracking_ref:
            //     return self.tracking_url.replace("<shipmenttrackingnumber>", picking.carrier_tracking_ref)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> BaseOnRuleRateShipmentAsync(Guid id, DeliveryCarrierBaseOnRuleRateShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_rate_shipment(self, order):
            // carrier = self._match_address(order.partner_shipping_id)
            // if not carrier:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': _('Error: this delivery method is not available for this address.'),
            //             'warning_message': False}
            // 
            // try:
            //     price_unit = self._get_price_available(order)
            // except UserError as e:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': e.args[0],
            //             'warning_message': False}
            // 
            // price_unit = self._compute_currency(order, price_unit, 'company_to_pricelist')
            // 
            // return {'success': True,
            //         'price': price_unit,
            //         'error_message': False,
            //         'warning_message': False}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> BaseOnRuleSendShippingAsync(Guid id, DeliveryCarrierBaseOnRuleSendShippingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_send_shipping(self, pickings):
            // res = []
            // for p in pickings:
            //     carrier = self._match_address(p.partner_id)
            //     if not carrier:
            //         raise ValidationError(_('There is no matching delivery rule.'))
            //     res = res + [{'exact_price': p.carrier_id._get_price_available(p.sale_id) if p.sale_id else 0.0,  # TODO cleanme
            //                   'tracking_number': False}]
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> CancelShipmentAsync(Guid id, DeliveryCarrierCancelShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def cancel_shipment(self, pickings):
            // ''' Cancel a shipment
            // 
            // :param pickings: A recordset of pickings
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_cancel_shipment' % self.delivery_type):
            //     return getattr(self, '%s_cancel_shipment' % self.delivery_type)(pickings)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> CheckInStoreDmHasWarehousesWhenPublishedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _check_in_store_dm_has_warehouses_when_published(self):
            // if any(self.filtered(
            //     lambda dm: dm.delivery_type == 'in_store'
            //     and dm.is_published
            //     and not dm.warehouse_ids
            // )):
            //     raise ValidationError(
            //         _("The delivery method must have at least one warehouse to be published.")
            //     )
            */
            return default;
        }

        protected async Task<DeliveryCarrier> CheckTagsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _check_tags(self):
            // for carrier in self:
            //     if carrier.must_have_tag_ids & carrier.excluded_tag_ids:
            //         raise UserError(_("Carrier %s cannot have the same tag in both Must Have Tags and Excluded Tags.") % carrier.name)
            */
            return default;
        }

        protected async Task<DeliveryCarrier> CheckWarehousesHaveSameCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _check_warehouses_have_same_company(self):
            // for dm in self:
            //     if dm.delivery_type == 'in_store' and dm.company_id and any(
            //         wh.company_id and dm.company_id != wh.company_id for wh in dm.warehouse_ids
            //     ):
            //         raise ValidationError(
            //             _("The delivery method and a warehouse must share the same company")
            //         )
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeCanGenerateReturnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_can_generate_return(self):
            // for carrier in self:
            //     carrier.can_generate_return = False
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeCurrencyInternalAsync(object order, object price, object conversion)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_currency(self, order, price, conversion):
            // from_currency, to_currency = self._get_conversion_currencies(order, conversion)
            // if from_currency.id == to_currency.id:
            //     return price
            // return from_currency._convert(price, to_currency, order.company_id, order.date_order or fields.Date.today())
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeFixedPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_fixed_price(self):
            // for carrier in self:
            //     carrier.fixed_price = carrier.product_id.list_price
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeIsMondialrelayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def _compute_is_mondialrelay(self):
            // for c in self:
            //     c.is_mondialrelay = c.product_id.default_code == "MR"
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeSupportsShippingInsuranceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_supports_shipping_insurance(self):
            // for carrier in self:
            //     carrier.supports_shipping_insurance = False
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeVolumeUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self.env['product.template']._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<DeliveryCarrier> CopyDataAsync(Guid id, DeliveryCarrierCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", carrier.name)) for carrier, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<DeliveryCarrier> CreateAsync(DeliveryCarrier entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('delivery_type') == 'in_store':
            //         vals['integration_level'] = 'rate'
            //         vals['allow_cash_on_delivery'] = False
            // 
            //         # Set the default warehouses and publish if one is found.
            //         if 'company_id' in vals:
            //             company_id = vals.get('company_id')
            //         else:
            //             company_id = (
            //                 self.env['product.product'].browse(vals.get('product_id')).company_id.id
            //                 or self.env.company.id
            //             )
            //         warehouses = self.env['stock.warehouse'].search(
            //             [('company_id', 'in', company_id)]
            //         )
            //         vals.update({
            //             'warehouse_ids': [Command.set(warehouses.ids)],
            //             'is_published': bool(warehouses),
            //         })
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<DeliveryCarrier> FixedCancelShipmentAsync(Guid id, DeliveryCarrierFixedCancelShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_cancel_shipment(self, pickings):
            // raise NotImplementedError()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> FixedGetTrackingLinkAsync(Guid id, DeliveryCarrierFixedGetTrackingLinkRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def fixed_get_tracking_link(self, picking):
            // if self.is_mondialrelay:
            //     return self.base_on_rule_get_tracking_link(picking)
            // return super().fixed_get_tracking_link(picking)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_get_tracking_link(self, picking):
            // if self.tracking_url and picking.carrier_tracking_ref:
            //     return self.tracking_url.replace("<shipmenttrackingnumber>", picking.carrier_tracking_ref)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> FixedRateShipmentAsync(Guid id, DeliveryCarrierFixedRateShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def fixed_rate_shipment(self, order):
            // carrier = self._match_address(order.partner_shipping_id)
            // if not carrier:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': _('Error: this delivery method is not available for this address.'),
            //             'warning_message': False}
            // price = order.pricelist_id._get_product_price(self.product_id, 1.0)
            // return {'success': True,
            //         'price': price,
            //         'error_message': False,
            //         'warning_message': False}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> FixedSendShippingAsync(Guid id, DeliveryCarrierFixedSendShippingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_send_shipping(self, pickings):
            // res = []
            // for p in pickings:
            //     res = res + [{'exact_price': p.carrier_id.fixed_price,
            //                   'tracking_number': False}]
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> GelatoRateShipmentAsync(Guid id, DeliveryCarrierGelatoRateShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def gelato_rate_shipment(self, order):
            // """ Fetch the Gelato delivery price based on products, quantity and address.
            // 
            // This method is called by `delivery`'s `rate_shipment` method.
            // 
            // Note: `self._ensure_one()` from `rate_shipment`
            // 
            // :param sale.order order: The order for which to fetch the delivery price.
            // :return: The shipment rate request results.
            // :rtype: dict
            // """
            // if error_message := order._ensure_partner_address_is_complete():
            //     return {
            //         'success': False,
            //         'price': 0,
            //         'error_message': error_message,
            //     }
            // 
            // # Fetch the delivery price from Gelato.
            // payload = {
            //     'orderReferenceId': order.id,
            //     'customerReferenceId': f'Odoo Partner #{order.partner_id.id}',
            //     'currency': order.currency_id.name,
            //     'allowMultipleQuotes': 'true',
            //     'products': order._gelato_prepare_items_payload(),
            //     'recipient': order.partner_shipping_id._gelato_prepare_address_payload(),
            // }
            // try:
            //     api_key = order.company_id.sudo().gelato_api_key  # In sudo mode to read on the company.
            //     order_data = utils.make_request(api_key, 'order', 'v4', 'orders:quote', payload=payload)
            // except UserError as e:
            //     return {
            //         'success': False,
            //         'price': 0,
            //         'error_message': str(e),
            //     }
            // 
            // # Find the total delivery price by summing all products' matching methods' minimum price.
            // total_delivery_price = 0
            // for quote_data in order_data['quotes']:
            //     matching_shipment_method_prices = [
            //         shipment_method_data['price']
            //         for shipment_method_data in quote_data['shipmentMethods']
            //         if shipment_method_data['type'] == self.gelato_shipping_service_type
            //     ]
            //     if not matching_shipment_method_prices:
            //         return {
            //             'success': False,
            //             'price': 0,
            //             'error_message': _("The delivery method is not available for this order."),
            //         }
            //     else:
            //         total_delivery_price += min(matching_shipment_method_prices)
            // 
            // return {
            //     'success': True,
            //     'price': total_delivery_price,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> GetCommoditiesFromOrderInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_commodities_from_order(self, order):
            // commodities = []
            // 
            // for line in order.order_line.filtered(lambda line: not line.is_delivery and not line.display_type and line.product_id.type == 'consu'):
            //     unit_quantity = line.product_uom_id._compute_quantity(line.product_uom_qty, line.product_id.uom_id)
            //     rounded_qty = max(1, float_round(unit_quantity, precision_digits=0))
            //     country_of_origin = line.product_id.country_of_origin.code or order.warehouse_id.partner_id.country_id.code
            //     commodities.append(DeliveryCommodity(
            //         line.product_id,
            //         amount=rounded_qty,
            //         monetary_value=line.price_reduce_taxinc,
            //         country_of_origin=country_of_origin,
            //     ))
            // 
            // return commodities
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetCommoditiesFromStockMoveLinesInternalAsync(object move_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_commodities_from_stock_move_lines(self, move_lines):
            // commodities = []
            // 
            // product_lines = move_lines.filtered(lambda line: line.product_id.type == 'consu')
            // for product, lines in groupby(product_lines, lambda x: x.product_id):
            //     unit_quantity = sum(
            //         line.product_uom_id._compute_quantity(
            //             line.quantity,
            //             product.uom_id)
            //         for line in lines)
            //     rounded_qty = max(1, float_round(unit_quantity, precision_digits=0))
            //     country_of_origin = product.country_of_origin.code or lines[0].picking_id.picking_type_id.warehouse_id.partner_id.country_id.code
            //     unit_price = sum(line.sale_price for line in lines) / rounded_qty
            //     commodities.append(DeliveryCommodity(product, amount=rounded_qty, monetary_value=unit_price, country_of_origin=country_of_origin))
            // 
            // return commodities
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetConversionCurrenciesInternalAsync(object order, object conversion)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_conversion_currencies(self, order, conversion):
            // company_currency = (self.company_id or self.env['res.company']._get_main_company()).currency_id
            // pricelist_currency = order.currency_id
            // 
            // if conversion == 'company_to_pricelist':
            //     return company_currency, pricelist_currency
            // elif conversion == 'pricelist_to_company':
            //     return pricelist_currency, company_currency
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDefaultCustomPackageCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_default_custom_package_code(self):
            // """ Some delivery carriers require a prefix to be sent in order to use custom
            // packages (ie not official ones). This optional method will return it as a string.
            // """
            // self.ensure_one()
            // if hasattr(self, '_%s_get_default_custom_package_code' % self.delivery_type):
            //     return getattr(self, '_%s_get_default_custom_package_code' % self.delivery_type)()
            // else:
            //     return False
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryDocPrefixInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_doc_prefix(self):
            // return 'ShippingDoc-%s' % self.delivery_type
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryLabelPrefixInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_label_prefix(self):
            // return 'LabelShipping-%s' % self.delivery_type
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_type(self):
            // """Return the delivery type.
            // 
            // This method needs to be overridden by a delivery carrier module if the delivery type is not
            // stored on the field `delivery_type`.
            // """
            // self.ensure_one()
            // return self.delivery_type
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPackagesFromOrderInternalAsync(object order, object default_package_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_packages_from_order(self, order, default_package_type):
            // packages = []
            // 
            // total_cost = 0
            // for line in order.order_line.filtered(lambda line: not line.is_delivery and not line.display_type):
            //     total_cost += self._product_price_to_company_currency(line.product_qty, line.product_id, order.company_id)
            // 
            // total_weight = order._get_estimated_weight() + default_package_type.base_weight
            // order_weight = self.env.context.get('order_weight', False)
            // total_weight = order_weight or total_weight
            // if total_weight == 0.0:
            //     weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            //     raise UserError(_("The package cannot be created because the total weight of the products in the picking is 0.0 %s", weight_uom_name))
            // # If max weight == 0 => division by 0. If this happens, we want to have
            // # more in the max weight than in the total weight, so that it only
            // # creates ONE package with everything.
            // max_weight = default_package_type.max_weight or total_weight + 1
            // total_full_packages = int(total_weight / max_weight)
            // last_package_weight = total_weight % max_weight
            // 
            // package_weights = [max_weight] * total_full_packages + ([last_package_weight] if last_package_weight else [])
            // partial_cost = total_cost / len(package_weights)  # separate the cost uniformly
            // order_commodities = self._get_commodities_from_order(order)
            // 
            // # Split the commodities value uniformly as well
            // for commodity in order_commodities:
            //     commodity.monetary_value /= len(package_weights)
            //     commodity.qty = max(1, commodity.qty // len(package_weights))
            // 
            // for weight in package_weights:
            //     packages.append(DeliveryPackage(
            //         order_commodities,
            //         weight,
            //         default_package_type,
            //         total_cost=partial_cost,
            //         currency=order.company_id.currency_id,
            //         order=order,
            //     ))
            // return packages
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPackagesFromPickingInternalAsync(object picking, object default_package_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_packages_from_picking(self, picking, default_package_type):
            // packages = []
            // 
            // if picking.is_return_picking:
            //     commodities = self._get_commodities_from_stock_move_lines(picking.move_line_ids)
            //     weight = picking._get_estimated_weight() + default_package_type.base_weight
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         weight,
            //         default_package_type,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            //     return packages
            // 
            // # Create all packages.
            // for package in picking.move_line_ids.result_package_id:
            //     move_lines = picking.move_line_ids.filtered(lambda ml: ml.result_package_id == package)
            //     commodities = self._get_commodities_from_stock_move_lines(move_lines)
            //     package_total_cost = 0.0
            //     for quant in package.quant_ids:
            //         package_total_cost += self._product_price_to_company_currency(
            //             quant.quantity, quant.product_id, picking.company_id
            //         )
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         package.shipping_weight or package.weight,
            //         package.package_type_id,
            //         name=package.name,
            //         total_cost=package_total_cost,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            // 
            // # Create one package: either everything is in pack or nothing is.
            // if picking.weight_bulk:
            //     commodities = self._get_commodities_from_stock_move_lines(picking.move_line_ids)
            //     package_total_cost = 0.0
            //     for move_line in picking.move_line_ids:
            //         package_total_cost += self._product_price_to_company_currency(
            //             move_line.quantity, move_line.product_id, picking.company_id
            //         )
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         picking.weight_bulk,
            //         default_package_type,
            //         name='Bulk Content',
            //         total_cost=package_total_cost,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            // elif not packages:
            //     raise UserError(_(
            //         "The package cannot be created because the total weight of the "
            //         "products in the picking is 0.0 %s",
            //         picking.weight_uom_name
            //     ))
            // return packages
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceAvailableInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_available(self, order):
            // self.ensure_one()
            // self = self.sudo()
            // order = order.sudo()
            // total = weight = volume = quantity = wv = 0
            // total_delivery = 0.0
            // for line in order.order_line:
            //     if line.state == 'cancel':
            //         continue
            //     if line.is_delivery:
            //         total_delivery += line.price_total
            //     if not line.product_id or line.is_delivery:
            //         continue
            //     if line.product_id.type == "service":
            //         continue
            //     qty = line.product_uom_id._compute_quantity(line.product_uom_qty, line.product_id.uom_id)
            //     weight += (line.product_id.weight or 0.0) * qty
            //     volume += (line.product_id.volume or 0.0) * qty
            //     wv += (line.product_id.weight or 0.0) * (line.product_id.volume or 0.0) * qty
            //     quantity += qty
            // total = (order.amount_total or 0.0) - total_delivery
            // 
            // total = self._compute_currency(order, total, 'pricelist_to_company')
            // # weight is either,
            // # 1- weight chosen by user in choose.delivery.carrier wizard passed by context
            // # 2- saved weight to use on sale order
            // # 3- total order line weight as fallback
            // weight = self.env.context.get('order_weight') or order.shipping_weight or weight
            // return self._get_price_from_picking(total, weight, volume, quantity, wv=wv)
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceDictInternalAsync(object total, object weight, object volume, object quantity, object wv)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_dict(self, total, weight, volume, quantity, wv=0.):
            // '''Hook allowing to retrieve dict to be used in _get_price_from_picking() function.
            // Hook to be overridden when we need to add some field to product and use it in variable factor from price rules. '''
            // return {
            //     'price': total,
            //     'volume': volume,
            //     'weight': weight,
            //     'wv': wv or volume * weight,
            //     'quantity': quantity
            // }
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceFromPickingInternalAsync(object total, object weight, object volume, object quantity, object wv)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_from_picking(self, total, weight, volume, quantity, wv=0.):
            // price = 0.0
            // criteria_found = False
            // price_dict = self._get_price_dict(total, weight, volume, quantity, wv=wv)
            // for line in self.price_rule_ids:
            //     test = safe_eval(line.variable + line.operator + str(line.max_value), price_dict)
            //     if test:
            //         price = line.list_base_price + line.list_price * price_dict[line.variable_factor]
            //         criteria_found = True
            //         break
            // if not criteria_found:
            //     raise UserError(_("Not available for current order"))
            // 
            // return price
            */
            return default;
        }

        public async Task<DeliveryCarrier> GetReturnLabelAsync(Guid id, DeliveryCarrierGetReturnLabelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_return_label(self, pickings, tracking_number=None, origin_date=None):
            // self.ensure_one()
            // if self.can_generate_return:
            //     res = getattr(self, '%s_get_return_label' % self.delivery_type)(
            //         pickings, tracking_number, origin_date
            //     )
            //     if self.get_return_label_from_portal:
            //         pickings.return_label_ids.generate_access_token()
            //     return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> GetReturnLabelPrefixAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_return_label_prefix(self):
            // return 'LabelReturn-%s' % self.delivery_type
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> GetTrackingLinkAsync(Guid id, DeliveryCarrierGetTrackingLinkRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_tracking_link(self, picking):
            // ''' Ask the tracking link to the service provider
            // 
            // :param picking: record of stock.picking
            // :returns: an URL containing the tracking link or None
            // :rtype: str | None
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_get_tracking_link' % self.delivery_type):
            //     return getattr(self, '%s_get_tracking_link' % self.delivery_type)(picking)
            // return None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> InStoreGetCloseLocationsInternalAsync(object partner_address, Guid product_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _in_store_get_close_locations(self, partner_address, product_id=None):
            // """ Get the formatted close pickup locations sorted by distance to the partner address.
            // 
            // :param res.partner partner_address: The address to use to sort the pickup locations.
            // :param str product_id: The product whose product page was used to open the location
            //                        selector, if any, as a `product.product` id.
            // :return: The sorted and formatted close pickup locations.
            // :rtype: list[dict]
            // """
            // try:
            //     product_id = product_id and int(product_id)
            // except ValueError:
            //     product = self.env['product.product']
            // else:
            //     product = self.env['product.product'].browse(product_id)
            // 
            // partner_address.geo_localize()  # Calculate coordinates.
            // 
            // pickup_locations = []
            // order_sudo = request.cart
            // for wh in self.warehouse_ids:
            //     pickup_location_values = wh._prepare_pickup_location_data()
            //     if not pickup_location_values:  # Ignore warehouses with badly configured addresses.
            //         continue
            // 
            //     # Prepare the stock data based on either the product or the order.
            //     if product:  # Called from the product page.
            //         in_store_stock_data = utils.format_product_stock_values(product, wh.id)
            //     else:  # Called from the checkout page.
            //         in_store_stock_data = {'in_stock': order_sudo._is_in_stock(wh.id)}
            // 
            //     # Calculate the distance between the partner address and the warehouse location.
            //     pickup_location_values.update({
            //         'additional_data': {'in_store_stock_data': in_store_stock_data},
            //         'distance': utils.calculate_partner_distance(partner_address, wh.partner_id),
            //     })
            //     pickup_locations.append(pickup_location_values)
            // 
            // return sorted(pickup_locations, key=lambda k: k['distance'])
            */
            return default;
        }

        public async Task<DeliveryCarrier> InStoreRateShipmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def in_store_rate_shipment(self, *_args):
            // return {
            //     'success': True,
            //     'price': self.product_id.list_price,
            //     'error_message': False,
            //     'warning_message': False,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> InstallMoreProviderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def install_more_provider(self):
            // exclude_apps = ['delivery_barcode', 'delivery_stock_picking_batch', 'delivery_iot']
            // return {
            //     'name': _('New Providers'),
            //     'res_model': 'ir.module.module',
            //     'view_mode': 'kanban,list',
            //     'views': [
            //         (self.env.ref('delivery.delivery_provider_module_kanban').id, 'kanban'),
            //         (self.env.ref('delivery.delivery_provider_module_list').id, 'list'),
            //     ],
            //     'domain': [['name', '=like', 'delivery_%'], ['name', 'not in', exclude_apps]],
            //     'type': 'ir.actions.act_window',
            //     'help': _('''<p class="o_view_nocontent">
            //             Buy Odoo Enterprise now to get more providers.
            //         </p>'''),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> IsAvailableForOrderInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _is_available_for_order(self, order):
            // self.ensure_one()
            // order.ensure_one()
            // if not self._match(order.partner_shipping_id, order):
            //     return False
            // 
            // if self.delivery_type == 'base_on_rule':
            //     return self.rate_shipment(order).get('success')
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def _is_available_for_order(self, order):
            // """ Override of `delivery` to exclude regular delivery methods from Gelato orders and Gelato
            // delivery methods from non-Gelato orders.
            // 
            // :param sale.order order: The current order.
            // :return: Whether the delivery method is available for the order.
            // :rtype: bool
            // """
            // is_gelato_order = any(order.order_line.product_id.mapped('gelato_product_uid'))
            // is_gelato_delivery = self.delivery_type == 'gelato'
            // if is_gelato_order and not is_gelato_delivery or not is_gelato_order and is_gelato_delivery:
            //     return False
            // return super()._is_available_for_order(order)
            */
            return default;
        }

        public async Task<DeliveryCarrier> LogXmlAsync(Guid id, DeliveryCarrierLogXmlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def log_xml(self, xml_string, func):
            // self.ensure_one()
            // 
            // if self.debug_logging:
            //     self.env.flush_all()
            //     db_name = self.env.cr.dbname
            // 
            //     # Use a new cursor to avoid rollback that could be caused by an upper method
            //     try:
            //         db_registry = Registry(db_name)
            //         with db_registry.cursor() as cr:
            //             env = api.Environment(cr, SUPERUSER_ID, {})
            //             IrLogging = env['ir.logging']
            //             IrLogging.sudo().create({'name': 'delivery.carrier',
            //                       'type': 'server',
            //                       'dbname': db_name,
            //                       'level': 'DEBUG',
            //                       'message': xml_string,
            //                       'path': self.delivery_type,
            //                       'func': func,
            //                       'line': 1})
            //     except psycopg2.Error:
            //         pass
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> MatchAddressInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_address(self, partner):
            // self.ensure_one()
            // if self.country_ids and partner.country_id not in self.country_ids:
            //     return False
            // if self.state_ids and partner.state_id not in self.state_ids:
            //     return False
            // if self.zip_prefix_ids:
            //     regex = re.compile('|'.join(['^' + zip_prefix for zip_prefix in self.zip_prefix_ids.mapped('name')]))
            //     if not partner.zip or not re.match(regex, partner.zip.upper()):
            //         return False
            // return True
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchExcludedTagsInternalAsync(object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_excluded_tags(self, source):
            // self.ensure_one()
            // if source._name == 'sale.order':
            //     products = source.order_line.product_id
            // elif source._name == 'stock.picking':
            //     products = source.move_ids.with_prefetch().mapped('product_id')
            // else:
            //     raise UserError(_("Invalid source document type"))
            // return not any(tag in products.all_product_tag_ids for tag in self.excluded_tag_ids)
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchInternalAsync(object partner, object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match(self, partner, source):
            // self.ensure_one()
            // return (
            //     self._match_address(partner)
            //     and self._match_must_have_tags(source)
            //     and self._match_excluded_tags(source)
            //     and self._match_weight(source)
            //     and self._match_volume(source)
            // )
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchMustHaveTagsInternalAsync(object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_must_have_tags(self, source):
            // self.ensure_one()
            // if source._name == 'sale.order':
            //     products = source.order_line.product_id
            // elif source._name == 'stock.picking':
            //     products = source.move_ids.with_prefetch().mapped('product_id')
            // else:
            //     raise UserError(_("Invalid source document type"))
            // return not self.must_have_tag_ids or any(
            //     tag in products.all_product_tag_ids
            //     for tag in self.must_have_tag_ids
            // )
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchVolumeInternalAsync(object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_volume(self, source):
            // self.ensure_one()
            // if source._name == 'sale.order':
            //     total_volume = sum(
            //         line.product_id.volume * line.product_qty
            //         for line in source.order_line
            //     )
            // elif source._name == 'stock.picking':
            //     total_volume = sum(
            //         move.product_id.volume * move.product_uom_qty
            //         for move in source.move_ids
            //     )
            // else:
            //     raise UserError(_("Invalid source document type"))
            // return not self.max_volume or total_volume <= self.max_volume
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchWeightInternalAsync(object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_weight(self, source):
            // self.ensure_one()
            // if source._name == 'sale.order':
            //     total_weight = sum(
            //         line.product_id.weight * line.product_qty
            //         for line in source.order_line
            //     )
            // elif source._name == 'stock.picking':
            //     total_weight = sum(
            //         move.product_id.weight * move.product_uom_qty
            //         for move in source.move_ids
            //     )
            // else:
            //     raise UserError(_("Invalid source document type"))
            // return not self.max_weight or total_weight <= self.max_weight
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeCanGenerateReturnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_can_generate_return(self):
            // if not self.can_generate_return:
            //     self.return_label_on_delivery = False
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeCountryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_country_ids(self):
            // self.state_ids -= self.state_ids.filtered(
            //     lambda state: state._origin.id not in self.country_ids.state_ids.ids
            // )
            // if not self.country_ids:
            //     self.zip_prefix_ids = [Command.clear()]
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeIntegrationLevelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_integration_level(self):
            // if self.integration_level == 'rate':
            //     self.invoice_policy = 'estimated'
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeReturnLabelOnDeliveryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_return_label_on_delivery(self):
            // if not self.return_label_on_delivery:
            //     self.get_return_label_from_portal = False
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ProductPriceToCompanyCurrencyInternalAsync(object quantity, object product, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _product_price_to_company_currency(self, quantity, product, company):
            // return company.currency_id._convert(quantity * product.standard_price, product.currency_id, company, fields.Date.today())
            */
            return default;
        }

        public async Task<DeliveryCarrier> RateShipmentAsync(Guid id, DeliveryCarrierRateShipmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def rate_shipment(self, order):
            // ''' Compute the price of the order shipment
            // 
            // :param order: record of sale.order
            // :returns: a dict with structure
            //   ::
            // 
            //     {'success': boolean,
            //      'price': a float,
            //      'error_message': a string containing an error message,
            //      'warning_message': a string containing a warning message}
            // :rtype: dict
            // '''
            // # TODO maybe the currency code?
            // self.ensure_one()
            // if hasattr(self, '%s_rate_shipment' % self.delivery_type):
            //     res = getattr(self, '%s_rate_shipment' % self.delivery_type)(order)
            //     # apply fiscal position
            //     company = self.company_id or order.company_id or self.env.company
            //     res['price'] = self.product_id._get_tax_included_unit_price(
            //         company,
            //         company.currency_id,
            //         order.date_order,
            //         'sale',
            //         fiscal_position=order.fiscal_position_id,
            //         product_price_unit=res['price'],
            //         product_currency=company.currency_id
            //     )
            //     # apply margin on computed price
            //     res['price'] = self._apply_margins(res['price'], order)
            //     # save the real price in case a free_over rule overide it to 0
            //     res['carrier_price'] = res['price']
            //     # free when order is large enough
            //     amount_without_delivery = order._compute_amount_total_without_delivery()
            //     if (
            //         res['success']
            //         and self.free_over
            //         and self.delivery_type != 'base_on_rule'
            //         and self._compute_currency(order, amount_without_delivery, 'pricelist_to_company') >= self.amount
            //     ):
            //         res['warning_message'] = _('The shipping is free since the order amount exceeds %.2f.', self.amount)
            //         res['price'] = 0.0
            //     return res
            // else:
            //     return {
            //         'success': False,
            //         'price': 0.0,
            //         'error_message': _('Error: this delivery method is not available.'),
            //         'warning_message': False,
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> SearchIsMondialrelayInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def _search_is_mondialrelay(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('product_id.default_code', '=', 'MR')]
            */
            return default;
        }

        public async Task<DeliveryCarrier> SendShippingAsync(Guid id, DeliveryCarrierSendShippingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def send_shipping(self, pickings):
            // ''' Send the package to the service provider
            // 
            // :param pickings: A recordset of pickings
            // :returns: A list of dictionaries (one per picking) containing of
            //     the form::
            // 
            //                  { 'exact_price': price,
            //                    'tracking_number': number }
            // :rtype: list[dict] | None
            // '''
            // # TODO missing labels per package
            // # TODO missing currency
            // # TODO missing success, error, warnings
            // self.ensure_one()
            // if hasattr(self, '%s_send_shipping' % self.delivery_type):
            //     return getattr(self, '%s_send_shipping' % self.delivery_type)(pickings)
            // return None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DeliveryCarrier> SetProductFixedPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _set_product_fixed_price(self):
            // for carrier in self:
            //     carrier.product_id.list_price = carrier.fixed_price
            */
            return default;
        }

        public async Task<DeliveryCarrier> ToggleDebugAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def toggle_debug(self):
            // for c in self:
            //     c.debug_logging = not c.debug_logging
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DeliveryCarrier> ToggleProdEnvironmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def toggle_prod_environment(self):
            // for c in self:
            //     c.prod_environment = not c.prod_environment
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, DeliveryCarrier entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def write(self, vals):
            // if vals.get('delivery_type') == 'in_store':
            //     vals['integration_level'] = 'rate'
            //     vals['allow_cash_on_delivery'] = False
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}