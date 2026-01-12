using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class UomUomController
    {
        
        [HttpPost]
        [Route("{id}/action-open-packaging-barcodes")]
        public async Task<IActionResult> ActionOpenPackagingBarcodesAsync(Guid id)
        {
            var result = await _appService.OpenPackagingBarcodesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compare")]
        public async Task<IActionResult> CompareAsync(Guid id, [FromBody] UomUomCompareRequestDto input)
        {
            var result = await _appService.CompareAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-zero")]
        public async Task<IActionResult> IsZeroAsync(Guid id, [FromBody] UomUomIsZeroRequestDto input)
        {
            var result = await _appService.IsZeroAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/round")]
        public async Task<IActionResult> RoundAsync(Guid id, [FromBody] UomUomRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(id, input);
            return Ok(result);
        }
    }
}