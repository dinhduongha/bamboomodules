using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/MailingSubscription")]
    public partial class MailingSubscriptionController : AbpController
    {
        protected readonly IMailingSubscriptionAppService _appService;
        public MailingSubscriptionController(IMailingSubscriptionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("open-mailing-contact")]
        public async Task<IActionResult> OpenMailingContactAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenMailingContactAsync(ids);
            return Ok(result);
        }
    }
    
}