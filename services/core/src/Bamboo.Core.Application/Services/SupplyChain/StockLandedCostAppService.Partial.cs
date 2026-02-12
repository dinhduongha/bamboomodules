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
    public partial class StockLandedCostAppService
    {

        protected async Task<StockLandedCost> CheckCanValidateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _check_can_validate) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> CheckSumInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _check_sum) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> ComputeTotalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _compute_total_amount) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> DefaultAccountJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _default_account_journal_id) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> GetTargetedMoveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_landed_costs, FILE: stock_landed_cost.py, METHOD: _get_targeted_move_ids) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _get_targeted_move_ids) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> OnchangeTargetModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_landed_costs, FILE: stock_landed_cost.py, METHOD: _onchange_target_model) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _onchange_target_model) ---
            */
            return default;
        }

        protected async Task<StockLandedCost> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _track_subtype) ---
            */
            return default;
        }
    }
}