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
    public interface IStockScrapAppService : IGenericAppService<StockScrap>
    {
        Task<StockScrap> CheckAvailableQtyAsync(Guid[] ids);
        Task<StockScrap> DoReplenishAsync(StockScrapDoReplenishRequestDto input);
        Task<StockScrap> DoScrapAsync(Guid[] ids);
        Task<StockScrap> GetStockMoveLinesAsync(Guid[] ids);
        Task<StockScrap> GetStockPickingAsync(Guid[] ids);
        Task<StockScrap> ValidateAsync(Guid[] ids);
    }
}