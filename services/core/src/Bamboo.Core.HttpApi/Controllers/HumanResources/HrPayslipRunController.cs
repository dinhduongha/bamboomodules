using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/generic-modules/HrPayslipRun")]
    public partial class HrPayslipRunController : AbpController
    {
        protected readonly IHrPayslipRunAppService _appService;
        public HrPayslipRunController(IHrPayslipRunAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("close-payslip-run")]
        public async Task<IActionResult> ClosePayslipRunAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClosePayslipRunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("done-payslip-run")]
        public async Task<IActionResult> DonePayslipRunAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DonePayslipRunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("draft-payslip-run")]
        public async Task<IActionResult> DraftPayslipRunAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DraftPayslipRunAsync(ids);
            return Ok(result);
        }
    }
    
}