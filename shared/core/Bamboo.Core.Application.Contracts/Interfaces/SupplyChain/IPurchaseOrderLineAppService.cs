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
    public interface IPurchaseOrderLineAppService : IGenericApplicationService<PurchaseOrderLine>
    {
        Task<PurchaseOrderLine> AddFromCatalogAsync(Guid[] ids);
        Task<PurchaseOrderLine> ChooseAsync(Guid[] ids);
        Task<PurchaseOrderLine> ClearQuantitiesAsync(Guid[] ids);
        Task<PurchaseOrderLine> GetParentSectionLineAsync(Guid[] ids);
        Task<PurchaseOrderLine> OnchangeProductIdAsync(Guid[] ids);
        Task<PurchaseOrderLine> OpenOrderAsync(Guid[] ids);
        Task<PurchaseOrderLine> ProductForecastReportAsync(Guid[] ids);
    }
}