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
    [Route("api/v1/sales/PosSession")]
    public partial class PosSessionController : AbpController
    {
        protected readonly IPosSessionAppService _appService;
        public PosSessionController(IPosSessionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-pos-session-close")]
        public async Task<IActionResult> PosSessionCloseAsync([FromBody] PosSessionPosSessionCloseRequestDto input)
        {
            var result = await _appService.PosSessionCloseAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-closing-control")]
        public async Task<IActionResult> PosSessionClosingControlAsync([FromBody] PosSessionPosSessionClosingControlRequestDto input)
        {
            var result = await _appService.PosSessionClosingControlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-open")]
        public async Task<IActionResult> PosSessionOpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PosSessionOpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-session-validate")]
        public async Task<IActionResult> PosSessionValidateAsync([FromBody] PosSessionPosSessionValidateRequestDto input)
        {
            var result = await _appService.PosSessionValidateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-payments-list")]
        public async Task<IActionResult> ShowPaymentsListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowPaymentsListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-picking")]
        public async Task<IActionResult> StockPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-order")]
        public async Task<IActionResult> ViewOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("close-session-from-ui")]
        public async Task<IActionResult> CloseSessionFromUiAsync([FromBody] PosSessionCloseSessionFromUiRequestDto input)
        {
            var result = await _appService.CloseSessionFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-cash-in-out")]
        public async Task<IActionResult> DeleteCashInOutAsync([FromBody] PosSessionDeleteCashInOutRequestDto input)
        {
            var result = await _appService.DeleteCashInOutAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-opening-control-session")]
        public async Task<IActionResult> DeleteOpeningControlSessionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DeleteOpeningControlSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-local-data")]
        public async Task<IActionResult> FilterLocalDataAsync([FromBody] PosSessionFilterLocalDataRequestDto input)
        {
            var result = await _appService.FilterLocalDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-product-by-barcode")]
        public async Task<IActionResult> FindProductByBarcodeAsync([FromBody] PosSessionFindProductByBarcodeRequestDto input)
        {
            var result = await _appService.FindProductByBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cash-in-out-list")]
        public async Task<IActionResult> GetCashInOutListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCashInOutListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-closing-control-data")]
        public async Task<IActionResult> GetClosingControlDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetClosingControlDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pos-ui-product-pricelist-item-by-product")]
        public async Task<IActionResult> GetPosUiProductPricelistItemByProductAsync([FromBody] PosSessionGetPosUiProductPricelistItemByProductRequestDto input)
        {
            var result = await _appService.GetPosUiProductPricelistItemByProductAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-session-orders")]
        public async Task<IActionResult> GetSessionOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSessionOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-total-discount")]
        public async Task<IActionResult> GetTotalDiscountAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTotalDiscountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-data")]
        public async Task<IActionResult> LoadDataAsync([FromBody] PosSessionLoadDataRequestDto input)
        {
            var result = await _appService.LoadDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-data-params")]
        public async Task<IActionResult> LoadDataParamsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LoadDataParamsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-partner-message")]
        public async Task<IActionResult> LogPartnerMessageAsync([FromBody] PosSessionLogPartnerMessageRequestDto input)
        {
            var result = await _appService.LogPartnerMessageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-frontend-cb")]
        public async Task<IActionResult> OpenFrontendCbAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenFrontendCbAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-close-register-message")]
        public async Task<IActionResult> PostCloseRegisterMessageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostCloseRegisterMessageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-closing-cash-details")]
        public async Task<IActionResult> PostClosingCashDetailsAsync([FromBody] PosSessionPostClosingCashDetailsRequestDto input)
        {
            var result = await _appService.PostClosingCashDetailsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-opening-control")]
        public async Task<IActionResult> SetOpeningControlAsync([FromBody] PosSessionSetOpeningControlRequestDto input)
        {
            var result = await _appService.SetOpeningControlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-cash-register")]
        public async Task<IActionResult> ShowCashRegisterAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowCashRegisterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-journal-items")]
        public async Task<IActionResult> ShowJournalItemsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowJournalItemsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("try-cash-in-out")]
        public async Task<IActionResult> TryCashInOutAsync([FromBody] PosSessionTryCashInOutRequestDto input)
        {
            var result = await _appService.TryCashInOutAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-closing-control-state-session")]
        public async Task<IActionResult> UpdateClosingControlStateSessionAsync([FromBody] PosSessionUpdateClosingControlStateSessionRequestDto input)
        {
            var result = await _appService.UpdateClosingControlStateSessionAsync(input);
            return Ok(result);
        }
    }
    
}