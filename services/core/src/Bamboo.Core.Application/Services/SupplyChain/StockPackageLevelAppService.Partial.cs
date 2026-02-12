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
    public partial class StockPackageLevelAppService
    {

        protected async Task<StockPackageLevel> CheckMoveLinesMapQuantPackageInternalAsync(object package, object only_picked)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _check_move_lines_map_quant_package) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeFreshPackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_fresh_pack) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeIsDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_is_done) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeShowLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_show_lot) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> GenerateMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _generate_moves) ---
            */
            return default;
        }

        protected async Task<StockPackageLevel> SetIsDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_level.py, METHOD: _set_is_done) ---
            */
            return default;
        }
    }
}