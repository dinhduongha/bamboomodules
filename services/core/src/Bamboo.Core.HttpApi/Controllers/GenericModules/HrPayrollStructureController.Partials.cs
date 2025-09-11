using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrPayrollStructureController
    {
        
        [HttpPost]
        [Route("{id}/get-all-rules")]
        public async Task<IActionResult> GetAllRulesAsync(Guid id)
        {
            var result = await _appService.GetAllRulesAsync(id);
            return Ok(result);
        }
    }
}