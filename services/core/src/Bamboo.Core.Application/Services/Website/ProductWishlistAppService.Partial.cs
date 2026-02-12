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
    public partial class ProductWishlistAppService
    {

        [ApiModel]
        protected async Task<ProductWishlist> AddToWishlistInternalAsync(Guid pricelist_id, Guid currency_id, Guid website_id, object price, Guid product_id, Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _add_to_wishlist) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductWishlist> CheckWishlistFromSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _check_wishlist_from_session) ---
            */
            return default;
        }

        protected async Task<ProductWishlist> ComputeStockNotificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_wishlist.py, METHOD: _compute_stock_notification) ---
            */
            return default;
        }

        protected async Task<ProductWishlist> GcSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _gc_sessions) ---
            */
            return default;
        }

        protected async Task<ProductWishlist> InverseStockNotificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_wishlist.py, METHOD: _inverse_stock_notification) ---
            */
            return default;
        }
    }
}