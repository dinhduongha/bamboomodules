using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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