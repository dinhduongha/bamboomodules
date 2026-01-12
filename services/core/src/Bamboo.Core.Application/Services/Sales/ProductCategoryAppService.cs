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
    public class ProductCategoryAppService : GenericApplicationService<ProductCategory>, IProductCategoryAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ProductCategory> CheckCategoryRecursionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def _check_category_recursion(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive categories.'))
            */
            return default;
        }

        protected async Task<ProductCategory> CheckValuationAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _check_valuation_accounts(self):
            // fnames = self._get_mandatory_stock_account_property_field_names()
            // for category in self:
            //     if category.property_valuation == 'real_time':
            //         if any(not category[account] for account in fnames):
            //             raise ValidationError(_('The stock accounts should be set in order to use the automatic valuation.'))
            // 
            //     # Prevent to set the valuation account as the input or output account.
            //     valuation_account = category.property_stock_valuation_account_id
            //     input_and_output_accounts = category.property_stock_account_input_categ_id | category.property_stock_account_output_categ_id
            //     if valuation_account and valuation_account in input_and_output_accounts:
            //         raise ValidationError(_('The Stock Input and/or Output accounts cannot be the same as the Stock Valuation account.'))
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def _compute_complete_name(self):
            // for category in self:
            //     if category.parent_id:
            //         category.complete_name = '%s / %s' % (category.parent_id.complete_name, category.name)
            //     else:
            //         category.complete_name = category.name
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def _compute_display_name(self):
            // if self.env.context.get('hierarchical_naming', True):
            //     return super()._compute_display_name()
            // for record in self:
            //     record.display_name = record.name
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeParentRouteIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_parent_route_ids(self):
            // for category in self:
            //     base_cat = category
            //     routes = self.env['stock.route']
            //     while base_cat.parent_id:
            //         base_cat = base_cat.parent_id
            //         routes |= base_cat.route_ids
            //     category.parent_route_ids = routes - category.route_ids
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeProductCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def _compute_product_count(self):
            // read_group_res = self.env['product.template']._read_group([('categ_id', 'child_of', self.ids)], ['categ_id'], ['__count'])
            // group_data = {categ.id: count for categ, count in read_group_res}
            // for categ in self:
            //     product_count = 0
            //     for sub_categ_id in categ.search([('id', 'child_of', categ.ids)]).ids:
            //         product_count += group_data.get(sub_categ_id, 0)
            //     categ.product_count = product_count
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeTotalRouteIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_total_route_ids(self):
            // for category in self:
            //     category.total_route_ids = category.route_ids | category.parent_route_ids
            */
            return default;
        }

        protected async Task<ProductCategory> CreateDefaultStockAccountsPropertiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _create_default_stock_accounts_properties(self):
            // IrDefault = self.env['ir.default']
            // company = self.env.ref('base.main_company')
            // output_field = self.env['ir.model.fields'].search([
            //     ('model', '=', 'product.category'),
            //     ('name', '=', 'property_stock_account_output_categ_id'),
            // ])
            // output_property = IrDefault.search([
            //     ('field_id', '=', output_field.id),
            //     ('company_id', '=', company.id),
            // ])
            // if not output_property:
            //     IrDefault._load_records([{
            //         'xml_id': 'stock_account.property_stock_account_output_categ_id',
            //         'noupdate': True,
            //         'values': {
            //             'field_id': output_field.id,
            //             'json_value': 'false',
            //             'company_id': company.id,
            //         },
            //     }])
            // 
            // input_field = self.env['ir.model.fields'].search([
            //     ('model', '=', 'product.category'),
            //     ('name', '=', 'property_stock_account_input_categ_id'),
            // ])
            // input_property = IrDefault.search([
            //     ('field_id', '=', input_field.id),
            //     ('company_id', '=', company.id),
            // ])
            // if not input_property:
            //     IrDefault._load_records([{
            //         'xml_id': 'stock_account.property_stock_account_input_categ_id',
            //         'noupdate': True,
            //         'values': {
            //             'field_id': input_field.id,
            //             'json_value': 'false',
            //             'company_id': company.id,
            //         },
            //     }])
            */
            return default;
        }

        protected async Task<ProductCategory> GetMandatoryStockAccountPropertyFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_mandatory_stock_account_property_field_names(self):
            // return [
            //     'property_stock_account_input_categ_id',
            //     'property_stock_account_output_categ_id',
            //     'property_stock_valuation_account_id',
            // ]
            */
            return default;
        }

        protected async Task<ProductCategory> GetStockAccountPropertyFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _get_stock_account_property_field_names(self):
            // return super()._get_stock_account_property_field_names() + ['property_stock_account_production_cost_id']
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_stock_account_property_field_names(self):
            // return self._get_mandatory_stock_account_property_field_names()
            */
            return default;
        }

        protected async Task<ProductCategory> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'parent_id']
            */
            return default;
        }

        public async Task<ProductCategory> OnchangePropertyCostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def onchange_property_cost(self):
            // if not self._origin:
            //     # don't display the warning when creating a product category
            //     return
            // return {
            //     'warning': {
            //         'title': _("Warning"),
            //         'message': _("Changing your cost method is an important change that will impact your inventory valuation. Are you sure you want to make that change?"),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductCategory> SearchFilterForStockPutawayRuleInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_filter_for_stock_putaway_rule(self, operator, value):
            // assert operator == '='
            // assert value
            // 
            // active_model = self.env.context.get('active_model')
            // if active_model in ('product.template', 'product.product') and self.env.context.get('active_id'):
            //     product = self.env[active_model].browse(self.env.context.get('active_id'))
            //     product = product.exists()
            //     if product:
            //         return [('id', '=', product.categ_id.id)]
            // return []
            */
            return default;
        }

        protected async Task<ProductCategory> SearchTotalRouteIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_total_route_ids(self, operator, value):
            // categories = self.env['product.category'].sudo().search([])
            // categ_ids = categories.filtered_domain([('total_route_ids', operator, value)]).ids
            // return [('id', 'in', categ_ids)]
            */
            return default;
        }

        protected async Task<ProductCategory> UnlinkExceptDefaultCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def _unlink_except_default_category(self):
            // main_category = self.env.ref('product.product_category_all', raise_if_not_found=False)
            // if main_category and main_category in self:
            //     raise UserError(_("You cannot delete this product category, it is the default generic category."))
            // expense_category = self.env.ref('product.cat_expense', raise_if_not_found=False)
            // if expense_category and expense_category in self:
            //     raise UserError(_("You cannot delete the %s product category.", expense_category.name))
            // saleable_category = self.env.ref('product.product_category_1', raise_if_not_found=False)
            // if saleable_category and saleable_category in self:
            //     raise UserError(_("You cannot delete the %s product category.", saleable_category.name))
            */
            return default;
        }

        protected async Task<ProductCategory> UnlinkExceptDeliveryCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: product_category.py) ---
            // def _unlink_except_delivery_category(self):
            // delivery_category = self.env.ref('delivery.product_category_deliveries', raise_if_not_found=False)
            // if delivery_category and delivery_category in self:
            //     raise UserError(_("You cannot delete the deliveries product category as it is used on the delivery carriers products."))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProductCategory entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def write(self, vals):
            // impacted_categories = {}
            // move_vals_list = []
            // Product = self.env['product.product']
            // SVL = self.env['stock.valuation.layer']
            // 
            // if 'property_cost_method' in vals or 'property_valuation' in vals:
            //     categ_products = self.env['product.product'].search([('categ_id', 'in', self.ids)])
            //     if any(p.lot_valuated and p.stock_valuation_layer_ids for p in categ_products):
            //         raise UserError(_("You cannot change the costing method of product valuated by lot/serial number."))
            //     # When the cost method or the valuation are changed on a product category, we empty
            //     # out and replenish the stock for each impacted products.
            //     new_cost_method = vals.get('property_cost_method')
            //     new_valuation = vals.get('property_valuation')
            // 
            //     for product_category in self:
            //         valuation_impacted = False
            //         if new_cost_method and new_cost_method != product_category.property_cost_method:
            //             valuation_impacted = True
            //         if new_valuation and new_valuation != product_category.property_valuation:
            //             valuation_impacted = True
            //         if valuation_impacted is False:
            //             continue
            // 
            //         # Empty out the stock with the current cost method.
            //         if new_cost_method:
            //             description = _(
            //                 "Costing method change for product category %(category)s: from %(old_method)s to %(new_method)s.",
            //                 category=product_category.display_name, old_method=product_category.property_cost_method, new_method=new_cost_method)
            //         else:
            //             description = _(
            //                 "Valuation method change for product category %(category)s: from %(old_method)s to %(new_method)s.",
            //                 category=product_category.display_name, old_method=product_category.property_valuation, new_method=new_valuation)
            //         out_svl_vals_list, products_orig_quantity_svl, products = Product\
            //             ._svl_empty_stock(description, product_category=product_category)
            //         out_stock_valuation_layers = SVL.sudo().create(out_svl_vals_list)
            //         if product_category.property_valuation == 'real_time':
            // 
            //             move_vals_list += Product.with_context(products_orig_quantity_svl=products_orig_quantity_svl)._svl_empty_stock_am(out_stock_valuation_layers)
            //         impacted_categories[product_category] = (products, description, products_orig_quantity_svl)
            // 
            // res = super(ProductCategory, self).write(vals)
            // 
            // for product_category, (products, description, products_orig_quantity_svl) in impacted_categories.items():
            //     # Replenish the stock with the new cost method.
            //     in_svl_vals_list = products._svl_replenish_stock(description, products_orig_quantity_svl)
            //     in_stock_valuation_layers = SVL.sudo().create(in_svl_vals_list)
            //     if product_category.property_valuation == 'real_time':
            //         move_vals_list += Product._svl_replenish_stock_am(in_stock_valuation_layers)
            //     products._update_lots_standard_price()
            // 
            // # Check access right
            // if move_vals_list and not self.env['stock.valuation.layer'].has_access('read'):
            //     raise UserError(_("The action leads to the creation of a journal entry, for which you don't have the access rights."))
            // # Create the account moves.
            // if move_vals_list:
            //     account_moves = self.env['account.move'].sudo().create(move_vals_list)
            //     account_moves._post()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}