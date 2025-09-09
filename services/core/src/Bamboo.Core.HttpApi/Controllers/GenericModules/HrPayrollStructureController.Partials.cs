using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
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