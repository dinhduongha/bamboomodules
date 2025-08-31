using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    public partial class MrpProductionController
    {
        
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
        [Route("{id}/action-generate-bom")]
        public async Task<IActionResult> ActionGenerateBomAsync(Guid id)
        {
            var result = await _appService.GenerateBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-generate-serial")]
        public async Task<IActionResult> ActionGenerateSerialAsync(Guid id)
        {
            var result = await _appService.GenerateSerialAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mass-produce")]
        public async Task<IActionResult> ActionMassProduceAsync(Guid id)
        {
            var result = await _appService.MassProduceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid id)
        {
            var result = await _appService.MergeAsync(id);
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
        [Route("{id}/action-plan-with-components-availability")]
        public async Task<IActionResult> ActionPlanWithComponentsAvailabilityAsync(Guid id)
        {
            var result = await _appService.PlanWithComponentsAvailabilityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-product-forecast-report")]
        public async Task<IActionResult> ActionProductForecastReportAsync(Guid id)
        {
            var result = await _appService.ProductForecastReportAsync(id);
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
        [Route("{id}/action-split")]
        public async Task<IActionResult> ActionSplitAsync(Guid id)
        {
            var result = await _appService.SplitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-start")]
        public async Task<IActionResult> ActionStartAsync(Guid id)
        {
            var result = await _appService.StartAsync(id);
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
        [Route("{id}/action-update-bom")]
        public async Task<IActionResult> ActionUpdateBomAsync(Guid id)
        {
            var result = await _appService.UpdateBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-analytic-accounts")]
        public async Task<IActionResult> ActionViewAnalyticAccountsAsync(Guid id)
        {
            var result = await _appService.ViewAnalyticAccountsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mo-delivery")]
        public async Task<IActionResult> ActionViewMoDeliveryAsync(Guid id)
        {
            var result = await _appService.ViewMoDeliveryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production-backorders")]
        public async Task<IActionResult> ActionViewMrpProductionBackordersAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionBackordersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production-childs")]
        public async Task<IActionResult> ActionViewMrpProductionChildsAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionChildsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production-sources")]
        public async Task<IActionResult> ActionViewMrpProductionSourcesAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionSourcesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production-unbuilds")]
        public async Task<IActionResult> ActionViewMrpProductionUnbuildsAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionUnbuildsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-purchase-orders")]
        public async Task<IActionResult> ActionViewPurchaseOrdersAsync(Guid id)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(id);
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
        [Route("{id}/action-view-repair-orders")]
        public async Task<IActionResult> ActionViewRepairOrdersAsync(Guid id)
        {
            var result = await _appService.ViewRepairOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-orders")]
        public async Task<IActionResult> ActionViewSaleOrdersAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-valuation-layers")]
        public async Task<IActionResult> ActionViewStockValuationLayersAsync(Guid id)
        {
            var result = await _appService.ViewStockValuationLayersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-mark-done")]
        public async Task<IActionResult> ButtonMarkDoneAsync(Guid id)
        {
            var result = await _appService.ButtonMarkDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-plan")]
        public async Task<IActionResult> ButtonPlanAsync(Guid id)
        {
            var result = await _appService.ButtonPlanAsync(id);
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
        [Route("{id}/button-unbuild")]
        public async Task<IActionResult> ButtonUnbuildAsync(Guid id)
        {
            var result = await _appService.ButtonUnbuildAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-unplan")]
        public async Task<IActionResult> ButtonUnplanAsync(Guid id)
        {
            var result = await _appService.ButtonUnplanAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] MrpProductionCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
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
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] MrpProductionGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input.HelpMessage);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-linked-sale-orders")]
        public async Task<IActionResult> GetLinkedSaleOrdersAsync(Guid id)
        {
            var result = await _appService.GetLinkedSaleOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pre-button-mark-done")]
        public async Task<IActionResult> PreButtonMarkDoneAsync(Guid id)
        {
            var result = await _appService.PreButtonMarkDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-qty-producing")]
        public async Task<IActionResult> SetQtyProducingAsync(Guid id)
        {
            var result = await _appService.SetQtyProducingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/subcontracting-record-component")]
        public async Task<IActionResult> SubcontractingRecordComponentAsync(Guid id)
        {
            var result = await _appService.SubcontractingRecordComponentAsync(id);
            return Ok(result);
        }
    }
}