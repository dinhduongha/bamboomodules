using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    public partial class PosOrderLineController
    {
        
        [HttpPost]
        [Route("{id}/get-existing-lots")]
        public async Task<IActionResult> GetExistingLotsAsync(Guid id, [FromBody] PosOrderLineGetExistingLotsRequestDto input)
        {
            var result = await _appService.GetExistingLotsAsync(id, input);
            return Ok(result);
        }
    }
}