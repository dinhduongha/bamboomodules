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
    public interface IStockMoveLineAppService : IGenericApplicationService<StockMoveLine>
    {
        Task<StockMoveLine> GetMoveLineQuantMatchAsync(StockMoveLineGetMoveLineQuantMatchRequestDto input);
        Task<StockMoveLine> OpenAddToWaveAsync(Guid[] ids);
        Task<StockMoveLine> OpenReferenceAsync(Guid[] ids);
        Task<StockMoveLine> PutInPackAsync(Guid[] ids);
        Task<StockMoveLine> RevertInventoryAsync(Guid[] ids);
    }
}