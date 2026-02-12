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
    public partial class StockStorageCategoryAppService
    {

        protected async Task<StockStorageCategory> ComputeStorageCapacityIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py, METHOD: _compute_storage_capacity_ids) ---
            */
            return default;
        }

        protected async Task<StockStorageCategory> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockStorageCategory> SetStorageCapacityIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py, METHOD: _set_storage_capacity_ids) ---
            */
            return default;
        }
    }
}