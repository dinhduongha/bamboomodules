using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Lunch", Depends = new[] { "mail" })]
    public class LunchProductCategoryAppService : GenericApplicationService<LunchProductCategory>, ILunchProductCategoryAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        public LunchProductCategoryAppService(IRepository<LunchProductCategory, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _imageMixinAppService = imageMixinAppService;
        }

        protected async Task<LunchProductCategory> ComputeProductCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def _compute_product_count(self):
            // product_data = self.env['lunch.product']._read_group([('category_id', 'in', self.ids)], ['category_id'], ['__count'])
            // data = {category.id: count for category, count in product_data}
            // for category in self:
            //     category.product_count = data.get(category.id, 0)
            */
            return default;
        }

        protected async Task<LunchProductCategory> DefaultImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def _default_image(self):
            // return base64.b64encode(file_open('lunch/static/img/lunch.png', 'rb').read())
            */
            return default;
        }

        public async Task<LunchProductCategory> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def toggle_active(self):
            // """ Archiving related lunch product """
            // res = super().toggle_active()
            // Product = self.env['lunch.product'].with_context(active_test=False)
            // all_products = Product.search([('category_id', 'in', self.ids)])
            // all_products._sync_active_from_related()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}