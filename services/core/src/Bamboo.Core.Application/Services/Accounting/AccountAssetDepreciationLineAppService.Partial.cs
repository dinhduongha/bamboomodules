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
    public partial class AccountAssetDepreciationLineAppService
    {

        protected async Task<AccountAssetDepreciationLine> GetMoveCheckInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _get_move_check) ---
            */
            return default;
        }

        protected async Task<AccountAssetDepreciationLine> GetMovePostedCheckInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _get_move_posted_check) ---
            */
            return default;
        }

        protected async Task<AccountAssetDepreciationLine> PrepareMoveGroupedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _prepare_move_grouped) ---
            */
            return default;
        }

        protected async Task<AccountAssetDepreciationLine> PrepareMoveInternalAsync(object line)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _prepare_move) ---
            */
            return default;
        }
    }
}