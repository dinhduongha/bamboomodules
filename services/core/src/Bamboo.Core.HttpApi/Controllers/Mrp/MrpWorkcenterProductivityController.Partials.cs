using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    public partial class MrpWorkcenterProductivityController
    {
        
        [HttpPost]
        [Route("{id}/button-block")]
        public async Task<IActionResult> ButtonBlockAsync(Guid id)
        {
            var result = await _appService.ButtonBlockAsync(id);
            return Ok(result);
        }
    }
}