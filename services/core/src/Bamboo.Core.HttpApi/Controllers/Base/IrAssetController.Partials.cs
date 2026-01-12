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
        [Route("{id}/filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(Guid id, [FromBody] IrAssetFilterDuplicateRequestDto input)
        {
            var result = await _appService.FilterDuplicateAsync(id, input);
            return Ok(result);
        }
    }
}