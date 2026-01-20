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
    public partial class ProductAttributeAppService : GenericApplicationService<ProductAttribute>, IProductAttributeAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductAttributeAppService(IRepository<ProductAttribute, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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

        protected async Task<ProductAttribute> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_attribute.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['name', 'display_type', 'create_variant']
            */
            return default;
        }

        protected async Task<ProductAttribute> OnchangeDisablePreviewVariantsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_attribute.py) ---
            // def _onchange_disable_preview_variants(self):
            // """ The option to preview variants is only available for instantly created single variants.
            // """
            // if self.create_variant != 'always' or self.display_type == 'multi':
            //     self.preview_variants = 'hidden'
            //     self.is_thumbnail_visible = False
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