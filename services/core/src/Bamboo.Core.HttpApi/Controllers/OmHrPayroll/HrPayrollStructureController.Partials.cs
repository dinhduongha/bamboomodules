using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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