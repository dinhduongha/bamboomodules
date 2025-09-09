using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IStockWarehouseAppService : IGenericApplicationService<StockWarehouse>
    {
        Task<StockWarehouse> CopyDataAsync(Guid id, StockWarehouseCopyDataRequestDto input);
        Task<StockWarehouse> CreateResupplyRoutesAsync(Guid id, StockWarehouseCreateResupplyRoutesRequestDto input);
        Task<StockWarehouse> GetCurrentWarehousesAsync(Guid id);
        Task<StockWarehouse> GetRulesDictAsync(Guid id);
        Task<StockWarehouse> UpdateGlobalRouteDropshipSubcontractorAsync(Guid id);
        Task<StockWarehouse> ViewAllRoutesAsync(Guid id);
    }
}