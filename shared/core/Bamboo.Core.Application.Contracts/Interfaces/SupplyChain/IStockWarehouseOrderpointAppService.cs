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
    public interface IStockWarehouseOrderpointAppService : IGenericApplicationService<StockWarehouseOrderpoint>
    {
        Task<StockWarehouseOrderpoint> CheckProductIsNotKitAsync(Guid id);
        Task<StockWarehouseOrderpoint> GetHorizonDaysAsync(Guid id);
        Task<StockWarehouseOrderpoint> OpenOrderpointsAsync(Guid id);
        Task<StockWarehouseOrderpoint> ProductForecastReportAsync(Guid id);
        Task<StockWarehouseOrderpoint> RemoveManualQtyToOrderAsync(Guid id);
        Task<StockWarehouseOrderpoint> ReplenishAsync(Guid id, StockWarehouseOrderpointReplenishRequestDto input);
        Task<StockWarehouseOrderpoint> ReplenishAutoAsync(Guid id);
        Task<StockWarehouseOrderpoint> StockReplenishmentInfoAsync(Guid id);
        Task<StockWarehouseOrderpoint> ViewPurchaseAsync(Guid id);
    }
}