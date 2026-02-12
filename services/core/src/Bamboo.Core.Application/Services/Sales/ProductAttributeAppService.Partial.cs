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
    public partial class ProductAttributeAppService
    {

        protected async Task<ProductAttribute> ComputeNumberRelatedProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: _compute_number_related_products) ---
            */
            return default;
        }

        protected async Task<ProductAttribute> ComputeProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: _compute_products) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductAttribute> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_attribute.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ProductAttribute> OnchangeDisablePreviewVariantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_attribute.py, METHOD: _onchange_disable_preview_variants) ---
            */
            return default;
        }

        protected async Task<ProductAttribute> OnchangeDisplayTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: _onchange_display_type) ---
            */
            return default;
        }

        protected async Task<ProductAttribute> UnlinkExceptUsedOnProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: _unlink_except_used_on_product) ---
            */
            return default;
        }

        protected async Task<ProductAttribute> WithoutNoVariantAttributesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: _without_no_variant_attributes) ---
            */
            return default;
        }
    }
}