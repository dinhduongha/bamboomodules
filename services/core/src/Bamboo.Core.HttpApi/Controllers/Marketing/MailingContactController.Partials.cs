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
        [Route("{id}/action-add-to-mailing-list")]
        public async Task<IActionResult> ActionAddToMailingListAsync(Guid id)
        {
            var result = await _appService.AddToMailingListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-import")]
        public async Task<IActionResult> ActionImportAsync(Guid id)
        {
            var result = await _appService.ImportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-to-list")]
        public async Task<IActionResult> AddToListAsync(Guid id, [FromBody] MailingContactAddToListRequestDto input)
        {
            var result = await _appService.AddToListAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
    }
}