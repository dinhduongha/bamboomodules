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
    public class ProductTemplateAppService : GenericApplicationService<ProductTemplate>, IProductTemplateAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IRatingMixinAppService _ratingMixinAppService;
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ProductTemplateAppService(IRepository<ProductTemplate, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IRatingMixinAppService ratingMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _imageMixinAppService = imageMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _ratingMixinAppService = ratingMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        protected async Task<ProductTemplate> ApplyTaxesToPriceInternalAsync(object price, object currency, object product_taxes, object taxes, object product_or_template, object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _apply_taxes_to_price(
            //     self, price, currency, product_taxes, taxes, product_or_template,
            //     website=None,
            // ):
            //     website = website or self.env['website'].get_current_website()
            //     price = self.env['product.product']._get_tax_included_unit_price_from_price(
            //         price,
            //         product_taxes,
            //         product_taxes_after_fp=taxes,
            //     )
            //     show_tax = website.show_line_subtotals_tax_selection
            //     tax_display = 'total_excluded' if show_tax == 'tax_excluded' else 'total_included'
            // 
            //     # The list_price is always the price of one.
            //     return taxes.compute_all(
            //         price, currency, 1, product_or_template, self.env.user.partner_id
            //     )[tax_display]
            */
            return default;
        }

        public async Task<ProductTemplate> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_archive(self):
            // filtered_products = self.env['mrp.bom.line'].search([('product_id', 'in', self.product_variant_ids.ids), ('bom_id.active', '=', True)]).product_id.mapped('display_name')
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

        protected async Task<ProductTemplate> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _auto_init(self):
            // if not column_exists(self.env.cr, "product_template", "can_be_expensed"):
            //     create_column(self.env.cr, "product_template", "can_be_expensed", "boolean")
            //     self.env.cr.execute(
            //         """
            //         UPDATE product_template
            //         SET can_be_expensed = false
            //         WHERE type NOT IN ('consu', 'service')
            //         """
            //     )
            // return super()._auto_init()
            */
            return default;
        }

        public async Task<ProductTemplate> BomCostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def action_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').action_bom_cost()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ButtonBomCostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def button_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').button_bom_cost()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> CanBeAddedToCartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _can_be_added_to_cart(self):
            // """
            // Pre-check to `_is_add_to_cart_possible` to know if product can be sold.
            // """
            // return self.sale_ok
            */
            return default;
        }

        protected async Task<ProductTemplate> CartesianProductInternalAsync(object product_template_attribute_values_per_line, object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _cartesian_product(self, product_template_attribute_values_per_line, parent_combination):
            // """
            // Generate all possible combination for attributes values (aka cartesian product).
            // It is equivalent to itertools.product except it skips invalid partial combinations before they are complete.
            // 
            // Imagine the cartesian product of 'A', 'CD' and range(1_000_000) and let's say that 'A' and 'C' are incompatible.
            // If you use itertools.product or any normal cartesian product, you'll need to filter out of the final result
            // the 1_000_000 combinations that start with 'A' and 'C' . Instead, This implementation will test if 'A' and 'C' are
            // compatible before even considering range(1_000_000), skip it and and continue with combinations that start
            // with 'A' and 'D'.
            // 
            // It's necessary for performance reason because filtering out invalid combinations from standard Cartesian product
            // can be extremely slow
            // 
            // :param product_template_attribute_values_per_line: the values we want all the possibles combinations of.
            // One list of values by attribute line
            // :return: a generator of product template attribute value
            // """
            // if not product_template_attribute_values_per_line:
            //     return
            // 
            // all_exclusions = {self.env['product.template.attribute.value'].browse(k):
            //                   self.env['product.template.attribute.value'].browse(v) for k, v in
            //                   self._get_own_attribute_exclusions().items()}
            // # The following dict uses product template attribute values as keys
            // # 0 means the value is acceptable, greater than 0 means it's rejected, it cannot be negative
            // # Bear in mind that several values can reject the same value and the latter can only be included in the
            // #  considered combination if no value rejects it.
            // # This dictionary counts how many times each value is rejected.
            // # Each time a value is included in the considered combination, the values it rejects are incremented
            // # When a value is discarded from the considered combination, the values it rejects are decremented
            // current_exclusions = defaultdict(int)
            // for exclusion in self._get_parent_attribute_exclusions(parent_combination):
            //     current_exclusions[self.env['product.template.attribute.value'].browse(exclusion)] += 1
            // partial_combination = self.env['product.template.attribute.value']
            // 
            // # The following list reflects product_template_attribute_values_per_line
            // # For each line, instead of a list of values, it contains the index of the selected value
            // # -1 means no value has been picked for the line in the current (partial) combination
            // value_index_per_line = [-1] * len(product_template_attribute_values_per_line)
            // # determines which line line we're working on
            // line_index = 0
            // # determines which ptav we're working on
            // current_ptav = None
            // 
            // while True:
            //     current_line_values = product_template_attribute_values_per_line[line_index]
            //     current_ptav_index = value_index_per_line[line_index]
            // 
            //     # For multi-checkbox attribute, the list is empty as we want to start without any selected value
            //     if not current_line_values:
            //         if line_index == len(product_template_attribute_values_per_line) - 1:
            //             # submit combination if we're on the last line
            //             yield partial_combination
            //             # will break or continue further down as current_ptav_index is always -1 here
            //         else:
            //             line_index += 1
            //             continue
            //     else:
            //         current_ptav = current_line_values[current_ptav_index]
            // 
            //     # removing exclusions from current_ptav as we're removing it from partial_combination
            //     if current_ptav_index >= 0:
            //         for ptav_to_include_back in all_exclusions[current_ptav]:
            //             current_exclusions[ptav_to_include_back] -= 1
            //         partial_combination -= current_ptav
            // 
            //     if current_ptav_index < len(current_line_values) - 1:
            //         # go to next value of current line
            //         value_index_per_line[line_index] += 1
            //         current_line_values = product_template_attribute_values_per_line[line_index]
            //         current_ptav_index = value_index_per_line[line_index]
            //         current_ptav = current_line_values[current_ptav_index]
            //     elif line_index != 0:
            //         # reset current line, and then go to previous line
            //         value_index_per_line[line_index] = - 1
            //         line_index -= 1
            //         continue
            //     else:
            //         # we're done if we must reset first line
            //         break
            // 
            //     # adding exclusions from current_ptav as we're incorporating it in partial_combination
            //     for ptav_to_exclude in all_exclusions[current_ptav]:
            //         current_exclusions[ptav_to_exclude] += 1
            //     partial_combination += current_ptav
            // 
            //     # test if included values excludes current value or if current value exclude included values
            //     if current_exclusions[current_ptav] or \
            //             any(intersection in partial_combination for intersection in all_exclusions[current_ptav]):
            //         continue
            // 
            //     if line_index == len(product_template_attribute_values_per_line) - 1:
            //         # submit combination if we're on the last line
            //         yield partial_combination
            //     else:
            //         # else we go to the next line
            //         line_index += 1
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckBarcodeUniquenessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_barcode_uniqueness(self):
            // for template in self:
            //     template.product_variant_ids._check_barcode_uniqueness()
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckComboIdsNotEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_combo_ids_not_empty(self):
            // for template in self:
            //     if template.type == 'combo' and not template.combo_ids:
            //         raise ValidationError(_("A combo product must contain at least 1 combo choice."))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckComboInclusionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _check_combo_inclusions(self):
            // for product in self:
            //     if not product.available_in_pos:
            //         combo_name = self.env['product.combo.item'].sudo().search([('product_id', 'in', product.product_variant_ids.ids)], limit=1).combo_id.name
            //         if combo_name:
            //             raise UserError(_('You must first remove this product from the %s combo', combo_name))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckIncompatibleTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_incompatible_types(self):
            // incompatible_types = self._get_incompatible_types()
            // if len(incompatible_types) < 2:
            //     return
            // fields = self.env['ir.model.fields'].sudo().search_read(
            //     [('model', '=', 'product.template'), ('name', 'in', incompatible_types)],
            //     ['name', 'field_description'])
            // field_descriptions = {v['name']: v['field_description'] for v in fields}
            // field_list = incompatible_types + ['name']
            // values = self.read(field_list)
            // for val in values:
            //     incompatible_fields = [f for f in incompatible_types if val[f]]
            //     if len(incompatible_fields) > 1:
            //         raise ValidationError(_(
            //             "The product (%(product)s) has incompatible values: %(value_list)s",
            //             product=val['name'],
            //             value_list=format_list(self.env, [field_descriptions[v] for v in incompatible_fields]),
            //         ))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckPrintImagesAreSetBeforePublishingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _check_print_images_are_set_before_publishing(self):
            // for product in self.filtered('gelato_template_ref'):
            //     if product.is_published and product.gelato_missing_images:
            //         raise ValidationError(
            //             _("Print images must be set on products before they can be published.")
            //         )
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckProjectAndTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _check_project_and_template(self):
            // """ NOTE 'service_tracking' should be in decorator parameters but since ORM check constraints twice (one after setting
            //     stored fields, one after setting non stored field), the error is raised when company-dependent fields are not set.
            //     So, this constraints does cover all cases and inconsistent can still be recorded until the ORM change its behavior.
            // """
            // for product in self:
            //     if product.service_tracking == 'no' and (product.project_id or product.project_template_id):
            //         raise ValidationError(_('The product %s should not have a project nor a project template since it will not generate project.', product.name))
            //     elif product.service_tracking == 'task_global_project' and product.project_template_id:
            //         raise ValidationError(_('The product %s should not have a project template since it will generate a task in a global project.', product.name))
            //     elif product.service_tracking in ['task_in_project', 'project_only'] and product.project_id:
            //         raise ValidationError(_('The product %s should not have a global project since it will generate a project.', product.name))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckSaleComboIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_sale_combo_ids(self):
            // for template in self:
            //     if (
            //         template.type == 'combo'
            //         and template.sale_ok
            //         and any(
            //             not product.sale_ok for product in template.combo_ids.combo_item_ids.product_id
            //         )
            //     ):
            //         raise ValidationError(
            //             _("A sellable combo product can only contain sellable products.")
            //         )
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckSaleProductCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_sale_product_company(self):
            // """Ensure the product is not being restricted to a single company while
            // having been sold in another one in the past, as this could cause issues."""
            // products_by_compagny = defaultdict(lambda: self.env['product.template'])
            // for product in self:
            //     if not product.product_variant_ids or not product.company_id:
            //         # No need to check if the product has just being created (`product_variant_ids` is
            //         # still empty) or if we're writing `False` on its company (should always work.)
            //         continue
            //     products_by_compagny[product.company_id] |= product
            // 
            // for target_company, products in products_by_compagny.items():
            //     subquery_products = self.env['product.product'].sudo().with_context(active_test=False)._search([('product_tmpl_id', 'in', products.ids)])
            //     so_lines = self.env['sale.order.line'].sudo().search_read(
            //         [('product_id', 'in', subquery_products), '!', ('company_id', 'child_of', target_company.id)],
            //         fields=['id', 'product_id'])
            //     if so_lines:
            //         used_products = [sol['product_id'][1] for sol in so_lines]
            //         raise ValidationError(_('The following products cannot be restricted to the company'
            //                                 ' %(company)s because they have already been used in quotations or '
            //                                 'sales orders in another company:\n%(used_products)s\n'
            //                                 'You can archive these products and recreate them '
            //                                 'with your company restriction instead, or leave them as '
            //                                 'shared product.', company=target_company.name, used_products=', '.join(used_products)))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckServiceToPurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_service_to_purchase(self):
            // for template in self:
            //     if template.service_to_purchase:
            //         if template.type != 'service':
            //             raise ValidationError(_("Product that is not a service can not create RFQ."))
            //         template._check_vendor_for_service_to_purchase(template.seller_ids)
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_uom(self):
            // if any(template.uom_id and template.uom_po_id and template.uom_id.category_id != template.uom_po_id.category_id for template in self):
            //     raise ValidationError(_('The default Unit of Measure and the purchase Unit of Measure must be in the same category.'))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckUomNotInInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _check_uom_not_in_invoice(self):
            // self.env['product.template'].flush_model(['uom_id'])
            // self._cr.execute("""
            //     SELECT prod_template.id
            //       FROM account_move_line line
            //       JOIN product_product prod_variant ON line.product_id = prod_variant.id
            //       JOIN product_template prod_template ON prod_variant.product_tmpl_id = prod_template.id
            //       JOIN uom_uom template_uom ON prod_template.uom_id = template_uom.id
            //       JOIN uom_category template_uom_cat ON template_uom.category_id = template_uom_cat.id
            //       JOIN uom_uom line_uom ON line.product_uom_id = line_uom.id
            //       JOIN uom_category line_uom_cat ON line_uom.category_id = line_uom_cat.id
            //      WHERE prod_template.id IN %s
            //        AND line.parent_state = 'posted'
            //        AND template_uom_cat.id != line_uom_cat.id
            //      LIMIT 1
            // """, [tuple(self.ids)])
            // if self._cr.fetchall():
            //     raise ValidationError(_(
            //         "This product is already being used in posted Journal Entries.\n"
            //         "If you want to change its Unit of Measure, please archive this product and create a new one."
            //     ))
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckVendorForServiceToPurchaseInternalAsync(object sellers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_vendor_for_service_to_purchase(self, sellers):
            // if not sellers:
            //     raise ValidationError(_("Please define the vendor from whom you would like to purchase this service automatically."))
            */
            return default;
        }

        protected async Task<ProductTemplate> CompleteInverseExclusionsInternalAsync(object exclusions)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _complete_inverse_exclusions(self, exclusions):
            // """Will complete the dictionnary of exclusions with their respective inverse
            // e.g: Black excludes XL and L
            // -> XL excludes Black
            // -> L excludes Black"""
            // result = dict(exclusions)
            // for key, value in exclusions.items():
            //     for exclusion in value:
            //         if exclusion in result and key not in result[exclusion]:
            //             result[exclusion].append(key)
            //         else:
            //             result[exclusion] = [key]
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBarcodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_barcode(self):
            // self._compute_template_field_from_variant_field('barcode')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_count(self):
            // self.base_unit_count = 0
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_count = template.product_variant_ids.base_unit_count
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_id(self):
            // self.base_unit_id = self.env['website.base.unit']
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_id = template.product_variant_ids.base_unit_id
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_name(self):
            // for template in self:
            //     template.base_unit_name = template.base_unit_id.name or template.uom_name
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_price(self):
            // for template in self:
            //     template.base_unit_price = template._get_base_unit_price(template.list_price)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_bom_count(self):
            // for product in self:
            //     product.bom_count = self.env['mrp.bom'].search_count(['|', ('product_tmpl_id', '=', product.id), ('byproduct_ids.product_id.product_tmpl_id', '=', product.id)])
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCanBeExpensedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_can_be_expensed(self):
            // self.filtered(lambda p: p.type not in ['consu', 'service'] or not p.purchase_ok).update({'can_be_expensed': False})
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCanImage1024BeZoomedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for template in self.with_context(bin_size=False):
            //     template.can_image_1024_be_zoomed = template.image_1920 and is_image_size_above(template.image_1920, template.image_1024)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _compute_color(self):
            // """Automatically set the color field based on the selected category."""
            // for product in self:
            //     if product.pos_categ_ids:
            //         product.color = product.pos_categ_ids[0].color
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCostCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_cost_currency_id(self):
            // env_currency_id = self.env.company.currency_id.id
            // for template in self:
            //     template.cost_currency_id = template.company_id.sudo().currency_id.id or env_currency_id
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_currency_id(self):
            // main_company = self.env['res.company']._get_main_company()
            // for template in self:
            //     template.currency_id = template.company_id.sudo().currency_id.id or main_company.currency_id.id
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeDefaultCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_default_code(self):
            // self._compute_template_field_from_variant_field('default_code')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_display_name(self):
            // for template in self:
            //     template.display_name = False if not template.name else (
            //         '{}{}'.format(
            //             template.default_code and '[%s] ' % template.default_code or '', template.name
            //         ))
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeExpensePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // self.filtered(lambda t: not t.sale_ok).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: not t.can_be_expensed).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: t.is_storable).expense_policy = 'no'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeExpensePolicyTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy_tooltip(self):
            // for product_template in self:
            //     if not product_template.can_be_expensed or not product_template.expense_policy:
            //         product_template.expense_policy_tooltip = False
            //     elif product_template.expense_policy == 'no':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses of this category may not be added to a Sales Order."
            //         )
            //     elif product_template.expense_policy == 'cost':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their actual cost when posted."
            //         )
            //     elif product_template.expense_policy == 'sales_price':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their sales price (product price, pricelist, etc.) when posted."
            //         )
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     allowed_companies = record.company_id or self.env.companies
            //     record.fiscal_country_codes = ",".join(allowed_companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeGelatoMissingImagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_missing_images(self):
            // for product in self:
            //     product.gelato_missing_images = any(
            //         not image.datas for image in product.gelato_image_ids
            //     )
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeGelatoProductUidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_product_uid(self):
            // self._compute_template_field_from_variant_field('gelato_product_uid')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeHasAvailableRouteIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_has_available_route_ids(self):
            // self.has_available_route_ids = self.env['stock.route'].search_count([('product_selectable', '=', True)])
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeHasConfigurableAttributesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_has_configurable_attributes(self):
            // """A product is considered configurable if:
            // - It has dynamic attributes
            // - It has any attribute line with at least 2 attribute values configured
            // - It has multi-checkbox display type
            // - It has at least one custom attribute value
            // """
            // for product in self:
            //     product.has_configurable_attributes = (
            //         product.has_dynamic_attributes() or any(
            //             ptal._is_configurable()
            //             for ptal in product.attribute_line_ids
            //         )
            //     )
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeInvoicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_invoice_policy(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.invoice_policy).invoice_policy = 'order'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeIsKitsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_is_kits(self):
            // domain = [('product_tmpl_id', 'in', self.ids), ('type', '=', 'phantom'), '|', ('company_id', '=', False), ('company_id', '=', self.env.company.id)]
            // bom_mapping = self.env['mrp.bom'].sudo().search_read(domain, ['product_tmpl_id'])
            // kits_ids = set(b['product_tmpl_id'][0] for b in bom_mapping)
            // for template in self:
            //     template.is_kits = (template.id in kits_ids)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeIsProductVariantInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = False
            */
            return default;
        }

        public async Task<ProductTemplate> ComputeIsStorableAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def compute_is_storable(self):
            // self.filtered(lambda t: t.type != 'consu' and t.is_storable).is_storable = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> ComputeItemCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_item_count(self):
            // for template in self:
            //     # Pricelist item count counts the rules applicable on current template or on its variants.
            //     template.pricelist_item_count = template.env['product.pricelist.item'].search_count([
            //         '&',
            //         '|', ('product_tmpl_id', '=', template.id), ('product_id', 'in', template.product_variant_ids.ids),
            //         ('pricelist_id.active', '=', True),
            //         ('compute_price', '=', 'fixed'),
            //     ])
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeL10nEgEtaCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: product_template.py) ---
            // def _compute_l10n_eg_eta_code(self):
            // self.l10n_eg_eta_code = False
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.l10n_eg_eta_code = template.product_variant_ids.l10n_eg_eta_code
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeL10nIdProductCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_id_efaktur_coretax, FILE: product_template.py) ---
            // def _compute_l10n_id_product_code(self):
            // # used for setting default product code depending on product being goods/service
            // # 000000 is default for both general goods/service
            // for record in self:
            //     if record.type == 'service':
            //         record.l10n_id_product_code = self.env.ref('l10n_id_efaktur_coretax.product_code_000000_service', raise_if_not_found=False)
            //     else:
            //         record.l10n_id_product_code = self.env.ref('l10n_id_efaktur_coretax.product_code_000000_goods', raise_if_not_found=False)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeL10nInHsnWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: product_template.py) ---
            // def _compute_l10n_in_hsn_warning(self):
            // digit_suffixes = {
            //     '4': _("either 4, 6 or 8"),
            //     '6': _("either 6 or 8"),
            //     '8': _("8")
            // }
            // active_hsn_code_digit_len = max(
            //     int(company.l10n_in_hsn_code_digit)
            //     for company in self.env.companies
            // )
            // for record in self:
            //     check_hsn = record.sale_ok and record.l10n_in_hsn_code and active_hsn_code_digit_len
            //     if check_hsn and (not re.match(r'^\d{4}$|^\d{6}$|^\d{8}$', record.l10n_in_hsn_code) or len(record.l10n_in_hsn_code) < active_hsn_code_digit_len):
            //         record.l10n_in_hsn_warning = _(
            //             "HSN code field must consist solely of digits and be %s in length.",
            //             digit_suffixes.get(str(active_hsn_code_digit_len))
            //         )
            //         continue
            //     record.l10n_in_hsn_warning = False
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeLotValuatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_lot_valuated(self):
            // for product in self:
            //     if product.tracking == 'none':
            //         product.lot_valuated = False
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeMrpProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // for template in self:
            //     template.mrp_product_qty = float_round(sum(template.mapped('product_variant_ids').mapped('mrp_product_qty')), precision_rounding=template.uom_id.rounding)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeNbrMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_moves(self):
            // res = defaultdict(lambda: {'moves_in': 0, 'moves_out': 0})
            // incoming_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'incoming'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // outgoing_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'outgoing'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // for product, count in incoming_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_in'] += count
            // for product, count in outgoing_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_out'] += count
            // for template in self:
            //     template.nbr_moves_in = res[template.id]['moves_in']
            //     template.nbr_moves_out = res[template.id]['moves_out']
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeNbrReorderingRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_reordering_rules(self):
            // res = {k: {'nbr_reordering_rules': 0, 'reordering_min_qty': 0, 'reordering_max_qty': 0} for k in self.ids}
            // product_data = self.env['stock.warehouse.orderpoint']._read_group([('product_id.product_tmpl_id', 'in', self.ids)], ['product_id'], ['__count', 'product_min_qty:sum', 'product_max_qty:sum'])
            // for product, count, product_min_qty, product_max_qty in product_data:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['nbr_reordering_rules'] += count
            //     res[product_tmpl_id]['reordering_min_qty'] = product_min_qty
            //     res[product_tmpl_id]['reordering_max_qty'] = product_max_qty
            // for template in self:
            //     if not template.id:
            //         template.nbr_reordering_rules = 0
            //         template.reordering_min_qty = 0
            //         template.reordering_max_qty = 0
            //         continue
            //     template.nbr_reordering_rules = res[template.id]['nbr_reordering_rules']
            //     template.reordering_min_qty = res[template.id]['reordering_min_qty']
            //     template.reordering_max_qty = res[template.id]['reordering_max_qty']
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePackagingIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.packaging_ids = p.product_variant_ids.packaging_ids
            //     else:
            //         p.packaging_ids = False
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductDocumentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_document_count(self):
            // for template in self:
            //     template.product_document_count = template.env['product.document'].search_count(
            //         template._get_product_document_domain()
            //     )
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // self.product_tooltip = False
            // for template in self:
            //     template.product_tooltip = template._prepare_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductVariantCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_count(self):
            // for template in self:
            //     template.product_variant_count = len(template.product_variant_ids)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductVariantIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_id(self):
            // for p in self:
            //     p.product_variant_id = p.product_variant_ids[:1].id
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchaseMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchase_method(self):
            // default_purchase_method = self.env['product.template'].default_get(['purchase_method']).get('purchase_method', 'receive')
            // for product in self:
            //     if product.type == 'service':
            //         product.purchase_method = 'purchase'
            //     else:
            //         product.purchase_method = default_purchase_method
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchaseOkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // for record in self:
            //     if record.can_be_expensed:
            //         record.purchase_ok = True
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // pass
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchasedProductQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchased_product_qty(self):
            // for template in self.with_context(active_test=False):
            //     template.purchased_product_qty = float_round(sum(p.purchased_product_qty for
            //         p in template.product_variant_ids), precision_rounding=template.uom_id.rounding
            //     )
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeQuantitiesDictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities_dict(self):
            // variants_available = {
            //     p['id']: p for p in self.product_variant_ids._origin.read(['qty_available', 'virtual_available', 'incoming_qty', 'outgoing_qty'])
            // }
            // prod_available = {}
            // for template in self:
            //     qty_available = 0
            //     virtual_available = 0
            //     incoming_qty = 0
            //     outgoing_qty = 0
            //     for p in template.product_variant_ids._origin:
            //         qty_available += variants_available[p.id]["qty_available"]
            //         virtual_available += variants_available[p.id]["virtual_available"]
            //         incoming_qty += variants_available[p.id]["incoming_qty"]
            //         outgoing_qty += variants_available[p.id]["outgoing_qty"]
            //     prod_available[template.id] = {
            //         "qty_available": qty_available,
            //         "virtual_available": virtual_available,
            //         "incoming_qty": incoming_qty,
            //         "outgoing_qty": outgoing_qty,
            //     }
            // return prod_available
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeQuantitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // res = self._compute_quantities_dict()
            // for template in self:
            //     template.qty_available = res[template.id]['qty_available']
            //     template.virtual_available = res[template.id]['virtual_available']
            //     template.incoming_qty = res[template.id]['incoming_qty']
            //     template.outgoing_qty = res[template.id]['outgoing_qty']
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeSalesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_sales_count(self):
            // for product in self:
            //     product.sales_count = float_round(sum([p.sales_count for p in product.with_context(active_test=False).product_variant_ids]), precision_rounding=product.uom_id.rounding)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_service_policy(self):
            // for product in self:
            //     product.service_policy = self._get_general_to_service(product.invoice_policy, product.service_type)
            //     if not product.service_policy and product.type == 'service':
            //         product.service_policy = 'ordered_prepaid'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // self.filtered(lambda product: product.type != 'service').service_tracking = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // super()._compute_service_tracking()
            // self.filtered(lambda pt: not pt.sale_ok).service_tracking = 'no'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.service_type).service_type = 'manual'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // super()._compute_service_type()
            // self.filtered(lambda t: t.is_storable).service_type = 'manual'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceUpsellThresholdRatioInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_service_upsell_threshold_ratio(self):
            // product_uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_unit = self.env.ref('uom.product_uom_unit')
            // company_uom = self.env.company.timesheet_encode_uom_id
            // for record in self:
            //     if not record.uom_id or record.uom_id != uom_unit or\
            //        product_uom_hour.factor == record.uom_id.factor or\
            //        record.uom_id.category_id not in [product_uom_hour.category_id, uom_unit.category_id]:
            //         record.service_upsell_threshold_ratio = False
            //         continue
            //     else:
            //         timesheet_encode_uom = record.company_id.timesheet_encode_uom_id or company_uom
            //         record.service_upsell_threshold_ratio = f'(1 {record.uom_id.name} = {timesheet_encode_uom.factor / product_uom_hour.factor:.2f} {timesheet_encode_uom.name})'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeShowQtyStatusButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // super()._compute_show_qty_status_button()
            // for template in self:
            //     if template.is_kits:
            //         template.show_on_hand_qty_status_button = template.product_variant_count <= 1
            //         template.show_forecasted_qty_status_button = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // for template in self:
            //     template.show_on_hand_qty_status_button = template.is_storable
            //     template.show_forecasted_qty_status_button = template.is_storable
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_standard_price(self):
            // # Depends on force_company context because standard_price is company_dependent
            // # on the product_product
            // self._compute_template_field_from_variant_field('standard_price')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTaxStringInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_tax_string(self):
            // for record in self:
            //     record.tax_string = record._construct_tax_string(record.list_price)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTemplateFieldFromVariantFieldInternalAsync(object fname, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_template_field_from_variant_field(self, fname, default=False):
            // """Sets the value of the given field based on the template variant values
            // 
            // Equals to product_variant_ids[fname] if it's a single variant product.
            // Otherwise, sets the value specified in ``default``.
            // It's used to compute fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field to compute
            //     (field name must be identical between product.product & product.template models)
            // :param default: default value to set when there are multiple or no variants on the template
            // :return: None
            // """
            // for template in self:
            //     variant_count = len(template.product_variant_ids)
            //     if variant_count == 1:
            //         template[fname] = template.product_variant_ids[fname]
            //     elif variant_count == 0 and self.env.context.get("active_test", True):
            //         # If the product has no active variants, retry without the active_test
            //         template_ctx = template.with_context(active_test=False)
            //         template_ctx._compute_template_field_from_variant_field(fname, default=default)
            //     else:
            //         template[fname] = default
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_tracking(self):
            // self.filtered(lambda t: not t.is_storable and t.tracking != 'none').tracking = 'none'
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeUomPoIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_uom_po_id(self):
            // for template in self:
            //     if not template.uom_po_id or template.uom_id.category_id != template.uom_po_id.category_id:
            //         template.uom_po_id = template.uom_id
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeUsedInBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_used_in_bom_count(self):
            // for template in self:
            //     template.used_in_bom_count = self.env['mrp.bom'].search_count(
            //         [('bom_line_ids.product_tmpl_id', '=', template.id)])
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeValidProductTemplateAttributeLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_valid_product_template_attribute_line_ids(self):
            // """A product template attribute line is considered valid if it has at
            // least one possible value.
            // 
            // Those with only one value are considered valid, even though they should
            // not appear on the configurator itself (unless they have an is_custom
            // value to input), indeed single value attributes can be used to filter
            // products among others based on that attribute/value.
            // """
            // for record in self:
            //     record.valid_product_template_attribute_line_ids = record.attribute_line_ids.filtered(lambda ptal: ptal.value_ids)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVisibleExpensePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('analytic.group_analytic_accounting')
            // for product_template in self:
            //     product_template.visible_expense_policy = visibility and product_template.purchase_ok
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // expense_products = self.filtered(lambda p: p.can_be_expensed)
            // super(ProductTemplate, self - expense_products)._compute_visible_expense_policy()
            // visibility = self.env.user.has_group('hr_expense.group_hr_expense_user')
            // for product_template in expense_products:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('project.group_project_user')
            // for product_template in self:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            // return super()._compute_visible_expense_policy()
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVolumeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume(self):
            // self._compute_template_field_from_variant_field('volume')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVolumeUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for product in self:
            //     if product.id:
            //         product.website_url = "/shop/%s" % self.env['ir.http']._slug(product)
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight(self):
            // self._compute_template_field_from_variant_field('weight')
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<ProductTemplate> ConstructTaxStringInternalAsync(object price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _construct_tax_string(self, price):
            // currency = self.currency_id
            // res = self.taxes_id.filtered(lambda t: t.company_id == self.env.company).compute_all(
            //     price, product=self, partner=self.env['res.partner']
            // )
            // joined = []
            // included = res['total_included']
            // if currency.compare_amounts(included, price):
            //     joined.append(_('%(amount)s Incl. Taxes', amount=format_amount(self.env, included, currency)))
            // excluded = res['total_excluded']
            // if currency.compare_amounts(excluded, price):
            //     joined.append(_('%(amount)s Excl. Taxes', amount=format_amount(self.env, excluded, currency)))
            // if joined:
            //     tax_string = f"(= {', '.join(joined)})"
            // else:
            //     tax_string = " "
            // return tax_string
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: product_template.py) ---
            // def _construct_tax_string(self, price):
            // """ Updates the tax string computation to include the withheld amount when withholding taxes are involved. """
            // # OVERRIDE 'account'
            // company_taxes = self.taxes_id.filtered(lambda t: t.company_id == self.env.company)
            // 
            // def _get_withheld_amount():
            //     if not company_taxes:
            //         return 0.0
            // 
            //     base_line = company_taxes._prepare_base_line_for_taxes_computation(
            //         None,
            //         partner_id=self.env["res.partner"],
            //         currency_id=self.env.company.currency_id,
            //         product_id=self,
            //         quantity=1.0,
            //         tax_ids=company_taxes,
            //         price_unit=price,
            //         calculate_withholding_taxes=True,
            //     )
            //     company_taxes._add_tax_details_in_base_line(base_line, self.env.company)
            //     company_taxes._round_base_lines_tax_details([base_line], self.env.company)
            //     company_taxes._add_accounting_data_to_base_line_tax_details(
            //         base_line,
            //         self.env.company,
            //     )
            //     tax_details = base_line['tax_details']
            //     wth_total = 0.0
            //     for tax_data in tax_details['taxes_data']:
            //         if tax_data['tax'].is_withholding_tax_on_payment:
            //             wth_total -= tax_data['tax_amount_currency']
            //     return wth_total
            // 
            // # Reimplement the tax string by taking into account the withholding taxes.
            // # First step; compute the amounts excluding withholding taxes.
            // res = company_taxes.compute_all(
            //     price, product=self, partner=self.env['res.partner']
            // )
            // joined = []
            // included = res['total_included']
            // excluded = res['total_excluded']
            // # Second step, compute the withholding tax amounts
            // withheld_amount = _get_withheld_amount()
            // 
            // currency = self.currency_id
            // if currency.compare_amounts(included, price):
            //     joined.append(self.env._('%(amount)s Incl. Taxes', amount=format_amount(self.env, included, currency)))
            // if currency.compare_amounts(excluded, price):
            //     joined.append(self.env._('%(amount)s Excl. Taxes', amount=format_amount(self.env, excluded, currency)))
            // if not currency.is_zero(withheld_amount):
            //     joined.append(self.env._('%(amount)s Tax Withheld', amount=format_amount(self.env, withheld_amount, currency)))
            // if joined:
            //     tax_string = f"(= {', '.join(joined)})"
            // else:
            //     tax_string = " "
            // return tax_string
            */
            return default;
        }

        public override async Task<ProductTemplate> CopyAsync(Guid id, List<string> fields, ProductTemplate defaultValues = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def copy(self, default=None):
            // res = super().copy(default=default)
            // # Since we don't copy the product template attribute values, we need to match the extra prices.
            // for ptal, copied_ptal in zip(self.attribute_line_ids, res.attribute_line_ids):
            //     for ptav, copied_ptav in zip(ptal.product_template_value_ids, copied_ptal.product_template_value_ids):
            //         if not ptav.price_extra:
            //             continue
            //         # security check
            //         if ptav.attribute_id == copied_ptav.attribute_id and ptav.product_attribute_value_id == copied_ptav.product_attribute_value_id:
            //             copied_ptav.price_extra = ptav.price_extra
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def copy(self, default=None):
            // new_products = super().copy(default=default)
            // # Since we don't copy product variants directly, we need to match the newly
            // # created product variants with the old one, and copy the storage category
            // # capacity from them.
            // new_product_dict = {}
            // for product in new_products.product_variant_ids:
            //     product_attribute_value = product.product_template_attribute_value_ids.product_attribute_value_id
            //     new_product_dict[product_attribute_value] = product.id
            // storage_category_capacity_vals = []
            // for storage_category_capacity in self.product_variant_ids.storage_category_capacity_ids:
            //     product_attribute_value = storage_category_capacity.product_id.product_template_attribute_value_ids.product_attribute_value_id
            //     storage_category_capacity_vals.append(storage_category_capacity.copy_data({'product_id': new_product_dict[product_attribute_value]})[0])
            // self.env['stock.storage.category.capacity'].create(storage_category_capacity_vals)
            // return new_products
            */
            return await base.CopyAsync(id, fields, defaultValues);
        }

        public async Task<ProductTemplate> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for template, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", template.name)
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // if not (self.env.user.has_group('stock.group_stock_user') or self.env.is_superuser()):
            //     default = dict(default or {}, create_repair=False)
            // return super().copy_data(default)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ProductTemplate> CreateAsync(ProductTemplate entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def create(self, vals_list):
            // products = super().create(vals_list)
            // # If no company was set for the product, the product will be available for all companies and therefore should
            // # have the default taxes of the other companies as well. sudo() is used since we're going to need to fetch all
            // # the other companies default taxes which the user may not have access to.
            // other_companies = self.env['res.company'].sudo().search([('id', 'not in', self.env.companies.ids)])
            // if other_companies and products:
            //     products_without_company = products.filtered(lambda p: not p.company_id).sudo()
            //     products_without_company._force_default_tax(other_companies)
            // return products
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: product_template.py) ---
            // def create(self, vals_list):
            // templates = super().create(vals_list)
            // 
            // for template, vals in zip(templates, vals_list):
            //     related_vals = {}
            //     if vals.get('l10n_eg_eta_code'):
            //         related_vals['l10n_eg_eta_code'] = vals['l10n_eg_eta_code']
            //     if related_vals:
            //         template.write(related_vals)
            // 
            // return templates
            --- ODOO METHOD SOURCE (MODULE: l10n_tr, FILE: product.py) ---
            // def create(self, vals_list):
            // products = super().create(vals_list)
            // 
            // for product in products:
            //     if product.company_id.country_code == 'TR':
            //         ChartTemplate = self.env['account.chart.template'].with_company(product.company_id)
            //         return_account = ChartTemplate.ref('tr610', raise_if_not_found=False)
            //         product.l10n_tr_default_sales_return_account_id = return_account
            // 
            // return products
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def create(self, vals_list):
            // ''' Store the initial standard price in order to be able to retrieve the cost of a product template for a given date'''
            // templates = super(ProductTemplate, self).create(vals_list)
            // if self._context.get("create_product_product", True):
            //     templates._create_variant_ids()
            // 
            // # This is needed to set given values to first variant after creation
            // for template, vals in zip(templates, vals_list):
            //     related_vals = {}
            //     for field_name in self._get_related_fields_variant_template():
            //         if vals.get(field_name):
            //             related_vals[field_name] = vals[field_name]
            //     if related_vals:
            //         template.write(related_vals)
            // 
            // return templates
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('service_to_purchase'):
            //         self._check_vendor_for_service_to_purchase(vals.get('seller_ids'))
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ProductTemplate> CreateAttributesFromGelatoInfoInternalAsync(object template_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Create attributes for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // if len(template_info['variants']) == 1:  # The template has no attribute.
            //     self.gelato_product_uid = template_info['variants'][0]['productUid']
            // else:  # The template has multiple attributes.
            //     # Iterate over the variants to find and create the possible attributes.
            //     for variant_data in template_info['variants']:
            //         current_variant_pavs = self.env['product.attribute.value']
            //         for attribute_data in variant_data['variantOptions']:  # Attribute name and value.
            //             # Search for the existing attribute with the proper variant creation policy and
            //             # create it if not found.
            //             attribute = self.env['product.attribute'].search(
            //                 [('name', '=', attribute_data['name']), ('create_variant', '=', 'always')],
            //                 limit=1,
            //             )
            //             if not attribute:
            //                 attribute = self.env['product.attribute'].create({
            //                     'name': attribute_data['name']
            //                 })
            // 
            //             # Search for the existing attribute value and create it if not found.
            //             attribute_value = self.env['product.attribute.value'].search([
            //                 ('name', '=', attribute_data['value']),
            //                 ('attribute_id', '=', attribute.id),
            //             ], limit=1)
            //             if not attribute_value:
            //                 attribute_value = self.env['product.attribute.value'].create({
            //                     'name': attribute_data['value'],
            //                     'attribute_id': attribute.id
            //                 })
            //             current_variant_pavs += attribute_value
            // 
            //             # Search for the existing PTAL and create it if not found.
            //             ptal = self.env['product.template.attribute.line'].search(
            //                 [('product_tmpl_id', '=', self.id), ('attribute_id', '=', attribute.id)],
            //                 limit=1,
            //             )
            //             if not ptal:
            //                 self.env['product.template.attribute.line'].create({
            //                     'product_tmpl_id': self.id,
            //                     'attribute_id': attribute.id,
            //                     'value_ids': [Command.link(attribute_value.id)]
            //                 })
            //             else:  # The PTAL already exists.
            //                 ptal.value_ids = [Command.link(attribute_value.id)]  # Link the value.
            // 
            //         # Find the variant that was automatically created and set the Gelato UID.
            //         for variant in self.product_variant_ids:
            //             corresponding_ptavs = variant.product_template_attribute_value_ids
            //             corresponding_pavs = corresponding_ptavs.product_attribute_value_id
            //             if corresponding_pavs == current_variant_pavs:
            //                 variant.gelato_product_uid = variant_data['productUid']
            //                 break
            // 
            //     # Delete the incompatible variants that were created but not allowed by Gelato.
            //     variants_without_gelato = self.env['product.product'].search([
            //         ('product_tmpl_id', '=', self.id),
            //         ('gelato_product_uid', '=', False)
            //     ])
            //     variants_without_gelato.unlink()
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Override of `sale_gelato` to set the eCommerce description. """
            // self.description_ecommerce = template_info['description']
            // return super()._create_attributes_from_gelato_info(template_info)
            */
            return default;
        }

        protected async Task<ProductTemplate> CreateFirstProductVariantInternalAsync(object log_warning)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_first_product_variant(self, log_warning=False):
            // """Create if necessary and possible and return the first product
            // variant for this template.
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the first product variant or none
            // :rtype: recordset of `product.product`
            // """
            // return self._create_product_variant(self._get_first_possible_combination(), log_warning)
            */
            return default;
        }

        protected async Task<ProductTemplate> CreatePrintImagesFromGelatoInfoInternalAsync(object template_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_print_images_from_gelato_info(self, template_info):
            // """ Create print image for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // # Iterate over the print image data listed in the info of the first variant, as we don't
            // # support varying image placements between variants.
            // for print_image_data in template_info['variants'][0]['imagePlaceholders']:
            //     # Gelato might send image placements that are named '1' or 'front' that are not accepted
            //     # by their API when placing order.
            //     if print_image_data['printArea'].lower() in ('1', 'front'):
            //         print_image_data['printArea'] = 'default'  # Use 'default' which is accepted.
            // 
            //     # Gelato might send several print images for the same placement if several layers were
            //     # defined, but we keep only one because their API only accepts one image per placement.
            //     print_image_found = bool(self.env['product.document'].search_count([
            //         ('name', 'ilike', print_image_data['printArea']),
            //         ('res_id', '=', self.id),
            //         ('res_model', '=', 'product.template'),
            //         ('is_gelato', '=', True),  # Avoid finding regular documents with the same name.
            //     ]))
            //     if not print_image_found:
            //         self.gelato_image_ids = [Command.create({
            //             'name': print_image_data['printArea'].lower(),
            //             'res_id': self.id,
            //             'res_model': 'product.template',
            //             'is_gelato': True,
            //         })]
            */
            return default;
        }

        public async Task<ProductTemplate> CreateProductVariantAsync(Guid id, List<Guid> product_template_attribute_value_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def create_product_variant(self, product_template_attribute_value_ids):
            // """ Create if necessary and possible and return the id of the product
            // variant matching the given combination for this template.
            // 
            // Note AWA: Known "exploit" issues with this method:
            // 
            // - This method could be used by an unauthenticated user to generate a
            //     lot of useless variants. Unfortunately, after discussing the
            //     matter with ODO, there's no easy and user-friendly way to block
            //     that behavior.
            // 
            //     We would have to use captcha/server actions to clean/... that
            //     are all not user-friendly/overkill mechanisms.
            // 
            // - This method could be used to try to guess what product variant ids
            //     are created in the system and what product template ids are
            //     configured as "dynamic", but that does not seem like a big deal.
            // 
            // The error messages are identical on purpose to avoid giving too much
            // information to a potential attacker:
            //     - returning 0 when failing
            //     - returning the variant id whether it already existed or not
            // 
            // :param product_template_attribute_value_ids: the combination for which
            //     to get or create variant
            // :type product_template_attribute_value_ids: list of id
            //     of `product.template.attribute.value`
            // 
            // :return: id of the product variant matching the combination or 0
            // :rtype: int
            // """
            // combination = self.env['product.template.attribute.value'].browse(
            //     product_template_attribute_value_ids)
            // 
            // return self._create_product_variant(combination, log_warning=True).id or 0
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> CreateProductVariantInternalAsync(object combination, object log_warning)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_product_variant(self, combination, log_warning=False):
            // """ Create if necessary and possible and return the product variant
            // matching the given combination for this template.
            // 
            // It is possible to create only if the template has dynamic attributes
            // and the combination itself is possible.
            // If we are in this case and the variant already exists but it is
            // archived, it is activated instead of being created again.
            // 
            // :param combination: the combination for which to get or create variant.
            //     The combination must contain all necessary attributes, including
            //     those of type no_variant. Indeed even though those attributes won't
            //     be included in the variant if newly created, they are needed when
            //     checking if the combination is possible.
            // :type combination: recordset of `product.template.attribute.value`
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the product variant matching the combination or none
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // Product = self.env['product.product']
            // 
            // product_variant = self._get_variant_for_combination(combination)
            // if product_variant:
            //     if not product_variant.active and self.has_dynamic_attributes() and self._is_combination_possible(combination):
            //         product_variant.active = True
            //     return product_variant
            // 
            // if not self.has_dynamic_attributes():
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create a variant for the non-dynamic product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // if not self._is_combination_possible(combination):
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create an invalid variant for the product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // return Product.sudo().create({
            //     'product_tmpl_id': self.id,
            //     'product_template_attribute_value_ids': [(6, 0, combination._without_no_variant_attributes().ids)]
            // })
            */
            return default;
        }

        public async Task<ProductTemplate> CreateProductVariantsFromGelatoTemplateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def action_create_product_variants_from_gelato_template(self):
            // """ Override of `sale_gelato` to unpublish products for which the synchronization with
            // Gelato led to new print images being created. """
            // image_count_before_sync = len(self.gelato_image_ids)
            // res = super().action_create_product_variants_from_gelato_template()
            // if image_count_before_sync < len(self.gelato_image_ids):
            //     self.is_published = False
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> CreateVariantIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_variant_ids(self):
            // if not self:
            //     return
            // self.env.flush_all()
            // Product = self.env["product.product"]
            // 
            // variants_to_create = []
            // variants_to_activate = Product
            // variants_to_unlink = Product
            // 
            // for tmpl_id in self:
            //     lines_without_no_variants = tmpl_id.valid_product_template_attribute_line_ids._without_no_variant_attributes()
            // 
            //     all_variants = tmpl_id.with_context(active_test=False).product_variant_ids.sorted(lambda p: (p.active, -p.id))
            // 
            //     current_variants_to_create = []
            //     current_variants_to_activate = Product
            // 
            //     # adding an attribute with only one value should not recreate product
            //     # write this attribute on every product to make sure we don't lose them
            //     single_value_lines = lines_without_no_variants.filtered(lambda ptal: len(ptal.product_template_value_ids._only_active()) == 1)
            //     if single_value_lines:
            //         for variant in all_variants:
            //             combination = variant.product_template_attribute_value_ids | single_value_lines.product_template_value_ids._only_active()
            //             # Do not add single value if the resulting combination would
            //             # be invalid anyway.
            //             if (
            //                 len(combination) == len(lines_without_no_variants) and
            //                 combination.attribute_line_id == lines_without_no_variants
            //             ):
            //                 variant.product_template_attribute_value_ids = combination
            // 
            //     # Set containing existing `product.template.attribute.value` combination
            //     existing_variants = {
            //         variant.product_template_attribute_value_ids: variant for variant in all_variants
            //     }
            // 
            //     # Determine which product variants need to be created based on the attribute
            //     # configuration. If any attribute is set to generate variants dynamically, skip the
            //     # process.
            //     # Technical note: if there is no attribute, a variant is still created because
            //     # 'not any([])' and 'set([]) not in set([])' are True.
            //     if not tmpl_id.has_dynamic_attributes():
            //         # Iterator containing all possible `product.template.attribute.value` combination
            //         # The iterator is used to avoid MemoryError in case of a huge number of combination.
            //         all_combinations = itertools.product(*[
            //             ptal.product_template_value_ids._only_active() for ptal in lines_without_no_variants
            //         ])
            //         # For each possible variant, create if it doesn't exist yet.
            //         for combination in tmpl_id._filter_combinations_impossible_by_config(
            //             all_combinations, ignore_no_variant=True,
            //         ):
            //             if combination in existing_variants:
            //                 current_variants_to_activate += existing_variants[combination]
            //             else:
            //                 current_variants_to_create.append(tmpl_id._prepare_variant_values(combination))
            //                 variant_limit = self.env['ir.config_parameter'].sudo().get_param('product.dynamic_variant_limit', 1000)
            //                 if len(current_variants_to_create) > int(variant_limit):
            //                     raise UserError(_(
            //                         'The number of variants to generate is above allowed limit. '
            //                         'You should either not generate variants for each combination or generate them on demand from the sales order. '
            //                         'To do so, open the form view of attributes and change the mode of *Create Variants*.'))
            //         variants_to_create += current_variants_to_create
            //         variants_to_activate += current_variants_to_activate
            // 
            //     elif existing_variants:
            //         variants_combinations = [variant.product_template_attribute_value_ids for variant in existing_variants.values()]
            //         current_variants_to_activate += Product.concat(*[existing_variants[possible_combination]
            //             for possible_combination in tmpl_id._filter_combinations_impossible_by_config(variants_combinations, ignore_no_variant=True)
            //         ])
            //         variants_to_activate += current_variants_to_activate
            // 
            //     variants_to_unlink += all_variants - current_variants_to_activate
            // 
            // if variants_to_activate:
            //     variants_to_activate.write({'active': True})
            // if variants_to_create:
            //     Product.create(variants_to_create)
            // if variants_to_unlink:
            //     variants_to_unlink._unlink_or_archive()
            //     # prevent change if exclusion deleted template by deleting last variant
            //     if self.exists() != self:
            //         raise UserError(_("This configuration of product attributes, values, and exclusions would lead to no possible variant. Please archive or delete your product directly if intended."))
            // for variant in variants_to_unlink:
            //     combo_items_to_unlink = self.env['product.combo.item'].search([
            //         ('product_id', '=', variant.id)
            //     ])
            //     # Unlink all combo items which reference unlinked variants.
            //     combo_items_to_unlink.unlink()
            // 
            // # prefetched o2m have to be reloaded (because of active_test)
            // # (eg. product.template: product_variant_ids)
            // # We can't rely on existing invalidate because of the savepoint
            // # in _unlink_or_archive.
            // self.env.flush_all()
            // self.env.invalidate_all()
            // return True
            */
            return default;
        }

        public override async Task<ProductTemplate> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def default_get(self, fields):
            // result = super(ProductTemplate, self).default_get(fields)
            // if self.env.context.get('default_can_be_expensed'):
            //     result['supplier_taxes_id'] = False
            // return result
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def default_get(self, fields_list):
            // res = super().default_get(fields_list)
            // if 'uom_id' in fields_list and not res.get('uom_id') or self.env.context.get('default_uom_id') is False:
            //     res['uom_id'] = self._get_default_uom_id().id
            // return res
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<ProductTemplate> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_meta(self):
            // res = super()._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.description_sale
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = self.env['website'].image_url(self, 'image_1024')
            // res['default_meta_description'] = self.description_sale
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> DefaultWebsiteSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_sequence(self):
            // """ We want new product to be the last (highest seq).
            // Every product should ideally have an unique sequence.
            // Default sequence (10000) should only be used for DB first product.
            // As we don't resequence the whole tree (as `sequence` does), this field
            // might have negative value.
            // """
            // self.env.cr.execute('SELECT MAX(website_sequence) FROM %s' % self._table)
            // max_sequence = self.env.cr.fetchone()[0]
            // if max_sequence is None:
            //     return 10000
            // return max_sequence + 5
            */
            return default;
        }

        protected async Task<ProductTemplate> DemoConfigureVariantsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _demo_configure_variants(self):
            // acoustic_bloc_screens = self.env.ref(
            //     'product.product_template_acoustic_bloc_screens', raise_if_not_found=False
            // )
            // if acoustic_bloc_screens:
            //     acoustic_bloc_screens.product_variant_ids[0].default_code = 'FURN_6666'
            //     acoustic_bloc_screens.product_variant_ids[1].default_code = 'FURN_6667'
            //     self.env['ir.model.data']._update_xmlids([{
            //         'xml_id': 'product.product_product_25',
            //         'record': acoustic_bloc_screens.product_variant_ids[1],
            //         'noupdate': True,
            //     }])
            */
            return default;
        }

        protected async Task<ProductTemplate> FilterCombinationsImpossibleByConfigInternalAsync(object combination_tuples, object ignore_no_variant)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _filter_combinations_impossible_by_config(self, combination_tuples, ignore_no_variant=False):
            // """ Filter combination_tuples according to the config of attributes on the template
            // 
            // :return: iterator over possible combinations
            // :rtype: generator
            // """
            // self.ensure_one()
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // attribute_lines_active_values = attribute_lines.product_template_value_ids._only_active()
            // if ignore_no_variant:
            //     attribute_lines = attribute_lines._without_no_variant_attributes()
            // attribute_lines_without_multi = attribute_lines.filtered(
            //     lambda l: l.attribute_id.display_type != 'multi')
            // exclusions = self._get_own_attribute_exclusions()
            // for combination_tuple in combination_tuples:
            //     combination = self.env['product.template.attribute.value'].concat(*combination_tuple)
            //     combination_without_multi = combination.filtered(
            //         lambda l: l.attribute_line_id.attribute_id.display_type != 'multi')
            //     if len(combination_without_multi) != len(attribute_lines_without_multi):
            //         # number of attribute values passed is different than the
            //         # configuration of attributes on the template
            //         continue
            //     if attribute_lines_without_multi != combination_without_multi.attribute_line_id:
            //         # combination has different attributes than the ones configured on the template
            //         continue
            //     if not (attribute_lines_active_values >= combination):
            //         # combination has different values than the ones configured on the template
            //         continue
            //     if exclusions:
            //         # exclude if the current value is in an exclusion,
            //         # and the value excluding it is also in the combination
            //         combination_ids = set(combination.ids)
            //         combination_excluded_ids = set(itertools.chain(*[exclusions.get(ptav_id) for ptav_id in combination.ids]))
            //         if combination_ids & combination_excluded_ids:
            //             continue
            //     yield combination
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultPurchaseTaxInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_purchase_tax(self, companies):
            // default_supplier_taxes = companies.filtered('account_purchase_tax_id').account_purchase_tax_id
            // for product_grouped_by_tax in self.grouped('supplier_taxes_id').values():
            //     product_grouped_by_tax.supplier_taxes_id += default_supplier_taxes
            // self.invalidate_recordset(['supplier_taxes_id'])
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultSaleTaxInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_sale_tax(self, companies):
            // default_customer_taxes = companies.filtered('account_sale_tax_id').account_sale_tax_id
            // for product_grouped_by_tax in self.grouped('taxes_id').values():
            //     product_grouped_by_tax.taxes_id += default_customer_taxes
            // self.invalidate_recordset(['taxes_id'])
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultTaxInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_tax(self, companies):
            // self._force_default_sale_tax(companies)
            // self._force_default_purchase_tax(companies)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetActionViewRelatedPutawayRulesInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_action_view_related_putaway_rules(self, domain):
            // return {
            //     'name': _('Putaway Rules'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.putaway.rule',
            //     'view_mode': 'list',
            //     'domain': domain,
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAdditionalConfiguratorDataInternalAsync(object product_or_template, object date, object currency, object pricelist)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, **kwargs
            // ):
            //     """ Return additional data about the specified product, to be used by the product and combo
            //     configurators.
            // 
            //     This is a hook meant to append module-specific data in overriding modules.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to overrides.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     return {}
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to append tracking data.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     data = super()._get_additional_configurator_data(
            //         product_or_template, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if ir_http.get_request_website():
            //         data.update({
            //             # The following fields are needed for tracking.
            //             'category_name': product_or_template.categ_id.name,
            //             'currency_name': currency.name,
            //         })
            //     return data
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `website_sale` to append stock data.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to `super` and `_get_max_quantity`.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     data = super()._get_additional_configurator_data(
            //         product_or_template, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if (website := ir_http.get_request_website()) and product_or_template.is_product_variant:
            //         max_quantity = product_or_template._get_max_quantity(website, **kwargs)
            //         if max_quantity is not None:
            //             data['free_qty'] = max_quantity
            //     return data
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAdditionnalCombinationInfoInternalAsync(object product_or_template, object quantity, object date, object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // """Computes additional combination info, based on given parameters
            // 
            // :param product_or_template: `product.product` or `product.template` record
            //     as variant values must take precedence over template values (when we have a variant)
            // :param float quantity:
            // :param date date: today's date, avoids useless calls to today/context_today and harmonize
            //     behavior
            // :param website: `website` record holding the current website of the request (if any),
            //     or the contextual website (tests, ...)
            // :returns: additional product/template information
            // :rtype: dict
            // """
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // 
            // # Pricelist price doesn't have to be converted
            // pricelist_price, pricelist_rule_id = pricelist._get_product_price_rule(
            //     product=product_or_template,
            //     quantity=quantity,
            //     target_currency=currency,
            // )
            // 
            // price_before_discount = pricelist_price
            // pricelist_item = self.env['product.pricelist.item'].browse(pricelist_rule_id)
            // if pricelist_item._show_discount_on_shop():
            //     price_before_discount = pricelist_item._compute_price_before_discount(
            //         product=product_or_template,
            //         quantity=quantity or 1.0,
            //         date=date,
            //         uom=product_or_template.uom_id,
            //         currency=currency,
            //     )
            // 
            // has_discounted_price = price_before_discount > pricelist_price
            // combination_info = {
            //     'list_price': max(pricelist_price, price_before_discount),
            //     'price': pricelist_price,
            //     'has_discounted_price': has_discounted_price,
            // }
            // 
            // comparison_price = None
            // if (
            //     not has_discounted_price
            //     and product_or_template.compare_list_price
            //     and self.env.user.has_group('website_sale.group_product_price_comparison')
            // ):
            //     comparison_price = product_or_template.currency_id._convert(
            //         from_amount=product_or_template.compare_list_price,
            //         to_currency=currency,
            //         company=self.env.company,
            //         date=date,
            //         round=False)
            // combination_info['compare_list_price'] = comparison_price
            // 
            // combination_info['price_extra'] = product_or_template.currency_id._convert(
            //     from_amount=product_or_template._get_attributes_extra_price(),
            //     to_currency=currency,
            //     company=self.env.company,
            //     date=date,
            //     round=False,
            // )
            // 
            // # Apply taxes
            // fiscal_position = website.fiscal_position_id.sudo()
            // 
            // product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            // taxes = self.env['account.tax']
            // if product_taxes:
            //     taxes = fiscal_position.map_tax(product_taxes)
            //     # We do not apply taxes on the compare_list_price value because it's meant to be
            //     # a strict value displayed as is.
            //     for price_key in ('price', 'list_price', 'price_extra'):
            //         combination_info[price_key] = self._apply_taxes_to_price(
            //             combination_info[price_key],
            //             currency,
            //             product_taxes,
            //             taxes,
            //             product_or_template,
            //             website=website,
            //         )
            // 
            // combination_info.update({
            //     'prevent_zero_price_sale': website.prevent_zero_price_sale and float_is_zero(
            //         combination_info['price'],
            //         precision_rounding=currency.rounding,
            //     ),
            // 
            //     'base_unit_name': product_or_template.base_unit_name,
            //     'base_unit_price': product_or_template._get_base_unit_price(combination_info['price']),
            // 
            //     # additional info to simplify overrides
            //     'currency': currency,  # displayed currency
            //     'date': date,
            //     'product_taxes': product_taxes,  # taxes before fpos mapping
            //     'taxes': taxes,  # taxes after fpos mapping
            // })
            // 
            // if combination_info['prevent_zero_price_sale']:
            //     combination_info['compare_list_price'] = 0
            // 
            // return combination_info
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // """ Override of `website_sale` to add information on whether Click & Collect is enabled and
            // on the in-store stock of the product. """
            // res = super()._get_additionnal_combination_info(
            //     product_or_template, quantity, date, website
            // )
            // if (
            //     bool(website.sudo().in_store_dm_id)  # Click & Collect is enabled.
            //     and product_or_template.is_product_variant
            //     and product_or_template.is_storable
            // ):
            //     res['show_click_and_collect_availability'] = True
            //     order_sudo = website.sale_get_order()
            //     if (
            //         order_sudo
            //         and order_sudo.carrier_id.delivery_type == 'in_store'
            //         and order_sudo.pickup_location_data
            //     ):  # Get stock values for the product variant in the selected store.
            //         res['in_store_stock'] = utils.format_product_stock_values(
            //             product_or_template.sudo(), wh_id=order_sudo.pickup_location_data['id']
            //         )
            //     else:
            //         res['in_store_stock'] = utils.format_product_stock_values(
            //             product_or_template.sudo(),
            //             free_qty=website.sudo()._get_max_in_store_product_available_qty(
            //                 product_or_template.sudo()
            //             )
            //         )
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // res = super()._get_additionnal_combination_info(product_or_template, quantity, date, website)
            // 
            // product_or_template = product_or_template.sudo()
            // res.update({
            //     'product_type': product_or_template.type,
            //     'allow_out_of_stock_order': product_or_template.allow_out_of_stock_order,
            //     'available_threshold': product_or_template.available_threshold,
            // })
            // if product_or_template.is_product_variant:
            //     product = product_or_template
            //     free_qty = website._get_product_available_qty(product)
            //     has_stock_notification = (
            //         product._has_stock_notification(self.env.user.partner_id)
            //         or request and product.id in request.session.get(
            //             'product_with_stock_notification_enabled', set())
            //     )
            //     stock_notification_email = request and request.session.get('stock_notification_email', '')
            //     res.update({
            //         'free_qty': free_qty,
            //         'cart_qty': product._get_cart_qty(website),
            //         'uom_name': product.uom_id.name,
            //         'uom_rounding': product.uom_id.rounding,
            //         'show_availability': product_or_template.show_availability,
            //         'out_of_stock_message': product_or_template.out_of_stock_message,
            //         'has_stock_notification': has_stock_notification,
            //         'stock_notification_email': stock_notification_email,
            //     })
            // else:
            //     res.update({
            //         'free_qty': 0,
            //         'cart_qty': 0,
            //     })
            // if product_or_template.type == 'combo':
            //     # The max quantity of a combo product is the max quantity of its combo with the lowest
            //     # max quantity. If none of the combos has a max quantity, then the combo product also
            //     # has no max quantity.
            //     max_quantities = [
            //         max_quantity for combo in product_or_template.combo_ids.sudo()
            //         if (max_quantity := combo._get_max_quantity(website)) is not None
            //     ]
            //     if max_quantities:
            //         res['max_combo_quantity'] = min(max_quantities)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // res = super()._get_additionnal_combination_info(product_or_template, quantity, date, website)
            // 
            // if not self.env.context.get('website_sale_stock_wishlist_get_wish'):
            //     return res
            // 
            // if product_or_template.is_product_variant:
            //     product_sudo = product_or_template.sudo()
            //     res['is_in_wishlist'] = product_sudo._is_in_wishlist()
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAlternativeProductFilterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_alternative_product_filter(self):
            // return self.env.ref('website_sale.dynamic_filter_cross_selling_alternative_products').id
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAssetAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = {}
            // res['stock_input'] = False
            // res['stock_output'] = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = super(ProductTemplate, self)._get_asset_accounts()
            // if self.asset_category_id:
            //     res['stock_input'] = self.property_account_expense_id
            // if self.deferred_revenue_category_id:
            //     res['stock_output'] = self.property_account_income_id
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttribValuesDomainInternalAsync(object attribute_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_attrib_values_domain(self, attribute_values):
            // attribute_id = None
            // attribute_value_ids = []
            // domains = []
            // for value in attribute_values:
            //     if not attribute_id:
            //         attribute_id = value[0]
            //         attribute_value_ids.append(value[1])
            //     elif value[0] == attribute_id:
            //         attribute_value_ids.append(value[1])
            //     else:
            //         domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            //         attribute_id = value[0]
            //         attribute_value_ids = [value[1]]
            // if attribute_id:
            //     domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            // return domains
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttributeExclusionsInternalAsync(object parent_combination, object parent_name, List<Guid> combination_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attribute_exclusions(
            //     self, parent_combination=None, parent_name=None, combination_ids=None
            // ):
            //     """Return the list of attribute exclusions of a product.
            // 
            //     :param parent_combination: the combination from which
            //         `self` is an optional or accessory product. Indeed exclusions
            //         rules on one product can concern another product.
            //     :type parent_combination: recordset `product.template.attribute.value`
            //     :param parent_name: the name of the parent product combination.
            //     :type parent_name: str
            //     :param list combination: The combination of the product, as a
            //         list of `product.template.attribute.value` ids.
            // 
            //     :return: dict of exclusions
            //         - exclusions: from this product itself
            //         - archived_combinations: list of archived combinations
            //         - parent_combination: ids of the given parent_combination
            //         - parent_exclusions: from the parent_combination
            //        - parent_product_name: the name of the parent product if any, used in the interface
            //            to explain why some combinations are not available.
            //            (e.g: Not available with Customizable Desk (Legs: Steel))
            //        - mapped_attribute_names: the name of every attribute values based on their id,
            //            used to explain in the interface why that combination is not available
            //            (e.g: Not available with Color: Black)
            //     """
            //     self.ensure_one()
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     archived_products = self.with_context(active_test=False).product_variant_ids.filtered(lambda l: not l.active)
            //     active_combinations = set(tuple(product.product_template_attribute_value_ids.ids) for product in self.product_variant_ids)
            //     return {
            //         'exclusions': self._complete_inverse_exclusions(
            //             self._get_own_attribute_exclusions(combination_ids=combination_ids)
            //         ),
            //         'archived_combinations': list(set(
            //             tuple(product.product_template_attribute_value_ids.ids)
            //             for product in archived_products
            //             if product.product_template_attribute_value_ids and all(
            //                 ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //                 for ptav in product.product_template_attribute_value_ids
            //             )
            //         ) - active_combinations),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination),
            //         'parent_combination': parent_combination.ids,
            //         'parent_product_name': parent_name,
            //         'mapped_attribute_names': self._get_mapped_attribute_names(parent_combination),
            //     }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttributesExtraPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attributes_extra_price(self):
            // self.ensure_one()
            // 
            // return sum(self.env.context.get('current_attributes_price_extra', []))
            */
            return default;
        }

        protected async Task<ProductTemplate> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('mrp.menu_mrp_root').id]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('purchase.menu_purchase_root').id]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('sale.sale_menu_root').id]
            */
            return default;
        }

        protected async Task<ProductTemplate> GetBaseUnitPriceInternalAsync(object price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_base_unit_price(self, price):
            // self.ensure_one()
            // return self.base_unit_count and price / self.base_unit_count
            */
            return default;
        }

        protected async Task<ProductTemplate> GetBuyRouteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_buy_route(self):
            // buy_route = self.env.ref('purchase_stock.route_warehouse0_buy', raise_if_not_found=False)
            // if buy_route:
            //     return self.env['stock.route'].search([('id', '=', buy_route.id)]).ids
            // return []
            */
            return default;
        }

        protected async Task<ProductTemplate> GetClosestPossibleCombinationInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combination(self, combination):
            // """See `_get_closest_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_closest_possible_combinations(combination), self.env['product.template.attribute.value'])
            */
            return default;
        }

        protected async Task<ProductTemplate> GetClosestPossibleCombinationsInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combinations(self, combination):
            // """Generator returning the possible combinations that are the closest to
            // the given combination.
            // 
            // If the given combination is incomplete, try to complete it.
            // 
            // If the given combination is invalid, try to remove values from it before
            // completing it.
            // 
            // :param combination: the values to include if they are possible
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :return: the possible combinations that are including as much
            //     elements as possible from the given combination.
            // :rtype: generator of recordset of product.template.attribute.value
            // """
            // while True:
            //     res = self._get_possible_combinations(necessary_values=combination)
            //     try:
            //         # If there is at least one result for the given combination
            //         # we consider that combination set, and we yield all the
            //         # possible combinations for it.
            //         yield(next(res))
            //         for cur in res:
            //             yield(cur)
            //         return _("There are no remaining closest combination.")
            //     except StopIteration:
            //         # There are no results for the given combination, we try to
            //         # progressively remove values from it.
            //         if not combination:
            //             return _("There are no possible combination.")
            //         combination = combination[:-1]
            */
            return default;
        }

        protected async Task<ProductTemplate> GetCombinationInfoInternalAsync(object combination, Guid product_id, object add_qty, object parent_combination, object only_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_combination_info(
            //     self, combination=False, product_id=False, add_qty=1.0,
            //     parent_combination=False, only_template=False,
            // ):
            //     """ Return info about a given combination.
            // 
            //     Note: this method does not take into account whether the combination is
            //     actually possible.
            // 
            //     :param combination: recordset of `product.template.attribute.value`
            // 
            //     :param int product_id: `product.product` id. If no `combination`
            //         is set, the method will try to load the variant `product_id` if
            //         it exists instead of finding a variant based on the combination.
            // 
            //         If there is no combination, that means we definitely want a
            //         variant and not something that will have no_variant set.
            // 
            //     :param float add_qty: the quantity for which to get the info,
            //         indeed some pricelist rules might depend on it.
            // 
            //     :param parent_combination: if no combination and no product_id are
            //         given, it will try to find the first possible combination, taking
            //         into account parent_combination (if set) for the exclusion rules.
            // 
            //     :param only_template: boolean, if set to True, get the info for the
            //         template only: ignore combination and don't try to find variant
            // 
            //     :return: dict with product/combination info:
            // 
            //         - product_id: the variant id matching the combination (if it exists)
            // 
            //         - product_template_id: the current template id
            // 
            //         - display_name: the name of the combination
            // 
            //         - price: the computed price of the combination, take the catalog
            //             price if no pricelist is given
            // 
            //         - price_extra: the computed extra price of the combination
            // 
            //         - list_price: the catalog price of the combination, but this is
            //             not the "real" list_price, it has price_extra included (so
            //             it's actually more closely related to `lst_price`), and it
            //             is converted to the pricelist currency (if given)
            // 
            //         - has_discounted_price: True if the pricelist discount policy says
            //             the price does not include the discount and there is actually a
            //             discount applied (price < list_price), else False
            //     """
            //     self.ensure_one()
            // 
            //     combination = combination or self.env['product.template.attribute.value']
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     website = self.env['website'].get_current_website().with_context(self.env.context)
            // 
            //     if not product_id and not combination and not only_template:
            //         combination = self._get_first_possible_combination(parent_combination)
            // 
            //     if only_template:
            //         product = self.env['product.product']
            //     elif product_id:
            //         product = self.env['product.product'].browse(product_id)
            //         if (combination - product.product_template_attribute_value_ids):
            //             # If the combination is not fully represented in the given product
            //             #   make sure to fetch the right product for the given combination
            //             product = self._get_variant_for_combination(combination)
            //     else:
            //         product = self._get_variant_for_combination(combination)
            // 
            //     product_or_template = product or self
            //     combination = combination or product.product_template_attribute_value_ids
            // 
            //     display_name = product_or_template.with_context(display_default_code=False).display_name
            //     if not product:
            //         combination_name = combination._get_combination_name()
            //         if combination_name:
            //             display_name = f"{display_name} ({combination_name})"
            // 
            //     price_context = product_or_template._get_product_price_context(combination)
            //     product_or_template = product_or_template.with_context(**price_context)
            // 
            //     combination_info = {
            //         'combination': combination,
            //         'product_id': product.id,
            //         'product_template_id': self.id,
            //         'display_name': display_name,
            //         'display_image': bool(product_or_template.image_128),
            //         'is_combination_possible': self._is_combination_possible(combination=combination, parent_combination=parent_combination),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination=parent_combination),
            // 
            //         **self._get_additionnal_combination_info(
            //             product_or_template=product_or_template,
            //             quantity=add_qty or 1.0,
            //             date=fields.Date.context_today(self),
            //             website=website,
            //         )
            //     }
            // 
            //     if website.google_analytics_key:
            //         combination_info['product_tracking_info'] = self._get_google_analytics_data(
            //             product,
            //             combination_info,
            //         )
            // 
            //     if (
            //         product_or_template.type == 'combo'
            //         and website.show_line_subtotals_tax_selection == 'tax_included'
            //         and not all(
            //             tax.price_include
            //             for tax
            //             in product_or_template.combo_ids.sudo().combo_item_ids.product_id.taxes_id
            //         )
            //     ):
            //         combination_info['tax_disclaimer'] = _(
            //             "Final price may vary based on selection. Tax will be calculated at checkout."
            //         )
            // 
            //     return combination_info
            */
            return default;
        }

        protected async Task<ProductTemplate> GetConfiguratorDisplayPriceInternalAsync(object product_or_template, object quantity, object date, object currency, object pricelist)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_configurator_display_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Return the specified product's display price, to be used by the product and combo
            //     configurators.
            // 
            //     This is a hook meant to customize the display price computation in overriding modules.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `_get_configurator_price`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's display price (and the applied pricelist rule)
            //     """
            //     return self._get_configurator_price(
            //         product_or_template, quantity, date, currency, pricelist, **kwargs
            //     )
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_configurator_display_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to apply taxes.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's display price (and the applied pricelist rule)
            //     """
            //     price, pricelist_rule_id = super()._get_configurator_display_price(
            //         product_or_template, quantity, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if website := ir_http.get_request_website():
            //         product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(
            //             self.env.company
            //         )
            //         if product_taxes:
            //             fiscal_position = website.fiscal_position_id.sudo()
            //             taxes = fiscal_position.map_tax(product_taxes)
            //             return self._apply_taxes_to_price(
            //                 price, currency, product_taxes, taxes, product_or_template, website=website
            //             ), pricelist_rule_id
            //     return price, pricelist_rule_id
            */
            return default;
        }

        protected async Task<ProductTemplate> GetConfiguratorPriceInternalAsync(object product_or_template, object quantity, object date, object currency, object pricelist)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_configurator_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Return the specified product's price, to be used by the product and combo configurators.
            // 
            //     This is a hook meant to customize the price computation in overriding modules.
            // 
            //     This hook has been extracted from `_get_configurator_display_price` because the price
            //     computation can be overridden in 2 ways:
            // 
            //     - Either by transforming super's price (e.g. in `website_sale`, we apply taxes to the
            //       price),
            //     - Or by computing a different price (e.g. in `sale_subscription`, we ignore super when
            //       computing subscription prices).
            //     In some cases, the order of the overrides matters, which is why we need 2 separate methods
            //     (e.g. in `website_sale_subscription`, we must compute the subscription price before applying
            //     taxes).
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `_get_product_price`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's price (and the applied pricelist rule)
            //     """
            //     return pricelist._get_product_price_rule(
            //         product_or_template, quantity=quantity, currency=currency, date=date, **kwargs
            //     )
            */
            return default;
        }

        public async Task<ProductTemplate> GetContextualPriceAsync(Guid id, object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_contextual_price(self, product=None):
            // return self._get_contextual_price(product=product)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> GetContextualPriceInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_contextual_price(self, product=None):
            // self.ensure_one()
            // pricelist = self._get_contextual_pricelist()
            // quantity = self.env.context.get('quantity', 1.0)
            // uom = self.env['uom.uom'].browse(self.env.context.get('uom'))
            // date = self.env.context.get('date')
            // return pricelist._get_product_price(product or self, quantity, uom=uom, date=date)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetContextualPricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Get the contextual pricelist
            // 
            // This method is meant to be overriden in other standard modules.
            // """
            // return self.env['product.pricelist'].browse(self.env.context.get('pricelist'))
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Override to fallback on website current pricelist """
            // pricelist = super()._get_contextual_pricelist()
            // if not pricelist:
            //     website = ir_http.get_request_website()
            //     if website:
            //         return website.pricelist_id
            // return pricelist
            */
            return default;
        }

        protected async Task<ProductTemplate> GetDefaultCategoryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_category_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('product.product_category_all')
            */
            return default;
        }

        protected async Task<ProductTemplate> GetDefaultUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_uom_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        public async Task<ProductTemplate> GetEmptyListHelpAsync(Guid id, object help_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("product"),
            // )
            // return super(ProductTemplate, self).get_empty_list_help(help_message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> GetFirstPossibleCombinationInternalAsync(object parent_combination, object necessary_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_combination(self, parent_combination=None, necessary_values=None):
            // """See `_get_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_possible_combinations(parent_combination, necessary_values), self.env['product.template.attribute.value'])
            */
            return default;
        }

        protected async Task<ProductTemplate> GetFirstPossibleVariantIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_variant_id(self):
            // """See `_create_first_product_variant`. This method returns an ID
            // so it can be cached."""
            // self.ensure_one()
            // return self._create_first_product_variant().id
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGeneralToServiceInternalAsync(object invoice_policy, object service_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service(self, invoice_policy, service_type):
            // general_to_service = self._get_general_to_service_map()
            // return general_to_service.get((invoice_policy, service_type), False)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGeneralToServiceMapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service_map(self):
            // return {v: k for k, v in self._get_service_to_general_map().items()}
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGoogleAnalyticsDataInternalAsync(object product, object combination_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_google_analytics_data(self, product, combination_info):
            // self.ensure_one()
            // return {
            //     'item_id': product.barcode or product.id,
            //     'item_name': combination_info['display_name'],
            //     'item_category': self.categ_id.name,
            //     'currency': combination_info['currency'].name,
            //     'price': combination_info['list_price'],
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetImageHolderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_image_holder(self):
            // """Returns the holder of the image to use as default representation.
            // If the product template has an image it is the product template,
            // otherwise if the product has variants it is the first variant
            // 
            // :return: this product template or the first product variant
            // :rtype: recordset of 'product.template' or recordset of 'product.product'
            // """
            // self.ensure_one()
            // if self.image_128:
            //     return self
            // variant = self.env['product.product'].browse(self._get_first_possible_variant_id())
            // # if the variant has no image anyway, spare some queries by using template
            // return variant if variant.image_variant_128 else self
            */
            return default;
        }

        protected async Task<ProductTemplate> GetImagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_images(self):
            // """Return a list of records implementing `image.mixin` to
            // display on the carousel on the website for this template.
            // 
            // This returns a list and not a recordset because the records might be
            // from different models (template and image).
            // 
            // It contains in this order: the main image of the template and the
            // Template Extra Images.
            // """
            // self.ensure_one()
            // return [self] + list(self.product_template_image_ids)
            */
            return default;
        }

        public async Task<ProductTemplate> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Products'),
            //     'template': '/product/static/xls/product_template.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('purchase_product_template'):
            //     return [{
            //         'label': _('Import Template for Products'),
            //         'template': '/purchase/static/xls/product_purchase.xls'
            //     }]
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('sale_multi_pricelist_product_template'):
            //     if self.env.user.has_group('product.group_product_pricelist'):
            //         return [{
            //             'label': _("Import Template for Products"),
            //             'template': '/product/static/xls/product_template.xls'
            //         }]
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> GetIncompatibleTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_incompatible_types(self):
            // return []
            */
            return default;
        }

        protected async Task<ProductTemplate> GetLengthUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `length`, 'width', 'height' field.
            // By default, we considerer that length are expressed in millimeters. Users can configure
            // to express them in feet by adding an ir.config_parameter record with "product.volume_in_cubic_feet"
            // as key and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_foot')
            // else:
            //     return self.env.ref('uom.product_uom_millimeter')
            */
            return default;
        }

        protected async Task<ProductTemplate> GetLengthUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_name_from_ir_config_parameter(self):
            // return self._get_length_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        protected async Task<ProductTemplate> GetListPriceInternalAsync(object price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product """
            // self.ensure_one()
            // if not self.taxes_id:
            //     return super()._get_list_price(price)
            // computed_price = self.taxes_id.compute_all(price, self.currency_id)
            // total_included = computed_price["total_included"]
            // 
            // if price == total_included:
            //     # Tax is configured as price included
            //     return total_included
            // # calculate base from tax
            // included_computed_price = self.taxes_id.with_context(force_price_include=True).compute_all(price, self.currency_id)
            // return included_computed_price['total_excluded']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product.
            // To be overridden in accounting module."""
            // self.ensure_one()
            // return price
            */
            return default;
        }

        protected async Task<ProductTemplate> GetMappedAttributeNamesInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_mapped_attribute_names(self, parent_combination=None):
            // """ The name of every attribute values based on their id,
            // used to explain in the interface why that combination is not available
            // (e.g: Not available with Color: Black).
            // 
            // It contains both attribute value names from this product and from
            // the parent combination if provided.
            // """
            // self.ensure_one()
            // all_product_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // if parent_combination:
            //     all_product_attribute_values |= parent_combination
            // 
            // return {
            //     attribute_value.id: attribute_value.display_name
            //     for attribute_value in all_product_attribute_values
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetOnchangeServicePolicyUpdatesInternalAsync(object service_tracking, object service_policy, Guid project_id, Guid project_template_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_onchange_service_policy_updates(self, service_tracking, service_policy, project_id, project_template_id):
            // vals = {}
            // if service_tracking != 'no' and service_policy == 'delivered_timesheet':
            //     if project_id and not project_id.allow_timesheets:
            //         vals['project_id'] = False
            //     elif project_template_id and not project_template_id.allow_timesheets:
            //         vals['project_template_id'] = False
            // return vals
            */
            return default;
        }

        protected async Task<ProductTemplate> GetOwnAttributeExclusionsInternalAsync(List<Guid> combination_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_own_attribute_exclusions(self, combination_ids=None):
            // """Get exclusions coming from the current template.
            // 
            // :param list combination: The combination of the product, as a
            //     list of `product.template.attribute.value` ids.
            // Dictionnary, each product template attribute value is a key, and for each of them
            // the value is an array with the other ptav that they exclude (empty if no exclusion).
            // """
            // self.ensure_one()
            // product_template_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // return {
            //     ptav.id: [
            //         value.id
            //         for filter_line in ptav.exclude_for.filtered(
            //             lambda filter_line: filter_line.product_tmpl_id == self
            //         ) for value in filter_line.value_ids if value.ptav_active
            //     ]
            //     for ptav in product_template_attribute_values if (
            //         ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //     )
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetParentAttributeExclusionsInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_parent_attribute_exclusions(self, parent_combination):
            // """Get exclusions coming from the parent combination.
            // 
            // Dictionnary, each parent's ptav is a key, and for each of them the value is
            // an array with the other ptav that are excluded because of the parent.
            // """
            // self.ensure_one()
            // if not parent_combination:
            //     return {}
            // 
            // result = {}
            // for product_attribute_value in parent_combination:
            //     for filter_line in product_attribute_value.exclude_for.filtered(
            //         lambda filter_line: filter_line.product_tmpl_id == self
            //     ):
            //         # Some exclusions don't have attribute value. This means that the template is not
            //         # compatible with the parent combination. If such an exclusion is found, it means that all
            //         # attribute values are excluded.
            //         if filter_line.value_ids:
            //             result[product_attribute_value.id] = filter_line.value_ids.ids
            //         else:
            //             result[product_attribute_value.id] = filter_line.product_tmpl_id.mapped('attribute_line_ids.product_template_value_ids').ids
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return 'product/static/img/placeholder_thumbnail.png'
            // return super()._get_placeholder_filename(field)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleCombinationsInternalAsync(object parent_combination, object necessary_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_combinations(self, parent_combination=None, necessary_values=None):
            // """Generator returning combinations that are possible, following the
            // sequence of attributes and values.
            // 
            // See `_is_combination_possible` for what is a possible combination.
            // 
            // When encountering an impossible combination, try to change the value
            // of attributes by starting with the further regarding their sequences.
            // 
            // Ignore attributes that have no values.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :param necessary_values: values that must be in the returned combination
            // :type necessary_values: recordset of `product.template.attribute.value`
            // 
            // :return: the possible combinations
            // :rtype: generator of recordset of `product.template.attribute.value`
            // """
            // self.ensure_one()
            // 
            // if not self.active:
            //     return _("The product template is archived so no combination is possible.")
            // 
            // necessary_values = necessary_values or self.env['product.template.attribute.value']
            // necessary_attribute_lines = necessary_values.mapped('attribute_line_id')
            // attribute_lines = self.valid_product_template_attribute_line_ids.filtered(
            //     lambda ptal: ptal not in necessary_attribute_lines)
            // 
            // if not attribute_lines and self._is_combination_possible(necessary_values, parent_combination):
            //     yield necessary_values
            // 
            // product_template_attribute_values_per_line = []
            // for ptal in attribute_lines:
            //     if ptal.attribute_id.display_type != 'multi':
            //         values_to_add = ptal.product_template_value_ids._only_active()
            //     else:
            //         values_to_add = self.env['product.template.attribute.value']
            //     product_template_attribute_values_per_line.append(values_to_add)
            // 
            // for partial_combination in self._cartesian_product(product_template_attribute_values_per_line, parent_combination):
            //     combination = partial_combination + necessary_values
            //     if self._is_combination_possible(combination, parent_combination):
            //         yield combination
            // 
            // return _("There are no remaining possible combination.")
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleVariantsInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_variants(self, parent_combination=None):
            // """Return the existing variants that are possible.
            // 
            // For dynamic attributes, it will only return the variants that have been
            // created already.
            // 
            // If there are a lot of variants, this method might be slow. Even if there
            // aren't too many variants, for performance reasons, do not call this
            // method in a loop over the product templates.
            // 
            // Therefore this method has a very restricted reasonable use case and you
            // should strongly consider doing things differently if you consider using
            // this method.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the existing variants that are possible.
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // return self.product_variant_ids.filtered(lambda p: p._is_variant_possible(parent_combination))
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleVariantsSortedInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_possible_variants_sorted(self, parent_combination=None):
            // """Return the sorted recordset of variants that are possible.
            // 
            // The order is based on the order of the attributes and their values.
            // 
            // See `_get_possible_variants` for the limitations of this method with
            // dynamic or no_variant attributes, and also for a warning about
            // performances.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the sorted variants that are possible
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // def _sort_key_attribute_value(value):
            //     # if you change this order, keep it in sync with _order from `product.attribute`
            //     return (value.attribute_id.sequence, value.attribute_id.id)
            // 
            // def _sort_key_variant(variant):
            //     """
            //         We assume all variants will have the same attributes, with only one value for each.
            //             - first level sort: same as "product.attribute"._order
            //             - second level sort: same as "product.attribute.value"._order
            //     """
            //     keys = []
            //     for attribute in variant.product_template_attribute_value_ids.sorted(_sort_key_attribute_value):
            //         # if you change this order, keep it in sync with _order from `product.attribute.value`
            //         keys.append(attribute.product_attribute_value_id.sequence)
            //         keys.append(attribute.id)
            //     return keys
            // 
            // return self._get_possible_variants(parent_combination).sorted(_sort_key_variant)
            */
            return default;
        }

        public async Task<ProductTemplate> GetProductAccountsAsync(Guid id, object fiscal_pos)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // return {
            //     key: (fiscal_pos or self.env['account.fiscal.position']).map_account(account)
            //     for key, account in self._get_product_accounts().items()
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // """ Add the stock journal related to product to the result of super()
            // @return: dictionary which contains all needed information regarding stock accounts and journal and super (income+expense accounts)
            // """
            // accounts = super(ProductTemplate, self).get_product_accounts(fiscal_pos=fiscal_pos)
            // accounts.update({'stock_journal': self.categ_id.property_stock_journal or False})
            // return accounts
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> GetProductAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // return {
            //     'income': self.property_account_income_id or self.categ_id.property_account_income_categ_id,
            //     'expense': self.property_account_expense_id or self.categ_id.property_account_expense_categ_id
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: datev.py) ---
            // def _get_product_accounts(self):
            // """ As taxes with a different rate need a different income/expense account, we add this logic in case people only use
            //  invoicing to not be blocked by the above constraint"""
            // result = super(ProductTemplate, self)._get_product_accounts()
            // company = self.env.company
            // if company.account_fiscal_country_id.code == "DE":
            //     if not self.property_account_income_id:
            //         taxes = self.taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(company))
            //         if not result['income'] or (result['income'].tax_ids and taxes and taxes[0] not in result['income'].tax_ids):
            //             result_income = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('internal_group', '=', 'income'),
            //                 ('deprecated', '=', False),
            //                 ('tax_ids', 'in', taxes.ids)
            //             ], limit=1)
            //             result['income'] = result_income or result['income']
            //     if not self.property_account_expense_id:
            //         supplier_taxes = self.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(company))
            //         if not result['expense'] or (result['expense'].tax_ids and supplier_taxes and supplier_taxes[0] not in result['expense'].tax_ids):
            //             result_expense = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('internal_group', '=', 'expense'),
            //                 ('deprecated', '=', False),
            //                 ('tax_ids', 'in', supplier_taxes.ids),
            //             ], limit=1)
            //             result['expense'] = result_expense or result['expense']
            // return result
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // accounts = super()._get_product_accounts()
            // accounts.update({
            //     'production': self.categ_id.property_stock_account_production_cost_id,
            // })
            // return accounts
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_product_accounts(self):
            // product_accounts = super()._get_product_accounts()
            // product_accounts['downpayment'] = self.categ_id.property_account_downpayment_categ_id
            // return product_accounts
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // """ Add the stock accounts related to product to the result of super()
            // @return: dictionary which contains information regarding stock accounts and super (income+expense accounts)
            // """
            // accounts = super(ProductTemplate, self)._get_product_accounts()
            // res = self._get_asset_accounts()
            // accounts.update({
            //     'stock_input': res['stock_input'] or self.categ_id.property_stock_account_input_categ_id,
            //     'stock_output': res['stock_output'] or self.categ_id.property_stock_account_output_categ_id,
            //     'stock_valuation': self.categ_id.property_stock_valuation_account_id,
            // })
            // return accounts
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductDocumentDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // self.ensure_one()
            // return expression.OR([
            //     expression.AND([[('res_model', '=', 'product.template')], [('res_id', '=', self.id)]]),
            //     expression.AND([
            //         [('res_model', '=', 'product.product')],
            //         [('res_id', 'in', self.product_variant_ids.ids)],
            //     ])
            // ])
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // """ Override of `product` to filter out gelato print images. """
            // domain = super()._get_product_document_domain()
            // return expression.AND([domain, [('is_gelato', '=', False)]])
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductPriceContextInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_price_context(self, combination):
            // self.ensure_one()
            // res = {}
            // 
            // current_attributes_price_extra = [
            //     ptav.price_extra for ptav in combination.filtered(
            //         lambda ptav:
            //             ptav.price_extra
            //             and ptav.product_tmpl_id == self
            //     )
            // ]
            // if current_attributes_price_extra:
            //     res['current_attributes_price_extra'] = tuple(current_attributes_price_extra)
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductTypesAllowZeroPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale, FILE: product_template.py) ---
            // def _get_product_types_allow_zero_price(self):
            // return super()._get_product_types_allow_zero_price() + ["event_booth"]
            --- ODOO METHOD SOURCE (MODULE: website_event_sale, FILE: product.py) ---
            // def _get_product_types_allow_zero_price(self):
            // return super()._get_product_types_allow_zero_price() + ["event"]
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_product_types_allow_zero_price(self):
            // """
            // Returns a list of service_tracking (`product.template.service_tracking`) that can ignore the
            // `prevent_zero_price_sale` rule when buying products on a website.
            // """
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _get_product_types_allow_zero_price(self):
            // return super()._get_product_types_allow_zero_price() + ["course"]
            */
            return default;
        }

        protected async Task<ProductTemplate> GetRelatedFieldsVariantTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Return a list of fields present on template and variants models and that are related"""
            // return ['barcode', 'default_code', 'standard_price', 'volume', 'weight', 'packaging_ids', 'product_properties']
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Override of `product` to add `gelato_product_uid` as a related field. """
            // return super()._get_related_fields_variant_template() + ['gelato_product_uid']
            */
            return default;
        }

        protected async Task<ProductTemplate> GetSaleableTrackingTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // """Return list of salealbe service_tracking types.
            // 
            // :rtype: list
            // """
            // return ['no']
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // return super()._get_saleable_tracking_types() + [
            //     'task_global_project',
            //     'task_in_project',
            //     'project_only',
            // ]
            */
            return default;
        }

        protected async Task<ProductTemplate> GetSalesPricesInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_sales_prices(self, website):
            // if not self:
            //     return {}
            // 
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // fiscal_position = website.fiscal_position_id.sudo()
            // date = fields.Date.context_today(self)
            // 
            // pricelist_prices = pricelist._compute_price_rule(self, 1.0)
            // comparison_prices_enabled = self.env.user.has_group('website_sale.group_product_price_comparison')
            // 
            // res = {}
            // for template in self:
            //     pricelist_price, pricelist_rule_id = pricelist_prices[template.id]
            // 
            //     product_taxes = template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            //     taxes = fiscal_position.map_tax(product_taxes)
            // 
            //     base_price = None
            //     template_price_vals = {
            //         'price_reduce': self._apply_taxes_to_price(
            //             pricelist_price, currency, product_taxes, taxes, template, website=website,
            //         ),
            //     }
            //     pricelist_item = template.env['product.pricelist.item'].browse(pricelist_rule_id)
            //     if pricelist_item._show_discount_on_shop():
            //         pricelist_base_price = pricelist_item._compute_price_before_discount(
            //             product=template,
            //             quantity=1.0,
            //             date=date,
            //             uom=template.uom_id,
            //             currency=currency,
            //         )
            //         if currency.compare_amounts(pricelist_base_price, pricelist_price) == 1:
            //             base_price = pricelist_base_price
            //             template_price_vals['base_price'] = self._apply_taxes_to_price(
            //                 base_price, currency, product_taxes, taxes, template, website=website,
            //             )
            // 
            //     if not base_price and comparison_prices_enabled and template.compare_list_price:
            //         template_price_vals['base_price'] = template.currency_id._convert(
            //             template.compare_list_price,
            //             currency,
            //             self.env.company,
            //             date,
            //             round=False,
            //         )
            // 
            //     res[template.id] = template_price_vals
            // 
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> GetServiceToGeneralInternalAsync(object service_policy)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general(self, service_policy):
            // return self._get_service_to_general_map().get(service_policy, (False, False))
            */
            return default;
        }

        protected async Task<ProductTemplate> GetServiceToGeneralMapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     # service_policy: (invoice_policy, service_type)
            //     'ordered_prepaid': ('order', 'manual'),
            //     'delivered_milestones': ('delivery', 'milestones'),
            //     'delivered_manual': ('delivery', 'manual'),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     **super()._get_service_to_general_map(),
            //     'delivered_timesheet': ('delivery', 'timesheet'),
            //     'ordered_prepaid': ('order', 'timesheet'),
            // }
            */
            return default;
        }

        public async Task<ProductTemplate> GetSingleProductVariantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products (method is extended in sale to return optional products info)
            // 
            // Note: self.ensure_one()
            // """
            // self.ensure_one()
            // if self.product_variant_count == 1 and not self.has_configurable_attributes:
            //     return {
            //         'product_id': self.product_variant_id.id,
            //         'product_name': self.product_variant_id.display_name,
            //     }
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products """
            // res = super().get_single_product_variant()
            // if res.get('product_id', False):
            //     has_optional_products = False
            //     for optional_product in self.product_variant_id.optional_product_ids:
            //         if optional_product.has_dynamic_attributes() or optional_product._get_possible_variants(
            //             self.product_variant_id.product_template_attribute_value_ids
            //         ):
            //             has_optional_products = True
            //             break
            //     res.update({
            //         'has_optional_products': has_optional_products,
            //         'is_combo': self.type == 'combo',
            //     })
            // if self.sale_line_warn != 'no-message':
            //     res['sale_warning'] = {
            //         'type': self.sale_line_warn,
            //         'title': _("Warning for %s", self.name),
            //         'message': self.sale_line_warn_msg,
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // res = super().get_single_product_variant()
            // if self.has_configurable_attributes:
            //     res['mode'] = self.product_add_mode
            // else:
            //     res['mode'] = 'configurator'
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> GetSuitableImageSizeInternalAsync(object columns, object x_size, object y_size)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_suitable_image_size(self, columns, x_size, y_size):
            // if x_size == 1 and y_size == 1 and columns >= 3:
            //     return 'image_512'
            // return 'image_1024'
            */
            return default;
        }

        protected async Task<ProductTemplate> GetTemplateMatrixInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py) ---
            // def _get_template_matrix(self, **kwargs):
            // self.ensure_one()
            // company_id = kwargs.get('company_id', None) or self.company_id or self.env.company
            // currency_id = kwargs.get('currency_id', None) or self.currency_id
            // display_extra = kwargs.get('display_extra_price', False)
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // 
            // Attrib = self.env['product.template.attribute.value']
            // first_line_attributes = attribute_lines[0].product_template_value_ids._only_active()
            // attribute_ids_by_line = [line.product_template_value_ids._only_active().ids for line in attribute_lines]
            // 
            // header = [{"name": self.display_name}] + [
            //     attr._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra
            //     ) for attr in first_line_attributes]
            // 
            // result = [[]]
            // for pool in attribute_ids_by_line:
            //     result = [x + [y] for y in pool for x in result]
            // args = [iter(result)] * len(first_line_attributes)
            // rows = itertools.zip_longest(*args)
            // 
            // matrix = []
            // for row in rows:
            //     row_attributes = Attrib.browse(row[0][1:])
            //     row_header_cell = row_attributes._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra)
            //     result = [row_header_cell]
            // 
            //     for cell in row:
            //         combination = Attrib.browse(cell)
            //         is_possible_combination = self._is_combination_possible(combination)
            //         cell.sort()
            //         result.append({
            //             "ptav_ids": cell,
            //             "qty": 0,
            //             "is_possible_combination": is_possible_combination
            //         })
            //     matrix.append(result)
            // 
            // return {
            //     "header": header,
            //     "matrix": matrix,
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVariantForCombinationInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_for_combination(self, combination):
            // """Get the variant matching the combination.
            // 
            // All of the values in combination must be present in the variant, and the
            // variant should not have more attributes. Ignore the attributes that are
            // not supposed to create variants.
            // 
            // :param combination: recordset of `product.template.attribute.value`
            // 
            // :return: the variant if found, else empty
            // :rtype: recordset `product.product`
            // """
            // self.ensure_one()
            // filtered_combination = combination._without_no_variant_attributes()
            // return self.env['product.product'].browse(self._get_variant_id_for_combination(filtered_combination))
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVariantIdForCombinationInternalAsync(object filtered_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_id_for_combination(self, filtered_combination):
            // """See `_get_variant_for_combination`. This method returns an ID
            // so it can be cached.
            // 
            // Use sudo because the same result should be cached for all users.
            // """
            // self.ensure_one()
            // domain = [('product_tmpl_id', '=', self.id)]
            // combination_indices_ids = filtered_combination._ids2str()
            // 
            // if combination_indices_ids:
            //     domain = expression.AND([domain, [('combination_indices', '=', combination_indices_ids)]])
            // else:
            //     domain = expression.AND([domain, [('combination_indices', 'in', ['', False])]])
            // 
            // return self.env['product.product'].sudo().with_context(active_test=False).search(domain, order='active DESC', limit=1).id
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVolumeUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `volume` field. By default, we consider
            // that volumes are expressed in cubic meters. Users can configure to express them in cubic feet
            // by adding an ir.config_parameter record with "product.volume_in_cubic_feet" as key
            // and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_cubic_foot')
            // else:
            //     return self.env.ref('uom.product_uom_cubic_meter')
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVolumeUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_name_from_ir_config_parameter(self):
            // return self._get_volume_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWebsiteAccessoryProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_accessory_product(self):
            // domain = self.env['website'].sale_product_domain()
            // if not self.env.user._is_internal():
            //     domain = expression.AND([domain, [('is_published', '=', True)]])
            // return self.accessory_product_ids.filtered_domain(domain)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWebsiteAlternativeProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_alternative_product(self):
            // domain = self.env['website'].sale_product_domain()
            // return self.alternative_product_ids.filtered_domain(domain)
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWeightUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `weight` field. By default, we considerer
            // that weights are expressed in kilograms. Users can configure to express them in pounds
            // by adding an ir.config_parameter record with "product.product_weight_in_lbs" as key
            // and "1" as value.
            // """
            // product_weight_in_lbs_param = self.env['ir.config_parameter'].sudo().get_param('product.weight_in_lbs')
            // if product_weight_in_lbs_param == '1':
            //     return self.env.ref('uom.product_uom_lb')
            // else:
            //     return self.env.ref('uom.product_uom_kgm')
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWeightUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_name_from_ir_config_parameter(self):
            // return self._get_weight_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<ProductTemplate> HasDynamicAttributesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def has_dynamic_attributes(self):
            // """Return whether this `product.template` has at least one dynamic
            // attribute.
            // 
            // :return: True if at least one dynamic attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'dynamic' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> HasIsCustomValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_is_custom_values(self):
            // self.ensure_one()
            // """Return whether this `product.template` has at least one is_custom
            // attribute value.
            // 
            // :return: True if at least one is_custom attribute value, False otherwise
            // :rtype: bool
            // """
            // return any(v.is_custom for v in self.valid_product_template_attribute_line_ids.product_template_value_ids._only_active())
            */
            return default;
        }

        protected async Task<ProductTemplate> HasNoVariantAttributesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_no_variant_attributes(self):
            // """Return whether this `product.template` has at least one no_variant
            // attribute.
            // 
            // :return: True if at least one no_variant attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'no_variant' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            return default;
        }

        protected async Task<ProductTemplate> InitColumnInternalAsync(object column_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _init_column(self, column_name):
            // # to avoid generating a single default website_sequence when installing the module,
            // # we need to set the default row by row for this column
            // if column_name == "website_sequence":
            //     _logger.debug("Table '%s': setting default value of new column %s to unique values for each row", self._table, column_name)
            //     self.env.cr.execute("SELECT id FROM %s WHERE website_sequence IS NULL" % self._table)
            //     prod_tmpl_ids = self.env.cr.dictfetchall()
            //     max_seq = self._default_website_sequence()
            //     query = """
            //         UPDATE {table}
            //         SET website_sequence = p.web_seq
            //         FROM (VALUES %s) AS p(p_id, web_seq)
            //         WHERE id = p.p_id
            //     """.format(table=self._table)
            //     values_args = [(prod_tmpl['id'], max_seq + i * 5) for i, prod_tmpl in enumerate(prod_tmpl_ids)]
            //     self.env.cr.execute_values(query, values_args)
            // else:
            //     super()._init_column(column_name)
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseGelatoProductUidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _inverse_gelato_product_uid(self):
            // self._set_product_variant_field('gelato_product_uid')
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _inverse_service_policy(self):
            // for product in self:
            //     if product.service_policy:
            //         product.invoice_policy, product.service_type = self._get_service_to_general(product.service_policy)
            */
            return default;
        }

        protected async Task<ProductTemplate> IsAddToCartPossibleInternalAsync(object parent_combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _is_add_to_cart_possible(self, parent_combination=None):
            // """
            // It's possible to add to cart (potentially after configuration) if
            // there is at least one possible combination.
            // 
            // :param parent_combination: the combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: True if it's possible to add to cart, else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // if not self.active or not self._can_be_added_to_cart():
            //     # for performance: avoid calling `_get_possible_combinations`
            //     return False
            // return next(self._get_possible_combinations(parent_combination), False) is not False
            */
            return default;
        }

        protected async Task<ProductTemplate> IsCombinationPossibleByConfigInternalAsync(object combination, object ignore_no_variant)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible_by_config(self, combination, ignore_no_variant=False):
            // """Return whether the given combination is possible according to the config of attributes on the template
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :return: wether the given combination is possible according to the config of attributes on the template
            // :rtype: bool
            // """
            // self.ensure_one()
            // # Returns False on StopIteration. Empty combination should return True.
            // return isinstance(next(self._filter_combinations_impossible_by_config([combination], ignore_no_variant), False), models.BaseModel)
            */
            return default;
        }

        protected async Task<ProductTemplate> IsCombinationPossibleInternalAsync(object combination, object parent_combination, object ignore_no_variant)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible(self, combination, parent_combination=None, ignore_no_variant=False):
            // """
            // The combination is possible if it is not excluded by any rule
            // coming from the current template, not excluded by any rule from the
            // parent_combination (if given), and there should not be any archived
            // variant with the exact same combination.
            // 
            // If the template does not have any dynamic attribute, the combination
            // is also not possible if the matching variant has been deleted.
            // 
            // Moreover the attributes of the combination must excatly match the
            // attributes allowed on the template.
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: whether the combination is possible
            // :rtype: bool
            // """
            // self.ensure_one()
            // 
            // if not self._is_combination_possible_by_config(combination, ignore_no_variant):
            //     return False
            // 
            // variant = self._get_variant_for_combination(combination)
            // 
            // if self.has_dynamic_attributes():
            //     if variant and not variant.active:
            //         # dynamic and the variant has been archived
            //         return False
            // else:
            //     if not variant or not variant.active:
            //         # not dynamic, the variant has been archived or deleted
            //         return False
            // 
            // parent_exclusions = self._get_parent_attribute_exclusions(parent_combination)
            // if parent_exclusions:
            //     # parent_exclusion are mapped by ptav but here we don't need to know
            //     # where the exclusion comes from so we loop directly on the dict values
            //     for exclusions_values in parent_exclusions.values():
            //         for exclusion in exclusions_values:
            //             if exclusion in combination.ids:
            //                 return False
            // 
            // return True
            */
            return default;
        }

        protected async Task<ProductTemplate> IsInWishlistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _is_in_wishlist(self):
            // self.ensure_one()
            // return self in self.env['product.wishlist'].current().mapped('product_id.product_tmpl_id')
            */
            return default;
        }

        protected async Task<ProductTemplate> IsSoldOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _is_sold_out(self):
            // return self.is_storable and self.product_variant_id._is_sold_out()
            */
            return default;
        }

        protected async Task<ProductTemplate> OnChangeAvailableInPosInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _on_change_available_in_pos(self):
            // for record in self:
            //     if not record.available_in_pos:
            //         record.self_order_available = False
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeAvailableInPosInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_available_in_pos(self):
            // if self.available_in_pos and not self.sale_ok:
            //     self.sale_ok = True
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeDefaultCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_default_code(self):
            // if not self.default_code:
            //     return
            // 
            // domain = [('default_code', '=', self.default_code)]
            // if self.id.origin:
            //     domain.append(('id', '!=', self.id.origin))
            // 
            // if self.env['product.template'].search_count(domain, limit=1):
            //     return {'warning': {
            //         'title': _("Note:"),
            //         'message': _("The Internal Reference '%s' already exists.", self.default_code),
            //     }}
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeSaleOkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_sale_ok(self):
            // if not self.sale_ok:
            //     self.available_in_pos = False
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_fields(self):
            // for record in self:
            //     default_uom_id = self.env['ir.default']._get_model_defaults('product.template').get('uom_id')
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
            //         record.uom_id = self.default_get(['uom_id']).get('uom_id')
            //     record.uom_po_id = record.uom_id
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_policy(self):
            // self._inverse_service_policy()
            // vals = self._get_onchange_service_policy_updates(self.service_tracking,
            //                                                 self.service_policy,
            //                                                 self.project_id,
            //                                                 self.project_template_id)
            // if vals:
            //     self.update(vals)
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceToPurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _onchange_service_to_purchase(self):
            // products_template = self.filtered(lambda p: p.type != 'service' or p.expense_policy != 'no')
            // products_template.service_to_purchase = False
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
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

        protected async Task<ProductTemplate> OnchangeStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _onchange_standard_price(self):
            //         if self.lot_valuated and any(p.quantity_svl for p in self.product_variant_ids):
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

        protected async Task<ProductTemplate> OnchangeTrackingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_tracking(self):
            // return self.mapped('product_variant_ids')._onchange_tracking()
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeEventBoothInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _onchange_type_event_booth(self):
            // if self.service_tracking == 'event_booth':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeEventInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _onchange_type_event(self):
            // if self.service_tracking == 'event':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     self.taxes_id = False
            //     self.supplier_taxes_id = False
            // return super()._onchange_type()
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     if self.attribute_line_ids:
            //         raise UserError(_("Combo products can't have attributes."))
            //     combo_items = self.env['product.combo.item'].sudo().search([
            //         ('product_id', 'in', self.product_variant_ids.ids)
            //     ])
            //     if combo_items:
            //         raise UserError(_(
            //             "This product is part of a combo, so its type can't be changed to \"combo\"."
            //         ))
            //     self.purchase_ok = False
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _onchange_type(self):
            // res = super()._onchange_type()
            // if self._origin and self.sales_count > 0:
            //     res['warning'] = {
            //         'title': _("Warning"),
            //         'message': _("You cannot change the product's type because it is already used in sales orders.")
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_type(self):
            // # Return a warning when trying to change the product type
            // res = super()._onchange_type()
            // if self.ids and self.product_variant_ids.ids and self.env['stock.move.line'].sudo().search_count([
            //     ('product_id', 'in', self.product_variant_ids.ids), ('state', '!=', 'cancel')
            // ]):
            //     res['warning'] = {
            //         'title': _('Warning!'),
            //         'message': _(
            //             'This product has been used in at least one inventory movement. '
            //             'It is not advised to change the Product Type since it can lead to inconsistencies. '
            //             'A better solution could be to archive the product and create a new one instead.'
            //         )
            //     }
            // return res
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_uom_id(self):
            // if self.uom_id:
            //     self.uom_po_id = self.uom_id.id
            */
            return default;
        }

        public async Task<ProductTemplate> OpenDocumentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_documents(self):
            // self.ensure_one()
            // return {
            //     'name': _('Documents'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'product.document',
            //     'view_mode': 'kanban,list,form',
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.id,
            //         'default_company_id': self.company_id.id,
            //     },
            //     'domain': self._get_product_document_domain(),
            //     'target': 'current',
            //     'help': """
            //         <p class="o_view_nocontent_smiling_face">
            //             %s
            //         </p>
            //         <p>
            //             %s
            //             <br/>
            //             %s
            //         </p>
            //         <p>
            //             <a class="oe_link" href="https://www.odoo.com/documentation/18.0/_downloads/c2c6ce32294dfddffcfefcf2775f7a09/pdfquotebuilderexamples.zip">
            //             %s
            //             </a>
            //         </p>
            //     """ % (
            //         _("Upload files to your product"),
            //         _("Use this feature to store any files you would like to share with your customers"),
            //         _("(e.g: product description, ebook, legal notice, ...)."),
            //         _("Download examples")
            //     )
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> OpenLabelLayoutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_label_layout(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_tmpl_ids': self.ids}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> OpenPricelistRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def open_pricelist_rules(self):
            // self.ensure_one()
            // domain = ['|',
            //     ('product_tmpl_id', '=', self.id),
            //     ('product_id', 'in', self.product_variant_ids.ids),
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
            //         'default_product_tmpl_id': self.id,
            //         'default_applied_on': '1_product',
            //         'product_without_variants': self.product_variant_count == 1,
            //         'search_default_visible': True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> OpenProductLotAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_product_lot(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_product_production_lot_form")
            // action['domain'] = [
            //     ('product_id.product_tmpl_id', '=', self.id),
            //     '|', ('location_id', '=', False),
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self._context['allowed_company_ids']))
            // ]
            // action['context'] = {
            //     'default_product_tmpl_id': self.id,
            //     'search_default_group_by_location': True,
            // }
            // if self.product_variant_count == 1:
            //     action['context'].update({
            //         'default_product_id': self.product_variant_id.id,
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> OpenQuantsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_quants(self):
            // if 'product_variant' in self.env.context:
            //     return self.env['product.product'].browse(self.env.context['default_product_id']).action_open_quants()
            // return self.product_variant_ids.filtered(lambda p: p.active or p.qty_available != 0).action_open_quants()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> OpenRoutesDiagramAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_routes_diagram(self):
            // products = False
            // if self.env.context.get('default_product_id'):
            //     products = self.env['product.product'].browse(self.env.context['default_product_id'])
            // if not products and self.env.context.get('default_product_tmpl_id'):
            //     products = self.env['product.template'].browse(self.env.context['default_product_tmpl_id']).product_variant_ids
            // if not self.env.user.has_group('stock.group_stock_multi_warehouses') and len(products) == 1:
            //     company = products.company_id or self.env.company
            //     warehouse = self.env['stock.warehouse'].search([('company_id', '=', company.id)], limit=1)
            //     return self.env.ref('stock.action_report_stock_rule').report_action(None, data={
            //         'product_id': products.id,
            //         'warehouse_ids': warehouse.ids,
            //     }, config=False)
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_stock_rules_report")
            // action['context'] = self.env.context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> PrepareInvoicingTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.invoice_policy == 'delivery':
            //     return _("Invoice after delivery, based on quantities delivered, not ordered.")
            // elif self.invoice_policy == 'order':
            //     if self.type == 'consu':
            //         return _("You can invoice goods before they are delivered.")
            //     elif self.type == 'service':
            //         return _("Invoice ordered quantities as soon as this service is sold.")
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_milestones':
            //     return _("Invoice your milestones when they are reached.")
            // # ordered_prepaid and delivered_manual are handled in the super call, according to the
            // # corresponding value in the `invoice_policy` field (delivered/ordered quantities)
            // return super()._prepare_invoicing_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_timesheet':
            //     return _("Invoice based on timesheets (delivered quantity).")
            // return super()._prepare_invoicing_tooltip()
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareServiceTrackingTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event_booth':
            //     return _("Mark the selected Booth as Unavailable.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event':
            //     return _("Create an Attendee for the selected Event.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'task_global_project':
            //     return _("Create a task in an existing project to track the time spent.")
            // elif self.service_tracking == 'project_only':
            //     return _(
            //         "Create an empty project for the order to track the time spent."
            //     )
            // elif self.service_tracking == 'task_in_project':
            //     return _(
            //         "Create a project for the order with a task for each sales order line "
            //         "to track the time spent."
            //     )
            // elif self.service_tracking == 'no':
            //     return _(
            //         "Create projects or tasks later, and link them to order to track the time spent."
            //     )
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'course':
            //     return _("Grant access to the eLearning course linked to this product.")
            // return super()._prepare_service_tracking_tooltip()
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // self.ensure_one()
            // tooltip = ""
            // if self.type == 'combo':
            //     tooltip = _(
            //         "Combos allow to choose one product amongst a selection of choices per category."
            //     )
            // return tooltip
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // tooltip = super()._prepare_tooltip()
            // if not self.sale_ok:
            //     return tooltip
            // 
            // invoicing_tooltip = self._prepare_invoicing_tooltip()
            // 
            // tooltip = f'{tooltip} {invoicing_tooltip}' if tooltip else invoicing_tooltip
            // 
            // if self.type == 'service':
            //     additional_tooltip = self._prepare_service_tracking_tooltip()
            //     tooltip = f'{tooltip} {additional_tooltip}' if additional_tooltip else tooltip
            // 
            // return tooltip
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareVariantValuesInternalAsync(object combination)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _prepare_variant_values(self, combination):
            // self.ensure_one()
            // return {
            //     'product_tmpl_id': self.id,
            //     'product_template_attribute_value_ids': [(6, 0, combination.ids)],
            //     'active': self.active
            // }
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _prepare_variant_values(self, combination):
            // variant_dict = super()._prepare_variant_values(combination)
            // variant_dict['base_unit_count'] = self.base_unit_count
            // return variant_dict
            */
            return default;
        }

        protected async Task<ProductTemplate> PriceComputeInternalAsync(object price_type, object uom, object currency, object company, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
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
            // for template in self:
            //     price = template[price_type] or 0.0
            //     price_currency = template.currency_id
            //     if price_type == 'standard_price':
            //         if not price and template.product_variant_ids:
            //             price = template.product_variant_ids[0].standard_price
            //         price_currency = template.cost_currency_id
            //     elif price_type == 'list_price':
            //         price += template._get_attributes_extra_price()
            // 
            //     if uom:
            //         price = template.uom_id._compute_price(price, uom)
            // 
            //     # Convert from current user company currency to asked one
            //     # This is right cause a field cannot be in more than one currency
            //     if currency:
            //         price = price_currency._convert(price, currency, company, date)
            // 
            //     prices[template.id] = price
            // return prices
            */
            return default;
        }

        public async Task<ProductTemplate> ProductTmplForecastReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_product_tmpl_forecast_report(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('stock.stock_forecasted_product_template_action')
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> RatingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super()._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            */
            return default;
        }

        protected async Task<ProductTemplate> ReadGroupCategIdInternalAsync(object categories, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _read_group_categ_id(self, categories, domain):
            // category_ids = self.env.context.get('default_categ_id')
            // if not category_ids and self.env.context.get('group_expand'):
            //     category_ids = categories.sudo()._search([], order=categories._order)
            // return categories.browse(category_ids)
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchBarcodeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_barcode(self, operator, value):
            // subquery = self.with_context(active_test=False)._search([
            //     ('product_variant_ids.barcode', operator, value),
            // ])
            // return [('id', 'in', subquery)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_display_name(self, operator, value):
            // domain = super()._search_display_name(operator, value)
            // if self.env.context.get('search_product_product', bool(value)):
            //     combine = expression.OR if operator not in expression.NEGATIVE_TERM_OPERATORS else expression.AND
            //     domain = combine([domain, [('product_variant_ids', operator, value)]])
            // return domain
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_image = options['displayImage']
            // with_description = options['displayDescription']
            // with_category = options['displayExtraLink']
            // with_price = options['displayDetail']
            // domains = [website.sale_product_domain()]
            // category = options.get('category')
            // tags = options.get('tags')
            // min_price = options.get('min_price')
            // max_price = options.get('max_price')
            // attrib_values = options.get('attrib_values')
            // if category:
            //     domains.append([('public_categ_ids', 'child_of', self.env['ir.http']._unslug(category)[1])])
            // if tags:
            //     if isinstance(tags, str):
            //         tags = tags.split(',')
            //     domains.append([('product_variant_ids.all_product_tag_ids', 'in', tags)])
            // if min_price:
            //     domains.append([('list_price', '>=', min_price)])
            // if max_price:
            //     domains.append([('list_price', '<=', max_price)])
            // if attrib_values:
            //     domains.extend(self._get_attrib_values_domain(attrib_values))
            // search_fields = ['name', 'default_code', 'product_variant_ids.default_code']
            // fetch_fields = ['id', 'name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'default_code': {'name': 'default_code', 'type': 'text', 'match': True},
            //     'product_variant_ids.default_code': {'name': 'product_variant_ids.default_code', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_image:
            //     mapping['image_url'] = {'name': 'image_url', 'type': 'html'}
            // if with_description:
            //     # Internal note is not part of the rendering.
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     search_fields.append('description_sale')
            //     fetch_fields.append('description_sale')
            //     mapping['description'] = {'name': 'description_sale', 'type': 'text', 'match': True}
            // if with_price:
            //     mapping['detail'] = {'name': 'price', 'type': 'html', 'display_currency': options['display_currency']}
            //     mapping['detail_strike'] = {'name': 'list_price', 'type': 'html', 'display_currency': options['display_currency']}
            // if with_category:
            //     mapping['extra_link'] = {'name': 'category', 'type': 'html'}
            // return {
            //     'model': 'product.template',
            //     'base_domain': domains,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-shopping-cart',
            // }
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchIncomingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_incoming_qty(self, operator, value):
            // domain = [('incoming_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchIsKitsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // assert operator in ('=', '!='), 'Unsupported operator'
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('active', '=', True)])
            // neg = ''
            // if (operator == '=' and not value) or (operator == '!=' and value):
            //     neg = 'not '
            // return [('id', neg + 'in', bom_tmpl_query.subselect('product_tmpl_id'))]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchOutgoingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_outgoing_qty(self, operator, value):
            // domain = [('outgoing_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchQtyAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available(self, operator, value):
            // domain = [('qty_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_image = 'image_url' in mapping
            // with_category = 'extra_link' in mapping
            // with_price = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // current_website = self.env['website'].get_current_website()
            // for product, data in zip(self, results_data):
            //     categ_ids = product.public_categ_ids.filtered(lambda c: not c.website_id or c.website_id == current_website)
            //     if with_price:
            //         combination_info = product._get_combination_info(only_template=True)
            //         data['price'], list_price = self._search_render_results_prices(
            //             mapping, combination_info
            //         )
            //         if list_price:
            //             data['list_price'] = list_price
            // 
            //     if with_image:
            //         data['image_url'] = '/web/image/product.template/%s/image_128' % data['id']
            //     if with_category and categ_ids:
            //         data['category'] = self.env['ir.ui.view'].sudo()._render_template(
            //             "website_sale.product_category_extra_link",
            //             {'categories': categ_ids, 'slug': self.env['ir.http']._slug}
            //         )
            // return results_data
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchRenderResultsPricesInternalAsync(object mapping, object combination_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results_prices(self, mapping, combination_info):
            // if combination_info.get('prevent_zero_price_sale'):
            //     website = self.env['website'].get_current_website()
            //     return website.prevent_zero_price_sale_text, None
            // 
            // monetary_options = {'display_currency': mapping['detail']['display_currency']}
            // price = self.env['ir.qweb.field.monetary'].value_to_html(
            //     combination_info['price'], monetary_options
            // )
            // list_price = None
            // if combination_info['has_discounted_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['list_price'], monetary_options
            //     )
            // if combination_info['compare_list_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['compare_list_price'], monetary_options
            //     )
            // 
            // return price, list_price
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchStandardPriceInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_standard_price(self, operator, value):
            // return [('product_variant_ids.standard_price', operator, value)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchVirtualAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_virtual_available(self, operator, value):
            // domain = [('virtual_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        protected async Task<ProductTemplate> SelectionServicePolicyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = [
            //     # (service_policy, string)
            //     ('ordered_prepaid', _('Prepaid/Fixed Price')),
            //     ('delivered_manual', _('Based on Delivered Quantity (Manual)')),
            // ]
            // 
            // user = self.env['res.users'].sudo().browse(SUPERUSER_ID)
            // if (self.env.user.has_group('project.group_project_milestone') or
            //         (self.env.user.has_group('base.group_public') and user.has_group('project.group_project_milestone'))
            // ):
            //     service_policies.insert(1, ('delivered_milestones', _('Based on Milestones')))
            // return service_policies
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = super()._selection_service_policy()
            // service_policies.insert(1, ('delivered_timesheet', _('Based on Timesheets')))
            // return service_policies
            */
            return default;
        }

        protected async Task<ProductTemplate> ServiceTrackingBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event_booth']
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // """ Service tracking field is used to distinguish some specific categories of products.
            // Those products shouldn't be displayed or used in unrelated applications.
            // This method returns a domain targeting all those specific products (events, courses, ...).
            // """
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['course']
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBarcodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_barcode(self):
            // self._set_product_variant_field('barcode')
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBaseUnitCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_count(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_count = template.base_unit_count
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBaseUnitIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_id(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_id = template.base_unit_id
            */
            return default;
        }

        protected async Task<ProductTemplate> SetDefaultCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_default_code(self):
            // self._set_product_variant_field('default_code')
            */
            return default;
        }

        protected async Task<ProductTemplate> SetL10nEgEtaCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: product_template.py) ---
            // def _set_l10n_eg_eta_code(self):
            // if len(self.product_variant_ids) == 1:
            //     self.product_variant_ids.l10n_eg_eta_code = self.l10n_eg_eta_code
            */
            return default;
        }

        protected async Task<ProductTemplate> SetPackagingIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.product_variant_ids.packaging_ids = p.packaging_ids
            */
            return default;
        }

        protected async Task<ProductTemplate> SetProductVariantFieldInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_product_variant_field(self, fname):
            // """Propagate the value of the given field from the templates to their unique variant.
            // 
            // Only if it's a single variant product.
            // It's used to set fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field whose value should be propagated to the variant.
            //     (field name must be identical between product.product & product.template models)
            // """
            // for template in self:
            //     count = len(template.product_variant_ids)
            //     if count == 1:
            //         template.product_variant_ids[fname] = template[fname]
            //     elif count == 0:
            //         archived_variants = self.with_context(active_test=False).product_variant_ids
            //         if len(archived_variants) == 1:
            //             archived_variants[fname] = template[fname]
            */
            return default;
        }

        public async Task<ProductTemplate> SetSequenceBottomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_bottom(self):
            // max_sequence = self.sudo().search([], order='website_sequence DESC', limit=1)
            // self.website_sequence = max_sequence.website_sequence + 5
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> SetSequenceDownAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_down(self):
            // next_prodcut_tmpl = self.search([
            //     ('website_sequence', '>', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence ASC', limit=1)
            // if next_prodcut_tmpl:
            //     next_prodcut_tmpl.website_sequence, self.website_sequence = self.website_sequence, next_prodcut_tmpl.website_sequence
            // else:
            //     return self.set_sequence_bottom()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> SetSequenceTopAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_top(self):
            // min_sequence = self.sudo().search([], order='website_sequence ASC', limit=1)
            // self.website_sequence = min_sequence.website_sequence - 5
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> SetSequenceUpAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_up(self):
            // previous_product_tmpl = self.sudo().search([
            //     ('website_sequence', '<', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence DESC', limit=1)
            // if previous_product_tmpl:
            //     previous_product_tmpl.website_sequence, self.website_sequence = self.website_sequence, previous_product_tmpl.website_sequence
            // else:
            //     self.set_sequence_top()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> SetStandardPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_standard_price(self):
            // self._set_product_variant_field('standard_price')
            */
            return default;
        }

        protected async Task<ProductTemplate> SetVolumeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_volume(self):
            // self._set_product_variant_field('volume')
            */
            return default;
        }

        protected async Task<ProductTemplate> SetWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_weight(self):
            // self._set_product_variant_field('weight')
            */
            return default;
        }

        public async Task<ProductTemplate> SyncGelatoTemplateInfoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def action_sync_gelato_template_info(self):
            // """ Fetch the template information from Gelato and update the product template accordingly.
            // 
            // :return: The action to display a toast notification to the user.
            // :rtype: dict
            // """
            // # Fetch the template info from Gelato.
            // try:
            //     endpoint = f'templates/{self.gelato_template_ref}'
            //     template_info = utils.make_request(
            //         self.env.company.sudo().gelato_api_key, 'ecommerce', 'v1', endpoint, method='GET'
            //     )  # In sudo mode to read the API key from the company.
            // except UserError as e:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'title': _("Could not synchronize with Gelato"),
            //             'message': str(e),
            //             'sticky': True,
            //         }
            //     }
            // 
            // # Apply the necessary changes on the product template.
            // self._create_attributes_from_gelato_info(template_info)
            // self._create_print_images_from_gelato_info(template_info)
            // 
            // # Display a toaster notification to the user if all went well.
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'title': _("Successfully synchronized with Gelato"),
            //         'message': _("Missing product variants and images have been successfully created."),
            //         'sticky': False,
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload'
            //         }
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> UnlinkExceptLoyaltyProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_template.py) ---
            // def _unlink_except_loyalty_products(self):
            // product_data = [
            //     self.env.ref('loyalty.gift_card_product_50', False),
            //     self.env.ref('loyalty.ewallet_product_50', False),
            // ]
            // for product in self.filtered(lambda p: p.product_variant_id in product_data):
            //     raise UserError(_(
            //         "You cannot delete %(name)s as it is used in 'Coupons & Loyalty'."
            //         " Please archive it instead.",
            //         name=product.with_context(display_default_code=False).display_name
            //     ))
            */
            return default;
        }

        protected async Task<ProductTemplate> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _unlink_except_master_data(self):
            // time_product = self.env.ref('sale_timesheet.time_product')
            // if time_product.product_tmpl_id in self:
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            */
            return default;
        }

        protected async Task<ProductTemplate> UnlinkExceptOpenSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _unlink_except_open_session(self):
            // product_ctx = dict(self.env.context or {}, active_test=False)
            // if self.with_context(product_ctx).search_count([('id', 'in', self.ids), ('available_in_pos', '=', True)]):
            //     if self.env['pos.session'].sudo().search_count([('state', '!=', 'closed')]):
            //         raise UserError(_(
            //             "To delete a product, make sure all point of sale sessions are closed.\n\n"
            //             "Deleting a product available in a session would be like attempting to snatch a hamburger from a customer’s hand mid-bite; chaos will ensue as ketchup and mayo go flying everywhere!",
            //         ))
            */
            return default;
        }

        public async Task<ProductTemplate> UpdateQuantityOnHandAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_update_quantity_on_hand(self):
            // advanced_option_groups = [
            //     'stock.group_stock_multi_locations',
            //     'stock.group_tracking_owner',
            //     'stock.group_tracking_lot'
            // ]
            // if any(self.env.user.has_group(g) for g in advanced_option_groups) or self.tracking != 'none':
            //     return self.action_open_quants()
            // else:
            //     default_product_id = self.env.context.get('default_product_id', len(self.product_variant_ids) == 1 and self.product_variant_id.id)
            //     action = self.env["ir.actions.actions"]._for_xml_id("stock.action_change_product_quantity")
            //     action['context'] = dict(
            //         self.env.context,
            //         default_product_id=default_product_id,
            //         default_product_tmpl_id=self.id
            //     )
            //     return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> UsedInBomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_used_in_bom(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_bom_form_action")
            // action['domain'] = [('bom_line_ids.product_tmpl_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewMosAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_view_mos(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_production_action")
            // action['domain'] = [('state', '=', 'done'), ('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'search_default_filter_plan_date': 1,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewOrderpointsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_orderpoints(self):
            // return self.product_variant_ids.action_view_orderpoints()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewPoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def action_view_po(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = [
            //     ('state', 'in', ['purchase', 'done']),
            //     ('product_id', 'in', self.with_context(active_test=False).product_variant_ids.ids),
            // ]
            // action['display_name'] = _("Purchase History for %s", self.display_name)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewRelatedPutawayRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_related_putaway_rules(self):
            // self.ensure_one()
            // domain = [
            //     '|',
            //         ('product_id.product_tmpl_id', '=', self.id),
            //         ('category_id', '=', self.categ_id.id),
            // ]
            // return self._get_action_view_related_putaway_rules(domain)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewSalesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def action_view_sales(self):
            // action = self.env['ir.actions.actions']._for_xml_id('sale.report_all_channels_sales_action')
            // action['domain'] = [('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'pivot_measures': ['product_uom_qty'],
            //     'active_id': self._context.get('active_id'),
            //     'active_model': 'sale.report',
            //     'search_default_Sales': 1,
            //     'search_default_filter_order_date': 1,
            //     'search_default_group_by_date': 1,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewStockMoveLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_stock_move_lines(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_move_line_action")
            // action['domain'] = [('product_id.product_tmpl_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductTemplate> ViewStorageCategoryCapacityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_storage_category_capacity(self):
            // self.ensure_one()
            // return self.product_variant_ids.action_view_storage_category_capacity()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductTemplate> WebsiteShowQuickAddInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _website_show_quick_add(self):
            // self.ensure_one()
            // # TODO VFE pass website as param and avoid existence check
            // website = self.env['website'].get_current_website()
            // return self.sale_ok and (not website.prevent_zero_price_sale or self._get_contextual_price())
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _website_show_quick_add(self):
            // return (self.allow_out_of_stock_order or not self._is_sold_out()) and super()._website_show_quick_add()
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProductTemplate entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def write(self, values):
            // if 'active' in values:
            //     self.filtered(lambda p: p.active != values['active']).with_context(active_test=False).bom_ids.write({
            //         'active': values['active']
            //     })
            // return super().write(values)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def write(self, vals_list):
            // if 'available_in_pos' in vals_list:
            //     if not vals_list['available_in_pos']:
            //         vals_list['self_order_available'] = False
            // 
            // res = super().write(vals_list)
            // 
            // if 'self_order_available' in vals_list:
            //     for record in self:
            //         for product in record.product_variant_ids:
            //             product._send_availability_status()
            // return res
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def write(self, vals):
            // res = super(ProductTemplate, self).write(vals)
            // if self._context.get("create_product_product", True) and 'attribute_line_ids' in vals or (vals.get('active') and len(self.product_variant_ids) == 0):
            //     self._create_variant_ids()
            // if 'active' in vals and not vals.get('active'):
            //     self.with_context(active_test=False).mapped('product_variant_ids').write({'active': vals.get('active')})
            // if 'image_1920' in vals:
            //     self.env['product.product'].invalidate_model([
            //         'image_1920',
            //         'image_1024',
            //         'image_512',
            //         'image_256',
            //         'image_128',
            //         'can_image_1024_be_zoomed',
            //     ])
            // for product_template in self:
            //     if "type" in vals and vals.get("type") != "combo":
            //         product_template.combo_ids = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def write(self, vals):
            // if 'type' in vals and vals['type'] != 'service':
            //     vals.update({
            //         'service_tracking': 'no',
            //         'project_id': False
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def write(self, vals):
            // # timesheet product can't be archived or linked to a company
            // test_mode = getattr(threading.current_thread(), 'testing', False) or self.env.registry.in_test_mode()
            // if not test_mode and 'active' in vals and not vals['active']:
            //     time_product = self.env.ref('sale_timesheet.time_product')
            //     if time_product.product_tmpl_id in self:
            //         raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            // # TODO: avoid duplicate code by joining both conditions in master
            // if not test_mode and 'company_id' in vals and vals['company_id']:
            //     time_product = self.env.ref('sale_timesheet.time_product')
            //     if time_product.product_tmpl_id in self:
            //         raise ValidationError(_('The %s product is required by the Timesheets app and cannot be linked to a company.', time_product.name))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def write(self, vals):
            // if 'company_id' in vals and vals['company_id']:
            //     products_changing_company = self.filtered(lambda product: product.company_id.id != vals['company_id'])
            //     if products_changing_company:
            //         move = self.env['stock.move'].sudo().search([
            //             ('product_id', 'in', products_changing_company.product_variant_ids.ids),
            //             ('company_id', 'not in', [vals['company_id'], False]),
            //         ], order=None, limit=1)
            //         if move:
            //             raise UserError(_("This product's company cannot be changed as long as there are stock moves of it belonging to another company."))
            // 
            //         # Forbid changing a product's company when quant(s) exist in another company.
            //         quant = self.env['stock.quant'].sudo().search([
            //             ('product_id', 'in', products_changing_company.product_variant_ids.ids),
            //             ('company_id', 'not in', [vals['company_id'], False]),
            //             ('quantity', '!=', 0),
            //         ], order=None, limit=1)
            //         if quant:
            //             raise UserError(_("This product's company cannot be changed as long as there are quantities of it belonging to another company."))
            // 
            // if 'uom_id' in vals:
            //     new_uom = self.env['uom.uom'].browse(vals['uom_id'])
            //     updated = self.filtered(lambda template: template.uom_id != new_uom)
            //     done_moves = self.env['stock.move'].sudo().search([('product_id', 'in', updated.with_context(active_test=False).mapped('product_variant_ids').ids)], limit=1)
            //     if done_moves:
            //         raise UserError(_("You cannot change the unit of measure as there are already stock moves for this product. If you want to change the unit of measure, you should rather archive this product and create a new one."))
            // if 'is_storable' in vals and not vals['is_storable'] and sum(self.mapped('nbr_reordering_rules')) != 0:
            //     raise UserError(_('You still have some active reordering rules on this product. Please archive or delete them first.'))
            // if any('is_storable' in vals and vals['is_storable'] != prod_tmpl.is_storable for prod_tmpl in self):
            //     existing_done_move_lines = self.env['stock.move.line'].sudo().search([
            //         ('product_id', 'in', self.with_context(active_test=False).mapped('product_variant_ids').ids),
            //         ('state', '=', 'done'),
            //     ], limit=1)
            //     if existing_done_move_lines:
            //         raise UserError(_("You can not change the inventory tracking of a product that was already used."))
            //     existing_reserved_move_lines = self.env['stock.move.line'].sudo().search([
            //         ('product_id', 'in', self.with_context(active_test=False).mapped('product_variant_ids').ids),
            //         ('state', 'in', ['partially_available', 'assigned']),
            //     ], limit=1)
            //     if existing_reserved_move_lines:
            //         raise UserError(_("You can not change the inventory tracking of a product that is currently reserved on a stock move. If you need to change the inventory tracking, you should first unreserve the stock move."))
            // if 'is_storable' in vals and not vals['is_storable'] and any(p.is_storable and not float_is_zero(p.qty_available, precision_rounding=p.uom_id.rounding) for p in self):
            //     raise UserError(_("Available quantity should be set to zero before changing inventory tracking"))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def write(self, vals):
            // impacted_templates = {}
            // move_vals_list = []
            // Product = self.env['product.product']
            // SVL = self.env['stock.valuation.layer']
            // 
            // if 'categ_id' in vals:
            //     # When a change of category implies a change of cost method, we empty out and replenish
            //     # the stock.
            //     new_product_category = self.env['product.category'].browse(vals.get('categ_id'))
            // 
            //     for product_template in self:
            //         product_template = product_template.with_company(product_template.company_id)
            //         valuation_impacted = False
            //         if product_template.cost_method != new_product_category.property_cost_method:
            //             if product_template.lot_valuated and not 'lot_valuated' in vals\
            //                     and any(p.stock_valuation_layer_ids for p in product_template.product_variant_ids):
            //                 raise UserError(_("You cannot change the product category of a product valuated by lot/serial number."))
            //             valuation_impacted = True
            //         if product_template.valuation != new_product_category.property_valuation:
            //             valuation_impacted = True
            //         if valuation_impacted is False:
            //             continue
            // 
            //         # Empty out the stock with the current cost method.
            //         description = _(
            //             "Due to a change of product category (from %(old_category)s to %(new_category)s), the costing method has changed for product %(product)s: from %(old_method)s to %(new_method)s.",
            //             old_category=product_template.categ_id.display_name,
            //             new_category=new_product_category.display_name,
            //             product=product_template.display_name,
            //             old_method=product_template.cost_method,
            //             new_method=new_product_category.property_cost_method)
            //         out_svl_vals_list, products_orig_quantity_svl, products = Product\
            //             ._svl_empty_stock(description, product_template=product_template)
            //         out_stock_valuation_layers = SVL.create(out_svl_vals_list)
            //         if product_template.valuation == 'real_time':
            //             move_vals_list += Product.with_context(products_orig_quantity_svl=products_orig_quantity_svl)._svl_empty_stock_am(out_stock_valuation_layers)
            //         impacted_templates[product_template] = (products, description, products_orig_quantity_svl)
            // 
            // if 'lot_valuated' in vals:
            //     for tmpl in self:
            //         if tmpl.lot_valuated != vals['lot_valuated'] and tmpl not in impacted_templates:
            //             description = _("Updating lot valuation for product %s.", tmpl.display_name)
            //             out_svl_vals_list, products_orig_quantity_svl, products = Product\
            //                 ._svl_empty_stock(description, product_template=tmpl)
            //             out_stock_valuation_layers = SVL.create(out_svl_vals_list)
            //             if tmpl.valuation == 'real_time':
            //                 move_vals_list += Product._svl_empty_stock_am(out_stock_valuation_layers)
            //             impacted_templates[tmpl] = (products, description, products_orig_quantity_svl)
            // 
            // res = super(ProductTemplate, self).write(vals)
            // 
            // for product_template, (products, description, products_orig_quantity_svl) in impacted_templates.items():
            //     products = products.exists()
            //     if products:
            //         # Replenish the stock with the new cost method.
            //         in_svl_vals_list = products._svl_replenish_stock(description, products_orig_quantity_svl)
            //         in_stock_valuation_layers = SVL.create(in_svl_vals_list)
            //         if product_template.valuation == 'real_time':
            //             move_vals_list += Product._svl_replenish_stock_am(in_stock_valuation_layers)
            //         products._update_lots_standard_price()
            // 
            // # Check access right
            // if move_vals_list and not self.env['stock.valuation.layer'].has_access('read'):
            //     raise UserError(_("The action leads to the creation of a journal entry, for which you don't have the access rights."))
            // # Create the account moves.
            // if move_vals_list:
            //     account_moves = self.env['account.move'].sudo().create(move_vals_list)
            //     account_moves._post()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: product.py) ---
            // def write(self, vals):
            // for product in self:
            //     if (('type' in vals and vals['type'] != 'service') or ('landed_cost_ok' in vals and not vals['landed_cost_ok'])) and product.type == 'service' and product.landed_cost_ok:
            //         if self.env['account.move.line'].search_count([('product_id', 'in', product.product_variant_ids.ids), ('is_landed_costs_line', '=', True)]):
            //             raise UserError(_("You cannot change the product type or disable landed cost option because the product is used in an account move line."))
            //         vals['landed_cost_ok'] = False
            // 
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def write(self, vals):
            // # Clear empty ecommerce description content to avoid side-effects on product pages
            // # when there is no content to display anyway.
            // if vals.get('description_ecommerce') and is_html_empty(vals['description_ecommerce']):
            //     vals['description_ecommerce'] = ''
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}