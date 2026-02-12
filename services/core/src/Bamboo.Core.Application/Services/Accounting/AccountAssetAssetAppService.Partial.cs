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
    public partial class AccountAssetAssetAppService
    {

        protected async Task<AccountAssetAsset> AmountResidualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _amount_residual) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> CheckProrataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _check_prorata) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ComputeBoardAmountInternalAsync(object sequence, object residual_amount, object amount_to_depr, object undone_dotation_number, List<Guid> posted_depreciation_line_ids, object total_days, object depreciation_date)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_amount) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ComputeBoardUndoneDotationNbInternalAsync(object depreciation_date, object total_days)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_undone_dotation_nb) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ComputeEntriesInternalAsync(object date, object group_entries)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_entries) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAssetAsset> CronGenerateEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _cron_generate_entries) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> EntryCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _entry_count) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> GetDisposalMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _get_disposal_moves) ---
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ReturnDisposalViewInternalAsync(List<Guid> move_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _return_disposal_view) ---
            */
            return default;
        }
    }
}