using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    public partial class PosOrderLineController
    {
        
        [HttpPost]
        [Route("{id}/get-existing-lots")]
        public async Task<IActionResult> GetExistingLotsAsync(Guid id, [FromBody] PosOrderLineGetExistingLotsRequestDto input)
        {
            var result = await _appService.GetExistingLotsAsync(id, input.CompanyId, input.ProductId);
            return Ok(result);
        }
    }
}