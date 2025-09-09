using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var result = await _appService.AdjustValsCountryIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/map-account")]
        public async Task<IActionResult> MapAccountAsync(Guid id, [FromBody] AccountFiscalPositionMapAccountRequestDto input)
        {
            var result = await _appService.MapAccountAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/map-tax")]
        public async Task<IActionResult> MapTaxAsync(Guid id, [FromBody] AccountFiscalPositionMapTaxRequestDto input)
        {
            var result = await _appService.MapTaxAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/raise-vat-error-message")]
        public async Task<IActionResult> RaiseVatErrorMessageAsync(Guid id, [FromBody] AccountFiscalPositionRaiseVatErrorMessageRequestDto input)
        {
            var result = await _appService.RaiseVatErrorMessageAsync(id, input);
            return Ok(result);
        }
    }
}