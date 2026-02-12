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
    public partial class ProductTagAppService
    {

        protected async Task<ProductTag> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<ProductTag> ComputeHasImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py, METHOD: _compute_has_image) ---
            */
            return default;
        }

        protected async Task<ProductTag> ComputeProductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _compute_product_ids) ---
            */
            return default;
        }

        protected async Task<ProductTag> GetDefaultTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _get_default_template_id) ---
            */
            return default;
        }

        protected async Task<ProductTag> GetDefaultVariantIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _get_default_variant_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTag> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTag> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<ProductTag> SearchProductIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _search_product_ids) ---
            */
            return default;
        }
    }
}