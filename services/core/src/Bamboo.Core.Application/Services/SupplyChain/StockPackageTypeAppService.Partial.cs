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
    public partial class StockPackageTypeAppService
    {

        protected async Task<StockPackageType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeHasQuantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _compute_has_quants) ---
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeLengthUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _compute_length_uom_name) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package_type.py, METHOD: _compute_length_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPackageType> GetDefaultLengthUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _get_default_length_uom) ---
            */
            return default;
        }

        protected async Task<StockPackageType> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _get_default_weight_uom) ---
            */
            return default;
        }

        protected async Task<StockPackageType> GetNextNameBySequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py, METHOD: _get_next_name_by_sequence) ---
            */
            return default;
        }

        protected async Task<StockPackageType> OnchangeCarrierTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package_type.py, METHOD: _onchange_carrier_type) ---
            */
            return default;
        }
    }
}