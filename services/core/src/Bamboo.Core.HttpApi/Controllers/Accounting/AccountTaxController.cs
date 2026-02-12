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
    [Route("api/v1/accounting/AccountTax")]
    public partial class AccountTaxController : AbpController
    {
        protected readonly IAccountTaxAppService _appService;
        public AccountTaxController(IAccountTaxAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("compute-all")]
        public async Task<IActionResult> ComputeAllAsync([FromBody] AccountTaxComputeAllRequestDto input)
        {
            var result = await _appService.ComputeAllAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountTaxCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("flatten-taxes-hierarchy")]
        public async Task<IActionResult> FlattenTaxesHierarchyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FlattenTaxesHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tax-tags")]
        public async Task<IActionResult> GetTaxTagsAsync([FromBody] AccountTaxGetTaxTagsRequestDto input)
        {
            var result = await _appService.GetTaxTagsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-amount")]
        public async Task<IActionResult> OnchangeAmountAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeAmountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-amount-type")]
        public async Task<IActionResult> OnchangeAmountTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeAmountTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-price-include")]
        public async Task<IActionResult> OnchangePriceIncludeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangePriceIncludeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-tax-group-id")]
        public async Task<IActionResult> ValidateTaxGroupIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateTaxGroupIdAsync(ids);
            return Ok(result);
        }
    }
    
}