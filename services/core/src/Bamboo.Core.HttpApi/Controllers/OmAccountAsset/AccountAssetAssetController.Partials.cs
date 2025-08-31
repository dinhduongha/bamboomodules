using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    public partial class AccountAssetAssetController
    {
        
        [HttpPost]
        [Route("{id}/compute-depreciation-board")]
        public async Task<IActionResult> ComputeDepreciationBoardAsync(Guid id)
        {
            var result = await _appService.ComputeDepreciationBoardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-generated-entries")]
        public async Task<IActionResult> ComputeGeneratedEntriesAsync(Guid id, [FromBody] AccountAssetAssetComputeGeneratedEntriesRequestDto input)
        {
            var result = await _appService.ComputeGeneratedEntriesAsync(id, input.Date, input.AssetType);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountAssetAssetCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-category-id")]
        public async Task<IActionResult> OnchangeCategoryIdAsync(Guid id)
        {
            var result = await _appService.OnchangeCategoryIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-category-id-values")]
        public async Task<IActionResult> OnchangeCategoryIdValuesAsync(Guid id, [FromBody] AccountAssetAssetOnchangeCategoryIdValuesRequestDto input)
        {
            var result = await _appService.OnchangeCategoryIdValuesAsync(id, input.CategoryId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-company-id")]
        public async Task<IActionResult> OnchangeCompanyIdAsync(Guid id)
        {
            var result = await _appService.OnchangeCompanyIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-date-first-depreciation")]
        public async Task<IActionResult> OnchangeDateFirstDepreciationAsync(Guid id)
        {
            var result = await _appService.OnchangeDateFirstDepreciationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-method-time")]
        public async Task<IActionResult> OnchangeMethodTimeAsync(Guid id)
        {
            var result = await _appService.OnchangeMethodTimeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-entries")]
        public async Task<IActionResult> OpenEntriesAsync(Guid id)
        {
            var result = await _appService.OpenEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-to-close")]
        public async Task<IActionResult> SetToCloseAsync(Guid id)
        {
            var result = await _appService.SetToCloseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-to-draft")]
        public async Task<IActionResult> SetToDraftAsync(Guid id)
        {
            var result = await _appService.SetToDraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate")]
        public async Task<IActionResult> ValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
    }
}