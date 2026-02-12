using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class ProductPublicCategoryAppService
    {

        protected async Task<ProductPublicCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductPublicCategory> ComputeHasPublishedProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_has_published_products) ---
            */
            return default;
        }

        protected async Task<ProductPublicCategory> ComputeParentsAndSelfInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_parents_and_self) ---
            */
            return default;
        }

        protected async Task<ProductPublicCategory> DefaultSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPublicCategory> GetAvailableCategoryDomainInternalAsync(Guid website_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _get_available_category_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPublicCategory> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPublicCategory> SearchHasPublishedProductsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_has_published_products) ---
            */
            return default;
        }

        protected async Task<ProductPublicCategory> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_render_results) ---
            */
            return default;
        }
    }
}