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
    [Module("WebsiteSale", Depends = new[] { "website", "sale", "website_payment", "website_mail", "portal_rating", "digest", "delivery" })]
    public class ProductPublicCategoryAppService : GenericApplicationService<ProductPublicCategory>, IProductPublicCategoryAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ProductPublicCategoryAppService(IRepository<ProductPublicCategory, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _imageMixinAppService = imageMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<ProductPublicCategory> CheckParentIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def check_parent_id(self):
            // if self._has_cycle():
            //     raise ValueError(self.env._("Error! You cannot create recursive categories."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductPublicCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_display_name(self):
            // for category in self:
            //     category.display_name = " / ".join(category.parents_and_self.mapped(
            //         lambda cat: cat.name or self.env._("New")
            //     ))
            */
            return default;
        }

        protected async Task<ProductPublicCategory> ComputeParentsAndSelfInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_parents_and_self(self):
            // for category in self:
            //     if category.parent_path:
            //         category.parents_and_self = self.env['product.public.category'].browse([int(p) for p in category.parent_path.split('/')[:-1]])
            //     else:
            //         category.parents_and_self = category
            */
            return default;
        }

        protected async Task<ProductPublicCategory> DefaultSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _default_sequence(self):
            // cat = self.search([], limit=1, order='sequence DESC')
            // if cat:
            //     return cat.sequence + 5
            // return 10000
            */
            return default;
        }

        protected async Task<ProductPublicCategory> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('website_description')
            //     fetch_fields.append('website_description')
            //     mapping['description'] = {'name': 'website_description', 'type': 'text', 'match': True, 'html': True}
            // return {
            //     'model': 'product.public.category',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-folder-o',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            */
            return default;
        }

        protected async Task<ProductPublicCategory> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/shop/category/%s' % data['id']
            // return results_data
            */
            return default;
        }
    }
}