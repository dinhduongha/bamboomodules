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
    public interface IStockPickingAppService : IGenericApplicationService<StockPicking>
    {
        Task<StockPicking> AddOperationsAsync(Guid id);
        Task<StockPicking> AssignAsync(Guid id);
        Task<StockPicking> AssignBatchUserAsync(Guid id, StockPickingAssignBatchUserRequestDto input);
        Task<StockPicking> ButtonScrapAsync(Guid id);
        Task<StockPicking> ButtonValidateAsync(Guid id);
        Task<StockPicking> CalculateDateCategoryAsync(Guid id, StockPickingCalculateDateCategoryRequestDto input);
        Task<StockPicking> CancelAsync(Guid id);
        Task<StockPicking> CancelShipmentAsync(Guid id);
        Task<StockPicking> ConfirmAsync(Guid id);
        Task<StockPicking> DateCategoryToDomainAsync(Guid id, StockPickingDateCategoryToDomainRequestDto input);
        Task<StockPicking> DetailedOperationsAsync(Guid id);
        Task<StockPicking> DoPrintPickingAsync(Guid id);
        Task<StockPicking> DoUnreserveAsync(Guid id);
        Task<StockPicking> GetClickGraphAsync(Guid id);
        Task<StockPicking> GetEmptyListHelpAsync(Guid id, StockPickingGetEmptyListHelpRequestDto input);
        Task<StockPicking> GetMultipleCarrierTrackingAsync(Guid id);
        Task<StockPicking> GetPickingTreeIncomingAsync(Guid id);
        Task<StockPicking> GetPickingTreeInternalAsync(Guid id);
        Task<StockPicking> GetPickingTreeOutgoingAsync(Guid id);
        Task<StockPicking> NextTransferAsync(Guid id);
        Task<StockPicking> OpenLabelLayoutAsync(Guid id);
        Task<StockPicking> OpenLabelTypeAsync(Guid id);
        Task<StockPicking> OpenWebsiteUrlAsync(Guid id);
        Task<StockPicking> PickingMoveTreeAsync(Guid id);
        Task<StockPicking> PrintReturnLabelAsync(Guid id);
        Task<StockPicking> PutInPackAsync(Guid id, StockPickingPutInPackRequestDto input);
        Task<StockPicking> RecordComponentsAsync(Guid id);
        Task<StockPicking> RepairReturnAsync(Guid id);
        Task<StockPicking> SeeMoveScrapAsync(Guid id);
        Task<StockPicking> SeePackagesAsync(Guid id);
        Task<StockPicking> SeeReturnsAsync(Guid id);
        Task<StockPicking> SendToShipperAsync(Guid id);
        Task<StockPicking> ShouldPrintDeliveryAddressAsync(Guid id);
        Task<StockPicking> SplitTransferAsync(Guid id);
        Task<StockPicking> ToggleIsLockedAsync(Guid id);
        Task<StockPicking> ViewBatchAsync(Guid id);
        Task<StockPicking> ViewMrpProductionAsync(Guid id);
        Task<StockPicking> ViewReceptionReportAsync(Guid id);
        Task<StockPicking> ViewRepairsAsync(Guid id);
        Task<StockPicking> ViewStockValuationLayersAsync(Guid id);
        Task<StockPicking> ViewSubcontractingSourcePurchaseAsync(Guid id);
    }
}