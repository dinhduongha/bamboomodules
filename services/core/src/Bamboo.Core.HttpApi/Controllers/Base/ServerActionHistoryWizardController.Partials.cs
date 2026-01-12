using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ServerActionHistoryWizardController
    {
        
        [HttpPost]
        [Route("{id}/restore-revision")]
        public async Task<IActionResult> RestoreRevisionAsync(Guid id)
        {
            var result = await _appService.RestoreRevisionAsync(id);
            return Ok(result);
        }
    }
}