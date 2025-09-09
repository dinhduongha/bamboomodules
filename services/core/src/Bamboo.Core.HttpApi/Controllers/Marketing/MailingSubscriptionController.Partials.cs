using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
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