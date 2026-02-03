using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAssetAssetController
    {
        
        [HttpPost]
        [Route("compute-depreciation-board")]
        public async Task<IActionResult> ComputeDepreciationBoardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeDepreciationBoardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-generated-entries")]
        public async Task<IActionResult> ComputeGeneratedEntriesAsync(AccountAssetAssetComputeGeneratedEntriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeGeneratedEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountAssetAssetCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-category-id")]
        public async Task<IActionResult> OnchangeCategoryIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeCategoryIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-category-id-values")]
        public async Task<IActionResult> OnchangeCategoryIdValuesAsync(AccountAssetAssetOnchangeCategoryIdValuesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.OnchangeCategoryIdValuesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-company-id")]
        public async Task<IActionResult> OnchangeCompanyIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeCompanyIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-date-first-depreciation")]
        public async Task<IActionResult> OnchangeDateFirstDepreciationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeDateFirstDepreciationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-method-time")]
        public async Task<IActionResult> OnchangeMethodTimeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeMethodTimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-entries")]
        public async Task<IActionResult> OpenEntriesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-close")]
        public async Task<IActionResult> SetToCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetToCloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-draft")]
        public async Task<IActionResult> SetToDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetToDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> ValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
    }
}