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
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public class ProductProductAppService : GenericApplicationService<ProductProduct>, IProductProductAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductProductAppService(IRepository<ProductProduct, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
            // def action_archive(self):
            // self.product_tmpl_id._ensure_unused_in_pos()
            // return super().action_archive()
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def action_archive(self):
            // records = self.filtered('active')
            // super().action_archive()
            // # We deactivate product templates which are active with no active variants.
            // records.product_tmpl_id.filtered(
            //     lambda product_tmpl: product_tmpl.active and not product_tmpl.product_variant_ids
            // ).action_archive()
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

        protected async Task<ProductProduct> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if field_name == "image_128" and self.sudo().available_in_pos:
            //     return True
            // return super()._can_return_content(field_name, access_token)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if field_name == "image_512" and self.sudo().self_order_available:
            //     return True
            // return super()._can_return_content(field_name, access_token)
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: product.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // """ Override of `orm` to give public users access to the unpublished product image.
            // 
            // Give access to the public users to the unpublished product images if they are linked to an
            // event ticket.
            // 
            // :param field_name: The name of the field to check.
            // :param access_token: The access token.
            // :return: Whether to allow the access to the image.
            // :rtype: bool
            // """
            // if (
            //     field_name in ["image_%s" % size for size in [1920, 1024, 512, 256, 128]]
            //     and self.sudo().event_ticket_ids
            // ):
            //     return True
            // return super()._can_return_content(field_name, access_token)
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: product_product.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // """ Override of `orm` to give public users access to the unpublished product image.
            // 
            // Give access to the public users to the unpublished product images if they are linked to a
            // reward.
            // 
            // :param field_name: The name of the field to check.
            // :param access_token: The access token.
            // :return: Whether to allow the access to the image.
            // :rtype: bool
            // """
            // if (
            //     field_name in ["image_%s" % size for size in [1920, 1024, 512, 256, 128]]
            //     and self.env['loyalty.reward'].sudo().search_count([
            //         ('discount_line_product_id', '=', self.id),
            //     ], limit=1)
            // ):
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        protected async Task<ProductProduct> ChangeStandardPriceInternalAsync(object old_price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _change_standard_price(self, old_price):
            // for product in self:
            //     if product.cost_method == 'fifo' or product.standard_price == old_price.get(product):
            //         continue
            //     self.env['product.value'].sudo().create({
            //         'product_id': product.id,
            //         'value': product.standard_price,
            //         'company_id': product.company_id.id or self.env.company.id,
            //         'date': fields.Datetime.now(),
            //         'description': _('Price update from %(old_price)s to %(new_price)s by %(user)s',
            //             old_price=old_price.get(product), new_price=product.standard_price, user=self.env.user.name)
            //     })
            // return
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
            // self_ctx = self.with_context(skip_preprocess_gs1=True)
            // for company_id, barcodes_within_company in self_ctx._get_barcodes_by_company():
            //     self_ctx._check_duplicated_product_barcodes(barcodes_within_company, company_id)
            //     self_ctx._check_duplicated_packaging_barcodes(barcodes_within_company, company_id)
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
            // if self.env['product.uom'].sudo().search_count(packaging_domain, limit=1):
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
            // products_by_barcode = self.sudo()._read_group(
            //     domain, ['barcode'], ['id:recordset'], having=[('__count', '>', 1)],
            // )
            // 
            // duplicates_as_str = "\n".join(
            //     self.env._(
            //         "- Barcode \"%(barcode)s\" already assigned to product(s): %(product_list)s",
            //         barcode=barcode, product_list=duplicate_products._filtered_access('read').mapped('display_name'),
            //     )
            //     for barcode, duplicate_products in products_by_barcode
            // )
            // if duplicates_as_str:
            //     duplicates_as_str += _(
            //         "\n\nNote: products that you don't have access to will not be shown above."
            //     )
            //     raise ValidationError(_("Barcode(s) already assigned:\n\n%s", duplicates_as_str))
            */
            return default;
        }

        protected async Task<ProductProduct> CheckEventTicketServiceTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: product_product.py) ---
            // def _check_event_ticket_service_tracking(self):
            // if any(product.service_tracking != 'event' for product in self if product.event_ticket_ids):
            //     service_tracking = self.fields_get(['service_tracking'], ['string', 'selection'])['service_tracking']
            //     raise ValidationError(_(
            //         'Products linked to an event ticket must have "%(tracking)s" set to "%(event)s".',
            //         tracking=service_tracking['string'],
            //         event=dict(service_tracking['selection'])['event'],
            //     ))
            */
            return default;
        }

        protected async Task<ProductProduct> CheckServiceTrackingForEventBoothsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_product.py) ---
            // def _check_service_tracking_for_event_booths(self):
            // if product_not_event_booth := self.filtered(lambda p: p.service_tracking != 'event_booth'):
            //     booth_category = self.env['event.booth.category'].search([('product_id', 'in', product_not_event_booth.ids)], limit=1)
            //     if booth_category:
            //         raise ValidationError(
            //             _(
            //                 "You cannot change the service_tracking of the product %(product_name)s because it is already assigned "
            //                 "to %(booth_category_name)s. The service_tracking must remain 'event_booth'.",
            //                 product_name=product_not_event_booth.name,
            //                 booth_category_name=booth_category.name,
            //             )
            //         )
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
            //     product.bom_count = self.env['mrp.bom'].search_count([
            //         '|', '|', ('byproduct_ids.product_id', 'in', product.ids), ('product_id', 'in', product.ids),
            //         '&', ('product_id', '=', False), ('product_tmpl_id', 'in', product.product_tmpl_id.ids),
            //     ])
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
            //     total += opt.cost
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
            // return 0.0
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: product_product.py) ---
            // def _compute_bom_price(self, bom, boms_to_recompute=False, byproduct_bom=False):
            // """ Add the price of the subcontracting supplier if it exists with the bom configuration.
            // """
            // price = super()._compute_bom_price(bom, boms_to_recompute, byproduct_bom)
            // if bom and bom.type == 'subcontract':
            //     seller = self._select_seller(quantity=bom.product_qty, uom_id=bom.product_uom_id, params={'subcontractor_ids': bom.subcontractor_ids})
            //     if seller:
            //         seller_price = seller.currency_id._convert(seller.price, self.env.company.currency_id, (bom.company_id or self.env.company), fields.Date.today())
            //         price += seller.product_uom_id._compute_price(seller_price, self.uom_id)
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
            //     if self.env.context.get('display_default_code', True) and code:
            //         if self.env.context.get('formatted_display_name'):
            //             return f'{name}\t--{code}--'
            //         return f'[{code}] {name}'
            //     return name
            // 
            // partner_id = self.env.context.get('partner_id')
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

        protected async Task<ProductProduct> ComputeMonthlyDemandInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_monthly_demand(self):
            // based_on = self.env.context.get("suggest_based_on", "30_days")
            // start_date, limit_date = self._get_monthly_demand_range(based_on)
            // 
            // move_domain = Domain([
            //     ('product_id', 'in', self.ids),
            //     ('state', 'in', ['assigned', 'confirmed', 'partially_available', 'done']),
            //     ('date', '>=', start_date),
            //     ('date', '<', limit_date),
            // ])
            // move_domain = Domain.AND([
            //     move_domain,
            //     self._get_monthly_demand_moves_location_domain(),
            // ])
            // 
            // move_qty_by_products = self.env['stock.move']._read_group(move_domain, ['product_id'], ['product_qty:sum'])
            // qty_by_product = {product.id: qty for product, qty in move_qty_by_products}
            // 
            // factor = 1
            // if based_on == "one_year":
            //     factor = 12
            // elif based_on == "three_months" or based_on == "last_year_quarter":
            //     factor = 3
            // elif based_on == "one_week":
            //     factor = 7 / (365.25 / 12)  # 7 days / (365.25 days/yr / 12 mth/yr) = 0.23 months
            // for product in self:
            //     product.monthly_demand = qty_by_product.get(product.id, 0) / factor
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeMrpProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // date_from = fields.Datetime.to_string(fields.Datetime.now() - timedelta(days=365))
            // #TODO: state = done?
            // domain = [('state', '=', 'done'), ('product_id', 'in', self.ids), ('date_start', '>', date_from)]
            // read_group_res = self.env['mrp.production']._read_group(domain, ['product_id'], ['product_uom_qty:sum'])
            // mapped_data = {product.id: qty for product, qty in read_group_res}
            // for product in self:
            //     if not product.id:
            //         product.mrp_product_qty = 0.0
            //         continue
            //     product.mrp_product_qty = product.uom_id.round(mapped_data.get(product.id, 0))
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
            //         if supplier_info.partner_id.id == product.env.context.get('partner_id'):
            //             product_name = supplier_info.product_name or product.default_code or product.name
            //             product.partner_ref = '%s%s' % (product.code and '[%s] ' % product.code or '', product_name)
            //             break
            //     else:
            //         product.partner_ref = product.display_name
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePricelistRuleIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _compute_pricelist_rule_ids(self):
            // for product in self:
            //     if not product.id:
            //         product.pricelist_rule_ids = False
            //         continue
            //     product.pricelist_rule_ids = product.product_tmpl_id.pricelist_rule_ids.filtered(
            //         lambda rule: rule.product_id <= product,
            //     )
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
            //             if supplier_info.partner_id.id == product.env.context.get('partner_id'):
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
            //         ('res_id', 'in', product.ids),
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
            // if 'uom' in self.env.context:
            //     to_uom = self.env['uom.uom'].browse(self.env.context['uom'])
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
            // if not self.ids:
            //     for field_name, field in self._fields.items():
            //         if field.compute == '_compute_product_margin_fields_values':
            //             self[field_name] = False
            //     return
            // 
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
            // for product_id, avg, qty, total, _dummy in self.env.cr.fetchall():
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

        protected async Task<ProductProduct> ComputeProductWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _compute_product_website_url(self):
            // for product in self:
            //     url = product.product_tmpl_id.website_url
            //     if pavs := product.product_template_attribute_value_ids.product_attribute_value_id:
            //         pav_ids = [str(pav.id) for pav in pavs]
            //         url = f'{url}?attribute_values={",".join(pav_ids)}'
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
            //     ('order_id.state', '=', 'purchase'),
            //     ('product_id', 'in', self.ids),
            //     ('order_id.date_approve', '>=', date_from)
            // ]
            // order_lines = self.env['purchase.order.line']._read_group(domain, ['product_id'], ['product_uom_qty:sum'])
            // purchased_data = {product.id: qty for product, qty in order_lines}
            // for product in self:
            //     if not product.id:
            //         product.purchased_product_qty = 0.0
            //         continue
            //     product.purchased_product_qty = product.uom_id.round(purchased_data.get(product.id, 0))
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
            //             if not component.is_storable or bom_line.product_uom_id.is_zero(bom_line_data['qty']):
            //                 # As BoMs allow components with 0 qty, a.k.a. optionnal components, we simply skip those
            //                 # to avoid a division by zero. The same logic is applied to non-storable products as those
            //                 # products have 0 qty available.
            //                 continue
            //             uom_qty_per_kit = bom_line_data['qty'] / bom_line_data['original_qty']
            //             qty_per_kit += bom_line.product_uom_id._compute_quantity(uom_qty_per_kit, bom_line.product_id.uom_id, round=False, raise_if_failure=False)
            //         if not qty_per_kit:
            //             continue
            //         component_res = (
            //             qties.get(component.id)
            //             if component.id in qties
            //             else {
            //                 "virtual_available": component.uom_id.round(component.virtual_available),
            //                 "qty_available": component.uom_id.round(component.qty_available),
            //                 "incoming_qty": component.uom_id.round(component.incoming_qty),
            //                 "outgoing_qty": component.uom_id.round(component.outgoing_qty),
            //                 "free_qty": component.uom_id.round(component.free_qty),
            //             }
            //         )
            //         ratios_virtual_available.append(component.uom_id.round(component_res["virtual_available"] / qty_per_kit, rounding_method='DOWN'))
            //         ratios_qty_available.append(component.uom_id.round(component_res["qty_available"] / qty_per_kit, rounding_method='DOWN'))
            //         ratios_incoming_qty.append(component.uom_id.round(component_res["incoming_qty"] / qty_per_kit, rounding_method='DOWN'))
            //         ratios_outgoing_qty.append(component.uom_id.round(component_res["outgoing_qty"] / qty_per_kit, rounding_method='DOWN'))
            //         ratios_free_qty.append(component.uom_id.round(component_res["free_qty"] / qty_per_kit, rounding_method='DOWN'))
            //     if bom_sub_lines and ratios_virtual_available:  # Guard against all cnsumable bom: at least one ratio should be present.
            //         res[product.id] = {
            //             'virtual_available': component.uom_id.round(min(ratios_virtual_available) * bom_kits[product].product_qty) // 1,
            //             'qty_available': component.uom_id.round(min(ratios_qty_available) * bom_kits[product].product_qty) // 1,
            //             'incoming_qty': component.uom_id.round(min(ratios_incoming_qty) * bom_kits[product].product_qty) // 1,
            //             'outgoing_qty': component.uom_id.round(min(ratios_outgoing_qty) * bom_kits[product].product_qty) // 1,
            //             'free_qty': component.uom_id.round(min(ratios_free_qty) * bom_kits[product].product_qty) // 1,
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
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: product_product.py) ---
            // def _compute_quantities_dict(self, lot_id, owner_id, package_id, from_date=False, to_date=False):
            // return super(ProductProduct, self.with_context(with_expiration=datetime.date.today()))._compute_quantities_dict(lot_id, owner_id, package_id, from_date, to_date)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_quantities_dict(self, lot_id, owner_id, package_id, from_date=False, to_date=False):
            // if self.env.context.get("suggest_based_on") and "suggest_days" in self.env.context:
            //     # Override to compute actual demand suggestion and update forecast on Kanban card
            //     to_date = fields.Datetime.now() + relativedelta(days=self.env.context.get("suggest_days"))
            // return super()._compute_quantities_dict(
            //     lot_id=lot_id,
            //     owner_id=owner_id,
            //     package_id=package_id,
            //     from_date=from_date,  # Keeping default which fetches all past deliveries
            //     to_date=to_date,
            // )
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
            // if 'owners' in self.env.context:
            //     owners = self.env.context['owners']
            //     if owners:
            //         domain_quant += [('owner_id', 'in', self.env.context['owners'])]
            //     else:
            //         domain_quant += [('owner_id', '=', False)]
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
            // Move = self.env['stock.move'].with_context(active_test=False)
            // Quant = self.env['stock.quant'].with_context(active_test=False)
            // domain_move_in_todo = [('state', 'in', ('waiting', 'confirmed', 'assigned', 'partially_available'))] + domain_move_in
            // domain_move_out_todo = [('state', 'in', ('waiting', 'confirmed', 'assigned', 'partially_available'))] + domain_move_out
            // moves_in_res = {product.id: product_qty for product, product_qty in Move._read_group(domain_move_in_todo, ['product_id'], ['product_qty:sum'])}
            // moves_out_res = {product.id: product_qty for product, product_qty in Move._read_group(domain_move_out_todo, ['product_id'], ['product_qty:sum'])}
            // quants_res = {product.id: (quantity, reserved_quantity) for product, quantity, reserved_quantity in Quant._read_group(domain_quant, ['product_id'], ['quantity:sum', 'reserved_quantity:sum'])}
            // expired_unreserved_quants_res = {}
            // if self.env.context.get('with_expiration'):
            //     max_date = self.env.context['to_date'] if self.env.context.get('to_date') else self.env.context['with_expiration']
            //     domain_quant += [('removal_date', '<=', max_date)]
            //     expired_unreserved_quants_res = {product.id: quantity - reserved_quantity for product, quantity, reserved_quantity in Quant._read_group(domain_quant, ['product_id'], ['quantity:sum', 'reserved_quantity:sum'])}
            // moves_in_res_past = defaultdict(float)
            // moves_out_res_past = defaultdict(float)
            // if dates_in_the_past:
            //     # Calculate the moves that were done before now to calculate back in time (as most questions will be recent ones)
            //     domain_move_in_done = [('state', '=', 'done'), ('date', '>', to_date)] + domain_move_in_done
            //     domain_move_out_done = [('state', '=', 'done'), ('date', '>', to_date)] + domain_move_out_done
            // 
            //     groupby = ['product_id', 'product_uom']
            //     for product, uom, quantity in Move._read_group(domain_move_in_done, groupby, ['quantity:sum']):
            //         moves_in_res_past[product.id] += uom._compute_quantity(quantity, product.uom_id)
            // 
            //     for product, uom, quantity in Move._read_group(domain_move_out_done, groupby, ['quantity:sum']):
            //         moves_out_res_past[product.id] += uom._compute_quantity(quantity, product.uom_id)
            // 
            // res = dict()
            // for product in self.with_context(prefetch_fields=False):
            //     origin_product_id = product._origin.id
            //     product_id = product.id
            //     if not origin_product_id or (
            //         origin_product_id not in quants_res
            //         and origin_product_id not in moves_in_res
            //         and origin_product_id not in moves_out_res
            //         and origin_product_id not in moves_in_res_past
            //         and origin_product_id not in moves_out_res_past
            //         and origin_product_id not in expired_unreserved_quants_res
            //     ):
            //         res[product_id] = dict.fromkeys(
            //             ['qty_available', 'free_qty', 'incoming_qty', 'outgoing_qty', 'virtual_available'],
            //             0.0,
            //         )
            //         continue
            //     res[product_id] = {}
            //     if dates_in_the_past:
            //         qty_available = quants_res.get(origin_product_id, [0.0])[0] - moves_in_res_past.get(origin_product_id, 0.0) + moves_out_res_past.get(origin_product_id, 0.0)
            //     else:
            //         qty_available = quants_res.get(origin_product_id, [0.0])[0]
            //     reserved_quantity = quants_res.get(origin_product_id, [False, 0.0])[1]
            //     expired_unreserved_qty = expired_unreserved_quants_res.get(origin_product_id, 0.0)
            //     res[product_id]['qty_available'] = product.uom_id.round(qty_available)
            //     res[product_id]['free_qty'] = product.uom_id.round(qty_available - reserved_quantity - expired_unreserved_qty)
            //     res[product_id]['incoming_qty'] = product.uom_id.round(moves_in_res.get(origin_product_id, 0.0))
            //     res[product_id]['outgoing_qty'] = product.uom_id.round(moves_out_res.get(origin_product_id, 0.0))
            //     res[product_id]['virtual_available'] = product.uom_id.round(
            //         qty_available + res[product_id]['incoming_qty'] - res[product_id]['outgoing_qty'] - expired_unreserved_qty,
            //     )
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeQuantitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // return super()._compute_quantities()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // products = self.with_context(prefetch_fields=False).filtered(lambda p: p.type != 'service').with_context(prefetch_fields=True)
            // res = products._compute_quantities_dict(self.env.context.get('lot_id'), self.env.context.get('owner_id'), self.env.context.get('package_id'), self.env.context.get('from_date'), self.env.context.get('to_date'))
            // # Set qty fields to 0 for all products as services have 0 quantities. Also skips calling __setitem__ on products with 0 quantites in res.
            // self.with_context(skip_qty_available_update=True).qty_available = 0.0
            // self.incoming_qty = 0.0
            // self.outgoing_qty = 0.0
            // self.virtual_available = 0.0
            // self.free_qty = 0.0
            // for product in products:
            //     product.with_context(skip_qty_available_update=True).update({key: val for key, val in res[product.id].items() if val})
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
            // date_from = fields.Date.today() - timedelta(days=365)
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
            //     product.sales_count = product.uom_id.round(r.get(product.id, 0))
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

        protected async Task<ProductProduct> ComputeShowQtyUpdateButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_update_button(self):
            // for product in self:
            //     product.show_qty_update_button = product.product_tmpl_id._should_open_product_quants()
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeStandardPriceUpdateWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_product.py) ---
            // def _compute_standard_price_update_warning(self):
            // undone_expenses = self.env['hr.expense']._read_group(
            //     domain=[('state', '=', 'draft'), ('product_id', 'in', self.ids)],
            //     groupby=['price_unit'],
            //     )
            // # The following list is composed of all the price_units of expenses that use this product and should NOT trigger a warning.
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

        protected async Task<ProductProduct> ComputeSuggestEstimatedPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_suggest_estimated_price(self):
            // seller_args = {
            //     "partner_id": self.env['res.partner'].browse(self.env.context.get("partner_id")),
            //     "params": {'order_id': self.env['purchase.order'].browse(self.env.context.get("order_id"))}
            // }
            // self.suggest_estimated_price = 0.0
            // for product in self:
            //     if product.suggested_qty <= 0:
            //         continue
            //     # Get lowest price pricelist for suggested_qty or lowest min_qty pricelist
            //     seller = product._select_seller(quantity=product.suggested_qty, **seller_args) or \
            //              product._select_seller(quantity=None, ordered_by="min_qty", **seller_args)
            // 
            //     price = seller.price_discounted if seller else product.standard_price
            //     product.suggest_estimated_price = price * product.suggested_qty
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeSuggestedQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_suggested_quantity(self):
            // ctx = self.env.context
            // self.suggested_qty = 0
            // if ctx.get("suggest_based_on") == "actual_demand":
            //     for product in self:
            //         if product.virtual_available >= 0:
            //             continue
            //         qty = - product.virtual_available * ctx.get("suggest_percent", 0) / 100
            //         product.suggested_qty = max(float_round(qty, precision_digits=0, rounding_method="UP"), 0)
            // elif ctx.get("suggest_based_on"):
            //     for product in self:
            //         if product.monthly_demand <= 0:
            //             continue
            //         monthly_ratio = ctx.get("suggest_days", 0) / (365.25 / 12)  # eg. 7 days / (365.25 days/yr / 12 mth/yr) = 0.23 months
            //         qty = product.monthly_demand * monthly_ratio * ctx.get("suggest_percent", 0) / 100
            //         qty -= max(product.qty_available, 0) + max(product.incoming_qty, 0)
            //         product.suggested_qty = max(float_round(qty, precision_digits=0, rounding_method="UP"), 0)
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
            //     product.used_in_bom_count = self.env['mrp.bom'].search_count(
            //         [('bom_line_ids.product_id', 'in', product.ids)])
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

        protected async Task<ProductProduct> ComputeValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_value(self):
            // """Compute totals of multiple svl related values"""
            // company_id = self.env.company
            // self.company_currency_id = company_id.currency_id
            // 
            // for product in self:
            //     at_date = fields.Datetime.to_datetime(product.env.context.get('to_date'))
            //     if at_date:
            //         at_date = at_date.replace(hour=23, minute=59, second=59)
            //         product = product.with_context(at_date=at_date)
            //     valuated_product = product.sudo(False)._with_valuation_context()
            //     qty_valued = valuated_product.qty_available
            //     qty_available = valuated_product.with_context(warehouse_id=False).qty_available if self.env.context.get('warehouse_id') else qty_valued
            //     if product.lot_valuated:
            //         product.total_value = product._get_value_from_lots()
            //     elif product.uom_id.is_zero(qty_valued):
            //         product.total_value = 0
            //     elif product.uom_id.is_zero(qty_available):
            //         product.total_value = product.standard_price * qty_valued
            //     elif product.cost_method == 'standard':
            //         standard_price = product.standard_price
            //         if at_date:
            //             standard_price = product._get_standard_price_at_date(at_date)
            //         product.total_value = standard_price * qty_valued
            //     elif product.cost_method == 'average':
            //         product.total_value = product._run_avco(at_date=at_date)[1] * qty_valued / qty_available
            //     else:
            //         product.total_value = product.with_context(warehouse_id=False)._run_fifo(qty_available, at_date=at_date) * qty_valued / qty_available
            //     product.avg_cost = product.total_value / qty_valued if not product.uom_id.is_zero(qty_valued) else 0
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
            // now = self.env.cr.now()
            // for record in self:
            //     if not record.id:
            //         record.write_date = record._origin.write_date
            //         continue
            //     record.write_date = max(
            //         record.write_date or now, record.product_tmpl_id.write_date or now
            //     )
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
            // return Domain([
            //     ('lot_id', '=', sn_lot.id),
            //     ('quantity', '=', 1),
            //     ('state', '=', 'done'),
            // ]) & Domain.OR(or_domains)
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

        public override async Task<ProductProduct> CreateAsync(ProductProduct entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def create(self, vals_list):
            // products = super(ProductProduct, self.with_context(create_product_product=False)).create(vals_list)
            // # `_get_variant_id_for_combination` depends on existing variants
            // self.env.registry.clear_cache()
            // return products
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def create(self, vals_list):
            // products = super().create(vals_list)
            // products._change_standard_price({product: 0 for product in products if product.standard_price})
            // return products
            */
            return await base.CreateAsync(entity, fields);
        }

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // res = super().fields_get(allfields, attributes)
            // context_location = self.env.context.get('location') or self.env.context.get('search_location')
            // if context_location and isinstance(context_location, int):
            //     location = self.env['stock.location'].browse(context_location)
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
            // def _filter_applicable_attributes(self, attributes_by_ptal_id: dict) -> list[dict]:
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
            // def _filter_to_unlink(self):
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
            // return super(ProductProduct, self - self.browse(linked_product_ids))._filter_to_unlink()
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
            //     'date_planned': date,
            //     'date_order': date - relativedelta(days=delays['purchase_delay']),
            // }
            */
            return default;
        }

        protected async Task<ProductProduct> GetDescriptionInternalAsync(Guid picking_type_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_description(self, picking_type_id):
            // """
            //     Return product description based on the picking type:
            //     * For outgoing pickings, we always use the product name.
            //     * For all other pickings, we try to use the product description (if one has been set),
            //       otherwise we fall back to the product name.
            // """
            // self.ensure_one()
            // if picking_type_id.code == 'outgoing':
            //     return self.display_name
            // return html2plaintext(self.description) if not is_html_empty(self.description) else self.display_name
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: product.py) ---
            // def _get_description(self, picking_type_id):
            // if picking_type_id.code == 'dropship':
            //     return self.description_pickingout or self.display_name
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
            //             domains.append(Domain(self.env[model]._rec_name, 'ilike', item))
            //     if domains:
            //         ids |= set(self.env[model].search(Domain.OR(domains)).ids)
            //     return ids
            // 
            // # We may receive a location or warehouse from the context, either by explicit
            // # python code or by the use of dummy fields in the search view.
            // # Normalize them into a list.
            // location = self.env.context.get('location') or self.env.context.get('search_location')
            // if location and not isinstance(location, list):
            //     location = [location]
            // warehouse = self.env.context.get('warehouse_id') or self.env.context.get('search_warehouse')
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
            // def _get_domain_locations_new(self, location_ids) -> tuple[Domain, Domain, Domain]:
            // if not location_ids:
            //     return (Domain.FALSE,) * 3
            // locations = self.env['stock.location'].browse(location_ids)
            // # TDE FIXME: should move the support of child_of + bypass_search_access directly in expression
            // # this optimizes [('location_id', 'child_of', locations.ids)]
            // # by avoiding the ORM to search for children locations and injecting a
            // # lot of location ids into the main query
            // if self.env.context.get('strict'):
            //     loc_domain = Domain('location_id', 'in', locations.ids)
            //     dest_loc_domain = Domain('location_dest_id', 'in', locations.ids)
            //     dest_loc_domain_out = Domain('location_dest_id', 'not in', locations.ids)
            // elif locations:
            //     alias = locations._table + '_inner'
            //     paths_query = Query(locations.env, alias, SQL.identifier(locations._table))
            //     paths_query.add_where(alias + '.parent_path LIKE ANY(%s)', [[loc.parent_path + '%' for loc in locations]])
            //     loc_domain = Domain('location_id', 'in', paths_query)
            //     # The condition should be split for done and not-done moves as the final_dest_id only make sense
            //     # for the part of the move chain that is not done yet.
            //     dest_loc_domain_done = Domain('location_dest_id', 'in', paths_query)
            //     dest_loc_domain_in_progress = Domain([
            //         '|',
            //             '&', ('location_final_id', '!=', False), ('location_final_id', 'in', paths_query),
            //             '&', ('location_final_id', '=', False), ('location_dest_id', 'in', paths_query),
            //     ])
            //     dest_loc_domain = Domain([
            //         '|',
            //             '&', ('state', '=', 'done'), dest_loc_domain_done,
            //             '&', ('state', '!=', 'done'), dest_loc_domain_in_progress,
            //     ])
            //     dest_loc_domain_out = Domain([
            //         '|',
            //             '&', ('state', '=', 'done'), ~dest_loc_domain_done,
            //             '&', ('state', '!=', 'done'), ~dest_loc_domain_in_progress,
            //     ])
            // 
            // # returns: (domain_quant_loc, domain_move_in_loc, domain_move_out_loc)
            // return (
            //     loc_domain,
            //     dest_loc_domain & ~loc_domain,
            //     loc_domain & dest_loc_domain_out,
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

        protected async Task<ProductProduct> GetExtraImage1920UrlsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _get_extra_image_1920_urls(self):
            // """ Returns the local url of the product additional images, no videos. This includes the
            // variant specific images first and then the template images.
            // 
            // Note: self.ensure_one()
            // 
            // :rtype: list[str]
            // """
            // self.ensure_one()
            // return [
            //     self.env['website'].image_url(extra_image, 'image_1920')
            //     for extra_image in self.product_variant_image_ids + self.product_template_image_ids
            //     if extra_image.image_128  # only images, no video urls
            // ]
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
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // 
            // sellers_filtered = self._prepare_sellers(params)
            // sellers = self.env['product.supplierinfo']
            // for seller in sellers_filtered:
            //     # Set quantity in UoM of seller
            //     quantity_uom_seller = quantity
            //     if quantity_uom_seller and uom_id and uom_id != seller.product_uom_id:
            //         quantity_uom_seller = uom_id._compute_quantity(quantity_uom_seller, seller.product_uom_id)
            // 
            //     if seller.date_start and seller.date_start > date:
            //         continue
            //     if seller.date_end and seller.date_end < date:
            //         continue
            //     if params and params.get('force_uom') and seller.product_uom_id != uom_id and seller.product_uom_id != self.uom_id:
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

        protected async Task<ProductProduct> GetImage1024UrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_comparison, FILE: product_product.py) ---
            // def _get_image_1024_url(self):
            // """ Returns the local url of the product main image.
            // Note: self.ensure_one()
            // :rtype: str
            // """
            // self.ensure_one()
            // return self.env['website'].image_url(self, 'image_1024')
            */
            return default;
        }

        protected async Task<ProductProduct> GetImage1920UrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _get_image_1920_url(self):
            // """ Returns the local url of the product main image.
            // 
            // Note: self.ensure_one()
            // 
            // :rtype: str
            // """
            // self.ensure_one()
            // return self.env['website'].image_url(self, 'image_1920')
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

        protected async Task<ProductProduct> GetLastInInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_last_in(self, date=None):
            // last_in_domain = Domain([('is_in', '=', True), ('product_id', '=', self.id)])
            // if date:
            //     last_in_domain &= Domain([('date', '<=', date)])
            // last_in = self.env['stock.move'].search(last_in_domain, order='date desc, id desc', limit=1)
            // return last_in
            */
            return default;
        }

        protected async Task<ProductProduct> GetLinesDomainInternalAsync(List<Guid> location_ids, List<Guid> warehouse_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_lines_domain(self, location_ids=False, warehouse_ids=False):
            // domains = []
            // rfq_domain = (
            //     Domain('state', 'in', ('draft', 'sent', 'to approve'))
            //     & Domain('product_id', 'in', self.ids)
            // )
            // if location_ids:
            //     domains.append(Domain([
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
            //     ]))
            // if warehouse_ids:
            //     domains.append(Domain([
            //         '|',
            //             '&',
            //                 ('orderpoint_id', '=', False),
            //                 ('order_id.picking_type_id.warehouse_id', 'in', warehouse_ids),
            //             '&',
            //                 ('move_dest_ids', '=', False),
            //                 ('orderpoint_id.warehouse_id', 'in', warehouse_ids)
            //     ]))
            // return rfq_domain & Domain.OR(domains or [Domain.TRUE])
            */
            return default;
        }

        protected async Task<ProductProduct> GetMaxQuantityInternalAsync(object website, object sale_order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _get_max_quantity(self, website, sale_order, **kwargs):
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
            //     cart_qty = sale_order._get_cart_qty(self.id)
            //     return free_qty - cart_qty
            // return None
            */
            return default;
        }

        protected async Task<ProductProduct> GetMonthlyDemandMovesLocationDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: product_product.py) ---
            // def _get_monthly_demand_moves_location_domain(self):
            // subcontracting_location_ids = self.env.companies.subcontracting_location_id.child_internal_location_ids.ids
            // domain = Domain.AND([
            //     Domain.OR([
            //         super()._get_monthly_demand_moves_location_domain(),
            //         [('location_dest_id', 'in', subcontracting_location_ids)],
            //     ]),
            //     [('location_id', 'not in', subcontracting_location_ids)],
            // ])
            // return domain
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_monthly_demand_moves_location_domain(self):
            // """ Returns a domain on stock moves coming from the selected warehouse that are:
            //         - going to customer locations or used in production
            //         - going to other warehouses (eg. central warehouse dispatching to stores)
            //     (We don't include returns in demand estimation - they come back on hand)
            // """
            // warehouse_id = self.env.context.get('warehouse_id')
            // if not warehouse_id:
            //     return Domain.OR([
            //         [('location_dest_usage', 'in', ['customer', 'production'])],
            //         [('location_final_id.usage', 'in', ['customer', 'production'])],
            //     ])
            // else:
            //     return Domain.AND([
            //         [('location_id.warehouse_id', '=', warehouse_id)],
            //         Domain.OR([
            //             [('location_dest_id.warehouse_id', '!=', warehouse_id)],
            //             [('location_final_id.warehouse_id', '!=', warehouse_id)]
            //         ]),  # includes moves going to customer or production
            //         [('location_dest_id.usage', '!=', 'inventory')]  # exclude scrap
            //     ])
            */
            return default;
        }

        protected async Task<ProductProduct> GetMonthlyDemandRangeInternalAsync(object based_on)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_monthly_demand_range(self, based_on):
            // start_date = limit_date = datetime.now()
            // 
            // if not based_on or based_on == 'actual_demand' or based_on == '30_days':
            //     start_date = start_date - relativedelta(days=30)  # Default monthly demand
            // elif based_on == 'one_week':
            //     start_date = start_date - relativedelta(weeks=1)
            // elif based_on == 'three_months':
            //     start_date = start_date - relativedelta(months=3)
            // elif based_on == 'one_year':
            //     start_date = start_date - relativedelta(years=1)
            // else:  # Relative period of time.
            //     today = datetime.now()
            //     start_date = datetime(year=today.year - 1, month=today.month, day=1)
            // 
            //     if based_on == 'last_year_m_plus_1':
            //         start_date += relativedelta(months=1)
            //     elif based_on == 'last_year_m_plus_2':
            //         start_date += relativedelta(months=2)
            // 
            //     if based_on == 'last_year_quarter':
            //         limit_date = start_date + relativedelta(months=3)
            //     else:
            //         limit_date = start_date + relativedelta(months=1)
            // 
            // return start_date, limit_date
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
            // domain_quant = Domain.AND([self._get_domain_locations()[0], [('product_id', 'in', self.ids)]])
            // quants_groupby = self.env['stock.quant']._read_group(domain_quant, ['product_id'], ['quantity:sum'])
            // currents = defaultdict(float)
            // currents.update({product.id: quantity for product, quantity in quants_groupby})
            // return currents
            */
            return default;
        }

        protected async Task<ProductProduct> GetPickingDescriptionInternalAsync(Guid picking_type_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_picking_description(self, picking_type_id):
            // """
            // Return product receipt/delivery/picking description depending on picking type passed as argument.
            // """
            // return {
            //     'incoming': self.description_pickingin,
            //     'outgoing': self.description_pickingout,
            //     'internal': self.description_picking
            // }.get(picking_type_id.code, '')
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
            //     return self._get_product_placeholder_filename()
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

        protected async Task<ProductProduct> GetProductDomainSearchOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_domain_search_order(self, **vals):
            // """Gives the order of search for a product given the parameters.
            // 
            // :param name:            The name of the product.
            // :param default_code:    The default_code of the product.
            // :param barcode:         The barcode of the product.
            // :returns:               An ordered list of product domains and their associated priority.
            // :rtype: list[tuple[int, Domain]]
            // """
            // sorted_domains = []
            // if barcode := vals.get('barcode'):
            //     sorted_domains.append((5, Domain('barcode', '=', barcode)))
            // if default_code := vals.get('default_code'):
            //     sorted_domains.append((10, Domain('default_code', '=', default_code)))
            // if name := vals.get('name'):
            //     name = name.split('\n', 1)[0]  # Cut sales description from the name
            //     sorted_domains.append((15, Domain('name', '=', name)))
            //     # avoid matching unrelated products whose names merely contain that short string
            //     if len(name) > 4:
            //         sorted_domains.append((20, Domain('name', 'ilike', name)))
            // return sorted_domains
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: product_product.py) ---
            // def _get_product_domain_search_order(self, **vals):
            // """Override of `account` to include the variant identifiers in the search order.
            // 
            // If the product is not found using `*ItemIdentification:ID` elements, tries again with the
            // `*ItemIdentification:ExtendedID` elements. `ExtendedID` could be used to identify a product
            // variant.
            // 
            // Example:
            //     StandardItemIdentification::ID == product.template.barcode           (product ID)
            //     StandardItemIdentification::ExtendedID == product.product.barcode    (variant ID)
            // """
            // domains = super()._get_product_domain_search_order(**vals)
            // 
            // if variant_default_code := vals.get('variant_default_code'):
            //     bisect.insort(domains, (12, Domain('default_code', '=', variant_default_code)))
            // if variant_barcode := vals.get('variant_barcode'):
            //     bisect.insort(domains, (14, Domain('barcode', '=', variant_barcode)))
            // 
            // return domains
            */
            return default;
        }

        public async Task<ProductProduct> GetProductMultilineDescriptionSaleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def get_product_multiline_description_sale(self):
            // """ Compute a multiline description of this product, in the context of sales
            // (do not use for purchases or other display reasons that don't intend to use "description_sale").
            // It will often be used as the default description of a sale order line referencing this product.
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
            //     return super().get_product_multiline_description_sale()
            // 
            // new_line = '' if len(payment_channels) == 1 else '\n'
            // return _('Access to: %(new_line)s%(channel_list)s', new_line=new_line, channel_list='\n'.join(payment_channels.mapped('name')))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetProductPlaceholderFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _get_product_placeholder_filename(self):
            // return self.product_tmpl_id._get_product_placeholder_filename()
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: product.py) ---
            // def _get_product_placeholder_filename(self):
            // if self.event_ticket_ids:
            //     return 'website_event_sale/static/img/event_ticket_placeholder_thumbnail.png'
            // return super()._get_product_placeholder_filename()
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: product_product.py) ---
            // def _get_product_placeholder_filename(self):
            // """ Override of `product` to set a default image for reward products. """
            // # In sudo mode to allow eCommerce customers to see the placeholder
            // if self.env['loyalty.reward'].sudo().search_count([
            //     ('discount_line_product_id', '=', self.id),
            // ], limit=1):
            //     if self.env['loyalty.reward'].sudo().search_count([
            //         ('program_type', '=', 'gift_card'),
            //         ('discount_line_product_id', '=', self.id),
            //     ], limit=1):
            //         return 'loyalty/static/img/gift_card.png'
            //     return 'loyalty/static/img/discount_placeholder_thumbnail.png'
            // return super()._get_product_placeholder_filename()
            */
            return default;
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
            //     ['order_id', 'product_id', 'product_uom_id', 'orderpoint_id', 'location_final_id'],
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

        protected async Task<ProductProduct> GetRemainingMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_remaining_moves(self):
            // moves_qty_by_product = {}
            // for product in self:
            //     moves, remaining_qty = product._run_fifo_get_stack()
            //     moves = self.env['stock.move'].concat(*moves)
            //     if not moves:
            //         continue
            //     qty_by_move = {m: m.quantity for m in moves[1:]}
            //     qty_by_move[moves[0]] = remaining_qty
            //     moves_qty_by_product[product] = qty_by_move
            // return moves_qty_by_product
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
            // rule = self.env['stock.rule'].with_context(active_test=True)._get_rule(self, location, {
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

        protected async Task<ProductProduct> GetStandardPriceAtDateInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_standard_price_at_date(self, date=None):
            // """ Get Last Price History """
            // self.ensure_one()
            // if not date or date == fields.Date.today():
            //     return self.standard_price
            // if self.cost_method != 'standard':
            //     raise ValidationError(_("You can only get the standard price at a given date for products with 'Standard Price' as cost method."))
            // product_value_domain = Domain([
            //     ('product_id', '=', self.id),
            //     ('move_id', '=', False),
            //     ('lot_id', '=', False),
            // ])
            // product_value = self.env['product.value'].search(product_value_domain & Domain([('date', '<=', date)]), limit=1, order="date DESC, id DESC")
            // if not product_value:
            //     # If there is no history then get the value at creation
            //     product_value = self.env['product.value'].search(product_value_domain, limit=1, order="date, id")
            // return product_value.value if product_value else self.standard_price
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

        public async Task<ProductProduct> GetTotalRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def get_total_routes(self):
            // routes = super().get_total_routes()
            // if self.bom_ids:
            //     manufacture_routes = self.env['stock.rule'].search([('action', '=', 'manufacture')]).route_id
            //     routes |= manufacture_routes
            // return routes
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def get_total_routes(self):
            // routes = super().get_total_routes()
            // if self.seller_ids:
            //     buy_routes = self.env['stock.rule'].search([('action', '=', 'buy')]).route_id
            //     routes |= buy_routes
            // return routes
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def get_total_routes(self):
            // # Extend the total routes in other modules
            // return self.env['stock.route']
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> GetValueFromLotsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_value_from_lots(self):
            // lots = self.env['stock.lot'].search([
            //     ('product_id', 'in', self.ids),
            //     ('product_qty', '!=', 0),
            // ])
            // return sum(lots.mapped('total_value'))
            */
            return default;
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

        protected async Task<ProductProduct> InversePricelistRuleIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _inverse_pricelist_rule_ids(self):
            // for product in self:
            //     template = product.product_tmpl_id
            //     template.pricelist_rule_ids = (
            //         product.pricelist_rule_ids
            //         # We have to manually keep the rules the current variant
            //         # wasn't aware of because they targeted other variants.
            //         | template.pricelist_rule_ids.filtered(
            //             lambda rule: rule.product_id and rule.product_id != product
            //         )
            //     )
            */
            return default;
        }

        protected async Task<ProductProduct> InverseQtyAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _inverse_qty_available(self):
            // """
            // Inverse method for the 'qty_available' field, enabling manual adjustment of stock on hand quantity
            // in the product form. To prevent the automatic creation of stock quants when the
            // 'compute_quantities' method is triggered, this method skips quant creation by custom context key.
            // """
            // if self.env.context.get('skip_qty_available_update', False):
            //     return
            // for product in self:
            //     if (
            //         product.type == "consu" and product.is_storable and float_compare(product.qty_available,
            //              0.0, precision_rounding=product.uom_id.rounding) >= 0
            //     ):
            //         warehouse = self.env['stock.warehouse'].search(
            //             [('company_id', '=', self.env.company.id)], limit=1
            //         )
            //         self.env['stock.quant'].with_context(inventory_mode=True, from_inverse_qty=True).create({
            //             'product_id': product.id,
            //             'location_id': warehouse.lot_stock_id.id,
            //             'inventory_quantity': product.qty_available,
            //         })._apply_inventory()
            */
            return default;
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
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _is_add_to_cart_allowed(self):
            // self.ensure_one()
            // if self.env.user.has_group('base.group_system'):
            //     return True
            // if not self.active or not self.website_published:
            //     return False
            // if not self.filtered_domain(self.env['website']._product_domain()):
            //     return False
            // if request.website.prevent_zero_price_sale and not self._get_contextual_price():
            //     return False
            // return request.website.has_ecommerce_access()
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
            // """Return whether the product is sold out (no available quantity).
            // 
            // If a product inventory is not tracked, or if it's allowed to be sold regardless
            // of availabilities, the product is never considered sold out.
            // 
            // :return: whether the product can still be sold
            // :rtype: bool
            // """
            // self.ensure_one()
            // if not self.is_storable or self.allow_out_of_stock_order:
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

        protected async Task<ProductProduct> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('product_tmpl_id', 'in', [p['id'] for p in data['product.template']])]
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config):
            // taxes = self.env['account.tax'].search(self.env['account.tax']._check_company_domain(config.company_id.id))
            // product_fields = taxes._eval_taxes_computation_prepare_product_fields()
            // return list(product_fields.union({
            //     'id', 'lst_price', 'display_name', 'product_tmpl_id', 'product_template_variant_value_ids',
            //     'product_template_attribute_value_ids', 'barcode', 'product_tag_ids', 'default_code', 'standard_price'
            // }))
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config):
            // result = super()._load_pos_data_fields(config)
            // result.append('all_product_tag_ids')
            // return result
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config):
            // params = super()._load_pos_data_fields(config)
            // params += ['all_product_tag_ids']
            // 
            // # add missing product fields used in the reward_product_domain
            // missing_fields = self.env['loyalty.reward']._get_reward_product_domain_fields(config) - set(params)
            // 
            // if missing_fields:
            //     params.extend([field for field in missing_fields if field in self._fields])
            // 
            // return params
            */
            return default;
        }

        protected async Task<ProductProduct> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // different_currency = config.currency_id != self.env.company.currency_id
            // if different_currency:
            //     for product in read_records:
            //         product['lst_price'] = self.env.company.currency_id._convert(
            //             product['lst_price'], config.currency_id, self.env.company, fields.Date.today()
            //         )
            // return read_records
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
            //     if record.type == 'service' and record.service_type == 'timesheet' and \
            //        not (record._origin.service_policy and record.service_policy == record._origin.service_policy):
            //         record.uom_id = self.env.ref('uom.product_uom_hour')
            //     elif record._origin.uom_id:
            //         record.uom_id = record._origin.uom_id
            //     else:
            //         record.uom_id = self.product_tmpl_id.default_get(['uom_id']).get('uom_id')
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
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _onchange_standard_price(self):
            // if self.standard_price < 0:
            //     raise ValidationError(_("The cost of a product can't be negative."))
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
            // if self._origin.uom_id == self.uom_id or not self._trigger_uom_warning():
            //     return
            // message = _(
            //     'Changing the unit of measure for your product will apply a conversion 1 %(old_uom_name)s = 1 %(new_uom_name)s.\n'
            //     'All existing records (Sales orders, Purchase orders, etc.) using this product will be updated by replacing the unit name.',
            //     old_uom_name=self._origin.uom_id.display_name, new_uom_name=self.uom_id.display_name)
            // return {
            //     'warning': {
            //         'title': _('What to expect ?'),
            //         'message': message,
            //     }
            // }
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
            // if any(product.type == 'service' for product in self):
            //     raise ValidationError(_('Labels cannot be printed for products of service type'))
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_ids': self.ids}
            // return action
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
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self.env.context['allowed_company_ids']))
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
            //     res['context'].pop('default_product_tmpl_id', None)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_quants(self):
            // hide_location = not self.env.user.has_group('stock.group_stock_multi_locations')
            // hide_lot = all(product.tracking == 'none' for product in self)
            // self = self.with_context(
            //     hide_location=hide_location, hide_lot=hide_lot,
            //     no_at_date=True,
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
            //         product.product_template_attribute_value_ids.filtered(
            //             lambda ptav: ptav.attribute_id == pa
            //         ) or  # If no_variant, show all possible values
            //         product.attribute_line_ids.filtered(lambda ptal: ptal.attribute_id == pa).value_ids
            //     ) for product in self])
            // return categories
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
            //     return SQL("NULL")
            // return super()._read_group_select(aggregate_spec, query)
            */
            return default;
        }

        protected async Task<ProductProduct> ReadGroupingSetsInternalAsync(object domain, object grouping_sets, object aggregates, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_margin, FILE: product_product.py) ---
            // def _read_grouping_sets(self, domain, grouping_sets, aggregates=(), order=None):
            // if self._SPECIAL_SUM_AGGREGATES.isdisjoint(aggregates):
            //     return super()._read_grouping_sets(domain, grouping_sets, aggregates, order)
            // 
            // base_aggregates = [*(agg for agg in aggregates if agg not in self._SPECIAL_SUM_AGGREGATES), 'id:recordset']
            // base_result = super()._read_grouping_sets(domain, grouping_sets, base_aggregates, order)
            // 
            // # Force the compute of all records to bypass the limit compute batching (PREFETCH_MAX)
            // all_records = self.concat(*(item[-1] for row in base_result for item in row))
            // # This line will compute all fields having _compute_product_margin_fields_values
            // # as compute method.
            // all_records._compute_product_margin_fields_values()
            // 
            // # base_result = [[(a1, b1, records), (a2, b2, records), ...], [(a1, b1, c1, records), (a2, b2, c2, records), ...] ...]
            // result = []
            // for grouping_spec, grouping in zip(grouping_sets, base_result):
            //     row = []
            //     for *other, records in grouping:
            //         for index, spec in enumerate(itertools.chain(grouping_spec, aggregates)):
            //             if spec in self._SPECIAL_SUM_AGGREGATES:
            //                 field_name = spec.split(':')[0]
            //                 other.insert(index, sum(records.mapped(field_name)))
            //         row.append(tuple(other))
            //     result.append(row)
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProductProduct> RetrieveProductInternalAsync(object company, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _retrieve_product(self, company=None, extra_domain=None, **product_vals):
            // '''Search all products and find one that matches one of the parameters.
            // 
            // :param company:         The company of the product.
            // :param extra_domain:    Any extra domain to add to the search.
            // :param product_vals:    Values the product should match.
            // :returns:               A product or an empty recordset if not found.
            // '''
            // domains = self._get_product_domain_search_order(**product_vals)
            // company = company or self.env.company
            // for _priority, domain in domains:
            //     for company_domain in (
            //         [*self.env['res.partner']._check_company_domain(company), ('company_id', '!=', False)],
            //         [('company_id', '=', False)],
            //     ):
            //         if product := self.env['product.product'].search(
            //             Domain.AND([domain, company_domain, extra_domain or Domain.TRUE]), limit=1,
            //         ):
            //             return product
            // return self.env['product.product']
            */
            return default;
        }

        protected async Task<ProductProduct> RunAvcoInternalAsync(object at_date, object lot, object method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _run_avco(self, at_date=None, lot=None, method="realtime"):
            // """ Recompute the average cost of the product base on the last closing
            // inventory value and all the incoming moves during the period."""
            // # TODO remove at the end and do at real time
            // self.ensure_one()
            // # Get value and quantity from last closing
            // quantity = 0
            // # Get value and quantity for all incoming
            // moves_domain = Domain([
            //     ('product_id', '=', self.id),
            //     ('company_id', '=', self.env.company.id),
            // ])
            // if lot:
            //     moves_domain &= Domain([
            //         ('move_line_ids.lot_id', 'in', lot.id),
            //     ])
            // if at_date:
            //     moves_domain &= Domain([
            //         ('date', '<=', at_date),
            //     ])
            // 
            // # PERF avoid memoryerror
            // move_fields = ['date', 'is_dropship', 'is_in', 'is_out', 'location_dest_id', 'location_id', 'move_line_ids', 'picked', 'value']
            // # load in before in case of quick return
            // moves_in = self.env['stock.move'].search_fetch(
            //     moves_domain & Domain(['|', ('is_in', '=', True), ('is_dropship', '=', True)]),
            //     field_names=move_fields,
            //     order='date, id'
            // )
            // # TODO convert to company UoM
            // product_value_domain = Domain([('product_id', '=', self.id)])
            // if lot:
            //     product_value_domain &= Domain(['|', ('lot_id', '=', lot.id), ('lot_id', '=', False)])
            // else:
            //     product_value_domain &= Domain([('lot_id', '=', False)])
            // if at_date:
            //     product_value_domain &= Domain([('date', '<=', at_date)])
            // 
            // product_values = self.env['product.value'].sudo().search(product_value_domain, order="date, id")
            // 
            // # If the last value was defined by the user just return it
            // if product_values and not moves_in:
            //     quantity = self._with_valuation_context().with_context(to_date=at_date).qty_available
            //     last_value = product_values[-1]
            //     return last_value.value, last_value.value * quantity
            // if product_values and moves_in and product_values[-1].date > moves_in[-1].date:
            //     quantity = self._with_valuation_context().with_context(to_date=at_date).qty_available
            //     if lot:
            //         quantity = lot.product_qty
            //     avco_value = product_values[-1].value
            //     return avco_value, avco_value * quantity
            // 
            // avco_value = 0
            // avco_total_value = 0
            // 
            // if method == "realtime":
            //     moves_full_domain = moves_domain & Domain([
            //         '|',
            //         '|', ('is_in', '=', True),
            //         ('is_out', '=', True),
            //         ('is_dropship', '=', True)
            //     ])
            //     moves = self.env['stock.move'].search_fetch(moves_full_domain, field_names=move_fields, order='date, id')
            // else:
            //     # no needed to join + reorder
            //     moves = moves_in
            // 
            // # PERF avoid memoryerror
            // moves.move_line_ids.fetch(['company_id', 'location_id', 'location_dest_id', 'lot_id', 'owner_id', 'picked', 'quantity_product_uom'])
            // 
            // # TODO Only browse from last product_value
            // for move in moves:
            //     while product_values and move.date >= product_values[0].date:
            //         product_value = product_values[0]
            //         product_values = product_values[1:]
            //         avco_value = product_value.value
            //         avco_total_value = avco_value * quantity
            //     if move.is_in or move.is_dropship:
            //         in_qty = move._get_valued_qty()
            //         in_value = move.value
            //         if at_date or move.is_dropship:
            //             in_value = move._get_value(at_date=at_date)
            //         if lot:
            //             lot_qty = move._get_valued_qty(lot)
            //             in_value = (in_value * lot_qty / in_qty) if in_qty else 0
            //             in_qty = lot_qty
            //         if quantity < 0 and quantity + in_qty >= 0:
            //             positive_qty = quantity + in_qty
            //             ratio = positive_qty / in_qty
            //             avco_total_value = ratio * in_value
            //         else:
            //             avco_total_value += in_value
            //         quantity += in_qty
            //         avco_value = avco_total_value / quantity if quantity else 0
            //     if move.is_out or move.is_dropship:
            //         out_qty = move._get_valued_qty()
            //         out_value = out_qty * avco_value
            //         if lot:
            //             lot_qty = move._get_valued_qty(lot)
            //             out_value = (out_value * lot_qty / out_qty) if out_qty else 0
            //             out_qty = lot_qty
            //         avco_total_value -= out_value
            //         quantity -= out_qty
            // 
            // return avco_value, avco_total_value
            */
            return default;
        }

        protected async Task<ProductProduct> RunFifoGetStackInternalAsync(object lot, object at_date, object location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _run_fifo_get_stack(self, lot=None, at_date=None, location=None):
            // # TODO: return a list of tuple (move, valued_qty) instead
            // external_location = location and location.is_valued_external
            // fifo_stack = []
            // fifo_stack_size = 0
            // if location:
            //     self = self.with_context(location=location.ids)  # noqa: PLW0642
            // if lot:
            //     fifo_stack_size = lot.product_qty
            // else:
            //     fifo_stack_size = self._with_valuation_context().with_context(to_date=at_date).qty_available
            // if self.env.context.get('fifo_qty_already_processed'):
            //     # When validating multiple moves at the same time, the qty_available won't be up to date yet
            //     fifo_stack_size -= self.env.context['fifo_qty_already_processed']
            // if self.uom_id.compare(fifo_stack_size, 0) <= 0:
            //     return fifo_stack, 0
            // 
            // moves_domain = Domain([
            //     ('product_id', '=', self.id),
            //     ('company_id', '=', self.env.company.id)
            // ])
            // if lot:
            //     moves_domain &= Domain([('move_line_ids.lot_id', 'in', lot.id)])
            // if at_date:
            //     moves_domain &= Domain([('date', '<=', at_date)])
            // if location:
            //     moves_domain &= Domain([('location_dest_id', '=', location.id)])
            // if external_location:
            //     moves_domain &= Domain([('is_out', '=', True)])
            // else:
            //     moves_domain &= Domain([('is_in', '=', True)])
            // 
            // # Arbitrary limit as we can't guess how many moves correspond to the qty_available, but avoid fetching all moves at the same time.
            // initial_limit = 100
            // moves_in = self.env['stock.move'].search(moves_domain, order='date desc, id desc', limit=initial_limit)
            // 
            // remaining_qty_on_first_stack_move = 0
            // current_offset = 0
            // # Go to the bottom of the stack
            // while self.uom_id.compare(fifo_stack_size, 0) > 0 and moves_in:
            //     move = moves_in[0]
            //     moves_in = moves_in[1:]
            //     in_qty = move._get_valued_qty()
            //     fifo_stack.append(move)
            //     remaining_qty_on_first_stack_move = min(in_qty, fifo_stack_size)
            //     fifo_stack_size -= in_qty
            //     if self.uom_id.compare(fifo_stack_size, 0) > 0 and not moves_in:
            //         # We need to fetch more moves
            //         current_offset += 1
            //         moves_in = self.env['stock.move'].search(moves_domain, order='date desc, id desc', offset=current_offset * initial_limit, limit=initial_limit)
            // fifo_stack.reverse()
            // return fifo_stack, remaining_qty_on_first_stack_move
            */
            return default;
        }

        protected async Task<ProductProduct> RunFifoInternalAsync(object quantity, object lot, object at_date, object location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _run_fifo(self, quantity, lot=None, at_date=None, location=None):
            // """ Returns the value for the next outgoing product base on the qty give as argument."""
            // self.ensure_one()
            // if self.uom_id.compare(quantity, 0) <= 0:
            //     if at_date:
            //         last_in = self._get_last_in(at_date)
            //         return quantity * (last_in._get_price_unit() if last_in else self.standard_price)
            //     return quantity * self.standard_price
            // external_location = location and location.is_valued_external
            // 
            // fifo_cost = 0
            // fifo_stack, qty_on_first_move = self._run_fifo_get_stack(lot=lot, at_date=at_date, location=location)
            // last_move = False
            // # Going up to get the quantity in the argument
            // while quantity > 0 and fifo_stack:
            //     move = fifo_stack.pop(0)
            //     last_move = move
            //     move_value = move.value
            //     if at_date:
            //         move_value = move._get_value(at_date=at_date)
            //     if qty_on_first_move:
            //         valued_qty = move._get_valued_qty()
            //         in_qty = qty_on_first_move
            //         in_value = move_value * in_qty / valued_qty
            //         qty_on_first_move = 0
            //     else:
            //         in_qty = move._get_valued_qty()
            //         in_value = move_value
            //     if in_qty > quantity:
            //         in_value = in_value * quantity / in_qty
            //         in_qty = quantity
            //     fifo_cost += in_value
            //     quantity -= in_qty
            // # When we required more quantity than available we extrapolate with the last known price
            // if quantity > 0:
            //     if last_move and last_move.quantity:
            //         fifo_cost += quantity * (last_move.value / last_move.quantity)
            //     else:
            //         fifo_cost += quantity * self.standard_price
            // return fifo_cost
            */
            return default;
        }

        protected async Task<ProductProduct> SearchAllProductTagIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search_all_product_tag_ids(self, operator, operand):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // return ['|', ('product_tag_ids', operator, operand), ('additional_product_tag_ids', operator, operand)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search_display_name(self, operator, value):
            // is_positive = operator not in Domain.NEGATIVE_OPERATORS
            // template_domains = [[('name', operator, value)]]
            // product_domains = [[('default_code', operator, value)]]
            // 
            // if operator == 'in':
            //     product_domains.append([('barcode', 'in', value)])
            //     for v in value:
            //         if isinstance(v, str) and (m := re.search(r'(\[(.*?)\])', v)):
            //             product_domains.append([('default_code', '=', m.group(2))])
            // elif operator.endswith('like') and is_positive:
            //     product_domains.append([('barcode', 'in', [value])])
            // 
            // supplier_domain = []
            // if partner_id := self.env.context.get('partner_id'):
            //     supplier_domain = [
            //         ('partner_id', '=', partner_id),
            //         '|',
            //         ('product_code', operator, value),
            //         ('product_name', operator, value),
            //     ]
            // 
            // # AND clauses properly hit indexes so no need for custom sql in this case.
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     domains = template_domains + product_domains
            //     if supplier_domain:
            //         domains.append([('product_tmpl_id.seller_ids', 'any', supplier_domain)])
            //     return Domain.AND(domains)
            // 
            // # Disable active_test to simplify subqueries
            // self_no_active_test = self.with_context(active_test=False)
            // queries = [
            //     self_no_active_test._search([
            //         ('product_tmpl_id', 'in', self_no_active_test.env['product.template']._search(Domain.OR(template_domains)))
            //     ]),
            //     self_no_active_test._search(Domain.OR(product_domains)),
            // ]
            // if supplier_domain:
            //     queries.append(
            //         self_no_active_test._search([
            //             (
            //                 'product_tmpl_id',
            //                 'in',
            //                 self_no_active_test.env['product.supplierinfo']._search(supplier_domain).subselect('product_tmpl_id'),
            //             )
            //         ])
            //     )
            // query = SQL(
            //     """(%s)""",
            //     SQL("UNION ALL").join(
            //         [SQL("(%s)", query.select()) for query in queries]
            //     )
            // )
            // 
            // return [('id', 'in', query)]
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

        protected async Task<ProductProduct> SearchInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search(self, domain, *args, **kwargs):
            // # TDE FIXME: strange
            // if self.env.context.get('search_default_categ_id'):
            //     domain = Domain(domain) & Domain('categ_id', 'child_of', self.env.context['search_default_categ_id'])
            // return super()._search(domain, *args, **kwargs)
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsInPurchaseOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _search_is_in_purchase_order(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // product_ids = self.env['purchase.order.line'].search([
            //     ('order_id', 'in', [self.env.context.get('order_id', '')]),
            // ]).product_id.ids
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsInSelectedSectionOfOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _search_is_in_selected_section_of_order(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // ctx = self.env.context
            // order_id = ctx.get('order_id')
            // order_model = ctx.get('product_catalog_order_model')
            // line_field = ctx.get('child_field')
            // if not (order_id and order_model and line_field):
            //     return []
            // 
            // product_ids = self.env[order_model].browse(order_id)[line_field].filtered(
            //     lambda line: line.get_parent_section_line().id == ctx.get('section_id'),
            // ).mapped('product_id').ids
            // 
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsKitsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('active', '=', True),
            //      ('type', '=', 'phantom'), ('product_id', '=', False)])
            // bom_product_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('product_id', '!=', False)])
            // return [
            //     '|', ('product_tmpl_id', 'in', bom_tmpl_query.subselect('product_tmpl_id')),
            //     ('id', 'in', bom_product_query.subselect('product_id'))
            // ]
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
            // if operator != 'in':
            //     return NotImplemented
            // product_ids = self.env['mrp.bom.line'].search([
            //     ('bom_id', '=', self.env.context.get('order_id', '')),
            // ]).product_id.ids
            // return [('id', operator, product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInMoInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_product_is_in_mo(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // product_ids = self.env['mrp.production'].search([
            //     ('id', 'in', [self.env.context.get('order_id', '')]),
            // ]).move_raw_ids.product_id.ids
            // return [('id', operator, product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInRepairInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _search_product_is_in_repair(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // product_ids = self.env['repair.order'].search([
            //     ('id', 'in', [self.env.context.get('order_id', '')]),
            // ]).move_ids.product_id.ids
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInSaleOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _search_product_is_in_sale_order(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // product_ids = self.env['sale.order.line'].search_fetch([
            //     ('order_id', 'in', [self.env.context.get('order_id', '')]),
            // ], ['product_id']).product_id.ids
            // return [('id', 'in', product_ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductQuantityInternalAsync(object @operator, object @value, object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_product_quantity(self, operator, value, field):
            // # Order the search on `id` to prevent the default order on the product name which slows
            // # down the search.
            // ids = self.with_context(prefetch_fields=False).search_fetch([], [field], order='id').filtered_domain([(field, operator, value)]).ids
            // return [('id', 'in', ids)]
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductWithSuggestedQuantityInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _search_product_with_suggested_quantity(self, operator, value):
            // if operator in ["in", "not in"]:
            //     return NotImplemented
            // 
            // search_domain = self.env.context.get("suggest_domain") or [('type', '=', 'consu')]
            // safe_search_domain = [c if c[0] != "suggested_qty" else [1, "=", 1] for c in search_domain]
            // products = self.search_fetch(safe_search_domain, ["suggested_qty"])
            // ids = products.filtered_domain([("suggested_qty", operator, value)]).ids
            // 
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
            // op = PY_OPERATORS.get(operator)
            // if not op:
            //     return NotImplemented
            // product_ids = super(ProductProduct, self)._search_qty_available_new(operator, value, lot_id, owner_id, package_id)
            // kit_boms = self.env['mrp.bom'].search([('type', "=", 'phantom')])
            // kit_products = self.env['product.product']
            // for kit in kit_boms:
            //     if kit.product_id:
            //         kit_products |= kit.product_id
            //     else:
            //         kit_products |= kit.product_tmpl_id.product_variant_ids
            // for product in kit_products:
            //     if op(product.qty_available, value):
            //         product_ids.append(product.id)
            //     elif product.id in product_ids:
            //         product_ids.pop(product_ids.index(product.id))
            // return list(set(product_ids))
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available_new(self, operator, value, lot_id=False, owner_id=False, package_id=False):
            // ''' Optimized method which doesn't search on stock.moves, only on stock.quants. '''
            // op = PY_OPERATORS.get(operator)
            // if not op:
            //     return NotImplemented
            // if isinstance(value, Iterable) and not isinstance(value, str):
            //     value = {float(v) for v in value}
            // else:
            //     value = float(value)
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
            // include_zero = op(0.0, value)
            // 
            // processed_product_ids = set()
            // for product, quantity_sum in quants_groupby:
            //     product_id = product.id
            //     if include_zero:
            //         processed_product_ids.add(product_id)
            //     if op(quantity_sum, value):
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
            //             'website_sale_stock.availability_email_body',
            //             {'product': product_ctxt},
            //         )
            //         full_mail = product_ctxt.env['mail.render.mixin']._render_encapsulate(
            //             'mail.mail_notification_light',
            //             body_html,
            //             add_context={'model_description': _("Product")},
            //             context_record=product_ctxt,
            //         )
            //         context = {'lang': partner.lang}  # Use partner lang to translate mail subject below
            //         mail_values = {
            //             'subject': _(
            //                 "The product '%(product_name)s' is now available",
            //                 product_name=product_ctxt.name
            //             ),
            //             'email_from': (product.company_id.partner_id or self.env.user).email_formatted,
            //             'email_to': partner.email_formatted,
            //             'body_html': full_mail,
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
            //         records = self.env["product.template"].load_product_from_pos(config.id, [('id', '=', self.product_tmpl_id.id)])
            //         payload = {}
            //         self_models = self.env["pos.config"]._load_self_data_models()
            //         for model in records:
            //             if model in self_models:
            //                 payload[model] = records[model]
            //         config._notify('PRODUCT_CHANGED', payload)
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
            //     if self.env.context.get('uom'):
            //         value = self.env['uom.uom'].browse(self.env.context['uom'])._compute_price(product.lst_price, product.uom_id)
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

        protected async Task<ProductProduct> ToMarkupDataInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def _to_markup_data(self, website):
            // """ Generate JSON-LD markup data for the current product.
            // 
            // :param website website: The current website.
            // :return: The JSON-LD markup data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // product_price = request.pricelist._get_product_price(
            //     self, quantity=1, target_currency=website.currency_id
            // )
            // # Use sudo to access cross-company taxes.
            // product_taxes_sudo = self.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            // taxes = request.fiscal_position.map_tax(product_taxes_sudo)
            // price = self.product_tmpl_id._apply_taxes_to_price(
            //     product_price, website.currency_id, product_taxes_sudo, taxes, self, website=website
            // )
            // 
            // base_url = website.get_base_url()
            // markup_data = {
            //     '@context': 'https://schema.org',
            //     '@type': 'Product',
            //     'name': self.with_context(display_default_code=False).display_name,
            //     'url': f'{base_url}{self.website_url}',
            //     'image': f'{base_url}{website.image_url(self, "image_1920")}',
            //     'offers': {
            //         '@type': 'Offer',
            //         'price': price,
            //         'priceCurrency': website.currency_id.name,
            //     },
            // }
            // if self.website_meta_description or self.description_sale:
            //     markup_data['description'] = self.website_meta_description or self.description_sale
            // if website.is_view_active('website_sale.product_comment') and self.rating_count:
            //     markup_data['aggregateRating'] = {
            //         '@type': 'AggregateRating',
            //         # sudo: product.product - visitor can access product average rating
            //         'ratingValue': self.sudo().rating_avg,
            //         'reviewCount': self.rating_count,
            //     }
            // return markup_data
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _to_markup_data(self, website):
            // """ Override of `website_sale` to include the product availability in the offer. """
            // markup_data = super()._to_markup_data(website)
            // if self.is_product_variant and self.is_storable:
            //     if not self._is_sold_out():
            //         availability = 'https://schema.org/InStock'
            //     else:
            //         availability = 'https://schema.org/OutOfStock'
            //     markup_data['offers']['availability'] = availability
            // return markup_data
            */
            return default;
        }

        protected async Task<ProductProduct> TriggerUomWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _trigger_uom_warning(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _trigger_uom_warning(self):
            // res = super()._trigger_uom_warning()
            // if res:
            //     return res
            // po_lines = self.env['purchase.order.line'].sudo().search_count(
            //     [('product_id', 'in', self.ids)], limit=1
            // )
            // return bool(po_lines)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _trigger_uom_warning(self):        
            // res = super()._trigger_uom_warning()
            // if res:
            //     return res
            // so_lines = self.env['sale.order.line'].sudo().search_count(
            //     [('product_id', 'in', self.ids)], limit=1
            // )
            // return bool(so_lines)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _trigger_uom_warning(self):
            // res = super()._trigger_uom_warning()
            // if res:
            //     return res
            // moves = self.env['stock.move'].sudo().search_count(
            //     [('product_id', 'in', self.ids)], limit=1
            // )
            // return bool(moves)
            */
            return default;
        }

        public async Task<ProductProduct> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def action_unarchive(self):
            // records = self.filtered(lambda rec: not rec.active)
            // super().action_unarchive()
            // # We activate product templates which are inactive with active variants.
            // records.product_tmpl_id.filtered(
            //     lambda product_tmpl: not product_tmpl.active and product_tmpl.product_variant_ids
            // ).action_unarchive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductProduct> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py) ---
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
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived, deleted nor linked to a company.', time_product.name))
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

        protected async Task<ProductProduct> UpdateStandardPriceInternalAsync(object extra_value, object extra_quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _update_standard_price(self, extra_value=None, extra_quantity=None):
            // # TODO: Add extra value and extra quantity kwargs to avoid total recomputation
            // for product in self:
            //     if product.cost_method == 'standard':
            //         continue
            //     if product.cost_method == 'fifo':
            //         qty_available = product._with_valuation_context().qty_available
            //         if product.uom_id.compare(qty_available, 0) > 0:
            //             product.sudo().with_context(disable_auto_revaluation=True).standard_price = product.total_value / qty_available
            //         elif last_in := product._get_last_in():
            //             product.sudo().with_context(disable_auto_revaluation=True).standard_price = last_in._get_price_unit()
            //         continue
            //     new_standard_price = product._run_avco()[0]
            //     if new_standard_price:
            //         product.with_context(disable_auto_revaluation=True).sudo().standard_price = new_standard_price
            */
            return default;
        }

        protected async Task<ProductProduct> UpdateUomInternalAsync(Guid to_uom_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _update_uom(self, to_uom_id):
            // for uom, product_template, boms in self.env['mrp.bom']._read_group(
            //     [('product_tmpl_id', 'in', self.product_tmpl_id.ids)],
            //     ['product_uom_id', 'product_tmpl_id'],
            //     ['id:recordset'],
            // ):
            //     if product_template.uom_id != uom:
            //         raise UserError(_('As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.name, uom=product_template.uom_id.name))
            //     boms.product_uom_id = to_uom_id
            // 
            // for uom, product, bom_lines in self.env['mrp.bom.line']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom_id', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if product.product_tmpl_id.uom_id != uom:
            //         raise UserError(_('As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.name, uom=product.product_tmpl_id.uom_id.name))
            //     bom_lines.product_uom_id = to_uom_id
            // 
            // for uom, product, productions in self.env['mrp.production']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom_id', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if product.product_tmpl_id.uom_id != uom:
            //         raise UserError(_('As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.name, uom=product.product_tmpl_id.uom_id.name))
            //     productions.product_uom_id = to_uom_id
            // 
            // return super()._update_uom(to_uom_id)
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def _update_uom(self, to_uom_id):
            // """ Hook to handle an UoM modification. Avoid recomputation and just replace the
            // many2one field on the impacted models."""
            // return True
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _update_uom(self, to_uom_id):
            // for uom, product, po_lines in self.env['purchase.order.line']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom_id', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if uom != product.product_tmpl_id.uom_id:
            //         raise UserError(_(
            //             'As other units of measure (ex : %(problem_uom)s) '
            //             'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //             'If you want to change it, please archive the product and create a new one.',
            //             problem_uom=uom.display_name, uom=product.product_tmpl_id.uom_id.display_name))
            //     po_lines.product_uom_id = to_uom_id
            //     po_lines.flush_recordset()
            // 
            // return super()._update_uom(to_uom_id)
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _update_uom(self, to_uom_id):
            // for uom, product, repairs in self.env['repair.order']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if uom != product.product_tmpl_id.uom_id:
            //         raise UserError(_(
            //         'As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.display_name, uom=product.product_tmpl_id.uom_id.display_name))
            //     repairs.product_uom = to_uom_id
            // return super()._update_uom(to_uom_id)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_product.py) ---
            // def _update_uom(self, to_uom_id):
            // for uom, product, so_lines in self.env['sale.order.line']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom_id', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if so_lines.product_uom_id != product.product_tmpl_id.uom_id:
            //         raise UserError(_(
            //             'As other units of measure (ex : %(problem_uom)s) '
            //             'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //             'If you want to change it, please archive the product and create a new one.',
            //             problem_uom=uom.display_name, uom=product.product_tmpl_id.uom_id.display_name))
            //     so_lines.product_uom_id = to_uom_id
            // return super()._update_uom(to_uom_id)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _update_uom(self, to_uom_id):
            // for uom, product, moves in self.env['stock.move']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if uom != product.product_tmpl_id.uom_id:
            //         raise UserError(_('As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.name, uom=product.product_tmpl_id.uom_id.name))
            //     moves.product_uom = to_uom_id
            // 
            // for uom, product, move_lines in self.env['stock.move.line']._read_group(
            //     [('product_id', 'in', self.ids)],
            //     ['product_uom_id', 'product_id'],
            //     ['id:recordset'],
            // ):
            //     if uom != product.product_tmpl_id.uom_id:
            //         raise UserError(_('As other units of measure (ex : %(problem_uom)s) '
            //         'than %(uom)s have already been used for this product, the change of unit of measure can not be done.'
            //         'If you want to change it, please archive the product and create a new one.',
            //         problem_uom=uom.name, uom=product.product_tmpl_id.uom_id.name))
            //     move_lines.product_uom_id = to_uom_id
            // return super()._update_uom(to_uom_id)
            */
            return default;
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
            // if self.env.context.get('categ_id'):
            //     return _(
            //         'Products: %(category)s',
            //         category=self.env['product.category'].browse(self.env.context['categ_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def view_header_get(self, view_id, view_type):
            // res = super().view_header_get(view_id, view_type)
            // if not res and self.env.context.get('active_id') and self.env.context.get('active_model') == 'stock.location':
            //     return _(
            //         'Products: %(location)s',
            //         location=self.env['stock.location'].browse(self.env.context['active_id']).name,
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
            //     action['domain'] = Domain(action.get('domain') or Domain.TRUE) & Domain('product_id', 'in', self.ids)
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
            // action['domain'] = ['&', ('state', '=', 'purchase'), ('product_id', 'in', self.ids)]
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
            //     'active_id': self.env.context.get('active_id'),
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
            // if not self.filtered_domain(self.env['website']._product_domain()):
            //     return False
            // return not request.website.prevent_zero_price_sale or self._get_contextual_price()
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py) ---
            // def _website_show_quick_add(self):
            // return not self._is_sold_out() and super()._website_show_quick_add()
            */
            return default;
        }

        protected async Task<ProductProduct> WithValuationContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _with_valuation_context(self):
            // self_with_context = self
            // valued_locations = self.env['stock.location'].search([('is_valued_internal', '=', True)])
            // self_with_context = self.with_context(location=valued_locations.ids)
            // # In FIFO, the stack in on stock.move and their value is already computed base on the owner
            // if self.cost_method != 'fifo':
            //     self_with_context = self_with_context.with_context(
            //         owners=[False, self.env.company.partner_id.id]
            //     )
            // return self_with_context
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
            //         ('state', '=', 'draft'),
            //     ])
            //     for expense_sudo in expenses_sudo:
            //         expense_product_sudo = expense_sudo.product_id
            //         product_has_cost = (
            //                 expense_product_sudo
            //                 and not expense_sudo.company_currency_id.is_zero(expense_product_sudo.standard_price)
            //         )
            //         expense_vals = {
            //             'product_has_cost': product_has_cost,
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
            // def write(self, vals):
            // if 'active' in vals:
            //     self.filtered(lambda p: p.active != vals['active']).with_context(active_test=False).variant_bom_ids.write({
            //         'active': vals['active']
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'self_order_available' in vals:
            //     for record in self:
            //         record._send_availability_status()
            // return res
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_product.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'product_template_attribute_value_ids' in vals:
            //     # `_get_variant_id_for_combination` depends on `product_template_attribute_value_ids`
            //     self.env.registry.clear_cache()
            // elif 'active' in vals:
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
            // # timesheet product can't be deleted, archived or linked to a company
            // if ('active' in vals and not vals['active']) or ('company_id' in vals and vals['company_id']):
            //     time_product = self.env.ref('sale_timesheet.time_product')
            //     if time_product in self:
            //         raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived, deleted nor linked to a company.', time_product.name))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def write(self, vals):
            // if 'active' in vals:
            //     self.filtered(lambda p: p.active != vals['active']).with_context(active_test=False).orderpoint_ids.write({
            //         'active': vals['active']
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def write(self, vals):
            // old_price = False
            // if 'standard_price' in vals and not self.env.context.get('disable_auto_revaluation'):
            //     old_price = {product: product.standard_price for product in self}
            // if 'lot_valuated' in vals:
            //     # lot_valuated must be updated from the ProductTemplate
            //     self.product_tmpl_id.write({'lot_valuated': vals.pop('lot_valuated')})
            // res = super().write(vals)
            // if old_price:
            //     self._change_standard_price(old_price)
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_product.py) ---
            // def write(self, vals):
            // if 'active' in vals and not vals['active']:
            //     # unlink draft lines containing the archived product
            //     self.env['sale.order.line'].sudo().search([
            //         ('state', '=', 'draft'),
            //         ('product_id', 'in', self.ids),
            //         ('order_id', 'any', [('website_id', '!=', False)]),
            //     ]).unlink()
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}