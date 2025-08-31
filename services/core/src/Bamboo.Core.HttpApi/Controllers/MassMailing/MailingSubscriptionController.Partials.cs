using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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