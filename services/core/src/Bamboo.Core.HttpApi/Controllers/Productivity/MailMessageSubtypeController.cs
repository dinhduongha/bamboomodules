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
    [Route("api/v1/productivity/MailMessageSubtype")]
    public partial class MailMessageSubtypeController : AbpController
    {
        protected readonly IMailMessageSubtypeAppService _appService;
        public MailMessageSubtypeController(IMailMessageSubtypeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("default-subtypes")]
        public async Task<IActionResult> DefaultSubtypesAsync([FromBody] MailMessageSubtypeDefaultSubtypesRequestDto input)
        {
            var result = await _appService.DefaultSubtypesAsync(input);
            return Ok(result);
        }
    }
    
}