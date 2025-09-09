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