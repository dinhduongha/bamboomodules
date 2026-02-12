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
    public partial class LunchProductCategoryAppService
    {

        protected async Task<LunchProductCategory> ComputeProductCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _compute_product_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LunchProductCategory> DefaultImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _default_image) ---
            */
            return default;
        }

        protected async Task<LunchProductCategory> SyncActiveProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _sync_active_products) ---
            */
            return default;
        }
    }
}