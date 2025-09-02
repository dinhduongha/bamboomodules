using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountReconcileModelPartnerMappingController
    {
        
        [HttpPost]
        [Route("{id}/validate-regex")]
        public async Task<IActionResult> ValidateRegexAsync(Guid id)
        {
            var result = await _appService.ValidateRegexAsync(id);
            return Ok(result);
        }
    }
}