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
    public partial class LunchOrderAppService
    {

        protected async Task<LunchOrder> CheckToppingQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _check_topping_quantity) ---
            */
            return default;
        }

        protected async Task<LunchOrder> CheckWalletInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _check_wallet) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeAvailableOnDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_available_on_date) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeAvailableToppingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_available_toppings) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayAddButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_display_add_button) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayReorderButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_display_reorder_button) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayToppingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_display_toppings) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeOrderDeadlinePassedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_order_deadline_passed) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeProductImagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_product_images) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeTotalPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _compute_total_price) ---
            */
            return default;
        }

        protected async Task<LunchOrder> ExtractToppingsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _extract_toppings) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LunchOrder> FindMatchingLinesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _find_matching_lines) ---
            */
            return default;
        }

        protected async Task<LunchOrder> GetToppingIdsInternalAsync(object field, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: _get_topping_ids) ---
            */
            return default;
        }
    }
}