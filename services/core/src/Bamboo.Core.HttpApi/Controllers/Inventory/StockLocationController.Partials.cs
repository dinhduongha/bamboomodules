using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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