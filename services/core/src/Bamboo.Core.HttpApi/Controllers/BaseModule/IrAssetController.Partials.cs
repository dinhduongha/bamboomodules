using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrAssetController
    {
        
        [HttpPost]
        [Route("{id}/filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(Guid id, [FromBody] IrAssetFilterDuplicateRequestDto input)
        {
            var result = await _appService.FilterDuplicateAsync(id, input);
            return Ok(result);
        }
    }
}