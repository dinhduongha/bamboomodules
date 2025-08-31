using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountTaxGroupController
    {
        
        [HttpPost]
        [Route("{id}/check-uninstall-required")]
        public async Task<IActionResult> CheckUninstallRequiredAsync(Guid id)
        {
            var result = await _appService.CheckUninstallRequiredAsync(id);
            return Ok(result);
        }
    }
}