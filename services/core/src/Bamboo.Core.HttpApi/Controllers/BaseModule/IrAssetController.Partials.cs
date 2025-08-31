using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrAssetController
    {
        
        [HttpPost]
        [Route("{id}/filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(Guid id, [FromBody] IrAssetFilterDuplicateRequestDto input)
        {
            var result = await _appService.FilterDuplicateAsync(id, input.WebsiteId);
            return Ok(result);
        }
    }
}