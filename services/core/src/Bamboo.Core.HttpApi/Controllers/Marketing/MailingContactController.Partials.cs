using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingContactController
    {
        
        [HttpPost]
        [Route("action-add-to-mailing-list")]
        public async Task<IActionResult> ActionAddToMailingListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToMailingListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-import")]
        public async Task<IActionResult> ActionImportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ImportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-to-list")]
        public async Task<IActionResult> AddToListAsync(MailingContactAddToListRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddToListAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
    }
}