using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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