using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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