using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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