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
    public partial class LunchSupplierAppService
    {

        protected async Task<LunchSupplier> AvailableOnDateInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _available_on_date) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> CancelFutureDaysInternalAsync(object weekdays)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _cancel_future_days) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeAvailableTodayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_available_today) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeButtonsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_buttons) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeOrderDeadlinePassedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_order_deadline_passed) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> GetCurrentOrdersInternalAsync(object state)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _get_current_orders) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> SearchAvailableTodayInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _search_available_today) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> SendAutoEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _send_auto_email) ---
            */
            return default;
        }

        protected async Task<LunchSupplier> SyncCronInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _sync_cron) ---
            */
            return default;
        }
    }
}