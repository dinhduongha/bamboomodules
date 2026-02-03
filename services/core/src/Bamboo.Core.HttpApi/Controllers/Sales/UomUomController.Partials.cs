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
        [Route("action-open-packaging-barcodes")]
        public async Task<IActionResult> ActionOpenPackagingBarcodesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenPackagingBarcodesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compare")]
        public async Task<IActionResult> CompareAsync(UomUomCompareRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CompareAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-zero")]
        public async Task<IActionResult> IsZeroAsync(UomUomIsZeroRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsZeroAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync(UomUomRoundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
    }
}