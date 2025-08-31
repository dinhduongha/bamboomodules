using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailAliasController
    {
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-document")]
        public async Task<IActionResult> OpenDocumentAsync(Guid id)
        {
            var result = await _appService.OpenDocumentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-parent-document")]
        public async Task<IActionResult> OpenParentDocumentAsync(Guid id)
        {
            var result = await _appService.OpenParentDocumentAsync(id);
            return Ok(result);
        }
    }
}