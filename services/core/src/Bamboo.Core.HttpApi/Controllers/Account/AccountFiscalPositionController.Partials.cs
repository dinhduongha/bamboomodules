using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountFiscalPositionController
    {
        
        [HttpPost]
        [Route("{id}/action-create-foreign-taxes")]
        public async Task<IActionResult> ActionCreateForeignTaxesAsync(Guid id)
        {
            var result = await _appService.CreateForeignTaxesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/adjust-vals-country-id")]
        public async Task<IActionResult> AdjustValsCountryIdAsync(Guid id, [FromBody] AccountFiscalPositionAdjustValsCountryIdRequestDto input)
        {
            var result = await _appService.AdjustValsCountryIdAsync(id, input.Vals);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/map-account")]
        public async Task<IActionResult> MapAccountAsync(Guid id, [FromBody] AccountFiscalPositionMapAccountRequestDto input)
        {
            var result = await _appService.MapAccountAsync(id, input.Account);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/map-tax")]
        public async Task<IActionResult> MapTaxAsync(Guid id, [FromBody] AccountFiscalPositionMapTaxRequestDto input)
        {
            var result = await _appService.MapTaxAsync(id, input.Taxes);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/raise-vat-error-message")]
        public async Task<IActionResult> RaiseVatErrorMessageAsync(Guid id, [FromBody] AccountFiscalPositionRaiseVatErrorMessageRequestDto input)
        {
            var result = await _appService.RaiseVatErrorMessageAsync(id, input.Country);
            return Ok(result);
        }
    }
}