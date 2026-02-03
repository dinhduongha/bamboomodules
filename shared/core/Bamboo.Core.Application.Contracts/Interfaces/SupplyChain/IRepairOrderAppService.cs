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
    public interface IRepairOrderAppService : IGenericAppService<RepairOrder>
    {
        Task<RepairOrder> AddFromCatalogAsync(Guid[] ids);
        Task<RepairOrder> AssignAsync(Guid[] ids);
        Task<RepairOrder> ComputeLotIdAsync(Guid[] ids);
        Task<RepairOrder> ComputeProductUomAsync(Guid[] ids);
        Task<RepairOrder> CreateSaleOrderAsync(Guid[] ids);
        Task<RepairOrder> ExplodeAsync(Guid[] ids);
        Task<RepairOrder> GenerateSerialAsync(Guid[] ids);
        Task<RepairOrder> MessagePostAsync(Guid[] ids);
        Task<RepairOrder> OnchangeProductUomAsync(Guid[] ids);
        Task<RepairOrder> PrintRepairOrderAsync(Guid[] ids);
        Task<RepairOrder> RepairCancelAsync(Guid[] ids);
        Task<RepairOrder> RepairCancelDraftAsync(Guid[] ids);
        Task<RepairOrder> RepairDoneAsync(Guid[] ids);
        Task<RepairOrder> RepairEndAsync(Guid[] ids);
        Task<RepairOrder> RepairStartAsync(Guid[] ids);
        Task<RepairOrder> UnreserveAsync(Guid[] ids);
        Task<RepairOrder> ValidateAsync(Guid[] ids);
        Task<RepairOrder> ViewMrpProductionsAsync(Guid[] ids);
        Task<RepairOrder> ViewPurchaseOrdersAsync(Guid[] ids);
        Task<RepairOrder> ViewSaleOrderAsync(Guid[] ids);
    }
}