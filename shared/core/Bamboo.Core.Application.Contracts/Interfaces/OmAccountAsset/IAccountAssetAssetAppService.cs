using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAssetAssetAppService : IGenericApplicationService<AccountAssetAsset>
    {
        Task<AccountAssetAsset> ComputeDepreciationBoardAsync(Guid id);
        Task<AccountAssetAsset> ComputeGeneratedEntriesAsync(Guid id, AccountAssetAssetComputeGeneratedEntriesRequestDto input);
        Task<AccountAssetAsset> CopyDataAsync(Guid id, AccountAssetAssetCopyDataRequestDto input);
        Task<AccountAssetAsset> OnchangeCategoryIdAsync(Guid id);
        Task<AccountAssetAsset> OnchangeCategoryIdValuesAsync(Guid id, AccountAssetAssetOnchangeCategoryIdValuesRequestDto input);
        Task<AccountAssetAsset> OnchangeCompanyIdAsync(Guid id);
        Task<AccountAssetAsset> OnchangeDateFirstDepreciationAsync(Guid id);
        Task<AccountAssetAsset> OnchangeMethodTimeAsync(Guid id);
        Task<AccountAssetAsset> OpenEntriesAsync(Guid id);
        Task<AccountAssetAsset> SetToCloseAsync(Guid id);
        Task<AccountAssetAsset> SetToDraftAsync(Guid id);
        Task<AccountAssetAsset> ValidateAsync(Guid id);
    }
}