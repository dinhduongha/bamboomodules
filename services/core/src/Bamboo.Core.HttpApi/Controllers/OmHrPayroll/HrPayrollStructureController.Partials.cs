using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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