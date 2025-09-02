using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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