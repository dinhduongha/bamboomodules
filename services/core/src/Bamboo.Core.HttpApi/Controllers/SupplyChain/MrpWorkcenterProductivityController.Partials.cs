using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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