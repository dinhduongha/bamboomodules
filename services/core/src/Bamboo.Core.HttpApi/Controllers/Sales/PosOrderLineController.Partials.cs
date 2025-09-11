using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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