using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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