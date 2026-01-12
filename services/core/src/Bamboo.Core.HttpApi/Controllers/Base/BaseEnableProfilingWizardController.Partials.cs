using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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