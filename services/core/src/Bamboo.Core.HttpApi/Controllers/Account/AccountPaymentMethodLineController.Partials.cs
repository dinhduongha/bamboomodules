using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountPaymentMethodLineController
    {
        
        [HttpPost]
        [Route("{id}/action-open-provider-form")]
        public async Task<IActionResult> ActionOpenProviderFormAsync(Guid id)
        {
            var result = await _appService.OpenProviderFormAsync(id);
            return Ok(result);
        }
    }
}