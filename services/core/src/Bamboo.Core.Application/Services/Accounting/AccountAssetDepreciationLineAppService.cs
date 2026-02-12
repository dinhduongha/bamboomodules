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
    [Module("OmAccountAsset", Category = "Accounting", Depends = new[] { "account" })]
    public partial class AccountAssetDepreciationLineAppService : GenericAppService<AccountAssetDepreciationLine>, IAccountAssetDepreciationLineAppService
    {

        public AccountAssetDepreciationLineAppService(IRepository<AccountAssetDepreciationLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AccountAssetDepreciationLine> CreateGroupedMoveAsync(AccountAssetDepreciationLineCreateGroupedMoveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: create_grouped_move) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetDepreciationLine> CreateMoveAsync(AccountAssetDepreciationLineCreateMoveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: create_move) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetDepreciationLine> LogMessageWhenPostedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: log_message_when_posted) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetDepreciationLine> PostLinesAndCloseAssetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: post_lines_and_close_asset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}