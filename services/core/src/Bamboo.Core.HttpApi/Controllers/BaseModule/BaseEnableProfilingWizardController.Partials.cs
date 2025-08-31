using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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