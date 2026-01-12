using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SmsTwilioNumberController
    {
        
        [HttpPost]
        [Route("{id}/action-unlink")]
        public async Task<IActionResult> ActionUnlinkAsync(Guid id)
        {
            var result = await _appService.UnlinkAsync(id);
            return Ok(result);
        }
    }
}