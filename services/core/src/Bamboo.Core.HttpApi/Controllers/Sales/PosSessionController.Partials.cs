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
        [Route("{id}/action-pos-session-close")]
        public async Task<IActionResult> ActionPosSessionCloseAsync(Guid id, [FromBody] PosSessionPosSessionCloseRequestDto input)
        {
            var result = await _appService.PosSessionCloseAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-session-closing-control")]
        public async Task<IActionResult> ActionPosSessionClosingControlAsync(Guid id, [FromBody] PosSessionPosSessionClosingControlRequestDto input)
        {
            var result = await _appService.PosSessionClosingControlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-session-open")]
        public async Task<IActionResult> ActionPosSessionOpenAsync(Guid id)
        {
            var result = await _appService.PosSessionOpenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-session-validate")]
        public async Task<IActionResult> ActionPosSessionValidateAsync(Guid id, [FromBody] PosSessionPosSessionValidateRequestDto input)
        {
            var result = await _appService.PosSessionValidateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-payments-list")]
        public async Task<IActionResult> ActionShowPaymentsListAsync(Guid id)
        {
            var result = await _appService.ShowPaymentsListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stock-picking")]
        public async Task<IActionResult> ActionStockPickingAsync(Guid id)
        {
            var result = await _appService.StockPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-order")]
        public async Task<IActionResult> ActionViewOrderAsync(Guid id)
        {
            var result = await _appService.ViewOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/close-session-from-ui")]
        public async Task<IActionResult> CloseSessionFromUiAsync(Guid id, [FromBody] PosSessionCloseSessionFromUiRequestDto input)
        {
            var result = await _appService.CloseSessionFromUiAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/delete-cash-in-out")]
        public async Task<IActionResult> DeleteCashInOutAsync(Guid id, [FromBody] PosSessionDeleteCashInOutRequestDto input)
        {
            var result = await _appService.DeleteCashInOutAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/delete-opening-control-session")]
        public async Task<IActionResult> DeleteOpeningControlSessionAsync(Guid id)
        {
            var result = await _appService.DeleteOpeningControlSessionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/filter-local-data")]
        public async Task<IActionResult> FilterLocalDataAsync(Guid id, [FromBody] PosSessionFilterLocalDataRequestDto input)
        {
            var result = await _appService.FilterLocalDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/find-product-by-barcode")]
        public async Task<IActionResult> FindProductByBarcodeAsync(Guid id, [FromBody] PosSessionFindProductByBarcodeRequestDto input)
        {
            var result = await _appService.FindProductByBarcodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-cash-in-out-list")]
        public async Task<IActionResult> GetCashInOutListAsync(Guid id)
        {
            var result = await _appService.GetCashInOutListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-closing-control-data")]
        public async Task<IActionResult> GetClosingControlDataAsync(Guid id)
        {
            var result = await _appService.GetClosingControlDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-pos-ui-product-pricelist-item-by-product")]
        public async Task<IActionResult> GetPosUiProductPricelistItemByProductAsync(Guid id, [FromBody] PosSessionGetPosUiProductPricelistItemByProductRequestDto input)
        {
            var result = await _appService.GetPosUiProductPricelistItemByProductAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-session-orders")]
        public async Task<IActionResult> GetSessionOrdersAsync(Guid id)
        {
            var result = await _appService.GetSessionOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-total-discount")]
        public async Task<IActionResult> GetTotalDiscountAsync(Guid id)
        {
            var result = await _appService.GetTotalDiscountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-data")]
        public async Task<IActionResult> LoadDataAsync(Guid id, [FromBody] PosSessionLoadDataRequestDto input)
        {
            var result = await _appService.LoadDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-data-params")]
        public async Task<IActionResult> LoadDataParamsAsync(Guid id)
        {
            var result = await _appService.LoadDataParamsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/log-partner-message")]
        public async Task<IActionResult> LogPartnerMessageAsync(Guid id, [FromBody] PosSessionLogPartnerMessageRequestDto input)
        {
            var result = await _appService.LogPartnerMessageAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-frontend-cb")]
        public async Task<IActionResult> OpenFrontendCbAsync(Guid id)
        {
            var result = await _appService.OpenFrontendCbAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/post-close-register-message")]
        public async Task<IActionResult> PostCloseRegisterMessageAsync(Guid id)
        {
            var result = await _appService.PostCloseRegisterMessageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/post-closing-cash-details")]
        public async Task<IActionResult> PostClosingCashDetailsAsync(Guid id, [FromBody] PosSessionPostClosingCashDetailsRequestDto input)
        {
            var result = await _appService.PostClosingCashDetailsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-opening-control")]
        public async Task<IActionResult> SetOpeningControlAsync(Guid id, [FromBody] PosSessionSetOpeningControlRequestDto input)
        {
            var result = await _appService.SetOpeningControlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/show-cash-register")]
        public async Task<IActionResult> ShowCashRegisterAsync(Guid id)
        {
            var result = await _appService.ShowCashRegisterAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/show-journal-items")]
        public async Task<IActionResult> ShowJournalItemsAsync(Guid id)
        {
            var result = await _appService.ShowJournalItemsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/try-cash-in-out")]
        public async Task<IActionResult> TryCashInOutAsync(Guid id, [FromBody] PosSessionTryCashInOutRequestDto input)
        {
            var result = await _appService.TryCashInOutAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-closing-control-state-session")]
        public async Task<IActionResult> UpdateClosingControlStateSessionAsync(Guid id, [FromBody] PosSessionUpdateClosingControlStateSessionRequestDto input)
        {
            var result = await _appService.UpdateClosingControlStateSessionAsync(id, input);
            return Ok(result);
        }
    }
}