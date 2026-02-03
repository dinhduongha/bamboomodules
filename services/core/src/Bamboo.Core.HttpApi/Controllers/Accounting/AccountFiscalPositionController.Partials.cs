using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountFiscalPositionController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-foreign-taxes")]
        public async Task<IActionResult> ActionCreateForeignTaxesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateForeignTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-related-taxes")]
        public async Task<IActionResult> ActionOpenRelatedTaxesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRelatedTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-account")]
        public async Task<IActionResult> MapAccountAsync(AccountFiscalPositionMapAccountRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MapAccountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-tax")]
        public async Task<IActionResult> MapTaxAsync(AccountFiscalPositionMapTaxRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MapTaxAsync(input);
            return Ok(result);
        }
    }
}