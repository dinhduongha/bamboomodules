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
    public class ProductTagAppService : GenericApplicationService<ProductTag>, IProductTagAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        public ProductTagAppService(IRepository<ProductTag, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
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

        public async Task<ProductTag> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", tag.name)) for tag, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<ProductTag> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['name']
            */
            return default;
        }

        protected async Task<ProductTag> SearchProductIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _search_product_ids(self, operator, operand):
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return [('product_template_ids.product_variant_ids', operator, operand), ('product_product_ids', operator, operand)]
            // return ['|', ('product_template_ids.product_variant_ids', operator, operand), ('product_product_ids', operator, operand)]
            */
            return default;
        }
    }
}