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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-foreign-taxes")]
        public async Task<IActionResult> ActionCreateForeignTaxesAsync(Guid id)
        {
            var result = await _appService.CreateForeignTaxesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-related-taxes")]
        public async Task<IActionResult> ActionOpenRelatedTaxesAsync(Guid id)
        {
            var result = await _appService.OpenRelatedTaxesAsync(id);
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
    }
}