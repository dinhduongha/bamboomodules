using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockPicking")]
    public partial class StockPickingController : AbpController
    {
        protected readonly IStockPickingAppService _appService;
        public StockPickingController(IStockPickingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-entire-packs")]
        public async Task<IActionResult> AddEntirePacksAsync([FromBody] StockPickingAddEntirePacksRequestDto input)
        {
            var result = await _appService.AddEntirePacksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-operations")]
        public async Task<IActionResult> AddOperationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> AssignAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-detailed-operations")]
        public async Task<IActionResult> DetailedOperationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DetailedOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-next-transfer")]
        public async Task<IActionResult> NextTransferAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NextTransferAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> OpenLabelLayoutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-type")]
        public async Task<IActionResult> OpenLabelTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLabelTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-picking-move-tree")]
        public async Task<IActionResult> PickingMoveTreeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PickingMoveTreeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> PutInPackAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-return")]
        public async Task<IActionResult> RepairReturnAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairReturnAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-move-scrap")]
        public async Task<IActionResult> SeeMoveScrapAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeMoveScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-package-histories")]
        public async Task<IActionResult> SeePackageHistoriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeePackageHistoriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-packages")]
        public async Task<IActionResult> SeePackagesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeePackagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-returns")]
        public async Task<IActionResult> SeeReturnsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeReturnsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-subcontract-details")]
        public async Task<IActionResult> ShowSubcontractDetailsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowSubcontractDetailsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split-transfer")]
        public async Task<IActionResult> SplitTransferAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SplitTransferAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-is-locked")]
        public async Task<IActionResult> ToggleIsLockedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleIsLockedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-batch")]
        public async Task<IActionResult> ViewBatchAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewBatchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ViewMrpProductionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-reception-report")]
        public async Task<IActionResult> ViewReceptionReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewReceptionReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-repairs")]
        public async Task<IActionResult> ViewRepairsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRepairsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-subcontracting-source-purchase")]
        public async Task<IActionResult> ViewSubcontractingSourcePurchaseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSubcontractingSourcePurchaseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-batch-user")]
        public async Task<IActionResult> AssignBatchUserAsync([FromBody] StockPickingAssignBatchUserRequestDto input)
        {
            var result = await _appService.AssignBatchUserAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-validate")]
        public async Task<IActionResult> ButtonValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("calculate-date-category")]
        public async Task<IActionResult> CalculateDateCategoryAsync([FromBody] StockPickingCalculateDateCategoryRequestDto input)
        {
            var result = await _appService.CalculateDateCategoryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel-shipment")]
        public async Task<IActionResult> CancelShipmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelShipmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("date-category-to-domain")]
        public async Task<IActionResult> DateCategoryToDomainAsync([FromBody] StockPickingDateCategoryToDomainRequestDto input)
        {
            var result = await _appService.DateCategoryToDomainAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-print-picking")]
        public async Task<IActionResult> DoPrintPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoPrintPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-unreserve")]
        public async Task<IActionResult> DoUnreserveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoUnreserveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-click-graph")]
        public async Task<IActionResult> GetClickGraphAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetClickGraphAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-incoming")]
        public async Task<IActionResult> GetPickingTreeIncomingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeIncomingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-internal")]
        public async Task<IActionResult> GetPickingTreeInternalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeInternalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-outgoing")]
        public async Task<IActionResult> GetPickingTreeOutgoingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeOutgoingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] StockPickingGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-multiple-carrier-tracking")]
        public async Task<IActionResult> GetMultipleCarrierTrackingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetMultipleCarrierTrackingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-return-label")]
        public async Task<IActionResult> PrintReturnLabelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintReturnLabelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-to-shipper")]
        public async Task<IActionResult> SendToShipperAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendToShipperAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("should-print-delivery-address")]
        public async Task<IActionResult> ShouldPrintDeliveryAddressAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShouldPrintDeliveryAddressAsync(ids);
            return Ok(result);
        }
    }
    
}