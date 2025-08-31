using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountTaxController
    {
        
        [HttpPost]
        [Route("{id}/compute-all")]
        public async Task<IActionResult> ComputeAllAsync(Guid id, [FromBody] AccountTaxComputeAllRequestDto input)
        {
            var result = await _appService.ComputeAllAsync(id, input.PriceUnit, input.Currency, input.Quantity, input.Product, input.Partner, input.IsRefund, input.HandlePriceInclude, input.IncludeCabaTags, input.RoundingMethod);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountTaxCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/flatten-taxes-hierarchy")]
        public async Task<IActionResult> FlattenTaxesHierarchyAsync(Guid id)
        {
            var result = await _appService.FlattenTaxesHierarchyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-tax-tags")]
        public async Task<IActionResult> GetTaxTagsAsync(Guid id, [FromBody] AccountTaxGetTaxTagsRequestDto input)
        {
            var result = await _appService.GetTaxTagsAsync(id, input.IsRefund, input.RepartitionType);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-amount")]
        public async Task<IActionResult> OnchangeAmountAsync(Guid id)
        {
            var result = await _appService.OnchangeAmountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-amount-type")]
        public async Task<IActionResult> OnchangeAmountTypeAsync(Guid id)
        {
            var result = await _appService.OnchangeAmountTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-price-include")]
        public async Task<IActionResult> OnchangePriceIncludeAsync(Guid id)
        {
            var result = await _appService.OnchangePriceIncludeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-tax-group-id")]
        public async Task<IActionResult> ValidateTaxGroupIdAsync(Guid id)
        {
            var result = await _appService.ValidateTaxGroupIdAsync(id);
            return Ok(result);
        }
    }
}