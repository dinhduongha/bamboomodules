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
    public partial class ProductTemplateAttributeLineAppService
    {

        protected async Task<ProductTemplateAttributeLine> CheckValidValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _check_valid_values) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> ComputeValueCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _compute_value_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> IsConfigurableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _is_configurable) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplateAttributeLine> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_attribute.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplateAttributeLine> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_attribute.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> OnchangeAttributeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _onchange_attribute_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> PrepareCategoriesForDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_comparison, FILE: product_template_attribute_line.py, METHOD: _prepare_categories_for_display) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> PrepareSingleValueForDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template_attribute_line.py, METHOD: _prepare_single_value_for_display) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> UpdateProductTemplateAttributeValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _update_product_template_attribute_values) ---
            */
            return default;
        }

        protected async Task<ProductTemplateAttributeLine> WithoutNoVariantAttributesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template_attribute_line.py, METHOD: _without_no_variant_attributes) ---
            */
            return default;
        }
    }
}