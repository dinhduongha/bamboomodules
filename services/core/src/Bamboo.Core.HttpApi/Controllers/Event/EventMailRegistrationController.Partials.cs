using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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