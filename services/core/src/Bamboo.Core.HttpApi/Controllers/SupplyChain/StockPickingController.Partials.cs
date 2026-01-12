using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPickingController
    {
        
        [HttpPost]
        [Route("{id}/action-add-entire-packs")]
        public async Task<IActionResult> ActionAddEntirePacksAsync(Guid id, [FromBody] StockPickingAddEntirePacksRequestDto input)
        {
            var result = await _appService.AddEntirePacksAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-add-operations")]
        public async Task<IActionResult> ActionAddOperationsAsync(Guid id)
        {
            var result = await _appService.AddOperationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid id)
        {
            var result = await _appService.AssignAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-detailed-operations")]
        public async Task<IActionResult> ActionDetailedOperationsAsync(Guid id)
        {
            var result = await _appService.DetailedOperationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-next-transfer")]
        public async Task<IActionResult> ActionNextTransferAsync(Guid id)
        {
            var result = await _appService.NextTransferAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid id)
        {
            var result = await _appService.OpenLabelLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-label-type")]
        public async Task<IActionResult> ActionOpenLabelTypeAsync(Guid id)
        {
            var result = await _appService.OpenLabelTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-picking-move-tree")]
        public async Task<IActionResult> ActionPickingMoveTreeAsync(Guid id)
        {
            var result = await _appService.PickingMoveTreeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid id)
        {
            var result = await _appService.PutInPackAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-return")]
        public async Task<IActionResult> ActionRepairReturnAsync(Guid id)
        {
            var result = await _appService.RepairReturnAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-move-scrap")]
        public async Task<IActionResult> ActionSeeMoveScrapAsync(Guid id)
        {
            var result = await _appService.SeeMoveScrapAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-package-histories")]
        public async Task<IActionResult> ActionSeePackageHistoriesAsync(Guid id)
        {
            var result = await _appService.SeePackageHistoriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-packages")]
        public async Task<IActionResult> ActionSeePackagesAsync(Guid id)
        {
            var result = await _appService.SeePackagesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-returns")]
        public async Task<IActionResult> ActionSeeReturnsAsync(Guid id)
        {
            var result = await _appService.SeeReturnsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-subcontract-details")]
        public async Task<IActionResult> ActionShowSubcontractDetailsAsync(Guid id)
        {
            var result = await _appService.ShowSubcontractDetailsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-split-transfer")]
        public async Task<IActionResult> ActionSplitTransferAsync(Guid id)
        {
            var result = await _appService.SplitTransferAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-is-locked")]
        public async Task<IActionResult> ActionToggleIsLockedAsync(Guid id)
        {
            var result = await _appService.ToggleIsLockedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-batch")]
        public async Task<IActionResult> ActionViewBatchAsync(Guid id)
        {
            var result = await _appService.ViewBatchAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-reception-report")]
        public async Task<IActionResult> ActionViewReceptionReportAsync(Guid id)
        {
            var result = await _appService.ViewReceptionReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-repairs")]
        public async Task<IActionResult> ActionViewRepairsAsync(Guid id)
        {
            var result = await _appService.ViewRepairsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-subcontracting-source-purchase")]
        public async Task<IActionResult> ActionViewSubcontractingSourcePurchaseAsync(Guid id)
        {
            var result = await _appService.ViewSubcontractingSourcePurchaseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/assign-batch-user")]
        public async Task<IActionResult> AssignBatchUserAsync(Guid id, [FromBody] StockPickingAssignBatchUserRequestDto input)
        {
            var result = await _appService.AssignBatchUserAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync(Guid id)
        {
            var result = await _appService.ButtonScrapAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-validate")]
        public async Task<IActionResult> ButtonValidateAsync(Guid id)
        {
            var result = await _appService.ButtonValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/calculate-date-category")]
        public async Task<IActionResult> CalculateDateCategoryAsync(Guid id, [FromBody] StockPickingCalculateDateCategoryRequestDto input)
        {
            var result = await _appService.CalculateDateCategoryAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel-shipment")]
        public async Task<IActionResult> CancelShipmentAsync(Guid id)
        {
            var result = await _appService.CancelShipmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/date-category-to-domain")]
        public async Task<IActionResult> DateCategoryToDomainAsync(Guid id, [FromBody] StockPickingDateCategoryToDomainRequestDto input)
        {
            var result = await _appService.DateCategoryToDomainAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-print-picking")]
        public async Task<IActionResult> DoPrintPickingAsync(Guid id)
        {
            var result = await _appService.DoPrintPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-unreserve")]
        public async Task<IActionResult> DoUnreserveAsync(Guid id)
        {
            var result = await _appService.DoUnreserveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-click-graph")]
        public async Task<IActionResult> GetActionClickGraphAsync(Guid id)
        {
            var result = await _appService.GetClickGraphAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-incoming")]
        public async Task<IActionResult> GetActionPickingTreeIncomingAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeIncomingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-internal")]
        public async Task<IActionResult> GetActionPickingTreeInternalAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeInternalAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-outgoing")]
        public async Task<IActionResult> GetActionPickingTreeOutgoingAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeOutgoingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] StockPickingGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-multiple-carrier-tracking")]
        public async Task<IActionResult> GetMultipleCarrierTrackingAsync(Guid id)
        {
            var result = await _appService.GetMultipleCarrierTrackingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-return-label")]
        public async Task<IActionResult> PrintReturnLabelAsync(Guid id)
        {
            var result = await _appService.PrintReturnLabelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-to-shipper")]
        public async Task<IActionResult> SendToShipperAsync(Guid id)
        {
            var result = await _appService.SendToShipperAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/should-print-delivery-address")]
        public async Task<IActionResult> ShouldPrintDeliveryAddressAsync(Guid id)
        {
            var result = await _appService.ShouldPrintDeliveryAddressAsync(id);
            return Ok(result);
        }
    }
}