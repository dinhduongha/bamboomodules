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
        Task<StockWarehouseOrderpoint> CheckProductIsNotKitAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> GetHorizonDaysAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> OpenOrderpointsAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> ProductForecastReportAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> RemoveManualQtyToOrderAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> ReplenishAsync(StockWarehouseOrderpointReplenishRequestDto input);
        Task<StockWarehouseOrderpoint> ReplenishAutoAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> StockReplenishmentInfoAsync(Guid[] ids);
        Task<StockWarehouseOrderpoint> ViewPurchaseAsync(Guid[] ids);
    }
}