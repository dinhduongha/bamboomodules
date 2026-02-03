using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrAssetController
    {
        
        [HttpPost]
        [Route("filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(IrAssetFilterDuplicateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FilterDuplicateAsync(input);
            return Ok(result);
        }
    }
}