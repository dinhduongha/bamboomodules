using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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