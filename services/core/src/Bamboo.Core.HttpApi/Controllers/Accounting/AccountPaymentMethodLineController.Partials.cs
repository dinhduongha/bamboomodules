using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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