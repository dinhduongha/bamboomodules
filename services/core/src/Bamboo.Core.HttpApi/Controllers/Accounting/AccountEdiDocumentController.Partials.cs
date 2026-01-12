using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountEdiDocumentController
    {
        
        [HttpPost]
        [Route("{id}/action-export-xml")]
        public async Task<IActionResult> ActionExportXmlAsync(Guid id)
        {
            var result = await _appService.ExportXmlAsync(id);
            return Ok(result);
        }
    }
}