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
    public partial class LunchProductAppService
    {

        protected async Task<LunchProduct> ComputeIsAvailableAtInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_available_at) ---
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeIsNewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_new) ---
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeLastOrderDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_last_order_date) ---
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeProductImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_product_image) ---
            */
            return default;
        }

        protected async Task<LunchProduct> InverseIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        protected async Task<LunchProduct> SearchIsAvailableAtInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _search_is_available_at) ---
            */
            return default;
        }

        protected async Task<LunchProduct> SyncActiveFromRelatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _sync_active_from_related) ---
            */
            return default;
        }
    }
}