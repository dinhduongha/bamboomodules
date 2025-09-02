using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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