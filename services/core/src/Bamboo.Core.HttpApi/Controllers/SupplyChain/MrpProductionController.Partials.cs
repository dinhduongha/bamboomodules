using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpProductionController
    {
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-clear-lot-producing-ids")]
        public async Task<IActionResult> ActionClearLotProducingIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClearLotProducingIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-bom")]
        public async Task<IActionResult> ActionGenerateBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-serial")]
        public async Task<IActionResult> ActionGenerateSerialAsync(MrpProductionGenerateSerialRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateSerialAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-type")]
        public async Task<IActionResult> ActionOpenLabelTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLabelTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-plan-with-components-availability")]
        public async Task<IActionResult> ActionPlanWithComponentsAvailabilityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PlanWithComponentsAvailabilityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-forecast-report")]
        public async Task<IActionResult> ActionProductForecastReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProductForecastReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-move-scrap")]
        public async Task<IActionResult> ActionSeeMoveScrapAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeMoveScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split")]
        public async Task<IActionResult> ActionSplitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SplitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split-subcontracting")]
        public async Task<IActionResult> ActionSplitSubcontractingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SplitSubcontractingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start")]
        public async Task<IActionResult> ActionStartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-is-locked")]
        public async Task<IActionResult> ActionToggleIsLockedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleIsLockedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-bom")]
        public async Task<IActionResult> ActionUpdateBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-analytic-accounts")]
        public async Task<IActionResult> ActionViewAnalyticAccountsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewAnalyticAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mo-delivery")]
        public async Task<IActionResult> ActionViewMoDeliveryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMoDeliveryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-move-wip")]
        public async Task<IActionResult> ActionViewMoveWipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMoveWipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-backorders")]
        public async Task<IActionResult> ActionViewMrpProductionBackordersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionBackordersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-childs")]
        public async Task<IActionResult> ActionViewMrpProductionChildsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionChildsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-sources")]
        public async Task<IActionResult> ActionViewMrpProductionSourcesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionSourcesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-unbuilds")]
        public async Task<IActionResult> ActionViewMrpProductionUnbuildsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionUnbuildsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase-orders")]
        public async Task<IActionResult> ActionViewPurchaseOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-reception-report")]
        public async Task<IActionResult> ActionViewReceptionReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewReceptionReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-repair-orders")]
        public async Task<IActionResult> ActionViewRepairOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRepairOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-orders")]
        public async Task<IActionResult> ActionViewSaleOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-serial-numbers")]
        public async Task<IActionResult> ActionViewSerialNumbersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSerialNumbersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-mark-done")]
        public async Task<IActionResult> ButtonMarkDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonMarkDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-plan")]
        public async Task<IActionResult> ButtonPlanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonPlanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unbuild")]
        public async Task<IActionResult> ButtonUnbuildAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUnbuildAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unplan")]
        public async Task<IActionResult> ButtonUnplanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUnplanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(MrpProductionCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-unreserve")]
        public async Task<IActionResult> DoUnreserveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoUnreserveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(MrpProductionGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pre-button-mark-done")]
        public async Task<IActionResult> PreButtonMarkDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreButtonMarkDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-qty-producing")]
        public async Task<IActionResult> SetQtyProducingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetQtyProducingAsync(ids);
            return Ok(result);
        }
    }
}