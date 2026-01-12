using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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