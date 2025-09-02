using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class BaseEnableProfilingWizardController
    {
        
        [HttpPost]
        [Route("{id}/submit")]
        public async Task<IActionResult> SubmitAsync(Guid id)
        {
            var result = await _appService.SubmitAsync(id);
            return Ok(result);
        }
    }
}