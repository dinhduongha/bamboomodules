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
    [Module("OmAccountAsset", Category = "Accounting", Depends = new[] { "account" })]
    public partial class AccountAssetAssetAppService : GenericAppService<AccountAssetAsset>, IAccountAssetAssetAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public AccountAssetAssetAppService(IRepository<AccountAssetAsset, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<AccountAssetAsset> ComputeDepreciationBoardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_depreciation_board) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAssetAsset> ComputeGeneratedEntriesAsync(AccountAssetAssetComputeGeneratedEntriesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_generated_entries) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> CopyDataAsync(AccountAssetAssetCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeCategoryIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeCategoryIdValuesAsync(AccountAssetAssetOnchangeCategoryIdValuesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id_values) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeCompanyIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_company_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeDateFirstDepreciationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_date_first_depreciation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeMethodTimeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_method_time) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> OpenEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: open_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> SetToCloseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_close) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> SetToDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAssetAsset> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}