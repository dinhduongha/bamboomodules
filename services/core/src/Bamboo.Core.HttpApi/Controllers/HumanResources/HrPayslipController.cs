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
    [Route("api/v1/generic-modules/HrPayslip")]
    public partial class HrPayslipController : AbpController
    {
        protected readonly IHrPayslipAppService _appService;
        public HrPayslipController(IHrPayslipAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-payslip-cancel")]
        public async Task<IActionResult> PayslipCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PayslipCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-payslip-done")]
        public async Task<IActionResult> PayslipDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PayslipDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-payslip-draft")]
        public async Task<IActionResult> PayslipDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PayslipDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-done")]
        public async Task<IActionResult> CheckDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-sheet")]
        public async Task<IActionResult> ComputeSheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeSheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contract")]
        public async Task<IActionResult> GetContractAsync([FromBody] HrPayslipGetContractRequestDto input)
        {
            var result = await _appService.GetContractAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-inputs")]
        public async Task<IActionResult> GetInputsAsync([FromBody] HrPayslipGetInputsRequestDto input)
        {
            var result = await _appService.GetInputsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-salary-line-total")]
        public async Task<IActionResult> GetSalaryLineTotalAsync([FromBody] HrPayslipGetSalaryLineTotalRequestDto input)
        {
            var result = await _appService.GetSalaryLineTotalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-worked-day-lines")]
        public async Task<IActionResult> GetWorkedDayLinesAsync([FromBody] HrPayslipGetWorkedDayLinesRequestDto input)
        {
            var result = await _appService.GetWorkedDayLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-contract")]
        public async Task<IActionResult> OnchangeContractAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeContractAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-employee")]
        public async Task<IActionResult> OnchangeEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-employee-id")]
        public async Task<IActionResult> OnchangeEmployeeIdAsync([FromBody] HrPayslipOnchangeEmployeeIdRequestDto input)
        {
            var result = await _appService.OnchangeEmployeeIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refund-sheet")]
        public async Task<IActionResult> RefundSheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefundSheetAsync(ids);
            return Ok(result);
        }
    }
    
}