using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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