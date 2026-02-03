using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountTaxController
    {
        
        [HttpPost]
        [Route("compute-all")]
        public async Task<IActionResult> ComputeAllAsync(AccountTaxComputeAllRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeAllAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountTaxCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("flatten-taxes-hierarchy")]
        public async Task<IActionResult> FlattenTaxesHierarchyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FlattenTaxesHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tax-tags")]
        public async Task<IActionResult> GetTaxTagsAsync(AccountTaxGetTaxTagsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTaxTagsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-amount")]
        public async Task<IActionResult> OnchangeAmountAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeAmountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-amount-type")]
        public async Task<IActionResult> OnchangeAmountTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeAmountTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-price-include")]
        public async Task<IActionResult> OnchangePriceIncludeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangePriceIncludeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-tax-group-id")]
        public async Task<IActionResult> ValidateTaxGroupIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateTaxGroupIdAsync(ids);
            return Ok(result);
        }
    }
}