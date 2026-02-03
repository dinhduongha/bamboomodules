using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAssetAssetAppService : IGenericAppService<AccountAssetAsset>
    {
        Task<AccountAssetAsset> ComputeDepreciationBoardAsync(Guid[] ids);
        Task<AccountAssetAsset> ComputeGeneratedEntriesAsync(AccountAssetAssetComputeGeneratedEntriesRequestDto input);
        Task<AccountAssetAsset> CopyDataAsync(AccountAssetAssetCopyDataRequestDto input);
        Task<AccountAssetAsset> OnchangeCategoryIdAsync(Guid[] ids);
        Task<AccountAssetAsset> OnchangeCategoryIdValuesAsync(AccountAssetAssetOnchangeCategoryIdValuesRequestDto input);
        Task<AccountAssetAsset> OnchangeCompanyIdAsync(Guid[] ids);
        Task<AccountAssetAsset> OnchangeDateFirstDepreciationAsync(Guid[] ids);
        Task<AccountAssetAsset> OnchangeMethodTimeAsync(Guid[] ids);
        Task<AccountAssetAsset> OpenEntriesAsync(Guid[] ids);
        Task<AccountAssetAsset> SetToCloseAsync(Guid[] ids);
        Task<AccountAssetAsset> SetToDraftAsync(Guid[] ids);
        Task<AccountAssetAsset> ValidateAsync(Guid[] ids);
    }
}