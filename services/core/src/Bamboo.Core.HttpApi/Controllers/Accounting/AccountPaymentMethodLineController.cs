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
    [Route("api/v1/accounting/AccountPaymentMethodLine")]
    public partial class AccountPaymentMethodLineController : AbpController
    {
        protected readonly IAccountPaymentMethodLineAppService _appService;
        public AccountPaymentMethodLineController(IAccountPaymentMethodLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-provider-form")]
        public async Task<IActionResult> OpenProviderFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProviderFormAsync(ids);
            return Ok(result);
        }
    }
    
}