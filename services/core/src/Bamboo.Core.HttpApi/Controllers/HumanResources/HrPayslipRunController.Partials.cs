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
        [Route("close-payslip-run")]
        public async Task<IActionResult> ClosePayslipRunAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClosePayslipRunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("done-payslip-run")]
        public async Task<IActionResult> DonePayslipRunAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DonePayslipRunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("draft-payslip-run")]
        public async Task<IActionResult> DraftPayslipRunAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DraftPayslipRunAsync(ids);
            return Ok(result);
        }
    }
}