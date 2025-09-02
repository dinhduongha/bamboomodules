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
    public interface IPurchaseOrderLineAppService : IGenericApplicationService<PurchaseOrderLine>
    {
        Task<PurchaseOrderLine> AddFromCatalogAsync(Guid id);
        Task<PurchaseOrderLine> ChooseAsync(Guid id);
        Task<PurchaseOrderLine> ClearQuantitiesAsync(Guid id);
        Task<PurchaseOrderLine> OnchangeProductIdAsync(Guid id);
        Task<PurchaseOrderLine> OnchangeProductIdWarningAsync(Guid id);
        Task<PurchaseOrderLine> OpenOrderAsync(Guid id);
        Task<PurchaseOrderLine> ProductForecastReportAsync(Guid id);
        Task<PurchaseOrderLine> PurchaseHistoryAsync(Guid id);
    }
}