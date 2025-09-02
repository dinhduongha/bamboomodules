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
    [Module("Product", Depends = new[] { "base", "mail", "uom" })]
    public class ProductProductAppService : GenericApplicationService<ProductProduct>, IProductProductAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductProductAppService(IRepository<ProductProduct, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ProductProduct> AddMissingProductsInternalAsync(object products, Guid config_id, object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _add_missing_products(self, products, config_id, data):
            // product_ids_in_loaded_lines = {line['product_id'] for line in data['pos.order.line']['data']}
            // not_loaded_product_ids = product_ids_in_loaded_lines - {product['id'] for product in products}
            // products.extend(self._load_product_with_domain([('id', 'in', list(not_loaded_product_ids))], config_id, True))
            */
            return default;
        }

        public async Task<ProductProduct> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_archive(self):
            // filtered_products = self.env['mrp.bom.line'].search([('product_id', 'in', self.ids), ('bom_id.active', '=', True)]).product_id.mapped('display_name')
            // res = super().action_archive()
            // if filtered_products:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //         'title': _("Note that product(s): '%s' is/are still linked to active Bill of Materials, "
            //                     "which means that the product can still be used on it/them.", filtered_products),
            //         'type': 'warning',
            //         'sticky': True,  #True/False will display for few seconds if false
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> BomCostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def action_bom_cost(self):
            // boms_to_recompute = self.env['mrp.bom'].search(['|', ('product_id', 'in', self.ids), '&', ('product_id', '=', False), ('product_tmpl_id', 'in', self.mapped('product_tmpl_id').ids)])
            // for product in self:
            //     product._set_price_from_bom(boms_to_recompute)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ButtonBomCostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def button_bom_cost(self):
            // self.ensure_one()
            // self._set_price_from_bom()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> ChangeStandardPriceInternalAsync(object new_price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _change_standard_price(self, new_price):
            // """Helper to create the stock valuation layers and the account moves
            // after an update of standard price.
            // 
            // :param new_price: new standard price
            // """
            // # Handle stock valuation layers.
            // 
            // if self.filtered(lambda p: p.valuation == 'real_time') and not self.env['stock.valuation.layer'].has_access('read'):
            //     raise UserError(_("You cannot update the cost of a product in automated valuation as it leads to the creation of a journal entry, for which you don't have the access rights."))
            // 
            // svl_vals_list = []
            // company_id = self.env.company
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // rounded_new_price = float_round(new_price, precision_digits=price_unit_prec)
            // for product in self:
            //     if product.cost_method not in ('standard', 'average'):
            //         continue
            //     if product.lot_valuated:
            //         self.env['stock.lot'].search([('product_id', '=', product.id)]).standard_price = new_price
            //         continue
            //     quantity_svl = product.sudo().quantity_svl
            //     if float_compare(quantity_svl, 0.0, precision_rounding=product.uom_id.rounding) <= 0:
            //         continue
            //     value_svl = product.sudo().value_svl
            //     value = company_id.currency_id.round((rounded_new_price * quantity_svl) - value_svl)
            //     if company_id.currency_id.is_zero(value):
            //         continue
            // 
            //     svl_vals = {
            //         'company_id': company_id.id,
            //         'product_id': product.id,
            //         'description': _(
            //             'Product value manually modified (from %(original_price)s to %(new_price)s)',
            //             original_price=product.standard_price,
            //             new_price=rounded_new_price,
            //         ),
            //         'value': value,
            //         'quantity': 0,
            //     }
            //     svl_vals_list.append(svl_vals)
            // stock_valuation_layers = self.env['stock.valuation.layer'].sudo().create(svl_vals_list)
            // stock_valuation_layers._change_standart_price_accounting_entries(new_price)
            */
            return default;
        }

        protected async Task<ProductProduct> CheckBarcodeUniquenessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _check_barcode_uniqueness(self):
            // """ With GS1 nomenclature, products and packagings use the same pattern. Therefore, we need
            // to ensure the uniqueness between products' barcodes and packagings' ones"""
            // # Barcodes should only be unique within a company
            // for company_id, barcodes_within_company in self._get_barcodes_by_company():
            //     self._check_duplicated_product_barcodes(barcodes_within_company, company_id)
            //     self._check_duplicated_packaging_barcodes(barcodes_within_company, company_id)
            */
            return default;
        }

        protected async Task<ProductProduct> CheckBaseUnitCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _check_base_unit_count(self):
            // if any(product.base_unit_count < 0 for product in self):
            //     raise ValidationError(_(
            //         "The value of Base Unit Count must be greater than 0."
            //         " Use 0 to hide the price per unit on this product."
            //     ))
            */
            return default;
        }

        protected async Task<ProductProduct> CheckCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _check_company_id(self):
            // combo_items = self.env['product.combo.item'].sudo().search([('product_id', 'in', self.ids)])
            // combo_items._check_company(fnames=['product_id'])
            */
            return default;
        }

        protected async Task<ProductProduct> CheckDuplicatedPackagingBarcodesInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _check_duplicated_packaging_barcodes(self, barcodes_within_company, company_id):
            // packaging_domain = self._get_barcode_search_domain(barcodes_within_company, company_id)
            // if self.env['product.packaging'].sudo().search_count(packaging_domain, limit=1):
            //     raise ValidationError(_("A packaging already uses the barcode"))
            */
            return default;
        }

        protected async Task<ProductProduct> CheckDuplicatedProductBarcodesInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _check_duplicated_product_barcodes(self, barcodes_within_company, company_id):
            // domain = self._get_barcode_search_domain(barcodes_within_company, company_id)
            // products_by_barcode = self.sudo().read_group(domain, ['barcode', 'id:array_agg'], ['barcode'])
            // 
            // duplicates_as_str = "\n".join(
            //     _(
            //         "- Barcode \"%(barcode)s\" already assigned to product(s): %(product_list)s",
            //         barcode=record['barcode'], product_list=format_list(self.env, [p.display_name for p in self.search([('id', 'in', record['id'])])]),
            //     )
            //     for record in products_by_barcode if len(record['id']) > 1
            // )
            // if duplicates_as_str.strip():
            //     duplicates_as_str += _(
            //         "\n\nNote: products that you don't have access to will not be shown above."
            //     )
            //     raise ValidationError(_("Barcode(s) already assigned:\n\n%s", duplicates_as_str))
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeAllProductTagIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_all_product_tag_ids(self):
            // for product in self:
            //     product.all_product_tag_ids = (
            //         product.product_tag_ids | product.additional_product_tag_ids
            //     ).sorted('sequence')
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeAveragePriceInternalAsync(object qty_invoiced, object qty_to_invoice, object stock_moves, object is_returned)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _compute_average_price(self, qty_invoiced, qty_to_invoice, stock_moves, is_returned=False):
            // self.ensure_one()
            // if stock_moves.product_id == self:
            //     return super()._compute_average_price(qty_invoiced, qty_to_invoice, stock_moves, is_returned=is_returned)
            // bom = self.env['mrp.bom']._bom_find(self, company_id=stock_moves.company_id.id, bom_type='phantom')[self]
            // if not bom:
            //     return super()._compute_average_price(qty_invoiced, qty_to_invoice, stock_moves, is_returned=is_returned)
            // value = 0
            // dummy, bom_lines = bom.explode(self, 1)
            // bom_lines = {line: data for line, data in bom_lines}
            // for bom_line, moves_list in groupby(stock_moves.filtered(lambda sm: sm.state != 'cancel'), lambda sm: sm.bom_line_id):
            //     if bom_line not in bom_lines:
            //         for move in moves_list:
            //             component_quantity = next(
            //                 (bml.product_qty for bml in move.product_id.bom_line_ids if bml in bom_lines),
            //                 1
            //             )
            //             value += component_quantity * move.product_id._compute_average_price(qty_invoiced * move.product_qty, qty_to_invoice * move.product_qty, move, is_returned=is_returned)
            //         continue
            //     line_qty = bom_line.product_uom_id._compute_quantity(bom_lines[bom_line]['qty'], bom_line.product_id.uom_id)
            //     moves = self.env['stock.move'].concat(*moves_list)
            //     value += line_qty * bom_line.product_id._compute_average_price(qty_invoiced * line_qty, qty_to_invoice * line_qty, moves, is_returned=is_returned)
            // return value
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_average_price(self, qty_invoiced, qty_to_invoice, stock_moves, is_returned=False):
            // """Go over the valuation layers of `stock_moves` to value `qty_to_invoice` while taking
            // care of ignoring `qty_invoiced`. If `qty_to_invoice` is greater than what's possible to
            // value with the valuation layers, use the product's standard price.
            // 
            // :param qty_invoiced: quantity already invoiced
            // :param qty_to_invoice: quantity to invoice
            // :param stock_moves: recordset of `stock.move`
            // :param is_returned: if True, consider the incoming moves
            // :returns: the anglo saxon price unit
            // :rtype: float
            // """
            // self.ensure_one()
            // if not qty_to_invoice:
            //     return 0
            // 
            // candidates = self.env['stock.valuation.layer'].sudo()
            // for move in stock_moves.sudo():
            //     move_candidates = move._get_layer_candidates()
            //     if is_returned != bool(move.origin_returned_move_id and sum(move_candidates.mapped('quantity')) >= 0):
            //         continue
            //     candidates |= move_candidates
            // 
            // if self.env.context.get('candidates_prefetch_ids'):
            //     candidates = candidates.with_prefetch(self.env.context.get('candidates_prefetch_ids'))
            // 
            // if len(candidates) > 1:
            //     # sort candidates by create_date > existing records by id > new records without origin
            //     candidates = candidates.sorted(lambda svl: (svl.create_date, not bool(svl.ids), svl.ids[0] if svl.ids else 0))
            // 
            // value_invoiced = self.env.context.get('value_invoiced', 0)
            // if 'value_invoiced' in self.env.context:
            //     qty_valued, valuation = candidates._consume_all(qty_invoiced, value_invoiced, qty_to_invoice)
            // else:
            //     qty_valued, valuation = candidates._consume_specific_qty(qty_invoiced, qty_to_invoice)
            // 
            // # If there's still quantity to invoice but we're out of candidates, we chose the standard
            // # price to estimate the anglo saxon price unit.
            // missing = qty_to_invoice - qty_valued
            // for sml in stock_moves.move_line_ids:
            //     if not sml._should_exclude_for_valuation():
            //         continue
            //     missing -= sml.product_uom_id._compute_quantity(sml.quantity, self.uom_id, rounding_method='HALF-UP')
            // if float_compare(missing, 0, precision_rounding=self.uom_id.rounding) > 0:
            //     valuation += self.standard_price * missing
            // 
            // return valuation / qty_to_invoice
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBaseUnitNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _compute_base_unit_name(self):
            // for product in self:
            //     product.base_unit_name = product.base_unit_id.name or product.uom_name
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBaseUnitPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _compute_base_unit_price(self):
            // for product in self:
            //     if not product.id:
            //         product.base_unit_price = 0
            //     else:
            //         product.base_unit_price = product._get_base_unit_price(product.lst_price)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_bom_count(self):
            // for product in self:
            //     product.bom_count = self.env['mrp.bom'].search_count(['|', '|', ('byproduct_ids.product_id', '=', product.id), ('product_id', '=', product.id), '&', ('product_id', '=', False), ('product_tmpl_id', '=', product.product_tmpl_id.id)])
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBomPriceInternalAsync(object bom, object boms_to_recompute, object byproduct_bom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _compute_bom_price(self, bom, boms_to_recompute=False, byproduct_bom=False):
            // self.ensure_one()
            // if not bom:
            //     return 0
            // if not boms_to_recompute:
            //     boms_to_recompute = []
            // total = 0
            // for opt in bom.operation_ids:
            //     if opt._skip_operation_line(self):
            //         continue
            // 
            //     duration_expected = (
            //         opt.workcenter_id._get_expected_duration(self) +
            //         opt.time_cycle * 100 / opt.workcenter_id.time_efficiency)
            //     total += (duration_expected / 60) * opt._total_cost_per_hour()
            // 
            // for line in bom.bom_line_ids:
            //     if line._skip_bom_line(self):
            //         continue
            // 
            //     # Compute recursive if line has `child_line_ids`
            //     if line.child_bom_id and line.child_bom_id in boms_to_recompute:
            //         child_total = line.product_id._compute_bom_price(line.child_bom_id, boms_to_recompute=boms_to_recompute)
            //         total += line.product_id.uom_id._compute_price(child_total, line.product_uom_id) * line.product_qty
            //     else:
            //         total += line.product_id.uom_id._compute_price(line.product_id.standard_price, line.product_uom_id) * line.product_qty
            // if byproduct_bom:
            //     byproduct_lines = bom.byproduct_ids.filtered(lambda b: b.product_id == self and b.cost_share != 0)
            //     product_uom_qty = 0
            //     for line in byproduct_lines:
            //         product_uom_qty += line.product_uom_id._compute_quantity(line.product_qty, self.uom_id, round=False)
            //     byproduct_cost_share = sum(byproduct_lines.mapped('cost_share'))
            //     if byproduct_cost_share and product_uom_qty:
            //         return total * byproduct_cost_share / 100 / product_uom_qty
            // else:
            //     byproduct_cost_share = sum(bom.byproduct_ids.mapped('cost_share'))
            //     if byproduct_cost_share:
            //         total *= float_round(1 - byproduct_cost_share / 100, precision_rounding=0.0001)
            //     return bom.product_uom_id._compute_price(total / bom.product_qty, self.uom_id)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: product_product.py) ---
            // def _compute_bom_price(self, bom, boms_to_recompute=False, byproduct_bom=False):
            // """ Add the price of the subcontracting supplier if it exists with the bom configuration.
            // """
            // price = super()._compute_bom_price(bom, boms_to_recompute, byproduct_bom)
            // if bom and bom.type == 'subcontract':
            //     seller = self._select_seller(quantity=bom.product_qty, uom_id=bom.product_uom_id, params={'subcontractor_ids': bom.subcontractor_ids})
            //     if seller:
            //         seller_price = seller.currency_id._convert(seller.price, self.env.company.currency_id, (bom.company_id or self.env.company), fields.Date.today())
            //         price += seller.product_uom._compute_price(seller_price, self.uom_id)
            // return price
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCanImage1024BeZoomedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.can_image_1024_be_zoomed = record.can_image_variant_1024_be_zoomed if record.image_variant_1920 else record.product_tmpl_id.can_image_1024_be_zoomed
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCanImageVariant1024BeZoomedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_can_image_variant_1024_be_zoomed(self):
            // for record in self:
            //     record.can_image_variant_1024_be_zoomed = record.image_variant_1920 and is_image_size_above(record.image_variant_1920, record.image_variant_1024)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCombinationIndicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_combination_indices(self):
            // for product in self:
            //     product.combination_indices = product.product_template_attribute_value_ids._ids2str()
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_display_name(self):
            // 
            // def get_display_name(name, code):
            //     if self._context.get('display_default_code', True) and code:
            //         return f'[{code}] {name}'
            //     return name
            // 
            // partner_id = self._context.get('partner_id')
            // if partner_id:
            //     partner_ids = [partner_id, self.env['res.partner'].browse(partner_id).commercial_partner_id.id]
            // else:
            //     partner_ids = []
            // company_id = self.env.context.get('company_id')
            // 
            // # all user don't have access to seller and partner
            // # check access and use superuser
            // self.check_access("read")
            // 
            // product_template_ids = self.sudo().product_tmpl_id.ids
            // 
            // if partner_ids:
            //     # prefetch the fields used by the `display_name`
            //     supplier_info = self.env['product.supplierinfo'].sudo().search_fetch(
            //         [('product_tmpl_id', 'in', product_template_ids), ('partner_id', 'in', partner_ids)],
            //         ['product_tmpl_id', 'product_id', 'company_id', 'product_name', 'product_code'],
            //     )
            //     supplier_info_by_template = {}
            //     for r in supplier_info:
            //         supplier_info_by_template.setdefault(r.product_tmpl_id, []).append(r)
            // 
            // for product in self.sudo():
            //     variant = product.product_template_attribute_value_ids._get_combination_name()
            // 
            //     name = variant and "%s (%s)" % (product.name, variant) or product.name
            //     sellers = self.env['product.supplierinfo'].sudo().browse(self.env.context.get('seller_id')) or []
            //     if not sellers and partner_ids:
            //         product_supplier_info = supplier_info_by_template.get(product.product_tmpl_id, [])
            //         sellers = [x for x in product_supplier_info if x.product_id and x.product_id == product]
            //         if not sellers:
            //             sellers = [x for x in product_supplier_info if not x.product_id]
            //         # Filter out sellers based on the company. This is done afterwards for a better
            //         # code readability. At this point, only a few sellers should remain, so it should
            //         # not be a performance issue.
            //         if company_id:
            //             sellers = [x for x in sellers if x.company_id.id in [company_id, False]]
            //     if sellers:
            //         temp = []
            //         for s in sellers:
            //             seller_variant = s.product_name and (
            //                 variant and "%s (%s)" % (s.product_name, variant) or s.product_name
            //                 ) or False
            //             temp.append(get_display_name(seller_variant or name, s.product_code or product.default_code))
            // 
            //         # => Feature drop here, one record can only have one display_name now, instead separate with `,`
            //         # Remove this comment
            //         product.display_name = ", ".join(unique(temp))
            //     else:
            //         product.display_name = get_display_name(name, product.default_code)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage1024InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_image_1024(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.image_1024 = record.image_variant_1024 or record.product_tmpl_id.image_1024
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_image_128(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.image_128 = record.image_variant_128 or record.product_tmpl_id.image_128
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage1920InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_image_1920(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.image_1920 = record.image_variant_1920 or record.product_tmpl_id.image_1920
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage256InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_image_256(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.image_256 = record.image_variant_256 or record.product_tmpl_id.image_256
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage512InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_image_512(self):
            // """Get the image from the template if no image is set on the variant."""
            // for record in self:
            //     record.image_512 = record.image_variant_512 or record.product_tmpl_id.image_512
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsInPurchaseOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_is_in_purchase_order(self):
            // order_id = self.env.context.get('order_id')
            // if not order_id:
            //     self.is_in_purchase_order = False
            //     return
            // 
            // read_group_data = self.env['purchase.order.line']._read_group(
            //     domain=[('order_id', '=', order_id)],
            //     groupby=['product_id'],
            //     aggregates=['__count'],
            // )
            // data = {product.id: count for product, count in read_group_data}
            // for product in self:
            //     product.is_in_purchase_order = bool(data.get(product.id, 0))
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsKitsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_is_kits(self):
            // domain = ['&', '&', ('type', '=', 'phantom'),
            //                '|', ('company_id', '=', False),
            //                     ('company_id', '=', self.env.company.id),
            //                '|', ('product_id', 'in', self.ids),
            //                     '&', ('product_id', '=', False),
            //                          ('product_tmpl_id', 'in', self.product_tmpl_id.ids)]
            // bom_mapping = self.env['mrp.bom'].sudo().search_read(domain, ['product_tmpl_id', 'product_id'])
            // kits_template_ids = set([])
            // kits_product_ids = set([])
            // for bom_data in bom_mapping:
            //     if bom_data['product_id']:
            //         kits_product_ids.add(bom_data['product_id'][0])
            //     else:
            //         kits_template_ids.add(bom_data['product_tmpl_id'][0])
            // for product in self:
            //     product.is_kits = (product.id in kits_product_ids or product.product_tmpl_id.id in kits_template_ids)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsProductVariantInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = True
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeMrpProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // date_from = fields.Datetime.to_string(fields.datetime.now() - timedelta(days=365))
            // #TODO: state = done?
            // domain = [('state', '=', 'done'), ('product_id', 'in', self.ids), ('date_start', '>', date_from)]
            // read_group_res = self.env['mrp.production']._read_group(domain, ['product_id'], ['product_uom_qty:sum'])
            // mapped_data = {product.id: qty for product, qty in read_group_res}
            // for product in self:
            //     if not product.id:
            //         product.mrp_product_qty = 0.0
            //         continue
            //     product.mrp_product_qty = float_round(mapped_data.get(product.id, 0), precision_rounding=product.uom_id.rounding)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeNbrMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_moves(self):
            // incoming_moves = self.env['stock.move.line']._read_group([
            //         ('product_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'incoming'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // outgoing_moves = self.env['stock.move.line']._read_group([
            //         ('product_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'outgoing'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // res_incoming = {product.id: count for product, count in incoming_moves}
            // res_outgoing = {product.id: count for product, count in outgoing_moves}
            // for product in self:
            //     product.nbr_moves_in = res_incoming.get(product.id, 0)
            //     product.nbr_moves_out = res_outgoing.get(product.id, 0)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeNbrReorderingRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_reordering_rules(self):
            // read_group_res = self.env['stock.warehouse.orderpoint']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_id'],
            //     ['__count', 'product_min_qty:sum', 'product_max_qty:sum'])
            // mapped_res = {product: aggregates for product, *aggregates in read_group_res}
            // for product in self:
            //     count, product_min_qty_sum, product_max_qty_sum = mapped_res.get(product._origin, (0, 0, 0))
            //     product.nbr_reordering_rules = count
            //     product.reordering_min_qty = product_min_qty_sum
            //     product.reordering_max_qty = product_max_qty_sum
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePartnerRefInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_partner_ref(self):
            // for product in self:
            //     for supplier_info in product.seller_ids:
            //         if supplier_info.partner_id.id == product._context.get('partner_id'):
            //             product_name = supplier_info.product_name or product.default_code or product.name
            //             product.partner_ref = '%s%s' % (product.code and '[%s] ' % product.code or '', product_name)
            //             break
            //     else:
            //         product.partner_ref = product.display_name
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_product_code(self):
            // read_access = self.env['ir.model.access'].check('product.supplierinfo', 'read', False)
            // for product in self:
            //     product.code = product.default_code
            //     if read_access:
            //         for supplier_info in product.seller_ids:
            //             if supplier_info.partner_id.id == product._context.get('partner_id'):
            //                 if supplier_info.product_id and supplier_info.product_id != product:
            //                     # Supplier info specific for another variant.
            //                     continue
            //                 product.code = supplier_info.product_code or product.default_code
            //                 if product == supplier_info.product_id:
            //                     # Supplier info specific for this variant.
            //                     break
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductDocumentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_product_document_count(self):
            // for product in self:
            //     product.product_document_count = product.env['product.document'].search_count([
            //         ('res_model', '=', 'product.product'),
            //         ('res_id', '=', product.id),
            //     ])
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInBomAndMoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_product_is_in_bom_and_mo(self):
            // # Just to enable the _search method
            // self.product_catalog_product_is_in_bom = False
            // self.product_catalog_product_is_in_mo = False
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInRepairInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _compute_product_is_in_repair(self):
            // # Just to enable the _search method
            // self.product_catalog_product_is_in_repair = False
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInSaleOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _compute_product_is_in_sale_order(self):
            // order_id = self.env.context.get('order_id')
            // if not order_id:
            //     self.product_catalog_product_is_in_sale_order = False
            //     return
            // 
            // read_group_data = self.env['sale.order.line']._read_group(
            //     domain=[('order_id', '=', order_id)],
            //     groupby=['product_id'],
            //     aggregates=['__count'],
            // )
            // data = {product.id: count for product, count in read_group_data}
            // for product in self:
            //     product.product_catalog_product_is_in_sale_order = bool(data.get(product.id, 0))
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductLstPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_product_lst_price(self):
            // to_uom = None
            // if 'uom' in self._context:
            //     to_uom = self.env['uom.uom'].browse(self._context['uom'])
            // 
            // for product in self:
            //     if to_uom:
            //         list_price = product.uom_id._compute_price(product.list_price, to_uom)
            //     else:
            //         list_price = product.list_price
            //     product.lst_price = list_price + product.price_extra
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductMarginFieldsValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_margin, FILE: product_product.py) ---
            // def _compute_product_margin_fields_values(self):
            // date_from = self.env.context.get('date_from', time.strftime('%Y-01-01'))
            // date_to = self.env.context.get('date_to', time.strftime('%Y-12-31'))
            // invoice_state = self.env.context.get('invoice_state', 'open_paid')
            // res = {
            //     product_id: {'date_from': date_from, 'date_to': date_to, 'invoice_state': invoice_state, 'turnover': 0.0,
            //         'sale_avg_price': 0.0, 'purchase_avg_price': 0.0, 'sale_num_invoiced': 0.0, 'purchase_num_invoiced': 0.0,
            //         'sales_gap': 0.0, 'purchase_gap': 0.0, 'total_cost': 0.0, 'sale_expected': 0.0, 'normal_cost': 0.0, 'total_margin': 0.0,
            //         'expected_margin': 0.0, 'total_margin_rate': 0.0, 'expected_margin_rate': 0.0}
            //     for product_id in self.ids
            // }
            // states = ()
            // payment_states = ()
            // if invoice_state == 'paid':
            //     states = ('posted',)
            //     payment_states = ('in_payment', 'paid', 'reversed')
            // elif invoice_state == 'open_paid':
            //     states = ('posted',)
            //     payment_states = ('not_paid', 'in_payment', 'paid', 'reversed', 'partial')
            // elif invoice_state == 'draft_open_paid':
            //     states = ('posted', 'draft')
            //     payment_states = ('not_paid', 'in_payment', 'paid', 'reversed', 'partial')
            // if "force_company" in self.env.context:
            //     company_id = self.env.context['force_company']
            // else:
            //     company_id = self.env.company.id
            // self.env['account.move.line'].flush_model(['price_unit', 'quantity', 'balance', 'product_id', 'display_type'])
            // self.env['account.move'].flush_model(['state', 'payment_state', 'move_type', 'invoice_date', 'company_id'])
            // self.env['product.template'].flush_model(['list_price'])
            // sqlstr = """
            //         WITH currency_rate AS MATERIALIZED ({})
            //         SELECT
            //             l.product_id as product_id,
            //             SUM(
            //                 l.price_unit / (CASE COALESCE(cr.rate, 0) WHEN 0 THEN 1.0 ELSE cr.rate END) *
            //                 l.quantity * (CASE WHEN i.move_type IN ('out_invoice', 'in_invoice') THEN 1 ELSE -1 END) * ((100 - l.discount) * 0.01)
            //             ) / NULLIF(SUM(l.quantity * (CASE WHEN i.move_type IN ('out_invoice', 'in_invoice') THEN 1 ELSE -1 END)), 0) AS avg_unit_price,
            //             SUM(l.quantity * (CASE WHEN i.move_type IN ('out_invoice', 'in_invoice') THEN 1 ELSE -1 END)) AS num_qty,
            //             SUM(CASE WHEN i.move_type = 'out_invoice' THEN -l.balance WHEN i.move_type = 'in_invoice' THEN l.balance ELSE -ABS(l.balance) END) AS total,
            //             SUM(l.quantity * pt.list_price * (CASE WHEN i.move_type IN ('out_invoice', 'in_invoice') THEN 1 ELSE -1 END)) AS sale_expected
            //         FROM account_move_line l
            //         LEFT JOIN account_move i ON (l.move_id = i.id)
            //         LEFT JOIN product_product product ON (product.id=l.product_id)
            //         LEFT JOIN product_template pt ON (pt.id = product.product_tmpl_id)
            //         left join currency_rate cr on
            //         (cr.currency_id = i.currency_id and
            //          cr.company_id = i.company_id and
            //          cr.date_start <= COALESCE(i.invoice_date, NOW()) and
            //          (cr.date_end IS NULL OR cr.date_end > COALESCE(i.invoice_date, NOW())))
            //         WHERE l.product_id IN %s
            //         AND i.state IN %s
            //         AND i.payment_state IN %s
            //         AND i.move_type IN %s
            //         AND i.invoice_date BETWEEN %s AND  %s
            //         AND i.company_id = %s
            //         AND l.display_type = 'product'
            //         GROUP BY l.product_id
            //         """.format(self.env['res.currency']._select_companies_rates())
            // invoice_types = ('out_invoice', 'out_refund')
            // self.env.cr.execute(sqlstr, (tuple(self.ids), states, payment_states, invoice_types, date_from, date_to, company_id))
            // for product_id, avg, qty, total, sale in self.env.cr.fetchall():
            //     res[product_id]['sale_avg_price'] = avg and avg or 0.0
            //     res[product_id]['sale_num_invoiced'] = qty and qty or 0.0
            //     res[product_id]['turnover'] = total and total or 0.0
            //     res[product_id]['sale_expected'] = sale and sale or 0.0
            //     res[product_id]['sales_gap'] = res[product_id]['sale_expected'] - res[product_id]['turnover']
            //     res[product_id]['total_margin'] = res[product_id]['turnover']
            //     res[product_id]['expected_margin'] = res[product_id]['sale_expected']
            //     res[product_id]['total_margin_rate'] = res[product_id]['turnover'] and res[product_id]['total_margin'] * 100 / res[product_id]['turnover'] or 0.0
            //     res[product_id]['expected_margin_rate'] = res[product_id]['sale_expected'] and res[product_id]['expected_margin'] * 100 / res[product_id]['sale_expected'] or 0.0
            // 
            // ctx = self.env.context.copy()
            // ctx['force_company'] = company_id
            // invoice_types = ('in_invoice', 'in_refund')
            // self.env.cr.execute(sqlstr, (tuple(self.ids), states, payment_states, invoice_types, date_from, date_to, company_id))
            // for product_id, avg, qty, total, dummy in self.env.cr.fetchall():
            //     res[product_id]['purchase_avg_price'] = avg and avg or 0.0
            //     res[product_id]['purchase_num_invoiced'] = qty and qty or 0.0
            //     res[product_id]['total_cost'] = total and total or 0.0
            //     res[product_id]['total_margin'] = res[product_id].get('turnover', 0.0) - res[product_id]['total_cost']
            //     res[product_id]['total_margin_rate'] = res[product_id].get('turnover', 0.0) and res[product_id]['total_margin'] * 100 / res[product_id].get('turnover', 0.0) or 0.0
            // for product in self:
            //     res[product.id]['normal_cost'] = product.standard_price * res[product.id]['purchase_num_invoiced']
            //     res[product.id]['purchase_gap'] = res[product.id]['normal_cost'] - res[product.id]['total_cost']
            //     res[product.id]['expected_margin'] = res[product.id].get('sale_expected', 0.0) - res[product.id]['normal_cost']
            //     res[product.id]['expected_margin_rate'] = res[product.id].get('sale_expected', 0.0) and res[product.id]['expected_margin'] * 100 / res[product.id].get('sale_expected', 0.0) or 0.0
            //     product.update(res[product.id])
            // return res
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductPriceExtraInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_product_price_extra(self):
            // for product in self:
            //     product.price_extra = sum(product.product_template_attribute_value_ids.mapped('price_extra'))
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductPriceWithPricelistInternalAsync(object products, Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _compute_product_price_with_pricelist(self, products, config_id):
            // config = self.env['pos.config'].browse(config_id)
            // pricelist = config.pricelist_id
            // 
            // product_ids = [product['id'] for product in products]
            // product_objs = self.env['product.product'].browse(product_ids)
            // 
            // product_map = {product.id: product for product in product_objs}
            // loaded_product_tmpl_ids = list({p['product_tmpl_id'] for p in products})
            // archived_combinations = self._get_archived_combinations_per_product_tmpl_id(loaded_product_tmpl_ids)
            // 
            // for product in products:
            //     product_obj = product_map.get(product['id'])
            //     if product_obj:
            //         product['lst_price'] = pricelist._get_product_price(
            //             product_obj, 1.0, currency=config.currency_id
            //         )
            //     if archived_combinations.get(product['product_tmpl_id']):
            //         product['_archived_combinations'] = archived_combinations[product['product_tmpl_id']]
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _compute_product_website_url(self):
            // for product in self:
            //     url = product.product_tmpl_id.website_url
            //     if pavs := product.product_template_attribute_value_ids.product_attribute_value_id:
            //         pav_ids = [str(pav.id) for pav in pavs]
            //         url = f'{url}#attribute_values={",".join(pav_ids)}'
            //     product.website_url = url
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePurchasedProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchased_product_qty(self):
            // date_from = fields.Datetime.to_string(fields.Date.context_today(self) - relativedelta(years=1))
            // domain = [
            //     ('order_id.state', 'in', ['purchase', 'done']),
            //     ('product_id', 'in', self.ids),
            //     ('order_id.date_approve', '>=', date_from)
            // ]
            // order_lines = self.env['purchase.order.line']._read_group(domain, ['product_id'], ['product_uom_qty:sum'])
            // purchased_data = {product.id: qty for product, qty in order_lines}
            // for product in self:
            //     if not product.id:
            //         product.purchased_product_qty = 0.0
            //         continue
            //     product.purchased_product_qty = float_round(purchased_data.get(product.id, 0), precision_rounding=product.uom_id.rounding)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeQuantitiesDictInternalAsync(Guid lot_id, Guid owner_id, Guid package_id, object from_date, object to_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_quantities_dict(self, lot_id, owner_id, package_id, from_date=False, to_date=False):
            // """ When the product is a kit, this override computes the fields :
            //  - 'virtual_available'
            //  - 'qty_available'
            //  - 'incoming_qty'
            //  - 'outgoing_qty'
            //  - 'free_qty'
            // 
            // This override is used to get the correct quantities of products
            // with 'phantom' as BoM type.
            // """
            // bom_kits = self.env['mrp.bom']._bom_find(self, bom_type='phantom')
            // kits = self.filtered(lambda p: bom_kits.get(p))
            // regular_products = self - kits
            // res = (
            //     super(ProductProduct, regular_products)._compute_quantities_dict(lot_id, owner_id, package_id, from_date=from_date, to_date=to_date)
            //     if regular_products
            //     else {}
            // )
            // qties = self.env.context.get("mrp_compute_quantities", {})
            // qties.update(res)
            // # pre-compute bom lines and identify missing kit components to prefetch
            // bom_sub_lines_per_kit = {}
            // prefetch_component_ids = set()
            // for product in bom_kits:
            //     __, bom_sub_lines = bom_kits[product].explode(product, 1)
            //     bom_sub_lines_per_kit[product] = bom_sub_lines
            //     for bom_line, __ in bom_sub_lines:
            //         if bom_line.product_id.id not in qties:
            //             prefetch_component_ids.add(bom_line.product_id.id)
            // # compute kit quantities
            // for product in bom_kits:
            //     bom_sub_lines = bom_sub_lines_per_kit[product]
            //     # group lines by component
            //     bom_sub_lines_grouped = collections.defaultdict(list)
            //     for info in bom_sub_lines:
            //         bom_sub_lines_grouped[info[0].product_id].append(info)
            //     ratios_virtual_available = []
            //     ratios_qty_available = []
            //     ratios_incoming_qty = []
            //     ratios_outgoing_qty = []
            //     ratios_free_qty = []
            // 
            //     for component, bom_sub_lines in bom_sub_lines_grouped.items():
            //         component = component.with_context(mrp_compute_quantities=qties).with_prefetch(prefetch_component_ids)
            //         qty_per_kit = 0
            //         for bom_line, bom_line_data in bom_sub_lines:
            //             if not component.is_storable or float_is_zero(bom_line_data['qty'], precision_rounding=bom_line.product_uom_id.rounding):
            //                 # As BoMs allow components with 0 qty, a.k.a. optionnal components, we simply skip those
            //                 # to avoid a division by zero. The same logic is applied to non-storable products as those
            //                 # products have 0 qty available.
            //                 continue
            //             uom_qty_per_kit = bom_line_data['qty'] / bom_line_data['original_qty']
            //             qty_per_kit += bom_line.product_uom_id._compute_quantity(uom_qty_per_kit, bom_line.product_id.uom_id, round=False, raise_if_failure=False)
            //         if not qty_per_kit:
            //             continue
            //         rounding = component.uom_id.rounding
            //         component_res = (
            //             qties.get(component.id)
            //             if component.id in qties
            //             else {
            //                 "virtual_available": float_round(component.virtual_available, precision_rounding=rounding),
            //                 "qty_available": float_round(component.qty_available, precision_rounding=rounding),
            //                 "incoming_qty": float_round(component.incoming_qty, precision_rounding=rounding),
            //                 "outgoing_qty": float_round(component.outgoing_qty, precision_rounding=rounding),
            //                 "free_qty": float_round(component.free_qty, precision_rounding=rounding),
            //             }
            //         )
            //         ratios_virtual_available.append(float_round(component_res["virtual_available"] / qty_per_kit, precision_rounding=rounding, rounding_method='DOWN'))
            //         ratios_qty_available.append(float_round(component_res["qty_available"] / qty_per_kit, precision_rounding=rounding, rounding_method='DOWN'))
            //         ratios_incoming_qty.append(float_round(component_res["incoming_qty"] / qty_per_kit, precision_rounding=rounding, rounding_method='DOWN'))
            //         ratios_outgoing_qty.append(float_round(component_res["outgoing_qty"] / qty_per_kit, precision_rounding=rounding, rounding_method='DOWN'))
            //         ratios_free_qty.append(float_round(component_res["free_qty"] / qty_per_kit, precision_rounding=rounding, rounding_method='DOWN'))
            //     if bom_sub_lines and ratios_virtual_available:  # Guard against all cnsumable bom: at least one ratio should be present.
            //         res[product.id] = {
            //             'virtual_available': float_round(min(ratios_virtual_available) * bom_kits[product].product_qty, precision_rounding=rounding) // 1,
            //             'qty_available': float_round(min(ratios_qty_available) * bom_kits[product].product_qty, precision_rounding=rounding) // 1,
            //             'incoming_qty': float_round(min(ratios_incoming_qty) * bom_kits[product].product_qty, precision_rounding=rounding) // 1,
            //             'outgoing_qty': float_round(min(ratios_outgoing_qty) * bom_kits[product].product_qty, precision_rounding=rounding) // 1,
            //             'free_qty': float_round(min(ratios_free_qty) * bom_kits[product].product_qty, precision_rounding=rounding) // 1,
            //         }
            //     else:
            //         res[product.id] = {
            //             'virtual_available': 0,
            //             'qty_available': 0,
            //             'incoming_qty': 0,
            //             'outgoing_qty': 0,
            //             'free_qty': 0,
            //         }
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities_dict(self, lot_id, owner_id, package_id, from_date=False, to_date=False):
            // domain_quant_loc, domain_move_in_loc, domain_move_out_loc = self._get_domain_locations()
            // domain_quant = [('product_id', 'in', self.ids)] + domain_quant_loc
            // dates_in_the_past = False
            // # only to_date as to_date will correspond to qty_available
            // to_date = fields.Datetime.to_datetime(to_date)
            // if to_date and to_date < fields.Datetime.now():
            //     dates_in_the_past = True
            // 
            // domain_move_in = [('product_id', 'in', self.ids)] + domain_move_in_loc
            // domain_move_out = [('product_id', 'in', self.ids)] + domain_move_out_loc
            // if lot_id is not None:
            //     domain_quant += [('lot_id', '=', lot_id)]
            // if owner_id is not None:
            //     domain_quant += [('owner_id', '=', owner_id)]
            //     domain_move_in += [('restrict_partner_id', '=', owner_id)]
            //     domain_move_out += [('restrict_partner_id', '=', owner_id)]
            // if package_id is not None:
            //     domain_quant += [('package_id', '=', package_id)]
            // if dates_in_the_past:
            //     domain_move_in_done = list(domain_move_in)
            //     domain_move_out_done = list(domain_move_out)
            // if from_date:
            //     date_date_expected_domain_from = [('date', '>=', from_date)]
            //     domain_move_in += date_date_expected_domain_from
            //     domain_move_out += date_date_expected_domain_from
            // if to_date:
            //     date_date_expected_domain_to = [('date', '<=', to_date)]
            //     domain_move_in += date_date_expected_domain_to
            //     domain_move_out += date_date_expected_domain_to
            // 
            // Move = self.env['stock.move'].with_context(active_test=False)
            // Quant = self.env['stock.quant'].with_context(active_test=False)
            // domain_move_in_todo = [('state', 'in', ('waiting', 'confirmed', 'assigned', 'partially_available'))] + domain_move_in
            // domain_move_out_todo = [('state', 'in', ('waiting', 'confirmed', 'assigned', 'partially_available'))] + domain_move_out
            // moves_in_res = {product.id: product_qty for product, product_qty in Move._read_group(domain_move_in_todo, ['product_id'], ['product_qty:sum'])}
            // moves_out_res = {product.id: product_qty for product, product_qty in Move._read_group(domain_move_out_todo, ['product_id'], ['product_qty:sum'])}
            // quants_res = {product.id: (quantity, reserved_quantity) for product, quantity, reserved_quantity in Quant._read_group(domain_quant, ['product_id'], ['quantity:sum', 'reserved_quantity:sum'])}
            // if dates_in_the_past:
            //     # Calculate the moves that were done before now to calculate back in time (as most questions will be recent ones)
            //     domain_move_in_done = [('state', '=', 'done'), ('date', '>', to_date)] + domain_move_in_done
            //     domain_move_out_done = [('state', '=', 'done'), ('date', '>', to_date)] + domain_move_out_done
            // 
            //     groupby = ['product_id', 'product_uom']
            //     moves_in_res_past = defaultdict(float)
            //     for product, uom, quantity in Move._read_group(domain_move_in_done, groupby, ['quantity:sum']):
            //         moves_in_res_past[product.id] += uom._compute_quantity(quantity, product.uom_id)
            // 
            //     moves_out_res_past = defaultdict(float)
            //     for product, uom, quantity in Move._read_group(domain_move_out_done, groupby, ['quantity:sum']):
            //         moves_out_res_past[product.id] += uom._compute_quantity(quantity, product.uom_id)
            // 
            // res = dict()
            // for product in self.with_context(prefetch_fields=False):
            //     origin_product_id = product._origin.id
            //     product_id = product.id
            //     if not origin_product_id:
            //         res[product_id] = dict.fromkeys(
            //             ['qty_available', 'free_qty', 'incoming_qty', 'outgoing_qty', 'virtual_available'],
            //             0.0,
            //         )
            //         continue
            //     rounding = product.uom_id.rounding
            //     res[product_id] = {}
            //     if dates_in_the_past:
            //         qty_available = quants_res.get(origin_product_id, [0.0])[0] - moves_in_res_past.get(origin_product_id, 0.0) + moves_out_res_past.get(origin_product_id, 0.0)
            //     else:
            //         qty_available = quants_res.get(origin_product_id, [0.0])[0]
            //     reserved_quantity = quants_res.get(origin_product_id, [False, 0.0])[1]
            //     res[product_id]['qty_available'] = float_round(qty_available, precision_rounding=rounding)
            //     res[product_id]['free_qty'] = float_round(qty_available - reserved_quantity, precision_rounding=rounding)
            //     res[product_id]['incoming_qty'] = float_round(moves_in_res.get(origin_product_id, 0.0), precision_rounding=rounding)
            //     res[product_id]['outgoing_qty'] = float_round(moves_out_res.get(origin_product_id, 0.0), precision_rounding=rounding)
            //     res[product_id]['virtual_available'] = float_round(
            //         qty_available + res[product_id]['incoming_qty'] - res[product_id]['outgoing_qty'],
            //         precision_rounding=rounding)
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeQuantitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // products = self.with_context(prefetch_fields=False).filtered(lambda p: p.type != 'service').with_context(prefetch_fields=True)
            // res = products._compute_quantities_dict(self._context.get('lot_id'), self._context.get('owner_id'), self._context.get('package_id'), self._context.get('from_date'), self._context.get('to_date'))
            // for product in products:
            //     product.update(res[product.id])
            // # Services need to be set with 0.0 for all quantities
            // services = self - products
            // services.qty_available = 0.0
            // services.incoming_qty = 0.0
            // services.outgoing_qty = 0.0
            // services.virtual_available = 0.0
            // services.free_qty = 0.0
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeSalesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _compute_sales_count(self):
            // r = {}
            // self.sales_count = 0
            // if not self.env.user.has_group('sales_team.group_sale_salesman'):
            //     return r
            // date_from = fields.Datetime.to_string(fields.datetime.combine(fields.datetime.now() - timedelta(days=365),
            //                                                               time.min))
            // 
            // done_states = self.env['sale.report']._get_done_states()
            // 
            // domain = [
            //     ('state', 'in', done_states),
            //     ('product_id', 'in', self.ids),
            //     ('date', '>=', date_from),
            // ]
            // for product, product_uom_qty in self.env['sale.report']._read_group(domain, ['product_id'], ['product_uom_qty:sum']):
            //     r[product.id] = product_uom_qty
            // for product in self:
            //     if not product.id:
            //         product.sales_count = 0.0
            //         continue
            //     product.sales_count = float_round(r.get(product.id, 0), precision_rounding=product.uom_id.rounding)
            // return r
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeShowQtyStatusButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // super()._compute_show_qty_status_button()
            // for product in self:
            //     if product.is_kits:
            //         product.show_on_hand_qty_status_button = True
            //         product.show_forecasted_qty_status_button = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // for product in self:
            //     product.show_on_hand_qty_status_button = product.product_tmpl_id.show_on_hand_qty_status_button
            //     product.show_forecasted_qty_status_button = product.product_tmpl_id.show_forecasted_qty_status_button
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeStandardPriceUpdateWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_product.py) ---
            // def _compute_standard_price_update_warning(self):
            // undone_expenses = self.env['hr.expense']._read_group(
            //     domain=[('state', 'in', ['draft', 'reported']), ('product_id', 'in', self.ids)],
            //     groupby=['price_unit'],
            //     )
            // # The following list is composed of all the unit_amounts of expenses that use this product and should NOT trigger a warning.
            // # Those are the amounts of any undone expense using this product and 0.0 which is the default unit_amount.
            // unit_amounts_no_warning = [self.env.company.currency_id.round(row[0]) for row in undone_expenses]
            // for product in self:
            //     product.standard_price_update_warning = False
            //     if undone_expenses:
            //         rounded_price = self.env.company.currency_id.round(product.standard_price)
            //         if rounded_price and (len(unit_amounts_no_warning) > 1 or (len(unit_amounts_no_warning) == 1 and rounded_price not in unit_amounts_no_warning)):
            //             product.standard_price_update_warning = _(
            //                     "There are unsubmitted expenses linked to this category. Updating the category cost will change expense amounts. "
            //                     "Make sure it is what you want to do."
            //                 )
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeTaxStringInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_tax_string(self):
            // for record in self:
            //     record.tax_string = record.product_tmpl_id._construct_tax_string(record.lst_price)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeUsedInBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_used_in_bom_count(self):
            // for product in self:
            //     product.used_in_bom_count = self.env['mrp.bom'].search_count([('bom_line_ids.product_id', '=', product.id)])
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeValidEanInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_valid_ean(self):
            // self.valid_ean = False
            // for product in self:
            //     if product.barcode:
            //         product.valid_ean = check_barcode_encoding(product.barcode.rjust(14, '0'), 'gtin14')
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeValueSvlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_value_svl(self):
            // """Compute totals of multiple svl related values"""
            // company_id = self.env.company
            // self.company_currency_id = company_id.currency_id
            // domain = [
            //     *self.env['stock.valuation.layer']._check_company_domain(company_id),
            //     ('product_id', 'in', self.ids),
            // ]
            // if self.env.context.get('to_date'):
            //     to_date = fields.Datetime.to_datetime(self.env.context['to_date'])
            //     domain.append(('create_date', '<=', to_date))
            // groups = self.env['stock.valuation.layer']._read_group(
            //     domain,
            //     groupby=['product_id'],
            //     aggregates=['value:sum', 'quantity:sum'],
            // )
            // # Browse all products and compute products' quantities_dict in batch.
            // group_mapping = {product: aggregates for product, *aggregates in groups}
            // for product in self:
            //     value_sum, quantity_sum = group_mapping.get(product._origin, (0, 0))
            //     value_svl = company_id.currency_id.round(value_sum)
            //     avg_cost = value_svl / quantity_sum if quantity_sum else 0
            //     product.value_svl = value_svl
            //     product.quantity_svl = quantity_sum
            //     product.avg_cost = avg_cost
            //     product.total_value = avg_cost * product.sudo(False).qty_available
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeVariantItemCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_variant_item_count(self):
            // for product in self:
            //     domain = [
            //         ('pricelist_id.active', '=', True),
            //         '|',
            //             '&', ('product_tmpl_id', '=', product.product_tmpl_id.id), ('applied_on', '=', '1_product'),
            //             '&', ('product_id', '=', product.id), ('applied_on', '=', '0_product_variant'),
            //         ('compute_price', '=', 'fixed'),
            //     ]
            //     product.pricelist_item_count = self.env['product.pricelist.item'].search_count(domain)
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeWriteDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_write_date(self):
            // """
            // First, the purpose of this computation is to update a product's
            // write_date whenever its template's write_date is updated.  Indeed,
            // when a template's image is modified, updating its products'
            // write_date will invalidate the browser's cache for the products'
            // image, which may be the same as the template's.  This guarantees UI
            // consistency.
            // 
            // Second, the field 'write_date' is automatically updated by the
            // framework when the product is modified.  The recomputation of the
            // field supplements that behavior to keep the product's write_date
            // up-to-date with its template's write_date.
            // 
            // Third, the framework normally prevents us from updating write_date
            // because it is a "magic" field.  However, the assignment inside the
            // compute method is not subject to this restriction.  It therefore
            // works as intended :-)
            // """
            // for record in self:
            //     record.write_date = max(record.write_date or self.env.cr.now(), record.product_tmpl_id.write_date)
            */
            return default;
        }

        protected async Task<ProductProduct> CountReturnedSnProductsDomainInternalAsync(object sn_lot, object or_domains)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _count_returned_sn_products_domain(self, sn_lot, or_domains):
            // or_domains.append([
            //     ('production_id', '=', False),
            //     ('location_id.usage', '=', 'production'),
            //     ('move_id.unbuild_id', '!=', False),
            // ])
            // return super()._count_returned_sn_products_domain(sn_lot, or_domains)
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _count_returned_sn_products_domain(self, sn_lot, or_domains):
            // or_domains.append([
            //         ('move_id.repair_line_type', 'in', ['remove', 'recycle']),
            //         ('location_dest_usage', '=', 'internal'),
            // ])
            // return super()._count_returned_sn_products_domain(sn_lot, or_domains)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _count_returned_sn_products_domain(self, sn_lot, or_domains):
            // if not or_domains:
            //     return None
            // base_domain = [
            //     ('lot_id', '=', sn_lot.id),
            //     ('quantity', '=', 1),
            //     ('state', '=', 'done'),
            // ]
            // or_domains = expression.OR(or_domains)
            // return expression.AND([base_domain, or_domains])
            */
            return default;
        }

        protected async Task<ProductProduct> CountReturnedSnProductsInternalAsync(object sn_lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _count_returned_sn_products(self, sn_lot):
            // domain = self._count_returned_sn_products_domain(sn_lot, or_domains=[])
            // if not domain:
            //     return 0
            // return self.env['stock.move.line'].search_count(domain)
            */
            return default;
        }

        protected async Task<ProductProduct> CreateFifoVacuumAngloSaxonExpenseEntriesInternalAsync(object vacuum_pairs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _create_fifo_vacuum_anglo_saxon_expense_entries(self, vacuum_pairs):
            // """ Batch version of _create_fifo_vacuum_anglo_saxon_expense_entry
            // """
            // AccountMove = self.env['account.move'].sudo()
            // account_move_vals = []
            // vacuum_pairs_to_reconcile = []
            // svls_accounts = {}
            // for vacuum_svl, svl_to_vacuum in vacuum_pairs:
            //     if not vacuum_svl.company_id.anglo_saxon_accounting or not svl_to_vacuum.stock_move_id._is_out():
            //         continue
            //     account_move_lines = svl_to_vacuum.account_move_id.line_ids
            //     # Find related customer invoice where product is delivered while you don't have units in stock anymore
            //     reconciled_line_ids = list(set(account_move_lines._reconciled_lines()) - set(account_move_lines.ids))
            //     account_move = AccountMove.search([('line_ids', 'in', reconciled_line_ids)], limit=1)
            //     # If delivered quantity is not invoiced then no need to create this entry
            //     if not account_move:
            //         continue
            //     accounts = svl_to_vacuum.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=account_move.fiscal_position_id)
            //     if not accounts.get('stock_output') or not accounts.get('expense'):
            //         continue
            //     svls_accounts[svl_to_vacuum.id] = accounts
            //     description = "Expenses %s" % (vacuum_svl.description)
            //     move_lines = vacuum_svl.stock_move_id._prepare_account_move_line(
            //     vacuum_svl.quantity, vacuum_svl.value * -1,
            //     accounts['stock_output'].id, accounts['expense'].id,
            //     vacuum_svl.id, description)
            //     account_move_vals.append({
            //         'journal_id': accounts['stock_journal'].id,
            //         'line_ids': move_lines,
            //         'date': self._context.get('force_period_date', fields.Date.context_today(self)),
            //         'ref': description,
            //         'stock_move_id': vacuum_svl.stock_move_id.id,
            //         'move_type': 'entry',
            //     })
            //     vacuum_pairs_to_reconcile.append((vacuum_svl, svl_to_vacuum))
            // new_account_moves = AccountMove.create(account_move_vals)
            // new_account_moves._post()
            // for new_account_move, (vacuum_svl, svl_to_vacuum) in zip(new_account_moves, vacuum_pairs_to_reconcile):
            //     account = svls_accounts[svl_to_vacuum.id]['stock_output']
            //     to_reconcile_account_move_lines = vacuum_svl.account_move_id.line_ids.filtered(lambda l: not l.reconciled and l.account_id == account and l.account_id.reconcile)
            //     to_reconcile_account_move_lines += new_account_move.line_ids.filtered(lambda l: not l.reconciled and l.account_id == account and l.account_id.reconcile)
            //     to_reconcile_account_move_lines.reconcile()
            */
            return default;
        }

        protected async Task<ProductProduct> CreateFifoVacuumAngloSaxonExpenseEntryInternalAsync(object vacuum_svl, object svl_to_vacuum)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _create_fifo_vacuum_anglo_saxon_expense_entry(self, vacuum_svl, svl_to_vacuum):
            // """ When product is delivered and invoiced while you don't have units in stock anymore, there are chances of that
            //     product getting undervalued/overvalued. So, we should nevertheless take into account the fact that the product has
            //     already been delivered and invoiced to the customer by posting the value difference in the expense account also.
            //     Consider the below case where product is getting undervalued:
            // 
            //     You bought 8 units @ 10$ -> You have a stock valuation of 8 units, unit cost 10.
            //     Then you deliver 10 units of the product.
            //     You assumed the missing 2 should go out at a value of 10$ but you are not sure yet as it hasn't been bought in Odoo yet.
            //     Afterwards, you buy missing 2 units of the same product at 12$ instead of expected 10$.
            //     In case the product has been undervalued when delivered without stock, the vacuum entry is the following one (this entry already takes place):
            // 
            //     Account                         | Debit   | Credit
            //     ===================================================
            //     Stock Valuation                 | 0.00     | 4.00
            //     Stock Interim (Delivered)       | 4.00     | 0.00
            // 
            //     So, on delivering product with different price, We should create additional journal items like:
            //     Account                         | Debit    | Credit
            //     ===================================================
            //     Stock Interim (Delivered)       | 0.00     | 4.00
            //     Expenses Revaluation            | 4.00     | 0.00
            // """
            // if not vacuum_svl.company_id.anglo_saxon_accounting or not svl_to_vacuum.stock_move_id._is_out():
            //     return False
            // AccountMove = self.env['account.move'].sudo()
            // account_move_lines = svl_to_vacuum.account_move_id.line_ids
            // # Find related customer invoice where product is delivered while you don't have units in stock anymore
            // reconciled_line_ids = list(set(account_move_lines._reconciled_lines()) - set(account_move_lines.ids))
            // account_move = AccountMove.search([('line_ids','in', reconciled_line_ids)], limit=1)
            // # If delivered quantity is not invoiced then no need to create this entry
            // if not account_move:
            //     return False
            // accounts = svl_to_vacuum.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=account_move.fiscal_position_id)
            // if not accounts.get('stock_output') or not accounts.get('expense'):
            //     return False
            // description = "Expenses %s" % (vacuum_svl.description)
            // move_lines = vacuum_svl.stock_move_id._prepare_account_move_line(
            //     vacuum_svl.quantity, vacuum_svl.value * -1,
            //     accounts['stock_output'].id, accounts['expense'].id,
            //     vacuum_svl.id, description)
            // new_account_move = AccountMove.sudo().create({
            //     'journal_id': accounts['stock_journal'].id,
            //     'line_ids': move_lines,
            //     'date': self._context.get('force_period_date', fields.Date.context_today(self)),
            //     'ref': description,
            //     'stock_move_id': vacuum_svl.stock_move_id.id,
            //     'move_type': 'entry',
            // })
            // new_account_move._post()
            // to_reconcile_account_move_lines = vacuum_svl.account_move_id.line_ids.filtered(lambda l: not l.reconciled and l.account_id == accounts['stock_output'] and l.account_id.reconcile)
            // to_reconcile_account_move_lines += new_account_move.line_ids.filtered(lambda l: not l.reconciled and l.account_id == accounts['stock_output'] and l.account_id.reconcile)
            // return to_reconcile_account_move_lines.reconcile()
            */
            return default;
        }

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // res = super().fields_get(allfields, attributes)
            // if self._context.get('location') and isinstance(self._context['location'], int):
            //     location = self.env['stock.location'].browse(self._context['location'])
            //     if location.usage == 'supplier':
            //         if res.get('virtual_available'):
            //             res['virtual_available']['string'] = _('Future Receipts')
            //         if res.get('qty_available'):
            //             res['qty_available']['string'] = _('Received Qty')
            //     elif location.usage == 'internal':
            //         if res.get('virtual_available'):
            //             res['virtual_available']['string'] = _('Forecasted Quantity')
            //     elif location.usage == 'customer':
            //         if res.get('virtual_available'):
            //             res['virtual_available']['string'] = _('Future Deliveries')
            //         if res.get('qty_available'):
            //             res['qty_available']['string'] = _('Delivered Qty')
            //     elif location.usage == 'inventory':
            //         if res.get('virtual_available'):
            //             res['virtual_available']['string'] = _('Future P&L')
            //         if res.get('qty_available'):
            //             res['qty_available']['string'] = _('P&L Qty')
            //     elif location.usage == 'production':
            //         if res.get('virtual_available'):
            //             res['virtual_available']['string'] = _('Future Productions')
            //         if res.get('qty_available'):
            //             res['qty_available']['string'] = _('Produced Qty')
            // return res
            */
            return await base.FieldsGetAsync(fields, attributes);
        }

        protected async Task<List<Dictionary<string, object>>> FilterApplicableAttributesInternalAsync(Guid attributes_by_ptal_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _filter_applicable_attributes(self, attributes_by_ptal_id: Dict) -> List[Dict]:
            // """
            // The attributes_by_ptal_id is a dictionary that contains all the attributes that have
            // [('create_variant', '=', 'no_variant')]
            // This method filters out the attributes that are not applicable to the product in self
            // """
            // self.ensure_one()
            // return [
            //     attributes_by_ptal_id[id]
            //     for id in self.attribute_line_ids.ids
            //     if attributes_by_ptal_id.get(id) is not None
            // ]
            */
            return default;
        }

        public async Task<ProductProduct> FilterHasRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def filter_has_routes(self):
            // """ Return products with route_ids
            //     or whose categ_id has total_route_ids.
            // """
            // products_with_routes = self.env['product.product']
            // # retrieve products with route_ids
            // products_with_routes += self.search([('id', 'in', self.ids), ('route_ids', '!=', False)])
            // # retrive products with categ_ids having routes
            // products_with_routes += self.search([('id', 'in', (self - products_with_routes).ids), ('categ_id.total_route_ids', '!=', False)])
            // return products_with_routes
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> FilterToUnlinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _filter_to_unlink(self, check_access=True):
            // return self
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _filter_to_unlink(self):
            // domain = [('product_id', 'in', self.ids)]
            // lines = self.env['sale.order.line']._read_group(domain, ['product_id'])
            // linked_product_ids = [product.id for [product] in lines]
            // return super(ProductProduct, self - self.browse(linked_product_ids))._filter_to_unlink()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _filter_to_unlink(self):
            // domain = [('product_id', 'in', self.ids)]
            // lines = self.env['stock.lot']._read_group(domain, ['product_id'])
            // linked_product_ids = [product.id for [product] in lines]
            // return super(Product, self - self.browse(linked_product_ids))._filter_to_unlink()
            */
            return default;
        }

        protected async Task<ProductProduct> GetArchivedCombinationsPerProductTmplIdInternalAsync(List<Guid> product_tmpl_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _get_archived_combinations_per_product_tmpl_id(self, product_tmpl_ids):
            // archived_combinations = {}
            // for product_tmpl in self.env['product.template'].browse(product_tmpl_ids):
            //     attribute_exclusions = product_tmpl._get_attribute_exclusions()
            //     archived_combinations[product_tmpl.id] = attribute_exclusions['archived_combinations']
            //     excluded = {}
            //     for ptav_id, ptav_ids in attribute_exclusions['exclusions'].items():
            //         for ptav_id2 in set(ptav_ids) - excluded.keys():
            //             excluded[ptav_id] = ptav_id2
            //     archived_combinations[product_tmpl.id].extend(excluded.items())
            // return archived_combinations
            */
            return default;
        }

        protected async Task<ProductProduct> GetAttributesExtraPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_attributes_extra_price(self):
            // self.ensure_one()
            // 
            // return self.price_extra + self.env.context.get('no_variant_attributes_price_extra', 0)
            */
            return default;
        }

        protected async Task<ProductProduct> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('mrp.menu_mrp_root').id]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('purchase.menu_purchase_root').id]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('sale.sale_menu_root').id]
            */
            return default;
        }

        protected async Task<ProductProduct> GetBarcodeSearchDomainInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_barcode_search_domain(self, barcodes_within_company, company_id):
            // domain = [('barcode', 'in', barcodes_within_company)]
            // if company_id:
            //     domain.append(('company_id', 'in', (False, company_id)))
            // return domain
            */
            return default;
        }

        protected async Task<ProductProduct> GetBarcodesByCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_barcodes_by_company(self):
            // return [
            //     (company_id, [p.barcode for p in products if p.barcode])
            //     for company_id, products in groupby(self, lambda p: p.company_id.id)
            // ]
            */
            return default;
        }

        protected async Task<ProductProduct> GetBaseUnitPriceInternalAsync(object price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _get_base_unit_price(self, price):
            // self.ensure_one()
            // return self.base_unit_count and price / self.base_unit_count
            */
            return default;
        }

        protected async Task<ProductProduct> GetCartQtyInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _get_cart_qty(self, website=None):
            // if not self.allow_out_of_stock_order:
            //     website = website or self.env['website'].get_current_website()
            //     # When the cron is run manually, request has no attribute website, and that would cause a crash
            //     # so we check for it
            //     cart = website and request and hasattr(request, 'website') and website.sale_get_order() or None
            //     if cart:
            //         return sum(cart._get_common_product_lines(product=self).mapped('product_uom_qty'))
            // return 0
            */
            return default;
        }

        protected async Task<ProductProduct> GetCombinationInfoVariantInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _get_combination_info_variant(self, **kwargs):
            // """Return the variant info based on its combination.
            // See `_get_combination_info` for more information.
            // """
            // self.ensure_one()
            // return self.product_tmpl_id._get_combination_info(
            //     combination=self.product_template_attribute_value_ids,
            //     product_id=self.id,
            //     **kwargs)
            */
            return default;
        }

        public async Task<ProductProduct> GetComponentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def get_components(self):
            // """ Return the components list ids in case of kit product.
            // Return the product itself otherwise"""
            // self.ensure_one()
            // bom_kit = self.env['mrp.bom']._bom_find(self, bom_type='phantom')[self]
            // if bom_kit:
            //     boms, bom_sub_lines = bom_kit.explode(self, 1)
            //     return [bom_line.product_id.id for bom_line, data in bom_sub_lines if bom_line.product_id.is_storable]
            // else:
            //     return super(ProductProduct, self).get_components()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def get_components(self):
            // self.ensure_one()
            // return self.ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetContextualDiscountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_contextual_discount(self):
            // self.ensure_one()
            // 
            // pricelist = self.product_tmpl_id._get_contextual_pricelist()
            // if not pricelist:
            //     # No pricelist = no discount
            //     return 0.0
            // 
            // lst_price = self.currency_id._convert(
            //     self.lst_price,
            //     pricelist.currency_id,
            //     self.env.company,
            //     fields.Datetime.now(),
            //     round=False
            // )
            // if lst_price:
            //     return (lst_price - self._get_contextual_price()) / lst_price
            // return 0.0
            */
            return default;
        }

        public async Task<ProductProduct> GetContextualPriceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def get_contextual_price(self):
            // return self._get_contextual_price()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetContextualPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_contextual_price(self):
            // # FIXME VFE this won't consider ptavs extra prices, since we rely on the template price
            // self.ensure_one()
            // return self.product_tmpl_id._get_contextual_price(self)
            */
            return default;
        }

        protected async Task<ProductProduct> GetDatesInfoInternalAsync(object date, object location, List<Guid> route_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_dates_info(self, date, location, route_ids=False):
            // rules = self._get_rules_from_location(location, route_ids=route_ids)
            // delays, _ = rules.with_context(bypass_delay_description=True)._get_lead_days(self)
            // return {
            //     'date_planned': date - relativedelta(days=delays['security_lead_days']),
            //     'date_order': date - relativedelta(days=delays['security_lead_days'] + delays['purchase_delay']),
            // }
            */
            return default;
        }

        protected async Task<ProductProduct> GetDefaultUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def _get_default_uom_id(self):
            // # TODO remove me in master
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        protected async Task<ProductProduct> GetDescriptionInternalAsync(Guid picking_type_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_description(self, picking_type_id):
            // """ return product receipt/delivery/picking description depending on
            // picking type passed as argument.
            // """
            // self.ensure_one()
            // picking_code = picking_type_id.code
            // description = html2plaintext(self.description) if not is_html_empty(self.description) else self.name
            // if picking_code == 'incoming':
            //     return self.description_pickingin or description
            // if picking_code == 'outgoing':
            //     return self.description_pickingout or self.name
            // if picking_code == 'internal':
            //     return self.description_picking or description
            // return description
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: product.py) ---
            // def _get_description(self, picking_type_id):
            // if picking_type_id.code == 'dropship':
            //     return self.description_pickingout or self.name
            // else:
            //     return super()._get_description(picking_type_id)
            */
            return default;
        }

        protected async Task<ProductProduct> GetDomainLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_domain_locations(self):
            // '''
            // Parses the context and returns a list of location_ids based on it.
            // It will return all stock locations when no parameters are given
            // Possible parameters are shop, warehouse, location, compute_child
            // '''
            // Location = self.env['stock.location']
            // Warehouse = self.env['stock.warehouse']
            // 
            // def _search_ids(model, values):
            //     ids = set()
            //     domains = []
            //     for item in values:
            //         if isinstance(item, int):
            //             ids.add(item)
            //         else:
            //             domains.append([(self.env[model]._rec_name, 'ilike', item)])
            //     if domains:
            //         ids |= set(self.env[model].search(expression.OR(domains)).ids)
            //     return ids
            // 
            // # We may receive a location or warehouse from the context, either by explicit
            // # python code or by the use of dummy fields in the search view.
            // # Normalize them into a list.
            // location = self.env.context.get('location')
            // if location and not isinstance(location, list):
            //     location = [location]
            // warehouse = self.env.context.get('warehouse_id')
            // if warehouse and not isinstance(warehouse, list):
            //     warehouse = [warehouse]
            // # filter by location and/or warehouse
            // if warehouse:
            //     w_ids = set(Warehouse.browse(_search_ids('stock.warehouse', warehouse)).mapped('view_location_id').ids)
            //     if location:
            //         l_ids = _search_ids('stock.location', location)
            //         parents = Location.browse(w_ids).mapped("parent_path")
            //         location_ids = {
            //             loc.id
            //             for loc in Location.browse(l_ids)
            //             if any(loc.parent_path.startswith(parent) for parent in parents)
            //         }
            //     else:
            //         location_ids = w_ids
            // else:
            //     if location:
            //         location_ids = _search_ids('stock.location', location)
            //     else:
            //         location_ids = set(Warehouse.search(
            //             [('company_id', 'in', self.env.companies.ids)]
            //         ).mapped('view_location_id').ids)
            // 
            // return self._get_domain_locations_new(location_ids)
            */
            return default;
        }

        protected async Task<ProductProduct> GetDomainLocationsNewInternalAsync(List<Guid> location_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_domain_locations_new(self, location_ids):
            // if not location_ids:
            //     return [[expression.FALSE_LEAF]] * 3
            // locations = self.env['stock.location'].browse(location_ids)
            // # TDE FIXME: should move the support of child_of + auto_join directly in expression
            // # this optimizes [('location_id', 'child_of', locations.ids)]
            // # by avoiding the ORM to search for children locations and injecting a
            // # lot of location ids into the main query
            // if self.env.context.get('strict'):
            //     loc_domain = [('location_id', 'in', locations.ids)]
            //     dest_loc_domain = [('location_dest_id', 'in', locations.ids)]
            // elif locations:
            //     paths_domain = expression.OR([[('parent_path', '=like', loc.parent_path + '%')] for loc in locations])
            //     loc_domain = [('location_id', 'any', paths_domain)]
            //     dest_loc_domain = [
            //         '|',
            //         '&', ('location_final_id', '!=', False), ('location_final_id', 'any', paths_domain),
            //         '&', ('location_final_id', '=', False), ('location_dest_id', 'any', paths_domain),
            //     ]
            // 
            // # returns: (domain_quant_loc, domain_move_in_loc, domain_move_out_loc)
            // return (
            //     loc_domain,
            //     dest_loc_domain + ['!'] + loc_domain,
            //     loc_domain + ['!'] + dest_loc_domain,
            // )
            */
            return default;
        }

        public async Task<ProductProduct> GetEmptyListHelpAsync(Guid id, ProductProductGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("product"),
            // )
            // return super(ProductProduct, self).get_empty_list_help(help_message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetFifoCandidatesDomainInternalAsync(object company, object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_fifo_candidates_domain(self, company, lot=False):
            // return [
            //     ("product_id", "=", self.id),
            //     ("remaining_qty", ">", 0),
            //     ("company_id", "=", company.id),
            //     ("lot_id", "=", lot.id if lot else False),
            // ]
            */
            return default;
        }

        protected async Task<ProductProduct> GetFifoCandidatesInternalAsync(object company, object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_fifo_candidates(self, company, lot=False):
            // candidates_domain = self._get_fifo_candidates_domain(company, lot=lot)
            // return self.env["stock.valuation.layer"].sudo().search(candidates_domain).sorted(lambda svl: svl._candidate_sort_key())
            */
            return default;
        }

        protected async Task<ProductProduct> GetFilteredSellersInternalAsync(Guid partner_id, object quantity, object date, Guid uom_id, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_filtered_sellers(self, partner_id=False, quantity=0.0, date=None, uom_id=False, params=False):
            // self.ensure_one()
            // if not date:
            //     date = fields.Date.context_today(self)
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // 
            // sellers_filtered = self._prepare_sellers(params)
            // sellers = self.env['product.supplierinfo']
            // for seller in sellers_filtered:
            //     # Set quantity in UoM of seller
            //     quantity_uom_seller = quantity
            //     if quantity_uom_seller and uom_id and uom_id != seller.product_uom:
            //         quantity_uom_seller = uom_id._compute_quantity(quantity_uom_seller, seller.product_uom)
            // 
            //     if seller.date_start and seller.date_start > date:
            //         continue
            //     if seller.date_end and seller.date_end < date:
            //         continue
            //     if partner_id and seller.partner_id not in [partner_id, partner_id.parent_id]:
            //         continue
            //     if quantity is not None and float_compare(quantity_uom_seller, seller.min_qty, precision_digits=precision) == -1:
            //         continue
            //     if seller.product_id and seller.product_id != self:
            //         continue
            //     sellers |= seller
            // return sellers
            */
            return default;
        }

        protected async Task<ProductProduct> GetImagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _get_images(self):
            // """Return a list of records implementing `image.mixin` to
            // display on the carousel on the website for this variant.
            // 
            // This returns a list and not a recordset because the records might be
            // from different models (template, variant and image).
            // 
            // It contains in this order: the main image of the variant (which will fall back on the main
            // image of the template, if unset), the Variant Extra Images, and the Template Extra Images.
            // """
            // self.ensure_one()
            // variant_images = list(self.product_variant_image_ids)
            // template_images = list(self.product_tmpl_id.product_template_image_ids)
            // return [self] + variant_images + template_images
            */
            return default;
        }

        protected async Task<ProductProduct> GetInvoicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_invoice_policy(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _get_invoice_policy(self):
            // return self.invoice_policy
            */
            return default;
        }

        protected async Task<ProductProduct> GetLinesDomainInternalAsync(List<Guid> location_ids, List<Guid> warehouse_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_lines_domain(self, location_ids=False, warehouse_ids=False):
            // domains = []
            // rfq_domain = [
            //     ('state', 'in', ('draft', 'sent', 'to approve')),
            //     ('product_id', 'in', self.ids)
            // ]
            // if location_ids:
            //     domains.append([
            //         '|',
            //             '&',
            //             ('orderpoint_id', '=', False),
            //             '|',
            //                 '&',
            //                     ('location_final_id', '=', False),
            //                     ('order_id.picking_type_id.default_location_dest_id', 'in', location_ids),
            //                 '&',
            //                     ('move_ids', '=', False),
            //                     ('location_final_id', 'child_of', location_ids),
            //             '&',
            //                 ('move_dest_ids', '=', False),
            //                 ('orderpoint_id.location_id', 'in', location_ids)
            //     ])
            // if warehouse_ids:
            //     domains.append([
            //         '|',
            //             '&',
            //                 ('orderpoint_id', '=', False),
            //                 ('order_id.picking_type_id.warehouse_id', 'in', warehouse_ids),
            //             '&',
            //                 ('move_dest_ids', '=', False),
            //                 ('orderpoint_id.warehouse_id', 'in', warehouse_ids)
            //     ])
            // domains = expression.OR(domains) if domains else []
            // return expression.AND([rfq_domain, domains])
            */
            return default;
        }

        protected async Task<ProductProduct> GetMaxQuantityInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _get_max_quantity(self, website, **kwargs):
            // """ The max quantity of a product is the difference between the quantity that's free to use
            // and the quantity that's already been added to the cart.
            // 
            // Note: self.ensure_one()
            // 
            // :param website website: The website for which to compute the max quantity.
            // :return: The max quantity of the product.
            // :rtype: float | None
            // """
            // self.ensure_one()
            // if self.is_storable and not self.allow_out_of_stock_order:
            //     free_qty = website._get_product_available_qty(self.sudo(), **kwargs)
            //     cart_qty = self._get_cart_qty(website)
            //     return free_qty - cart_qty
            // return None
            */
            return default;
        }

        protected async Task<ProductProduct> GetNoVariantAttributesPriceExtraInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_no_variant_attributes_price_extra(self, combination):
            // # It is possible that a no_variant attribute is still in a variant if
            // # the type of the attribute has been changed after creation.
            // return sum(
            //     ptav.price_extra for ptav in combination.filtered(
            //         lambda ptav:
            //             ptav.price_extra
            //             and ptav.product_tmpl_id == self.product_tmpl_id
            //             and ptav not in self.product_template_attribute_value_ids
            //     )
            // )
            */
            return default;
        }

        protected async Task<ProductProduct> GetOnlyQtyAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_only_qty_available(self):
            // """ Get only quantities available, it is equivalent to read qty_available
            // but avoid fetching other qty fields (avoid costly read group on moves)
            // 
            // :rtype: defaultdict(float)
            // """
            // domain_quant = expression.AND([self._get_domain_locations()[0], [('product_id', 'in', self.ids)]])
            // quants_groupby = self.env['stock.quant']._read_group(domain_quant, ['product_id'], ['quantity:sum'])
            // currents = defaultdict(float)
            // currents.update({product.id: quantity for product, quantity in quants_groupby})
            // return currents
            */
            return default;
        }

        protected async Task<ProductProduct> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return 'product/static/img/placeholder_thumbnail.png'
            // return super()._get_placeholder_filename(field)
            */
            return default;
        }

        protected async Task<ProductProduct> GetProductAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // return self.product_tmpl_id._get_product_accounts()
            */
            return default;
        }

        public async Task<ProductProduct> GetProductInfoPosAsync(Guid id, ProductProductGetProductInfoPosRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def get_product_info_pos(self, price, quantity, pos_config_id):
            // self.ensure_one()
            // config = self.env['pos.config'].browse(pos_config_id)
            // 
            // # Tax related
            // tax_to_use = None
            // company = config.company_id
            // while not tax_to_use and company:
            //     tax_to_use = self.taxes_id.filtered(lambda tax: tax.company_id.id == company.id)
            //     if not tax_to_use:
            //         company = company.parent_id
            // taxes = tax_to_use.compute_all(price, config.currency_id, quantity, self)
            // grouped_taxes = {}
            // for tax in taxes['taxes']:
            //     if tax['id'] in grouped_taxes:
            //         grouped_taxes[tax['id']]['amount'] += tax['amount']/quantity if quantity else 0
            //     else:
            //         grouped_taxes[tax['id']] = {
            //             'name': tax['name'],
            //             'amount': tax['amount']/quantity if quantity else 0
            //         }
            // 
            // all_prices = {
            //     'price_without_tax': taxes['total_excluded']/quantity if quantity else 0,
            //     'price_with_tax': taxes['total_included']/quantity if quantity else 0,
            //     'tax_details': list(grouped_taxes.values()),
            // }
            // 
            // # Pricelists
            // if config.use_pricelist:
            //     pricelists = config.available_pricelist_ids
            // else:
            //     pricelists = config.pricelist_id
            // price_per_pricelist_id = pricelists._price_get(self, quantity) if pricelists else False
            // pricelist_list = [{'id': pl.id, 'name': pl.name, 'price': price_per_pricelist_id[pl.id]} for pl in pricelists]
            // 
            // # Warehouses
            // warehouse_list = [
            //     {'id': w.id,
            //     'name': w.name,
            //     'available_quantity': self.with_context({'warehouse_id': w.id}).qty_available,
            //     'forecasted_quantity': self.with_context({'warehouse_id': w.id}).virtual_available,
            //     'uom': self.uom_name}
            //     for w in self.env['stock.warehouse'].search([('company_id', '=', config.company_id.id)])]
            // 
            // if config.picking_type_id.warehouse_id:
            //     # Sort the warehouse_list, prioritizing config.picking_type_id.warehouse_id
            //     warehouse_list = sorted(
            //         warehouse_list,
            //         key=lambda w: w['id'] != config.picking_type_id.warehouse_id.id
            //     )
            // 
            // # Suppliers
            // key = itemgetter('partner_id')
            // supplier_list = []
            // for key, group in groupby(sorted(self.seller_ids, key=key), key=key):
            //     for s in list(group):
            //         if not((s.date_start and s.date_start > date.today()) or (s.date_end and s.date_end < date.today()) or (s.min_qty > quantity)):
            //             supplier_list.append({
            //                 'id': s.id,
            //                 'name': s.partner_id.name,
            //                 'delay': s.delay,
            //                 'price': s.price
            //             })
            //             break
            // 
            // # Variants
            // variant_list = [{'name': attribute_line.attribute_id.name,
            //                  'values': list(map(lambda attr_name: {'name': attr_name, 'search': '%s %s' % (self.name, attr_name)}, attribute_line.value_ids.mapped('name')))}
            //                 for attribute_line in self.attribute_line_ids]
            // 
            // return {
            //     'all_prices': all_prices,
            //     'pricelists': pricelist_list,
            //     'warehouses': warehouse_list,
            //     'suppliers': supplier_list,
            //     'variants': variant_list
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: product_product.py) ---
            // def get_product_info_pos(self, price, quantity, pos_config_id):
            // res = super().get_product_info_pos(price, quantity, pos_config_id)
            // 
            // # Optional products
            // res['optional_products'] = [
            //     {'name': p.name, 'price': min(p.product_variant_ids.mapped('lst_price'))}
            //     for p in self.optional_product_ids.filtered_domain(self._optional_product_pos_domain())
            // ]
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> GetProductMultilineDescriptionSaleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def get_product_multiline_description_sale(self):
            // """ Compute a multiline description of this product, in the context of sales
            //         (do not use for purchases or other display reasons that don't intend to use "description_sale").
            //     It will often be used as the default description of a sale order line referencing this product.
            // """
            // name = self.display_name
            // if self.description_sale:
            //     name += '\n' + self.description_sale
            // 
            // return name
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_product.py) ---
            // def get_product_multiline_description_sale(self):
            // payment_channels = self.channel_ids.filtered(lambda course: course.enroll == 'payment')
            // 
            // if not payment_channels:
            //     return super(Product, self).get_product_multiline_description_sale()
            // 
            // new_line = '' if len(payment_channels) == 1 else '\n'
            // return _('Access to: %(new_line)s%(channel_list)s', new_line=new_line, channel_list='\n'.join(payment_channels.mapped('name')))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetProductPriceContextInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_product_price_context(self, combination):
            // self.ensure_one()
            // res = {}
            // 
            // no_variant_attributes_price_extra = self._get_no_variant_attributes_price_extra(combination)
            // 
            // if no_variant_attributes_price_extra:
            //     res['no_variant_attributes_price_extra'] = no_variant_attributes_price_extra
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductProduct> GetQtyTakenOnCandidateInternalAsync(object qty_to_take_on_candidates, object candidate)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_qty_taken_on_candidate(self, qty_to_take_on_candidates, candidate):
            // return min(qty_to_take_on_candidates, candidate.remaining_qty)
            */
            return default;
        }

        protected async Task<ProductProduct> GetQuantityInProgressInternalAsync(List<Guid> location_ids, List<Guid> warehouse_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_quantity_in_progress(self, location_ids=False, warehouse_ids=False):
            // if not location_ids:
            //     location_ids = []
            // if not warehouse_ids:
            //     warehouse_ids = []
            // 
            // qty_by_product_location, qty_by_product_wh = super()._get_quantity_in_progress(location_ids, warehouse_ids)
            // domain = self._get_lines_domain(location_ids, warehouse_ids)
            // groups = self.env['purchase.order.line'].sudo()._read_group(domain,
            //     ['order_id', 'product_id', 'product_uom', 'orderpoint_id', 'location_final_id'],
            //     ['product_qty:sum'])
            // for order, product, uom, orderpoint, location_final, product_qty_sum in groups:
            //     if orderpoint:
            //         location = orderpoint.location_id
            //     elif location_final:
            //         location = location_final
            //     else:
            //         location = order.picking_type_id.default_location_dest_id
            //     product_qty = uom._compute_quantity(product_qty_sum, product.uom_id, round=False)
            //     qty_by_product_location[(product.id, location.id)] += product_qty
            //     qty_by_product_wh[(product.id, location.warehouse_id.id)] += product_qty
            // return qty_by_product_location, qty_by_product_wh
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_quantity_in_progress(self, location_ids=False, warehouse_ids=False):
            // return defaultdict(float), defaultdict(float)
            */
            return default;
        }

        protected async Task<ProductProduct> GetRulesFromLocationInternalAsync(object location, List<Guid> route_ids, object seen_rules)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_rules_from_location(self, location, route_ids=False, seen_rules=False):
            // if not seen_rules:
            //     seen_rules = self.env['stock.rule']
            // warehouse = location.warehouse_id
            // if not warehouse and seen_rules:
            //     warehouse = seen_rules[-1].propagate_warehouse_id
            // rule = self.env['procurement.group'].with_context(active_test=True)._get_rule(self, location, {
            //     'route_ids': route_ids,
            //     'warehouse_id': warehouse,
            // })
            // if rule in seen_rules:
            //     raise UserError(_("Invalid rule's configuration, the following rule causes an endless loop: %s", rule.display_name))
            // if not rule:
            //     return seen_rules
            // if rule.procure_method == 'make_to_stock' or rule.action not in ('pull_push', 'pull'):
            //     return seen_rules | rule
            // else:
            //     return self._get_rules_from_location(rule.location_src_id, seen_rules=seen_rules | rule)
            */
            return default;
        }

        protected async Task<ProductProduct> GetTaxIncludedUnitPriceFromPriceInternalAsync(object product_price_unit, object product_taxes, object fiscal_position, object product_taxes_after_fp)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_tax_included_unit_price_from_price(
            //     self, product_price_unit, product_taxes,
            //     fiscal_position=None,
            //     product_taxes_after_fp=None,
            // ):
            //     if not product_taxes:
            //         return product_price_unit
            // 
            //     if product_taxes_after_fp is None:
            //         if not fiscal_position:
            //             return product_price_unit
            // 
            //         product_taxes_after_fp = fiscal_position.map_tax(product_taxes)
            // 
            //     return product_taxes._adapt_price_unit_to_another_taxes(
            //         price_unit=product_price_unit,
            //         product=self,
            //         original_taxes=product_taxes,
            //         new_taxes=product_taxes_after_fp,
            //     )
            */
            return default;
        }

        protected async Task<ProductProduct> GetTaxIncludedUnitPriceInternalAsync(object company, object currency, object document_date, object document_type, object is_refund_document, object product_uom, object product_currency, object product_price_unit, object product_taxes, object fiscal_position)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_tax_included_unit_price(self, company, currency, document_date, document_type,
            //     is_refund_document=False, product_uom=None, product_currency=None,
            //     product_price_unit=None, product_taxes=None, fiscal_position=None
            // ):
            //     """ Helper to get the price unit from different models.
            //         This is needed to compute the same unit price in different models (sale order, account move, etc.) with same parameters.
            //     """
            //     self.ensure_one()
            //     company.ensure_one()
            // 
            //     product = self
            // 
            //     assert document_type
            // 
            //     if product_uom is None:
            //         product_uom = product.uom_id
            //     if not product_currency:
            //         if document_type == 'sale':
            //             product_currency = product.currency_id
            //         elif document_type == 'purchase':
            //             product_currency = company.currency_id
            //     if product_price_unit is None:
            //         if document_type == 'sale':
            //             product_price_unit = product.with_company(company).lst_price
            //         elif document_type == 'purchase':
            //             product_price_unit = product.with_company(company).standard_price
            //         else:
            //             return 0.0
            //     if product_taxes is None:
            //         if document_type == 'sale':
            //             product_taxes = product.taxes_id.filtered(lambda x: x.company_id == company)
            //         elif document_type == 'purchase':
            //             product_taxes = product.supplier_taxes_id.filtered(lambda x: x.company_id == company)
            //     # Apply unit of measure.
            //     if product_uom and product.uom_id != product_uom:
            //         product_price_unit = product.uom_id._compute_price(product_price_unit, product_uom)
            // 
            //     # Apply fiscal position.
            //     if product_taxes and fiscal_position:
            //         product_price_unit = self._get_tax_included_unit_price_from_price(
            //             product_price_unit,
            //             product_taxes,
            //             fiscal_position=fiscal_position,
            //         )
            // 
            //     # Apply currency rate.
            //     if currency != product_currency:
            //         product_price_unit = product_currency._convert(product_price_unit, currency, company, document_date, round=False)
            // 
            //     return product_price_unit
            */
            return default;
        }

        public async Task<ProductProduct> HasOptionalProductInPosAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: product_product.py) ---
            // def has_optional_product_in_pos(self):
            // self.ensure_one()
            // return bool(self.optional_product_ids.filtered_domain(self._optional_product_pos_domain()))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> HasStockNotificationInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _has_stock_notification(self, partner):
            // self.ensure_one()
            // return partner in self.stock_notification_partner_ids
            */
            return default;
        }

        public async Task<ProductProduct> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def init(self):
            // """Ensure there is at most one active variant for each combination.
            // 
            // There could be no variant for a combination if using dynamic attributes.
            // """
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS product_product_combination_unique ON %s (product_tmpl_id, combination_indices) WHERE active is true"
            //     % self._table)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> InverseServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_product.py) ---
            // def _inverse_service_policy(self):
            // for product in self:
            //     if product.service_policy:
            // 
            //         product.invoice_policy, product.service_type = self.product_tmpl_id._get_service_to_general(product.service_policy)
            */
            return default;
        }

        protected async Task<ProductProduct> IsAddToCartAllowedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: product_product.py) ---
            // def _is_add_to_cart_allowed(self):
            // # `event_booth_registration_confirm` calls `_cart_update` with specific products, allow those aswell.
            // return super()._is_add_to_cart_allowed() or\
            //         self.env['event.booth.category'].sudo().search_count([('product_id', '=', self.id)])
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: product.py) ---
            // def _is_add_to_cart_allowed(self):
            // # Allow adding event tickets to the cart regardless of product's rules
            // self.ensure_one()
            // res = super()._is_add_to_cart_allowed()
            // return res or any(event.website_published for event in self.event_ticket_ids.event_id)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _is_add_to_cart_allowed(self):
            // self.ensure_one()
            // is_product_salable = self.active and self.sale_ok and self.website_published
            // website = self.env['website'].get_current_website()
            // return (is_product_salable and website.has_ecommerce_access()) \
            //        or self.env.user.has_group('base.group_system')
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_product.py) ---
            // def _is_add_to_cart_allowed(self):
            // """Override to allow published course related products to the cart regardless of product's rules."""
            // self.ensure_one()
            // res = super()._is_add_to_cart_allowed()
            // return res or bool(self.env['slide.channel'].sudo().search_count([
            //     ('product_id', '=', self.id),
            //     ('website_published', '=', True),
            // ], limit=1))
            */
            return default;
        }

        protected async Task<ProductProduct> IsDeliveredTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def _is_delivered_timesheet(self):
            // """ Check if the product is a delivered timesheet """
            // self.ensure_one()
            // return self.type == 'service' and self.service_policy == 'delivered_timesheet'
            */
            return default;
        }

        protected async Task<ProductProduct> IsInWishlistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _is_in_wishlist(self):
            // self.ensure_one()
            // return self in self.env['product.wishlist'].current().mapped('product_id')
            */
            return default;
        }

        protected async Task<ProductProduct> IsSoldOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _is_sold_out(self):
            // self.ensure_one()
            // if not self.is_storable:
            //     return False
            // free_qty = self.env['website'].get_current_website()._get_product_available_qty(self.sudo())
            // return free_qty <= 0
            */
            return default;
        }

        protected async Task<ProductProduct> IsVariantPossibleInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _is_variant_possible(self, parent_combination=None):
            // """Return whether the variant is possible based on its own combination,
            // and optionally a parent combination.
            // 
            // See `_is_combination_possible` for more information.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: ẁhether the variant is possible based on its own combination
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.product_tmpl_id._is_combination_possible(self.product_template_attribute_value_ids, parent_combination=parent_combination, ignore_no_variant=True)
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_domain(self, data):
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // return config_id._get_available_product_domain()
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'id', 'display_name', 'lst_price', 'standard_price', 'categ_id', 'pos_categ_ids', 'taxes_id', 'barcode', 'name',
            //     'default_code', 'to_weight', 'uom_id', 'description_sale', 'description', 'product_tmpl_id', 'tracking', 'type', 'service_tracking', 'is_storable',
            //     'write_date', 'color', 'available_in_pos', 'attribute_line_ids', 'active', 'image_128', 'combo_ids', 'product_template_variant_value_ids', 'product_tag_ids',
            // ]
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // result = super()._load_pos_data_fields(config_id)
            // result.append('all_product_tag_ids')
            // return result
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['all_product_tag_ids']
            // 
            // # add missing product fields used in the reward_product_domain
            // missing_fields = self.env['loyalty.reward']._get_reward_product_domain_fields(config_id) - set(params)
            // 
            // if missing_fields:
            //     params.extend([field for field in missing_fields if field in self._fields])
            // 
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['invoice_policy', 'optional_product_ids', 'type']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['self_order_available']
            // return params
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data(self, data):
            // # Add custom fields for 'formula' taxes.
            // fields = set(self._load_pos_data_fields(data['pos.config']['data'][0]['id']))
            // taxes = self.env['account.tax'].search(self.env['account.tax']._load_pos_data_domain(data))
            // product_fields = taxes._eval_taxes_computation_prepare_product_fields()
            // fields = list(fields.union(product_fields))
            // 
            // config = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // limit_count = config.get_limited_product_count()
            // if limit_count:
            //     products = config.with_context(display_default_code=False).get_limited_products_loading(fields)
            // else:
            //     domain = self._load_pos_data_domain(data)
            //     products = self._load_product_with_domain(domain, config.id)
            // 
            // self._add_missing_products(products, config.id, data)
            // 
            // data['pos.config']['data'][0]['_product_default_values'] = \
            //     self.env['account.tax']._eval_taxes_computation_prepare_product_default_values(product_fields)
            // 
            // self._process_pos_ui_product_product(products, config)
            // return {
            //     'data': products,
            //     'fields': fields,
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: product_product.py) ---
            // def _load_pos_data(self, data):
            // res = super()._load_pos_data(data)
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // discount_product_id = config_id.discount_product_id.id
            // product_ids_set = {product['id'] for product in res['data']}
            // 
            // if config_id.module_pos_discount and discount_product_id not in product_ids_set:
            //     productModel = self.env['product.product'].with_context({**self.env.context, 'display_default_code': False})
            //     product = productModel.search_read([('id', '=', discount_product_id)], fields=res['fields'], load=False)
            //     self._process_pos_ui_product_product(product, config_id)
            //     res['data'].extend(product)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: product_product.py) ---
            // def _load_pos_data(self, data):
            // res = super()._load_pos_data(data)
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // try:
            //     rewards = config_id._get_program_ids().reward_ids
            //     reward_products = rewards.discount_line_product_id | rewards.reward_product_ids | rewards.reward_product_id
            //     trigger_products = config_id._get_program_ids().filtered(lambda p: p.program_type in ['ewallet', 'gift_card']).trigger_product_ids
            // 
            //     loyalty_product_ids = set(reward_products.ids + trigger_products.ids)
            //     classic_product_ids = {product['id'] for product in res['data']}
            //     products = self.env['product.product'].browse(list(loyalty_product_ids - classic_product_ids))
            //     products = products.read(fields=res['fields'], load=False)
            //     self._process_pos_ui_product_product(products, config_id)
            // 
            //     data['pos.session']['data'][0]['_pos_special_products_ids'] += [product.id for product in reward_products if product.id not in [p["id"] for p in res['data']]]
            //     res['data'].extend(products)
            // except AccessError as e:
            //     _logger.warning('Cannot load loyalty products into the PoS \n%s', e)
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosSelfDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_self_data_domain(self, data):
            // domain = super()._load_pos_self_data_domain(data)
            // return AND([domain, [('self_order_available', '=', True)]])
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosSelfDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_self_data_fields(self, config_id):
            // params = super()._load_pos_self_data_fields(config_id)
            // params += ['public_description', 'list_price']
            // return params
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosSelfDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_self_data(self, data):
            // domain = self._load_pos_self_data_domain(data)
            // config_id = data['pos.config']['data'][0]['id']
            // 
            // # Add custom fields for 'formula' taxes.
            // fields = set(self._load_pos_self_data_fields(config_id))
            // taxes = self.env['account.tax'].search(self.env['account.tax']._load_pos_data_domain(data))
            // product_fields = taxes._eval_taxes_computation_prepare_product_fields()
            // fields = list(fields.union(product_fields))
            // 
            // config = self.env['pos.config'].browse(config_id)
            // products = self.with_context(display_default_code=False).search_read(
            //     domain,
            //     fields,
            //     limit=config.get_limited_product_count(),
            //     order='sequence,default_code,name',
            //     load=False
            // )
            // combo_products = self.browse((p['id'] for p in products if p["type"]=="combo"))
            // combo_products_choice = self.with_context(display_default_code=False).search_read(
            //     [("id", 'in', combo_products.combo_ids.combo_item_ids.product_id.ids), ("id", "not in", [p['id'] for p in products])],
            //     fields,
            //     limit=config.get_limited_product_count(),
            //     order='sequence,default_code,name',
            //     load=False
            // )
            // products.extend(combo_products_choice)
            // for product in products:
            //     product['image_128'] = bool(product['image_128'])
            // 
            // data['pos.config']['data'][0]['_product_default_values'] = \
            //     self.env['account.tax']._eval_taxes_computation_prepare_product_default_values(product_fields)
            // 
            // self._compute_product_price_with_pricelist(products, config_id)
            // return {
            //     'data': products,
            //     'fields': fields,
            // }
            */
            return default;
        }

        protected async Task<ProductProduct> LoadProductWithDomainInternalAsync(object domain, Guid config_id, object load_archived)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_product_with_domain(self, domain, config_id, load_archived=False):
            // fields = self._load_pos_data_fields(config_id)
            // context = {**self.env.context, 'display_default_code': False, 'active_test': not load_archived}
            // return self.with_context(context).search_read(
            //     domain,
            //     fields,
            //     order='sequence,default_code,name',
            //     load=False)
            */
            return default;
        }

        protected async Task<ProductProduct> MatchAllVariantValuesInternalAsync(List<Guid> product_template_attribute_value_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _match_all_variant_values(self, product_template_attribute_value_ids):
            // """ It currently checks that all variant values (`product_template_attribute_value_ids`)
            // are in the product (`self`).
            // 
            // If multiple values are encoded for the same attribute line, only one of
            // them has to be found on the variant.
            // """
            // self.ensure_one()
            // # The intersection of the values of the product and those of the line satisfy:
            // # * the number of items equals the number of attributes (since a product cannot
            // #   have multiple values for the same attribute),
            // # * the attributes are a subset of the attributes of the line.
            // return len(self.product_template_attribute_value_ids & product_template_attribute_value_ids) == len(product_template_attribute_value_ids.attribute_id)
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeDefaultCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _onchange_default_code(self):
            // if not self.default_code:
            //     return
            // 
            // domain = [('default_code', '=', self.default_code)]
            // if self.id.origin:
            //     domain.append(('id', '!=', self.id.origin))
            // 
            // if self.env['product.product'].search_count(domain, limit=1):
            //     return {'warning': {
            //         'title': _("Note:"),
            //         'message': _("The Reference '%s' already exists.", self.default_code),
            //     }}
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangePublicCategIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _onchange_public_categ_ids(self):
            // if self.public_categ_ids:
            //     self.website_published = True
            // else:
            //     self.website_published = False
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServiceFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def _onchange_service_fields(self):
            // for record in self:
            //     default_uom_id = self.env['ir.default']._get_model_defaults('product.product').get('uom_id')
            //     default_uom = self.env['uom.uom'].browse(default_uom_id)
            //     if record.type == 'service' and record.service_type == 'timesheet' and \
            //        not (record._origin.service_policy and record.service_policy == record._origin.service_policy):
            //         if default_uom and default_uom.category_id == self.env.ref('uom.uom_categ_wtime'):
            //             record.uom_id = default_uom
            //         else:
            //             record.uom_id = self.env.ref('uom.product_uom_hour')
            //     elif record._origin.uom_id:
            //         record.uom_id = record._origin.uom_id
            //     elif default_uom:
            //         record.uom_id = default_uom
            //     else:
            //         record.uom_id = self.product_tmpl_id.default_get(['uom_id']).get('uom_id')
            //     record.uom_po_id = record.uom_id
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def _onchange_service_policy(self):
            // self._inverse_service_policy()
            // vals = self.product_tmpl_id._get_onchange_service_policy_updates(self.service_tracking,
            //                                                                 self.service_policy,
            //                                                                 self.project_id,
            //                                                                 self.project_template_id)
            // if vals:
            //     self.update(vals)
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServiceTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_product.py) ---
            // def _onchange_service_tracking(self):
            // if self.service_tracking == 'no':
            //     self.project_id = False
            //     self.project_template_id = False
            // elif self.service_tracking == 'task_global_project':
            //     self.project_template_id = False
            // elif self.service_tracking in ['task_in_project', 'project_only']:
            //     self.project_id = False
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _onchange_standard_price(self):
            //         if self.lot_valuated:
            //             return {
            //                 'warning': {
            //                     'title': _("Warning"),
            //                     'message': _("This product is valuated by lot/serial number. Changing the cost \
            // will update the cost of every lot/serial number in stock."),
            //                 }
            //             }
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_tracking(self):
            // if any(product.tracking != 'none' and product.qty_available > 0 for product in self):
            //     return {
            //         'warning': {
            //             'title': _('Warning!'),
            //             'message': _("You have product(s) in stock that have no lot/serial number. You can assign lot/serial numbers by doing an inventory adjustment.")}}
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTypeEventBoothInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_product.py) ---
            // def _onchange_type_event_booth(self):
            // if self.service_tracking == 'event_booth':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _onchange_type(self):
            // if self._origin and self.sales_count > 0:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("You cannot change the product's type because it is already used in sales orders.")
            //     }}
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _onchange_uom_id(self):
            // if self.uom_id:
            //     self.uom_po_id = self.uom_id.id
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _onchange_uom(self):
            // if self.uom_id and self.uom_po_id and self.uom_id.category_id != self.uom_po_id.category_id:
            //     self.uom_po_id = self.uom_id
            */
            return default;
        }

        public async Task<ProductProduct> OpenDocumentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def action_open_documents(self):
            // res = self.product_tmpl_id.action_open_documents()
            // res['context'].update({
            //     'default_res_model': self._name,
            //     'default_res_id': self.id,
            //     'search_default_context_variant': True,
            // })
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenLabelLayoutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def action_open_label_layout(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_ids': self.ids}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenPricelistRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def open_pricelist_rules(self):
            // self.ensure_one()
            // domain = ['|',
            //     '&', ('product_tmpl_id', '=', self.product_tmpl_id.id), ('applied_on', '=', '1_product'),
            //     '&', ('product_id', '=', self.id), ('applied_on', '=', '0_product_variant'),
            //     ('compute_price', '=', 'fixed'),
            // ]
            // return {
            //     'name': _('Price Rules'),
            //     'view_mode': 'list,form',
            //     'views': [(self.env.ref('product.product_pricelist_item_tree_view_from_product').id, 'list')],
            //     'res_model': 'product.pricelist.item',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'domain': domain,
            //     'context': {
            //         'default_product_id': self.id,
            //         'default_applied_on': '0_product_variant',
            //         'search_default_visible': True,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenProductLotAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_product_lot(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_product_production_lot_form")
            // action['domain'] = [
            //     ('product_id', '=', self.id),
            //     '|', ('location_id', '=', False),
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self._context['allowed_company_ids']))
            // ]
            // action['context'] = {
            //     'default_product_id': self.id,
            //     'set_product_readonly': True,
            //     'search_default_group_by_location': True,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenProductTemplateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def open_product_template(self):
            // """ Utility method used to add an "Open Template" button in product views """
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'product.template',
            //     'view_mode': 'form',
            //     'res_id': self.product_tmpl_id.id,
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenQuantsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_open_quants(self):
            // bom_kits = self.env['mrp.bom']._bom_find(self, bom_type='phantom')
            // components = self - self.env['product.product'].concat(*list(bom_kits.keys()))
            // for product in bom_kits:
            //     boms, bom_sub_lines = bom_kits[product].explode(product, 1)
            //     components |= self.env['product.product'].concat(*[l[0].product_id for l in bom_sub_lines])
            // res = super(ProductProduct, components).action_open_quants()
            // if bom_kits:
            //     res['context']['single_product'] = False
            //     res['context'].pop('default_product_tmpl_id', None)
            // return res
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: product_product.py) ---
            // def action_open_quants(self):
            // # Override to hide the `removal_date` column if not needed.
            // if not any(product.use_expiration_date for product in self):
            //     self = self.with_context(hide_removal_date=True)
            // return super().action_open_quants()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_quants(self):
            // hide_location = not self.env.user.has_group('stock.group_stock_multi_locations')
            // hide_lot = all(product.tracking == 'none' for product in self)
            // self = self.with_context(
            //     hide_location=hide_location, hide_lot=hide_lot,
            //     no_at_date=True, search_default_on_hand=True,
            // )
            // 
            // # If user have rights to write on quant, we define the view as editable.
            // if self.env.user.has_group('stock.group_stock_manager'):
            //     self = self.with_context(inventory_mode=True)
            //     # Set default location id if multilocations is inactive
            //     if not self.env.user.has_group('stock.group_stock_multi_locations'):
            //         user_company = self.env.company
            //         warehouse = self.env['stock.warehouse'].search(
            //             [('company_id', '=', user_company.id)], limit=1
            //         )
            //         if warehouse:
            //             self = self.with_context(default_location_id=warehouse.lot_stock_id.id)
            // # Set default product id if quants concern only one product
            // if len(self) == 1:
            //     self = self.with_context(
            //         default_product_id=self.id,
            //         single_product=True
            //     )
            // else:
            //     self = self.with_context(product_tmpl_ids=self.product_tmpl_id.ids)
            // action = self.env['stock.quant'].action_view_quants()
            // # note that this action is used by different views w/varying customizations
            // if not self.env.context.get('is_stock_report'):
            //     action['domain'] = [('product_id', 'in', self.ids)]
            //     action["name"] = _('Update Quantity')
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def open_website_url(self):
            // self.ensure_one()
            // res = self.product_tmpl_id.open_website_url()
            // res['url'] = self.website_url
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> OptionalProductPosDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: product_product.py) ---
            // def _optional_product_pos_domain(self):
            // return [
            //     *self.env['product.product']._check_company_domain(self.env.company),
            //     ['sale_ok', '=', True],
            //     ['available_in_pos', '=', True],
            // ]
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareCategoriesForDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_comparison, FILE: product_product.py) ---
            // def _prepare_categories_for_display(self):
            // """On the comparison page group on the same line the values of each
            // product that concern the same attributes, and then group those
            // attributes per category.
            // 
            // The returned categories are ordered following their default order.
            // 
            // :return: OrderedDict [{
            //     product.attribute.category: OrderedDict [{
            //         product.attribute: OrderedDict [{
            //             product: [product.template.attribute.value]
            //         }]
            //     }]
            // }]
            // """
            // attributes = self.product_tmpl_id.valid_product_template_attribute_line_ids.attribute_id.sorted()
            // categories = OrderedDict([(cat, OrderedDict()) for cat in attributes.category_id.sorted()])
            // if any(not pa.category_id for pa in attributes):
            //     # category_id is not required and the mapped does not return empty
            //     categories[self.env['product.attribute.category']] = OrderedDict()
            // for pa in attributes:
            //     categories[pa.category_id][pa] = OrderedDict([(
            //         product,
            //         product.attribute_line_ids.filtered(lambda ptal: ptal.attribute_id == pa).value_ids
            //     ) for product in self])
            // return categories
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareInSvlValsInternalAsync(object quantity, object unit_cost, object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _prepare_in_svl_vals(self, quantity, unit_cost, lot=False):
            // """Prepare the values for a stock valuation layer created by a receipt.
            // 
            // :param quantity: the quantity to value, expressed in `self.uom_id`
            // :param unit_cost: the unit cost to value `quantity`
            // :return: values to use in a call to create
            // :rtype: dict
            // """
            // self.ensure_one()
            // company_id = self.env.context.get('force_company', self.env.company.id)
            // company = self.env['res.company'].browse(company_id)
            // value = company.currency_id.round(unit_cost * quantity)
            // return {
            //     'product_id': self.id,
            //     'value': value,
            //     'unit_cost': unit_cost,
            //     'quantity': quantity,
            //     'remaining_qty': quantity,
            //     'remaining_value': value,
            //     'company_id': company_id,
            //     'lot_id': lot.id if lot else False,
            // }
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareOutSvlValsInternalAsync(object quantity, object company, object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _prepare_out_svl_vals(self, quantity, company, lot=False):
            // """Prepare the values for a stock valuation layer created by a delivery.
            // 
            // :param quantity: the quantity to value, expressed in `self.uom_id`
            // :return: values to use in a call to create
            // :rtype: dict
            // """
            // self.ensure_one()
            // company_id = self.env.context.get('force_company', self.env.company.id)
            // company = self.env['res.company'].browse(company_id)
            // currency = company.currency_id
            // # Quantity is negative for out valuation layers.
            // quantity = -1 * quantity
            // cost = self.standard_price
            // if lot and lot.standard_price:
            //     cost = lot.standard_price
            // vals = {
            //     'product_id': self.id,
            //     'value': currency.round(quantity * cost),
            //     'unit_cost': cost,
            //     'quantity': quantity,
            //     'lot_id': lot.id if lot else False,
            // }
            // fifo_vals = self._run_fifo(abs(quantity), company, lot=lot)
            // vals['remaining_qty'] = fifo_vals.get('remaining_qty')
            // # In case of AVCO, fix rounding issue of standard price when needed.
            // if self.product_tmpl_id.cost_method == 'average' and not float_is_zero(self.quantity_svl, precision_rounding=self.uom_id.rounding):
            //     rounding_error = currency.round(
            //         (cost * self.quantity_svl - self.value_svl) * abs(quantity / self.quantity_svl)
            //     )
            // 
            //     # If it is bigger than the (smallest number of the currency * quantity) / 2,
            //     # then it isn't a rounding error but a stock valuation error, we shouldn't fix it under the hood ...
            //     threshold = currency.round(max((abs(quantity) * currency.rounding) / 2, currency.rounding))
            //     if rounding_error and abs(rounding_error) <= threshold:
            //         vals['value'] += rounding_error
            //         vals['rounding_adjustment'] = '\nRounding Adjustment: %s%s %s' % (
            //             '+' if rounding_error > 0 else '',
            //             float_repr(rounding_error, precision_digits=currency.decimal_places),
            //             currency.symbol
            //         )
            // if self.product_tmpl_id.cost_method == 'fifo':
            //     vals.update(fifo_vals)
            // return vals
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareSellersInternalAsync(object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: product.py) ---
            // def _prepare_sellers(self, params=False):
            // if params and params.get('subcontractor_ids'):
            //     return super()._prepare_sellers(params=params).filtered(lambda s: s.partner_id in params.get('subcontractor_ids'))
            // return super()._prepare_sellers(params=params)
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _prepare_sellers(self, params=False):
            // sellers = self.seller_ids._get_filtered_supplier(self.env.company, self, params)
            // return sellers.sorted(lambda s: (s.sequence, -s.min_qty, s.price, s.id))
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: product.py) ---
            // def _prepare_sellers(self, params=False):
            // sellers = super(ProductProduct, self)._prepare_sellers(params=params)
            // if params and params.get('order_id') and params['order_id']._fields.get("requisition_id"):
            //     return sellers.filtered(lambda s: not s.purchase_requisition_id or s.purchase_requisition_id == params['order_id'].requisition_id)
            // else:
            //     return sellers
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareVariantValuesInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _prepare_variant_values(self, combination):
            // variant_dict = super()._prepare_variant_values(combination)
            // variant_dict['base_unit_count'] = self.base_unit_count
            // return variant_dict
            */
            return default;
        }

        protected async Task<ProductProduct> PriceComputeInternalAsync(object price_type, object uom, object currency, object company, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _price_compute(self, price_type, uom=None, currency=None, company=None, date=False):
            // company = company or self.env.company
            // date = date or fields.Date.context_today(self)
            // 
            // self = self.with_company(company)
            // if price_type == 'standard_price':
            //     # standard_price field can only be seen by users in base.group_user
            //     # Thus, in order to compute the sale price from the cost for users not in this group
            //     # We fetch the standard price as the superuser
            //     self = self.sudo()
            // 
            // prices = dict.fromkeys(self.ids, 0.0)
            // for product in self:
            //     price = product[price_type] or 0.0
            //     price_currency = product.currency_id
            //     if price_type == 'standard_price':
            //         price_currency = product.cost_currency_id
            //     elif price_type == 'list_price':
            //         price += product._get_attributes_extra_price()
            // 
            //     if uom:
            //         price = product.uom_id._compute_price(price, uom)
            // 
            //     # Convert from current user company currency to asked one
            //     # This is right cause a field cannot be in more than one currency
            //     if currency:
            //         price = price_currency._convert(price, currency, company, date)
            // 
            //     prices[product.id] = price
            // 
            // return prices
            */
            return default;
        }

        protected async Task<ProductProduct> ProcessPosUiProductProductInternalAsync(object products, Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _process_pos_ui_product_product(self, products, config_id):
            // 
            // def filter_taxes_on_company(product_taxes, taxes_by_company):
            //     """
            //     Filter the list of tax ids on a single company starting from the current one.
            //     If there is no tax in the result, it's filtered on the parent company and so
            //     on until a non empty result is found.
            //     """
            //     taxes, comp = None, self.env.company
            //     while not taxes and comp:
            //         taxes = list(set(product_taxes) & set(taxes_by_company[comp.id]))
            //         comp = comp.parent_id
            //     return taxes
            // 
            // taxes = self.env['account.tax'].search(self.env['account.tax']._check_company_domain(self.env.company))
            // # group all taxes by company in a dict where:
            // # - key: ID of the company
            // # - values: list of tax ids
            // taxes_by_company = defaultdict(set)
            // if self.env.company.parent_id:
            //     for tax in taxes:
            //         taxes_by_company[tax.company_id.id].add(tax.id)
            // 
            // loaded_product_tmpl_ids = list({p['product_tmpl_id'] for p in products})
            // archived_combinations = self._get_archived_combinations_per_product_tmpl_id(loaded_product_tmpl_ids)
            // different_currency = config_id.currency_id != self.env.company.currency_id
            // for product in products:
            //     if different_currency:
            //         product['lst_price'] = self.env.company.currency_id._convert(product['lst_price'], config_id.currency_id, self.env.company, fields.Date.today())
            //     product['image_128'] = bool(product['image_128'])
            // 
            //     if len(taxes_by_company) > 1 and len(product['taxes_id']) > 1:
            //         product['taxes_id'] = filter_taxes_on_company(product['taxes_id'], taxes_by_company)
            // 
            //     if archived_combinations.get(product['product_tmpl_id']):
            //         product['_archived_combinations'] = archived_combinations[product['product_tmpl_id']]
            */
            return default;
        }

        public async Task<ProductProduct> ProductForecastReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_product_forecast_report(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_forecasted_product_product_action")
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> ReadGroupInternalAsync(object domain, object groupby, object aggregates, object having, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_margin, FILE: product_product.py) ---
            // def _read_group(self, domain, groupby=(), aggregates=(), having=(), offset=0, limit=None, order=None):
            // """
            //     Inherit _read_group to calculate the sum of the non-stored fields, as it is not automatically done anymore through the XML.
            // """
            // if self._SPECIAL_SUM_AGGREGATES.isdisjoint(aggregates):
            //     return super()._read_group(domain, groupby, aggregates, having, offset, limit, order)
            // 
            // base_aggregates = [*(agg for agg in aggregates if agg not in self._SPECIAL_SUM_AGGREGATES), 'id:recordset']
            // base_result = super()._read_group(domain, groupby, base_aggregates, having, offset, limit, order)
            // 
            // # Force the compute of all records to bypass the limit compute batching (PREFETCH_MAX)
            // all_records = self.browse().union(*(item[-1] for item in base_result))
            // # This line will compute all fields having _compute_product_margin_fields_values
            // # as compute method.
            // self._fields['turnover'].compute_value(all_records)
            // 
            // # base_result = [(a1, b1, records), (a2, b2, records), ...]
            // result = []
            // for *other, records in base_result:
            //     for index, spec in enumerate(itertools.chain(groupby, aggregates)):
            //         if spec in self._SPECIAL_SUM_AGGREGATES:
            //             field_name = spec.split(':')[0]
            //             other.insert(index, sum(records.mapped(field_name)))
            //     result.append(tuple(other))
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProductProduct> ReadGroupSelectInternalAsync(object aggregate_spec, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_margin, FILE: product_product.py) ---
            // def _read_group_select(self, aggregate_spec, query):
            // # the purpose of this override is to flag the aggregates above as such:
            // # field._description_aggregator() should simply not fail
            // if aggregate_spec in self._SPECIAL_SUM_AGGREGATES:
            //     return SQL()
            // return super()._read_group_select(aggregate_spec, query)
            */
            return default;
        }

        protected async Task<ProductProduct> RetrieveProductInternalAsync(object name, object default_code, object barcode, object company, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _retrieve_product(self, name=None, default_code=None, barcode=None, company=None, extra_domain=None):
            // '''Search all products and find one that matches one of the parameters.
            // 
            // :param name:            The name of the product.
            // :param default_code:    The default_code of the product.
            // :param barcode:         The barcode of the product.
            // :param company:         The company of the product.
            // :param extra_domain:    Any extra domain to add to the search.
            // :returns:               A product or an empty recordset if not found.
            // '''
            // if name and '\n' in name:
            //     # cut Sales Description from the name
            //     name = name.split('\n')[0]
            // domains = []
            // if barcode:
            //     domains.append([('barcode', '=', barcode)])
            // if default_code:
            //     domains.append([('default_code', '=', default_code)])
            // if name:
            //     domains += [[('name', '=', name)], [('name', 'ilike', name)]]
            // 
            // company = company or self.env.company
            // for company_domain in (
            //     [*self.env['res.partner']._check_company_domain(company), ('company_id', '!=', False)],
            //     [('company_id', '=', False)],
            // ):
            //     products = self.env['product.product'].search(
            //         expression.AND([
            //             expression.OR(domains),
            //             company_domain,
            //             extra_domain or [],
            //         ]),
            //     )
            //     for domain in domains:
            //         if products_by_domain := products.filtered_domain(domain):
            //             return products_by_domain[0]
            // return self.env['product.product']
            */
            return default;
        }

        public async Task<ProductProduct> RevaluationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def action_revaluation(self):
            // self.ensure_one()
            // ctx = dict(self._context, default_product_id=self.id, default_company_id=self.env.company.id)
            // return {
            //     'name': _("Product Revaluation"),
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

        protected async Task<ProductProduct> RunFifoInternalAsync(object quantity, object company, object lot)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _run_fifo(self, quantity, company, lot=False):
            // self.ensure_one()
            // 
            // # Find back incoming stock valuation layers (called candidates here) to value `quantity`.
            // qty_to_take_on_candidates = quantity
            // candidates = self._get_fifo_candidates(company, lot=lot)
            // new_standard_price = 0
            // tmp_value = 0  # to accumulate the value taken on the candidates
            // for candidate in candidates:
            //     qty_taken_on_candidate = self._get_qty_taken_on_candidate(qty_to_take_on_candidates, candidate)
            // 
            //     candidate_unit_cost = candidate.remaining_value / candidate.remaining_qty
            //     new_standard_price = candidate_unit_cost
            //     value_taken_on_candidate = qty_taken_on_candidate * candidate_unit_cost
            //     value_taken_on_candidate = candidate.currency_id.round(value_taken_on_candidate)
            //     new_remaining_value = candidate.remaining_value - value_taken_on_candidate
            // 
            //     candidate_vals = {
            //         'remaining_qty': candidate.remaining_qty - qty_taken_on_candidate,
            //         'remaining_value': new_remaining_value,
            //     }
            // 
            //     candidate.write(candidate_vals)
            // 
            //     qty_to_take_on_candidates -= qty_taken_on_candidate
            //     tmp_value += value_taken_on_candidate
            // 
            //     if float_is_zero(qty_to_take_on_candidates, precision_rounding=self.uom_id.rounding):
            //         if float_is_zero(candidate.remaining_qty, precision_rounding=self.uom_id.rounding):
            //             next_candidates = candidates.filtered(lambda svl: svl.remaining_qty > 0)
            //             new_standard_price = next_candidates and next_candidates[0].unit_cost or new_standard_price
            //         break
            // 
            // # Fifo out will change the AVCO value of the product. So in case of out,
            // # we recompute it base on the remaining value and quantities.
            // if self.cost_method == 'fifo':
            //     quantity_svl = sum(candidates.mapped('remaining_qty'))
            //     value_svl = sum(candidates.mapped('remaining_value'))
            //     product = self.sudo().with_company(company.id).with_context(disable_auto_svl=True)
            //     if float_compare(quantity_svl, 0.0, precision_rounding=self.uom_id.rounding) > 0:
            //         product.standard_price = value_svl / quantity_svl
            //     elif candidates and not float_is_zero(qty_to_take_on_candidates, precision_rounding=self.uom_id.rounding):
            //         product.standard_price = new_standard_price
            // 
            // # If there's still quantity to value but we're out of candidates, we fall in the
            // # negative stock use case. We chose to value the out move at the price of the
            // # last out and a correction entry will be made once `_fifo_vacuum` is called.
            // vals = {}
            // if float_is_zero(qty_to_take_on_candidates, precision_rounding=self.uom_id.rounding):
            //     vals = {
            //         'value': -tmp_value,
            //         'unit_cost': tmp_value / quantity,
            //     }
            // else:
            //     assert qty_to_take_on_candidates > 0
            //     last_fifo_price = new_standard_price or self.standard_price
            //     negative_stock_value = last_fifo_price * -qty_to_take_on_candidates
            //     tmp_value += abs(negative_stock_value)
            //     vals = {
            //         'remaining_qty': -qty_to_take_on_candidates,
            //         'value': -tmp_value,
            //         'unit_cost': last_fifo_price,
            //     }
            // return vals
            */
            return default;
        }

        protected async Task<ProductProduct> RunFifoVacuumInternalAsync(object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _run_fifo_vacuum(self, company=None):
            // """Compensate layer valued at an estimated price with the price of future receipts
            // if any. If the estimated price is equals to the real price, no layer is created but
            // the original layer is marked as compensated.
            // 
            // :param company: recordset of `res.company` to limit the execution of the vacuum
            // """
            // if company is None:
            //     company = self.env.company
            // ValuationLayer = self.env['stock.valuation.layer'].sudo()
            // svls_to_vacuum_by_product = defaultdict(lambda: ValuationLayer)
            // res = ValuationLayer._read_group([
            //     ('product_id', 'in', self.ids),
            //     ('remaining_qty', '<', 0),
            //     ('stock_move_id', '!=', False),
            //     ('company_id', '=', company.id),
            // ], ['product_id'], ['id:recordset', 'create_date:min'], order='create_date:min')
            // min_create_date = datetime.max
            // if not res:
            //     return
            // for group in res:
            //     svls_to_vacuum_by_product[group[0].id] = group[1].sorted(key=lambda r: (r.create_date, r.id))
            //     min_create_date = min(min_create_date, group[2])
            // all_candidates_by_product = defaultdict(lambda: ValuationLayer)
            // lot_to_update = []
            // res = ValuationLayer._read_group([
            //     ('product_id', 'in', self.ids),
            //     ('remaining_qty', '>', 0),
            //     ('company_id', '=', company.id),
            //     ('create_date', '>=', min_create_date),
            // ], ['product_id'], ['id:recordset'])
            // for group in res:
            //     all_candidates_by_product[group[0].id] = group[1]
            // 
            // new_svl_vals_real_time = []
            // new_svl_vals_manual = []
            // real_time_svls_to_vacuum = ValuationLayer
            // 
            // for product in self.with_company(company.id):
            //     all_candidates = all_candidates_by_product[product.id]
            //     current_real_time_svls = ValuationLayer
            //     for svl_to_vacuum in svls_to_vacuum_by_product[product.id]:
            //         # We don't use search to avoid executing _flush_search and to decrease interaction with DB
            //         candidates = all_candidates.filtered(
            //             lambda r: r.create_date > svl_to_vacuum.create_date
            //             or r.create_date == svl_to_vacuum.create_date
            //             and r.id > svl_to_vacuum.id
            //         )
            //         if product.lot_valuated:
            //             candidates = candidates.filtered(lambda r: r.lot_id == svl_to_vacuum.lot_id)
            //         if not candidates:
            //             break
            //         qty_to_take_on_candidates = abs(svl_to_vacuum.remaining_qty)
            //         qty_taken_on_candidates = 0
            //         tmp_value = 0
            //         for candidate in candidates:
            //             qty_taken_on_candidate = min(candidate.remaining_qty, qty_to_take_on_candidates)
            //             qty_taken_on_candidates += qty_taken_on_candidate
            // 
            //             candidate_unit_cost = candidate.remaining_value / candidate.remaining_qty
            //             value_taken_on_candidate = qty_taken_on_candidate * candidate_unit_cost
            //             value_taken_on_candidate = candidate.currency_id.round(value_taken_on_candidate)
            //             new_remaining_value = candidate.remaining_value - value_taken_on_candidate
            // 
            //             candidate_vals = {
            //                 'remaining_qty': candidate.remaining_qty - qty_taken_on_candidate,
            //                 'remaining_value': new_remaining_value
            //             }
            //             candidate.write(candidate_vals)
            //             if not (candidate.remaining_qty > 0):
            //                 all_candidates -= candidate
            // 
            //             qty_to_take_on_candidates -= qty_taken_on_candidate
            //             tmp_value += value_taken_on_candidate
            //             if float_is_zero(qty_to_take_on_candidates, precision_rounding=product.uom_id.rounding):
            //                 break
            // 
            //         # Get the estimated value we will correct.
            //         remaining_value_before_vacuum = svl_to_vacuum.unit_cost * qty_taken_on_candidates
            //         new_remaining_qty = svl_to_vacuum.remaining_qty + qty_taken_on_candidates
            //         corrected_value = remaining_value_before_vacuum - tmp_value
            //         svl_to_vacuum.write({
            //             'remaining_qty': new_remaining_qty,
            //         })
            // 
            //         # Don't create a layer or an accounting entry if the corrected value is zero.
            //         if svl_to_vacuum.currency_id.is_zero(corrected_value):
            //             continue
            // 
            //         corrected_value = svl_to_vacuum.currency_id.round(corrected_value)
            // 
            //         move = svl_to_vacuum.stock_move_id
            //         new_svl_vals = new_svl_vals_real_time if product.valuation == 'real_time' else new_svl_vals_manual
            //         new_svl_vals.append({
            //             'product_id': product.id,
            //             'value': corrected_value,
            //             'unit_cost': 0,
            //             'quantity': 0,
            //             'remaining_qty': 0,
            //             'stock_move_id': move.id,
            //             'company_id': move.company_id.id,
            //             'description': 'Revaluation of %s (negative inventory)' % (move.picking_id.name or move.name),
            //             'stock_valuation_layer_id': svl_to_vacuum.id,
            //             'lot_id': svl_to_vacuum.lot_id.id,
            //         })
            //         lot_to_update.append(svl_to_vacuum.lot_id)
            //         if product.valuation == 'real_time':
            //             current_real_time_svls |= svl_to_vacuum
            //     real_time_svls_to_vacuum |= current_real_time_svls
            // ValuationLayer.create(new_svl_vals_manual)
            // vacuum_svls = ValuationLayer.create(new_svl_vals_real_time)
            // 
            // # If some negative stock were fixed, we need to recompute the standard price.
            // for product in self:
            //     product = product.with_company(company.id)
            //     if not svls_to_vacuum_by_product[product.id]:
            //         continue
            //     if product.cost_method not in ['average', 'fifo'] or float_is_zero(product.quantity_svl,
            //                                                               precision_rounding=product.uom_id.rounding):
            //         continue
            //     if product.lot_valuated:
            //         for lot in lot_to_update:
            //             if float_is_zero(lot.quantity_svl, precision_rounding=product.uom_id.rounding):
            //                 continue
            //             lot.sudo().with_context(disable_auto_svl=True).write(
            //                 {'standard_price': lot.value_svl / lot.quantity_svl}
            //             )
            //     product.sudo().with_context(disable_auto_svl=True).write({'standard_price': product.value_svl / product.quantity_svl})
            // 
            // vacuum_svls._validate_accounting_entries()
            // self._create_fifo_vacuum_anglo_saxon_expense_entries(zip(vacuum_svls, real_time_svls_to_vacuum))
            */
            return default;
        }

        protected async Task<ProductProduct> SearchAllProductTagIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search_all_product_tag_ids(self, operator, operand):
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return [('product_tag_ids', operator, operand), ('additional_product_tag_ids', operator, operand)]
            // return ['|', ('product_tag_ids', operator, operand), ('additional_product_tag_ids', operator, operand)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search_display_name(self, operator, value):
            // is_positive = operator not in expression.NEGATIVE_TERM_OPERATORS
            // combine = expression.OR if is_positive else expression.AND
            // domains = [
            //     [('name', operator, value)],
            //     [('default_code', operator, value)],
            // ]
            // if operator in ('=', 'in') or (operator.endswith('like') and is_positive):
            //     barcode_values = [value] if operator != 'in' else value
            //     domains.append([('barcode', 'in', barcode_values)])
            // if operator == '=' and isinstance(value, str) and (m := re.search(r'(\[(.*?)\])', value)):
            //     domains.append([('default_code', '=', m.group(2))])
            // if partner_id := self.env.context.get('partner_id'):
            //     supplier_domain = [
            //         ('partner_id', '=', partner_id),
            //         '|',
            //         ('product_code', operator, value),
            //         ('product_name', operator, value),
            //     ]
            //     domains.append([('product_tmpl_id.seller_ids', 'any', supplier_domain)])
            // return combine(domains)
            */
            return default;
        }

        protected async Task<ProductProduct> SearchFreeQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_free_qty(self, operator, value):
            // return self._search_product_quantity(operator, value, 'free_qty')
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIncomingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_incoming_qty(self, operator, value):
            // # TDE FIXME: should probably clean the search methods
            // return self._search_product_quantity(operator, value, 'incoming_qty')
            */
            return default;
        }

        protected async Task<ProductProduct> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // # TDE FIXME: strange
            // if self._context.get('search_default_categ_id'):
            //     domain = domain.copy()
            //     domain.append((('categ_id', 'child_of', self._context['search_default_categ_id'])))
            // return super()._search(domain, offset, limit, order)
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsInPurchaseOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _search_is_in_purchase_order(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // product_ids = self.env['purchase.order.line'].search([
            //     ('order_id', 'in', [self.env.context.get('order_id', '')]),
            // ]).product_id.ids
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsKitsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // assert operator in ('=', '!='), 'Unsupported operator'
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('active', '=', True),
            //      ('type', '=', 'phantom'), ('product_id', '=', False)])
            // bom_product_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('product_id', '!=', False)])
            // neg = ''
            // op = '|'
            // if (operator == '=' and not value) or (operator == '!=' and value):
            //     neg = 'not '
            //     op = '&'
            // return [op, ('product_tmpl_id', neg + 'in', bom_tmpl_query.subselect('product_tmpl_id')),
            //         ('id', neg + 'in', bom_product_query.subselect('product_id'))]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchOutgoingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_outgoing_qty(self, operator, value):
            // # TDE FIXME: should probably clean the search methods
            // return self._search_product_quantity(operator, value, 'outgoing_qty')
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInBomInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_product_is_in_bom(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // product_ids = self.env['mrp.bom.line'].search([
            //     ('bom_id', '=', self.env.context.get('order_id', '')),
            // ]).product_id.ids
            // if (operator == '!=' and value is True) or (operator == '=' and value is False):
            //     domain_operator = 'not in'
            // else:
            //     domain_operator = 'in'
            // return [('id', domain_operator, product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInMoInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_product_is_in_mo(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // product_ids = self.env['mrp.production'].search([
            //     ('id', 'in', [self.env.context.get('order_id', '')]),
            // ]).move_raw_ids.product_id.ids
            // if (operator == '!=' and value is True) or (operator == '=' and value is False):
            //     domain_operator = 'not in'
            // else:
            //     domain_operator = 'in'
            // return [('id', domain_operator, product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInRepairInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _search_product_is_in_repair(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // product_ids = self.env['repair.order'].search([
            //     ('id', 'in', [self.env.context.get('order_id', '')]),
            // ]).move_ids.product_id.ids
            // if (operator == '!=' and value is True) or (operator == '=' and value is False):
            //     domain_operator = 'not in'
            // else:
            //     domain_operator = 'in'
            // return [('id', domain_operator, product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInSaleOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _search_product_is_in_sale_order(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // product_ids = self.env['sale.order.line'].search([
            //     ('order_id', 'in', [self.env.context.get('order_id', '')]),
            // ]).product_id.ids
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductQuantityInternalAsync(object @operator, object @value, object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_product_quantity(self, operator, value, field):
            // # TDE FIXME: should probably clean the search methods
            // # to prevent sql injections
            // if field not in ('qty_available', 'virtual_available', 'incoming_qty', 'outgoing_qty', 'free_qty'):
            //     raise UserError(_('Invalid domain left operand %s', field))
            // if operator not in ('<', '>', '=', '!=', '<=', '>='):
            //     raise UserError(_('Invalid domain operator %s', operator))
            // if not isinstance(value, (float, int)):
            //     raise UserError(_("Invalid domain right operand '%s'. It must be of type Integer/Float", value))
            // 
            // # TODO: Still optimization possible when searching virtual quantities
            // ids = []
            // # Order the search on `id` to prevent the default order on the product name which slows
            // # down the search because of the join on the translation table to get the translated names.
            // for product in self.with_context(prefetch_fields=False).search([], order='id'):
            //     if OPERATORS[operator](product[field], value):
            //         ids.append(product.id)
            // return [('id', 'in', ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchQtyAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available(self, operator, value):
            // # In the very specific case we want to retrieve products with stock available, we only need
            // # to use the quants, not the stock moves. Therefore, we bypass the usual
            // # '_search_product_quantity' method and call '_search_qty_available_new' instead. This
            // # allows better performances.
            // if not ({'from_date', 'to_date'} & set(self.env.context.keys())):
            //     product_ids = self._search_qty_available_new(
            //         operator, value, self.env.context.get('lot_id'), self.env.context.get('owner_id'),
            //         self.env.context.get('package_id')
            //     )
            //     return [('id', 'in', product_ids)]
            // return self._search_product_quantity(operator, value, 'qty_available')
            */
            return default;
        }

        protected async Task<ProductProduct> SearchQtyAvailableNewInternalAsync(object @operator, object @value, Guid lot_id, Guid owner_id, Guid package_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_qty_available_new(self, operator, value, lot_id=False, owner_id=False, package_id=False):
            // '''extending the method in stock.product to take into account kits'''
            // product_ids = super(ProductProduct, self)._search_qty_available_new(operator, value, lot_id, owner_id, package_id)
            // kit_boms = self.env['mrp.bom'].search([('type', "=", 'phantom')])
            // kit_products = self.env['product.product']
            // for kit in kit_boms:
            //     if kit.product_id:
            //         kit_products |= kit.product_id
            //     else:
            //         kit_products |= kit.product_tmpl_id.product_variant_ids
            // for product in kit_products:
            //     if OPERATORS[operator](product.qty_available, value):
            //         product_ids.append(product.id)
            // return list(set(product_ids))
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available_new(self, operator, value, lot_id=False, owner_id=False, package_id=False):
            // ''' Optimized method which doesn't search on stock.moves, only on stock.quants. '''
            // if operator not in ('<', '>', '=', '!=', '<=', '>='):
            //     raise UserError(_('Invalid domain operator %s', operator))
            // if not isinstance(value, (float, int)):
            //     raise UserError(_("Invalid domain right operand '%s'. It must be of type Integer/Float", value))
            // 
            // product_ids = set()
            // domain_quant = self._get_domain_locations()[0]
            // if lot_id:
            //     domain_quant.append(('lot_id', '=', lot_id))
            // if owner_id:
            //     domain_quant.append(('owner_id', '=', owner_id))
            // if package_id:
            //     domain_quant.append(('package_id', '=', package_id))
            // quants_groupby = self.env['stock.quant']._read_group(domain_quant, ['product_id'], ['quantity:sum'])
            // 
            // # check if we need include zero values in result
            // include_zero = (
            //     value < 0.0 and operator in ('>', '>=') or
            //     value > 0.0 and operator in ('<', '<=') or
            //     value == 0.0 and operator in ('>=', '<=', '=')
            // )
            // 
            // processed_product_ids = set()
            // for product, quantity_sum in quants_groupby:
            //     product_id = product.id
            //     if include_zero:
            //         processed_product_ids.add(product_id)
            //     if OPERATORS[operator](quantity_sum, value):
            //         product_ids.add(product_id)
            // 
            // if include_zero:
            //     products_without_quants_in_domain = self.env['product.product'].search([
            //         ('is_storable', '=', True),
            //         ('id', 'not in', list(processed_product_ids))],
            //         order='id'
            //     )
            //     product_ids |= set(products_without_quants_in_domain.ids)
            // return list(product_ids)
            */
            return default;
        }

        protected async Task<ProductProduct> SearchVirtualAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_virtual_available(self, operator, value):
            // # TDE FIXME: should probably clean the search methods
            // return self._search_product_quantity(operator, value, 'virtual_available')
            */
            return default;
        }

        protected async Task<ProductProduct> SelectSellerInternalAsync(Guid partner_id, object quantity, object date, Guid uom_id, object ordered_by, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _select_seller(self, partner_id=False, quantity=0.0, date=None, uom_id=False, ordered_by='price_discounted', params=False):
            // # Always sort by discounted price but another field can take the primacy through the `ordered_by` param.
            // sort_key = ('price_discounted', 'sequence', 'id')
            // if ordered_by != 'price_discounted':
            //     sort_key = (ordered_by, 'price_discounted', 'sequence', 'id')
            // 
            // def sort_function(record):
            //     vals = {
            //         'price_discounted': record.currency_id._convert(
            //             record.price_discounted,
            //             record.env.company.currency_id,
            //             record.env.company,
            //             date or fields.Date.context_today(self),
            //             round=False,
            //         ),
            //     }
            //     return [vals.get(key, record[key]) for key in sort_key]
            // sellers = self._get_filtered_sellers(partner_id=partner_id, quantity=quantity, date=date, uom_id=uom_id, params=params)
            // res = self.env['product.supplierinfo']
            // for seller in sellers:
            //     if not res or res.partner_id == seller.partner_id:
            //         res |= seller
            // return res and res.sorted(sort_function)[:1]
            */
            return default;
        }

        protected async Task<ProductProduct> SendAvailabilityEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _send_availability_email(self):
            // for product in self.search([('stock_notification_partner_ids', '!=', False)]):
            //     if product._is_sold_out():
            //         continue
            //     for partner in product.stock_notification_partner_ids:
            //         self_ctxt = self.with_context(lang=partner.lang)
            //         product_ctxt = product.with_context(lang=partner.lang)
            //         body_html = self_ctxt.env['ir.qweb']._render(
            //             'website_sale_stock.availability_email_body', {'product': product_ctxt})
            //         msg = self_ctxt.env['mail.message'].sudo().new(dict(body=body_html, record_name=product_ctxt.name))
            //         full_mail = self_ctxt.env['mail.render.mixin']._render_encapsulate(
            //             "mail.mail_notification_light",
            //             body_html,
            //             add_context=dict(message=msg, model_description=_("Product")),
            //         )
            //         context = {'lang': partner.lang}  # Use partner lang to translate mail subject below
            //         mail_values = {
            //             "subject": _("The product '%(product_name)s' is now available", product_name=product_ctxt.name),
            //             "email_from": (product.company_id.partner_id or self.env.user).email_formatted,
            //             "email_to": partner.email_formatted,
            //             "body_html": full_mail,
            //         }
            //         del context
            // 
            //         mail = self_ctxt.env['mail.mail'].sudo().create(mail_values)
            //         mail.send(raise_exception=False)
            //         product.stock_notification_partner_ids -= partner
            */
            return default;
        }

        protected async Task<ProductProduct> SendAvailabilityStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _send_availability_status(self):
            // config_self = self.env['pos.config'].sudo().search([('self_ordering_mode', '!=', 'nothing')])
            // for config in config_self:
            //     if config.current_session_id and config.access_token:
            //         config._notify('PRODUCT_CHANGED', {
            //             'product.product': self.read(self._load_pos_self_data_fields(config.id), load=False)
            //         })
            */
            return default;
        }

        protected async Task<ProductProduct> SetImage1920InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _set_image_1920(self):
            // return self._set_template_field('image_1920', 'image_variant_1920')
            */
            return default;
        }

        protected async Task<ProductProduct> SetPriceFromBomInternalAsync(object boms_to_recompute)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _set_price_from_bom(self, boms_to_recompute=False):
            // self.ensure_one()
            // bom = self.env['mrp.bom']._bom_find(self)[self]
            // if bom:
            //     self.standard_price = self._compute_bom_price(bom, boms_to_recompute=boms_to_recompute)
            // else:
            //     bom = self.env['mrp.bom'].search([('byproduct_ids.product_id', '=', self.id)], order='sequence, product_id, id', limit=1)
            //     if bom:
            //         price = self._compute_bom_price(bom, boms_to_recompute=boms_to_recompute, byproduct_bom=True)
            //         if price:
            //             self.standard_price = price
            */
            return default;
        }

        protected async Task<ProductProduct> SetProductLstPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _set_product_lst_price(self):
            // for product in self:
            //     if self._context.get('uom'):
            //         value = self.env['uom.uom'].browse(self._context['uom'])._compute_price(product.lst_price, product.uom_id)
            //     else:
            //         value = product.lst_price
            //     value -= product.price_extra
            //     product.write({'list_price': value})
            */
            return default;
        }

        protected async Task<ProductProduct> SetTemplateFieldInternalAsync(object template_field, object variant_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _set_template_field(self, template_field, variant_field):
            // for record in self:
            //     if (
            //         # We are trying to remove a field from the variant even though it is already
            //         # not set on the variant, remove it from the template instead.
            //         (not record[template_field] and not record[variant_field])
            //         # We are trying to add a field to the variant, but the template field is
            //         # not set, write on the template instead.
            //         or (record[template_field] and not record.product_tmpl_id[template_field])
            //         # There is only one variant, always write on the template.
            //         or self.search_count([
            //             ('product_tmpl_id', '=', record.product_tmpl_id.id),
            //             ('active', '=', True),
            //         ]) <= 1
            //     ):
            //         record[variant_field] = False
            //         record.product_tmpl_id[template_field] = record[template_field]
            //     else:
            //         record[variant_field] = record[template_field]
            */
            return default;
        }

        protected async Task<ProductProduct> StockAccountGetAngloSaxonPriceUnitInternalAsync(object uom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _stock_account_get_anglo_saxon_price_unit(self, uom=False):
            // price = self.standard_price
            // if not self or not uom or self.uom_id.id == uom.id:
            //     return price or 0.0
            // return self.uom_id._compute_price(price, uom)
            */
            return default;
        }

        protected async Task<ProductProduct> SvlEmptyStockAmInternalAsync(object stock_valuation_layers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _svl_empty_stock_am(self, stock_valuation_layers):
            // move_vals_list = []
            // product_accounts = {product.id: product.product_tmpl_id.get_product_accounts() for product in stock_valuation_layers.mapped('product_id')}
            // for out_stock_valuation_layer in stock_valuation_layers:
            //     product = out_stock_valuation_layer.product_id
            //     stock_input_account = product_accounts[product.id].get('stock_input')
            //     if not stock_input_account:
            //         raise UserError(_('You don\'t have any stock input account defined on your product category. You must define one before processing this operation.'))
            //     if not product_accounts[product.id].get('stock_valuation'):
            //         raise UserError(_('You don\'t have any stock valuation account defined on your product category. You must define one before processing this operation.'))
            //     if not product_accounts[product.id].get('stock_output'):
            //         raise UserError(
            //             _('You don\'t have any output valuation account defined on your product '
            //               'category. You must define one before processing this operation.')
            //         )
            // 
            //     precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     orig_qtys = self.env.context.get('products_orig_quantity_svl')
            //     if orig_qtys and float_compare(orig_qtys[product.id], 0, precision_digits=precision) < 1:
            //         debit_account_id = product_accounts[product.id]['stock_valuation'].id
            //         credit_account_id = product_accounts[product.id]['stock_output'].id
            //     else:
            //         debit_account_id = stock_input_account.id
            //         credit_account_id = product_accounts[product.id]['stock_valuation'].id
            //     value = out_stock_valuation_layer.value
            //     move_vals = {
            //         'journal_id': product_accounts[product.id]['stock_journal'].id,
            //         'company_id': self.env.company.id,
            //         'ref': product.default_code,
            //         'stock_valuation_layer_ids': [(6, None, [out_stock_valuation_layer.id])],
            //         'line_ids': [(0, 0, {
            //             'name': out_stock_valuation_layer.description,
            //             'account_id': debit_account_id,
            //             'debit': abs(value),
            //             'credit': 0,
            //             'product_id': product.id,
            //         }), (0, 0, {
            //             'name': out_stock_valuation_layer.description,
            //             'account_id': credit_account_id,
            //             'debit': 0,
            //             'credit': abs(value),
            //             'product_id': product.id,
            //         })],
            //         'move_type': 'entry',
            //     }
            //     move_vals_list.append(move_vals)
            // return move_vals_list
            */
            return default;
        }

        protected async Task<ProductProduct> SvlEmptyStockInternalAsync(object description, object product_category, object product_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _svl_empty_stock(self, description, product_category=None, product_template=None):
            // impacted_product_ids = []
            // impacted_products = self.env['product.product']
            // products_orig_quantity_svl = {}
            // 
            // # get the impacted products
            // domain = [('is_storable', '=', True)]
            // if product_category is not None:
            //     domain += [('categ_id', '=', product_category.id)]
            // elif product_template is not None:
            //     domain += [('product_tmpl_id', '=', product_template.id)]
            // else:
            //     raise ValueError()
            // products = self.env['product.product'].search_read(domain, ['quantity_svl'])
            // for product in products:
            //     impacted_product_ids.append(product['id'])
            //     products_orig_quantity_svl[product['id']] = product['quantity_svl']
            // impacted_products |= self.env['product.product'].browse(impacted_product_ids)
            // 
            // # empty out the stock for the impacted products
            // empty_stock_svl_list = []
            // lots_by_product = defaultdict(lambda: self.env['stock.lot'])
            // res = self.env["stock.valuation.layer"]._read_group(
            //     [("product_id", "in", impacted_products.ids), ("remaining_qty", "!=", 0)],
            //     ["product_id"],
            //     ["lot_id:recordset"],
            // )
            // for group in res:
            //     lots_by_product[group[0].id] |= group[1]
            // for product in impacted_products:
            //     # FIXME sle: why not use products_orig_quantity_svl here?
            //     if float_is_zero(product.quantity_svl, precision_rounding=product.uom_id.rounding):
            //         # FIXME: create an empty layer to track the change?
            //         continue
            //     if product.lot_valuated:
            //         if float_compare(product.quantity_svl, 0, precision_rounding=product.uom_id.rounding) > 0:
            //             for lot in lots_by_product[product.id]:
            //                 svsl_vals = product._prepare_out_svl_vals(lot.quantity_svl, self.env.company, lot=lot)
            //                 svsl_vals['description'] = description + svsl_vals.pop('rounding_adjustment', '')
            //                 svsl_vals['company_id'] = self.env.company.id
            //                 empty_stock_svl_list.append(svsl_vals)
            //         else:
            //             for lot in lots_by_product[product.id]:
            //                 svsl_vals = product._prepare_in_svl_vals(abs(lot.quantity_svl), lot.value_svl / lot.quantity_svl, lot=lot)
            //                 svsl_vals['description'] = description + svsl_vals.pop('rounding_adjustment', '')
            //                 svsl_vals['company_id'] = self.env.company.id
            //                 empty_stock_svl_list.append(svsl_vals)
            //     else:
            //         if float_compare(product.quantity_svl, 0, precision_rounding=product.uom_id.rounding) > 0:
            //             svsl_vals = product._prepare_out_svl_vals(product.quantity_svl, self.env.company)
            //         else:
            //             svsl_vals = product._prepare_in_svl_vals(abs(product.quantity_svl), product.value_svl / product.quantity_svl)
            //         svsl_vals['description'] = description + svsl_vals.pop('rounding_adjustment', '')
            //         svsl_vals['company_id'] = self.env.company.id
            //         empty_stock_svl_list.append(svsl_vals)
            // return empty_stock_svl_list, products_orig_quantity_svl, impacted_products
            */
            return default;
        }

        protected async Task<ProductProduct> SvlReplenishStockAmInternalAsync(object stock_valuation_layers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _svl_replenish_stock_am(self, stock_valuation_layers):
            // move_vals_list = []
            // product_accounts = {product.id: product.product_tmpl_id.get_product_accounts() for product in stock_valuation_layers.mapped('product_id')}
            // for out_stock_valuation_layer in stock_valuation_layers:
            //     product = out_stock_valuation_layer.product_id
            //     if not product_accounts[product.id].get('stock_input'):
            //         raise UserError(_('You don\'t have any input valuation account defined on your product category. You must define one before processing this operation.'))
            //     if not product_accounts[product.id].get('stock_valuation'):
            //         raise UserError(_('You don\'t have any stock valuation account defined on your product category. You must define one before processing this operation.'))
            //     if not product_accounts[product.id].get('stock_output'):
            //         raise UserError(
            //             _('You don\'t have any output valuation account defined on your product '
            //               'category. You must define one before processing this operation.')
            //         )
            // 
            //     precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     if float_compare(out_stock_valuation_layer.quantity, 0, precision_digits=precision) == 1:
            //         debit_account_id = product_accounts[product.id]['stock_valuation'].id
            //         credit_account_id = product_accounts[product.id]['stock_input'].id
            //     else:
            //         debit_account_id = product_accounts[product.id]['stock_output'].id
            //         credit_account_id = product_accounts[product.id]['stock_valuation'].id
            // 
            //     value = out_stock_valuation_layer.value
            //     move_vals = {
            //         'journal_id': product_accounts[product.id]['stock_journal'].id,
            //         'company_id': self.env.company.id,
            //         'ref': product.default_code,
            //         'stock_valuation_layer_ids': [(6, None, [out_stock_valuation_layer.id])],
            //         'line_ids': [(0, 0, {
            //             'name': out_stock_valuation_layer.description,
            //             'account_id': debit_account_id,
            //             'debit': abs(value),
            //             'credit': 0,
            //             'product_id': product.id,
            //         }), (0, 0, {
            //             'name': out_stock_valuation_layer.description,
            //             'account_id': credit_account_id,
            //             'debit': 0,
            //             'credit': abs(value),
            //             'product_id': product.id,
            //         })],
            //         'move_type': 'entry',
            //     }
            //     move_vals_list.append(move_vals)
            // return move_vals_list
            */
            return default;
        }

        protected async Task<ProductProduct> SvlReplenishStockInternalAsync(object description, object products_orig_quantity_svl)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _svl_replenish_stock(self, description, products_orig_quantity_svl):
            // refill_stock_svl_list = []
            // lot_by_product = defaultdict(lambda: defaultdict(float))
            // neg_lots = self.env['stock.quant']._read_group([
            //     ('product_id', 'in', self.product_variant_ids.ids),
            //     ('lot_id', '!=', False),
            //     ], ['product_id', 'location_id', 'lot_id'], ['quantity:sum'],
            //     having=[('quantity:sum', '<', 0)])
            // lots = self.env['stock.quant']._read_group([
            //     ('product_id', 'in', self.product_variant_ids.ids),
            //     ('lot_id', '!=', False),
            //     ], ['product_id', 'location_id', 'lot_id'], ['quantity:sum'],
            //     having=[('quantity:sum', '>', 0)])
            // for product, location, lot, qty in lots:
            //     if location._should_be_valued():
            //         lot_by_product[product][lot] += qty
            // for product, location, lot, qty in neg_lots:
            //     if location._should_be_valued():
            //         raise UserError(_(
            //             "Lot %(lot)s has a negative quantity in stock.\n"
            //             "Correct this quantity before enabling/disabling lot valuation.",
            //             lot=lot.display_name
            //         ))
            // lot_valuated_products = self.filtered("lot_valuated")
            // if lot_valuated_products:
            //     no_lot_quants = self.env['stock.quant']._read_group([
            //         ('product_id', 'in', lot_valuated_products.ids),
            //         ('lot_id', '=', False),
            //         ('quantity', '!=', 0),
            //     ], ['product_id', 'location_id'])
            //     for product, location in no_lot_quants:
            //         if location._should_be_valued():
            //             raise UserError(_(
            //                 "Product %(product)s has quantity in valued location %(location)s without any lot.\n"
            //                 "Please assign lots to all your quantities before enabling lot valuation.",
            //                 product=product.display_name,
            //                 location=location.display_name
            //             ))
            // 
            // for product in self:
            //     quantity_svl = products_orig_quantity_svl[product.id]
            //     if not quantity_svl:
            //         continue
            //     rounding = product.uom_id.rounding
            //     price_unit = product.standard_price
            //     if not product.lot_valuated:
            //         lot_by_product[product] = {False: quantity_svl}
            //     for lot, qty in lot_by_product[product].items():
            //         if float_compare(quantity_svl, 0, precision_rounding=rounding) > 0:
            //             qty_to_remove = min(qty, quantity_svl)
            //             quantity_svl -= qty_to_remove
            //             svl_vals = product._prepare_in_svl_vals(qty_to_remove, price_unit, lot=lot)
            // 
            //         else:
            //             svl_vals = product._prepare_out_svl_vals(abs(quantity_svl), self.env.company, lot=lot)
            //         svl_vals['description'] = description
            //         svl_vals['company_id'] = self.env.company.id
            //         refill_stock_svl_list.append(svl_vals)
            //         if float_is_zero(quantity_svl, precision_rounding=rounding):
            //             break
            // return refill_stock_svl_list
            */
            return default;
        }

        public async Task<ProductProduct> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def toggle_active(self):
            // """ Archiving related product.template if there is not any more active product.product
            // (and vice versa, unarchiving the related product template if there is now an active product.product) """
            // result = super().toggle_active()
            // # We deactivate product templates which are active with no active variants.
            // tmpl_to_deactivate = self.filtered(lambda product: (product.product_tmpl_id.active
            //                                                     and not product.product_tmpl_id.product_variant_ids)).mapped('product_tmpl_id')
            // # We activate product templates which are inactive with active variants.
            // tmpl_to_activate = self.filtered(lambda product: (not product.product_tmpl_id.active
            //                                                   and product.product_tmpl_id.product_variant_ids)).mapped('product_tmpl_id')
            // (tmpl_to_deactivate + tmpl_to_activate).toggle_active()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _unlink_except_active_pos_session(self):
            // product_ctx = dict(self.env.context or {}, active_test=False)
            // if self.env['pos.session'].sudo().search_count([('state', '!=', 'closed')]):
            //     if self.with_context(product_ctx).search_count([('id', 'in', self.ids), ('product_tmpl_id.available_in_pos', '=', True)]):
            //         raise UserError(_(
            //             "To delete a product, make sure all point of sale sessions are closed.\n\n"
            //             "Deleting a product available in a session would be like attempting to snatch a hamburger from a customer’s hand mid-bite; chaos will ensue as ketchup and mayo go flying everywhere!",
            //         ))
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkExceptLoyaltyProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_product.py) ---
            // def _unlink_except_loyalty_products(self):
            // product_data = [
            //     self.env.ref('loyalty.gift_card_product_50', False),
            //     self.env.ref('loyalty.ewallet_product_50', False),
            // ]
            // for product in self.filtered(lambda p: p in product_data):
            //     raise UserError(_(
            //         "You cannot delete %(name)s as it is used in 'Coupons & Loyalty'."
            //         " Please archive it instead.",
            //         name=product.with_context(display_default_code=False).display_name
            //     ))
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def _unlink_except_master_data(self):
            // time_product = self.env.ref('sale_timesheet.time_product')
            // if time_product in self:
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkOrArchiveInternalAsync(object check_access)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _unlink_or_archive(self, check_access=True):
            // """Unlink or archive products.
            // Try in batch as much as possible because it is much faster.
            // Use dichotomy when an exception occurs.
            // """
            // 
            // # Avoid access errors in case the products is shared amongst companies
            // # but the underlying objects are not. If unlink fails because of an
            // # AccessError (e.g. while recomputing fields), the 'write' call will
            // # fail as well for the same reason since the field has been set to
            // # recompute.
            // if check_access:
            //     self.check_access('unlink')
            //     self.check_access('write')
            //     self = self.sudo()
            //     to_unlink = self._filter_to_unlink()
            //     to_archive = self - to_unlink
            //     to_archive.write({'active': False})
            //     self = to_unlink
            // 
            // try:
            //     with self.env.cr.savepoint(), tools.mute_logger('odoo.sql_db'):
            //         self.unlink()
            // except Exception:
            //     # We catch all kind of exceptions to be sure that the operation
            //     # doesn't fail.
            //     if len(self) > 1:
            //         self[:len(self) // 2]._unlink_or_archive(check_access=False)
            //         self[len(self) // 2:]._unlink_or_archive(check_access=False)
            //     else:
            //         if self.active:
            //             # Note: this can still fail if something is preventing
            //             # from archiving.
            //             # This is the case from existing stock reordering rules.
            //             self.write({'active': False})
            */
            return default;
        }

        protected async Task<ProductProduct> UpdateLotsStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _update_lots_standard_price(self):
            // grouped_lots = self.env['stock.lot']._read_group(
            //     [('product_id', 'in', self.ids), ('product_id.lot_valuated', '=', True)],
            //     ['product_id'], ['id:recordset']
            // )
            // for product, lots in grouped_lots:
            //     lots.with_context(disable_auto_svl=True).write({"standard_price": product.standard_price})
            */
            return default;
        }

        public async Task<ProductProduct> UpdateQuantityOnHandAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_update_quantity_on_hand(self):
            // return self.product_tmpl_id.with_context(default_product_id=self.id, create=True).action_update_quantity_on_hand()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> UsedInBomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_used_in_bom(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_bom_form_action")
            // action['domain'] = [('bom_line_ids.product_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewBomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_view_bom(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.product_open_bom")
            // template_ids = self.mapped('product_tmpl_id').ids
            // # bom specific to this variant or global to template or that contains the product as a byproduct
            // action['context'] = {
            //     'default_product_tmpl_id': template_ids[0],
            //     'default_product_id': self.env.user.has_group('product.group_product_variant') and self.ids[0] or False,
            // }
            // action['domain'] = ['|', '|', ('byproduct_ids.product_id', 'in', self.ids), ('product_id', 'in', self.ids), '&', ('product_id', '=', False), ('product_tmpl_id', 'in', template_ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewHeaderGetAsync(Guid id, ProductProductViewHeaderGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self._context.get('categ_id'):
            //     return _(
            //         'Products: %(category)s',
            //         category=self.env['product.category'].browse(self.env.context['categ_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def view_header_get(self, view_id, view_type):
            // res = super(Product, self).view_header_get(view_id, view_type)
            // if not res and self._context.get('active_id') and self._context.get('active_model') == 'stock.location':
            //     return _(
            //         'Products: %(location)s',
            //         location=self.env['stock.location'].browse(self._context['active_id']).name,
            //     )
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewMosAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_view_mos(self):
            // action = self.product_tmpl_id.action_view_mos()
            // action['domain'] = [('state', '=', 'done'), ('product_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewOrderpointsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_orderpoints(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_orderpoint")
            // action['context'] = literal_eval(action.get('context'))
            // action['context'].pop('search_default_trigger', False)
            // action['context'].update({
            //     'search_default_filter_not_snoozed': True,
            // })
            // if self and len(self) == 1:
            //     action['context'].update({
            //         'default_product_id': self.ids[0],
            //         'search_default_product_id': self.ids[0]
            //     })
            // else:
            //     action['domain'] = expression.AND([action.get('domain') or [], [('product_id', 'in', self.ids)]])
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewPoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def action_view_po(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = ['&', ('state', 'in', ['purchase', 'done']), ('product_id', 'in', self.ids)]
            // action['display_name'] = _("Purchase History for %s", self.display_name)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewRelatedPutawayRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_related_putaway_rules(self):
            // self.ensure_one()
            // domain = [
            //     '|',
            //         ('product_id', '=', self.id),
            //         ('category_id', '=', self.product_tmpl_id.categ_id.id),
            // ]
            // return self.env['product.template']._get_action_view_related_putaway_rules(domain)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_routes(self):
            // return self.mapped('product_tmpl_id').action_view_routes()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewSalesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def action_view_sales(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.report_all_channels_sales_action")
            // action['domain'] = [('product_id', 'in', self.ids)]
            // action['context'] = {
            //     'pivot_measures': ['product_uom_qty'],
            //     'active_id': self._context.get('active_id'),
            //     'search_default_Sales': 1,
            //     'active_model': 'sale.report',
            //     'search_default_filter_order_date': 1,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewStockMoveLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_stock_move_lines(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_move_line_action")
            // action['domain'] = [('product_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> ViewStorageCategoryCapacityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_storage_category_capacity(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_storage_category_capacity")
            // action['context'] = {
            //     'hide_package_type': True,
            // }
            // if len(self) == 1:
            //     action['context'].update({
            //         'default_product_id': self.id,
            //     })
            // action['domain'] = [('product_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductProduct> WebsitePublishButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def website_publish_button(self):
            // self.ensure_one()
            // return self.product_tmpl_id.website_publish_button()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> WebsiteShowQuickAddInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _website_show_quick_add(self):
            // self.ensure_one()
            // # TODO VFE pass website as param and avoid existence check
            // website = self.env['website'].get_current_website()
            // return self.sale_ok and (not website.prevent_zero_price_sale or self._get_contextual_price())
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _website_show_quick_add(self):
            // return (self.allow_out_of_stock_order or not self._is_sold_out()) and super()._website_show_quick_add()
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProductProduct entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_product.py) ---
            // def write(self, vals):
            // result = super().write(vals)
            // if 'standard_price' in vals:
            //     expenses_sudo = self.env['hr.expense'].sudo().search([
            //         ('company_id', '=', self.env.company.id),
            //         ('product_id', 'in', self.ids),
            //         ('state', 'in', ['reported', 'draft']),
            //     ])
            //     for expense_sudo in expenses_sudo:
            //         expense_product_sudo = expense_sudo.product_id
            //         tax_domain = self.env['account.tax']._check_company_domain(expense_sudo.company_id)
            //         product_has_cost = (
            //                 expense_product_sudo
            //                 and not expense_sudo.company_currency_id.is_zero(expense_product_sudo.standard_price)
            //         )
            //         expense_vals = {
            //             'product_has_cost': product_has_cost,
            //             'product_has_tax': bool(expense_product_sudo.supplier_taxes_id.filtered_domain(tax_domain)),
            //         }
            //         if product_has_cost:
            //             expense_vals.update({
            //                 'price_unit': expense_product_sudo.standard_price,
            //             })
            //         else:
            //             expense_vals.update({
            //                 'quantity': 1,
            //                 'price_unit': expense_sudo.total_amount
            //             })
            //         expense_sudo.write(expense_vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_product.py) ---
            // def write(self, vals):
            // if not vals.get('active', True) and any(product.active for product in self):
            //     # Prevent archiving products used for giving rewards
            //     rewards = self.env['loyalty.reward'].sudo().search([
            //         ('active', '=', True),
            //         '|',
            //         ('discount_line_product_id', 'in', self.ids),
            //         ('discount_product_ids', 'in', self.ids),
            //     ], limit=1)
            //     if rewards:
            //         raise ValidationError(_("This product may not be archived. It is being used for an active promotion program."))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def write(self, values):
            // if 'active' in values:
            //     self.filtered(lambda p: p.active != values['active']).with_context(active_test=False).variant_bom_ids.write({
            //         'active': values['active']
            //     })
            // return super().write(values)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def write(self, vals_list):
            // res = super().write(vals_list)
            // if 'self_order_available' in vals_list:
            //     for record in self:
            //         record._send_availability_status()
            // return res
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def write(self, values):
            // res = super(ProductProduct, self).write(values)
            // if 'product_template_attribute_value_ids' in values:
            //     # `_get_variant_id_for_combination` depends on `product_template_attribute_value_ids`
            //     self.env.registry.clear_cache()
            // elif 'active' in values:
            //     # `_get_first_possible_variant_id` depends on variants active state
            //     self.env.registry.clear_cache()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_product.py) ---
            // def write(self, vals):
            // if 'type' in vals and vals['type'] != 'service':
            //     vals.update({
            //         'service_tracking': 'no',
            //         'project_id': False
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py) ---
            // def write(self, vals):
            // # timesheet product can't be archived
            // test_mode = getattr(threading.current_thread(), 'testing', False) or self.env.registry.in_test_mode()
            // if not test_mode and 'active' in vals and not vals['active']:
            //     time_product = self.env.ref('sale_timesheet.time_product')
            //     if time_product in self:
            //         raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def write(self, values):
            // if 'active' in values:
            //     self.filtered(lambda p: p.active != values['active']).with_context(active_test=False).orderpoint_ids.write({
            //         'active': values['active']
            //     })
            // return super().write(values)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def write(self, vals):
            // if 'standard_price' in vals and not self.env.context.get('disable_auto_svl'):
            //     self.filtered(lambda p: p.cost_method != 'fifo')._change_standard_price(vals['standard_price'])
            // if 'lot_valuated' in vals:
            //     # lot_valuated must be updated from the ProductTemplate
            //     self.product_tmpl_id.write({'lot_valuated': vals.pop('lot_valuated')})
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}