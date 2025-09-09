using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockLocationController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockLocationCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/should-bypass-reservation")]
        public async Task<IActionResult> ShouldBypassReservationAsync(Guid id)
        {
            var result = await _appService.ShouldBypassReservationAsync(id);
            return Ok(result);
        }
    }
}