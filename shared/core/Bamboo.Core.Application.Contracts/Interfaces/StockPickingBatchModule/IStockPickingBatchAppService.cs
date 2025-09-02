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
    public interface IStockPickingBatchAppService : IGenericApplicationService<StockPickingBatch>
    {
        Task<StockPickingBatch> AssignAsync(Guid id);
        Task<StockPickingBatch> CancelAsync(Guid id);
        Task<StockPickingBatch> ConfirmAsync(Guid id);
        Task<StockPickingBatch> DoneAsync(Guid id);
        Task<StockPickingBatch> OnchangeScheduledDateAsync(Guid id);
        Task<StockPickingBatch> OpenLabelLayoutAsync(Guid id);
        Task<StockPickingBatch> OrderOnZipAsync(Guid id);
        Task<StockPickingBatch> PrintAsync(Guid id);
        Task<StockPickingBatch> PutInPackAsync(Guid id);
        Task<StockPickingBatch> ViewReceptionReportAsync(Guid id);
    }
}