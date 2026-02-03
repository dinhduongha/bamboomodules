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
    public interface IStockPickingBatchAppService : IGenericAppService<StockPickingBatch>
    {
        Task<StockPickingBatch> AssignAsync(Guid[] ids);
        Task<StockPickingBatch> BatchDetailedOperationsAsync(Guid[] ids);
        Task<StockPickingBatch> CancelAsync(Guid[] ids);
        Task<StockPickingBatch> ConfirmAsync(Guid[] ids);
        Task<StockPickingBatch> DoneAsync(Guid[] ids);
        Task<StockPickingBatch> MergeAsync(Guid[] ids);
        Task<StockPickingBatch> OnchangeScheduledDateAsync(Guid[] ids);
        Task<StockPickingBatch> OpenLabelLayoutAsync(Guid[] ids);
        Task<StockPickingBatch> OrderOnZipAsync(Guid[] ids);
        Task<StockPickingBatch> PrintAsync(Guid[] ids);
        Task<StockPickingBatch> PutInPackAsync(Guid[] ids);
        Task<StockPickingBatch> SeePackagesAsync(Guid[] ids);
        Task<StockPickingBatch> ViewReceptionReportAsync(Guid[] ids);
    }
}