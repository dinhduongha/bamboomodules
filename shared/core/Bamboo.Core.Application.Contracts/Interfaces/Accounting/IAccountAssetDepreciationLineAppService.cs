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
    public interface IAccountAssetDepreciationLineAppService : IGenericApplicationService<AccountAssetDepreciationLine>
    {
        Task<AccountAssetDepreciationLine> CreateGroupedMoveAsync(AccountAssetDepreciationLineCreateGroupedMoveRequestDto input);
        Task<AccountAssetDepreciationLine> CreateMoveAsync(AccountAssetDepreciationLineCreateMoveRequestDto input);
        Task<AccountAssetDepreciationLine> LogMessageWhenPostedAsync(Guid[] ids);
        Task<AccountAssetDepreciationLine> PostLinesAndCloseAssetAsync(Guid[] ids);
    }
}