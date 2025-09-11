using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WizardIrModelMenuCreateController
    {
        
        [HttpPost]
        [Route("{id}/menu-create")]
        public async Task<IActionResult> MenuCreateAsync(Guid id)
        {
            var result = await _appService.MenuCreateAsync(id);
            return Ok(result);
        }
    }
}