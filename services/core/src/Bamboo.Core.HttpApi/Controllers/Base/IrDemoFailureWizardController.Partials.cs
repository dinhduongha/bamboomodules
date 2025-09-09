using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrDemoFailureWizardController
    {
        
        [HttpPost]
        [Route("{id}/done")]
        public async Task<IActionResult> DoneAsync(Guid id)
        {
            var result = await _appService.DoneAsync(id);
            return Ok(result);
        }
    }
}