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
    public interface IStockScrapAppService : IGenericApplicationService<StockScrap>
    {
        Task<StockScrap> CheckAvailableQtyAsync(Guid id);
        Task<StockScrap> DoReplenishAsync(Guid id, StockScrapDoReplenishRequestDto input);
        Task<StockScrap> DoScrapAsync(Guid id);
        Task<StockScrap> GetStockMoveLinesAsync(Guid id);
        Task<StockScrap> GetStockPickingAsync(Guid id);
        Task<StockScrap> ValidateAsync(Guid id);
    }
}