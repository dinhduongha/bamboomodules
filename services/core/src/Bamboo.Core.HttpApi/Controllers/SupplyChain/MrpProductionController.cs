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
    [Route("api/v1/supply-chain/MrpProduction")]
    public partial class MrpProductionController : AbpController
    {
        protected readonly IMrpProductionAppService _appService;
        public MrpProductionController(IMrpProductionAppService appService) { _appService = appService; }
        
        
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
        [Route("action-clear-lot-producing-ids")]
        public async Task<IActionResult> ClearLotProducingIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClearLotProducingIdsAsync(ids);
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
        [Route("action-generate-bom")]
        public async Task<IActionResult> GenerateBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GenerateBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-serial")]
        public async Task<IActionResult> GenerateSerialAsync([FromBody] MrpProductionGenerateSerialRequestDto input)
        {
            var result = await _appService.GenerateSerialAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> MergeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MergeAsync(ids);
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
        [Route("action-plan-with-components-availability")]
        public async Task<IActionResult> PlanWithComponentsAvailabilityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PlanWithComponentsAvailabilityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-forecast-report")]
        public async Task<IActionResult> ProductForecastReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProductForecastReportAsync(ids);
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
        [Route("action-split")]
        public async Task<IActionResult> SplitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SplitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split-subcontracting")]
        public async Task<IActionResult> SplitSubcontractingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SplitSubcontractingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start")]
        public async Task<IActionResult> StartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StartAsync(ids);
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
        [Route("action-update-bom")]
        public async Task<IActionResult> UpdateBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-analytic-accounts")]
        public async Task<IActionResult> ViewAnalyticAccountsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAnalyticAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mo-delivery")]
        public async Task<IActionResult> ViewMoDeliveryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMoDeliveryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-move-wip")]
        public async Task<IActionResult> ViewMoveWipAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMoveWipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-backorders")]
        public async Task<IActionResult> ViewMrpProductionBackordersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionBackordersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-childs")]
        public async Task<IActionResult> ViewMrpProductionChildsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionChildsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-sources")]
        public async Task<IActionResult> ViewMrpProductionSourcesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionSourcesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production-unbuilds")]
        public async Task<IActionResult> ViewMrpProductionUnbuildsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionUnbuildsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase-orders")]
        public async Task<IActionResult> ViewPurchaseOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(ids);
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
        [Route("action-view-repair-orders")]
        public async Task<IActionResult> ViewRepairOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRepairOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-orders")]
        public async Task<IActionResult> ViewSaleOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-serial-numbers")]
        public async Task<IActionResult> ViewSerialNumbersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSerialNumbersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-mark-done")]
        public async Task<IActionResult> ButtonMarkDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonMarkDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-plan")]
        public async Task<IActionResult> ButtonPlanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonPlanAsync(ids);
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
        [Route("button-unbuild")]
        public async Task<IActionResult> ButtonUnbuildAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUnbuildAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unplan")]
        public async Task<IActionResult> ButtonUnplanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUnplanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] MrpProductionCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
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
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] MrpProductionGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pre-button-mark-done")]
        public async Task<IActionResult> PreButtonMarkDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreButtonMarkDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-qty-producing")]
        public async Task<IActionResult> SetQtyProducingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetQtyProducingAsync(ids);
            return Ok(result);
        }
    }
    
}