using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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