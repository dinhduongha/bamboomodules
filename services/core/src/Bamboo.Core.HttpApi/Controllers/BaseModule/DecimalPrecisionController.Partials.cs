using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class DecimalPrecisionController
    {
        
        [HttpPost]
        [Route("{id}/precision-get")]
        public async Task<IActionResult> PrecisionGetAsync(Guid id, [FromBody] DecimalPrecisionPrecisionGetRequestDto input)
        {
            var result = await _appService.PrecisionGetAsync(id, input);
            return Ok(result);
        }
    }
}