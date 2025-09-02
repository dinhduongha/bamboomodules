using Bamboo.Core.Application.Contracts.DTOs;
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
    public class ProductAttributeValueAppService : GenericApplicationService<ProductAttributeValue>, IProductAttributeValueAppService
    {

        public ProductAttributeValueAppService(IRepository<ProductAttributeValue, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ProductAttributeValue> AddToProductsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def action_add_to_products(self):
            // return {
            //     'name': _("Add to all products"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'update.product.attribute.value',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'default_attribute_value_id': self.id,
            //         'default_mode': 'add',
            //         'dialog_size': 'medium',
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProductAttributeValue> CheckIsUsedOnProductsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def check_is_used_on_products(self):
            // for pav in self.filtered('is_used_on_products'):
            //     return _(
            //         "You cannot delete the value %(value)s because it is used on the following"
            //         " products:\n%(products)s\n",
            //         value=pav.display_name,
            //         products=", ".join(pav.pav_attribute_line_ids.product_tmpl_id.mapped('display_name')),
            //     )
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductAttributeValue> ComputeDefaultExtraPriceChangedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _compute_default_extra_price_changed(self):
            // for pav in self:
            //     pav.default_extra_price_changed = (
            //         pav.default_extra_price != pav._origin.default_extra_price
            //     )
            */
            return default;
        }

        protected async Task<ProductAttributeValue> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _compute_display_name(self):
            // """Override because in general the name of the value is confusing if it
            // is displayed without the name of the corresponding attribute.
            // Eg. on product list & kanban views, on BOM form view
            // 
            // However during variant set up (on the product template form) the name of
            // the attribute is already on each line so there is no need to repeat it
            // on every value.
            // """
            // if not self.env.context.get('show_attribute', True):
            //     return super()._compute_display_name()
            // for value in self:
            //     value.display_name = f"{value.attribute_id.name}: {value.name}"
            */
            return default;
        }

        protected async Task<ProductAttributeValue> ComputeIsUsedOnProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _compute_is_used_on_products(self):
            // for pav in self:
            //     pav.is_used_on_products = bool(pav.pav_attribute_line_ids.filtered('product_tmpl_id.active'))
            */
            return default;
        }

        protected async Task<ProductAttributeValue> GetDefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _get_default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        protected async Task<ProductAttributeValue> UnlinkExceptUsedOnProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _unlink_except_used_on_product(self):
            // if is_used_on_products := self.check_is_used_on_products():
            //     raise UserError(is_used_on_products)
            */
            return default;
        }

        public async Task<ProductAttributeValue> UpdatePricesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def action_update_prices(self):
            // return {
            //     'name': _("Update product extra prices"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'update.product.attribute.value',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'default_attribute_value_id': self.id,
            //         'default_mode': 'update_extra_price',
            //         'dialog_size': 'medium',
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductAttributeValue> WithoutNoVariantAttributesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py) ---
            // def _without_no_variant_attributes(self):
            // return self.filtered(lambda pav: pav.attribute_id.create_variant != 'no_variant')
            */
            return default;
        }
    }
}