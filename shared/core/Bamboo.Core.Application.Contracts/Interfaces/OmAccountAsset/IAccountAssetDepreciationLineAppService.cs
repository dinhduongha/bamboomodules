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
    public interface IAccountAssetDepreciationLineAppService : IGenericApplicationService<AccountAssetDepreciationLine>
    {
        Task<AccountAssetDepreciationLine> CreateGroupedMoveAsync(Guid id, AccountAssetDepreciationLineCreateGroupedMoveRequestDto input);
        Task<AccountAssetDepreciationLine> CreateMoveAsync(Guid id, AccountAssetDepreciationLineCreateMoveRequestDto input);
        Task<AccountAssetDepreciationLine> LogMessageWhenPostedAsync(Guid id);
        Task<AccountAssetDepreciationLine> PostLinesAndCloseAssetAsync(Guid id);
    }
}