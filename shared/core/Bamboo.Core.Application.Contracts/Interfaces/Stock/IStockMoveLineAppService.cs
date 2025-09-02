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
    public interface IStockMoveLineAppService : IGenericApplicationService<StockMoveLine>
    {
        Task<StockMoveLine> GetMoveLineQuantMatchAsync(Guid id, StockMoveLineGetMoveLineQuantMatchRequestDto input);
        Task<StockMoveLine> InitAsync(Guid id);
        Task<StockMoveLine> OpenAddToWaveAsync(Guid id);
        Task<StockMoveLine> OpenReferenceAsync(Guid id);
        Task<StockMoveLine> PutInPackAsync(Guid id);
        Task<StockMoveLine> RevertInventoryAsync(Guid id);
    }
}