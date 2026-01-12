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
    public interface IRepairOrderAppService : IGenericApplicationService<RepairOrder>
    {
        Task<RepairOrder> AddFromCatalogAsync(Guid id);
        Task<RepairOrder> AssignAsync(Guid id);
        Task<RepairOrder> ComputeLotIdAsync(Guid id);
        Task<RepairOrder> ComputeProductUomAsync(Guid id);
        Task<RepairOrder> CreateSaleOrderAsync(Guid id);
        Task<RepairOrder> ExplodeAsync(Guid id);
        Task<RepairOrder> OnchangeProductUomAsync(Guid id);
        Task<RepairOrder> PrintRepairOrderAsync(Guid id);
        Task<RepairOrder> RepairCancelAsync(Guid id);
        Task<RepairOrder> RepairCancelDraftAsync(Guid id);
        Task<RepairOrder> RepairDoneAsync(Guid id);
        Task<RepairOrder> RepairEndAsync(Guid id);
        Task<RepairOrder> RepairStartAsync(Guid id);
        Task<RepairOrder> UnreserveAsync(Guid id);
        Task<RepairOrder> ValidateAsync(Guid id);
        Task<RepairOrder> ViewMrpProductionsAsync(Guid id);
        Task<RepairOrder> ViewPurchaseOrdersAsync(Guid id);
        Task<RepairOrder> ViewSaleOrderAsync(Guid id);
    }
}