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
    public partial class ProductTagAppService : GenericAppService<ProductTag>, IProductTagAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        public ProductTagAppService(IRepository<ProductTag, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
        }

        protected async Task<ProductTag> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if field_name == "image" and self.sudo().visible_to_customers:
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        protected async Task<ProductTag> ComputeHasImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py) ---
            // def _compute_has_image(self):
            // for record in self:
            //     record.has_image = bool(record.image)
            */
            return default;
        }

        protected async Task<ProductTag> ComputeProductIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _compute_product_ids(self):
            // for tag in self:
            //     tag.product_ids = tag.product_template_ids.product_variant_ids | tag.product_product_ids
            */
            return default;
        }

        public async Task<ProductTag> CopyDataAsync(ProductTagCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", tag.name)) for tag, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<ProductTag> GetDefaultTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _get_default_template_id(self):
            // return self.env['product.template'].browse(self.env.context.get('product_template_id'))
            */
            return default;
        }

        protected async Task<ProductTag> GetDefaultVariantIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _get_default_variant_id(self):
            // return self.env['product.product'].browse(self.env.context.get('product_variant_id'))
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTag> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['name', 'pos_description', 'color', 'has_image', 'write_date']
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTag> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py) ---
            // def _load_pos_self_data_domain(self, data, config):
            // return [('visible_to_customers', '=', True)]
            */
            return default;
        }

        protected async Task<ProductTag> SearchProductIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _search_product_ids(self, operator, operand):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // return ['|', ('product_template_ids.product_variant_ids', operator, operand), ('product_product_ids', operator, operand)]
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductTag> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py) ---
            // def write(self, vals):
            // if vals.get('pos_description') and is_html_empty(vals['pos_description']):
            //     vals['pos_description'] = ''
            // return super().write(vals)
            */
            return await base.WriteAsync(input);
        }
    }
}