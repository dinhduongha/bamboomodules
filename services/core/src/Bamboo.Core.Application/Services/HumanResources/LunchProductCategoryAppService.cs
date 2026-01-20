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
    [Module("Lunch", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class LunchProductCategoryAppService : GenericApplicationService<LunchProductCategory>, ILunchProductCategoryAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        public LunchProductCategoryAppService(IRepository<LunchProductCategory, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
        }

        public async Task<LunchProductCategory> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def action_archive(self):
            // super().action_archive()
            // self._sync_active_products()
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // with file_open('lunch/static/img/lunch.png', 'rb') as f:
            //     return base64.b64encode(f.read())
            */
            return default;
        }

        protected async Task<LunchProductCategory> SyncActiveProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def _sync_active_products(self):
            // """ Archiving related lunch product """
            // Product = self.env['lunch.product'].with_context(active_test=False)
            // all_products = Product.search([('category_id', 'in', self.ids)])
            // all_products._sync_active_from_related()
            */
            return default;
        }

        public async Task<LunchProductCategory> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def action_unarchive(self):
            // super().action_unarchive()
            // self._sync_active_products()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}