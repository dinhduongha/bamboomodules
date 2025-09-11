using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingSubscriptionController
    {
        
        [HttpPost]
        [Route("{id}/open-mailing-contact")]
        public async Task<IActionResult> OpenMailingContactAsync(Guid id)
        {
            var result = await _appService.OpenMailingContactAsync(id);
            return Ok(result);
        }
    }
}