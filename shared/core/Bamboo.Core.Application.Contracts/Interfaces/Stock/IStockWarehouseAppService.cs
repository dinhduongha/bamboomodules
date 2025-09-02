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