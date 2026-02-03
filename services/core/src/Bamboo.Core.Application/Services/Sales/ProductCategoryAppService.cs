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
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductCategoryAppService : GenericAppService<ProductCategory>, IProductCategoryAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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

        protected async Task<ProductCategory> ComputeAngloSaxonAccountingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_anglo_saxon_accounting(self):
            // self.anglo_saxon_accounting = self.env.company.anglo_saxon_accounting
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

        public async Task<ProductCategory> CopyDataAsync(ProductCategoryCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_category.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for category, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", category.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<ProductCategory> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_category.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'parent_id']
            */
            return default;
        }

        protected async Task<ProductCategory> SearchFilterForStockPutawayRuleInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_filter_for_stock_putaway_rule(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domain = Domain.TRUE
            // active_model = self.env.context.get('active_model')
            // if active_model in ('product.template', 'product.product') and self.env.context.get('active_id'):
            //     product = self.env[active_model].browse(self.env.context.get('active_id'))
            //     product = product.exists()
            //     if product:
            //         domain = Domain('id', '=', product.categ_id.id)
            // return domain
            */
            return default;
        }

        protected async Task<ProductCategory> SearchTotalRouteIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_total_route_ids(self, operator, value):
            // categories = self.with_context(active_test=False).search([])
            // categ_ids = categories.filtered_domain([('total_route_ids', operator, value)]).ids
            // return [('id', 'in', categ_ids)]
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

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductCategory> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def write(self, vals):
            // products_to_update = self.env['product.product']
            // if 'property_cost_method' in vals:
            //     updated_categories = self.filtered(lambda c: c.property_cost_method != vals['property_cost_method'])
            //     if updated_categories:
            //         products_to_update = self.env['product.product'].search([('categ_id', 'in', updated_categories.ids)])
            // res = super().write(vals)
            // if products_to_update:
            //     products_to_update._update_standard_price()
            // return res
            */
            return await base.WriteAsync(input);
        }
    }
}