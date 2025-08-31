using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothSale
{
    public partial class EventBoothRegistrationController
    {
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
            return Ok(result);
        }
    }
}