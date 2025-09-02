using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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