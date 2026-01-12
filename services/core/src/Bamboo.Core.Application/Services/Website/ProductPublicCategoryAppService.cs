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
    [Module("WebsiteSale", Category = "Website", Depends = new[] { "website", "sale", "website_payment", "website_mail", "portal_rating", "digest", "delivery", "html_builder" })]
    public class ProductPublicCategoryAppService : GenericApplicationService<ProductPublicCategory>, IProductPublicCategoryAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ProductPublicCategoryAppService(IRepository<ProductPublicCategory, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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

        protected async Task<ProductPublicCategory> ComputeHasPublishedProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_has_published_products(self):
            // grouped_product_templates = self.env['product.template']._read_group(
            //     domain=[('public_categ_ids', 'in', self.ids), ('is_published', '=', True)],
            //     groupby=['public_categ_ids']
            // )
            // published_category_ids = {group[0].id for group in grouped_product_templates}
            // for category in self:
            //     has_published = category.id in published_category_ids
            //     category.has_published_products = (
            //         has_published or any(c.has_published_products for c in category.child_id)
            //     )
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

        protected async Task<ProductPublicCategory> GetAvailableCategoryDomainInternalAsync(Guid website_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _get_available_category_domain(self, website_id):
            // """Build a search domain for product categories to be used in dynamic snippets.
            // 
            // :param int website_id: ID of the current website
            // :return: A domain to filter product categories for the given website
            // :rtype: Domain
            // """
            // domain = Domain('website_id', 'in', [False, website_id])
            // # Public and portal users should only see categories with published products.
            // if not self.env.user.has_group('website.group_website_designer'):
            //     domain &= Domain('has_published_products', '=', True)
            // return domain
            */
            return default;
        }

        public async Task<ProductPublicCategory> GetAvailableSnippetCategoriesAsync(Guid id, ProductPublicCategoryGetAvailableSnippetCategoriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def get_available_snippet_categories(self, website_id):
            // """Return parent categories available for selection in the dynamic category snippet.
            // 
            // :param int website_id: ID of the current website
            // :return: Available parent categories
            // :rtype: list[dict]
            // """
            // child_count_by_parent = self._read_group(
            //     domain=self._get_available_category_domain(website_id),
            //     aggregates=['id:count'],
            //     groupby=['parent_id'],
            // )
            // return [{
            //     'id': parent_category.id,
            //     'name': f'{parent_category.name} ({child_count})',
            // } for parent_category, child_count in child_count_by_parent if parent_category]
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<ProductPublicCategory> SearchHasPublishedProductsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_has_published_products(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // published_categ_ids = self._search(
            //     [('product_tmpl_ids.is_published', 'in', True)]
            // ).get_result_ids()
            // # Note that if the `value` is False, the ORM will invert the domain below
            // return [
            //     '|',
            //     ('id', 'in', published_categ_ids),
            //     ('id', 'parent_of', published_categ_ids),
            // ]
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