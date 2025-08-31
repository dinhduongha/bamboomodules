using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class DecimalPrecisionController
    {
        
        [HttpPost]
        [Route("{id}/precision-get")]
        public async Task<IActionResult> PrecisionGetAsync(Guid id, [FromBody] DecimalPrecisionPrecisionGetRequestDto input)
        {
            var result = await _appService.PrecisionGetAsync(id, input.Application);
            return Ok(result);
        }
    }
}