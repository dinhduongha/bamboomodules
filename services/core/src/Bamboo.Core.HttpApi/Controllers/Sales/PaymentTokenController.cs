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
    [Route("api/v1/payment/PaymentToken")]
    public partial class PaymentTokenController : AbpController
    {
        protected readonly IPaymentTokenAppService _appService;
        public PaymentTokenController(IPaymentTokenAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-linked-records-info")]
        public async Task<IActionResult> GetLinkedRecordsInfoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLinkedRecordsInfoAsync(ids);
            return Ok(result);
        }
    }
    
}