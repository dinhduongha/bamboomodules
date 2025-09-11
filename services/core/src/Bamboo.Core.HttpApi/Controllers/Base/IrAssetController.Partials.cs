using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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