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
    public interface IStockWarehouseAppService : IGenericApplicationService<StockWarehouse>
    {
        Task<StockWarehouse> CopyDataAsync(StockWarehouseCopyDataRequestDto input);
        Task<StockWarehouse> CreateResupplyRoutesAsync(StockWarehouseCreateResupplyRoutesRequestDto input);
        Task<StockWarehouse> GetCurrentWarehousesAsync(Guid[] ids);
        Task<StockWarehouse> GetRulesDictAsync(Guid[] ids);
        Task<StockWarehouse> UpdateGlobalRouteDropshipSubcontractorAsync(Guid[] ids);
        Task<StockWarehouse> ViewAllRoutesAsync(Guid[] ids);
    }
}