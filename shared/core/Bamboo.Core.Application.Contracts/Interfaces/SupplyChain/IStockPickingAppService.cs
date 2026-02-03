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
    public interface IStockPickingAppService : IGenericApplicationService<StockPicking>
    {
        Task<StockPicking> AddEntirePacksAsync(StockPickingAddEntirePacksRequestDto input);
        Task<StockPicking> AddOperationsAsync(Guid[] ids);
        Task<StockPicking> AssignAsync(Guid[] ids);
        Task<StockPicking> AssignBatchUserAsync(StockPickingAssignBatchUserRequestDto input);
        Task<StockPicking> ButtonScrapAsync(Guid[] ids);
        Task<StockPicking> ButtonValidateAsync(Guid[] ids);
        Task<StockPicking> CalculateDateCategoryAsync(StockPickingCalculateDateCategoryRequestDto input);
        Task<StockPicking> CancelAsync(Guid[] ids);
        Task<StockPicking> CancelShipmentAsync(Guid[] ids);
        Task<StockPicking> ConfirmAsync(Guid[] ids);
        Task<StockPicking> DateCategoryToDomainAsync(StockPickingDateCategoryToDomainRequestDto input);
        Task<StockPicking> DetailedOperationsAsync(Guid[] ids);
        Task<StockPicking> DoPrintPickingAsync(Guid[] ids);
        Task<StockPicking> DoUnreserveAsync(Guid[] ids);
        Task<StockPicking> GetClickGraphAsync(Guid[] ids);
        Task<StockPicking> GetEmptyListHelpAsync(StockPickingGetEmptyListHelpRequestDto input);
        Task<StockPicking> GetMultipleCarrierTrackingAsync(Guid[] ids);
        Task<StockPicking> GetPickingTreeIncomingAsync(Guid[] ids);
        Task<StockPicking> GetPickingTreeInternalAsync(Guid[] ids);
        Task<StockPicking> GetPickingTreeOutgoingAsync(Guid[] ids);
        Task<StockPicking> NextTransferAsync(Guid[] ids);
        Task<StockPicking> OpenLabelLayoutAsync(Guid[] ids);
        Task<StockPicking> OpenLabelTypeAsync(Guid[] ids);
        Task<StockPicking> OpenWebsiteUrlAsync(Guid[] ids);
        Task<StockPicking> PickingMoveTreeAsync(Guid[] ids);
        Task<StockPicking> PrintReturnLabelAsync(Guid[] ids);
        Task<StockPicking> PutInPackAsync(Guid[] ids);
        Task<StockPicking> RepairReturnAsync(Guid[] ids);
        Task<StockPicking> SeeMoveScrapAsync(Guid[] ids);
        Task<StockPicking> SeePackageHistoriesAsync(Guid[] ids);
        Task<StockPicking> SeePackagesAsync(Guid[] ids);
        Task<StockPicking> SeeReturnsAsync(Guid[] ids);
        Task<StockPicking> SendToShipperAsync(Guid[] ids);
        Task<StockPicking> ShouldPrintDeliveryAddressAsync(Guid[] ids);
        Task<StockPicking> ShowSubcontractDetailsAsync(Guid[] ids);
        Task<StockPicking> SplitTransferAsync(Guid[] ids);
        Task<StockPicking> ToggleIsLockedAsync(Guid[] ids);
        Task<StockPicking> ViewBatchAsync(Guid[] ids);
        Task<StockPicking> ViewMrpProductionAsync(Guid[] ids);
        Task<StockPicking> ViewReceptionReportAsync(Guid[] ids);
        Task<StockPicking> ViewRepairsAsync(Guid[] ids);
        Task<StockPicking> ViewSubcontractingSourcePurchaseAsync(Guid[] ids);
    }
}