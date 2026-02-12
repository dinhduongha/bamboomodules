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
    [Route("api/v1/accounting/AccountAssetAsset")]
    public partial class AccountAssetAssetController : AbpController
    {
        protected readonly IAccountAssetAssetAppService _appService;
        public AccountAssetAssetController(IAccountAssetAssetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("compute-depreciation-board")]
        public async Task<IActionResult> ComputeDepreciationBoardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeDepreciationBoardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-generated-entries")]
        public async Task<IActionResult> ComputeGeneratedEntriesAsync([FromBody] AccountAssetAssetComputeGeneratedEntriesRequestDto input)
        {
            var result = await _appService.ComputeGeneratedEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountAssetAssetCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-category-id")]
        public async Task<IActionResult> OnchangeCategoryIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeCategoryIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-category-id-values")]
        public async Task<IActionResult> OnchangeCategoryIdValuesAsync([FromBody] AccountAssetAssetOnchangeCategoryIdValuesRequestDto input)
        {
            var result = await _appService.OnchangeCategoryIdValuesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-company-id")]
        public async Task<IActionResult> OnchangeCompanyIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeCompanyIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-date-first-depreciation")]
        public async Task<IActionResult> OnchangeDateFirstDepreciationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeDateFirstDepreciationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-method-time")]
        public async Task<IActionResult> OnchangeMethodTimeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeMethodTimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-entries")]
        public async Task<IActionResult> OpenEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-close")]
        public async Task<IActionResult> SetToCloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetToCloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-draft")]
        public async Task<IActionResult> SetToDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetToDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
    }
    
}