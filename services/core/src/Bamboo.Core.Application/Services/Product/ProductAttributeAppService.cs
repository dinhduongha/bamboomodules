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
    public class ProductAttributeAppService : GenericApplicationService<ProductAttribute>, IProductAttributeAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductAttributeAppService(IRepository<ProductAttribute, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ProductAttribute> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def action_archive(self):
            // for attribute in self:
            //     if attribute.number_related_products:
            //         raise UserError(_(
            //             "You cannot archive this attribute as there are still products linked to it",
            //         ))
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductAttribute> ComputeNumberRelatedProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def _compute_number_related_products(self):
            // res = {
            //     attribute.id: count
            //     for attribute, count in self.env['product.template.attribute.line']._read_group(
            //         domain=[('attribute_id', 'in', self.ids), ('product_tmpl_id.active', '=', 'True')],
            //         groupby=['attribute_id'],
            //         aggregates=['__count'],
            //     )
            // }
            // for pa in self:
            //     pa.number_related_products = res.get(pa.id, 0)
            */
            return default;
        }

        protected async Task<ProductAttribute> ComputeProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def _compute_products(self):
            // templates_by_attribute = {
            //     attribute.id: templates
            //     for attribute, templates in self.env['product.template.attribute.line']._read_group(
            //         domain=[('attribute_id', 'in', self.ids)],
            //         groupby=['attribute_id'],
            //         aggregates=['product_tmpl_id:recordset']
            //     )
            // }
            // for pa in self:
            //     pa.with_context(active_test=False).product_tmpl_ids = templates_by_attribute.get(pa.id, False)
            */
            return default;
        }

        protected async Task<ProductAttribute> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_domain(self, data):
            // loaded_attribute_ids = {ptal['attribute_id'] for ptal in data['product.template.attribute.line']['data']}
            // return [('id', 'in', list(loaded_attribute_ids))]
            */
            return default;
        }

        protected async Task<ProductAttribute> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['name', 'display_type', 'template_value_ids', 'attribute_line_ids', 'create_variant']
            */
            return default;
        }

        protected async Task<ProductAttribute> OnchangeDisplayTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def _onchange_display_type(self):
            // if self.display_type == 'multi' and self.number_related_products == 0:
            //     self.create_variant = 'no_variant'
            */
            return default;
        }

        public async Task<ProductAttribute> OpenProductTemplateAttributeLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def action_open_product_template_attribute_lines(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Products"),
            //     'res_model': 'product.template.attribute.line',
            //     'view_mode': 'list,form',
            //     'domain': [('attribute_id', '=', self.id), ('product_tmpl_id.active', '=', 'True')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductAttribute> UnlinkExceptUsedOnProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def _unlink_except_used_on_product(self):
            // for pa in self:
            //     if pa.number_related_products:
            //         raise UserError(_(
            //             "You cannot delete the attribute %(attribute)s because it is used on the"
            //             " following products:\n%(products)s",
            //             attribute=pa.display_name,
            //             products=", ".join(pa.product_tmpl_ids.mapped('display_name')),
            //         ))
            */
            return default;
        }

        protected async Task<ProductAttribute> WithoutNoVariantAttributesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_attribute.py) ---
            // def _without_no_variant_attributes(self):
            // return self.filtered(lambda pa: pa.create_variant != 'no_variant')
            */
            return default;
        }
    }
}