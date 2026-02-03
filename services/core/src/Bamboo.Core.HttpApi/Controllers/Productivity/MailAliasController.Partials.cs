using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailAliasController
    {
        
        [HttpPost]
        [Route("open-document")]
        public async Task<IActionResult> OpenDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-parent-document")]
        public async Task<IActionResult> OpenParentDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenParentDocumentAsync(ids);
            return Ok(result);
        }
    }
}