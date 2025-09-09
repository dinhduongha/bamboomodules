using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    public partial class EventMailRegistrationController
    {
        
        [HttpPost]
        [Route("{id}/execute")]
        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var result = await _appService.ExecuteAsync(id);
            return Ok(result);
        }
    }
}