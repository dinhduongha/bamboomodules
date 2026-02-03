using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosSessionController
    {
        
        [HttpPost]
        [Route("action-pos-session-close")]
        public async Task<IActionResult> ActionPosSessionCloseAsync(PosSessionPosSessionCloseRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PosSessionCloseAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-closing-control")]
        public async Task<IActionResult> ActionPosSessionClosingControlAsync(PosSessionPosSessionClosingControlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PosSessionClosingControlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-open")]
        public async Task<IActionResult> ActionPosSessionOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosSessionOpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-validate")]
        public async Task<IActionResult> ActionPosSessionValidateAsync(PosSessionPosSessionValidateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PosSessionValidateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-payments-list")]
        public async Task<IActionResult> ActionShowPaymentsListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowPaymentsListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-picking")]
        public async Task<IActionResult> ActionStockPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-order")]
        public async Task<IActionResult> ActionViewOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("close-session-from-ui")]
        public async Task<IActionResult> CloseSessionFromUiAsync(PosSessionCloseSessionFromUiRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CloseSessionFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-cash-in-out")]
        public async Task<IActionResult> DeleteCashInOutAsync(PosSessionDeleteCashInOutRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DeleteCashInOutAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-opening-control-session")]
        public async Task<IActionResult> DeleteOpeningControlSessionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DeleteOpeningControlSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-local-data")]
        public async Task<IActionResult> FilterLocalDataAsync(PosSessionFilterLocalDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FilterLocalDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-product-by-barcode")]
        public async Task<IActionResult> FindProductByBarcodeAsync(PosSessionFindProductByBarcodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FindProductByBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cash-in-out-list")]
        public async Task<IActionResult> GetCashInOutListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCashInOutListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-closing-control-data")]
        public async Task<IActionResult> GetClosingControlDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetClosingControlDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pos-ui-product-pricelist-item-by-product")]
        public async Task<IActionResult> GetPosUiProductPricelistItemByProductAsync(PosSessionGetPosUiProductPricelistItemByProductRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetPosUiProductPricelistItemByProductAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-session-orders")]
        public async Task<IActionResult> GetSessionOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSessionOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-total-discount")]
        public async Task<IActionResult> GetTotalDiscountAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTotalDiscountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-data")]
        public async Task<IActionResult> LoadDataAsync(PosSessionLoadDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-data-params")]
        public async Task<IActionResult> LoadDataParamsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadDataParamsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-partner-message")]
        public async Task<IActionResult> LogPartnerMessageAsync(PosSessionLogPartnerMessageRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LogPartnerMessageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-frontend-cb")]
        public async Task<IActionResult> OpenFrontendCbAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenFrontendCbAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-close-register-message")]
        public async Task<IActionResult> PostCloseRegisterMessageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostCloseRegisterMessageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-closing-cash-details")]
        public async Task<IActionResult> PostClosingCashDetailsAsync(PosSessionPostClosingCashDetailsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PostClosingCashDetailsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-opening-control")]
        public async Task<IActionResult> SetOpeningControlAsync(PosSessionSetOpeningControlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetOpeningControlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-cash-register")]
        public async Task<IActionResult> ShowCashRegisterAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowCashRegisterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-journal-items")]
        public async Task<IActionResult> ShowJournalItemsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowJournalItemsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("try-cash-in-out")]
        public async Task<IActionResult> TryCashInOutAsync(PosSessionTryCashInOutRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.TryCashInOutAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-closing-control-state-session")]
        public async Task<IActionResult> UpdateClosingControlStateSessionAsync(PosSessionUpdateClosingControlStateSessionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateClosingControlStateSessionAsync(input);
            return Ok(result);
        }
    }
}