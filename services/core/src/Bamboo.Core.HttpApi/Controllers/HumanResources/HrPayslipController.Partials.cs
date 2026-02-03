using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrPayslipController
    {
        
        [HttpPost]
        [Route("action-payslip-cancel")]
        public async Task<IActionResult> ActionPayslipCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PayslipCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-payslip-done")]
        public async Task<IActionResult> ActionPayslipDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PayslipDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-payslip-draft")]
        public async Task<IActionResult> ActionPayslipDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PayslipDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-done")]
        public async Task<IActionResult> CheckDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-sheet")]
        public async Task<IActionResult> ComputeSheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeSheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contract")]
        public async Task<IActionResult> GetContractAsync(HrPayslipGetContractRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetContractAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-inputs")]
        public async Task<IActionResult> GetInputsAsync(HrPayslipGetInputsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetInputsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-salary-line-total")]
        public async Task<IActionResult> GetSalaryLineTotalAsync(HrPayslipGetSalaryLineTotalRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSalaryLineTotalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-worked-day-lines")]
        public async Task<IActionResult> GetWorkedDayLinesAsync(HrPayslipGetWorkedDayLinesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWorkedDayLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-contract")]
        public async Task<IActionResult> OnchangeContractAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeContractAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-employee")]
        public async Task<IActionResult> OnchangeEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-employee-id")]
        public async Task<IActionResult> OnchangeEmployeeIdAsync(HrPayslipOnchangeEmployeeIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.OnchangeEmployeeIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refund-sheet")]
        public async Task<IActionResult> RefundSheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefundSheetAsync(ids);
            return Ok(result);
        }
    }
}