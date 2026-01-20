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
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public partial class MrpBomAppService : GenericApplicationService<MrpBom>, IMrpBomAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public MrpBomAppService(IRepository<MrpBom, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        public async Task<MrpBom> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_archive(self):
            // self.with_context(active_test=False).operation_ids.action_archive()
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> BomFindDomainInternalAsync(object products, object picking_type, Guid company_id, object bom_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _bom_find_domain(self, products, picking_type=None, company_id=False, bom_type=False):
            // domain = (
            //     Domain('product_id', 'in', products.ids) | (
            //         Domain('product_id', '=', False) & Domain('product_tmpl_id', 'in', products.product_tmpl_id.ids)
            //     )
            // ) & Domain('active', '=', True)
            // if company_id or self.env.context.get('company_id'):
            //     domain &= Domain('company_id', 'in', [False, company_id or self.env.context.get('company_id')])
            // if picking_type:
            //     domain &= Domain('picking_type_id', 'in', [picking_type.id, False])
            // if bom_type:
            //     domain &= Domain('type', '=', bom_type)
            // return domain
            */
            return default;
        }

        protected async Task<MrpBom> BomFindInternalAsync(object products, object picking_type, Guid company_id, object bom_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _bom_find(self, products, picking_type=None, company_id=False, bom_type=False):
            // """ Find the first BoM for each products
            // 
            // :param products: `product.product` recordset
            // :return: One bom (or empty recordset `mrp.bom` if none find) by product (`product.product` record)
            // :rtype: defaultdict(`lambda: self.env['mrp.bom']`)
            // """
            // bom_by_product = defaultdict(lambda: self.env['mrp.bom'])
            // products = products.filtered(lambda p: p.type != 'service')
            // if not products:
            //     return bom_by_product
            // domain = self._bom_find_domain(products, picking_type=picking_type, company_id=company_id, bom_type=bom_type)
            // 
            // # Performance optimization, allow usage of limit and avoid the for loop `bom.product_tmpl_id.product_variant_ids`
            // if len(products) == 1:
            //     bom = self.search(domain, order='sequence, product_id, id', limit=1)
            //     if bom:
            //         bom_by_product[products] = bom
            //     return bom_by_product
            // 
            // boms = self.search(domain, order='sequence, product_id, id')
            // 
            // products_ids = set(products.ids)
            // for bom in boms:
            //     products_implies = bom.product_id or bom.product_tmpl_id.product_variant_ids
            //     for product in products_implies:
            //         if product.id in products_ids and product not in bom_by_product:
            //             bom_by_product[product] = bom
            // 
            // return bom_by_product
            */
            return default;
        }

        protected async Task<MrpBom> BomSubcontractFindInternalAsync(object product, object picking_type, Guid company_id, object bom_type, object subcontractor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_bom.py) ---
            // def _bom_subcontract_find(self, product, picking_type=None, company_id=False, bom_type='subcontract', subcontractor=False):
            // domain = self._bom_find_domain(product, picking_type=picking_type, company_id=company_id, bom_type=bom_type)
            // if subcontractor:
            //     domain &= Domain('subcontractor_ids', 'parent_of', subcontractor.ids)
            //     return self.search(domain, order='sequence, product_id, id', limit=1)
            // else:
            //     return self.env['mrp.bom']
            */
            return default;
        }

        protected async Task<MrpBom> CheckBomCycleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _check_bom_cycle(self):
            // subcomponents_dict = dict()
            // 
            // def _check_cycle(components, finished_products):
            //     """
            //     Check whether the components are part of the finished products (-> cycle). Then, if
            //     these components have a BoM, repeat the operation with the subcomponents (recursion).
            //     The method will return the list of product variants that creates the cycle
            //     """
            //     products_to_find = self.env['product.product']
            // 
            //     for component in components:
            //         if component in finished_products:
            //             names = finished_products.mapped('display_name')
            //             raise ValidationError(_(
            //                 "The current configuration is incorrect because it would create a cycle between these products: %s.",
            //                 ', '.join(names)))
            //         if component not in subcomponents_dict:
            //             products_to_find |= component
            // 
            //     bom_find_result = self._bom_find(products_to_find)
            //     for component in components:
            //         if component not in subcomponents_dict:
            //             bom = bom_find_result[component]
            //             subcomponents = bom.bom_line_ids.filtered(lambda l: not l._skip_bom_line(component)).product_id
            //             subcomponents_dict[component] = subcomponents
            //         subcomponents = subcomponents_dict[component]
            //         if subcomponents:
            //             _check_cycle(subcomponents, finished_products | component)
            // 
            // boms_to_check = self
            // if self.bom_line_ids.product_id:
            //     boms_to_check |= self.search(Domain.OR(
            //         self._bom_find_domain(product)
            //         for product in self.bom_line_ids.product_id
            //     ))
            // 
            // for bom in boms_to_check:
            //     if not bom.active:
            //         continue
            //     finished_products = bom.product_id or bom.product_tmpl_id.product_variant_ids
            //     if bom.bom_line_ids.bom_product_template_attribute_value_ids:
            //         grouped_by_components = defaultdict(lambda: self.env['product.product'])
            //         for finished in finished_products:
            //             components = bom.bom_line_ids.filtered(lambda l: not l._skip_bom_line(finished)).product_id
            //             grouped_by_components[components] |= finished
            //         for components, finished in grouped_by_components.items():
            //             _check_cycle(components, finished)
            //     else:
            //         _check_cycle(bom.bom_line_ids.product_id, finished_products)
            */
            return default;
        }

        protected async Task<MrpBom> CheckBomLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _check_bom_lines(self):
            // for bom in self:
            //     apply_variants = bom.bom_line_ids.bom_product_template_attribute_value_ids | bom.operation_ids.bom_product_template_attribute_value_ids | bom.byproduct_ids.bom_product_template_attribute_value_ids
            //     if bom.product_id and apply_variants:
            //         raise ValidationError(_("You cannot use the 'Apply on Variant' functionality and simultaneously create a BoM for a specific variant."))
            //     for ptav in apply_variants:
            //         if ptav.product_tmpl_id != bom.product_tmpl_id:
            //             raise ValidationError(_(
            //                 "The attribute value %(attribute)s set on product %(product)s does not match the BoM product %(bom_product)s.",
            //                 attribute=ptav.display_name,
            //                 product=ptav.product_tmpl_id.display_name,
            //                 bom_product=bom.product_tmpl_id.display_name
            //             ))
            //     for byproduct in bom.byproduct_ids:
            //         if bom.product_id:
            //             same_product = bom.product_id == byproduct.product_id
            //         else:
            //             same_product = bom.product_tmpl_id == byproduct.product_id.product_tmpl_id
            //         if same_product:
            //             raise ValidationError(_("By-product %s should not be the same as BoM product.", bom.display_name))
            //         if byproduct.cost_share < 0:
            //             raise ValidationError(_("By-products cost shares must be positive."))
            //     if sum(bom.byproduct_ids.mapped('cost_share')) > 100:
            //         raise ValidationError(_("The total cost share for a BoM's by-products cannot exceed 100."))
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _check_bom_lines(self):
            // res = super()._check_bom_lines()
            // for bom in self:
            //     if all(not bl.cost_share for bl in bom.bom_line_ids):
            //         continue
            //     if any(bl.cost_share < 0 for bl in bom.bom_line_ids):
            //         raise UserError(_("Components cost share have to be positive or equals to zero."))
            //     for product in bom.product_tmpl_id.product_variant_ids:
            //         total_variant_cost_share = sum(bom.bom_line_ids.filtered(lambda bl: not bl._skip_bom_line(product) and not bl.product_uom_id.is_zero(bl.product_qty)).mapped('cost_share'))
            //         if float_round(total_variant_cost_share, precision_digits=2) not in [0, 100]:
            //             raise UserError(_("The total cost share for a BoM's component have to be 100"))
            // return res
            */
            return default;
        }

        public async Task<MrpBom> CheckKitHasNotOrderpointAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def check_kit_has_not_orderpoint(self):
            // product_ids = [pid for bom in self.filtered(lambda bom: bom.type == "phantom")
            //                    for pid in (bom.product_id.ids or bom.product_tmpl_id.product_variant_ids.ids)]
            // if self.env['stock.warehouse.orderpoint'].search_count([('product_id', 'in', product_ids)], limit=1):
            //     raise ValidationError(_("You can not create a kit-type bill of materials for products that have at least one reordering rule."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> CheckSubcontractingNoOperationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_bom.py) ---
            // def _check_subcontracting_no_operation(self):
            // if self.filtered_domain([('type', '=', 'subcontract'), '|', ('operation_ids', '!=', False), ('byproduct_ids', '!=', False)]):
            //     raise ValidationError(_('You can not set a Bill of Material with operations or by-product line as subcontracting.'))
            */
            return default;
        }

        protected async Task<MrpBom> CheckValidBatchSizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _check_valid_batch_size(self):
            // if any(bom.enable_batch_size and bom.product_uom_id.compare(bom.batch_size, 0.0) <= 0 for bom in self):
            //     raise ValidationError(self.env._("The batch size must be positive!"))
            */
            return default;
        }

        public async Task<MrpBom> ComputeBomDaysAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_compute_bom_days(self):
            // company_id = self.env.context.get('default_company_id', self.env.company.id)
            // warehouse = self.env['stock.warehouse'].search([('company_id', '=', company_id)], limit=1)
            // for bom in self:
            //     bom_data = self.env['report.mrp.report_bom_structure'].with_context(minimized=True)._get_bom_data(bom, warehouse, bom.product_id, ignore_stock=True)
            //     bom.days_to_prepare_mo = self.env['report.mrp.report_bom_structure']._get_max_component_delay(bom_data['components'])
            //     if bom_data.get('availability_state') == 'unavailable' and not bom_data.get('components_available', True):
            //         return {
            //             'type': 'ir.actions.client',
            //             'tag': 'display_notification',
            //             'params': {
            //                 'title': _('Cannot compute days to prepare due to missing route info for at least 1 component or for the final product.'),
            //                 'sticky': False,
            //             }
            //         }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_display_name(self):
            // for bom in self:
            //     display_name = f"{bom.code + ': ' if bom.code else ''}{bom.product_tmpl_id.display_name}"
            //     if self.env.context.get('display_bom_uom_qty') and (bom.product_qty > 1 or bom.product_uom_id != bom.product_tmpl_id.uom_id):
            //         display_name += f" ({bom.product_qty} {bom.product_uom_id.name})"
            //     bom.display_name = _('%(display_name)s', display_name=display_name)
            */
            return default;
        }

        protected async Task<MrpBom> ComputeOperationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_operation_count(self):
            // for bom in self:
            //     bom.operation_count = len(bom.operation_ids)
            */
            return default;
        }

        protected async Task<MrpBom> ComputePossibleProductTemplateAttributeValueIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_possible_product_template_attribute_value_ids(self):
            // for bom in self:
            //     bom.possible_product_template_attribute_value_ids = bom.product_tmpl_id.valid_product_template_attribute_line_ids.product_template_value_ids._only_active()
            */
            return default;
        }

        protected async Task<MrpBom> ComputeShowSetBomButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_show_set_bom_button(self):
            // self.show_set_bom_button = True
            // orderpoint_id = self.env.context.get('orderpoint_id', self.env.context.get('default_orderpoint_id'))
            // if orderpoint_id:
            //     orderpoint = self.env['stock.warehouse.orderpoint'].browse(orderpoint_id)
            //     self.filtered(
            //         lambda s: s.id == orderpoint.bom_id.id
            //     ).show_set_bom_button = False
            */
            return default;
        }

        protected async Task<MrpBom> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self[child_field]._get_product_catalog_lines_data(default=True)
            // 
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        protected async Task<MrpBom> EnsureBomIsFreeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py) ---
            // def _ensure_bom_is_free(self):
            // product_ids = []
            // for bom in self:
            //     if not bom.active or bom.type != 'phantom':
            //         continue
            //     product_ids += bom.product_id.ids or bom.product_tmpl_id.product_variant_ids.ids
            // if not product_ids:
            //     return
            // lines = self.env['sale.order.line'].sudo().search([
            //     ('state', '=', 'sale'),
            //     ('invoice_status', 'in', ('no', 'to invoice')),
            //     ('product_id', 'in', product_ids),
            //     ('move_ids.state', '!=', 'cancel'),
            // ])
            // if lines:
            //     product_names = ', '.join(lines.product_id.mapped('display_name'))
            //     raise UserError(_('As long as there are some sale order lines that must be delivered/invoiced and are '
            //                       'related to these bills of materials, you can not remove them.\n'
            //                       'The error concerns these products: %s', product_names))
            */
            return default;
        }

        public async Task<MrpBom> ExplodeAsync(Guid id, MrpBomExplodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def explode(self, product, quantity, picking_type=False, never_attribute_values=False):
            // """
            //     Explodes the BoM and creates two lists with all the information you need: bom_done and line_done
            //     Quantity describes the number of times you need the BoM: so the quantity divided by the number created by the BoM
            //     and converted into its UoM
            // """
            // product_ids = set()
            // product_boms = {}
            // def update_product_boms():
            //     products = self.env['product.product'].browse(product_ids)
            //     product_boms.update(self._bom_find(products, picking_type=picking_type or self.picking_type_id,
            //         company_id=self.company_id.id, bom_type='phantom'))
            //     # Set missing keys to default value
            //     for product in products:
            //         product_boms.setdefault(product, self.env['mrp.bom'])
            // 
            // boms_done = [(self, self.env['mrp.bom.line']._prepare_bom_done_values(quantity, product, quantity, []))]
            // lines_done = []
            // 
            // bom_lines = []
            // for bom_line in self.bom_line_ids:
            //     product_id = bom_line.product_id
            //     bom_lines.append((bom_line, product, quantity, False))
            //     product_ids.add(product_id.id)
            // update_product_boms()
            // product_ids.clear()
            // while bom_lines:
            //     current_line, current_product, current_qty, parent_line = bom_lines[0]
            //     bom_lines = bom_lines[1:]
            // 
            //     if current_line._skip_bom_line(current_product, never_attribute_values):
            //         continue
            // 
            //     line_quantity = current_qty * current_line.product_qty
            //     if current_line.product_id not in product_boms:
            //         update_product_boms()
            //         product_ids.clear()
            //     bom = product_boms.get(current_line.product_id)
            //     if bom:
            //         converted_line_quantity = current_line.product_uom_id._compute_quantity(
            //             line_quantity / bom.product_qty, bom.product_uom_id, round=False
            //         )
            //         bom_lines = [(line, current_line.product_id, converted_line_quantity, current_line) for line in bom.bom_line_ids] + bom_lines
            //         for bom_line in bom.bom_line_ids:
            //             if bom_line.product_id not in product_boms:
            //                 product_ids.add(bom_line.product_id.id)
            //         boms_done.append((bom, current_line._prepare_bom_done_values(converted_line_quantity, current_product, quantity, boms_done)))
            //     else:
            //         # We round up here because the user expects that if he has to consume a little more, the whole UOM unit
            //         # should be consumed.
            //         line_quantity = current_line.product_uom_id.round(line_quantity, rounding_method='UP')
            //         lines_done.append((current_line, current_line._prepare_line_done_values(line_quantity, current_product, quantity, parent_line, boms_done)))
            // 
            // lines_done = self._round_last_line_done(lines_done)
            // return boms_done, lines_done
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'product_catalog_currency_id': self.env.company.currency_id.id,
            // }
            */
            return default;
        }

        protected async Task<MrpBom> GetDefaultProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_default_product_uom_id(self):
            // return self.env['uom.uom'].search([], limit=1, order='id').id
            */
            return default;
        }

        protected async Task<MrpBom> GetExtraAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_extra_attachments(self):
            // is_byproduct = self.env.user.has_group('mrp.group_mrp_byproducts')
            // product_ids, template_ids = OrderedSet(), OrderedSet()
            // for bom in self:
            //     product_ids.add(bom.product_id.id)
            //     template_ids.add(bom.product_tmpl_id.id)
            //     if is_byproduct:
            //         product_ids.update(bom.byproduct_ids.product_id.ids)
            //         template_ids.update(bom.byproduct_ids.product_id.product_tmpl_id.ids)
            // 
            // domain = Domain('attached_on_mrp', '=', 'bom') & (
            //     (Domain('res_model', '=', 'product.product') & Domain('res_id', 'in', product_ids))
            //     | (Domain('res_model', '=', 'product.template') & Domain('res_id', 'in', template_ids))
            // )
            // attachements = self.env['product.document'].search(domain).ir_attachment_id
            // return attachements
            */
            return default;
        }

        public async Task<MrpBom> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Bills of Materials'),
            //     'template': '/mrp/static/xls/mrp_bom.xls'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> GetMailThreadDataAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_mail_thread_data_attachments(self):
            // res = super()._get_mail_thread_data_attachments()
            // return res | self._get_extra_attachments()
            */
            return default;
        }

        protected async Task<MrpBom> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // product_catalog = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     product_catalog[product.id] |= self._get_product_price_and_data(product)
            // return product_catalog
            */
            return default;
        }

        protected async Task<MrpBom> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, *, child_field=False, **kwargs):
            // if not child_field:
            //     return {}
            // lines = self[child_field].filtered(lambda line: line.product_id.id in product_ids)
            // return lines.grouped('product_id')
            */
            return default;
        }

        protected async Task<MrpBom> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_product_price_and_data(self, product):
            // self.ensure_one()
            // return {'price': product.standard_price}
            */
            return default;
        }

        public async Task<MrpBom> OnchangeBomStructureAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def onchange_bom_structure(self):
            // if self.type == 'phantom' and self._origin and self.env['stock.move'].search_count([('bom_line_id', 'in', self._origin.bom_line_ids.ids)], limit=1):
            //     return {
            //         'warning': {
            //             'title': _('Warning'),
            //             'message': _(
            //                 'The product has already been used at least once, editing its structure may lead to undesirable behaviours. '
            //                 'You should rather archive the product and create a new one with a new bill of materials.'),
            //         }
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> OnchangeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _onchange_product_id(self):
            // if self.product_id:
            //     warning = (
            //         self.bom_line_ids.bom_product_template_attribute_value_ids or
            //         self.operation_ids.bom_product_template_attribute_value_ids or
            //         self.byproduct_ids.bom_product_template_attribute_value_ids
            //     ) and {
            //         'warning': {
            //             'title': _("Warning"),
            //             'message': _("Changing the product or variant will permanently reset all previously encoded variant-related data."),
            //         }
            //     }
            //     self.bom_line_ids.bom_product_template_attribute_value_ids = False
            //     self.operation_ids.bom_product_template_attribute_value_ids = False
            //     self.byproduct_ids.bom_product_template_attribute_value_ids = False
            //     if warning:
            //         return warning
            */
            return default;
        }

        public async Task<MrpBom> OnchangeProductTmplIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def onchange_product_tmpl_id(self):
            // if self.product_tmpl_id:
            //     warning = (
            //         self.bom_line_ids.bom_product_template_attribute_value_ids or
            //         self.operation_ids.bom_product_template_attribute_value_ids or
            //         self.byproduct_ids.bom_product_template_attribute_value_ids
            //     ) and {
            //         'warning': {
            //             'title': _("Warning"),
            //             'message': _("Changing the product or variant will permanently reset all previously encoded variant-related data."),
            //         }
            //     }
            //     default_uom_id = self.env.context.get('default_product_uom_id')
            //     # Avoids updating the BoM's UoM in case a specific UoM was passed through as a default value.
            //     if self.product_uom_id.id != default_uom_id:
            //         self.product_uom_id = self.product_tmpl_id.uom_id.id
            //     if self.product_id.product_tmpl_id != self.product_tmpl_id:
            //         self.product_id = False
            //     self.bom_line_ids.bom_product_template_attribute_value_ids = False
            //     self.operation_ids.bom_product_template_attribute_value_ids = False
            //     self.byproduct_ids.bom_product_template_attribute_value_ids = False
            // 
            //     domain = [('product_tmpl_id', '=', self.product_tmpl_id.id)]
            //     if self.id.origin:
            //         domain.append(('id', '!=', self.id.origin))
            //     number_of_bom_of_this_product = self.env['mrp.bom'].search_count(domain)
            //     if number_of_bom_of_this_product:  # add a reference to the bom if there is already a bom for this product
            //         self.code = _("%(product_name)s (new) %(number_of_boms)s", product_name=self.product_tmpl_id.name, number_of_boms=number_of_bom_of_this_product)
            //     if warning:
            //         return warning
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MrpBom> OpenOperationFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_open_operation_form(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mrp.routing.workcenter',
            //     'context': {
            //         'default_bom_id': self.id,
            //         'search_default_bom_id': self.id,
            //         'bom_id_invisible': True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> RoundLastLineDoneInternalAsync(object lines_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _round_last_line_done(self, lines_done):
            // return lines_done
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _round_last_line_done(self, lines_done):
            // result = super()._round_last_line_done(lines_done)
            // if result:
            //     result[-1][1]['line_cost_share'] = float_round(100.0 - sum(vals.get('line_cost_share', 0.0) for _, vals in result[:-1]), precision_digits=2)
            // return result
            */
            return default;
        }

        public async Task<MrpBom> SetBomOnOrderpointAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_set_bom_on_orderpoint(self):
            // self.ensure_one()
            // orderpoint_id = self.env.context.get('orderpoint_id')
            // if not orderpoint_id:
            //     return
            // orderpoint = self.env['stock.warehouse.orderpoint'].browse(orderpoint_id)
            // if 'manufacture' not in orderpoint.route_id.rule_ids.mapped('action'):
            //     domain = Domain.AND([
            //         [('action', '=', 'manufacture')],
            //         Domain.OR([
            //             [('company_id', '=', orderpoint.company_id.id)],
            //             [('company_id', '=', False)],
            //         ]),
            //     ])
            //     orderpoint.route_id = self.env['stock.rule'].search(domain, limit=1).route_id.id
            // orderpoint.bom_id = self
            // bom_qty = self.product_uom_id._compute_quantity(self.product_qty, orderpoint.product_id.uom_id)
            // if orderpoint.qty_to_order < bom_qty:
            //     orderpoint.qty_to_order = bom_qty
            // return orderpoint.action_stock_replenishment_info()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBom> SetOutdatedBomInProductionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _set_outdated_bom_in_productions(self):
            // if not self:
            //     return
            // # Searches for MOs using these BoMs to notify them that their BoM has been updated.
            // list_of_domain_by_bom = []
            // for bom in self:
            //     if bom.product_id:
            //         domain_by_products = Domain('product_id', '=', bom.product_id.id)
            //     else:
            //         domain_by_products = Domain('product_id', 'in', bom.product_tmpl_id.product_variant_ids.ids)
            //     domain_for_confirmed_mo = Domain('state', '=', 'confirmed') & domain_by_products
            //     # Avoid confirmed MOs if the BoM's product was changed.
            //     domain_by_states = Domain('state', '=', 'draft') | domain_for_confirmed_mo
            //     list_of_domain_by_bom.append(Domain('bom_id', '=', bom.id) & domain_by_states)
            // productions = self.env['mrp.production'].search(Domain.OR(list_of_domain_by_bom))
            // if productions:
            //     productions.is_outdated_bom = True
            */
            return default;
        }

        protected async Task<MrpBom> SkipForNoVariantInternalAsync(object product, object bom_attribule_values, object never_attribute_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _skip_for_no_variant(self, product, bom_attribule_values, never_attribute_values=False):
            // """ Controls if a Component/Operation/Byproduct line should be skipped based on the 'no_variant' attributes
            //     Cases:
            //         - no_variant:
            //             1. attribute present on the line
            //                 => need to be at least one attribute value matching between the one passed as args and the ones one the line
            //             2. attribute not present on the line
            //                 => valid if the line has no attribute value selected for that attribute
            //         - always and dynamic: match_all_variant_values()
            // """
            // no_variant_bom_attributes = bom_attribule_values.filtered(lambda av: av.attribute_id.create_variant == 'no_variant')
            // 
            // # Attributes create_variant 'always' and 'dynamic'
            // other_attribute_valid = product._match_all_variant_values(bom_attribule_values - no_variant_bom_attributes)
            // 
            // # If there are no never attribute values on the line => 'always' and 'dynamic'
            // if not no_variant_bom_attributes:
            //     return not other_attribute_valid
            // 
            // # Or if there are never attribute on the line values but no value is passed => impossible to match
            // if not never_attribute_values:
            //     return True
            // 
            // bom_values_by_attribute = no_variant_bom_attributes.grouped('attribute_id')
            // never_values_by_attribute = never_attribute_values.grouped('attribute_id')
            // 
            // # Or if there is no overlap between given line values attributes and the ones on on the bom
            // if not any(never_att_id in no_variant_bom_attributes.attribute_id.ids for never_att_id in never_attribute_values.attribute_id.ids):
            //     return True
            // 
            // # Check that at least one variant attribute is correct
            // for attribute, values in bom_values_by_attribute.items():
            //     if never_values_by_attribute.get(attribute) and any(val.id in never_values_by_attribute[attribute].ids for val in values):
            //         return not other_attribute_valid
            // 
            // # None were found, so we skip the line
            // return True
            */
            return default;
        }

        public async Task<MrpBom> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_unarchive(self):
            // self.with_context(active_test=False).operation_ids.action_unarchive()
            // return super().action_unarchive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py) ---
            // def unlink(self):
            // self._ensure_bom_is_free()
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<MrpBom> UnlinkExceptRunningMoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _unlink_except_running_mo(self):
            // if self.env['mrp.production'].search_count([('bom_id', 'in', self.ids), ('state', 'not in', ['done', 'cancel'])], limit=1):
            //     raise UserError(_('You can not delete a Bill of Material with running manufacturing orders.\nPlease close or cancel it first.'))
            */
            return default;
        }

        protected async Task<MrpBom> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _update_order_line_info(self, product_id, quantity, *, child_field=False, **kwargs):
            // if not child_field:
            //     return 0
            // entity = self[child_field].filtered(lambda line: line.product_id.id == product_id)
            // if entity:
            //     if quantity != 0:
            //         entity.product_qty = quantity
            //     else:
            //         entity.unlink()
            // elif quantity > 0:
            //     command = Command.create({
            //         'product_qty': quantity,
            //         'product_id': product_id,
            //     })
            //     self.write({child_field: [command]})
            // 
            // return self.env['product.product'].browse(product_id).standard_price
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MrpBom entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // relevant_fields = ['bom_line_ids', 'byproduct_ids', 'product_tmpl_id', 'product_id', 'product_qty']
            // if any(field_name in vals for field_name in relevant_fields):
            //     self._set_outdated_bom_in_productions()
            // if 'sequence' in vals and self and self[-1].id == list(self._prefetch_ids)[-1]:
            //     self.browse(self._prefetch_ids)._check_bom_cycle()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py) ---
            // def write(self, vals):
            // if not vals.get('active', True) or ('phantom' in self.mapped('type') and vals.get('type', 'phantom') != 'phantom'):
            //     self._ensure_bom_is_free()
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}