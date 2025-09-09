using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    public partial class HrPayslipController
    {
        
        [HttpPost]
        [Route("{id}/action-payslip-cancel")]
        public async Task<IActionResult> ActionPayslipCancelAsync(Guid id)
        {
            var result = await _appService.PayslipCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-payslip-done")]
        public async Task<IActionResult> ActionPayslipDoneAsync(Guid id)
        {
            var result = await _appService.PayslipDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-payslip-draft")]
        public async Task<IActionResult> ActionPayslipDraftAsync(Guid id)
        {
            var result = await _appService.PayslipDraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid id)
        {
            var result = await _appService.SendEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-done")]
        public async Task<IActionResult> CheckDoneAsync(Guid id)
        {
            var result = await _appService.CheckDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-sheet")]
        public async Task<IActionResult> ComputeSheetAsync(Guid id)
        {
            var result = await _appService.ComputeSheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-contract")]
        public async Task<IActionResult> GetContractAsync(Guid id, [FromBody] HrPayslipGetContractRequestDto input)
        {
            var result = await _appService.GetContractAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-inputs")]
        public async Task<IActionResult> GetInputsAsync(Guid id, [FromBody] HrPayslipGetInputsRequestDto input)
        {
            var result = await _appService.GetInputsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-salary-line-total")]
        public async Task<IActionResult> GetSalaryLineTotalAsync(Guid id, [FromBody] HrPayslipGetSalaryLineTotalRequestDto input)
        {
            var result = await _appService.GetSalaryLineTotalAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-worked-day-lines")]
        public async Task<IActionResult> GetWorkedDayLinesAsync(Guid id, [FromBody] HrPayslipGetWorkedDayLinesRequestDto input)
        {
            var result = await _appService.GetWorkedDayLinesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-contract")]
        public async Task<IActionResult> OnchangeContractAsync(Guid id)
        {
            var result = await _appService.OnchangeContractAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-employee")]
        public async Task<IActionResult> OnchangeEmployeeAsync(Guid id)
        {
            var result = await _appService.OnchangeEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-employee-id")]
        public async Task<IActionResult> OnchangeEmployeeIdAsync(Guid id, [FromBody] HrPayslipOnchangeEmployeeIdRequestDto input)
        {
            var result = await _appService.OnchangeEmployeeIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/refund-sheet")]
        public async Task<IActionResult> RefundSheetAsync(Guid id)
        {
            var result = await _appService.RefundSheetAsync(id);
            return Ok(result);
        }
    }
}