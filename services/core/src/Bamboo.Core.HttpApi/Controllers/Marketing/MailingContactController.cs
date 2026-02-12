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
    [Route("api/v1/marketing/MailingContact")]
    public partial class MailingContactController : AbpController
    {
        protected readonly IMailingContactAppService _appService;
        public MailingContactController(IMailingContactAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-to-mailing-list")]
        public async Task<IActionResult> AddToMailingListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToMailingListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-import")]
        public async Task<IActionResult> ImportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ImportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-to-list")]
        public async Task<IActionResult> AddToListAsync([FromBody] MailingContactAddToListRequestDto input)
        {
            var result = await _appService.AddToListAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
    }
    
}