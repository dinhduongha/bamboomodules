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
    [Route("api/v1/productivity/MailAlias")]
    public partial class MailAliasController : AbpController
    {
        protected readonly IMailAliasAppService _appService;
        public MailAliasController(IMailAliasAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("open-document")]
        public async Task<IActionResult> OpenDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-parent-document")]
        public async Task<IActionResult> OpenParentDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenParentDocumentAsync(ids);
            return Ok(result);
        }
    }
    
}