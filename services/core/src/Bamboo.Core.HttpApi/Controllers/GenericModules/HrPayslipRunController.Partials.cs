using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrPayslipRunController
    {
        
        [HttpPost]
        [Route("{id}/close-payslip-run")]
        public async Task<IActionResult> ClosePayslipRunAsync(Guid id)
        {
            var result = await _appService.ClosePayslipRunAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/done-payslip-run")]
        public async Task<IActionResult> DonePayslipRunAsync(Guid id)
        {
            var result = await _appService.DonePayslipRunAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/draft-payslip-run")]
        public async Task<IActionResult> DraftPayslipRunAsync(Guid id)
        {
            var result = await _appService.DraftPayslipRunAsync(id);
            return Ok(result);
        }
    }
}