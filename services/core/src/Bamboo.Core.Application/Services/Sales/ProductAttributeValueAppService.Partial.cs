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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class ProductAttributeValueAppService
    {

        protected async Task<ProductAttributeValue> ComputeDefaultExtraPriceChangedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _compute_default_extra_price_changed) ---
            */
            return default;
        }

        protected async Task<ProductAttributeValue> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductAttributeValue> ComputeIsUsedOnProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _compute_is_used_on_products) ---
            */
            return default;
        }

        protected async Task<ProductAttributeValue> GetDefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        protected async Task<ProductAttributeValue> UnlinkExceptUsedOnProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _unlink_except_used_on_product) ---
            */
            return default;
        }

        protected async Task<ProductAttributeValue> WithoutNoVariantAttributesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: _without_no_variant_attributes) ---
            */
            return default;
        }
    }
}