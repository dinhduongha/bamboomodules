using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockStorageCategoryController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockStorageCategoryCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
    }
}