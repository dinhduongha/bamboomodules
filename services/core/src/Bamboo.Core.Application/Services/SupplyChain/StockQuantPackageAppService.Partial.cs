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
    public partial class StockQuantPackageAppService
    {

        protected async Task<StockQuantPackage> CheckMoveLinesMapQuantInternalAsync(object move_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _check_move_lines_map_quant) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputeOwnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_owner_id) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputePackageInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_package_info) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputeValidSsccInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_valid_sscc) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputeWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_quant_package.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputeWeightIsKgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_quant_package.py, METHOD: _compute_weight_is_kg) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_quant_package.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_quant_package.py, METHOD: _get_default_weight_uom) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> GetWeightInternalAsync(Guid picking_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_weight) ---
            */
            return default;
        }

        protected async Task<StockQuantPackage> SearchOwnerInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _search_owner) ---
            */
            return default;
        }
    }
}